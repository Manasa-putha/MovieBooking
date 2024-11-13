using MBSBE.DBContext;
using MBSBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace MBSBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public MovieController(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("movies")]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie data is required.");
            }

            // Check for conflicts in shows
            //if (movie.Shows != null && movie.Shows.Any())
            //{
            //    foreach (var show in movie.Shows)
            //    {
            //        if (show.StartDate >= show.EndDate)
            //        {
            //            return BadRequest("Start date must be before end date.");
            //        }

            //        // Check for conflict
            //        bool conflict = await _context.Shows
            //            .AnyAsync(s => s.Screen_Number == show.Screen_Number) ;

            //        if (conflict)
            //        {
            //            return Conflict($"Show timing conflicts with an existing show on screen {show.Screen_Number}.");
            //        }
            //    }
            //}

            // Add the new movie and its shows
             _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            if (movie.Shows != null)
            {
                _context.Shows.AddRange(movie.Shows);
               // await _context.SaveChangesAsync();
            }
          
          

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }


        // Get all movies
        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();
       
            return Ok(movies);
        }

        // Get a movie by ID
        [HttpGet("movies/{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            //var movie = await _context.Movies.FindAsync(id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}
            //return Ok(movie);
            var movie = await _context.Movies
       .Include(m => m.Shows)
       .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpGet("movies/date")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {

            if (startDate > endDate)
            {
                return BadRequest("Start date cannot be after end date.");
            }
            DateTime parsedDate;
          

            var movieIds = await _context.Shows
                .Where(s => s.StartDate.Date <= endDate.Date && s.EndDate.Date >= startDate.Date)
                .Select(s => s.MovieId)
                .Distinct()
                .ToListAsync();
            if (!movieIds.Any())
            {
                return NotFound("No movies found for the specified date range.");
            }

            var movies = await _context.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();

            return Ok(movies);
        }

        [HttpGet("shows/movie/{movieId}/date/{date}")]
        public async Task<ActionResult<IEnumerable<Shows>>> GetShowsByMovieAndDate(int movieId, DateTime startDate, DateTime endDate)
        {
            //DateTime parsedDate;
            //if (!DateTime.TryParse(date, out parsedDate))
            //{
            //    return BadRequest("Invalid date format.");
            //}

            if (startDate > endDate)
            {
                return BadRequest("Start date cannot be after end date.");
            }
            var shows = await _context.Shows
            .Where(s => s.MovieId == movieId && s.StartDate.Date <= endDate.Date && s.EndDate.Date >= startDate.Date)
            .ToListAsync();

            if (!shows.Any())
            {
                return NotFound("No shows found for the specified movie and date range.");
            }

            return Ok(shows);
        }

    }
}

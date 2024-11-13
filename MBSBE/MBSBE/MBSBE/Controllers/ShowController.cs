using MBSBE.DBContext;
using MBSBE.Dtos;
using MBSBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Sockets;
using System.Security.Claims;

namespace MBSBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ShowController(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

      
        // Add a new show
        [HttpPost("shows")]
        public async Task<IActionResult> AddShow([FromBody] Shows show)
        {
            if (show == null)
            {
                return BadRequest("Show data is required.");
            }

            // Check for conflicts
            //bool conflict = await _context.Shows
            //    .AnyAsync(s => s.Screen_Number == show.Screen_Number &&
            //                   s.StartDate <= show.EndDate &&
            //                   s.EndDate >= show.StartDate);

            //if (conflict)
            //{
            //    return Conflict("Show timing conflicts with an existing show.");
            //}

            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShowById), new { id = show.Id }, show);
        }

        // Get shows by date
        [HttpGet("shows/date")]
        public async Task<ActionResult<IEnumerable<Shows>>> GetShowsByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
           
            var shows = await _context.Shows
                .Where(s => s.StartDate.Date <= endDate.Date && s.EndDate.Date >= startDate.Date)
                .ToListAsync();

            return Ok(shows);
        }


        // Get a show by ID
        [HttpGet("shows/{id}")]
        public async Task<ActionResult<Shows>> GetShowById(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            return Ok(show);
        }

   
        [HttpPost("shows/conflict")]
        public async Task<IActionResult> CheckShowConflict([FromBody] Shows show)
        {
            if (show == null)
            {
                return BadRequest("Show data is required.");
            }

            if (show.StartDate >= show.EndDate)
            {
                return BadRequest("Start date must be before end date.");
            }

            bool conflict = await _context.Shows
                .AnyAsync(s => s.Screen_Number == show.Screen_Number &&
                               s.StartDate < show.EndDate &&
                               s.EndDate > show.StartDate);

            return Ok(conflict);
        }


        [HttpPost("book")]
        public async Task<IActionResult> BookShow([FromBody] BookShowRequestDtos request)
        {
            if (request == null)
            {
                return BadRequest("Booking data is required.");
            }

            var show = await _context.Shows.FindAsync(request.ShowId);
            var movie = await _context.Movies.FindAsync(show.MovieId);
            if (movie == null)
            {
                return NotFound("Movie not found.");
            }
            if (show == null)
            {
                return NotFound("Show not found.");
            }

            if (request.Seats > 10)
            {
                return BadRequest("Cannot book more than 10 seats.");
            }

            if (request.Seats > show.No_of_seats)
            {
                return BadRequest("Not enough seats available.");
            }

            show.No_of_seats -= request.Seats;
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized("User is not logged in.");
            }
            // Create booking
            var booking = new Booking
            {
                TicketId = GenerateCustomTicketId(),
                UserId = int.Parse(userId),
                ShowId = request.ShowId,
                NumberOfSeats = request.Seats
            };

            await _context.Bookings.AddAsync(booking);
            _context.Shows.Update(show);
            await _context.SaveChangesAsync();


            // var ticketId = Guid.NewGuid().ToString();
            string ticketId = GenerateCustomTicketId();
            return Ok(new
            {
                TicketId = ticketId,
                MovieName = movie.MovieName,
                showTimings = show.ShowTimings,
                ScreenNumber = show.Screen_Number
            });
        }
        private string GenerateCustomTicketId()
        {
            // Example format: TICKET-YYYYMMDD-HHMMSS-RANDOM
            string prefix = "TICKET";
            string datePart = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            string randomPart = new Random().Next(1000, 9999).ToString();
            return $"{prefix}-{datePart}-{randomPart}";
        }


        [HttpGet("user-tickets")]
        public IActionResult GetUserTickets()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User is not logged in.");
            }
            var userId = int.Parse(userIdClaim);

            var ticketsQuery = _context.Bookings
                .Join(_context.Shows,
                      b => b.ShowId,
                      s => s.Id,
                      (b, s) => new { Booking = b, Show = s })
                .Join(_context.Movies,
                      combined => combined.Show.MovieId,
                      m => m.Id,
                      (combined, m) => new
                      {
                          combined.Booking.TicketId,
                          MovieName = m.MovieName,
                          ScreenNumber = combined.Show.Screen_Number,
                          ShowTime = combined.Show.ShowTimings,
                          StartDate = combined.Show.StartDate,
                          EndDate = combined.Show.EndDate,
                          NoOfSeats = combined.Booking.NumberOfSeats,
                          UserId = combined.Booking.UserId
                      });

            if (User.IsInRole("Admin"))
            {
                var adminTickets = ticketsQuery.ToList();
                return Ok(adminTickets);
            }
            else
            {
                var userTickets = ticketsQuery.Where(b => b.UserId == userId).ToList();

                if (!userTickets.Any())
                {
                    return NotFound("No tickets found for the user.");
                }

                return Ok(userTickets);
            }
        }


    }
}




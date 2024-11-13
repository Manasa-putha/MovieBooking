
export interface Movie {
    id: number;
    movieName: string;
    genre: string;
    director: string;
    description: string;
    Shows: Show[];
    ImageUrl: string;
  }
  
  export interface Show {
    id: number;
    StartDate: Date;
    EndDate: Date;
    showTimings: string;
    no_of_seats: number;
    price: number;
    screen_Number: number;
    movieId: number;
    seatsAvailable:number;
   
  }
  export interface User {
    id: number;
    userName: string;
    email: string;
    mobileNumber: string;
    alternativeNumber:string;
    password: string;
    // userType: UserType;
    role:Role;
    pincode:number;
    city:string;
    createdAt: string;
    UpdatedAt: string;
    tokensAvailable:number;
    basePrice:number;
  }
  export enum Role {
 
    None,Admin,Customer
  }
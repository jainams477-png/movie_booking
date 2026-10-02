using System;

namespace movie_booking.Models
{
    public class Movie
    {
        public int Movie_ID { get; set; }
        public string Movie_name { get; set; }
        public string Release_Date { get; set; }
        public int Cat_ID { get; set; }
        public string Cat_Type { get; set; }
        public int rate { get; set; }
    }
}
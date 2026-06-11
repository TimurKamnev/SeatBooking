namespace SeatBooking.Services;
using SeatBooking.Models;

public class SeatService()
{
    private readonly List<Movie> _movies = GenerateMovies();

    public List<Movie> GetMovies() => _movies;

    private static List<Movie> GenerateMovies()
    {
        return
        [
            new Movie
            {
                Id = "1",
                Name = "Man of steel",
                Description = "A movie about Superman and his adventures.",
                ImageUrl = "/Images/Man_Of_Steel.webp",
            },
            new Movie
            {
                Id = "2",
                Name = "The Lego Movie",
                Description = "A movie about Lego bricks and their adventures.",
                ImageUrl = "/Images/Lego_Movie.webp",
            },
            new Movie
            {
                Id = "3",
                Name = "Blitz",
                Description = "A movie about a fast-paced action story.",
                ImageUrl = "/Images/Blitz.webp",
            },
            new Movie
            {
                Id = "4",
                Name = "Interstellar",
                Description = "A movie about space and time.",
                ImageUrl = "/Images/Interstellar.webp",
            },
            new Movie
            {
                Id = "5",
                Name = "The Lord of the Rings",
                Description = "A movie about a fantasy world and its inhabitants.",
                ImageUrl = "/Images/Lord_of_the_rings.webp",
            }
        ];
    }
}


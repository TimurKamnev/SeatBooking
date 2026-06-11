namespace SeatBooking.Services;
using SeatBooking.Models;

public class SeatService()
{
    private readonly List<Movie> _movies = GenerateMovies();

    public List<Movie> GetMovies() => _movies;

    public Movie? GetMovie(string id) => _movies.FirstOrDefault(m => m.Id == id);

    public static int GetSelectedCount(Movie movie) => movie.Seats.SelectMany(s => s).Count(s => s.Status == PlaceStatus.Selected);

    public void ToggleSeat(string movieId, string seatId)
    {
        var movie = GetMovie(movieId);
        var seat = movie?.Seats.SelectMany(s => s).FirstOrDefault(s => s.Id == seatId);

        if(seat == null || seat.Status == PlaceStatus.Occupied) return;

        if(seat.Status == PlaceStatus.Empty && GetSelectedCount(movie!) >= 8) return;

        seat.Status = seat.Status == PlaceStatus.Selected 
            ? PlaceStatus.Empty 
            : PlaceStatus.Selected;
    }

    public void ResetSeats(string movieId)
    {
        var movie = GetMovie(movieId);

        if(movie == null) return;

        foreach(var seat in movie.Seats.SelectMany(s => s))
        {
            if(seat.Status == PlaceStatus.Selected)
            {
                seat.Status = PlaceStatus.Empty;
            }
        }
    }

    public void BookSeats(string movieId)
    {
        var movie = GetMovie(movieId);

        if(movie == null) return;

        foreach(var seat in movie.Seats.SelectMany(s => s))
        {
            if(seat.Status == PlaceStatus.Selected)
            {
                seat.Status = PlaceStatus.Occupied;
            }
        }
    }

    private static List<Movie> GenerateMovies()
    {
        return
        [
            new Movie
            {
                Id = "1",
                Name = "Человек из стали",
                Description = "Надежда, в основе этой надежды лежит вера в потенциал каждого человека в том что его задача творить добро.",
                ImageUrl = "/Images/Man_Of_Steel.webp",
                Seats = GenerateSeats(5, 5)
            },
            new Movie
            {
                Id = "2",
                Name = "Лего фильм",
                Description = "Детский мультфильм о приключении и жизни особенного героя.",
                ImageUrl = "/Images/Lego_Movie.webp",
                Seats = GenerateSeats(8, 10)
            },
            new Movie
            {
                Id = "3",
                Name = "Без компромиссов",
                Description = "Брутальный фильм и завораживающие события которые покажут мир наизнанку.",
                ImageUrl = "/Images/Blitz.webp",
                Seats = GenerateSeats(8, 10)
            },
            new Movie
            {
                Id = "4",
                Name = "Интерстеллар",
                Description = "Космическое приключение и спасение миллионов жизней",
                ImageUrl = "/Images/Interstellar.webp",
                Seats = GenerateSeats(2, 4)
            },
            new Movie
            {
                Id = "5",
                Name = "Властелин колец",
                Description = "Невероятное приключение хоббитов и приключение.",
                ImageUrl = "/Images/Lord_of_the_rings.webp",
                Seats = GenerateSeats(10, 12)
            }
        ];
    }

    private static List<List<Seat>> GenerateSeats(int rows, int columns)
    {
        var seats = new List<List<Seat>>();
        var random = new Random();

        for(int i = 0; i < rows; i++)
        {
            var cols = i < 2 ? columns + 2 : columns;
            var rowSeats = new List<Seat>();

            for(int j = 0; j < cols; j++)
            {
                rowSeats.Add(new Seat
                {
                    Id = $"{i}-{j}",
                    Row = i,
                    Column = j,
                    Status = random.Next(0, 5) == 0 ? PlaceStatus.Occupied : PlaceStatus.Empty
                });
            }
            seats.Add(rowSeats);
        }

        return seats;
    }
}


namespace SeatBooking.Models;

public class Movie
{
    public string Id {get; set;} = "";
    public string Name {get; set;} = "";
    public string Description {get; set;} = "";
    public List<string> Genre {get; set;} = [];
    public string ImageUrl {get; set;} = "";
    public List<List<Seat>> Seats {get; set;} = [];
}
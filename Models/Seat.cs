namespace SeatBooking.Models;

public enum PlaceStatus
{
    Empty,
    Selected,
    Occupied
}

public class Seat
{
    public string Id {get; set;} = "";
    public int Row {get; set;}
    public int Column {get; set;}
    public PlaceStatus Status {get; set;} = PlaceStatus.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace PaintCalc2
{
public class RoomDimensions
{
    //Properties

    [Required(ErrorMessage = "Room width is required.")]
    [Range(1, 1000000, ErrorMessage = "Room width must be between 1 and 1000000.")]
    public double RoomWidth { get; set; }

    [Required(ErrorMessage = "Room height is required.")]
    [Range(1, 1000000, ErrorMessage = "Room height must be between 1 and 1000000.")]
    public double RoomHeight { get; set; }

    [Required(ErrorMessage = "Room length is required.")]
    [Range(1, 1000000, ErrorMessage = "Room length must be between 1 and 1000000.")]
    public double RoomLength { get; set; }

    public bool CeilingIncluded { get; set; }
    public double FloorArea { get; set; }
    public double RoomVolume { get; set; }
    public double PaintNeeded { get; set; }

    //Methods

    public void CalculateFloorArea() {
        FloorArea = RoomWidth * RoomLength;
    }

    public void CalculateRoomVolume() {
        RoomVolume = FloorArea * RoomHeight;
    }

    public void CalculatePaintNeeded() {

        //Equation to find the surface area of a cuboid
        PaintNeeded = 2 * ((RoomWidth * RoomLength) + (RoomWidth * RoomHeight) + (RoomLength * RoomHeight));

        //Remove one floorArea worth as the floor likely wont be painted
        PaintNeeded -= FloorArea;

        //Check whether the Ceiling is being painted
        if (!CeilingIncluded) {
            PaintNeeded -= FloorArea;
        }
    }
}
}
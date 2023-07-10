using MarsRobot.Enums;

namespace MarsRobot;

public class Robot
{
    public int XCoord { get; set; }
    public int YCoord { get; set; }
    public FacingDirection FacingDirection { get; set; }

    public Robot() : this(1, 1, FacingDirection.North)
    {
    }

    private Robot(int xCoord, int yCoord, FacingDirection facingDirection)
    {
        XCoord = xCoord;
        YCoord = yCoord;
        FacingDirection = facingDirection;
    }
}
using MarsRobot.Enums;

namespace MarsRobot.Services;

public class MovingService : IMovingService
{
    public void Move(Robot robot, Plateau plateau)
    {
        switch (robot.FacingDirection)
        {
            case FacingDirection.North:
                MoveNorth(robot, plateau);
                break;
            case FacingDirection.East:
                MoveEast(robot, plateau);
                break;
            case FacingDirection.South:
                MoveSouth(robot, plateau);
                break;
            case FacingDirection.West: 
                MoveWest(robot, plateau);
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    private void MoveNorth(Robot robot, Plateau plateau)
    {
        robot.YCoord = robot.YCoord == plateau.YBound ? robot.YCoord : robot.YCoord + 1;
    }
    
    private void MoveSouth(Robot robot, Plateau plateau)
    {
        robot.YCoord = robot.YCoord == 1 ? robot.YCoord : robot.YCoord - 1;
    }
    
    private void MoveEast(Robot robot, Plateau plateau)
    {
        robot.XCoord = robot.XCoord == plateau.XBound? robot.XCoord : robot.XCoord + 1;
    }
    
    private void MoveWest(Robot robot, Plateau plateau)
    {
        robot.XCoord = robot.XCoord == 1 ? robot.XCoord : robot.XCoord - 1;
    }
}
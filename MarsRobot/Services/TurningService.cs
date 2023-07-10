using MarsRobot.Enums;

namespace MarsRobot.Services;

public class TurningService : ITurningService
{
    public void Turn(Robot robot, RobotCommandTypes turningRobotCommandTypes)
    {
        robot.FacingDirection = turningRobotCommandTypes switch
        {
            RobotCommandTypes.R => TurnRight(robot.FacingDirection),
            RobotCommandTypes.L => TurnLeft(robot.FacingDirection),
            _ => robot.FacingDirection
        };
    }

    private static FacingDirection TurnRight(FacingDirection direction)
    {
        return direction switch
        {
            FacingDirection.North => FacingDirection.East,
            FacingDirection.East => FacingDirection.South,
            FacingDirection.South => FacingDirection.West,
            _ => FacingDirection.North
        };
    }
    
    private static FacingDirection TurnLeft(FacingDirection direction)
    {
        return direction switch
        {
            FacingDirection.North => FacingDirection.West,
            FacingDirection.West => FacingDirection.South,
            FacingDirection.South => FacingDirection.East,
            _ => FacingDirection.North
        };
    }
}
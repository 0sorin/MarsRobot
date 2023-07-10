using MarsRobot.Enums;

namespace MarsRobot.Services;

public class MarsRobotService : IMarsRobotService
{
    private readonly ITurningService _turningService;
    private readonly IMovingService _movingService;
    
    public MarsRobotService(IMovingService movingService, ITurningService turningService)
    {
        _movingService = movingService;
        _turningService = turningService;
    }
    
    public Robot RunCommands(Plateau plateau, Robot robot, List<RobotCommandTypes> commandsList)
    {
        foreach (var command in commandsList)
        {
            if (command == RobotCommandTypes.F)
                Move(plateau, robot);
            else
                Turn(robot, command);
        }
        return robot;
    }

    private void Move(Plateau plateau, Robot robot)
    {
        _movingService.Move(robot, plateau);
    }

    private void Turn(Robot robot, RobotCommandTypes turnCommand)
    {
        _turningService.Turn(robot, turnCommand);
    }
    
}
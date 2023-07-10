using MarsRobot.Enums;

namespace MarsRobot.Services;

public interface IMarsRobotService
{
    Robot RunCommands(Plateau plateau, Robot robot, List<RobotCommandTypes> commandsList);
}
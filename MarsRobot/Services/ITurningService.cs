using MarsRobot.Enums;

namespace MarsRobot.Services;

public interface ITurningService
{
    void Turn(Robot robot, RobotCommandTypes turningRobotCommandTypes);
}
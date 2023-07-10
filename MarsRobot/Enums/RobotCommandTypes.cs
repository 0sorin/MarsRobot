using System.ComponentModel;

namespace MarsRobot.Enums;

public enum RobotCommandTypes
{
    [Description("Move Forward")]
    F,
    [Description("Turn Left")]
    L,
    [Description("Turn Right")]
    R
}
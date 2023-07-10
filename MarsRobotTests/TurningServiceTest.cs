using System.Linq;
using MarsRobot;
using MarsRobot.Enums;
using MarsRobot.Services;
using Xunit;

namespace MarsRobotTests;

public class TurningServiceTest
{
    [Theory]
    [InlineData(RobotCommandTypes.F, FacingDirection.North, 1, FacingDirection.North)]
    [InlineData(RobotCommandTypes.F, FacingDirection.East, 1, FacingDirection.East)]
    [InlineData(RobotCommandTypes.F, FacingDirection.South, 1, FacingDirection.South)]
    [InlineData(RobotCommandTypes.F, FacingDirection.West, 1, FacingDirection.West)]
    
    [InlineData(RobotCommandTypes.R, FacingDirection.North, 1, FacingDirection.East)]
    [InlineData(RobotCommandTypes.R, FacingDirection.North, 2, FacingDirection.South)]
    [InlineData(RobotCommandTypes.R, FacingDirection.North, 4, FacingDirection.North)]
    [InlineData(RobotCommandTypes.R, FacingDirection.East, 1, FacingDirection.South)]
    [InlineData(RobotCommandTypes.R, FacingDirection.South, 1, FacingDirection.West)]
    [InlineData(RobotCommandTypes.R, FacingDirection.West, 1, FacingDirection.North)]
    
    [InlineData(RobotCommandTypes.L, FacingDirection.North, 1, FacingDirection.West)]
    [InlineData(RobotCommandTypes.L, FacingDirection.North, 2, FacingDirection.South)]
    [InlineData(RobotCommandTypes.L, FacingDirection.North, 4, FacingDirection.North)]
    [InlineData(RobotCommandTypes.L, FacingDirection.East, 1, FacingDirection.North)]
    [InlineData(RobotCommandTypes.L, FacingDirection.South, 1, FacingDirection.East)]
    [InlineData(RobotCommandTypes.L, FacingDirection.West, 1, FacingDirection.South)]
    public void GivenRobot_OnTurn_UpdateDirection(RobotCommandTypes command, FacingDirection direction, int numberOfTurns, FacingDirection expectedDirection)
    {
        // Given
        var turningService = new TurningService();
        var robot = new Robot()
        {
            FacingDirection = direction
        };
            
        // When
        foreach (var i in Enumerable.Range(1,numberOfTurns))
        {
            turningService.Turn(robot, command);
        }
        
        // Then
        Assert.Equal(expectedDirection, robot.FacingDirection);
    }
}
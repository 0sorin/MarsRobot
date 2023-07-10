using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarsRobot;
using MarsRobot.Enums;
using MarsRobot.Services;
using Moq;
using Xunit;

namespace MarsRobotTests;

public class MovingServiceTest
{
    [Theory]
    [InlineData(10, 1, 1, FacingDirection.North, 1, 1, 2)]
    [InlineData(10, 1, 1, FacingDirection.North, 3, 1, 4)]
    [InlineData(1, 1, 1, FacingDirection.North, 1, 1, 1)]
    [InlineData(10, 1, 10, FacingDirection.North, 1, 1, 10)]
    
    [InlineData(10, 1, 1, FacingDirection.South, 1, 1, 1)]
    [InlineData(10, 1, 10, FacingDirection.South, 3, 1, 7)]
    [InlineData(1, 1, 1, FacingDirection.South, 1, 1, 1)]
    [InlineData(10, 1, 10, FacingDirection.South, 1, 1, 9)]
    
    [InlineData(10, 1, 1, FacingDirection.East, 1, 2, 1)]
    [InlineData(10, 1, 1, FacingDirection.East, 3, 4, 1)]
    [InlineData(1, 1, 1, FacingDirection.East, 1, 1, 1)]
    [InlineData(10, 10, 1, FacingDirection.East, 1, 10, 1)]
    
    [InlineData(10, 1, 1, FacingDirection.West, 1, 1, 1)]
    [InlineData(10, 10, 1, FacingDirection.West, 3, 7, 1)]
    [InlineData(1, 1, 1, FacingDirection.West, 1, 1, 1)]
    [InlineData(10, 10, 1, FacingDirection.West, 1, 9, 1)]
    public void GivenRobot_OnMove_UpdateCoords(int plateauDimensions, int x, int y, FacingDirection direction, int numberOfMoves, int expectedX, int expectedY)
    {
        // Given
        var plateau = new Plateau(plateauDimensions, plateauDimensions);
        var movingService = new MovingService();
        var robot = new Robot()
        {
            FacingDirection = direction,
            XCoord = x,
            YCoord = y
        };
            
        // When
        foreach (var i in Enumerable.Range(1,numberOfMoves))
        {
            movingService.Move(robot, plateau);
        }
        
        // Then
        Assert.Equal(expectedY, robot.YCoord);
        Assert.Equal(expectedX, robot.XCoord);
    }
}


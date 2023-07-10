using System.Collections;
using System.Collections.Generic;
using MarsRobot;
using MarsRobot.Enums;
using MarsRobot.Services;
using Moq;
using Xunit;

namespace MarsRobotTests;

public class MarsRobotServiceTest
{

    private readonly Mock<ITurningService> _mockTurningService;
    private readonly Mock<IMovingService> _mockMovingService;
    private readonly Plateau _plateau;

    public MarsRobotServiceTest()
    {
        _mockTurningService = new Mock<ITurningService>();
        _mockMovingService = new Mock<IMovingService>();
        _plateau = new Plateau(100, 100);
    }


    [Theory]
    [ClassData(typeof(MarsRobotServiceTestData))]
    public void GivenCommands_OnExecute_CallsRightMethods(List<RobotCommandTypes> commands, int expectedTurns, int expectedMoves)
    {
        // Given
        var plateau = new Plateau(100, 100);
        var marsRobotService = new MarsRobotService(_mockMovingService.Object, _mockTurningService.Object);
        
        // When
        marsRobotService.RunCommands(plateau, new Robot(), commands);
        
        // Then
        _mockTurningService.Verify(s => s.Turn(It.IsAny<Robot>(), It.IsAny<RobotCommandTypes>()), Times.Exactly(expectedTurns));
        _mockMovingService.Verify(s => s.Move(It.IsAny<Robot>(), It.IsAny<Plateau>()), Times.Exactly(expectedMoves));
    }

    [Fact]
    public void GivenMoveCommand_OnExecute_ReturnsUpdatedCoords()
    {
        Robot robot = new Robot();
        _mockMovingService.Setup(s => s.Move(robot, _plateau)).Callback(() => robot.XCoord = 3);
        var marsRobotService = new MarsRobotService(_mockMovingService.Object, _mockTurningService.Object);
        var commands = new List<RobotCommandTypes> {RobotCommandTypes.R, RobotCommandTypes.F, RobotCommandTypes.L};
        
        var finalRobot = marsRobotService.RunCommands(_plateau, new Robot(), commands);
        
        Assert.Equal(robot.XCoord, finalRobot.XCoord);
    }
    
    [Fact]
    public void GivenTurnCommand_OnExecute_ReturnsUpdatedDirection()
    {
        Robot robot = new Robot();
        _mockTurningService.Setup(s => s.Turn(robot, RobotCommandTypes.R)).Callback(() => robot.FacingDirection = FacingDirection.East);
        var marsRobotService = new MarsRobotService(_mockMovingService.Object, _mockTurningService.Object);
        var commands = new List<RobotCommandTypes> {RobotCommandTypes.R, RobotCommandTypes.F, RobotCommandTypes.L};
        
        var finalRobot = marsRobotService.RunCommands(_plateau, new Robot(), commands);
        
        Assert.Equal(robot.FacingDirection, finalRobot.FacingDirection);
    }

    
    private class MarsRobotServiceTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<RobotCommandTypes> {RobotCommandTypes.R, RobotCommandTypes.F, RobotCommandTypes.L},
                2,
                1
            };
            yield return new object[]
            {
                new List<RobotCommandTypes> {RobotCommandTypes.F, RobotCommandTypes.F, RobotCommandTypes.F},
                0,
                3
            };
        }
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


using MarsRobot.Services;
using MarsRobot.Validators;

namespace MarsRobot;

public class MarsRobot
{
    private readonly IMarsRobotService _robotService;
    
    public MarsRobot(IMarsRobotService robotService)
    {
        _robotService = robotService;
    }
    
    public void Run(string[] args)
    {
        if(!InputValidations.ValidateDimensions(Console.ReadLine(), out var gridHeight, out var gridWidth))
            throw new ArgumentException("Invalid grid dimensions provided");

        if(!InputValidations.ValidateCommands(Console.ReadLine(), out var commandsList))
            throw new ArgumentException("Invalid commands provided");

        Plateau plateau = new(gridHeight,gridWidth);
        Robot robot = new();
        
        robot = _robotService.RunCommands(plateau, robot, commandsList);
        
        Console.WriteLine($"{robot.XCoord},{robot.YCoord},{robot.FacingDirection.ToString()}");
    }
}
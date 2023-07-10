using MarsRobot.Enums;

namespace MarsRobot.Validators;

public static class InputValidations
{
    public static bool ValidateDimensions(string? inputDimensions, out int x, out int y)
    {
        x = 0;
        y = 0;
        if (string.IsNullOrWhiteSpace(inputDimensions)) return false;
        var dimensions = inputDimensions.ToLowerInvariant().Split('x');
        return dimensions.Length == 2 && 
               Int32.TryParse(dimensions[0], out x) &&
               Int32.TryParse(dimensions[1], out y);
    }
    
    public static bool ValidateCommands(string? inputCommands, out List<RobotCommandTypes> commandsList)
    {
        commandsList = new List<RobotCommandTypes>();
        if (string.IsNullOrWhiteSpace(inputCommands)) return false;

        foreach (var command in inputCommands.ToUpperInvariant().ToCharArray())
        {
            if (Enum.TryParse<RobotCommandTypes>(command.ToString(), out var currentCommand))
            {
                commandsList.Add(currentCommand);
            }
            else
            {
                return false;
            }

        }

        return true;
    }
}
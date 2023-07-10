using MarsRobot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<MarsRobot.MarsRobot>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, serviceCollection) =>
        {
            serviceCollection.AddSingleton<IMarsRobotService, MarsRobotService>();
            serviceCollection.AddSingleton<IMovingService, MovingService>();
            serviceCollection.AddSingleton<ITurningService, TurningService>();
            serviceCollection.AddSingleton<MarsRobot.MarsRobot>();
        });
}
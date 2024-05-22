using System.CommandLine;
using TestDoubleGenerator.Cli.Commands;
using TestDoubleGenerator.Cli.Extensions;

namespace TestDoubleGenerator.Cli;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        Console.WriteLine(string.Join(" ", args));

        var rootCommand = new RootCommand();
        rootCommand.AddCommands<GenerateCommand>();

        return await rootCommand.InvokeAsync(args);
    }
}
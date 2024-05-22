using System.Diagnostics;

namespace TestDoubleGenerator.Cli.Tests;

public static class ProcessRunner
{
    public static async Task<RunResult?> RunProcessAsync(string processName, string arguments, string? workingDirectory = null)
    {
        var startInfo = new ProcessStartInfo(processName, arguments)
        {
            UseShellExecute = false,
            WorkingDirectory = workingDirectory ?? ".",
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        using var process = Process.Start(startInfo);
        if (process == null)
        {
            return null;
        }

        var result = await process.StandardOutput.ReadToEndAsync();
        result += await process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        return new RunResult(process.ExitCode, result);
    }
}

public record RunResult(int ExitCode, string Output);

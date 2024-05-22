using Xunit.Abstractions;

namespace TestDoubleGenerator.Cli.Tests;

public class GeneratorShould(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task GenerateFromFile()
    {
        var result = await ProcessRunner.RunProcessAsync("tdgen.exe", @"generate --source ""..\..\..\..\..\swagger.json"" --output "".\WebApplicationExtensions.cs"" --dry-run");

        testOutputHelper.WriteLine(result?.Output);
        Assert.Equal(0, result?.ExitCode);
    }

    [Fact]
    public async Task GenerateFromUri()
    {
        var result = await ProcessRunner.RunProcessAsync("tdgen.exe", @"generate --source ""https://petstore.swagger.io/v2/swagger.json"" --output "".\WebApplicationExtensions.cs"" --dry-run");

        testOutputHelper.WriteLine(result?.Output);
        Assert.Equal(0, result?.ExitCode);
    }
}

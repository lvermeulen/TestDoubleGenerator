using NSwag;
using Xunit.Abstractions;

namespace TestDoubleGenerator.Tests;

public class GeneratorShould(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public async Task GenerateFromFile()
    {
        var document = await OpenApiDocument.FromFileAsync(@"..\..\..\..\..\swagger.json");
        GenerateInternal(document);
    }

    [Fact]
    public async Task GenerateFromUri()
    {
        var document = await OpenApiDocument.FromUrlAsync("https://petstore.swagger.io/v2/swagger.json");
        GenerateInternal(document);
    }

    private void GenerateInternal(OpenApiDocument document)
    {
        var generatorSettings = new GeneratorSettings(@"..\..\..\..\..\src\WebApplication1\WebApplicationExtensions.cs");
        var result = Generator.Generate(document, generatorSettings);
        testOutputHelper.WriteLine(result);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}
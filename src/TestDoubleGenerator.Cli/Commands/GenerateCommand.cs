using System.CommandLine.IO;
using System.CommandLine;
using NSwag;

namespace TestDoubleGenerator.Cli.Commands;

internal class GenerateCommand(string name, string? description = null) : Command(name, description)
{
    private const string CommandName = "generate";
    private const string CommandDescription = "Generate OpenApi endpoints from an OpenApi description";

    public GenerateCommand()
        : this(CommandName, CommandDescription)
    {
        var openApiSource = new Option<string>("--source", "The OpenApi source (file name or uri).");
        var outputFolder = new Option<string>(["--output"], "The destination folder and filename for the generated code.");
        var dryrun = new Option<bool>(["--dry-run"], "Displays a summary of what would happen if the given command line were run.");

        AddOption(openApiSource);
        AddOption(outputFolder);
        AddOption(dryrun);
        this.SetHandler(Handle, openApiSource, outputFolder, dryrun);
    }

    private static async Task Handle(string openApiSource, string outputFolder, bool dryrun)
    {
        var settings = new GeneratorSettings(outputFolder);

        var isUri = Uri.IsWellFormedUriString(openApiSource, UriKind.Absolute);
        var document = isUri
            ? await OpenApiDocument.FromUrlAsync(openApiSource)
            : await OpenApiDocument.FromFileAsync(openApiSource);

        var result = Generator.Generate(document, settings);
        if (!dryrun)
        {
            await File.WriteAllTextAsync(settings.Output, result);
        }

        IConsole console = new SystemConsole();
        var wasWouldHaveBeen = dryrun
            ? "would have been"
            : "was";
        console.WriteLine($"OpenApi endpoints file {Path.GetFileName(settings.Output)} {wasWouldHaveBeen} successfully generated.");
    }
}
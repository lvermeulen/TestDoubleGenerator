using System.Text;
using NJsonSchema;
using NSwag;

namespace TestDoubleGenerator;

public static class Generator
{
    public static string Generate(OpenApiDocument document, GeneratorSettings generatorSettings)
    {
        var sb = new StringBuilder();

        GeneratePreamble(generatorSettings, sb);
        GenerateEndpoints(document, sb);
        GeneratePostamble(sb);

        return sb.ToString();
    }

    private static void GeneratePreamble(GeneratorSettings generatorSettings, StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine($@"public static class {Path.GetFileNameWithoutExtension(generatorSettings.Output)}
{{
    public static WebApplication MapOpenApiEndpoints(this WebApplication webApplication)
    {{");
    }

    private static void GenerateEndpoints(OpenApiDocument document, StringBuilder stringBuilder)
    {
        foreach (var operationDescription in document.Operations)
        {
            var parameters = string.Join(", ", operationDescription.Operation.Parameters.Select(x => $"{GenerateAspNetCoreType(x.ActualSchema.Type)} {x.Name}"));
            var generated = @$"        webApplication.{GenerateAspNetCoreMethod(operationDescription.Method)}(""{operationDescription.Path}"",
            ({parameters}) =>
            {{
                return Task.FromResult(Results.Ok());
            }});";
            stringBuilder.AppendLine(generated);
            stringBuilder.AppendLine("");
        }
    }

    private static void GeneratePostamble(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine(@"        return webApplication;
    }
}");
    }

    private static string GenerateAspNetCoreMethod(string method)
    {
        return method.ToLowerInvariant() switch
        {
            "get" => "MapGet",
            "put" => "MapPut",
            "post" => "MapPost",
            "delete" => "MapDelete",
            "patch" => "MapPatch",
            _ => "MapUnknown"
        };
    }

    private static string GenerateAspNetCoreType(JsonObjectType type)
    {
        return type switch
        {
            JsonObjectType.Boolean => "bool",
            JsonObjectType.Integer => "int",
            JsonObjectType.Number => "decimal",
            JsonObjectType.Object => "object",
            JsonObjectType.String => "string",
            JsonObjectType.Array => "Array",
            JsonObjectType.File => "byte[]",
            _ => "UNKNOWN"
        };
    }
}

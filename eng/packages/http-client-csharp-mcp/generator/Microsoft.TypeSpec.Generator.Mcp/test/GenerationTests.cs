// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.Json;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class GenerationTests
{
    [Test]
    public async Task MultipleServicesGenerateAndCompileWithoutServiceSpecificProviders()
    {
        var package = FindPackage();
        var root = Path.Combine(package, "temp", Guid.NewGuid().ToString("N"));
        var generation = Path.Combine(root, "generation");
        var source = Path.Combine(root, "src");
        Directory.CreateDirectory(generation);
        Directory.CreateDirectory(source);
        try
        {
            CreateLocalCompilerAndHttpSentinels(root);
            File.WriteAllText(Path.Combine(root, "Directory.Build.props"), "<Project />");
            File.WriteAllText(Path.Combine(root, "Directory.Build.targets"), "<Project />");
            File.WriteAllText(Path.Combine(root, "Directory.Packages.props"), "<Project />");
            File.WriteAllText(Path.Combine(source, "Example.csproj"), """
                <Project Sdk="Microsoft.NET.Sdk">
                  <PropertyGroup>
                    <TargetFramework>net10.0</TargetFramework>
                    <Nullable>enable</Nullable>
                    <ImplicitUsings>enable</ImplicitUsings>
                  </PropertyGroup>
                </Project>
                """);
            File.WriteAllText(Path.Combine(source, "ExistingTypes.cs"), ExistingTypes);
            var specification = CreateSpecification();
            File.WriteAllText(Path.Combine(generation, "main.tsp"), specification);
            var emitterOptions = new Dictionary<string, object>
            {
                ["emitter-output-dir"] = root,
                ["package-name"] = "Example",
                ["new-project"] = false
            };
            var configuration = new
            {
                emit = new[] { package },
                options = new Dictionary<string, object>
                {
                    ["@azure-typespec/mcp-tools"] = emitterOptions
                }
            };
            File.WriteAllText(Path.Combine(generation, "tspconfig.yaml"), JsonSerializer.Serialize(configuration));
            var compiler = Path.Combine(package, "node_modules", "@typespec", "compiler", "cmd", "tsp.js");
            var library = Path.Combine(package, "lib", "main.tsp");
            var emitted = await Run("node", generation, compiler, "compile", "main.tsp", "--import", library);
            Assert.That(emitted.ExitCode, Is.Zero, emitted.Output);
            var output = Path.Combine(source, "Generated");
            Assert.That(Directory.GetFiles(output, "*.cs"), Has.Length.EqualTo(10));
            var secret = File.ReadAllText(Path.Combine(output, "SecretBinding.cs"));
            var queue = File.ReadAllText(Path.Combine(output, "QueueBinding.cs"));
            Assert.That(secret, Does.Contain("await client.GetSecretAsync(name, null, cancellationToken: cancellationToken).ConfigureAwait(false)"));
            Assert.That(queue, Does.Contain("await client.DeleteQueueAsync(name, null, cancellationToken: cancellationToken).ConfigureAwait(false)"));
            Assert.That(File.Exists(Path.Combine(root, "tspMcpCodeModel.json")), Is.False);
            Assert.That(File.ReadAllText(Path.Combine(output, "SecretOptions.cs")), Does.Contain("required string Name"));
            Assert.That(File.ReadAllText(Path.Combine(output, "QueueOptions.cs")), Does.Contain("int? Limit"));
            Assert.That(File.ReadAllText(Path.Combine(output, "SecretCatalog.cs")), Does.Contain("ReadOnly = true"));
            Assert.That(File.ReadAllText(Path.Combine(output, "QueueCatalog.cs")), Does.Contain("Destructive = true"));
            var compiled = await Run("dotnet", source, "build", "Example.csproj", "--nologo", "--verbosity", "quiet");
            Assert.That(compiled.ExitCode, Is.Zero, compiled.Output);

            emitterOptions["save-inputs"] = true;
            File.WriteAllText(Path.Combine(generation, "tspconfig.yaml"), JsonSerializer.Serialize(configuration));
            File.WriteAllText(Path.Combine(generation, "main.tsp"),
                specification.Replace("@path name: string", "@path name: string, @query extra?: string", StringComparison.Ordinal));
            var rejected = await Run("node", generation, compiler, "compile", "main.tsp", "--import", library);
            Assert.That(rejected.ExitCode, Is.Not.Zero, rejected.Output);
            Assert.That(rejected.Output, Does.Contain("needs a matching primitive option mapping"));
            Assert.That(File.Exists(Path.Combine(root, "tspMcpCodeModel.json")), Is.True);

            File.WriteAllText(Path.Combine(generation, "main.tsp"),
                specification.Replace("@query mode: \"1\"", "@query mode: 1", StringComparison.Ordinal));
            var wrongConstant = await Run("node", generation, compiler, "compile", "main.tsp", "--import", library);
            Assert.That(wrongConstant.ExitCode, Is.Not.Zero, wrongConstant.Output);
            Assert.That(wrongConstant.Output, Does.Contain("Additional or mismatched wire parameters"));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private static string TypeSpecValue(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.Object => "#{" + string.Join(", ", value.EnumerateObject()
            .Select(p => $"{p.Name}: {TypeSpecValue(p.Value)}")) + "}",
        JsonValueKind.Array => "#[" + string.Join(", ", value.EnumerateArray().Select(TypeSpecValue)) + "]",
        _ => value.GetRawText()
    };

    [TestCase("missing-service", "exactly one @mcpService")]
    [TestCase("missing-tool", "at least one @tool")]
    [TestCase("duplicate-service", "duplicate-decorator")]
    [TestCase("wrong-namespace", "must belong to the @mcpService namespace")]
    [TestCase("invalid-schema", "not assignable")]
    public async Task InvalidTypeSpecMetadataProducesDiagnostics(string change, string message)
    {
        var package = FindPackage();
        var root = Path.Combine(package, "temp", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            var specification = CreateSpecification();
            specification = change switch
            {
                "missing-service" => string.Join('\n', specification.Split('\n')
                    .Where(line => !line.TrimStart().StartsWith("@mcpService(", StringComparison.Ordinal))),
                "missing-tool" => string.Join('\n', specification.Split('\n')
                    .Where(line => !line.TrimStart().StartsWith("@tool(", StringComparison.Ordinal))),
                "duplicate-service" => specification.Replace("@mcpService(",
                    specification.Split('\n').Single(line => line.TrimStart().StartsWith("@mcpService(", StringComparison.Ordinal)) +
                    "\n@mcpService(", StringComparison.Ordinal),
                "wrong-namespace" => specification.Replace("namespace Services;", "namespace Services {}", StringComparison.Ordinal),
                "invalid-schema" => specification.Replace("outputNamespace: \"Example.Generated\"", "outputNamespace: 123", StringComparison.Ordinal),
                _ => throw new ArgumentException("Unknown diagnostic case.", nameof(change))
            };
            File.WriteAllText(Path.Combine(root, "main.tsp"), specification);
            var result = await Run("node", root,
                Path.Combine(package, "node_modules", "@typespec", "compiler", "cmd", "tsp.js"),
                "compile", "main.tsp", "--import", Path.Combine(package, "lib", "main.tsp"), "--no-emit");
            Assert.That(result.ExitCode, Is.Not.Zero, result.Output);
            Assert.That(result.Output, Does.Contain(message));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }

    private static string CreateSpecification()
    {
        var manifest = ManifestFixtures.Create();
        var service = new
        {
            outputNamespace = manifest.Namespace,
            metadataReferences = manifest.MetadataReferences,
            composites = manifest.Composites
        };
        var specification = Specification.Replace("SERVICE_OPTIONS",
            TypeSpecValue(JsonSerializer.SerializeToElement(service, ManifestFixtures.JsonOptions)), StringComparison.Ordinal);
        for (var index = 0; index < manifest.Operations.Length; index++)
        {
            var tool = JsonSerializer.SerializeToNode(manifest.Operations[index], ManifestFixtures.JsonOptions)!.AsObject();
            tool.Remove("operationId");
            specification = specification.Replace($"TOOL_OPTIONS_{index}",
                TypeSpecValue(JsonSerializer.SerializeToElement(tool)), StringComparison.Ordinal);
        }
        return specification;
    }

    private static void CreateLocalCompilerAndHttpSentinels(string root)
    {
        // A consumer's unrelated dependency tree must not supply compiler/typekit modules.
        foreach (var name in new[] { "compiler", "http" })
        {
            var package = Path.Combine(root, "node_modules", "@typespec", name);
            Directory.CreateDirectory(package);
            File.WriteAllText(Path.Combine(package, "package.json"),
                $$"""{"name":"@typespec/{{name}}","version":"1.17.0","type":"module","main":"index.js","tspMain":"main.tsp"}""");
            File.WriteAllText(Path.Combine(package, "main.tsp"), "import \"./index.js\";");
            File.WriteAllText(Path.Combine(package, "index.js"), "throw new Error('Consumer dependency tree must not be loaded.');");
            Directory.CreateDirectory(Path.Combine(package, "entrypoints"));
            File.Copy(Path.Combine(package, "index.js"), Path.Combine(package, "entrypoints", "cli.js"));
        }
    }

    internal static string FindPackage()
    {
        var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (directory is not null)
        {
            var package = Path.Combine(directory.FullName, "eng", "packages", "http-client-csharp-mcp");
            if (File.Exists(Path.Combine(package, "package.json")))
            {
                return package;
            }
            directory = directory.Parent;
        }
        throw new InvalidOperationException("Cannot find the MCP generator package from the test output directory.");
    }

    internal static async Task<(int ExitCode, string Output)> Run(string executable, string workingDirectory, params string[] arguments)
    {
        var start = new ProcessStartInfo(executable)
        {
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = System.Text.Encoding.UTF8,
            StandardErrorEncoding = System.Text.Encoding.UTF8,
            UseShellExecute = false
        };
        foreach (var argument in arguments)
        {
            start.ArgumentList.Add(argument);
        }
        start.Environment["TYPESPEC_SKIP_COMPILER_RESOLVE"] = "1";
        using var process = Process.Start(start) ?? throw new InvalidOperationException($"Could not start '{executable}'.");
        var stdout = process.StandardOutput.ReadToEndAsync();
        var stderr = process.StandardError.ReadToEndAsync();
        using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        try
        {
            await process.WaitForExitAsync(timeout.Token);
        }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            throw new TimeoutException($"'{executable}' did not finish within two minutes.");
        }
        return (process.ExitCode, await stdout + await stderr);
    }

    private const string Specification = """
        using TypeSpec.Http;
        using Azure.Mcp;
        @service(#{ title: "Multiple Azure service tool examples" })
        @server("{endpoint}", "The service endpoint.", { endpoint: url })
        @mcpService(SERVICE_OPTIONS)
        namespace Services;
        interface Secrets {
          /** Gets a secret. */
          @get @route("/secrets/{name}")
          @tool(TOOL_OPTIONS_0)
          get(@path name: string, @query mode: "1"): void;
        }
        interface Queues {
          /** Removes a queue. */
          @delete @route("/queues/{name}")
          @tool(TOOL_OPTIONS_1)
          remove(@path name: string, @query mode: "1"): void;
        }
        """;

    private const string ExistingTypes = """
        using System;
        using System.Threading;
        using System.Threading.Tasks;
        namespace Example
        {
            public class Model { public string? Value { get; set; } }
            public class SecretClient
            {
                public Task<Model> GetSecretAsync(string name, string? label, CancellationToken cancellationToken) => Task.FromResult(new Model());
            }
            public class QueueClient
            {
                public Task<Model> DeleteQueueAsync(string name, string? label, CancellationToken cancellationToken) => Task.FromResult(new Model());
            }
            public class SecretCommand { }
            public class QueueCommand { }
        }
        namespace Microsoft.Mcp.Core.Commands
        {
            public class CommandGroup { public void AddCommand<T>(IServiceProvider services) { } }
        }
        namespace Microsoft.Mcp.Core.Options
        {
            [AttributeUsage(AttributeTargets.Property)]
            public class OptionAttribute : Attribute { public string? Description { get; set; } }
        }
        """;
}

// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class GenerationTests
{
    [TestCase("missing-service", "same @service")]
    [TestCase("missing-tool", "at least one @tool")]
    [TestCase("duplicate-tool", "duplicate-decorator")]
    [TestCase("wrong-service", "same @service")]
    [TestCase("invalid-schema", "not assignable")]
    [TestCase("old-configuration", "Unknown decorator")]
    public async Task InvalidTypeSpecMetadataProducesDiagnostics(string change, string message)
    {
        var package = FindPackage();
        var root = Path.Combine(package, "temp", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        try
        {
            const string tool = """@tool("f5088334-e630-4df0-a5be-ac87787acad0", "example secret get", "Get secret")""";
            var specification = $$"""
                using TypeSpec.Http;
                using Azure.Mcp;
                @service namespace Example {
                  interface Secret {
                    @get @route("/secrets/{name}")
                    {{tool}}
                    get(@path name: string): void;
                  }
                }
                """;
            specification = change switch
            {
                "missing-service" => specification.Replace("@service ", "", StringComparison.Ordinal),
                "missing-tool" => specification.Replace(tool, "", StringComparison.Ordinal),
                "duplicate-tool" => specification.Replace(tool, tool + "\n" + tool, StringComparison.Ordinal),
                "wrong-service" => specification + """
                    @service namespace Other {
                      @get @route("/other")
                      @tool("a9ab33b5-d9b0-4cf4-b851-4e20925ade9b", "other get")
                      op get(): void;
                    }
                    """,
                "invalid-schema" => specification.Replace("@tool(\"f5088334-e630-4df0-a5be-ac87787acad0\"", "@tool(123", StringComparison.Ordinal),
                "old-configuration" => specification + """@@mcpService(Example, #{outputNamespace: "Wrong"});""",
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

    [Test]
    public void AllAuthoredTypeSpecIsSmallerThanItsGeneratedOutputAndContainsNoClrConfiguration()
    {
        var package = FindPackage();
        var libraryPath = Path.Combine(package, "lib", "main.tsp");
        var library = File.ReadAllText(libraryPath);
        var fixtures = Path.Combine(package, "emitter", "test", "fixtures");
        var authored = Directory.GetFiles(fixtures, "*.tsp", SearchOption.TopDirectoryOnly);
        Assert.That(authored.Select(Path.GetFileName), Is.EqualTo(new[] { "storage.tsp" }),
            "Do not retain a verbose parallel mapping fixture under another filename.");
        var input = library + File.ReadAllText(authored.Single());
        var outputs = Directory.GetFiles(Path.Combine(package, "generator", "TestProjects", "Local", "Storage", "src", "Generated"), "*.cs");
        var generated = string.Concat(outputs.Select(File.ReadAllText));
        Assert.That(Regex.Replace(input, @"\s+", "").Length, Is.LessThan(Regex.Replace(generated, @"\s+", "").Length));
        Assert.That(File.ReadAllLines(libraryPath).Length + authored.Sum(path => File.ReadAllLines(path).Length),
            Is.LessThan(outputs.Sum(path => File.ReadAllLines(path).Length)));
        Assert.That(input, Does.Not.Contain("#{").And.Not.Contain("metadataReferences").And.Not.Contain("outputNamespace")
            .And.Not.Contain("commandType").And.Not.Contain("handler").And.Not.Contain(".dll"));
    }

    internal static void CreateLocalCompilerAndHttpSentinels(string root)
    {
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
}

// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal static class ConsumerMetadata
{
    internal static string[] Resolve(string outputDirectory)
    {
        var source = Path.Combine(outputDirectory, "src");
        var projects = Directory.Exists(source) ? Directory.GetFiles(source, "*.csproj") : [];
        McpManifest.Require(projects.Length == 1, "MCP generation requires exactly one existing consumer project under src.");
        var start = new ProcessStartInfo("dotnet")
        {
            WorkingDirectory = source,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        foreach (var argument in new[] { "msbuild", projects[0], "-nologo", "-getProperty:TargetDir" })
        {
            start.ArgumentList.Add(argument);
        }
        using var process = Process.Start(start) ?? throw new InvalidOperationException("Cannot evaluate the consumer's build output.");
        var stdout = process.StandardOutput.ReadToEndAsync();
        var stderr = process.StandardError.ReadToEndAsync();
        if (!process.WaitForExit(60_000))
        {
            process.Kill(entireProcessTree: true);
            throw new TimeoutException("Evaluating the consumer project exceeded one minute.");
        }
        var target = stdout.GetAwaiter().GetResult().Trim();
        var errors = stderr.GetAwaiter().GetResult();
        McpManifest.Require(process.ExitCode == 0, $"Cannot evaluate the consumer project: {target}\n{errors}");
        McpManifest.Require(Path.IsPathFullyQualified(target) && Directory.Exists(target),
            "Build the consumer's baseline single-target project before MCP generation; its TargetDir must exist.");
        var core = Path.Combine(target, "Microsoft.Mcp.Core.dll");
        McpManifest.Require(File.Exists(core), $"Build the consumer before generation: missing MCP framework assembly '{core}'.");
        var azure = Path.Combine(target, "Azure.Mcp.Core.dll");
        return File.Exists(azure) ? [core, azure] : [core];
    }
}

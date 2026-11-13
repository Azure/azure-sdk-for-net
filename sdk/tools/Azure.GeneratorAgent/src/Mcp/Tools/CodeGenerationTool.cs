// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that runs code generation (dotnet build /t:generateCode).
/// </summary>
[McpServerToolType]
public static class CodeGenerationTool
{
    /// <summary>
    /// Default timeout for code generation (10 minutes).
    /// </summary>
    internal static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(10);

    [McpServerTool(Name = "run_code_generation"), Description("Run dotnet build /t:generateCode in a project's src directory. Optionally pass a local spec path (either the full spec directory or the repo root — resolved via tsp-location.yaml).")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the SDK project directory")] string projectPath,
        [Description("Optional. Absolute path to the local spec directory (containing main.tsp) or the root of the azure-rest-api-specs clone. The tool resolves the spec directory via tsp-location.yaml if only the repo root is provided.")] string? localSpecsPath = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var (success, output, error) = await ExecuteInProcessAsync(projectPath, localSpecsPath, cancellationToken).ConfigureAwait(false);
            if (!success)
            {
                return JsonSerializer.Serialize(new { success = false, error, output });
            }
            return JsonSerializer.Serialize(new { success = true, output = CSharpPatterns.Truncate(output, 3000) });
        }
        catch (OperationCanceledException)
        {
            return JsonSerializer.Serialize(new { success = false, error = "Code generation was cancelled or timed out." });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for the orchestrator.
    /// </summary>
    public static async Task<(bool Success, string Output, string? Error)> ExecuteInProcessAsync(
        string projectPath, string? localSpecsPath = null, CancellationToken cancellationToken = default)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var srcPath = Path.Combine(normalizedPath, "src");
            var workDir = Directory.Exists(srcPath) ? srcPath : normalizedPath;

            var resolvedSpecsPath = ResolveLocalSpecsPath(normalizedPath, localSpecsPath);
            var buildArgs = BuildArguments(resolvedSpecsPath);

            using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            timeoutCts.CancelAfter(DefaultTimeout);

            var (output, exitCode) = await ProcessRunner.RunAsync(
                "dotnet", buildArgs, workDir,
                environmentVariables: null,
                cancellationToken: timeoutCts.Token).ConfigureAwait(false);

            return (exitCode == 0, output, exitCode != 0 ? $"Code generation failed with exit code {exitCode}" : null);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            return (false, string.Empty, $"Code generation timed out after {DefaultTimeout.TotalMinutes} minutes.");
        }
        catch (Exception ex)
        {
            return (false, string.Empty, ex.Message);
        }
    }

    /// <summary>
    /// Resolves the local specs path. If the caller passed the root of the
    /// azure-rest-api-specs clone (i.e. the path does not already contain a
    /// main.tsp or tspconfig.yaml), we read tsp-location.yaml's <c>directory</c>
    /// field and join it to the repo root so that tsp-client receives the full
    /// spec directory path it expects.
    /// </summary>
    internal static string? ResolveLocalSpecsPath(string projectPath, string? localSpecsPath)
    {
        if (string.IsNullOrWhiteSpace(localSpecsPath))
        {
            return null;
        }

        var fullPath = Path.GetFullPath(localSpecsPath);

        // If the path already points at the spec directory (contains main.tsp
        // or tspconfig.yaml), use it directly.
        if (File.Exists(Path.Combine(fullPath, "main.tsp")) ||
            File.Exists(Path.Combine(fullPath, "tspconfig.yaml")))
        {
            return fullPath;
        }

        // Otherwise assume it's the repo root — read the tsp-location.yaml
        // directory field and build the full path.
        var directory = ReadTspLocationDirectory(projectPath);
        if (directory is not null)
        {
            var resolved = Path.GetFullPath(Path.Combine(fullPath, directory));
            if (Directory.Exists(resolved))
            {
                return resolved;
            }
        }

        // Fall back to the original value if we can't resolve.
        return fullPath;
    }

    /// <summary>
    /// Reads the <c>directory</c> field from tsp-location.yaml in the project root.
    /// Uses simple line parsing to avoid a YAML library dependency.
    /// </summary>
    internal static string? ReadTspLocationDirectory(string projectPath)
    {
        var tspLocationPath = Path.Combine(projectPath, "tsp-location.yaml");
        if (!File.Exists(tspLocationPath))
        {
            // If projectPath is the src dir, look one level up.
            tspLocationPath = Path.Combine(projectPath, "..", "tsp-location.yaml");
        }

        if (!File.Exists(tspLocationPath))
        {
            return null;
        }

        foreach (var line in File.ReadLines(tspLocationPath))
        {
            var trimmed = line.Trim();
            if (trimmed.StartsWith("directory:", StringComparison.OrdinalIgnoreCase))
            {
                var value = trimmed["directory:".Length..].Trim();
                if (value.Length > 0)
                {
                    return value;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Builds the dotnet build arguments for code generation.
    /// </summary>
    internal static string BuildArguments(string? localSpecsPath)
    {
        var args = "build /t:generateCode";
        if (!string.IsNullOrWhiteSpace(localSpecsPath))
        {
            args += $" /p:LocalSpecRepo={Path.GetFullPath(localSpecsPath)}";
        }
        return args;
    }
}

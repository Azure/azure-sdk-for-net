// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that runs finalization scripts (Export-API.ps1, Update-Snippets.ps1) after migration.
/// </summary>
[McpServerToolType]
public static class FinalizationTool
{
    [McpServerTool(Name = "finalize_migration"), Description("Run Export-API.ps1 and Update-Snippets.ps1 finalization scripts for a service directory.")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the SDK project directory (e.g., C:\\repo\\sdk\\storage\\Azure.Storage.Blobs)")] string projectPath)
    {
        try
        {
            var (success, output, error) = await ExecuteInProcessAsync(projectPath).ConfigureAwait(false);
            if (!success)
            {
                return JsonSerializer.Serialize(new { success = false, error });
            }
            return JsonSerializer.Serialize(new { success = true, output });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for the orchestrator.
    /// </summary>
    public static async Task<(bool Success, string Output, string? Error)> ExecuteInProcessAsync(string projectPath)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var (repoRoot, serviceDirectory) = ResolveRepoPaths(normalizedPath);

            if (repoRoot is null || serviceDirectory is null)
            {
                return (false, string.Empty, "Could not resolve repository root or service directory from project path");
            }

            var results = new List<string>();

            // Run Export-API.ps1
            var exportScript = Path.Combine(repoRoot, "eng", "scripts", "Export-API.ps1");
            if (File.Exists(exportScript))
            {
                var (exitCode, output) = await RunPowerShellScriptAsync(
                    repoRoot, $".\\eng\\scripts\\Export-API.ps1 -ServiceDirectory {serviceDirectory}").ConfigureAwait(false);
                results.Add($"Export-API: exit={exitCode}");
                if (exitCode != 0)
                {
                    results.Add(output);
                }
            }
            else
            {
                results.Add("Export-API.ps1 not found, skipping");
            }

            // Run Update-Snippets.ps1
            var snippetsScript = Path.Combine(repoRoot, "eng", "scripts", "Update-Snippets.ps1");
            if (File.Exists(snippetsScript))
            {
                var (exitCode, output) = await RunPowerShellScriptAsync(
                    repoRoot, $".\\eng\\scripts\\Update-Snippets.ps1 -ServiceDirectory {serviceDirectory}").ConfigureAwait(false);
                results.Add($"Update-Snippets: exit={exitCode}");
                if (exitCode != 0)
                {
                    results.Add(output);
                }
            }
            else
            {
                results.Add("Update-Snippets.ps1 not found, skipping");
            }

            return (true, string.Join(Environment.NewLine, results), null);
        }
        catch (Exception ex)
        {
            return (false, string.Empty, ex.Message);
        }
    }

    /// <summary>
    /// Resolves the repo root (directory containing eng/ and global.json) and the service directory name.
    /// </summary>
    internal static (string? RepoRoot, string? ServiceDirectory) ResolveRepoPaths(string projectPath)
    {
        // Find repo root by walking up until we find eng/ and global.json
        var dir = projectPath;
        string? repoRoot = null;
        while (!string.IsNullOrEmpty(dir))
        {
            if (Directory.Exists(Path.Combine(dir, "eng")) && File.Exists(Path.Combine(dir, "global.json")))
            {
                repoRoot = dir;
                break;
            }
            var parent = Path.GetDirectoryName(dir);
            if (parent == dir)
                break;
            dir = parent;
        }

        if (repoRoot is null)
            return (null, null);

        // Extract service directory: the folder name immediately after sdk/ in the path
        var normalizedProject = projectPath.Replace('/', Path.DirectorySeparatorChar);
        var sdkPrefix = Path.Combine(repoRoot, "sdk") + Path.DirectorySeparatorChar;
        if (normalizedProject.StartsWith(sdkPrefix, StringComparison.OrdinalIgnoreCase))
        {
            var afterSdk = normalizedProject[sdkPrefix.Length..];
            var separatorIdx = afterSdk.IndexOf(Path.DirectorySeparatorChar);
            var serviceDir = separatorIdx >= 0 ? afterSdk[..separatorIdx] : afterSdk;
            return (repoRoot, serviceDir);
        }

        return (repoRoot, null);
    }

    private static async Task<(int ExitCode, string Output)> RunPowerShellScriptAsync(string workingDirectory, string command)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "pwsh",
            Arguments = $"-NoProfile -NonInteractive -Command \"{command}\"",
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi)!;
        var stdout = await process.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
        var stderr = await process.StandardError.ReadToEndAsync().ConfigureAwait(false);
        await process.WaitForExitAsync().ConfigureAwait(false);

        var output = stdout;
        if (!string.IsNullOrWhiteSpace(stderr))
        {
            output += Environment.NewLine + stderr;
        }

        return (process.ExitCode, output);
    }
}

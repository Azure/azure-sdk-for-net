// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that removes the IncludeAutorestDependency element from .csproj files.
/// This is a pre-generation cleanup step during migration.
/// </summary>
[McpServerToolType]
public static class PreGenCleanupTool
{
    private static readonly Regex s_autorestDependencyRegex = new(
        @"\s*<IncludeAutorestDependency>true</IncludeAutorestDependency>\s*\r?\n?",
        RegexOptions.Compiled);

    [McpServerTool(Name = "pregen_cleanup"), Description("Remove IncludeAutorestDependency element from .csproj files in a project's src directory.")]
    public static string Execute(
        [Description("Absolute path to the SDK project directory")] string projectPath)
    {
        var (success, filesModified, error) = ExecuteInProcess(projectPath);
        if (!success)
        {
            return JsonSerializer.Serialize(new { success = false, error });
        }
        return JsonSerializer.Serialize(new { success = true, filesModified });
    }

    /// <summary>
    /// In-process execution for the orchestrator.
    /// </summary>
    public static (bool Success, int FilesModified, string? Error) ExecuteInProcess(string projectPath)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var srcPath = Path.Combine(normalizedPath, "src");
            if (!Directory.Exists(srcPath))
            {
                return (true, 0, null);
            }

            var csprojFiles = Directory.GetFiles(srcPath, "*.csproj", SearchOption.TopDirectoryOnly);
            var modified = 0;

            foreach (var csproj in csprojFiles)
            {
                var content = File.ReadAllText(csproj);
                var newContent = s_autorestDependencyRegex.Replace(content, string.Empty);
                if (!string.Equals(content, newContent, StringComparison.Ordinal))
                {
                    File.WriteAllText(csproj, newContent);
                    modified++;
                }
            }

            return (true, modified, null);
        }
        catch (Exception ex)
        {
            return (false, 0, ex.Message);
        }
    }
}

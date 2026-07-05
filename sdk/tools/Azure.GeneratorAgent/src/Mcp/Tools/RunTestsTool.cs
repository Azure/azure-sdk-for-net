// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that runs dotnet test and returns structured results.
/// </summary>
[McpServerToolType]
public static class RunTestsTool
{
    private static readonly Regex s_summaryRegex = new(
        @"(?:Passed|Failed)!\s*-\s*Failed:\s*(?<failed>\d+),\s*Passed:\s*(?<passed>\d+),\s*Skipped:\s*(?<skipped>\d+),\s*Total:\s*(?<total>\d+)",
        RegexOptions.Compiled);

    [McpServerTool(Name = "run_tests"), Description("Run dotnet test on a project, excluding live tests by default. Returns structured pass/fail results.")]
    public static async Task<string> ExecuteAsync(
        [Description("Absolute path to the SDK project directory or test .csproj file")] string projectPath,
        [Description("Optional. Additional test filter expression. Defaults to 'TestCategory!=Live'.")] string? filter = null)
    {
        try
        {
            var result = await ExecuteInProcessAsync(projectPath, filter).ConfigureAwait(false);
            return JsonSerializer.Serialize(result);
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new TestResult { Success = false, Error = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for the orchestrator.
    /// </summary>
    public static async Task<TestResult> ExecuteInProcessAsync(string projectPath, string? filter = null)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);

            // Resolve the test directory: look for tests/ subfolder
            var testsPath = Path.Combine(normalizedPath, "tests");
            string workDir;
            if (Directory.Exists(testsPath))
            {
                workDir = testsPath;
            }
            else if (Directory.Exists(normalizedPath))
            {
                workDir = normalizedPath;
            }
            else
            {
                workDir = Path.GetDirectoryName(normalizedPath) ?? normalizedPath;
            }

            var testFilter = filter ?? "TestCategory!=Live";
            var args = $"test --no-build --filter \"{testFilter}\"";

            var (output, exitCode) = await ProcessRunner.RunAsync("dotnet", args, workDir).ConfigureAwait(false);

            var result = ParseTestOutput(output, exitCode);
            return result;
        }
        catch (Exception ex)
        {
            return new TestResult { Success = false, Error = ex.Message };
        }
    }

    internal static TestResult ParseTestOutput(string output, int exitCode)
    {
        var result = new TestResult
        {
            Success = exitCode == 0,
            ExitCode = exitCode,
            RawOutput = output
        };

        // Parse the summary line: "Passed! - Failed: 0, Passed: 42, Skipped: 0, Total: 42"
        var match = s_summaryRegex.Match(output);
        if (match.Success)
        {
            result.Failed = int.Parse(match.Groups["failed"].Value);
            result.Passed = int.Parse(match.Groups["passed"].Value);
            result.Skipped = int.Parse(match.Groups["skipped"].Value);
            result.Total = int.Parse(match.Groups["total"].Value);
        }

        // Extract failure details (lines starting with "Failed" or containing "Error Message:")
        var lines = output.Split('\n');
        var failures = new List<string>();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (line.StartsWith("Failed ", StringComparison.Ordinal) ||
                line.StartsWith("X ", StringComparison.Ordinal))
            {
                // Collect the failure line and a few context lines
                var failureBlock = line;
                for (var j = i + 1; j < Math.Min(i + 5, lines.Length); j++)
                {
                    var nextLine = lines[j].Trim();
                    if (string.IsNullOrEmpty(nextLine) || nextLine.StartsWith("Failed ", StringComparison.Ordinal) || nextLine.StartsWith("X ", StringComparison.Ordinal))
                    {
                        break;
                    }
                    failureBlock += "\n  " + nextLine;
                }
                failures.Add(failureBlock);
            }
        }

        result.Failures = failures;
        return result;
    }
}

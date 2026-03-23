// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Shared utility for running external processes with concurrent stdout/stderr
/// reading to prevent buffer deadlocks.
/// </summary>
internal static class ProcessRunner
{
    /// <summary>
    /// Runs an external process and returns the combined output and exit code.
    /// Reads stdout and stderr concurrently to prevent deadlocks.
    /// </summary>
    public static async Task<(string Output, int ExitCode)> RunAsync(
        string fileName, string arguments, string workingDirectory)
    {
        var psi = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi)!;
        var stdoutTask = process.StandardOutput.ReadToEndAsync();
        var stderrTask = process.StandardError.ReadToEndAsync();
        await Task.WhenAll(stdoutTask, stderrTask).ConfigureAwait(false);
        await process.WaitForExitAsync().ConfigureAwait(false);

        var output = stdoutTask.Result;
        if (!string.IsNullOrWhiteSpace(stderrTask.Result))
        {
            output = string.Concat(output, Environment.NewLine, stderrTask.Result);
        }

        return (output, process.ExitCode);
    }
}

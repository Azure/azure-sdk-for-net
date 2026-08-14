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
    public static Task<(string Output, int ExitCode)> RunAsync(
        string fileName, string arguments, string workingDirectory)
        => RunAsync(fileName, arguments, workingDirectory, environmentVariables: null, cancellationToken: default);

    /// <summary>
    /// Runs an external process with optional environment variables and cancellation support.
    /// </summary>
    public static async Task<(string Output, int ExitCode)> RunAsync(
        string fileName, string arguments, string workingDirectory,
        IDictionary<string, string>? environmentVariables,
        CancellationToken cancellationToken)
    {
        var psi = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        if (environmentVariables is not null)
        {
            foreach (var (key, value) in environmentVariables)
            {
                psi.Environment[key] = value;
            }
        }

        using var process = Process.Start(psi)!;
        process.StandardInput.Close();

        try
        {
            var stdoutTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
            var stderrTask = process.StandardError.ReadToEndAsync(cancellationToken);
            await Task.WhenAll(stdoutTask, stderrTask).ConfigureAwait(false);
            await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);

            var output = stdoutTask.Result;
            if (!string.IsNullOrWhiteSpace(stderrTask.Result))
            {
                output = string.Concat(output, Environment.NewLine, stderrTask.Result);
            }

            return (output, process.ExitCode);
        }
        catch (OperationCanceledException)
        {
            try
            {
                process.Kill(entireProcessTree: true);
            }
            catch
            {
                // Best effort — process may have already exited.
            }
            throw;
        }
    }
}

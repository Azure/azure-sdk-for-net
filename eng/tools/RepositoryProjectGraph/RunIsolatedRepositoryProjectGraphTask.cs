using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Azure.Sdk.Tools.RepositoryProjectGraph;

public sealed class RunIsolatedRepositoryProjectGraphTask : Task
{
    [Required]
    public string Project { get; set; } = string.Empty;

    [Required]
    public string Target { get; set; } = string.Empty;

    public override bool Execute()
    {
        try
        {
            string hostPath = Environment.GetEnvironmentVariable("DOTNET_HOST_PATH");
            if (string.IsNullOrEmpty(hostPath))
            {
                hostPath = Environment.ProcessPath;
            }
            if (string.IsNullOrEmpty(hostPath))
            {
                hostPath = "dotnet";
            }

            var startInfo = new ProcessStartInfo(hostPath)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Path.GetDirectoryName(Path.GetFullPath(Project)),
            };
            if (Path.GetFileNameWithoutExtension(hostPath).Equals("dotnet", StringComparison.OrdinalIgnoreCase))
            {
                startInfo.ArgumentList.Add("msbuild");
            }
            startInfo.ArgumentList.Add("/nologo");
            startInfo.ArgumentList.Add("/m:1");
            startInfo.ArgumentList.Add("/nr:false");
            startInfo.ArgumentList.Add($"/t:{Target}");
            startInfo.ArgumentList.Add(Path.GetFullPath(Project));

            IReadOnlyDictionary<string, string> globalProperties =
                (BuildEngine as IBuildEngine6)?.GetGlobalProperties();
            if (globalProperties is not null)
            {
                foreach ((string name, string value) in globalProperties)
                {
                    startInfo.ArgumentList.Add($"/p:{name}={ProjectCollection.Escape(value)}");
                }
            }
            var stopwatch = Stopwatch.StartNew();
            using var process = Process.Start(startInfo)
                ?? throw new InvalidOperationException("Failed to start the isolated repository ProjectGraph process.");
            System.Threading.Tasks.Task<string> standardOutput = process.StandardOutput.ReadToEndAsync();
            System.Threading.Tasks.Task<string> standardError = process.StandardError.ReadToEndAsync();
            long peakWorkingSet = 0;
            // Sample while the child is alive because Unix process metrics are unavailable after exit.
            while (!process.WaitForExit(1000))
            {
                try
                {
                    process.Refresh();
                    peakWorkingSet = Math.Max(peakWorkingSet, process.WorkingSet64);
                }
                catch (InvalidOperationException)
                {
                    // The child can exit between WaitForExit's timeout and metric collection.
                }
            }
            process.WaitForExit();
            System.Threading.Tasks.Task.WaitAll(standardOutput, standardError);
            stopwatch.Stop();

            if (!string.IsNullOrWhiteSpace(standardOutput.Result))
            {
                Log.LogMessage(MessageImportance.High, standardOutput.Result.TrimEnd());
            }
            if (!string.IsNullOrWhiteSpace(standardError.Result))
            {
                if (process.ExitCode == 0)
                {
                    Log.LogMessage(MessageImportance.High, standardError.Result.TrimEnd());
                }
                else
                {
                    Log.LogError(standardError.Result.TrimEnd());
                }
            }

            Log.LogMessage(
                MessageImportance.High,
                "Repository ProjectGraph isolated process: target={0}, exitCode={1}, elapsed={2:F2}s, peakWorkingSet={3:F1}MiB.",
                Target,
                process.ExitCode,
                stopwatch.Elapsed.TotalSeconds,
                peakWorkingSet / 1024d / 1024d);

            if (process.ExitCode != 0)
            {
                Log.LogError("The isolated repository ProjectGraph process exited with code {0}.", process.ExitCode);
                return false;
            }

            return true;
        }
        catch (Exception exception)
        {
            Log.LogErrorFromException(exception, true);
            return false;
        }
    }
}

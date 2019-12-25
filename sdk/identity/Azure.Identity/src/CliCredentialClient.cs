// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Azure.Identity
{
    internal class CliCredentialClient
    {
        public virtual (string, int) CreateProcess(string extendCommand)
        {
            string fileName = string.Empty;
            string argument = string.Empty;

            Process proc = new Process();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fileName = "cmd";
                argument = $"/c \"{extendCommand}\"";
            }
            else
            {
                fileName = "/bin/sh";
                argument = $"-c \"{extendCommand}\"";
            }

            ProcessStartInfo procStartInfo = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = argument,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            proc.StartInfo = procStartInfo;

            StringBuilder stdOutput = new StringBuilder();
            proc.OutputDataReceived += new DataReceivedEventHandler((sender, e) => stdOutput.AppendLine(e.Data));

            StringBuilder stdError = new StringBuilder();
            proc.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => stdError.AppendLine(e.Data));

            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();

            int exitCode = proc.ExitCode;

            if (exitCode != 0)
            {
                return (stdError.ToString(), exitCode);
            }
            else
            {
                return (stdOutput.ToString(), exitCode);
            }
        }
    }
}

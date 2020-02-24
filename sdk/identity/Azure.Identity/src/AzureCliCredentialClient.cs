// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Azure.Core;
using System.Globalization;
using System;
using System.Text.RegularExpressions;

namespace Azure.Identity
{
    internal class AzureCliCredentialClient
    {
        private const string AzureCLINotInstalled = "Azure CLI not installed";
        private const string AzNotLogIn = "Please run 'az login' to setup account";
        private const string WinAzureCLIError = "'az' is not recognized";
        private const string AzureCliTimeoutError = "Azure CLI authentication timed out.";
        private const string AzureCliDefaultPath = "/usr/bin:/usr/local/bin";
        private static readonly string AzureCliDefaultPathWindows = $"{EnvironmentVariables.ProgramFilesX86}\\Microsoft SDKs\\Azure\\CLI2\\wbin;{EnvironmentVariables.ProgramFiles}\\Microsoft SDKs\\Azure\\CLI2\\wbin";
        private readonly string _path;
        private const int CliProcessTImeoutMs = 10000;

        public AzureCliCredentialClient(string path = default)
        {
            _path = path ?? GetPathFromEnvironment();
        }

        private static string GetPathFromEnvironment()
        {
            string path = EnvironmentVariables.AzureCliPath;

            if (string.IsNullOrEmpty(path))
            {
                path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? AzureCliDefaultPathWindows : AzureCliDefaultPath;
            }

            return path;
        }

        public virtual AccessToken RequestCliAccessToken(string[] scopes, CancellationToken cancellationToken)
        {
            return RequestCliAccessTokenAsync(false, scopes, cancellationToken).GetAwaiter().GetResult();
        }

        public virtual async ValueTask<AccessToken> RequestCliAccessTokenAsync(string[] scopes, CancellationToken cancellationToken)
        {
            return await RequestCliAccessTokenAsync(true, scopes, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async ValueTask<AccessToken> RequestCliAccessTokenAsync(bool isAsync, string[] scopes, CancellationToken cancellationToken)
        {
            string resource = ScopeUtilities.ScopesToResource(scopes);

            ScopeUtilities.ValidateScope(resource);

            (string output, int exitCode) = isAsync ? await GetAzureCliAccesToken(true, resource, cancellationToken).ConfigureAwait(false) : GetAzureCliAccesToken(false, resource, cancellationToken).GetAwaiter().GetResult();

            if (exitCode != 0)
            {
                bool isLoginError = output.StartsWith("Please run 'az login'", StringComparison.CurrentCultureIgnoreCase);
                bool isWinError = output.StartsWith(WinAzureCLIError, StringComparison.CurrentCultureIgnoreCase);
                string pattter = "az:(.*)not found";
                bool isOtherOsError = Regex.IsMatch(output, pattter);

                if (isWinError || isOtherOsError)
                {
                    throw new CredentialUnavailableException(AzureCLINotInstalled);
                }
                else if (isLoginError)
                {
                    throw new CredentialUnavailableException(AzNotLogIn);
                }

                throw new AuthenticationFailedException(output);
            }

            byte[] byteArrary = Encoding.ASCII.GetBytes(output);

            using MemoryStream stream = new MemoryStream(byteArrary);

            return isAsync ? await AccessTokenUtilities.DeserializeAsync(stream, cancellationToken).ConfigureAwait(false) : AccessTokenUtilities.Deserialize(stream);
        }

        protected virtual async ValueTask<(string, int)> GetAzureCliAccesToken(bool isAsync, string resource, CancellationToken cancellationToken)
        {
            string command = $"az account get-access-token --output json --resource {resource}";

            string fileName = string.Empty;
            string argument = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fileName = "cmd";
                argument = $"/c \"{command}\"";
            }
            else
            {
                fileName = "/bin/sh";
                argument = $"-c \"{command}\"";
            }

            ProcessStartInfo procStartInfo = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = argument,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                Environment = { { "PATH", _path } }
            };

            return isAsync ? await RunProcessAsync(isAsync, procStartInfo, cancellationToken).ConfigureAwait(false) : RunProcessAsync(isAsync, procStartInfo, cancellationToken).GetAwaiter().GetResult();
        }

        private static async ValueTask<(string, int)> RunProcessAsync(bool isAsync, ProcessStartInfo procStartInfo, CancellationToken cancellationToken)
        {
            int exitCode = default;
            StringBuilder stdOutput = new StringBuilder();
            StringBuilder stdError = new StringBuilder();
            bool completed;

            using (Process proc = new Process())
            {

                proc.StartInfo = procStartInfo;
                proc.OutputDataReceived += new DataReceivedEventHandler((sender, e) => stdOutput.AppendLine(e.Data));
                proc.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => stdError.AppendLine(e.Data));

                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                completed = isAsync ? await Task.Run(() => proc.WaitForExit(CliProcessTImeoutMs), cancellationToken).ConfigureAwait(false) : proc.WaitForExit(CliProcessTImeoutMs);

                if (!completed)
                {
                    proc.CancelOutputRead();

                    proc.CancelErrorRead();

                    throw new AuthenticationFailedException(AzureCliTimeoutError);
                }

                exitCode = proc.ExitCode;
            }

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

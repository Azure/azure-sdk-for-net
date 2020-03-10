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
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class AzureCliCredentialClient
    {
        private const string AzureCLINotInstalled = "Azure CLI not installed";
        private const string AzNotLogIn = "Please run 'az login' to set up account";
        private const string WinAzureCLIError = "'az' is not recognized";
        private const string AzureCliTimeoutError = "Azure CLI authentication timed out.";
        private const string AzureCliFailedError = "Azure CLI authentication failed due to an unknown error.";
        private const int CliProcessTImeoutMs = 10000;
        private readonly string _workingDir;
        private readonly string _path;

        // The default install paths are used to find Azure CLI if no path is specified. This is to prevent executing out of the current working directory.
        private static readonly string DefaultPathWindows = $"{EnvironmentVariables.ProgramFilesX86}\\Microsoft SDKs\\Azure\\CLI2\\wbin;{EnvironmentVariables.ProgramFiles}\\Microsoft SDKs\\Azure\\CLI2\\wbin";
        private const string DefaultPath = "/usr/bin:/usr/local/bin";
        private const string DefaultWorkingDir = "/bin/";
        private static readonly string DefaultWorkingDirWindows = Environment.GetFolderPath(Environment.SpecialFolder.System);

        private static readonly Regex AzNotFoundPattern = new Regex("az:(.*)not found");

        public AzureCliCredentialClient()
        {
            _path = EnvironmentVariables.Path;

            if (string.IsNullOrEmpty(_path))
            {
                _path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultPathWindows : DefaultPath;
            }

            _workingDir = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? DefaultWorkingDirWindows : DefaultWorkingDir;
        }

        public virtual AccessToken RequestCliAccessToken(string[] scopes, CancellationToken cancellationToken)
        {
            return RequestCliAccessTokenAsync(false, scopes, cancellationToken).EnsureCompleted();
        }

        public virtual async ValueTask<AccessToken> RequestCliAccessTokenAsync(string[] scopes, CancellationToken cancellationToken)
        {
            return await RequestCliAccessTokenAsync(true, scopes, cancellationToken).ConfigureAwait(false);
        }

        protected virtual async ValueTask<AccessToken> RequestCliAccessTokenAsync(bool async, string[] scopes, CancellationToken cancellationToken)
        {
            string resource = ScopeUtilities.ScopesToResource(scopes);

            ScopeUtilities.ValidateScope(resource);

            (string output, int exitCode) = await GetAzureCliAccesToken(async, resource, cancellationToken).ConfigureAwait(false);

            if (exitCode != 0)
            {
                bool isLoginError = output.IndexOf("az login", StringComparison.OrdinalIgnoreCase) != -1 || output.IndexOf("az account set", StringComparison.OrdinalIgnoreCase) != -1;

                bool isWinError = output.StartsWith(WinAzureCLIError, StringComparison.CurrentCultureIgnoreCase);

                bool isOtherOsError = AzNotFoundPattern.IsMatch(output);

                if (isWinError || isOtherOsError)
                {
                    throw new CredentialUnavailableException(AzureCLINotInstalled);
                }
                else if (isLoginError)
                {
                    throw new CredentialUnavailableException(AzNotLogIn);
                }

                throw new AuthenticationFailedException($"{AzureCliFailedError} {output}");
            }

            return DeserializeOutput(output);
        }

        protected virtual async ValueTask<(string, int)> GetAzureCliAccesToken(bool async, string resource, CancellationToken cancellationToken)
        {
            string command = $"az account get-access-token --output json --resource {resource}";

            string fileName = string.Empty;
            string argument = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe");
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
                WorkingDirectory = _workingDir,
                Environment = { { "PATH", _path } }
            };

            return await RunProcessAsync(async, procStartInfo, cancellationToken).ConfigureAwait(false);
        }

        private static async ValueTask<(string, int)> RunProcessAsync(bool async, ProcessStartInfo procStartInfo, CancellationToken cancellationToken)
        {
            int exitCode = default;
            StringBuilder stdOutput = new StringBuilder();
            StringBuilder stdError = new StringBuilder();
            bool completed;

            using (Process proc = new Process())
            {

                proc.StartInfo = procStartInfo;
                proc.OutputDataReceived += (sender, e) => stdOutput.AppendLine(e.Data);
                proc.ErrorDataReceived += (sender, e) => stdError.AppendLine(e.Data);

                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                completed = async ? await Task.Run(() => proc.WaitForExit(CliProcessTImeoutMs), cancellationToken).ConfigureAwait(false) : proc.WaitForExit(CliProcessTImeoutMs);

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

        private static AccessToken DeserializeOutput(string output)
        {
            string accessToken = null;
            DateTimeOffset expiresOn = DateTimeOffset.MaxValue;

            using (JsonDocument json = JsonDocument.Parse(output))
            {

                foreach (JsonProperty prop in json.RootElement.EnumerateObject())
                {
                    switch (prop.Name)
                    {
                        case "accessToken":
                            accessToken = prop.Value.GetString();
                            break;

                        case "expiresIn":
                            expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(prop.Value.GetInt64());
                            break;

                        case "expiresOn":
                            if (expiresOn == DateTimeOffset.MaxValue)
                            {
                                var expiresOnStr = prop.Value.GetString();

                                expiresOn = DateTimeOffset.ParseExact(expiresOnStr, "yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                            }
                            break;
                    }
                }
            }

            return new AccessToken(accessToken, expiresOn);
        }
    }
}

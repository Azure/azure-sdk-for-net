// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility
{
    internal class ReporterUtils
    {
        private readonly ILogger _logger;
        public ReporterUtils(ILogger? logger = null)
        {
            _logger = logger ?? new Logger();
        }
        internal static string GetRunId(CIInfo cIInfo)
        {
            if (cIInfo.Provider == CIConstants.s_dEFAULT)
            {
                return Guid.NewGuid().ToString();
            }
            var concatString = $"{cIInfo.Provider}-{cIInfo.Repo}-{cIInfo.RunId}-{cIInfo.RunAttempt}";
            return CalculateSha1Hash(concatString);
        }

        internal static string CalculateSha1Hash(string input)
        {
            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            }
        }
        internal static string? TruncateData(string? value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            return value?.Length <= maxLength ? value : value?.Substring(0, maxLength);
        }

        internal static string GetRunName(CIInfo ciInfo)
        {
            string GIT_VERSION_COMMAND = "git --version";
            string GIT_REV_PARSE = "git rev-parse --is-inside-work-tree";
            string GIT_COMMIT_MESSAGE_COMMAND = "git log -1 --pretty=format:\"%s\"";

            if (ciInfo.Provider == CIConstants.s_gITHUB_ACTIONS &&
            Environment.GetEnvironmentVariable("GITHUB_EVENT_NAME") == "pull_request")
            {
                var prNumber = Environment.GetEnvironmentVariable("GITHUB_REF_NAME")?.Split('/')[0];
                var repo = Environment.GetEnvironmentVariable("GITHUB_REPOSITORY");
                var prLink = $"{repo}/pull/{prNumber}";
                return $"PR# {prNumber} on Repo: {repo} ({prLink})";
            }

            try
            {
                string gitVersion = RunCommandAsync(GIT_VERSION_COMMAND).EnsureCompleted();
                if (string.IsNullOrEmpty(gitVersion))
                {
                    throw new Exception("Git is not installed on the machine");
                }

                string isInsideWorkTree = RunCommandAsync(GIT_REV_PARSE).EnsureCompleted();
                if (isInsideWorkTree.Trim() != "true")
                {
                    throw new Exception("Not inside a git repository");
                }

                string gitCommitMessage = RunCommandAsync(GIT_COMMIT_MESSAGE_COMMAND).EnsureCompleted();
                return gitCommitMessage;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        internal static async Task<string> RunCommandAsync(string command, bool async = false)
        {
            string shell, shellArgs;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                shell = "/bin/bash";
                shellArgs = $"-c \"{command}\"";
            }
            else
            {
                shell = "cmd";
                shellArgs = $"/c {command}";
            }
            var processInfo = new ProcessStartInfo(shell, shellArgs)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processInfo })
            {
                process.Start();
                string result;
                if (async)
                {
                    result = await process.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
                }
                else
                {
                    result = process.StandardOutput.ReadToEnd();
                }
                process.WaitForExit();
                return result;
            }
        }

        internal static string GetCurrentOS()
        {
            PlatformID platform = Environment.OSVersion.Platform;
            if (platform == PlatformID.Unix)
                return OSConstants.s_lINUX;
            else if (platform == PlatformID.MacOSX)
                return OSConstants.s_mACOS;
            else
                return OSConstants.s_wINDOWS;
        }

        internal TokenDetails ParseWorkspaceIdFromAccessToken(JsonWebTokenHandler? jsonWebTokenHandler, string? accessToken)
        {
            if (jsonWebTokenHandler == null)
            {
                jsonWebTokenHandler = new JsonWebTokenHandler();
            }
            TokenDetails tokenDetails = new();
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken), "AccessToken is null or empty");
            }
            try
            {
                JsonWebToken inputToken = (JsonWebToken)jsonWebTokenHandler.ReadToken(accessToken);
                var aid = inputToken.Claims.FirstOrDefault(c => c.Type == "aid")?.Value ?? string.Empty;

                if (!string.IsNullOrEmpty(aid)) // Custom Token
                {
                    _logger.Info("Custom Token parsing");
                    tokenDetails.aid = aid;
                    tokenDetails.oid = inputToken.Claims.FirstOrDefault(c => c.Type == "oid")?.Value ?? string.Empty;
                    tokenDetails.id = inputToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? string.Empty;
                    tokenDetails.userName = inputToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
                }
                else // Entra Token
                {
                    _logger.Info("Entra Token parsing");
                    tokenDetails.aid = Environment.GetEnvironmentVariable(ReporterConstants.s_pLAYWRIGHT_SERVICE_WORKSPACE_ID) ?? string.Empty;
                    tokenDetails.oid = inputToken.Claims.FirstOrDefault(c => c.Type == "oid")?.Value ?? string.Empty;
                    tokenDetails.id = string.Empty;
                    tokenDetails.userName = inputToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
                    // TODO add back suport for old claims https://devdiv.visualstudio.com/OnlineServices/_git/PlaywrightService?path=/src/Common/Authorization/JwtSecurityTokenValidator.cs&version=GBmain&line=200&lineEnd=200&lineStartColumn=30&lineEndColumn=52&lineStyle=plain&_a=contents
                }

                return tokenDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsTimeGreaterThanCurrentPlus10Minutes(string sasUri)
        {
            try
            {
                // Parse the SAS URI
                Uri url = new Uri(sasUri);
                string query = url.Query;
                var queryParams = System.Web.HttpUtility.ParseQueryString(query);
                string? expiryTime = queryParams["se"]; // 'se' is the query parameter for the expiry time

                if (!string.IsNullOrEmpty(expiryTime))
                {
                    // Convert expiry time to a timestamp
                    DateTime expiryDateTime = DateTime.Parse(expiryTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
                    long timestampFromIsoString = ((DateTimeOffset)expiryDateTime).ToUnixTimeMilliseconds();

                    // Get current time + 10 minutes in milliseconds
                    long currentTimestampPlus10Minutes = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + (10 * 60 * 1000);

                    bool isSasValidityGreaterThanCurrentTimePlus10Minutes = timestampFromIsoString > currentTimestampPlus10Minutes;

                    if (!isSasValidityGreaterThanCurrentTimePlus10Minutes)
                    {
                        // Log if SAS is close to expiry
                        _logger.Info(
                            $"Sas rotation required because close to expiry, SasUriValidTillTime: {timestampFromIsoString}, CurrentTime: {currentTimestampPlus10Minutes}"
                        );
                    }

                    return isSasValidityGreaterThanCurrentTimePlus10Minutes;
                }

                _logger.Info("Sas rotation required because expiry param not found.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Info($"Sas rotation required because of {ex.Message}.");
                return false;
            }
        }
    }
}

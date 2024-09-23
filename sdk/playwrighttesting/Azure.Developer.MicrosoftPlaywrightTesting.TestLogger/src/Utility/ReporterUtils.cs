// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility
{
    internal class ReporterUtils
    {
        internal static string GetRunId(CIInfo cIInfo)
        {
            if (cIInfo.Provider == Constants.DEFAULT)
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

        internal static string GetRunName(CIInfo ciInfo)
        {
            string GIT_VERSION_COMMAND = "git --version";
            string GIT_REV_PARSE = "git rev-parse --is-inside-work-tree";
            string GIT_COMMIT_MESSAGE_COMMAND = "git log -1 --pretty=%B";

            if (ciInfo.Provider == Constants.GITHUB_ACTIONS &&
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
            var processInfo = new ProcessStartInfo("cmd", $"/c {command}")
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
    }
}

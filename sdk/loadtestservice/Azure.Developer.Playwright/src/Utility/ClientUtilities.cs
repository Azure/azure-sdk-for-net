// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Azure.Developer.Playwright.Implementation;
using Azure.Developer.Playwright.Interface;
using Azure.Developer.Playwright.Model;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Azure.Developer.Playwright.Utility
{
    internal class ClientUtilities
    {
        private readonly IEnvironment _environment;
        private readonly JsonWebTokenHandler _jsonWebTokenHandler;
        private readonly IPlaywrightVersion _playwrightVersion;

        public ClientUtilities(IEnvironment? environment = null, JsonWebTokenHandler? jsonWebTokenHandler = null, IPlaywrightVersion? playwrightVersion = null)
        {
            _environment = environment ?? new EnvironmentHandler();
            _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
            _playwrightVersion = playwrightVersion ?? new PlaywrightVersion();
        }

        internal static string? GetServiceCompatibleOs(OSPlatform? oSPlatform)
        {
            if (oSPlatform == null)
                return null;
            if (oSPlatform.Equals(OSPlatform.Linux))
                return OSConstants.s_lINUX;
            if (oSPlatform.Equals(OSPlatform.Windows))
                return OSConstants.s_wINDOWS;
            throw new ArgumentException(Constants.s_invalid_os_error);
        }

        internal static OSPlatform? GetOSPlatform(string? os)
        {
            if (string.IsNullOrEmpty(os))
                return null;
            if (os == OSConstants.s_lINUX)
                return OSPlatform.Linux;
            if (os == OSConstants.s_wINDOWS)
                return OSPlatform.Windows;
            throw new ArgumentException(Constants.s_invalid_os_error);
        }

        internal string GetDefaultRunId()
        {
            var runIdFromEnvironmentVariable = _environment.GetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable);
            if (!string.IsNullOrEmpty(runIdFromEnvironmentVariable))
                return runIdFromEnvironmentVariable!;
            var runId = CIProvider.GetRunId();
            _environment.SetEnvironmentVariable(Constants.s_playwright_service_run_id_environment_variable, runId);
            return runId;
        }

        internal string GetDefaultRunName(string runId)
        {
            var runNameFromEnvironmentVariable = _environment.GetEnvironmentVariable(Constants.s_playwright_service_run_name_environment_variable);
            if (!string.IsNullOrEmpty(runNameFromEnvironmentVariable))
                return runNameFromEnvironmentVariable!;
            _environment.SetEnvironmentVariable(Constants.s_playwright_service_run_name_environment_variable, runId);
            return runId;
        }

        internal void ValidateMptPAT(string? authToken, string serviceEndpoint)
        {
            if (string.IsNullOrEmpty(authToken))
                throw new Exception(Constants.s_no_auth_error);
            JsonWebToken jsonWebToken = _jsonWebTokenHandler!.ReadJsonWebToken(authToken) ?? throw new Exception(Constants.s_invalid_mpt_pat_error);
            var tokenWorkspaceId = jsonWebToken.Claims.FirstOrDefault(c => c.Type == "pwid")?.Value;
            Match match = Regex.Match(serviceEndpoint, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/playwrightworkspaces/(?<workspaceId>[\w-]+)/");
            if (!match.Success)
                throw new Exception(Constants.s_invalid_service_endpoint_error_message);
            var serviceEndpointWorkspaceId = match.Groups["workspaceId"].Value;
            if (tokenWorkspaceId != serviceEndpointWorkspaceId)
                throw new Exception(Constants.s_workspace_mismatch_error);
            var expiry = (long)(jsonWebToken.ValidTo - new DateTime(1970, 1, 1)).TotalSeconds;
            if (expiry <= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                throw new Exception(Constants.s_expired_mpt_pat_error);
        }
        internal string GetTestRunApiUrl()
         {
            string apiVersion = ApiVersionConstants.s_latestApiVersion;
            var serviceUrl = _environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceUri.ToString());
            if (string.IsNullOrEmpty(serviceUrl))
            {
                throw new Exception(Constants.s_no_service_endpoint_error_message);
            }

            Match match = Regex.Match(serviceUrl, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/playwrightworkspaces/(?<workspaceId>[\w-]+)/");
            if (!match.Success)
            {
                throw new Exception(Constants.s_invalid_service_endpoint_error_message);
            }

            var region = match.Groups["region"].Value;
            var domain = match.Groups["domain"].Value;
            var baseUrl = $"https://{region}.reporting.api.{domain}";
            return $"{baseUrl}?api-version={apiVersion}";
        }

        internal string ExtractWorkspaceIdFromEndpoint(string serviceEndpoint)
        {
            var match = Regex.Match(serviceEndpoint, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/playwrightworkspaces/(?<workspaceId>[\w-]+)/");
            if (!match.Success)
            {
                throw new Exception(Constants.s_invalid_service_endpoint_error_message);
            }
                return match.Groups["workspaceId"].Value;
    }

    internal RunConfig GetTestRunConfig()
    {
        // Get the full version and format it to the SemVer standard (Major.Minor.Patch)
        var fullVersion = _playwrightVersion.GetPlaywrightVersion();
        var versionParts = fullVersion.Split('.');
        var playwrightVersion = string.Join(".", versionParts.Take(Math.Min(3, versionParts.Length)));

        var testRunConfig = new RunConfig
        {
            Framework = new RunFramework
            {
                Name = RunConfigConstants.s_tEST_FRAMEWORK_NAME,
                Version = playwrightVersion,
                RunnerName = RunConfigConstants.s_tEST_FRAMEWORK_RUNNERNAME
            },
            SdkLanguage = RunConfigConstants.s_tEST_SDK_LANGUAGE
        };

        return testRunConfig;
    }
    }
}

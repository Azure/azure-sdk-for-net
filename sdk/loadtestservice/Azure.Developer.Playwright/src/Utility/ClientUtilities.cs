﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

        public ClientUtilities(IEnvironment? environment = null, JsonWebTokenHandler? jsonWebTokenHandler = null)
        {
            _environment = environment ?? new EnvironmentHandler();
            _jsonWebTokenHandler = jsonWebTokenHandler ?? new JsonWebTokenHandler();
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

        internal void ValidateMptPAT(string? authToken, string serviceEndpoint)
        {
            if (string.IsNullOrEmpty(authToken))
                throw new Exception(Constants.s_no_auth_error);
            JsonWebToken jsonWebToken = _jsonWebTokenHandler!.ReadJsonWebToken(authToken) ?? throw new Exception(Constants.s_invalid_mpt_pat_error);
            var tokenWorkspaceId = jsonWebToken.Claims.FirstOrDefault(c => c.Type == "aid")?.Value;
            Match match = Regex.Match(serviceEndpoint, @"wss://(?<region>[\w-]+)\.api\.(?<domain>playwright(?:-test|-int)?\.io|playwright\.microsoft\.com)/accounts/(?<workspaceId>[\w-]+)/");
            if (!match.Success)
                throw new Exception(Constants.s_invalid_service_endpoint_error_message);
            var serviceEndpointWorkspaceId = match.Groups["workspaceId"].Value;
            if (tokenWorkspaceId != serviceEndpointWorkspaceId)
                throw new Exception(Constants.s_workspace_mismatch_error);
            var expiry = (long)(jsonWebToken.ValidTo - new DateTime(1970, 1, 1)).TotalSeconds;
            if (expiry <= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                throw new Exception(Constants.s_expired_mpt_pat_error);
        }
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Gets a token using Azure CLI 2.0 for local development scenarios. 
    /// az account get-access-token --resource
    /// </summary>
    internal class AzureCliAccessTokenProvider : NonInteractiveAzureServiceTokenProviderBase
    {
        // Allows for unit testing, by mocking IProcessManager
        private readonly IProcessManager _processManager;

        // Constants related to command to execute to get token using Azure CLI
        private const string Cmd = "cmd.exe";
        private const string Bash = "/bin/bash";
        private const string GetTokenCommand = "az account get-access-token -o json";
        private const string ResourceArgumentName = "--resource";

        // This is the path that a develop can set to tell this class what the install path for Azure CLI is. 
        private const string AzureCliPath = "AzureCLIPath";

        // The default install paths are used to find Azure CLI. This is for security, so that any path in the calling program's Path environment is not used to execute Azure CLI.
        private readonly string _azureCliDefaultPathWindows =
            $"{EnvironmentHelper.GetEnvironmentVariable("ProgramFiles(x86)")}\\Microsoft SDKs\\Azure\\CLI2\\wbin;{EnvironmentHelper.GetEnvironmentVariable("ProgramFiles")}\\Microsoft SDKs\\Azure\\CLI2\\wbin"
        ;

        // Default path for non-Windows. 
        private const string AzureCliDefaultPath = "/usr/bin:/usr/local/bin";

        internal AzureCliAccessTokenProvider(IProcessManager processManager)
        {
            _processManager = processManager;
            PrincipalUsed = new Principal { Type = "User" };
        }

#if net452 || net461
        // detect when running with Mono on Unix
        // https://www.mono-project.com/docs/faq/technical/#how-to-detect-the-execution-platform
        private bool IsUnixPlatform()
        {
            int p = (int)Environment.OSVersion.Platform;
            return p == 4 || p == 6 || p == 128;
        }
#endif

        private ProcessStartInfo GetProcessStartInfo(string resource)
        {

            ProcessStartInfo startInfo;
            string processPath;
            string currentPath = EnvironmentHelper.GetEnvironmentVariable("PATH");

#if net452 || net461
            if (!IsUnixPlatform())
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
#endif
            {
                startInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(EnvironmentHelper.SystemDirectory, Cmd),
                    Arguments = $"/c {GetTokenCommand} {ResourceArgumentName} {resource}"
                };

                processPath = $"{EnvironmentHelper.GetEnvironmentVariable(AzureCliPath)};{_azureCliDefaultPathWindows};{currentPath}";
            }
            else
            {
                startInfo = new ProcessStartInfo
                {
                    FileName = Bash,
                    Arguments = $"-c \"{GetTokenCommand} {ResourceArgumentName} {resource}\""
                };

                processPath = $"{EnvironmentHelper.GetEnvironmentVariable(AzureCliPath)}:{AzureCliDefaultPath}:{currentPath}";
            }

            // Default install location for Az CLI is included. If developer has installed to non-default location, the path can be specified using AzureCliPath variable.
#if FullNetFx
            startInfo.EnvironmentVariables["PATH"] = processPath;
#else
            startInfo.Environment["PATH"] = processPath;
#endif
            return startInfo;
        }


        public override async Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Validate resource, since it gets sent as a command line argument to Azure CLI
                ValidationHelper.ValidateResource(resource);

                // Execute Azure CLI to get token
                string response = await _processManager.ExecuteAsync(new Process { StartInfo = GetProcessStartInfo(resource) }, cancellationToken).ConfigureAwait(false);

                // Parse the response
                TokenResponse tokenResponse = TokenResponse.Parse(response);

                var accessToken = tokenResponse.AccessToken2;

                AccessToken token = AccessToken.Parse(accessToken);

                PrincipalUsed.IsAuthenticated = true;

                if (token != null)
                {
                    // Set principal used based on the claims in the access token. 
                    PrincipalUsed.UserPrincipalName = !string.IsNullOrEmpty(token.Upn) ? token.Upn : token.Email;
                    PrincipalUsed.TenantId = token.TenantId;
                }

                return AppAuthenticationResult.Create(tokenResponse);
            }
            catch (Exception exp)
            {
                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    $"{AzureServiceTokenProviderException.AzureCliUsed} {AzureServiceTokenProviderException.GenericErrorMessage} {exp.Message}");
            }
        }
    }
}

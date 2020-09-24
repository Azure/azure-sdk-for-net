﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Gets a token using Visual Studio key chain for local development scenarios. 
    /// </summary>
    internal class VisualStudioAccessTokenProvider : NonInteractiveAzureServiceTokenProviderBase
    {
        // Represents the token provider file, which has information about executable to call to get token.
        private VisualStudioTokenProviderFile _visualStudioTokenProviderFile;

        // Allows for unit testing, by mocking IProcessManager or using non-default file path for token provider file
        private readonly IProcessManager _processManager;

        private const string ResourceArgumentName = "--resource";
        private const string TenantArgumentName = "--tenant";
        private const string LocalAppDataPathEnv = "LOCALAPPDATA";
        private const string NoAppDataEnvironmentVariableError = "Environment variable LOCALAPPDATA not set.";
        private const string TokenProviderFilePath = ".IdentityService\\AzureServiceAuth\\tokenprovider.json";

        internal const string TokenProviderGenericError = "Exception for Visual Studio token provider";
        internal const string TokenProviderFileNotFound = "Visual Studio token provider file not found at";
        internal const string TokenProvidersNotFound = "No valid Visual Studio token providers were found in the Visual Studio token provider file";

        internal VisualStudioAccessTokenProvider(IProcessManager processManager, VisualStudioTokenProviderFile visualStudioTokenProviderFile = null)
        {
            _visualStudioTokenProviderFile = visualStudioTokenProviderFile;
            _processManager = processManager;
            PrincipalUsed = new Principal { Type = "User" };
        }

        /// <summary>
        /// Gets the token provider file from user's local appdata folder.
        /// </summary>
        /// <returns></returns>
        private VisualStudioTokenProviderFile GetTokenProviderFile()
        {
            if (string.IsNullOrEmpty(EnvironmentHelper.GetEnvironmentVariable(LocalAppDataPathEnv)))
            {
                throw new Exception(NoAppDataEnvironmentVariableError);
            }

            string tokenProviderPath = Path.Combine(EnvironmentHelper.GetEnvironmentVariable(LocalAppDataPathEnv),
                TokenProviderFilePath);

            if (!File.Exists(tokenProviderPath))
            {
                throw new Exception($"{TokenProviderFileNotFound} \"{tokenProviderPath}\"");
            }

            return VisualStudioTokenProviderFile.Load(tokenProviderPath);
        }

        /// <summary>
        /// Gets a list of token provider executables to call to get token.
        /// </summary>
        /// <param name="visualStudioTokenProviderFile">Visual Studio Token provider file</param>
        /// <param name="resource"></param>
        /// <param name="tenant"></param>
        /// <returns></returns>
        private List<ProcessStartInfo> GetProcessStartInfos(VisualStudioTokenProviderFile visualStudioTokenProviderFile, 
            string resource, string tenant = default)
        {
            List<ProcessStartInfo> processStartInfos = new List<ProcessStartInfo>();

            foreach (var tokenProvider in visualStudioTokenProviderFile.TokenProviders)
            {
                // If file does not exist, the version of Visual Studio that set the token provider may be uninstalled. 
                if (File.Exists(tokenProvider.Path))
                {
                    string arguments = $"{ResourceArgumentName} {resource} ";

                    if (tenant != default)
                    {
                        arguments += $"{TenantArgumentName} {tenant} ";
                    }

                    // Add the arguments set in the token provider file.
                    if (tokenProvider.Arguments?.Count > 0)
                    {
                        arguments += string.Join(" ", tokenProvider.Arguments);
                    }
               
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = tokenProvider.Path,
                        Arguments = arguments
                    };

                    processStartInfos.Add(startInfo);
                }
            }

            if (processStartInfos.Count == 0)
            {
                throw new Exception($"{TokenProvidersNotFound} \"{visualStudioTokenProviderFile.FilePath}\"");
            }

            return processStartInfos;
        }

        public override async Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Validate resource, since it gets sent as a command line argument to Visual Studio token provider.
                ValidationHelper.ValidateResource(resource);

                _visualStudioTokenProviderFile = _visualStudioTokenProviderFile ?? GetTokenProviderFile();

                // Get process start infos based on Visual Studio token providers
                var processStartInfos = GetProcessStartInfos(_visualStudioTokenProviderFile, resource, UriHelper.GetTenantByAuthority(authority));

                // To hold reason why token could not be acquired per token provider tried. 
                Dictionary<string, string> exceptionDictionary = new Dictionary<string, string>();

                foreach (var startInfo in processStartInfos)
                {
                    try
                    {
                        // For each of them, try to get token
                        string response = await _processManager
                            .ExecuteAsync(new Process {StartInfo = startInfo}, cancellationToken)
                            .ConfigureAwait(false);

                        TokenResponse tokenResponse = TokenResponse.Parse(response);

                        AccessToken token = AccessToken.Parse(tokenResponse.AccessToken);

                        PrincipalUsed.IsAuthenticated = true;

                        if (token != null)
                        {
                            // Set principal used based on the claims in the access token. 
                            PrincipalUsed.UserPrincipalName =
                                !string.IsNullOrEmpty(token.Upn) ? token.Upn : token.Email;

                            PrincipalUsed.TenantId = token.TenantId;
                        }

                        return AppAuthenticationResult.Create(tokenResponse);

                    }
                    catch (Exception exp)
                    {
                        // If token cannot be acquired using a token provider, try the next one
                        exceptionDictionary[Path.GetFileName(startInfo.FileName)] = exp.Message;
                    }
                }

                // Could not acquire access token, throw exception
                string message = string.Empty;

                // Include exception details for each token provider that was tried
                foreach (string key in exceptionDictionary.Keys)
                {
                    message += Environment.NewLine +
                               $"{TokenProviderGenericError} {key} : {exceptionDictionary[key]} ";
                }

                // Throw exception if none of the token providers worked
                throw new Exception(message);
                
            }
            catch (Exception exp)
            {
                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    $"{AzureServiceTokenProviderException.VisualStudioUsed} {AzureServiceTokenProviderException.GenericErrorMessage} {exp.Message}");
            }
        }
    }
}

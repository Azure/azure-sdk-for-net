// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Gets a token using Visual Studio key chain for local development scenarios. 
    /// </summary>
    internal class VisualStudioAccessTokenProvider : NonInteractiveAzureServiceTokenProviderBase
    {
        private readonly VisualStudioTokenProviderFile _visualStudioTokenProviderFile;
        
        // Allows for unit testing, by mocking IProcessManager
        private readonly IProcessManager _processManager;

        private const string ResourceArgumentName = "--resource";
        private const string TenantArgumentName = "--tenant";
        private readonly string _tokenProviderFilePath = Path.Combine(Environment.GetEnvironmentVariable("LOCALAPPDATA"), ".IdentityService/AzureServiceAuth/tokenprovider.json");

        internal VisualStudioAccessTokenProvider(VisualStudioTokenProviderFile visualStudioTokenProviderFile, IProcessManager processManager)
        {
            _visualStudioTokenProviderFile = visualStudioTokenProviderFile;
            _processManager = processManager;
            PrincipalUsed = new Principal { Type = "User" };
        }

        private List<ProcessStartInfo> GetProcessStartInfos(VisualStudioTokenProviderFile visualStudioTokenProviderFile, 
            string resource, string tenant = default(string))
        {
            List<ProcessStartInfo> processStartInfos = new List<ProcessStartInfo>();

            foreach (var tokenProvider in visualStudioTokenProviderFile.TokenProviders)
            {
                if (File.Exists(tokenProvider.Path))
                {
                    string arguments = $"{ResourceArgumentName} {resource} ";

                    if (tenant != default(string))
                    {
                        arguments += $"{TenantArgumentName} {tenant} ";
                    }

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

            return processStartInfos;
        }

        public override async Task<string> GetTokenAsync(string resource, string authority)
        {
            try
            {
                VisualStudioTokenProviderFile visualStudioTokenProviderFile;

                if (_visualStudioTokenProviderFile == null)
                {
                    if (!File.Exists(_tokenProviderFilePath))
                    {
                        throw new Exception($"Visual Studio Token provider file not found at {_tokenProviderFilePath}");
                    }

                    visualStudioTokenProviderFile = VisualStudioTokenProviderFile.Parse(File.ReadAllText(_tokenProviderFilePath));
                }
                else
                {
                    visualStudioTokenProviderFile = _visualStudioTokenProviderFile;
                }

                // Get process start infos based on Visual Studio token providers
                var processStartInfos = GetProcessStartInfos(visualStudioTokenProviderFile, resource);

                // To hold reason why token could not be acquired per token provider tried. 
                Dictionary<string, string> exceptionDictionary = new Dictionary<string, string>();

                foreach (var startInfo in processStartInfos)
                {
                    // For each of them, try to get token
                    Tuple<bool, string> response = await _processManager
                        .ExecuteAsync(new Process {StartInfo = startInfo})
                        .ConfigureAwait(false);

                    // If the response was successful
                    if (response.Item1)
                    {
                        TokenResponse tokenResponse = TokenResponse.Parse(response.Item2);

                        AccessToken token = AccessToken.Parse(tokenResponse.AccessToken);

                        PrincipalUsed.IsAuthenticated = true;

                        if (token != null)
                        {
                            // Set principal used based on the claims in the access token. 
                            PrincipalUsed.UserPrincipalName =
                                !string.IsNullOrEmpty(token.Upn) ? token.Upn : token.Email;
                            PrincipalUsed.TenantId = token.TenantId;
                        }

                        return tokenResponse.AccessToken;
                    }
                    
                    // If token cannot be acquired using a token provider, try the next one
                    exceptionDictionary[Path.GetFileName(startInfo.FileName)] = response.Item2;
                }

                // Could not acquire access token, throw exception
                string message = string.Empty;

                // Include exception details for each token provider that was tried
                foreach (string key in exceptionDictionary.Keys)
                {
                    message += Environment.NewLine +
                               $"Exception for Visual Studio token provider {key} : {exceptionDictionary[key]}";
                }

                // Throw exception if none of the token providers worked
                throw new Exception(message);
                
            }
            catch (Exception exp)
            {
                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    $"{AzureServiceTokenProviderException.VisualStudioUsed} {AzureServiceTokenProviderException.GenericErrorMessage}  {exp.Message}");
            }
        }
    }
}

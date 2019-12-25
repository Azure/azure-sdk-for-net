// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using System.Text.Json;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using Azure CLI to generated an access token.
    /// </summary>
    public class CliCredential : TokenCredential, IExtendedTokenCredential
    {
        private const string AzureCLINotInstalled = "Azure CLI not installed";
        private const string WinAzureCLIError = "'az' is not recognized";

        private readonly CredentialPipeline _pipeline;

        /// <summary>
        /// Create an instance of CliCredential class.
        /// </summary>
        public CliCredential()
            : this(CredentialPipeline.GetInstance(null))
        { }

        /// <summary>
        /// Create an instance of CliCredential class.
        /// </summary>
        /// <param name="options"></param>
        public CliCredential(TokenCredentialOptions options)
         : this(CredentialPipeline.GetInstance(options))
        {
        }

        internal CliCredential(CredentialPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        /// <summary>
        /// Obtains a access token from Azure CLI credential, using this access token to authenticate. This method called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(requestContext, cancellationToken).GetAwaiter().GetResult().GetTokenOrThrow();
        }

        /// <summary>
        /// Obtains a access token from Azure CLI service, using the access token to authenticate. This method id called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return (await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false)).GetTokenOrThrow();
        }

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext, cancellationToken).ConfigureAwait(false);
        }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        private async ValueTask<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.CLICredential.GetToken", requestContext);

            try
            {
                string fileName = string.Empty;
                string argument = string.Empty;
                string command = ScopeUtilities.ScopesToResource(requestContext.Scopes);
                string extendCommand = "az account get-access-token --resource " + command;

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

                Process proc = new Process();

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

                string cliResult = stdOutput.ToString().Trim();
                string errorMessage = stdError.ToString().Trim();

                if (proc.ExitCode != 0)
                {
                    bool winErrorFlag = errorMessage.StartsWith(WinAzureCLIError, StringComparison.CurrentCultureIgnoreCase);
                    string pattter = "az:(.*)not found";
                    bool otherErrorFlag = Regex.IsMatch(errorMessage, pattter);

                    if (winErrorFlag || otherErrorFlag)
                    {
                        throw new CredentialUnavailableException(AzureCLINotInstalled);
                    }

                    throw new CredentialUnavailableException(errorMessage);
                }

                byte[] byteArrary = Encoding.ASCII.GetBytes(cliResult);
                MemoryStream stream = new MemoryStream(byteArrary);

                Dictionary<string, string> result = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream, null, cancellationToken);
                result.TryGetValue("accessToken", out string accessToken);
                result.TryGetValue("expiresOn", out string expiresOnValue);
                DateTimeOffset expiresOn = DateTimeOffset.Parse(expiresOnValue, null, DateTimeStyles.AdjustToUniversal);

                AccessToken token = new AccessToken(accessToken, expiresOn);

                return new ExtendedAccessToken(scope.Succeeded(token));
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                throw scope.Failed(e);
            }
        }
    }
}

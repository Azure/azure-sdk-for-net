// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using Azure CLI to generated an access token.
    /// </summary>
    public class CliCredential : TokenCredential, IExtendedTokenCredential
    {
        private const string AzureCLINotInstalled = "Azure CLI not installed";
        private const string AzureCLIError = "'az' is not recognized as an internal or external command, operable program or batch file.";

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
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(requestContext).GetAwaiter().GetResult().GetTokenOrThrow();
        }

        /// <summary>
        /// Obtains a access token from Azure CLI service, using the access token to authenticate. This method id called by Azure SDK clients.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return (await GetTokenImplAsync(requestContext).ConfigureAwait(false)).GetTokenOrThrow();
        }

        async ValueTask<ExtendedAccessToken> IExtendedTokenCredential.GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(requestContext).ConfigureAwait(false);
        }

        ExtendedAccessToken IExtendedTokenCredential.GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(requestContext).GetAwaiter().GetResult();
        }

        private ValueTask<ExtendedAccessToken> GetTokenImplAsync(TokenRequestContext requestContext)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("Azure.Identity.CLICredential.GetToken", requestContext);

            try
            {
                string command = ScopeUtilities.ScopesToResource(requestContext.Scopes);
                string extendCommand = "az account get-access-token --resource " + command;

                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c" + extendCommand)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                Process proc = new Process();
                proc.StartInfo = procStartInfo;

                string error = proc.StandardError.ReadToEnd();
                if (string.Equals(error, AzureCLIError, StringComparison.Ordinal))
                {
                    throw new Exception(AzureCLINotInstalled);
                }

                string cliResult = proc.StandardOutput.ReadToEnd();

                Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(cliResult);
                result.TryGetValue("accessToken", out string accessToken);
                result.TryGetValue("expiresOn", out string expiresOnValue);
                DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(expiresOnValue, null, DateTimeStyles.AssumeUniversal);

                AccessToken token = new AccessToken(accessToken, dateTimeOffset);

                return new ValueTask<ExtendedAccessToken>(new ExtendedAccessToken(scope.Succeeded(token)));
            }
            catch (Exception e)
            {
                throw scope.Failed(e);
            }
        }
    }
}

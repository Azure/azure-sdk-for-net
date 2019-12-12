// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Management.Automation;
using Newtonsoft.Json;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using Azure CLI to generated an access token. More information on how
    /// to gengerate an access token can be found here:
    /// https://docs.microsoft.com/en-us/cli/azure/account?view=azure-cli-latest#az-account-get-access-token
    /// </summary>
    public class CliCredential : TokenCredential,IExtendedTokenCredential
    {
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
        /// Obtains a access token from Azure CLI service, using the access token to authenticate. This method id called by Azure SDK clients.
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
                string cliResult = string.Empty;

                using (PowerShell powerShell = PowerShell.Create())
                {
                    IAsyncResult pSObjects = powerShell.AddScript(extendCommand).BeginInvoke();

                    foreach (PSObject pSObject in powerShell.EndInvoke(pSObjects))
                    {
                        cliResult += pSObject.BaseObject.ToString();
                    }
                }

                Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(cliResult);
                result.TryGetValue("accessToken", out string accessToken);
                result.TryGetValue("expiresOn", out string expiresOnValue);
                DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(expiresOnValue, null, System.Globalization.DateTimeStyles.AssumeUniversal);

                AccessToken token = new AccessToken(accessToken, dateTimeOffset);

                return new ValueTask<ExtendedAccessToken>(new ExtendedAccessToken(scope.Succeeded(token)));
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

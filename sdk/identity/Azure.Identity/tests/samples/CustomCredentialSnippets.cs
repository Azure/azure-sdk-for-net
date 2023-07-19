// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests.samples
{
    public class CustomCredentialSnippets
    {
        [Test]
        public void TokenCredentialCreateUsage()
        {
            #region Snippet:TokenCredentialCreateUsage
            AccessToken token = GetTokenForScope("https://storage.azure.com/.default");

            var credential = DelegatedTokenCredential.Create((_, _) => token);

            var client = new BlobClient(new Uri("https://aka.ms/bloburl"), credential);
            #endregion
        }

        private AccessToken GetTokenForScope(string scope)
        {
            return new AccessToken();
        }

        #region Snippet:ConfidentialClientCredential
        public class ConfidentialClientCredential : TokenCredential
        {
            private readonly IConfidentialClientApplication _confidentialClient;

            public ConfidentialClientCredential(IConfidentialClientApplication confidentialClient)
            {
                _confidentialClient = confidentialClient;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
            }

            public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                AuthenticationResult result = await _confidentialClient.AcquireTokenForClient(requestContext.Scopes).ExecuteAsync();

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
        }
        #endregion

        [Test]
        public void ConfidentialClientCredentialUsage()
        {
            string clientSecret = "00000000-0000-0000-0000-000000000000";
            string clientId = "00000000-0000-0000-0000-000000000000";

            #region Snippet:ConfidentialClientCredentialUsage
            IConfidentialClientApplication confidentialClient = ConfidentialClientApplicationBuilder.Create(clientId).WithClientSecret(clientSecret).Build();

            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), new ConfidentialClientCredential(confidentialClient));
            #endregion
        }

        //#region Snippet:OnBehalfOfCredential
        public class OnBehalfOfCredential : TokenCredential
        {
            private readonly IConfidentialClientApplication _confidentialClient;
            private readonly UserAssertion _userAssertion;

            public OnBehalfOfCredential(string clientId, string clientSecret, string userAccessToken)
            {
                _confidentialClient = ConfidentialClientApplicationBuilder.Create(clientId).WithClientSecret(clientSecret).Build();

                _userAssertion = new UserAssertion(userAccessToken);
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
            }

            public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                AuthenticationResult result = await _confidentialClient.AcquireTokenOnBehalfOf(requestContext.Scopes, _userAssertion).ExecuteAsync();

                return new AccessToken(result.AccessToken, result.ExpiresOn);
            }
        }
        //#endregion

        public void OnBehalfOfCredentialUsage()
        {
            string clientSecret = "00000000-0000-0000-0000-000000000000";
            string clientId = "00000000-0000-0000-0000-000000000000";
            string userAccessToken = "00000000-0000-0000-0000-000000000000";

            //#region Snippet:OnBehalfOfCredentialUsage
            var oboCredential = new OnBehalfOfCredential(clientId, clientSecret, userAccessToken);

            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), oboCredential);
            //#endregion
        }
    }
}

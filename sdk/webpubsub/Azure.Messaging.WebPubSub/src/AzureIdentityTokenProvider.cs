// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// Hub endpoint with aad auth methods.
    /// </summary>
    internal class AzureIdentityTokenProvider : ITokenProvider
    {
        private const string DefaultScope = "https://webpubsub.azure.com/.default";

        public TokenCredential Credential { get; private set; }

        public Uri Endpoint { get; }

        private static TokenRequestContext DefaultContext { get; } = new TokenRequestContext(new string[] { DefaultScope });

        public AzureIdentityTokenProvider(Uri endpoint, TokenCredential credential)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            Endpoint = endpoint;
            Credential = credential;
        }

        public AccessToken GetServerToken(string audience)
        {
            var source = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            return Credential.GetToken(DefaultContext, source.Token);
        }

        public Task<AccessToken> GetServerTokenAsync(string audience, CancellationToken token = default)
        {
            return Credential.GetTokenAsync(default, token).AsTask();
        }

        public Task<AccessToken> GetClientTokenAsync(string audience,
                                                     string userId,
                                                     string[] roles,
                                                     DateTimeOffset expiresAt,
                                                     CancellationToken token = default)
        {
            // TODO call REST API to get an access token for client.
            throw new NotImplementedException();
        }

        public AccessToken GetClientToken(string audience,
                                          string userId,
                                          string[] roles,
                                          DateTimeOffset expiresAt)
        {
            var source = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            return GetClientTokenAsync(audience, userId, roles, expiresAt, source.Token).Result;
        }
    }
}

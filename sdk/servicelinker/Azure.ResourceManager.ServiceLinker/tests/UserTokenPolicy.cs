// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ServiceLinker.Tests
{
    public class UserTokenPolicy : HttpPipelinePolicy
    {
        public const string UserTokenHeader = "x-ms-serviceconnector-user-token";
        private const string BearerTokenPrefix = "bearer ";
        private const string AuthorizationHeaderKey = "Authorization";
        private readonly TokenCredential _credential;
        private readonly string _scope;
        public UserTokenPolicy(TokenCredential credential, string scope)
        {
            _credential = credential;
            _scope = scope;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            string token;
            if (message.Request.Headers.TryGetValue(AuthorizationHeaderKey, out string authorization) && authorization.StartsWith(BearerTokenPrefix, StringComparison.InvariantCultureIgnoreCase))
            {
                token = authorization.Substring(BearerTokenPrefix.Length);
            }
            else
            {
                token = (await _credential.GetTokenAsync(new TokenRequestContext(new[] { _scope }), default)).Token;
            }

            message.Request.Headers.SetValue(UserTokenHeader, token);
            await ProcessNextAsync(message, pipeline);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline).AsTask().Wait();
        }
    }
}

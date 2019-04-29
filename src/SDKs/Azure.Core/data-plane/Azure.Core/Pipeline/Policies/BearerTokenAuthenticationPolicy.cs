// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Credentials;
using Azure.Core.Pipeline;

namespace Azure.Base.Http.Pipeline
{
    public class BearerTokenAuthenticationPolicy : HttpPipelinePolicy
    {   
        private TokenCredential _credential;
        private string[] _scopes;

        public BearerTokenAuthenticationPolicy(TokenCredential credential, string scope)
        {
            _credential = credential ?? throw new ArgumentNullException(nameof(credential));
            _scopes = new string[] { scope } ?? throw new ArgumentNullException(nameof(scope));
        }

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            string token = await _credential.GetTokenAsync(_scopes, message.Cancellation).ConfigureAwait(false);
            
            message.Request.AddHeader(HttpHeader.Names.Authorization, "Bearer " + token);

            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }
    }
}

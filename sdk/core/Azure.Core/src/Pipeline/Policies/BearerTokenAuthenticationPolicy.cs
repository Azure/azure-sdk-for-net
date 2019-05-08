// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline.Policies
{
    public class BearerTokenAuthenticationPolicy: HttpPipelinePolicy
    {
        private readonly TokenCredential _credential;

        private readonly string[] _scopes;

        private string _currentToken;

        private string _headerValue;

        public BearerTokenAuthenticationPolicy(TokenCredential credential, string scope) : this(credential, new []{ scope })
        {
        }

        public BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            if (scopes == null)
            {
                throw new ArgumentNullException(nameof(scopes));
            }

            _credential = credential;
            _scopes = scopes.ToArray();
        }

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            string token = async ?
                    await _credential.GetTokenAsync(_scopes, message.Cancellation).ConfigureAwait(false) :
                    _credential.GetToken(_scopes, message.Cancellation);

            if (token != _currentToken)
            {
                // Avoid per request allocations
                _currentToken = token;
                _headerValue = "Bearer " + token;
            }

            message.Request.SetHeader(HttpHeader.Names.Authorization, _headerValue);

            if (async)
            {
                await ProcessNextAsync(pipeline, message);
            }
            else
            {
                ProcessNext(pipeline, message);
            }
        }
    }
}

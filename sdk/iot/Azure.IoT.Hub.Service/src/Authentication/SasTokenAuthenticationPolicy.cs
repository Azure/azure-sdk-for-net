// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.Hub.Service.Authentication
{
    /// <summary>
    /// The shared access signature based HTTP pipeline policy.
    /// This authentication policy injects the sas token into the HTTP authentication header for each HTTP request made.
    /// </summary>
    internal class SasTokenAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly TimeSpan _getTokenTimeout = TimeSpan.FromSeconds(30);
        private readonly TokenCredential _credential;

        internal SasTokenAuthenticationPolicy(TokenCredential credential)
        {
            _credential = credential;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            await AddHeaders(message, async).ConfigureAwait(false);

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }
        }

        private async Task AddHeaders(HttpMessage message, bool async)
        {
            using var cts = new CancellationTokenSource(_getTokenTimeout);

            AccessToken token = async
                ? await _credential.GetTokenAsync(new TokenRequestContext(), cts.Token).ConfigureAwait(false)
                : _credential.GetToken(new TokenRequestContext(), cts.Token);

            message.Request.Headers.Add(HttpHeader.Names.Authorization, token.Token);
        }
    }
}

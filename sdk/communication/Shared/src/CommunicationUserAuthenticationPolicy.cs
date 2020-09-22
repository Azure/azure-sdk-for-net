// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Pipeline
{
    internal class CommunicationUserAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly CommunicationUserCredential _communicationUserCredential;

        public CommunicationUserAuthenticationPolicy(CommunicationUserCredential communicationUserCredential)
        {
            _communicationUserCredential = communicationUserCredential;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            var token = _communicationUserCredential.GetToken(message.CancellationToken);
            AddAuthorizationHeader(message, token);
            ProcessNext(message, pipeline);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            var token = await _communicationUserCredential.GetTokenAsync(message.CancellationToken).ConfigureAwait(false);
            AddAuthorizationHeader(message, token);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        private static void AddAuthorizationHeader(HttpMessage message, AccessToken accessToken)
        {
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, $"Bearer {accessToken.Token}");
        }
    }
}

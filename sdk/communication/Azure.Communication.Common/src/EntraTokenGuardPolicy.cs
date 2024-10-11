// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication
{
    internal class EntraTokenGuardPolicy : HttpPipelinePolicy
    {
        private string _entraTokenCache;
        private Response _responseCache;

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, async: false).EnsureCompleted();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, async: true);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            var currentEntraToken = string.Empty;
            message.Request.Headers.TryGetValue("Authorization", out currentEntraToken);
            if (string.IsNullOrEmpty(_entraTokenCache) || currentEntraToken != _entraTokenCache)
            {
                _entraTokenCache = currentEntraToken;
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(continueOnCapturedContext: false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
                _responseCache = message.Response;
            }
            else
            {
                message.Response = _responseCache;
                return;
            }
        }
    }
}

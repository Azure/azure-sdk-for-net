// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
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
            var (entraTokenCacheValid, token) = IsEntraTokenCacheValid(message);
            if (entraTokenCacheValid && IsAcsTokenCacheValid())
            {
                message.Response = _responseCache;
                return;
            }
            else
            {
                _entraTokenCache = token;
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
        }

        private (bool CacheValid, string EntraToken) IsEntraTokenCacheValid(HttpMessage message)
        {
            var currentEntraToken = string.Empty;
            message.Request.Headers.TryGetValue("Authorization", out currentEntraToken);
            return (!string.IsNullOrEmpty(_entraTokenCache) && currentEntraToken == _entraTokenCache, currentEntraToken);
        }

        private bool IsAcsTokenCacheValid()
        {
            return _responseCache != null && _responseCache.Status == 200 && IsAccessTokenValid();
        }

        private bool IsAccessTokenValid()
        {
            try
            {
                var json = JsonDocument.Parse(_responseCache.Content);
                var expiresOnString = json.RootElement
                                          .GetProperty("accessToken")
                                          .GetProperty("expiresOn")
                                          .GetString();
                var expiresOn = DateTimeOffset.Parse(expiresOnString);
                return DateTimeOffset.UtcNow < expiresOn;
            }
            catch
            {
                return false;
            }
        }
    }
}

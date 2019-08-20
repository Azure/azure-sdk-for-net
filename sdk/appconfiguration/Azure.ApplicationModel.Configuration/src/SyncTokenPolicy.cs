// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.ApplicationModel.Configuration
{
    internal class SyncTokenPolicy : HttpPipelinePolicy
    {
        private ConcurrentDictionary<string, SyncToken> _syncTokens = new ConcurrentDictionary<string, SyncToken>();

        private const string SyncTokenHeader = "Sync-Token";

        public SyncTokenPolicy()
        {
        }

        public override Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, async: true);
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, async: false).GetAwaiter().GetResult();
        }

        private async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            foreach (SyncToken token in _syncTokens.Values)
            {
                message.Request.Headers.Add(SyncTokenHeader, token.ToString());
            }

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            if (message.Response.Headers.TryGetValues(SyncTokenHeader, out IEnumerable<string> rawSyncTokens))
            {
                foreach (string rawToken in rawSyncTokens)
                {
                    if (SyncTokenUtils.TryParse(rawToken, out SyncToken token))
                    {
                        _syncTokens.AddOrUpdate(token.Id, token, (key, existing) =>
                        {
                            if (existing.SequenceNumber < token.SequenceNumber)
                            {
                                return token;
                            }

                            return existing;
                        });
                    }
                }
            }
        }
    }
}

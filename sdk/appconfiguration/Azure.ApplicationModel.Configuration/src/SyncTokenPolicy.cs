// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
//using Azure.Core.Pipeline.TaskExtensions;

namespace Azure.ApplicationModel.Configuration
{
    internal class SyncTokenPolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// Map from token id to token.
        /// </summary>
        private ConcurrentDictionary<string, SyncToken> _syncTokens;

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

            //
            // Use session synchonization tokens
            foreach (SyncToken token in _syncTokens.Values)
            {
                message.Request.Headers.Add("Sync-Token", SyncTokenUtils.Format(token));
            }

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            // TODO: YOU ARE HERE

        }
    }
}

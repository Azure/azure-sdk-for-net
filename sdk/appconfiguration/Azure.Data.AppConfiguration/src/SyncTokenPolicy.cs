// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class SyncTokenPolicy : SynchronousHttpPipelinePolicy
    {
        private const string SyncTokenHeader = "Sync-Token";

        private readonly ConcurrentDictionary<string, SyncToken> _syncTokens;

        public SyncTokenPolicy()
        {
            _syncTokens = new ConcurrentDictionary<string, SyncToken>();
        }

        public override void OnSendingRequest(HttpPipelineMessage message)
        {
            foreach (SyncToken token in _syncTokens.Values)
            {
                message.Request.Headers.Add(SyncTokenHeader, token.ToString());
            }
        }

        public override void OnReceivedResponse(HttpPipelineMessage message)
        {
            if (message.Response.Headers.TryGetValues(SyncTokenHeader, out IEnumerable<string> rawSyncTokens))
            {
                foreach (string fullRawToken in rawSyncTokens)
                {
                    // Handle multiple header values.
                    string[] rawTokens = fullRawToken.Split(',');
                    foreach (string rawToken in rawTokens)
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
}

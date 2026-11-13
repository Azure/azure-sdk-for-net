// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Policy that manages and applies App Configuration sync tokens to requests.
    /// </summary>
    internal class SyncTokenPolicy : HttpPipelineSynchronousPolicy
    {
        private const string SyncTokenHeader = "Sync-Token";

        private readonly ConcurrentDictionary<string, SyncToken> _syncTokens;

        public SyncTokenPolicy()
        {
            _syncTokens = new ConcurrentDictionary<string, SyncToken>();
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Remove(SyncTokenHeader);
            foreach (SyncToken token in _syncTokens.Values)
            {
                message.Request.Headers.Add(SyncTokenHeader, token.ToString());
            }
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
            if (message.Response.Headers.TryGetValues(SyncTokenHeader, out IEnumerable<string> rawSyncTokens))
            {
                foreach (string fullRawToken in rawSyncTokens)
                {
                    AddToken(fullRawToken);
                }
            }
        }

        public void AddToken(string fullRawToken)
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

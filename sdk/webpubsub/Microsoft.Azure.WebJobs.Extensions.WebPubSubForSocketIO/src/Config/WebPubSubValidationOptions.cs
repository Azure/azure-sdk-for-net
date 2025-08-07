// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Validation options when using Web PubSub for Socket.IO.
    /// Used for Abuse Protection and Signature checks.
    /// </summary>
    internal class WebPubSubValidationOptions
    {
        private readonly Dictionary<string, string> _hostKeyMappings = new(StringComparer.OrdinalIgnoreCase);

        public WebPubSubValidationOptions(params SocketIOConnectionInfo[] connectionInfo)
        {
            foreach (var item in connectionInfo)
            {
                if (item == null)
                {
                    continue;
                }
                _hostKeyMappings.Add(item.Endpoint.Host, item.KeyCredential?.Key);
            }
        }

        public WebPubSubValidationOptions(IEnumerable<SocketIOConnectionInfo> connectionInfo)
            : this(connectionInfo.ToArray())
        {
        }

        internal bool ContainsHost()
        {
            return _hostKeyMappings.Count > 0;
        }

        internal bool ContainsHost(string host)
        {
            return _hostKeyMappings.ContainsKey(host);
        }

        internal bool TryGetKey(string host, out string accessKey)
        {
            return _hostKeyMappings.TryGetValue(host, out accessKey);
        }

        internal List<string> GetAllowedHosts()
        {
            return _hostKeyMappings.Select(x => x.Key).ToList();
        }
    }
}

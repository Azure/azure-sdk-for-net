// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// For local tracking the lifetime of sockets.
    /// </summary>
    internal class SocketLifetimeStore
    {
        private readonly ConcurrentDictionary<string, (string, string)> _store = new();

        public bool TryFindConnectionIdBySocketId(string socketId, out string connectionId, out string @namespace)
        {
            var rst = _store.TryGetValue(socketId, out var val);
            connectionId = val.Item1;
            @namespace = val.Item2;
            return rst;
        }

        public void AddSocket(string socketId, string @namespace, string connectionId)
        {
            _store.AddOrUpdate(socketId, (connectionId, @namespace), (key, oldValue) => (connectionId, @namespace));
        }

        public bool RemoveSocket(string socketId)
        {
            return _store.TryRemove(socketId, out _);
        }
    }
}

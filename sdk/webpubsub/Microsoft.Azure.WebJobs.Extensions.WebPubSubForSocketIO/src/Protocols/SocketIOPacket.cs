// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class SocketIOPacket
    {
        public SocketIOPacketType Type { get; set; }
        public string Namespace { get; set; }
        public string Data { get; set; }
        public int? Id { get; set; }

        public SocketIOPacket(SocketIOPacketType type, string @namespace, string data)
        {
            Type = type;
            Namespace = @namespace;
            Data = data;
        }
    }

    internal enum SocketIOPacketType
    {
        Connect = 0,
        Disconnect = 1,
        Event = 2,
        Ack = 3,
        ConnectError = 4,
        BinaryEvent = 5,
        BinaryAck = 6
    }
}

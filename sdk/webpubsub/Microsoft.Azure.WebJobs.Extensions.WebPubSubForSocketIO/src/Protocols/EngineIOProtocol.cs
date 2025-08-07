// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class EngineIOProtocol
    {
        public static ReadOnlyMemory<byte> EncodePacket(SocketIOPacket packet)
        {
            return Encoding.UTF8.GetBytes(EncodePacketToString(packet));
        }

        public static string EncodePacketToString(SocketIOPacket packet)
        {
            return $"4{SocketIOProtocol.EncodePacket(packet)}";
        }

        public static SocketIOPacket DecodePacket(string payload)
        {
            var type = payload[0];
            if (type == 'b')
            {
                throw new InvalidDataException("Binary data is not support.");
            }

            return SocketIOProtocol.DecodePacket(payload.Substring(1));
        }
    }
}

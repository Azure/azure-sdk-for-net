// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Linq;
using System.Text;
using Azure.Messaging.WebPubSub.Clients;

namespace Azure.Messaging.WebPubSub.Client.Protobuf
{
    /// <summary>
    /// The protobuf.reliable.webpubsub.azure.v1
    /// </summary>
    public class WebPubSubProtobufReliableProtocol : WebPubSubProtocol
    {
        /// <summary>
        /// Gets the name of the protocol. The name is used by Web PubSub client to resolve the protocol between the client and server.
        /// </summary>
        public override string Name => "protobuf.reliable.webpubsub.azure.v1";

        /// <summary>
        /// Get the message type to be used in websocket bytes
        /// </summary>
        public override WebPubSubProtocolMessageType WebSocketMessageType => WebPubSubProtocolMessageType.Binary;

        /// <summary>
        /// Get whether the protocol using a reliable subprotocol.
        /// </summary>
        public override bool IsReliable => true;

        /// <inheritdoc/>
        public override ReadOnlyMemory<byte> GetMessageBytes(WebPubSubMessage message)
        {
            return WebPubSubProtobufProtocolHelper.GetMessageBytes(message);
        }

        /// <inheritdoc/>
        public override WebPubSubMessage ParseMessage(ReadOnlySequence<byte> input)
        {
            return WebPubSubProtobufProtocolHelper.ParseMessage(input);
        }

        /// <inheritdoc/>
        public override void WriteMessage(WebPubSubMessage message, IBufferWriter<byte> output)
        {
            WebPubSubProtobufProtocolHelper.WriteMessage(message, output);
        }
    }
}

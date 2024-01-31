// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The protocol to represent "json.webpubsub.azure.v1"
    /// </summary>
    public class WebPubSubJsonProtocol : WebPubSubProtocol
    {
        private readonly WebPubSubJsonProtocolBase _processor = new WebPubSubJsonProtocolBase();

        /// <summary>
        /// Gets the name of the protocol. The name is used by Web PubSub client to resolve the protocol between the client and server.
        /// </summary>
        public override string Name => "json.webpubsub.azure.v1";

        /// <summary>
        /// Get whether the protocol using a reliable subprotocol.
        /// </summary>
        public override bool IsReliable => false;

        /// <summary>
        /// Get the message type to be used in websocket bytes
        /// </summary>
        public override WebPubSubProtocolMessageType WebSocketMessageType => WebPubSubProtocolMessageType.Text;

        /// <summary>
        /// Converts the specified <see cref="WebPubSubMessage"/> to its serialized representation.
        /// </summary>
        /// <param name="message">The message to convert.</param>
        /// <returns>The serialized representation of the message.</returns>
        public override ReadOnlyMemory<byte> GetMessageBytes(WebPubSubMessage message)
        {
            return _processor.GetMessageBytes(message);
        }

        /// <summary>
        /// Creates a new <see cref="WebPubSubMessage"/> from the specified serialized representation。
        /// </summary>
        /// <param name="input">The serialized representation of the message.</param>
        /// <returns>A <see cref="WebPubSubMessage"/></returns>
        public override IReadOnlyList<WebPubSubMessage> ParseMessage(ReadOnlySequence<byte> input)
        {
            return _processor.ParseMessage(input);
        }

        /// <summary>
        /// Writes the specified <see cref="WebPubSubMessage"/> to a writer.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="output">The output writer.</param>
        public override void WriteMessage(WebPubSubMessage message, IBufferWriter<byte> output)
        {
            _processor.WriteMessage(message, output);
        }
    }
}

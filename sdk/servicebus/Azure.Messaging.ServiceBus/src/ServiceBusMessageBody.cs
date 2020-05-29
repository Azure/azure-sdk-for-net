// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceBusMessageBody
    {
        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        /// <remarks>
        /// The easiest way to create a new message from a string is the following:
        /// <code>
        /// message.Body = System.Text.Encoding.UTF8.GetBytes("Message1");
        /// </code>
        /// </remarks>
        internal ReadOnlyMemory<byte> Body { get; set; }

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        /// <param name="body">The payload of the message in bytes.</param>
        internal ServiceBusMessageBody(ReadOnlyMemory<byte> body)
        {
            Body = body;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ReadOnlyMemory<byte> AsBytes() =>
            Body;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string AsString() =>
            AsString(Encoding.UTF8);

        /// <summary>
        ///
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string AsString(Encoding encoding)
        {
            if (MemoryMarshal.TryGetArray<byte>(Body, out ArraySegment<byte> segment))
            {
                return encoding.GetString(segment.Array);
            }
            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="body"></param>
        public static implicit operator string(ServiceBusMessageBody body) => body.AsString();

        /// <summary>
        ///
        /// </summary>
        /// <param name="body"></param>
        public static implicit operator ReadOnlyMemory<byte>(ServiceBusMessageBody body) => body.AsBytes();

    }
}

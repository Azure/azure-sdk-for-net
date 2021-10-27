// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    /// <summary>
    /// A protocol abstraction for communicating with Azure SignalR Service in serverless scenarios.
    /// </summary>
    public interface IServerlessProtocol
    {
        // TODO: Have a discussion about how to handle version change.
        /// <summary>
        /// Gets the version of the protocol.
        /// </summary>
        int Version { get; }

        /// <summary>
        /// Creates a new <see cref="ServerlessMessage"/> from the specified serialized representation.
        /// </summary>
        /// <param name="input">The serialized representation of the message.</param>
        /// <param name="message">When this method returns <c>true</c>, contains the parsed message.</param>
        /// <returns>A value that is <c>true</c> if the <see cref="ServerlessMessage"/> was successfully parsed; otherwise, <c>false</c>.</returns>
        bool TryParseMessage(ref ReadOnlySequence<byte> input, out ServerlessMessage message);
    }
}
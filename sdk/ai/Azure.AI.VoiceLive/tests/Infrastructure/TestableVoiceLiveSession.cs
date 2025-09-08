// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.WebSockets;
using Azure.Core;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// A lightweight testable subclass that exposes the protected constructor and allows
    /// injecting a <see cref="FakeWebSocket"/> without modifying production code.
    /// This class is shared across all VoiceLive unit tests to provide consistent testing infrastructure.
    /// </summary>
    internal sealed class TestableVoiceLiveSession : VoiceLiveSession
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestableVoiceLiveSession"/> class for testing purposes.
        /// </summary>
        /// <param name="client">The VoiceLive client instance.</param>
        /// <param name="endpoint">The WebSocket endpoint URI.</param>
        /// <param name="credential">The authentication credential.</param>
        public TestableVoiceLiveSession(VoiceLiveClient client, Uri endpoint, AzureKeyCredential credential)
            : base(client, endpoint, credential)
        {
        }

        /// <summary>
        /// Sets the WebSocket instance for testing. This allows injection of a <see cref="FakeWebSocket"/>
        /// to capture sent messages and simulate received messages.
        /// </summary>
        /// <param name="socket">The WebSocket instance to inject.</param>
        public void SetWebSocket(WebSocket socket) => WebSocket = socket;
    }
}
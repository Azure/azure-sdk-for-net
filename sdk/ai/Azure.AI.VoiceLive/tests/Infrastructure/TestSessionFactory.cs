// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Factory methods for creating test sessions with injected <see cref="FakeWebSocket"/> instances.
    /// Provides consistent test setup patterns across all VoiceLive unit tests.
    /// </summary>
    internal static class TestSessionFactory
    {
        /// <summary>
        /// Creates a <see cref="TestableVoiceLiveSession"/> with an injected <see cref="FakeWebSocket"/>
        /// for testing purposes. The session is configured with test URIs and credentials.
        /// </summary>
        /// <param name="fakeSocket">Outputs the injected <see cref="FakeWebSocket"/> instance for test assertions.</param>
        /// <returns>A configured <see cref="TestableVoiceLiveSession"/> ready for testing.</returns>
        internal static TestableVoiceLiveSession CreateSessionWithFakeSocket(out FakeWebSocket fakeSocket)
        {
            var client = new VoiceLiveClient(new Uri("https://example.org"), new AzureKeyCredential("test-key"));
            var session = new TestableVoiceLiveSession(client, new AzureKeyCredential("test-key"));
            fakeSocket = new FakeWebSocket();
            session.SetWebSocket(fakeSocket);
            return session;
        }

        /// <summary>
        /// Creates a <see cref="TestableVoiceLiveSession"/> with an injected <see cref="FakeWebSocket"/>
        /// for testing purposes. This overload uses a shorter method name for compatibility with existing tests.
        /// </summary>
        /// <param name="socket">Outputs the injected <see cref="FakeWebSocket"/> instance for test assertions.</param>
        /// <returns>A configured <see cref="TestableVoiceLiveSession"/> ready for testing.</returns>
        internal static TestableVoiceLiveSession CreateSession(out FakeWebSocket socket)
        {
            return CreateSessionWithFakeSocket(out socket);
        }
    }
}

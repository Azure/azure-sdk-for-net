// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Unit tests covering disposal and lifecycle behaviors of <see cref="VoiceLiveSession"/>.
    /// These tests validate that API calls after disposal throw the expected <see cref="ObjectDisposedException"/>,
    /// multiple disposal calls are safe (idempotent), and internal audio streaming state is correctly reset
    /// once a streaming send completes allowing subsequent audio sends.
    /// </summary>
    [TestFixture]
    public class VoiceLiveSessionDisposalTests
    {
        /// <summary>
        /// A lightweight testable subclass that exposes the protected constructor and allows
        /// injecting a <see cref="FakeWebSocket"/> without modifying production code.
        /// </summary>
        private sealed class TestableVoiceLiveSession : VoiceLiveSession
        {
            public TestableVoiceLiveSession(VoiceLiveClient parentClient, Uri endpoint, AzureKeyCredential credential)
                : base(parentClient, endpoint, credential)
            {
            }

            public void SetWebSocket(System.Net.WebSockets.WebSocket socket) => WebSocket = socket;
        }

        private static TestableVoiceLiveSession CreateSessionWithFakeSocket(out FakeWebSocket fakeSocket)
        {
            var client = new VoiceLiveClient(new Uri("https://example.org"), new AzureKeyCredential("test-key"));
            var session = new TestableVoiceLiveSession(client, new Uri("wss://example.org/voice-agent/realtime"), new AzureKeyCredential("test-key"));
            fakeSocket = new FakeWebSocket();
            session.SetWebSocket(fakeSocket); // Inject capture socket.
            return session;
        }

        private static int CountMessagesOfType(FakeWebSocket socket, string type)
        {
            return socket.GetSentTextMessages().Count(m =>
            {
                if (string.IsNullOrWhiteSpace(m))
                    return false;
                try
                {
                    using var doc = JsonDocument.Parse(m);
                    return doc.RootElement.TryGetProperty("type", out var tProp) && tProp.ValueKind == JsonValueKind.String && string.Equals(tProp.GetString(), type, StringComparison.OrdinalIgnoreCase);
                }
                catch (JsonException)
                {
                    return false;
                }
            });
        }

        [Test]
        public void MethodsAfterDispose_ThrowObjectDisposedException()
        {
            var session = CreateSessionWithFakeSocket(out _);
            session.Dispose();

            // SendInputAudioAsync(byte[]) should throw
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await session.SendInputAudioAsync(new byte[] { 0x01 }));

            // ConfigureConversationSessionAsync should throw
            var convoOptions = new VoiceLiveSessionOptions { Model = TestConstants.ModelName };
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await session.ConfigureConversationSessionAsync(convoOptions));
        }

        [Test]
        public void Dispose_MultipleCalls_NoThrow()
        {
            var session = CreateSessionWithFakeSocket(out _);

            Assert.DoesNotThrow(() => session.Dispose());
            Assert.DoesNotThrow(() => session.Dispose()); // Second call should be idempotent.

            // Also ensure async dispose after sync dispose is safe.
            Assert.DoesNotThrowAsync(async () => await session.DisposeAsync());
        }

        [Test]
        public async Task AudioStreamLockReleasedAfterStreamSendCompletes()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            // 1. Perform a streaming audio send (MemoryStream triggers stream-based overload)
            byte[] largeAudio = new byte[10 * 1024];
            new Random(0).NextBytes(largeAudio);
            using var ms = new MemoryStream(largeAudio);
            await session.SendInputAudioAsync(ms); // Should complete successfully.

            int appendCountAfterStream = CountMessagesOfType(fake, "input_audio_buffer.append");
            Assert.That(appendCountAfterStream, Is.GreaterThanOrEqualTo(1), "Expected at least one append message from streaming send.");

            // 2. Immediately send a small standalone chunk. This should succeed (no InvalidOperationException) indicating lock/state released.
            byte[] smallChunk = new byte[] { 0x05, 0x06, 0x07 };
            await session.SendInputAudioAsync(smallChunk);

            int appendCountFinal = CountMessagesOfType(fake, "input_audio_buffer.append");
            Assert.That(appendCountFinal, Is.EqualTo(appendCountAfterStream + 1), "Expected exactly one additional append message after standalone send.");
        }
    }
}

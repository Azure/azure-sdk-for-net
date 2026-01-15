// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Unit tests covering audio transmission APIs and audio turn management commands for <see cref="VoiceLiveSession"/>.
    /// These tests validate that the correct JSON command payloads (type properties and associated fields) are emitted
    /// over the injected <see cref="FakeWebSocket"/> without performing any live network operations.
    /// </summary>
    [TestFixture]
    public class VoiceLiveSessionAudioTests
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
            session.SetWebSocket(fakeSocket);
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
                    return doc.RootElement.TryGetProperty("type", out var tProp) &&
                           tProp.ValueKind == JsonValueKind.String &&
                           string.Equals(tProp.GetString(), type, StringComparison.OrdinalIgnoreCase);
                }
                catch (JsonException)
                {
                    return false;
                }
            });
        }

        private static JsonDocument? GetLastJsonMessage(FakeWebSocket socket)
        {
            foreach (var msg in socket.GetSentTextMessages().Reverse())
            {
                if (string.IsNullOrWhiteSpace(msg))
                    continue;
                try
                {
                    return JsonDocument.Parse(msg);
                }
                catch (JsonException)
                {
                    continue;
                }
            }
            return null;
        }

        [Test]
        public async Task SendInputAudioAsync_EncodesBase64AndWrapsAppendEvent()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            byte[] data = new byte[] { 0x01, 0x02, 0x03 }; // Known deterministic bytes -> AQID
            await session.SendInputAudioAsync(data);

            using var last = GetLastJsonMessage(fake);
            Assert.That(last, Is.Not.Null, "Expected a JSON command to have been sent.");
            var root = last!.RootElement;
            Assert.That(root.TryGetProperty("type", out var typeProp), Is.True, "type property missing");
            Assert.That(typeProp.GetString(), Is.EqualTo("input_audio_buffer.append"));
            Assert.That(root.TryGetProperty("audio", out var audioProp), Is.True, "audio property missing");
            Assert.That(audioProp.GetString(), Is.EqualTo("AQID"), "Base64 encoding mismatch");
        }

        [Test]
        public async Task SendInputAudioAsync_Stream_SendsMultipleAppendEvents()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            // Deterministic random bytes > 16K so that streaming uses multiple frames.
            byte[] data = new byte[40 * 1024];
            new Random(0).NextBytes(data);
            using var ms = new MemoryStream(data);

            await session.SendInputAudioAsync(ms);

            int appendCount = CountMessagesOfType(fake, "input_audio_buffer.append");
            Assert.That(appendCount, Is.GreaterThanOrEqualTo(3), "Expected at least three append messages for a 40KB stream.");
        }

        /// <summary>
        /// A blocking stream used to simulate a long running SendInputAudioAsync(stream) call so a second audio send
        /// attempt can be made concurrently to trigger the InvalidOperationException logic.
        /// </summary>
        private sealed class BlockingTestStream : Stream
        {
            private readonly byte[] _firstChunk;
            private bool _firstReturned;
            private readonly ManualResetEventSlim _continueEvent;
            private readonly ManualResetEventSlim _firstChunkReadEvent;

            public BlockingTestStream(byte[] firstChunk, ManualResetEventSlim firstChunkReadEvent, ManualResetEventSlim continueEvent)
            {
                _firstChunk = firstChunk ?? throw new ArgumentNullException(nameof(firstChunk));
                _firstChunkReadEvent = firstChunkReadEvent ?? throw new ArgumentNullException(nameof(firstChunkReadEvent));
                _continueEvent = continueEvent ?? throw new ArgumentNullException(nameof(continueEvent));
            }

            public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
            public override void Flush() { }
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => _firstChunk.Length;
            public override long Position { get => 0; set => throw new NotSupportedException(); }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                if (!_firstReturned)
                {
                    _firstReturned = true;
                    Array.Copy(_firstChunk, 0, buffer, offset, _firstChunk.Length);
                    _firstChunkReadEvent.Set();
                    return _firstChunk.Length;
                }

                // Block until released then indicate end of stream.
                await Task.Run(() => { _continueEvent.Wait(cancellationToken); });
                return 0;
            }
        }

        [Test]
        [Retry(3)] // Provide resilience in case of rare timing issues.
        public async Task SendInputAudioAsync_WhileStreaming_ThrowsInvalidOperation()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            var firstChunkRead = new ManualResetEventSlim(false);
            var releaseStream = new ManualResetEventSlim(false);
            var blockingStream = new BlockingTestStream(new byte[100], firstChunkRead, releaseStream);

            Task streamSendTask = session.SendInputAudioAsync(blockingStream);

            // Wait for first chunk to be processed (so _isSendingAudioStream == true)
            Assert.That(firstChunkRead.Wait(TimeSpan.FromSeconds(5)), Is.True, "Timed out waiting for first chunk to be read.");

            // Attempt second send (byte[] variant) which should fail while streaming active.
            byte[] secondData = new byte[] { 0x01 };
            Assert.ThrowsAsync<InvalidOperationException>(async () => await session.SendInputAudioAsync(secondData));

            // Allow the streaming operation to finish.
            releaseStream.Set();
            await streamSendTask.ConfigureAwait(false);

            // Sanity: at least one append from the streaming plus none from failed second send.
            int appendCount = CountMessagesOfType(fake, "input_audio_buffer.append");
            Assert.That(appendCount, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task ClearInputAudioAsync_SendsBufferClear()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.ClearInputAudioAsync();
            Assert.That(CountMessagesOfType(fake, "input_audio_buffer.clear"), Is.EqualTo(1));
        }

        [Test]
        public async Task CommitInputAudioAsync_SendsCommit()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.CommitInputAudioAsync();
            Assert.That(CountMessagesOfType(fake, "input_audio_buffer.commit"), Is.EqualTo(1));
        }

        [Test]
        public async Task ClearStreamingAudioAsync_SendsStreamingClear()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.ClearStreamingAudioAsync();
            Assert.That(CountMessagesOfType(fake, "input_audio.clear"), Is.EqualTo(1));
        }

        [Test]
        public async Task StartAppendEndAudioTurn_SendsExpectedSequence()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            string turnId = "turn1";
            byte[] audio = new byte[] { 0x05, 0x06 };

            await session.StartAudioTurnAsync(turnId);
            await session.AppendAudioToTurnAsync(turnId, audio);
            await session.EndAudioTurnAsync(turnId);

            var sent = fake.GetSentTextMessages();
            var turnEvents = new List<string>();
            foreach (var msg in sent)
            {
                if (string.IsNullOrWhiteSpace(msg))
                    continue;
                try
                {
                    using var doc = JsonDocument.Parse(msg);
                    if (doc.RootElement.TryGetProperty("type", out var tProp) && tProp.ValueKind == JsonValueKind.String)
                    {
                        var tVal = tProp.GetString();
                        if (tVal == "input_audio.turn.start" || tVal == "input_audio.turn.append" || tVal == "input_audio.turn.end")
                        {
                            turnEvents.Add(tVal);
                        }
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }
            }

            CollectionAssert.AreEqual(new[] { "input_audio.turn.start", "input_audio.turn.append", "input_audio.turn.end" }, turnEvents, "Unexpected turn event sequence");
        }

        [Test]
        public async Task CancelAudioTurnAsync_SendsTurnCancel()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            await session.CancelAudioTurnAsync("turn123");
            Assert.That(CountMessagesOfType(fake, "input_audio.turn.cancel"), Is.EqualTo(1));
        }

        [Test]
        public void AppendAudioToTurnAsync_EmptyTurnId_Throws()
        {
            var session = CreateSessionWithFakeSocket(out _);
            Assert.ThrowsAsync<ArgumentException>(async () => await session.AppendAudioToTurnAsync(string.Empty, new byte[] { 0x01 }));
        }

        [Test]
        public void StartAudioTurnAsync_NullOrEmpty_Throws()
        {
            var session = CreateSessionWithFakeSocket(out _);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.StartAudioTurnAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await session.StartAudioTurnAsync(string.Empty));
        }
    }
}

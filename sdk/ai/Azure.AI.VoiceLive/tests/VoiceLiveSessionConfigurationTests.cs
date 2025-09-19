// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Unit tests for configuring a <see cref="VoiceLiveSession"/> using the conversation session helpers.
    /// </summary>
    [TestFixture]
    public class VoiceLiveSessionConfigurationTests
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
            session.SetWebSocket(fakeSocket); // Inject our capture socket.
            return session;
        }

        private static List<JsonDocument> GetSentMessagesOfType(FakeWebSocket socket, string type)
        {
            var docs = new List<JsonDocument>();
            foreach (var msg in socket.GetSentTextMessages())
            {
                if (string.IsNullOrWhiteSpace(msg))
                    continue;
                try
                {
                    var doc = JsonDocument.Parse(msg);
                    if (doc.RootElement.TryGetProperty("type", out var tProp) && tProp.ValueKind == JsonValueKind.String && string.Equals(tProp.GetString(), type, StringComparison.OrdinalIgnoreCase))
                    {
                        docs.Add(doc);
                    }
                    else
                    {
                        doc.Dispose();
                    }
                }
                catch (JsonException)
                {
                    // Ignore non-JSON frames for these tests.
                }
            }
            return docs;
        }

        [Test]
        public async Task ConfigureConversationSession_SetsModalitiesAndVoice()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            var options = new VoiceLiveSessionOptions
            {
                Voice = new AzureStandardVoice(TestConstants.VoiceName),
                Model = TestConstants.ModelName,
                Instructions = "You are a helpful assistant.",
                TurnDetection = new ServerVad { Threshold = 0.5f, SilenceDurationMs = 500 },
                InputAudioFormat = InputAudioFormat.Pcm16,
                OutputAudioFormat = OutputAudioFormat.Pcm16
            };
            // Ensure we control modalities explicitly (clear defaults then add back only text & audio)
            options.Modalities.Clear();
            options.Modalities.Add(InputModality.Text);
            options.Modalities.Add(InputModality.Audio);

            await session.ConfigureSessionAsync(options);

            var updateMessages = GetSentMessagesOfType(fake, "session.update");
            Assert.That(updateMessages, Is.Not.Empty, "Expected at least one session.update message to be sent.");

            // Inspect the latest update for assertions (most specific state)
            using var doc = updateMessages.Last();
            var root = doc.RootElement;
            Assert.That(root.TryGetProperty("session", out var sessionElement), Is.True, "session object missing in payload");

            // Modalities assertion
            Assert.That(sessionElement.TryGetProperty("modalities", out var modalitiesElement), Is.True, "modalities missing");
            var modalities = modalitiesElement.EnumerateArray().Select(e => e.GetString()).Where(s => s != null).ToArray();
            Assert.That(modalities, Is.EquivalentTo(new[] { "text", "audio" }), "Modalities did not match expected set");

            // Voice assertion
            Assert.That(sessionElement.TryGetProperty("voice", out var voiceElement), Is.True, "voice object missing");
            Assert.That(voiceElement.TryGetProperty("name", out var voiceNameProp), Is.True, "voice.name missing");
            Assert.That(voiceNameProp.GetString(), Is.EqualTo(TestConstants.VoiceName));

            // Turn detection assertion (type should be server_vad)
            Assert.That(sessionElement.TryGetProperty("turn_detection", out var tdElement), Is.True, "turn_detection missing");
            Assert.That(tdElement.TryGetProperty("type", out var tdTypeProp), Is.True, "turn_detection.type missing");
            Assert.That(tdTypeProp.GetString(), Is.EqualTo("server_vad"));
        }

        [Test]
        public async Task ConfigureConversationSession_IncludesTools()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            var options = new VoiceLiveSessionOptions
            {
                Model = TestConstants.ModelName,
                Voice = new AzureStandardVoice(TestConstants.VoiceName)
            };

            options.Tools.Add(new VoiceLiveFunctionDefinition("get_weather") { Description = "Gets the weather." });
            options.Tools.Add(new VoiceLiveFunctionDefinition("book_flight") { Description = "Books a flight." });

            await session.ConfigureSessionAsync(options);

            var updateMessages = GetSentMessagesOfType(fake, "session.update");
            Assert.That(updateMessages, Is.Not.Empty, "Expected session.update message.");
            using var doc = updateMessages.Last();
            var sessionEl = doc.RootElement.GetProperty("session");
            Assert.That(sessionEl.TryGetProperty("tools", out var toolsEl), Is.True, "tools array missing");
            var tools = toolsEl.EnumerateArray().ToArray();
            Assert.That(tools.Length, Is.EqualTo(2), "Unexpected number of tools serialized");
            var names = tools.Select(t => t.GetProperty("name").GetString()).ToArray();
            Assert.That(names, Is.EquivalentTo(new[] { "get_weather", "book_flight" }));
        }

        [Test]
        public void ConfigureConversationSession_NullOptions_Throws()
        {
            var session = CreateSessionWithFakeSocket(out _);
            Assert.ThrowsAsync<ArgumentNullException>(async () => await session.ConfigureSessionAsync(null));
        }

        [Test]
        public async Task MultipleConfigureCalls_SendsMultipleUpdateMessages()
        {
            var session = CreateSessionWithFakeSocket(out var fake);

            var options1 = new VoiceLiveSessionOptions { Model = TestConstants.ModelName };
            options1.Modalities.Clear();
            options1.Modalities.Add(InputModality.Text);

            var options2 = new VoiceLiveSessionOptions { Model = TestConstants.ModelName };
            options2.Modalities.Clear();
            options2.Modalities.Add(InputModality.Audio);

            await session.ConfigureSessionAsync(options1);
            await session.ConfigureSessionAsync(options2);

            var updateMessages = GetSentMessagesOfType(fake, "session.update");
            Assert.That(updateMessages.Count, Is.GreaterThanOrEqualTo(2), "Expected two session.update messages after two configuration calls.");

            // Dispose docs not used further
            foreach (var d in updateMessages)
                d.Dispose();
        }

        [Ignore("WIP")]
        [Test]
        public void VoiceSetGetTest()
        {
            var voice = new AzureStandardVoice("en-US-JennyNeural");

            var sessionOpts = new VoiceLiveSessionOptions
            {
                Model = TestConstants.ModelName,
                Voice = voice
            };

            Assert.That(sessionOpts.Voice, Is.Not.Null);
            Assert.That(sessionOpts.Voice, Is.TypeOf<AzureStandardVoice>());
            var retrievedVoice = (AzureStandardVoice)sessionOpts.Voice;
            Assert.That(retrievedVoice.Name, Is.EqualTo("en-US-JennyNeural"));
        }

        [Test]
        public void MaxTokensSetGetTest()
        {
            var sessionOpts = new VoiceLiveSessionOptions
            {
                Model = TestConstants.ModelName,
                MaxResponseOutputTokens = 4
            };

            Assert.AreEqual(4, sessionOpts.MaxResponseOutputTokens.NumericValue);

            var sessionOpts2 = new VoiceLiveSessionOptions
            {
                Model = TestConstants.ModelName,
                MaxResponseOutputTokens = ResponseMaxOutputTokensOption.CreateInfiniteMaxTokensOption()
            };

            Assert.IsNull(sessionOpts2.MaxResponseOutputTokens.NumericValue);
        }

        [Test]
        public void ToolChoiceSetGet()
        {
            var sessionOpts = new VoiceLiveSessionOptions
            {
                Model = TestConstants.ModelName,
                ToolChoice = "my_tool"
            };

            Assert.AreEqual("my_tool", sessionOpts.ToolChoice.FunctionName);

            var sessionOpts2 = new VoiceLiveSessionOptions
            {
                Model = TestConstants.ModelName,
                ToolChoice = ToolChoiceLiteral.None
            };

            Assert.IsNull(sessionOpts2.ToolChoice.FunctionName);
        }
    }
}

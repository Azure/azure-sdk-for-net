// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Tests.Samples;
using Azure.AI.Projects.Tests.Utils;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests;

public class ProjectsLiveConversationTests : ProjectsClientTestBase
{
    public ProjectsLiveConversationTests(bool isAsync) : base(isAsync)
    {
        TestTimeoutInSeconds = 180;
        JsonPathSanitizers.Add("$..principal_id");
        JsonPathSanitizers.Add("$..client_id");
        JsonPathSanitizers.Add("$..agent_guid");
        JsonPathSanitizers.Add("$..blueprint_id");
    }

    [RecordedTest]
    public async Task StoredConversationLifecycle()
    {
        AIProjectClient project = CreateRecordedProject();
        AgentAdministrationClient agents = CreateProxyFromClient(project.AgentAdministrationClient);
        string name = Recording.GenerateId("live-rest-recording-", 40);
        await agents.CreateAgentVersionAsync(name, new ProjectsAgentVersionCreationOptions(CreateDefinition()));
        try
        {
            string conversationId = await CreateStoredConversationAsync(project, name);
            BetaVoiceAgentsLiveConversations history = CreateProxyFromClient(agents.GetBetaVoiceAgentEndpointLiveConversations());

            List<VoiceAgentLiveConversation> conversations = await history.GetLiveAgentConversationsAsync(name, limit: 1).ToListAsync();
            Assert.That(conversations.Select(value => value.Id), Does.Contain(conversationId));

            ClientResult<VoiceAgentLiveConversation> conversation = await WaitForConversationAsync(history, name, conversationId);
            Assert.That(conversation.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(conversation.Value.Id, Is.EqualTo(conversationId));
            Assert.That(conversation.Value.Status, Is.EqualTo(VoiceConversationStatus.Completed));

            List<VoiceAgentLiveConversationItem> items = await history.GetLiveAgentConversationItemsAsync(
                name, conversationId, limit: 1).ToListAsync();
            VoiceAgentLiveConversationItem speech = items.First(IsSpeech);
            ClientResult<VoiceAgentLiveConversationItem> item = await history.GetLiveAgentConversationItemAsync(
                name, conversationId, speech.Id);
            Assert.That(item.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(item.Value.Id, Is.EqualTo(speech.Id));
            Assert.That(item.Value, Is.TypeOf(speech.GetType()));

            ClientResult deleted = await history.DeleteLiveAgentConversationAsync(name, conversationId);
            Assert.That(deleted.GetRawResponse().Status, Is.EqualTo(204));
            ClientResultException missing = Assert.ThrowsAsync<ClientResultException>(() =>
                history.GetLiveAgentConversationAsync(name, conversationId));
            Assert.That(missing.Status, Is.EqualTo(404));
        }
        finally
        {
            await agents.DeleteAgentAsync(name);
        }
    }

    [RecordedTest]
    public async Task StoredConversationAudio()
    {
        AIProjectClient project = CreateRecordedProject();
        AgentAdministrationClient agents = CreateProxyFromClient(project.AgentAdministrationClient);
        string name = Recording.GenerateId("live-audio-recording-", 40);
        await agents.CreateAgentVersionAsync(name, new ProjectsAgentVersionCreationOptions(CreateDefinition()));
        try
        {
            string conversationId = await CreateStoredConversationAsync(project, name);
            BetaVoiceAgentsLiveConversations history = CreateProxyFromClient(agents.GetBetaVoiceAgentEndpointLiveConversations());
            Assert.That((await WaitForConversationAsync(history, name, conversationId)).Value.Status,
                Is.EqualTo(VoiceConversationStatus.Completed));
            List<VoiceAgentLiveConversationItem> items = await history.GetLiveAgentConversationItemsAsync(
                name, conversationId, limit: 1).ToListAsync();
            string itemId = items.First(IsSpeech).Id;

            ClientResult<VoiceAudioItem> segment = await history.GetLiveAgentConversationAudioItemAsync(name, conversationId, itemId);
            Assert.Multiple(() =>
            {
                Assert.That(segment.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(segment.Value.ConversationId, Is.EqualTo(conversationId));
                Assert.That(segment.Value.ItemId, Is.EqualTo(itemId));
                Assert.That(segment.Value.SampleRate, Is.EqualTo(24000));
                Assert.That(segment.Value.Channels, Is.EqualTo(1));
            });
            ClientResult<BinaryData> segmentAudio = await history.GetLiveAgentConversationAudioItemContentAsync(name, conversationId, itemId);
            Assert.That(segmentAudio.GetRawResponse().Status, Is.EqualTo(200));
            AssertPcmWave(segmentAudio.Value, channels: 1);

            ClientResult<VoiceRecording> recording = await history.GetLiveAgentConversationAudioAsync(name, conversationId);
            Assert.Multiple(() =>
            {
                Assert.That(recording.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(recording.Value.ConversationId, Is.EqualTo(conversationId));
                Assert.That(recording.Value.SampleRate, Is.EqualTo(24000));
                Assert.That(recording.Value.Channels, Is.EqualTo(2));
                Assert.That(recording.Value.DurationMs, Is.GreaterThan(TimeSpan.Zero));
            });
            ClientResult<BinaryData> recordingAudio = await history.GetLiveAgentConversationAudioContentAsync(name, conversationId);
            Assert.That(recordingAudio.GetRawResponse().Status, Is.EqualTo(200));
            AssertPcmWave(recordingAudio.Value, channels: 2);
            Assert.That((await history.DeleteLiveAgentConversationAsync(name, conversationId)).GetRawResponse().Status, Is.EqualTo(204));
        }
        finally
        {
            await agents.DeleteAgentAsync(name);
        }
    }

    private AIProjectClient CreateRecordedProject()
    {
        AIProjectClientOptions options = new();
        if (Mode == RecordedTestMode.Playback)
        {
            options.AddPolicy(new TestPipelinePolicy(message =>
                message.Request.Headers.Set("Authorization", SanitizeValue)), PipelinePosition.PerCall);
        }
        return new(new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT), GetTestTokenProvider(), InstrumentClientOptions(options));
    }

    private VoiceAgentLiveDefinition CreateDefinition()
    {
        string model = Recording.GetVariable("LiveModel", Environment.GetEnvironmentVariable("FOUNDRY_LIVE_MODEL_NAME"));
        Assert.That(model, Is.Not.Null.And.Not.Empty, "Set FOUNDRY_LIVE_MODEL_NAME when recording.");
        return new(model)
        {
            Store = true,
            Instructions = "Answer briefly in English. This demonstration cannot look up current weather.",
            Audio = new LiveInitialSessionAudioParam
            {
                Format = new LiveSessionAudioFormatPCMParam(LiveSessionAudioFormatPCMParamRate._24000)
            }
        };
    }

    private async Task<string> CreateStoredConversationAsync(AIProjectClient project, string name)
    {
        string conversationId = null;
        // The proxy records HTTP only. Playback reuses the ID from this real speech session.
        if (Mode != RecordedTestMode.Playback)
        {
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                name, new ProjectsLiveSessionClientOptions { Store = true }, timeout.Token);
            conversationId = session.SessionStarted.ConversationId;
            using Stream speechFile = File.OpenRead(Path.Combine(
                Microsoft.ClientModel.TestFramework.TestEnvironment.RepositoryRoot,
                "sdk", "openai", "Azure.AI.OpenAI", "tests", "Assets", "whats_the_weather_pcm16_24khz_mono.wav"));
            using MemoryStream output = new();
            await Sample_VoiceAgent_Live.RunAudioConversationAsync(session,
                VoiceAgentE2EDiagnostics.ReadPcmWave(speechFile), output, TextWriter.Null, timeout.Token);
            Assert.That(output.Length, Is.GreaterThan(0));
            Assert.That(session.SessionClosed, Is.Not.Null);
        }
        conversationId = Recording.GetVariable("ConversationId", conversationId);
        Assert.That(conversationId, Is.Not.Null.And.Not.Empty);
        return conversationId;
    }

    private static bool IsSpeech(VoiceAgentLiveConversationItem item)
        => item is VoiceAgentLiveInputConversationItem or VoiceAgentLiveOutputConversationItem;

    private async Task<ClientResult<VoiceAgentLiveConversation>> WaitForConversationAsync(
        BetaVoiceAgentsLiveConversations history, string name, string conversationId)
    {
        for (int attempt = 0; attempt < 40; attempt++)
        {
            ClientResult<VoiceAgentLiveConversation> result = await history.GetLiveAgentConversationAsync(name, conversationId);
            if (result.Value.Status != VoiceConversationStatus.InProgress)
            {
                return result;
            }
            await Delay(500);
        }
        throw new InvalidOperationException("Stored Live conversation persistence did not finish.");
    }

    private static void AssertPcmWave(BinaryData audio, int channels)
    {
        using BinaryReader reader = new(audio.ToStream(), Encoding.ASCII);
        Assert.That(new string(reader.ReadChars(4)), Is.EqualTo("RIFF"));
        Assert.That(reader.ReadUInt32(), Is.EqualTo(reader.BaseStream.Length - 8));
        Assert.That(new string(reader.ReadChars(4)), Is.EqualTo("WAVE"));
        bool formatVerified = false;
        while (reader.BaseStream.Position + 8 <= reader.BaseStream.Length)
        {
            string chunk = new(reader.ReadChars(4));
            uint length = reader.ReadUInt32();
            long end = reader.BaseStream.Position + length;
            Assert.That(end, Is.LessThanOrEqualTo(reader.BaseStream.Length));
            if (chunk == "fmt ")
            {
                Assert.That(reader.ReadUInt16(), Is.EqualTo(1));
                Assert.That(reader.ReadUInt16(), Is.EqualTo(channels));
                Assert.That(reader.ReadUInt32(), Is.EqualTo(24000));
                reader.ReadUInt32();
                reader.ReadUInt16();
                Assert.That(reader.ReadUInt16(), Is.EqualTo(16));
                formatVerified = true;
            }
            else if (chunk == "data")
            {
                Assert.That(formatVerified, Is.True);
                Assert.That(length, Is.GreaterThan(0));
                Assert.That(length % (channels * 2), Is.Zero);
                return;
            }
            reader.BaseStream.Position = end + (length & 1);
        }
        Assert.Fail("The recorded response did not contain PCM audio.");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE basic conversation tests for Voice Agent realtime streaming -- mirrors the pattern used by
// sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/BasicConversationTests.cs, adapted to
// ProjectsRealtimeSessionClient's realtime protocol surface. Covers a simple text turn and the
// interop between a persisted realtime session and the BetaVoiceAgentsConversations REST surface.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests.LiveTests;

public class ProjectsRealtimeConversationTests : ProjectsRealtimeLiveTestBase
{
    // PCM16 mono at 24 kHz is the format configured on the audio-modality test agent below.
    private const int AudioSampleRate = 24000;
    private const int AudioChannels = 1;
    private const int AudioBytesPerSample = sizeof(short);

    public ProjectsRealtimeConversationTests(bool isAsync) : base(isAsync)
    {
    }

    private static void LogUpdate(RealtimeServerUpdate update) => Console.WriteLine($"[event] {update.Kind}");

    private static string FormatAudioSize(long bytes)
    {
        double seconds = bytes / (double)(AudioSampleRate * AudioBytesPerSample * AudioChannels);
        return $"{bytes} bytes ({bytes / 1024.0:F1} KB), {seconds:F2}s @ {AudioSampleRate} Hz / 16-bit / {AudioChannels}ch PCM";
    }

    // Generates a deterministic, non-silent 440 Hz tone so the audio-streaming test below
    // exercises real (non-zero) sample data without depending on an external audio asset.
    private static byte[] GenerateToneChunk(int durationMs, int startSampleOffset)
    {
        int sampleCount = AudioSampleRate * durationMs / 1000;
        byte[] buffer = new byte[sampleCount * AudioBytesPerSample];
        for (int i = 0; i < sampleCount; i++)
        {
            double time = (startSampleOffset + i) / (double)AudioSampleRate;
            short sample = (short)(3000 * Math.Sin(2 * Math.PI * 440 * time));
            BitConverter.GetBytes(sample).CopyTo(buffer, i * AudioBytesPerSample);
        }
        return buffer;
    }

    private async Task EnsureConversationAgentAsync(Azure.AI.Projects.Agents.AgentAdministrationClient agentsClient, CancellationToken cancellationToken)
    {
        try
        {
            await agentsClient.GetAgentAsync(CONVERSATION_AGENT_NAME, cancellationToken);
        }
        catch
        {
            Azure.AI.Projects.Agents.VoiceAgentDefinition definition = new()
            {
                ModelType = Azure.AI.Projects.Agents.VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "Respond briefly and helpfully.",
            };
            definition.OutputModalities.Add(Azure.AI.Projects.Agents.VoiceOutputModality.Text);
            await agentsClient.CreateAgentVersionAsync(
                CONVERSATION_AGENT_NAME,
                new Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions(definition),
                cancellationToken: cancellationToken);
        }
    }

    private async Task EnsureAudioConversationAgentAsync(Azure.AI.Projects.Agents.AgentAdministrationClient agentsClient, CancellationToken cancellationToken)
    {
        try
        {
            await agentsClient.GetAgentAsync(AUDIO_CONVERSATION_AGENT_NAME, cancellationToken);
        }
        catch
        {
            Azure.AI.Projects.Agents.VoiceAgentDefinition definition = new()
            {
                ModelType = Azure.AI.Projects.Agents.VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "Respond briefly and helpfully.",
                Audio = new Azure.AI.Projects.Agents.VoiceAgentAudioConfig
                {
                    Input = new Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig
                    {
                        Format = new RealtimePcmAudioFormat { Rate = 24000 },
                    },
                },
            };
            definition.OutputModalities.Add(Azure.AI.Projects.Agents.VoiceOutputModality.Audio);
            await agentsClient.CreateAgentVersionAsync(
                AUDIO_CONVERSATION_AGENT_NAME,
                new Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions(definition),
                cancellationToken: cancellationToken);
        }
    }

    // -----------------------------------------------------------------------
    // Verifies: a simple text-only turn produces a completed text response.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task TextConversationProducesTextResponse()
    {
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureConversationAgentAsync(client.AgentAdministrationClient, timeout.Token);

        using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await client.ProjectsRealtimeClient.StartSessionAsync(
            CONVERSATION_AGENT_NAME,
            intent: null,
            cancellationToken: timeout.Token);

        await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);
        await session.StartResponseAsync(timeout.Token);

        string responseText = string.Empty;
        await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            LogUpdate(update);
            if (update is RealtimeServerUpdateResponseOutputTextDone textDoneUpdate)
            {
                responseText = textDoneUpdate.Text;
            }
            else if (update is RealtimeServerUpdateResponseDone)
            {
                break;
            }
        }

        Console.WriteLine($"Voice agent response: {responseText}");
        Assert.That(responseText, Is.Not.Null.And.Not.Empty, "Expected a non-empty text response.");
    }

    // -----------------------------------------------------------------------
    // Verifies: a session started with Store = true produces a conversation
    // that becomes retrievable through the BetaVoiceAgentsConversations REST
    // surface once the session closes.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task PersistedConversationIsRetrievableAfterSession()
    {
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureConversationAgentAsync(client.AgentAdministrationClient, timeout.Token);

        string conversationId;
        using (ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await client.ProjectsRealtimeClient.StartSessionAsync(
            CONVERSATION_AGENT_NAME,
            intent: null,
            options: new RealtimeSessionClientOptions { QueryString = "store=true" },
            cancellationToken: timeout.Token))
        {
            await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);
            await session.StartResponseAsync(timeout.Token);

            conversationId = null;
            await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                LogUpdate(update);
                if (update is RealtimeServerUpdateResponseDone doneUpdate)
                {
                    conversationId = doneUpdate.Response.ConversationId;
                    break;
                }
            }
        }

        Assert.That(conversationId, Is.Not.Null.And.Not.Empty, "Expected the response.done event to report a conversation ID when Store = true.");

        Azure.AI.Projects.Agents.BetaVoiceAgentsConversations conversationsClient = client.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();

        System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceConversation> getConversationResult = await conversationsClient.GetAgentConversationAsync(
            CONVERSATION_AGENT_NAME,
            conversationId,
            timeout.Token);
        Console.WriteLine($"[REST] GET conversation -> {(int)getConversationResult.GetRawResponse().Status}");
        Assert.That(getConversationResult.Value.Id, Is.EqualTo(conversationId));

        bool listed = await conversationsClient
            .GetAgentConversationsAsync(CONVERSATION_AGENT_NAME, cancellationToken: timeout.Token)
            .AnyAsync(c => c.Id == conversationId);
        Console.WriteLine($"[REST] LIST conversations -> found match: {listed}");
        Assert.That(listed, Is.True, "The persisted conversation must appear when listing the agent's conversations.");

        List<RealtimeItem> items = await conversationsClient
            .GetAgentConversationItemsAsync(CONVERSATION_AGENT_NAME, conversationId, cancellationToken: timeout.Token)
            .ToListAsync();
        Console.WriteLine($"[REST] LIST conversation items -> {items.Count} item(s)");
        Assert.That(items, Is.Not.Empty, "Expected at least one persisted conversation item.");

        List<Azure.AI.Projects.Agents.VoiceResponse> responses = await conversationsClient
            .GetAgentConversationResponsesAsync(CONVERSATION_AGENT_NAME, conversationId, cancellationToken: timeout.Token)
            .ToListAsync();
        Console.WriteLine($"[REST] LIST conversation responses -> {responses.Count} response(s)");
        Assert.That(responses, Is.Not.Empty, "Expected at least one persisted response.");
    }

    // -----------------------------------------------------------------------
    // Verifies: an audio-modality turn streams input PCM audio across several
    // chunks and produces a non-empty accumulated audio response. Logs every
    // realtime event received and reports the exact input/output audio byte
    // counts (computed from the actual payloads, not estimated).
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task AudioConversationProducesAudioResponse()
    {
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureAudioConversationAgentAsync(client.AgentAdministrationClient, timeout.Token);

        using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await client.ProjectsRealtimeClient.StartSessionAsync(
            AUDIO_CONVERSATION_AGENT_NAME,
            intent: null,
            cancellationToken: timeout.Token);

        await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);

        // Stream 500 ms of tone as five 100 ms chunks, the same incremental
        // SendInputAudioAsync pattern a live microphone capture would use.
        long inputAudioBytes = 0;
        for (int chunkIndex = 0; chunkIndex < 5; chunkIndex++)
        {
            byte[] toneChunk = GenerateToneChunk(durationMs: 100, startSampleOffset: chunkIndex * AudioSampleRate / 10);
            await session.SendInputAudioAsync(BinaryData.FromBytes(toneChunk), timeout.Token);
            inputAudioBytes += toneChunk.Length;
        }
        await session.StartResponseAsync(timeout.Token);

        long outputAudioBytes = 0;
        string outputTranscript = string.Empty;
        await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            LogUpdate(update);
            if (update is RealtimeServerUpdateResponseOutputAudioDelta audioDeltaUpdate)
            {
                outputAudioBytes += audioDeltaUpdate.Delta.ToArray().Length;
            }
            else if (update is RealtimeServerUpdateResponseOutputAudioTranscriptDone transcriptDoneUpdate)
            {
                outputTranscript = transcriptDoneUpdate.Transcript;
            }
            else if (update is RealtimeServerUpdateResponseDone)
            {
                break;
            }
        }

        Console.WriteLine($"Input audio sent: {FormatAudioSize(inputAudioBytes)}");
        Console.WriteLine($"Output audio received: {FormatAudioSize(outputAudioBytes)}");
        Console.WriteLine($"Total audio transferred: {inputAudioBytes + outputAudioBytes} bytes ({(inputAudioBytes + outputAudioBytes) / 1024.0:F1} KB)");
        Console.WriteLine($"Output transcript: {outputTranscript}");

        Assert.That(outputAudioBytes, Is.GreaterThan(0), "Expected a non-empty audio response.");
    }
}

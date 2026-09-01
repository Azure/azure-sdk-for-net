// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_VoiceAgent : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task VoiceAgentAsync()
    {
        var existingAgentName = Environment.GetEnvironmentVariable("FOUNDRY_VOICE_AGENT_NAME");
#if SNIPPET
        var projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = string.IsNullOrEmpty(existingAgentName)
            ? TestEnvironment.FOUNDRY_MODEL_NAME
            : null;
#endif
        var inputAudioPath = Environment.GetEnvironmentVariable("FOUNDRY_VOICE_INPUT_AUDIO_PATH");
        var outputAudioPath = Environment.GetEnvironmentVariable("FOUNDRY_VOICE_OUTPUT_AUDIO_PATH")
            ?? Path.Combine(Path.GetTempPath(), "voice-agent-response.pcm");
        VoiceModelType voiceModelType = string.Equals(
            Environment.GetEnvironmentVariable("FOUNDRY_VOICE_MODEL_TYPE"),
            "managed",
            StringComparison.OrdinalIgnoreCase)
                ? VoiceModelType.Managed
                : VoiceModelType.SelfDeployed;
        AgentAdministrationClient agentsClient = new(
            endpoint: new Uri(projectEndpoint),
            tokenProvider: new DefaultAzureCredential());
        string agentName = string.IsNullOrEmpty(existingAgentName)
            ? $"voice-agent-sample-{Guid.NewGuid():N}".Substring(0, 40)
            : existingAgentName;
        ProjectsAgentVersion agentVersion = null;
        bool deleteAgent = false;

        try
        {
            if (string.IsNullOrEmpty(existingAgentName))
            {
                #region Snippet:Sample_VoiceAgent_Create
                VoiceAgentDefinition definition = new(
                    modelType: voiceModelType,
                    model: modelDeploymentName)
                {
                    Instructions = "Respond briefly and helpfully.",
                    Audio = new VoiceAgentAudioConfig
                    {
                        Input = new VoiceAgentAudioInputConfig
                        {
                            Format = new RealtimeAudioFormatsAudioPcm { Rate = 24000 },
                            NoiseReduction = new VoiceAgentNoiseReduction(VoiceAgentNoiseReductionType.NearField),
                            TurnDetection = new VoiceAgentServerVadTurnDetection
                            {
                                Threshold = 0.5,
                                PrefixPaddingMs = 300,
                                SilenceDurationMs = 500
                            },
                            Transcription = new VoiceAgentInputTranscription(VoiceAgentInputTranscriptionModel.Whisper1)
                        },
                        Output = new VoiceAgentAudioOutputConfig
                        {
                            Voice = "alloy",
                            VoiceType = VoiceType.Openai
                        }
                    },
                    Store = true
                };
                definition.OutputModalities.Add(VoiceOutputModality.Audio);
                definition.Tools.Add(new VoiceAgentSystemTool(VoiceAgentSystemToolName.EndConversation));
                agentVersion = await agentsClient.CreateAgentVersionAsync(
                    agentName,
                    new ProjectsAgentVersionCreationOptions(definition));
                #endregion
                deleteAgent = true;
            }
            else
            {
                ProjectsAgentRecord existingAgent = await agentsClient.GetAgentAsync(agentName);
                agentVersion = existingAgent.GetLatestVersion();
                Console.WriteLine($"Using existing voice agent {agentName}, version {agentVersion.Version}");
            }

            if (deleteAgent)
            {
                #region Snippet:Sample_VoiceAgent_Manage
                ProjectsAgentRecord agent = await agentsClient.GetAgentAsync(agentName);
                ProjectsAgentVersion version = await agentsClient.GetAgentVersionAsync(
                    agentName,
                    agentVersion.Version);
                Console.WriteLine($"Voice agent {agent.Name}, version {version.Version}");

                await foreach (ProjectsAgentVersion listedVersion in agentsClient.GetAgentVersionsAsync(agentName))
                {
                    Console.WriteLine($"Version {listedVersion.Version}: {listedVersion.Description}");
                }

                await agentsClient.DisableAgentAsync(agentName);
                await agentsClient.EnableAgentAsync(agentName);
                #endregion
            }

            #region Snippet:Sample_VoiceAgent_Realtime
            VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(3));
            AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
            HashSet<string> existingConversationIds = new();
            await foreach (VoiceConversation conversation in conversationsClient.GetAgentConversationsAsync(
                agentName,
                cancellationToken: timeout.Token))
            {
                existingConversationIds.Add(conversation.Id);
            }

            await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
                agentName,
                new VoiceAgentConnectionOptions { AgentVersion = agentVersion.Version, Store = true },
                timeout.Token);

            await session.AddItemAsync(BinaryData.FromObjectAsJson(new
            {
                type = "message",
                role = "user",
                content = new[] { new { type = "input_text", text = "Say hello in one sentence." } }
            }), cancellationToken: timeout.Token);
            await session.StartResponseAsync(cancellationToken: timeout.Token);

            using MemoryStream responseAudio = new();
            await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                if (update.MessageType != WebSocketMessageType.Text)
                {
                    continue;
                }

                using JsonDocument document = JsonDocument.Parse(update.Data);
                Console.WriteLine(update.EventType);
                if (update.EventType == RealtimeServerEventType.ResponseOutputAudioDelta)
                {
                    byte[] audioChunk = Convert.FromBase64String(document.RootElement.GetProperty("delta").GetString());
                    await responseAudio.WriteAsync(audioChunk, 0, audioChunk.Length, timeout.Token);
                }
                else if (update.EventType == RealtimeServerEventType.ResponseDone)
                {
                    break;
                }
            }
            Console.WriteLine($"Received {responseAudio.Length} bytes of PCM response audio.");
            await session.CloseAsync();
            #endregion

            #region Snippet:Sample_VoiceAgent_AudioStreaming
            if (!string.IsNullOrEmpty(inputAudioPath))
            {
                await using VoiceAgentSession audioSession = await realtimeClient.StartSessionAsync(
                    agentName,
                    new VoiceAgentConnectionOptions { AgentVersion = agentVersion.Version, Store = true },
                    timeout.Token);
                using FileStream inputPcm = File.OpenRead(inputAudioPath);
                using FileStream outputPcm = File.Create(outputAudioPath);

                await StreamAudioTurnAsync(
                    audioSession,
                    inputPcm,
                    outputPcm,
                    appendTrailingSilence: true,
                    cancellationToken: timeout.Token);
                await audioSession.CloseAsync(timeout.Token);
                if (outputPcm.Length == 0)
                {
                    throw new InvalidOperationException("The streaming response did not contain audio.");
                }
                Console.WriteLine($"Streamed response audio to {outputAudioPath}");
            }
            #endregion

            #region Snippet:Sample_VoiceAgent_Conversations
            List<string> newConversationIds = new();
            await foreach (VoiceConversation conversation in conversationsClient.GetAgentConversationsAsync(
                agentName,
                limit: 10,
                order: AgentListOrder.Descending,
                cancellationToken: timeout.Token))
            {
                Console.WriteLine($"Conversation {conversation.Id}: {conversation.Status}");
                if (!existingConversationIds.Contains(conversation.Id))
                {
                    newConversationIds.Add(conversation.Id);
                }
            }

            foreach (string conversationId in newConversationIds)
            {
                string assistantItemId = await ReadPersistedConversationAsync(
                    conversationsClient,
                    agentName,
                    conversationId,
                    timeout.Token);

                using MemoryStream conversationAudio = new();
                await DownloadConversationAudioAsync(
                    conversationsClient,
                    agentName,
                    conversationId,
                    conversationAudio,
                    timeout.Token);
                Console.WriteLine($"Downloaded {conversationAudio.Length} bytes of conversation audio.");

                if (!string.IsNullOrEmpty(assistantItemId))
                {
                    using MemoryStream itemAudio = new();
                    await DownloadConversationItemAudioAsync(
                        conversationsClient,
                        agentName,
                        conversationId,
                        assistantItemId,
                        itemAudio,
                        timeout.Token);
                    Console.WriteLine($"Downloaded {itemAudio.Length} bytes of assistant item audio.");
                }
            }
            #endregion
        }
        finally
        {
            if (deleteAgent)
            {
                await agentsClient.DeleteAgentAsync(agentName, force: true);
            }
        }
    }

    #region Snippet:Sample_VoiceAgent_StreamAudio
    public static async Task<string> StreamAudioTurnAsync(
        VoiceAgentSession session,
        Stream inputPcm,
        Stream outputPcm,
        bool appendTrailingSilence = false,
        CancellationToken cancellationToken = default)
    {
        Task<string> receiveTask = ReceiveOutputAsync();
        Task sendTask = SendInputAsync();
        await Task.WhenAll(sendTask, receiveTask);
        return await receiveTask;

        async Task SendInputAsync()
        {
            const int bytesPerSecond = 24000 * sizeof(short);
            const int chunkSize = bytesPerSecond / 20;
            byte[] buffer = new byte[chunkSize];

            while (true)
            {
                int bytesRead = await inputPcm.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                if (bytesRead == 0)
                {
                    break;
                }

                await session.SendInputAudioAsync(
                    BinaryData.FromBytes(buffer.AsMemory(0, bytesRead)),
                    cancellationToken);
                await Task.Delay(TimeSpan.FromSeconds((double)bytesRead / bytesPerSecond), cancellationToken);
            }

            if (appendTrailingSilence)
            {
                Array.Clear(buffer, 0, buffer.Length);
                for (int i = 0; i < 20; i++)
                {
                    await session.SendInputAudioAsync(BinaryData.FromBytes(buffer), cancellationToken);
                    await Task.Delay(TimeSpan.FromMilliseconds(50), cancellationToken);
                }
            }
        }

        async Task<string> ReceiveOutputAsync()
        {
            await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(cancellationToken))
            {
                if (update.EventType == RealtimeServerEventType.ResponseOutputAudioDelta)
                {
                    using JsonDocument document = JsonDocument.Parse(update.Data);
                    byte[] audioChunk = Convert.FromBase64String(document.RootElement.GetProperty("delta").GetString());
                    await outputPcm.WriteAsync(audioChunk, 0, audioChunk.Length, cancellationToken);
                }
                else if (update.EventType == RealtimeServerEventType.ResponseDone)
                {
                    using JsonDocument document = JsonDocument.Parse(update.Data);
                    if (IsCancelledResponse(document.RootElement))
                    {
                        continue;
                    }
                    return GetConversationId(document.RootElement);
                }
            }
            return null;
        }
    }
    #endregion

    private static string GetConversationId(JsonElement eventPayload)
    {
        return eventPayload.TryGetProperty("response", out JsonElement response)
            && response.TryGetProperty("conversation_id", out JsonElement conversationId)
                ? conversationId.GetString()
                : null;
    }

    private static bool IsCancelledResponse(JsonElement eventPayload)
    {
        return eventPayload.TryGetProperty("response", out JsonElement response)
            && response.TryGetProperty("status", out JsonElement status)
            && status.ValueEquals("cancelled");
    }

    #region Snippet:Sample_VoiceAgent_ReadConversation
    private static async Task<string> ReadPersistedConversationAsync(
        AgentEndpointConversations conversationsClient,
        string agentName,
        string conversationId,
        CancellationToken cancellationToken = default)
    {
        string assistantItemId = null;
        VoiceConversation conversation = await conversationsClient.GetAgentConversationAsync(
            agentName,
            conversationId,
            cancellationToken);
        Console.WriteLine($"Created at {conversation.CreatedAt}; status: {conversation.Status}");

        await foreach (VoiceResponse response in conversationsClient.GetAgentConversationResponsesAsync(
            agentName,
            conversationId,
            cancellationToken: cancellationToken))
        {
            string responseId = response.Id;
            VoiceResponse detail = await conversationsClient.GetAgentConversationResponseAsync(
                agentName,
                conversationId,
                responseId,
                cancellationToken);
            Console.WriteLine($"Response {responseId}: {detail.Status}");

            await foreach (RealtimeConversationItem conversationItem in conversationsClient.GetAgentConversationResponseItemsAsync(
                agentName,
                conversationId,
                responseId,
                cancellationToken: cancellationToken))
            {
                using JsonDocument itemDocument = JsonDocument.Parse(ModelReaderWriter.Write(conversationItem));
                JsonElement item = itemDocument.RootElement;
                string itemType = item.TryGetProperty("type", out JsonElement type) ? type.GetString() : "unknown";
                Console.WriteLine($"Response item: {itemType}");
                if (assistantItemId is null
                    && item.TryGetProperty("role", out JsonElement role)
                    && role.ValueEquals("assistant")
                    && item.TryGetProperty("id", out JsonElement id))
                {
                    assistantItemId = id.GetString();
                }
            }
        }

        await foreach (RealtimeConversationItem conversationItem in conversationsClient.GetAgentConversationItemsAsync(
            agentName,
            conversationId,
            cancellationToken: cancellationToken))
        {
            using JsonDocument itemDocument = JsonDocument.Parse(ModelReaderWriter.Write(conversationItem));
            JsonElement item = itemDocument.RootElement;
            string itemType = item.TryGetProperty("type", out JsonElement type) ? type.GetString() : "unknown";
            Console.WriteLine($"Conversation item: {itemType}");
        }
        return assistantItemId;
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_ReadAudio
    private static async Task DownloadConversationAudioAsync(
        AgentEndpointConversations conversationsClient,
        string agentName,
        string conversationId,
        Stream destination,
        CancellationToken cancellationToken = default)
    {
        VoiceRecordingResponse recording = await conversationsClient.GetAgentConversationAudioAsync(
            agentName,
            conversationId,
            cancellationToken);
        Console.WriteLine($"{recording.Format}, {recording.SampleRate} Hz, {recording.Channels} channels");

        if (recording.BlobUri is not null)
        {
            Console.WriteLine($"Download the bring-your-own-storage recording from {recording.BlobUri}");
            return;
        }

        BinaryData content = await conversationsClient.GetAgentConversationAudioContentAsync(
            agentName,
            conversationId,
            cancellationToken);
        byte[] bytes = content.ToArray();
        await destination.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
    }

    private static async Task DownloadConversationItemAudioAsync(
        AgentEndpointConversations conversationsClient,
        string agentName,
        string conversationId,
        string itemId,
        Stream destination,
        CancellationToken cancellationToken = default)
    {
        VoiceItemAudioResponse audio = await conversationsClient.GetAgentConversationItemAudioAsync(
            agentName,
            conversationId,
            itemId,
            cancellationToken);
        Console.WriteLine($"{audio.Role}: {audio.DurationMs}");

        if (audio.BlobUri is not null)
        {
            Console.WriteLine($"Download the bring-your-own-storage item audio from {audio.BlobUri}");
            return;
        }

        BinaryData content = await conversationsClient.GetAgentConversationItemAudioContentAsync(
            agentName,
            conversationId,
            itemId,
            cancellationToken);
        byte[] bytes = content.ToArray();
        await destination.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
    }
    #endregion

    public Sample_VoiceAgent(bool isAsync) : base(isAsync)
    {
    }
}

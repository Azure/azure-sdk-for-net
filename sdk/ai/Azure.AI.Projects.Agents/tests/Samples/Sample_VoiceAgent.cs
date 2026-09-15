// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
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
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Agents.Tests.Samples;

[NonParallelizable]
[LiveOnly]
public class Sample_VoiceAgent : RecordedTestBase<AgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task VoiceAgentAsync()
    {
        var existingAgentName = Environment.GetEnvironmentVariable("FOUNDRY_VOICE_AGENT_NAME");
        var voiceModelName = Environment.GetEnvironmentVariable("FOUNDRY_VOICE_MODEL_NAME");
#if SNIPPET
        var projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = voiceModelName ?? Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = string.IsNullOrEmpty(existingAgentName)
            ? voiceModelName ?? TestEnvironment.FOUNDRY_MODEL_NAME
            : null;
#endif
        var inputAudioPath = Environment.GetEnvironmentVariable("FOUNDRY_VOICE_INPUT_AUDIO_PATH");
        var outputAudioPath = Environment.GetEnvironmentVariable("FOUNDRY_VOICE_OUTPUT_AUDIO_PATH")
            ?? Path.Combine(Path.GetTempPath(), $"voice-agent-response-{Guid.NewGuid():N}.pcm");
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
                VoiceAgentDefinition definition = new()
                {
                    ModelType = voiceModelType,
                    Model = modelDeploymentName,
                    Instructions = "Respond briefly and helpfully.",
                    Audio = new VoiceAgentAudioConfig
                    {
                        Input = new VoiceAgentAudioInputConfig
                        {
                            Format = CreatePcmAudioFormat(24000),
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
                            Format = CreatePcmAudioFormat(24000),
                            Voice = "en-US-AvaNeural",
                            VoiceType = VoiceType.AzureStandard
                        }
                    },
                    Store = true
                };
                definition.OutputModalities.Add(VoiceOutputModality.Audio);
                definition.Tools.Add(new VoiceAgentEndConversationSystemTool());
                ClientResult<ProjectsAgentVersion> createResult = await agentsClient.CreateAgentVersionAsync(
                    agentName,
                    new ProjectsAgentVersionCreationOptions(definition));
                agentVersion = createResult;
                #endregion
                Console.WriteLine($"CreateAgentVersion status: {(int)createResult.GetRawResponse().Status}");
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

                ClientResult disableResult = await agentsClient.DisableAgentAsync(agentName);
                ClientResult enableResult = await agentsClient.EnableAgentAsync(agentName);
                #endregion
                Console.WriteLine($"DisableAgent status: {(int)disableResult.GetRawResponse().Status}");
                Console.WriteLine($"EnableAgent status: {(int)enableResult.GetRawResponse().Status}");
            }

            #region Snippet:Sample_VoiceAgent_Realtime
            VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(5));
            AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
            HashSet<string> newConversationIds = new();
            bool hasGreeting = agentVersion.Definition is VoiceAgentDefinition voiceDefinition
                && voiceDefinition.Greeting is not null;

            await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
                agentName,
                new VoiceAgentConnectionOptions { AgentVersion = agentVersion.Version, Store = true },
                timeout.Token);
            newConversationIds.Add(await WaitForSessionReadyAsync(session, hasGreeting, timeout.Token));

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
                LogRealtimeEvent(update.EventType, document.RootElement);
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
            if (responseAudio.Length == 0)
            {
                throw new InvalidOperationException("The voice response did not contain audio.");
            }
            Console.WriteLine($"Received {responseAudio.Length} bytes of PCM response audio.");
            #endregion

            if (deleteAgent)
            {
                #region Snippet:Sample_VoiceAgent_UpdatePitch
                await session.ConfigureSessionAsync(BinaryData.FromObjectAsJson(new
                {
                    type = "realtime",
                    audio = new
                    {
                        output = new
                        {
                            voice = "en-US-AvaNeural",
                            voice_type = "azure-standard",
                            pitch = "+10%"
                        }
                    }
                }), timeout.Token);
                #endregion
            }

            #region Snippet:Sample_VoiceAgent_Tools
            // The agent was configured with the "end_conversation" system tool. Prompting the model
            // to end the conversation exercises that tool end-to-end: the service invokes it as a
            // function_call item and reflects the outcome in the response, without the client having
            // to submit a function_call_output (system tools are handled entirely server-side, unlike
            // custom/user-defined function tools).
            await session.AddItemAsync(BinaryData.FromObjectAsJson(new
            {
                type = "message",
                role = "user",
                content = new[] { new { type = "input_text", text = "Please say a brief goodbye and then end our conversation." } }
            }), cancellationToken: timeout.Token);
            await session.StartResponseAsync(cancellationToken: timeout.Token);

            await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                if (update.MessageType != WebSocketMessageType.Text)
                {
                    continue;
                }

                using JsonDocument document = JsonDocument.Parse(update.Data);
                LogRealtimeEvent(update.EventType, document.RootElement);
                if (update.EventType == RealtimeServerEventType.ResponseDone)
                {
                    break;
                }
            }
            #endregion

            await session.CloseAsync();

            #region Snippet:Sample_VoiceAgent_AudioStreaming
            if (!string.IsNullOrEmpty(inputAudioPath) || deleteAgent)
            {
                await using VoiceAgentSession audioSession = await realtimeClient.StartSessionAsync(
                    agentName,
                    new VoiceAgentConnectionOptions { AgentVersion = agentVersion.Version, Store = true },
                    timeout.Token);
                newConversationIds.Add(await WaitForSessionReadyAsync(audioSession, hasGreeting, timeout.Token));
                using Stream inputPcm = string.IsNullOrEmpty(inputAudioPath)
                    ? new MemoryStream(responseAudio.ToArray())
                    : File.OpenRead(inputAudioPath);
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
            foreach (string conversationId in newConversationIds)
            {
                await WaitForConversationPersistenceAsync(
                    conversationsClient,
                    agentName,
                    conversationId,
                    timeout.Token);
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
                ClientResult deleteResult = await agentsClient.DeleteAgentAsync(agentName, force: true);
                Console.WriteLine($"DeleteAgent status: {(int)deleteResult.GetRawResponse().Status}");
            }
        }
    }

    internal static async Task<string> WaitForSessionReadyAsync(
        VoiceAgentSession session,
        bool hasGreeting,
        CancellationToken cancellationToken = default)
    {
        string conversationId = null;
        await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(cancellationToken))
        {
            if (update.MessageType != WebSocketMessageType.Text)
            {
                continue;
            }

            using JsonDocument document = JsonDocument.Parse(update.Data);
            LogRealtimeEvent(update.EventType, document.RootElement);
            if (update.EventType == RealtimeServerEventType.SessionCreated)
            {
                conversationId = GetConversationId(document.RootElement)
                    ?? throw new InvalidOperationException("session.created did not include a conversation ID.");
                if (!hasGreeting)
                {
                    return conversationId;
                }
            }
            else if (update.EventType == RealtimeServerEventType.ResponseDone
                && conversationId is not null
                && !IsCancelledResponse(document.RootElement))
            {
                return conversationId;
            }
        }

        throw new InvalidOperationException("The voice session closed before initialization or its greeting completed.");
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
            string conversationId = null;
            await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(cancellationToken))
            {
                if (update.MessageType != WebSocketMessageType.Text)
                {
                    continue;
                }
                using JsonDocument document = JsonDocument.Parse(update.Data);
                LogRealtimeEvent(update.EventType, document.RootElement);
                conversationId = GetConversationId(document.RootElement) ?? conversationId;
                if (update.EventType == RealtimeServerEventType.ResponseOutputAudioDelta)
                {
                    byte[] audioChunk = Convert.FromBase64String(document.RootElement.GetProperty("delta").GetString());
                    await outputPcm.WriteAsync(audioChunk, 0, audioChunk.Length, cancellationToken);
                }
                else if (update.EventType == RealtimeServerEventType.ResponseDone)
                {
                    if (IsCancelledResponse(document.RootElement))
                    {
                        continue;
                    }
                    return conversationId;
                }
            }
            throw new InvalidOperationException("The voice session closed before the audio response completed.");
        }
    }
    #endregion

    /// <summary>
    /// Logs a streaming realtime event along with a short, event-type-specific summary of its
    /// payload (transcript deltas, audio chunk sizes, response status, tool-call arguments, or error
    /// messages), so the event flow can be verified beyond just the event type name.
    /// </summary>
    private static void LogRealtimeEvent(RealtimeServerEventType? eventType, JsonElement payload)
    {
        string detail = eventType?.ToString() switch
        {
            "response.output_audio_transcript.delta" => GetString(payload, "delta"),
            "conversation.item.input_audio_transcription.completed" => GetString(payload, "transcript"),
            "response.output_audio.delta" => payload.TryGetProperty("delta", out JsonElement audioDelta)
                ? $"{Convert.FromBase64String(audioDelta.GetString()).Length} bytes"
                : null,
            "response.function_call_arguments.done" => GetString(payload, "arguments"),
            "response.done" => payload.TryGetProperty("response", out JsonElement response) && response.TryGetProperty("status", out JsonElement status)
                ? status.GetString()
                : null,
            "error" => payload.TryGetProperty("error", out JsonElement error) && error.TryGetProperty("message", out JsonElement message)
                ? message.GetString()
                : null,
            _ => null
        };
        Console.WriteLine(detail is null ? $"{eventType}" : $"{eventType}: {detail}");

        if (eventType == RealtimeServerEventType.Error)
        {
            throw new InvalidOperationException($"The voice service returned an error: {detail}");
        }
        if (eventType == RealtimeServerEventType.ResponseDone
            && payload.TryGetProperty("response", out JsonElement completedResponse)
            && completedResponse.TryGetProperty("status", out JsonElement completedStatus)
            && (completedStatus.ValueEquals("failed") || completedStatus.ValueEquals("incomplete")))
        {
            string statusDetails = completedResponse.TryGetProperty("status_details", out JsonElement details)
                ? details.ToString()
                : "No status details were provided.";
            throw new InvalidOperationException($"The voice response {completedStatus.GetString()}: {statusDetails}");
        }

        static string GetString(JsonElement payload, string propertyName) =>
            payload.TryGetProperty(propertyName, out JsonElement value) ? value.GetString() : null;
    }

    /// <summary>
    /// Builds a PCM audio format at the given sample rate. <see cref="RealtimePcmAudioFormat.Rate"/> is
    /// read-only in the current OpenAI SDK "patch model" shape, so the rate must be set through the
    /// underlying <see cref="System.ClientModel.Primitives.JsonPatch"/> instead of an object initializer.
    /// </summary>
    private static RealtimePcmAudioFormat CreatePcmAudioFormat(int rate)
    {
        RealtimePcmAudioFormat format = new();
        format.Patch.Set("$.rate"u8, rate);
        return format;
    }

    private static string GetConversationId(JsonElement eventPayload)
    {
        if (eventPayload.TryGetProperty("conversation_id", out JsonElement id))
        {
            return id.GetString();
        }
        if (eventPayload.TryGetProperty("session", out JsonElement session)
            && session.TryGetProperty("conversation_id", out id))
        {
            return id.GetString();
        }
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

    private static async Task WaitForConversationPersistenceAsync(
        AgentEndpointConversations conversationsClient,
        string agentName,
        string conversationId,
        CancellationToken cancellationToken = default)
    {
        using CancellationTokenSource deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        deadline.CancelAfter(TimeSpan.FromMinutes(1));
        try
        {
            while (true)
            {
                try
                {
                    VoiceConversation conversation = await conversationsClient.GetAgentConversationAsync(
                        agentName, conversationId, deadline.Token);
                    if (conversation.Status == VoiceConversationStatus.Completed)
                    {
                        return;
                    }
                    if (conversation.Status == VoiceConversationStatus.Failed)
                    {
                        throw new InvalidOperationException($"Persistence failed for conversation {conversationId}.");
                    }
                }
                catch (ClientResultException exception) when (exception.Status == 404)
                {
                    // A closed session may not be visible until persistence finalization starts.
                }

                await Task.Delay(TimeSpan.FromSeconds(1), deadline.Token);
            }
        }
        catch (OperationCanceledException exception) when (!cancellationToken.IsCancellationRequested)
        {
            throw new TimeoutException($"Conversation {conversationId} was not persisted within one minute.", exception);
        }
    }

    #region Snippet:Sample_VoiceAgent_ReadConversation
    private static async Task<string> ReadPersistedConversationAsync(
        AgentEndpointConversations conversationsClient,
        string agentName,
        string conversationId,
        CancellationToken cancellationToken = default)
    {
        string assistantItemId = null;
        ClientResult<VoiceConversation> conversationResult = await conversationsClient.GetAgentConversationAsync(
            agentName,
            conversationId,
            cancellationToken);
        VoiceConversation conversation = conversationResult;
        Console.WriteLine($"Created at {conversation.CreatedAt}; status: {conversation.Status} (GetAgentConversation status: {(int)conversationResult.GetRawResponse().Status})");

        await foreach (VoiceResponse response in conversationsClient.GetAgentConversationResponsesAsync(
            agentName,
            conversationId,
            cancellationToken: cancellationToken))
        {
            string responseId = response.Id;
            ClientResult<VoiceResponse> detailResult = await conversationsClient.GetAgentConversationResponseAsync(
                agentName,
                conversationId,
                responseId,
                cancellationToken);
            VoiceResponse detail = detailResult;
            Console.WriteLine($"Response {responseId}: {detail.Status} (GetAgentConversationResponse status: {(int)detailResult.GetRawResponse().Status})");

            await foreach (RealtimeItem conversationItem in conversationsClient.GetAgentConversationResponseItemsAsync(
                agentName,
                conversationId,
                responseId,
                cancellationToken: cancellationToken))
            {
                Console.WriteLine($"Response item: {DescribeItem(conversationItem)}");
                if (assistantItemId is null
                    && conversationItem is RealtimeMessageItem assistantMessage
                    && assistantMessage.Role == RealtimeMessageRole.Assistant)
                {
                    assistantItemId = assistantMessage.Id;
                }
            }
        }

        await foreach (RealtimeItem conversationItem in conversationsClient.GetAgentConversationItemsAsync(
            agentName,
            conversationId,
            cancellationToken: cancellationToken))
        {
            Console.WriteLine($"Conversation item: {DescribeItem(conversationItem)}");
        }
        if (assistantItemId is null)
        {
            throw new InvalidOperationException("The persisted conversation did not contain an assistant message.");
        }
        RealtimeItem persistedItem = await conversationsClient.GetAgentConversationItemAsync(
            agentName, conversationId, assistantItemId, cancellationToken);
        Console.WriteLine($"Retrieved item: {DescribeItem(persistedItem)}");
        return assistantItemId;
    }

    /// <summary>
    /// Describes a persisted conversation item using typed pattern-matching rather than
    /// round-tripping through <see cref="ModelReaderWriter.Write{T}(T, ModelReaderWriterOptions)"/>.
    /// Items retrieved from the persisted-conversation-item endpoints omit large fields (e.g. inline
    /// audio bytes, which are fetched separately via the dedicated audio endpoints), and re-serializing
    /// such a partially-populated item can throw inside some OpenAI.Realtime content-part writers that
    /// don't yet null-check every field. Typed access below sidesteps that entirely.
    /// </summary>
    private static string DescribeItem(RealtimeItem item) => item switch
    {
        RealtimeMessageItem message => $"message (role={message.Role}, id={message.Id}, status={message.Status})",
        RealtimeFunctionCallItem functionCall => $"function_call (name={functionCall.FunctionName}, id={functionCall.Id})",
        RealtimeFunctionCallOutputItem functionCallOutput => $"function_call_output (id={functionCallOutput.Id})",
        RealtimeMcpToolCallItem mcpToolCall => $"mcp_call (name={mcpToolCall.ToolName}, id={mcpToolCall.Id})",
        RealtimeMcpToolCallApprovalRequestItem mcpApprovalRequest => $"mcp_approval_request (id={mcpApprovalRequest.Id})",
        RealtimeMcpToolCallApprovalResponseItem mcpApprovalResponse => $"mcp_approval_response (id={mcpApprovalResponse.Id})",
        RealtimeMcpToolDefinitionListItem mcpToolList => $"mcp_list_tools (id={mcpToolList.Id})",
        _ => $"unknown ({item.GetType().Name})"
    };
    #endregion

    #region Snippet:Sample_VoiceAgent_ReadAudio
    private static async Task DownloadConversationAudioAsync(
        AgentEndpointConversations conversationsClient,
        string agentName,
        string conversationId,
        Stream destination,
        CancellationToken cancellationToken = default)
    {
        ClientResult<VoiceRecordingResponse> recordingResult = await conversationsClient.GetAgentConversationAudioAsync(
            agentName,
            conversationId,
            cancellationToken);
        VoiceRecordingResponse recording = recordingResult;
        Console.WriteLine($"{recording.Format}, {recording.SampleRate} Hz, {recording.Channels} channels (GetAgentConversationAudio status: {(int)recordingResult.GetRawResponse().Status})");

        if (recording.BlobUri is not null)
        {
            Console.WriteLine($"Download the bring-your-own-storage recording from {recording.BlobUri}");
            return;
        }

        ClientResult<BinaryData> contentResult = await conversationsClient.GetAgentConversationAudioContentAsync(
            agentName,
            conversationId,
            cancellationToken);
        Console.WriteLine($"GetAgentConversationAudioContent status: {(int)contentResult.GetRawResponse().Status}");
        byte[] bytes = ((BinaryData)contentResult).ToArray();
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
        ClientResult<VoiceItemAudioResponse> audioResult = await conversationsClient.GetAgentConversationItemAudioAsync(
            agentName,
            conversationId,
            itemId,
            cancellationToken);
        VoiceItemAudioResponse audio = audioResult;
        Console.WriteLine($"{audio.Role}: {audio.DurationMs} (GetAgentConversationItemAudio status: {(int)audioResult.GetRawResponse().Status})");

        if (audio.BlobUri is not null)
        {
            Console.WriteLine($"Download the bring-your-own-storage item audio from {audio.BlobUri}");
            return;
        }

        ClientResult<BinaryData> contentResult = await conversationsClient.GetAgentConversationItemAudioContentAsync(
            agentName,
            conversationId,
            itemId,
            cancellationToken);
        Console.WriteLine($"GetAgentConversationItemAudioContent status: {(int)contentResult.GetRawResponse().Status}");
        byte[] bytes = ((BinaryData)contentResult).ToArray();
        await destination.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
    }
    #endregion

    public Sample_VoiceAgent(bool isAsync) : base(isAsync)
    {
        ProjectsTestSanitizers.ApplySanitizers(this);
    }
}

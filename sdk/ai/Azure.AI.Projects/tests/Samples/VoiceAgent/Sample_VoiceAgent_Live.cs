// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using OpenAI.Responses;

#pragma warning disable AAIP001, AAIP002, OPENAI001

namespace Azure.AI.Projects.Tests.Samples;

public static class Sample_VoiceAgent_Live
{
    private const int MaximumToolContinuations = 8;

    #region Snippet:Sample_VoiceAgent_Live_Options
    public static async Task ConnectionOptionsAsync(
        string projectEndpoint, string liveDeployment, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        VoiceAgentLiveDefinition definition = CreateDefinition(liveDeployment);
        definition.Instructions = "Answer briefly in {{language}}.";
        definition.StructuredInputs["language"] = new StructuredInputDefinition
        {
            Description = "Language used for spoken answers.",
            DefaultValue = BinaryData.FromObjectAsJson("English")
        };
        ProjectsAgentVersion version = await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: cancellationToken);
        try
        {
            ProjectsLiveClient live = project.ProjectsLiveClient;
            Console.WriteLine($"Live endpoint: {live.Endpoint}; shares project pipeline: {ReferenceEquals(live.Pipeline, project.Pipeline)}");
            ProjectsLiveSessionClientOptions options = CreateConnectionOptions(version.Version);
            ProjectsLiveSessionClient session = await live.StartSessionAsync(agentName, options, cancellationToken);
            await using (session)
            {
                Console.WriteLine($"State: {session.State}; model: {session.SessionStarted.Session.Model}");
            }
            // DisposeAsync confirms native finalization before releasing the connection.
            Console.WriteLine($"Closed: {session.State}; final usage: {session.SessionClosed.Usage.Seconds} seconds");
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_OptionsValues
    internal static ProjectsLiveSessionClientOptions CreateConnectionOptions(string version)
    {
        ProjectsLiveSessionClientOptions options = new()
        {
            AgentVersion = version,
            // Store is used by the other examples; this shows its raw-query alternative.
            QueryString = "store=false"
        };
        options.StructuredInputs["language"] = BinaryData.FromObjectAsJson("English");
        options.Headers["x-correlation-id"] = Guid.NewGuid().ToString();
        return options;
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Connect
    public static async Task ConnectAsync(string projectEndpoint, string liveDeployment, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(CreateDefinition(liveDeployment)), cancellationToken: cancellationToken);
        try
        {
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = false }, cancellationToken);
            Console.WriteLine($"Live model: {session.SessionStarted.Session.Model}");
            // Foundry already started the session. Do not send another session.start event.
            await session.CloseAsync(cancellationToken);
            Console.WriteLine($"Final Live usage: {session.SessionClosed.Usage.Seconds} seconds");
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Controls
    public static async Task SessionControlsAsync(
        string projectEndpoint, string liveDeployment, string backendDeployment, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        await project.AgentAdministrationClient.CreateAgentVersionAsync(agentName,
            new ProjectsAgentVersionCreationOptions(CreateResponsesDefinition(liveDeployment, backendDeployment, tools: false)),
            cancellationToken: cancellationToken);
        try
        {
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = false }, cancellationToken);
            await RunSessionControlsAsync(session, Console.Out, cancellationToken);
            await session.SendEventAsync(new LiveClientEventLiveSessionCloseParam { EventId = "sample-close" }, cancellationToken);
            await session.CloseAsync(cancellationToken);
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_ControlEvents
    internal static async Task RunSessionControlsAsync(
        ProjectsLiveSessionClient session, TextWriter output, CancellationToken cancellationToken)
    {
        LiveResponsesDelegationUpdateParam delegation = new()
        {
            Responses = new LiveResponsesDelegationSettingsUpdateInputParam
            {
                Instructions = "Answer briefly using only verified context."
            }
        };
        await session.SendEventAsync(new LiveClientEventLiveSessionUpdateParam(new LiveSessionUpdateParams
        {
            Delegation = ModelReaderWriter.Write(delegation, new ModelReaderWriterOptions("W"), AzureAIProjectsAgentsContext.Default)
        }) { EventId = "sample-update" }, cancellationToken);
        await session.SendEventAsync(new LiveClientEventLiveInputAudioMuteParam { EventId = "sample-mute" }, cancellationToken);
        await session.SendEventAsync(new LiveClientEventLiveInputAudioUnmuteParam { EventId = "sample-unmute" }, cancellationToken);
        await session.SendEventAsync(new LiveClientEventLiveThinkingAppendParam(null,
            "The verified demonstration value is seven.") { EventId = "sample-thinking" }, cancellationToken);
        await session.SendEventAsync(new LiveClientEventLiveCommentaryAppendParam(null,
            "The test lookup is complete.") { EventId = "sample-commentary" }, cancellationToken);
        await session.SendEventAsync(new LiveClientEventLiveInstructionsAppendParam(null,
            "Keep spoken answers brief.") { EventId = "sample-instructions" }, cancellationToken);
        await session.SendCommandAsync(BinaryData.FromString("""
            {"type":"session.thinking.append","event_id":"sample-raw","delegation_id":null,
             "content":"This command demonstrates the raw JSON escape hatch."}
            """), cancellationToken);

        HashSet<string> pending = new(StringComparer.Ordinal)
        {
            "sample-update", "sample-mute", "sample-unmute", "sample-thinking",
            "sample-commentary", "sample-instructions", "sample-raw"
        };
        using CancellationTokenSource flow = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        Task audio = FeedSilenceAsync(session, flow.Token, cancellationToken);
        Task acknowledgments = ReceiveAcknowledgmentsAsync();
        await Task.WhenAny(audio, acknowledgments);
        flow.Cancel();
        try
        {
            await acknowledgments;
        }
        finally
        {
            try
            {
                await audio;
            }
            catch (OperationCanceledException exception) when (
                exception.CancellationToken == flow.Token && !cancellationToken.IsCancellationRequested)
            {
                // Stop the producer after acknowledgments without canceling an in-flight socket send.
            }
        }

        async Task ReceiveAcknowledgmentsAsync()
        {
            await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(flow.Token))
            {
                ThrowIfServiceFailure(serverEvent);
                string acknowledged = serverEvent switch
                {
                    LiveServerEventLiveSessionUpdated value => value.ClientEventId,
                    LiveServerEventLiveInputAudioMuted value => value.ClientEventId,
                    LiveServerEventLiveInputAudioUnmuted value => value.ClientEventId,
                    LiveServerEventLiveThinkingAppended value => value.ClientEventId,
                    LiveServerEventLiveCommentaryAppended value => value.ClientEventId,
                    LiveServerEventLiveInstructionsAppended value => value.ClientEventId,
                    _ => null
                };
                if (acknowledged != null && pending.Remove(acknowledged))
                {
                    await output.WriteLineAsync("Acknowledged: " + acknowledged);
                }
                if (serverEvent is LiveServerEventLiveSessionClosed)
                {
                    throw new InvalidOperationException("Live closed before acknowledging all session controls.");
                }
                if (pending.Count == 0)
                {
                    return;
                }
            }
            throw new InvalidOperationException("Live disconnected before acknowledging all session controls.");
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_StreamAudio
    public static async Task StreamAudioAsync(string projectEndpoint, string liveDeployment,
        string speechWavePath, string outputWavePath, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(CreateDefinition(liveDeployment)), cancellationToken: cancellationToken);
        try
        {
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = false }, cancellationToken);
            using Stream speechFile = File.OpenRead(speechWavePath);
            using MemoryStream output = new();
            await RunAudioConversationAsync(session, ReadPcmWave(speechFile), output, Console.Out, cancellationToken, streamAudio: true);
            if (output.Length == 0)
            {
                throw new InvalidOperationException("No speech audio was returned.");
            }
            using Stream waveFile = File.Create(outputWavePath);
            WritePcmWave(waveFile, output.ToArray());
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Cancellation
    public static async Task CancelReceiveAsync(string projectEndpoint, string liveDeployment, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(CreateDefinition(liveDeployment)), cancellationToken: cancellationToken);
        try
        {
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = false }, cancellationToken);
            using CancellationTokenSource receiving = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            receiving.CancelAfter(TimeSpan.FromMilliseconds(250));
            try
            {
                await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(receiving.Token))
                {
                    ThrowIfServiceFailure(serverEvent);
                }
                throw new InvalidOperationException("The session ended before the cancellation example ran.");
            }
            catch (OperationCanceledException) when (receiving.IsCancellationRequested && !cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Receive canceled; native finalization has not been confirmed. Create a new session to continue.");
            }
            session.Dispose();
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Stored
    public static async Task StoredConversationAsync(string projectEndpoint, string liveDeployment, string speechWavePath,
        string outputDirectory, bool synchronous, bool protocol, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        VoiceAgentLiveDefinition definition = CreateDefinition(liveDeployment);
        definition.Store = true;
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: cancellationToken);
        try
        {
            string conversationId;
            using (ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = true }, cancellationToken))
            {
                conversationId = session.SessionStarted.ConversationId;
                if (string.IsNullOrEmpty(conversationId))
                {
                    throw new InvalidOperationException("The service did not return a Foundry conversation ID.");
                }
                using Stream speechFile = File.OpenRead(speechWavePath);
                using MemoryStream output = new();
                await RunAudioConversationAsync(session, ReadPcmWave(speechFile), output, Console.Out, cancellationToken);
                if (output.Length == 0 || session.SessionClosed == null || session.State != WebSocketState.Closed)
                {
                    throw new InvalidOperationException("The stored audio conversation did not finish successfully.");
                }
            }
            BetaVoiceAgentsLiveConversations history = project.AgentAdministrationClient.GetBetaVoiceAgentEndpointLiveConversations();
            Console.WriteLine($"History shares agent pipeline: {ReferenceEquals(history.Pipeline, project.AgentAdministrationClient.Pipeline)}");
            Console.WriteLine($"Reading stored Live conversation {conversationId} using the {(protocol ? "protocol" : "typed")} {(synchronous ? "sync" : "async")} APIs.");
            if (synchronous)
            {
                if (protocol)
                {
                    Sample_VoiceAgent_Live_Conversations.ReadProtocol(history, agentName, conversationId, outputDirectory,
                        deleteConversation: true, cancellationToken);
                }
                else
                {
                    Sample_VoiceAgent_Live_Conversations.Read(history, agentName, conversationId, outputDirectory,
                        deleteConversation: true, cancellationToken);
                }
            }
            else if (protocol)
            {
                await Sample_VoiceAgent_Live_Conversations.ReadProtocolAsync(history, agentName, conversationId, outputDirectory,
                    deleteConversation: true, cancellationToken);
            }
            else
            {
                await Sample_VoiceAgent_Live_Conversations.ReadAsync(history, agentName, conversationId, outputDirectory,
                    deleteConversation: true, cancellationToken);
            }
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Audio
    public static async Task ConversationAsync(
        string projectEndpoint, string liveDeployment, string speechWavePath, string outputWavePath, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(CreateDefinition(liveDeployment)), cancellationToken: cancellationToken);
        try
        {
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = false }, cancellationToken);
            using Stream speechFile = File.OpenRead(speechWavePath);
            byte[] speech = ReadPcmWave(speechFile);
            using MemoryStream output = new();
            await session.SendEventAsync(new LiveClientEventLiveThinkingAppendParam(null,
                "This example has no connection to a live weather service.") { EventId = "sample-context" }, cancellationToken);
            await RunAudioConversationAsync(session, speech, output, Console.Out, cancellationToken);
            if (output.Length == 0)
            {
                throw new InvalidOperationException("No speech audio was returned.");
            }
            using Stream waveFile = File.Create(outputWavePath);
            WritePcmWave(waveFile, output.ToArray());
            Console.WriteLine($"\nActual speech input: {speech.Length} bytes; generated output: {output.Length} bytes.");
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Text
    public static async Task TextConversationAsync(
        string projectEndpoint, string liveDeployment, string backendDeployment, IEnumerable<string> prompts, CancellationToken cancellationToken)
    {
        if (prompts == null)
        {
            throw new ArgumentNullException(nameof(prompts));
        }
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        VoiceAgentLiveDefinition definition = CreateResponsesDefinition(liveDeployment, backendDeployment, tools: false);
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: cancellationToken);
        try
        {
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = false }, cancellationToken);
            await RunResponsesConversationAsync(session, prompts, Console.Out, handleTools: false, cancellationToken);
            await session.CloseAsync(cancellationToken);
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Function
    public static async Task FunctionAsync(
        string projectEndpoint, string liveDeployment, string backendDeployment, CancellationToken cancellationToken)
    {
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        string agentName = NewName();
        VoiceAgentLiveDefinition definition = CreateResponsesDefinition(liveDeployment, backendDeployment, tools: true);
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: cancellationToken);
        try
        {
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, cancellationToken: cancellationToken);
            await RunResponsesConversationAsync(session,
                ["Call get_test_value and report the verified result."], Console.Out, handleTools: true, cancellationToken);
            await session.CloseAsync(cancellationToken);
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
    }
    #endregion

    internal static async Task RunResponsesConversationAsync(ProjectsLiveSessionClient session, IEnumerable<string> prompts,
        TextWriter output, bool handleTools, CancellationToken cancellationToken)
    {
        if (prompts == null)
        {
            throw new ArgumentNullException(nameof(prompts));
        }
        HashSet<string> callIds = new(StringComparer.Ordinal);
        await using IAsyncEnumerator<LiveServerEvent> events = session.ReceiveEventsAsync(cancellationToken).GetAsyncEnumerator();
        foreach (string prompt in prompts)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Each scripted prompt must be nonempty.", nameof(prompts));
            }
            cancellationToken.ThrowIfCancellationRequested();
            await output.WriteLineAsync("You: " + prompt);
            await output.WriteAsync("Assistant: ");
            await session.SendEventAsync(new LiveClientEventLiveResponseItemCreateParam(
                ResponseItem.CreateUserMessageItem(prompt)), cancellationToken);
            await session.SendEventAsync(new LiveClientEventLiveResponseCreateParam(), cancellationToken);
            List<ResponseItem> pendingResults = new();
            int continuations = 0;
            bool complete = false;
            bool answerReceived = false;
            while (await events.MoveNextAsync())
            {
                LiveServerEvent serverEvent = events.Current;
                ThrowIfServiceFailure(serverEvent);
                if (serverEvent is LiveServerEventLiveSessionClosed closed)
                {
                    throw new InvalidOperationException($"Live session closed before the backend completed: {closed.Reason}.");
                }
                if (serverEvent is not LiveServerEventLiveResponseEvent envelope)
                {
                    continue;
                }
                string type = GetBackendType(envelope);
                if (type == "response.output_item.done")
                {
                    using JsonDocument item = JsonDocument.Parse(envelope.Event["item"]);
                    if (item.RootElement.GetProperty("type").GetString() == "function_call")
                    {
                        if (!handleTools)
                        {
                            throw new InvalidOperationException("The text sample does not execute function tools.");
                        }
                        pendingResults.Add(CreateToolResult(item.RootElement, callIds));
                    }
                }
                else if (type == "response.output_text.delta")
                {
                    string delta = envelope.Event["delta"].ToObjectFromJson<string>();
                    await output.WriteAsync(delta);
                    answerReceived |= !string.IsNullOrEmpty(delta);
                }
                else if (type == "response.completed")
                {
                    if (pendingResults.Count == 0)
                    {
                        if (!answerReceived || (handleTools && callIds.Count == 0))
                        {
                            throw new InvalidOperationException("The backend completed without the expected text or tool result.");
                        }
                        complete = true;
                        break;
                    }
                    if (++continuations > MaximumToolContinuations)
                    {
                        throw new InvalidOperationException("Sample tool continuation limit exceeded.");
                    }
                    #region Snippet:Sample_VoiceAgent_Live_ToolResults
                    // Finish the backend response before returning all pending results and continuing once.
                    foreach (ResponseItem result in pendingResults)
                    {
                        await session.SendEventAsync(new LiveClientEventLiveResponseItemCreateParam(result), cancellationToken);
                    }
                    pendingResults.Clear();
                    answerReceived = false;
                    await session.SendEventAsync(new LiveClientEventLiveResponseCreateParam(), cancellationToken);
                    #endregion
                }
            }
            if (!complete)
            {
                throw new InvalidOperationException("Live disconnected before the backend response completed.");
            }
            await output.WriteLineAsync();
        }
    }

    #region Snippet:Sample_VoiceAgent_Live_AudioTasks
    internal static async Task RunAudioConversationAsync(ProjectsLiveSessionClient session, byte[] speech, Stream output,
        TextWriter transcript, CancellationToken cancellationToken, bool streamAudio = false)
    {
        using CancellationTokenSource flow = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        Task<long> receiving = ReceiveAudioAsync(session, output, transcript, flow.Token);
        Task<long> feeding = streamAudio ? FeedAudioStreamAsync(session, speech, flow.Token) : FeedAudioAsync(session, speech, flow.Token);
        Task closing = CloseAfterAudioAsync(session, feeding, flow.Token);
        Task first = await Task.WhenAny(receiving, closing);
        if (first.IsFaulted || first.IsCanceled)
        {
            flow.Cancel();
        }
        await Task.WhenAll(receiving, closing);
        long inputBytes = await feeding;
        long outputBytes = await receiving;
        await transcript.WriteLineAsync($"Input audio sent: {inputBytes} bytes ({inputBytes / 1024.0:F1} KB), " +
            $"{inputBytes / 48000.0:F2}s PCM16LE / 24000 Hz / 1 channel");
        await transcript.WriteLineAsync($"Output audio received: {outputBytes} bytes ({outputBytes / 1024.0:F1} KB), " +
            $"{outputBytes / 48000.0:F2}s PCM16LE / 24000 Hz / 1 channel");
        await transcript.WriteLineAsync($"Total audio transferred: {inputBytes + outputBytes} bytes " +
            $"({(inputBytes + outputBytes) / 1024.0:F1} KB)");
    }
    #endregion

    internal static async Task<long> ReceiveAudioAsync(ProjectsLiveSessionClient session, Stream output, TextWriter transcript,
        CancellationToken cancellationToken)
    {
        long receivedBytes = 0;
        string speaker = null;
        async Task WriteCaptionAsync(string name, string delta)
        {
            if (speaker != name)
            {
                if (speaker != null)
                {
                    await transcript.WriteLineAsync();
                }
                await transcript.WriteAsync(name + ": ");
                speaker = name;
            }
            await transcript.WriteAsync(delta);
        }

        async Task WriteNoticeAsync(string message)
        {
            if (speaker != null)
            {
                await transcript.WriteLineAsync();
                speaker = null;
            }
            await transcript.WriteLineAsync(message);
        }

        await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(cancellationToken))
        {
            Console.WriteLine($"\nReceived event: {serverEvent.GetType().Name}");
            ThrowIfServiceFailure(serverEvent);
            switch (serverEvent)
            {
                case LiveOutputAudioDelta audio:
                    byte[] pcm = Convert.FromBase64String(audio.Delta);
                    if (pcm.Length % 2 != 0)
                    {
                        throw new InvalidDataException("Live PCM16 output ended in the middle of a sample.");
                    }
                    await output.WriteAsync(pcm, 0, pcm.Length, cancellationToken);
                    receivedBytes += pcm.Length;
                    break;
                case LiveServerEventLiveInputTranscriptDelta input:
                    await WriteCaptionAsync("You", input.Delta);
                    break;
                case LiveServerEventLiveOutputTranscriptDelta text:
                    await WriteCaptionAsync("Assistant", text.Delta);
                    break;
                case LiveServerEventLiveDelegationCreated delegation:
                    await session.SendEventAsync(new LiveClientEventLiveCommentaryAppendParam(delegation.Delegation.Id,
                        "This demonstration cannot look up current weather conditions."), cancellationToken);
                    break;
                case LiveServerEventLiveSessionClosed:
                    if (speaker != null)
                    {
                        await transcript.WriteLineAsync();
                    }
                    return receivedBytes;
                case LiveServerEventLiveSessionUsageUpdated usage:
                    await WriteNoticeAsync($"Cumulative Live audio usage: {usage.Usage.Seconds} seconds");
                    break;
                case LiveServerEventLiveInfoEvent notice:
                    await WriteNoticeAsync($"Live notice ({notice.Code}): {notice.Message}");
                    break;
                case LiveInputAudioAppend:
                    // Reflected input is not assistant output; do not play it back.
                    break;
                case LiveServerEventLiveResponseEvent:
                    // Backend text is not a spoken transcript.
                    break;
                default:
                    using (JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
                        serverEvent, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default)))
                    {
                        await WriteNoticeAsync("Live event: " + document.RootElement.GetProperty("type").GetString());
                    }
                    break;
            }
        }
        throw new InvalidOperationException("Live disconnected before native session finalization.");
    }

    private static ResponseItem CreateToolResult(JsonElement item, HashSet<string> callIds)
    {
        if (item.GetProperty("name").GetString() != "get_test_value")
        {
            throw new InvalidOperationException("Only the allowlisted get_test_value function may execute.");
        }
        using JsonDocument arguments = JsonDocument.Parse(item.GetProperty("arguments").GetString());
        if (arguments.RootElement.ValueKind != JsonValueKind.Object || arguments.RootElement.EnumerateObject().MoveNext())
        {
            throw new InvalidOperationException("get_test_value takes an empty JSON object as its arguments.");
        }
        string callId = item.GetProperty("call_id").GetString();
        if (string.IsNullOrWhiteSpace(callId) || !callIds.Add(callId))
        {
            throw new InvalidOperationException("Each function call must have a unique nonempty call_id.");
        }
        return ResponseItem.CreateFunctionCallOutputItem(callId, "{\"value\":7}");
    }

    private static string GetBackendType(LiveServerEventLiveResponseEvent envelope)
    {
        if (!envelope.Event.TryGetValue("type", out BinaryData value) || value == null)
        {
            throw new InvalidDataException("A delegated backend event must have a type.");
        }
        string type = value.ToObjectFromJson<string>();
        if (string.IsNullOrEmpty(type))
        {
            throw new InvalidDataException("A delegated backend event must have a nonempty type.");
        }
        if (type == "error")
        {
            string code = envelope.Event.TryGetValue("code", out BinaryData errorCode) && errorCode != null
                ? errorCode.ToObjectFromJson<string>() : null;
            string message = envelope.Event.TryGetValue("message", out BinaryData errorMessage) && errorMessage != null
                ? errorMessage.ToObjectFromJson<string>() : null;
            throw new InvalidOperationException($"Responses backend error (code={code ?? "<not supplied>"}): {message ?? "<not supplied>"}");
        }
        if (type is "response.failed" or "response.incomplete")
        {
            throw new InvalidOperationException($"The delegated backend did not complete: {type}.");
        }
        return type;
    }

    private static void ThrowIfServiceFailure(LiveServerEvent serverEvent)
    {
        if (serverEvent is LiveServerEventLiveErrorEvent error)
        {
            throw new InvalidOperationException($"Live error ({error.Error.Type}, code={error.Error.Code ?? "<not supplied>"}): {error.Error.Message}");
        }
    }

    private static string NewName() => ("dotnet-live-sample-" + Guid.NewGuid().ToString("N")).Substring(0, 40);

    private static VoiceAgentLiveDefinition CreateResponsesDefinition(string liveDeployment, string backendDeployment, bool tools)
    {
        LiveResponsesDelegationSettingsInputParam responses = new(backendDeployment)
        {
            Instructions = tools
                ? "Call get_test_value exactly once, then report its verified result."
                : "Answer each user message briefly and helpfully."
        };
        if (tools)
        {
            LiveFunctionToolInputParam function = new("get_test_value")
            {
                Strict = true,
                Parameters = new Dictionary<string, BinaryData>
                {
                    ["type"] = BinaryData.FromString("\"object\""),
                    ["properties"] = BinaryData.FromString("{}"),
                    ["required"] = BinaryData.FromString("[]"),
                    ["additionalProperties"] = BinaryData.FromString("false")
                }
            };
            responses.Tools.Add(ModelReaderWriter.Write(function, new ModelReaderWriterOptions("W"), AzureAIProjectsAgentsContext.Default));
            responses.ToolChoice = BinaryData.FromString("\"auto\"");
            responses.ParallelToolCalls = false;
        }
        VoiceAgentLiveDefinition definition = CreateDefinition(liveDeployment);
        definition.Instructions = "You are a helpful voice assistant. Delegate requests to the Responses backend.";
        definition.Delegation = ModelReaderWriter.Write(new LiveResponsesDelegationParam(responses),
            new ModelReaderWriterOptions("W"), AzureAIProjectsAgentsContext.Default);
        return definition;
    }

    private static VoiceAgentLiveDefinition CreateDefinition(string deployment) => new(deployment)
    {
        Instructions = "Answer briefly in English. Do not invent current weather or other unavailable information.",
        Audio = new LiveInitialSessionAudioParam
        {
            Format = new LiveSessionAudioFormatPCMParam(LiveSessionAudioFormatPCMParamRate._24000)
        }
    };

    private static async Task CloseAfterAudioAsync(ProjectsLiveSessionClient session, Task audio, CancellationToken cancellationToken)
    {
        await audio;
        await session.CloseAsync(cancellationToken);
    }

    private static async Task<long> FeedAudioAsync(ProjectsLiveSessionClient session, byte[] speech, CancellationToken cancellationToken)
    {
        const int chunkSize = 960;
        const int chunkMilliseconds = 20;
        byte[] silence = new byte[chunkSize];
        int offset = 0;
        long sentBytes = 0;
        int silenceChunksRemaining = 8000 / chunkMilliseconds;
        Stopwatch clock = Stopwatch.StartNew();
        while (offset < speech.Length || silenceChunksRemaining > 0)
        {
            TimeSpan chunkStarted = clock.Elapsed;
            int count = Math.Min(chunkSize, speech.Length - offset);
            BinaryData audio = count > 0 ? BinaryData.FromBytes(speech.AsMemory(offset, count)) : BinaryData.FromBytes(silence);
            await session.SendInputAudioAsync(audio, cancellationToken);
            sentBytes += audio.ToMemory().Length;
            offset += count;
            if (count == 0)
            {
                silenceChunksRemaining--;
            }
            TimeSpan delay = TimeSpan.FromMilliseconds(chunkMilliseconds) - (clock.Elapsed - chunkStarted);
            if (delay > TimeSpan.Zero)
            {
                await Task.Delay(delay, cancellationToken);
            }
        }
        return sentBytes;
    }

    #region Snippet:Sample_VoiceAgent_Live_StreamSend
    private static async Task<long> FeedAudioStreamAsync(ProjectsLiveSessionClient session, byte[] speech, CancellationToken cancellationToken)
    {
        using PacedPcmStream audio = new(speech);
        // The SDK reads until EOF and leaves this stream open; the caller supplies real-time pacing.
        await session.SendInputAudioAsync(audio, cancellationToken);
        return audio.BytesRead;
    }
    #endregion

    private static async Task FeedSilenceAsync(
        ProjectsLiveSessionClient session, CancellationToken stopToken, CancellationToken cancellationToken)
    {
        BinaryData silence = BinaryData.FromBytes(new byte[960]);
        while (true)
        {
            stopToken.ThrowIfCancellationRequested();
            await session.SendInputAudioAsync(silence, cancellationToken);
            await Task.Delay(TimeSpan.FromMilliseconds(20), stopToken);
        }
    }

    private sealed class PacedPcmStream : MemoryStream
    {
        private readonly Stopwatch _clock = Stopwatch.StartNew();
        private TimeSpan _nextRead;
        public long BytesRead { get; private set; }

        public PacedPcmStream(byte[] speech) : base(WithSilenceTail(speech), writable: false)
        {
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (Position == Length)
            {
                return 0;
            }
            TimeSpan delay = _nextRead - _clock.Elapsed;
            if (delay > TimeSpan.Zero)
            {
                await Task.Delay(delay, cancellationToken);
            }
            int read = await base.ReadAsync(buffer, offset, Math.Min(count, 960), cancellationToken);
            BytesRead += read;
            _nextRead = _clock.Elapsed + TimeSpan.FromSeconds(read / 48000.0);
            return read;
        }

        private static byte[] WithSilenceTail(byte[] speech)
        {
            byte[] bytes = new byte[checked(speech.Length + 48000 * 8)];
            Buffer.BlockCopy(speech, 0, bytes, 0, speech.Length);
            return bytes;
        }
    }

    private static byte[] ReadPcmWave(Stream stream)
    {
        using BinaryReader reader = new(stream, Encoding.ASCII, leaveOpen: true);
        if (new string(reader.ReadChars(4)) != "RIFF")
        {
            throw new InvalidDataException("A RIFF/WAVE speech file is required.");
        }
        reader.ReadUInt32();
        if (new string(reader.ReadChars(4)) != "WAVE")
        {
            throw new InvalidDataException("A WAVE speech file is required.");
        }
        bool pcm = false;
        while (reader.BaseStream.Position + 8 <= reader.BaseStream.Length)
        {
            string id = new(reader.ReadChars(4));
            uint size = reader.ReadUInt32();
            long end = reader.BaseStream.Position + size;
            if (id == "fmt ")
            {
                ushort format = reader.ReadUInt16();
                ushort channels = reader.ReadUInt16();
                uint rate = reader.ReadUInt32();
                reader.ReadUInt32();
                reader.ReadUInt16();
                pcm = format == 1 && channels == 1 && rate == 24000 && reader.ReadUInt16() == 16;
            }
            else if (id == "data")
            {
                if (!pcm || size == 0 || size % 2 != 0 || size > int.MaxValue)
                {
                    throw new InvalidDataException("Use mono PCM16LE/24 kHz speech.");
                }
                byte[] data = reader.ReadBytes((int)size);
                if (data.Length != size)
                {
                    throw new EndOfStreamException("The speech file is truncated.");
                }
                return data;
            }
            reader.BaseStream.Position = end + (size & 1);
        }
        throw new InvalidDataException("The speech file contains no PCM data.");
    }

    private static void WritePcmWave(Stream stream, byte[] pcm)
    {
        using BinaryWriter writer = new(stream, Encoding.ASCII, leaveOpen: true);
        writer.Write(Encoding.ASCII.GetBytes("RIFF"));
        writer.Write(36 + pcm.Length);
        writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
        writer.Write(16);
        writer.Write((short)1);
        writer.Write((short)1);
        writer.Write(24000);
        writer.Write(48000);
        writer.Write((short)2);
        writer.Write((short)16);
        writer.Write(Encoding.ASCII.GetBytes("data"));
        writer.Write(pcm.Length);
        writer.Write(pcm);
    }
}

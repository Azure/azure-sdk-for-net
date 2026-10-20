// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        TextWriter transcript, CancellationToken cancellationToken)
    {
        using CancellationTokenSource flow = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        Task receiving = ReceiveAudioAsync(session, output, transcript, flow.Token);
        Task feeding = FeedAudioAsync(session, speech, flow.Token);
        Task closing = CloseAfterAudioAsync(session, feeding, flow.Token);
        Task first = await Task.WhenAny(receiving, closing);
        if (first.IsFaulted || first.IsCanceled)
        {
            flow.Cancel();
        }
        await Task.WhenAll(receiving, closing);
    }
    #endregion

    internal static async Task ReceiveAudioAsync(ProjectsLiveSessionClient session, Stream output, TextWriter transcript,
        CancellationToken cancellationToken)
    {
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

        await foreach (LiveServerEvent serverEvent in session.ReceiveEventsAsync(cancellationToken))
        {
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
                    return;
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

    private static async Task FeedAudioAsync(ProjectsLiveSessionClient session, byte[] speech, CancellationToken cancellationToken)
    {
        const int chunkSize = 960;
        byte[] silence = new byte[chunkSize];
        int offset = 0;
        int chunks = 0;
        Stopwatch clock = Stopwatch.StartNew();
        TimeSpan duration = TimeSpan.FromSeconds(speech.Length / 48000.0 + 8);
        while (clock.Elapsed < duration)
        {
            int count = Math.Min(chunkSize, speech.Length - offset);
            BinaryData audio = count > 0 ? BinaryData.FromBytes(speech.AsMemory(offset, count)) : BinaryData.FromBytes(silence);
            await session.SendInputAudioAsync(audio, cancellationToken);
            offset += count;
            chunks++;
            TimeSpan delay = TimeSpan.FromMilliseconds(chunks * 20) - clock.Elapsed;
            if (delay > TimeSpan.Zero)
            {
                await Task.Delay(delay, cancellationToken);
            }
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

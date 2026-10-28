# Use GPT Live with a Foundry voice agent

Use `AIProjectClient.ProjectsLiveClient` to send text or audio to a GPT Live voice agent.
Realtime agents use `ProjectsRealtimeClient` instead; the two clients use different commands
and events.

The [complete sample](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Live.cs) includes the helpers
used below. To read saved conversations and download recordings, see the
[Live history samples](Sample_VoiceAgent_Live_Conversations.md).

## Prerequisites

- A Foundry project endpoint and a GPT Live model deployment, such as `gpt-live-1`.
- A Microsoft Entra ID identity with permission to create agents and connect to their voice endpoints.
  For local development, sign in with `az login`.
- `Azure.AI.Projects` and `Azure.Identity`.
- Experimental opt-ins `AAIP001`, `AAIP002`, and `OPENAI001` where used by the sample.
- For text and function calls, a separate Responses-compatible model deployment in the same resource.
- For audio, a mono, 16-bit PCM WAV file at 24 kHz. You can use the repository's
  [recorded weather question](../../../openai/Azure.AI.OpenAI/tests/Assets/whats_the_weather_pcm16_24khz_mono.wav).

Pass a cancellation token with a timeout. The examples create temporary agents and delete them
in `finally`.

## Choose an example

| Task | Sample method |
| --- | --- |
| [Connect and close a session](#connect-and-close-a-session) | `ConnectAsync` |
| [Send text messages](#send-text-messages) | `TextConversationAsync` |
| [Send and receive audio](#send-and-receive-audio) | `ConversationAsync` |
| [Call a function](#call-a-function) | `FunctionAsync` |
| [Set connection options](#set-connection-options) | `ConnectionOptionsAsync` |
| [Update instructions, mute audio, and send commands](#update-and-control-a-session) | `SessionControlsAsync` |
| [Stream audio from a file](#stream-audio-from-a-file) | `StreamAudioAsync` |
| [Cancel a receive](#cancel-a-receive) | `CancelReceiveAsync` |
| [Save a conversation and download recordings](#stored-live-history) | `StoredConversationAsync` |

## Connect and close a session

Use an `https://` project endpoint. The client uses the project's Microsoft Entra ID credentials
and an encrypted WebSocket connection; unencrypted endpoints are rejected.

`StartSessionAsync` returns after receiving `session.started`. Foundry starts the session from
the agent definition, so **do not send `session.start` yourself**.

```C# Snippet:Sample_VoiceAgent_Live_Connect
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
```

`CloseAsync` waits for `session.closed` and the WebSocket closing handshake. Final usage and the
close reason are available in `SessionClosed`; a closed socket alone does not confirm that Live
finished. `Dispose` releases the connection immediately; `DisposeAsync` tries graceful closure first.

## Send text messages

Send each message to the Responses model and wait for its response before sending the next.
The same Live session keeps the conversation across turns. This example returns text from the
Responses model, not spoken captions, and needs no microphone or speaker.

```C# Snippet:Sample_VoiceAgent_Live_Text
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
```

For example, call the method with two prompts and a bounded cancellation token:

```C#
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
await Sample_VoiceAgent_Live.TextConversationAsync(
    projectEndpoint, liveDeployment, backendDeployment,
    new[] { "Remember that the test value is seven.", "What test value did I ask you to remember?" },
    timeout.Token);
```

## Send and receive audio

Live sends and receives audio continuously. This example sends a WAV recording, receives
generated speech, and saves the response as a WAV file.

- Send raw audio without the WAV header. At 24 kHz, a 20 ms PCM16 chunk contains 960 bytes.
- Read base64 audio from `LiveOutputAudioDelta.Delta` and spoken captions from
  `LiveServerEventLiveOutputTranscriptDelta`. The sample labels captions as `You:` and `Assistant:`.
- Send text guidance with `session.thinking.append`, `session.commentary.append`, or
  `session.instructions.append`. Keep audio flowing while waiting for acknowledgments.
  An acknowledgment means the guidance was accepted, not spoken.
- Live has no `input_audio_buffer.commit`, frontend `response.create`, or audio-done event.

The sample prints event types, raw input/output/total audio bytes, duration, sample rate, and
channels. Input totals include the silence sent after the recording.

```C# Snippet:Sample_VoiceAgent_Live_Audio
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
```

Send, receive, and close concurrently. If a task fails, cancel and await the remaining tasks
before disposing the session:

```C# Snippet:Sample_VoiceAgent_Live_AudioTasks
internal static async Task RunAudioConversationAsync(ProjectsLiveSessionClient session, byte[] speech, Stream output,
    TextWriter transcript, CancellationToken cancellationToken, bool streamAudio = false)
{
    using CancellationTokenSource flow = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    Task<long> receiving = ReceiveAudioAsync(session, output, transcript, flow.Token);
    Task<long> feeding = streamAudio ? FeedAudioStreamAsync(session, speech, flow.Token) : FeedAudioAsync(session, speech, flow.Token);
    Task closing = CloseAfterAudioAsync(session, feeding, cancellationToken);
    Task first = await Task.WhenAny(receiving, closing);
    if (first == receiving || first.IsFaulted || first.IsCanceled)
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
```

The sample sends the whole recording, then eight seconds of silence before closing. This wait
is a sample policy, **not a speech-completion signal**, and may cut off long answers.
Silence advances the Live timeline and **is billable**. Always use a cancellation token with a timeout.

Use one receive loop per session. Concurrent sends are serialized. You can call `CloseAsync`
inside the receive loop; keep iterating afterward to collect final audio or usage events.
Canceling WebSocket I/O may abort the connection; create a new session rather than reusing it.

## Call a function

Set `delegation.type` to `responses` to handle function calls through a Responses model.
The `response.item.create` and `response.create` commands control that model, not spoken output.

1. Read completed function calls from `LiveServerEventLiveResponseEvent.Event` and validate their
   names and arguments. Completion snapshots do not contain the full output.
2. Wait for `response.completed`, then submit all tool results using the matching `call_id` values.
3. Send `response.create` once to continue. Do not start it from `response.output_item.done`.

```C# Snippet:Sample_VoiceAgent_Live_Function
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
```

The shared loop submits the results and continues once:

```C# Snippet:Sample_VoiceAgent_Live_ToolResults
// Wait for response.completed, then submit all tool results and continue once.
foreach (ResponseItem result in pendingResults)
{
    await session.SendEventAsync(new LiveClientEventLiveResponseItemCreateParam(result), cancellationToken);
}
pendingResults.Clear();
answerReceived = false;
await session.SendEventAsync(new LiveClientEventLiveResponseCreateParam(), cancellationToken);
```

`get_test_value` returns a demonstration value. The loop rejects duplicate calls, unexpected
tools or arguments, and missing answers; it limits continuation to eight rounds. Service errors
are reported immediately. A completed Responses answer does not mean Live finished speaking;
observe output audio and transcript events separately.

## Set connection options

Select an agent version, provide structured instruction values, and add a correlation header.
Set storage through `Store` or `QueryString`, not both. The SDK manages authentication, API
version, and preview headers; those values cannot be overridden.
`await using` calls `DisposeAsync` to try graceful shutdown.

```C# Snippet:Sample_VoiceAgent_Live_Options
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
        // DisposeAsync attempts graceful closure before releasing the connection.
        Console.WriteLine($"Closed: {session.State}; final usage: {session.SessionClosed.Usage.Seconds} seconds");
    }
    finally
    {
        await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
    }
}
```

```C# Snippet:Sample_VoiceAgent_Live_OptionsValues
internal static ProjectsLiveSessionClientOptions CreateConnectionOptions(string version)
{
    ProjectsLiveSessionClientOptions options = new()
    {
        AgentVersion = version,
        // Use either Store or the store query parameter, not both.
        QueryString = "store=false"
    };
    options.StructuredInputs["language"] = BinaryData.FromObjectAsJson("English");
    options.Headers["x-correlation-id"] = Guid.NewGuid().ToString();
    return options;
}
```

## Update and control a session

Use a Responses model for this example. Update its instructions, mute or unmute input audio,
and append text guidance. An active session cannot change its Live model, audio format, or
delegation owner.

The sample matches acknowledgments by client event ID and sends paced silence while waiting.
That silence is billable. Acknowledgments confirm that commands were accepted, not spoken.
`SendCommandAsync` also lets you send a raw JSON command.

```C# Snippet:Sample_VoiceAgent_Live_Controls
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
```

```C# Snippet:Sample_VoiceAgent_Live_ControlEvents
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
```

## Stream audio from a file

`SendInputAudioAsync(Stream)` reads raw audio until the stream ends and leaves it open.
You must pace the input; the SDK does not delay file reads. This example uses `PacedPcmStream`
for 20 ms chunks followed by eight seconds of silence, then saves the response as a WAV file.
Byte counts measure raw audio read from the stream, not WAV headers.

```C# Snippet:Sample_VoiceAgent_Live_StreamAudio
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
```

```C# Snippet:Sample_VoiceAgent_Live_StreamSend
private static async Task<long> FeedAudioStreamAsync(ProjectsLiveSessionClient session, byte[] speech, CancellationToken cancellationToken)
{
    using PacedPcmStream audio = new(speech);
    // The caller controls pacing; the SDK reads to the end and leaves the stream open.
    await session.SendInputAudioAsync(audio, cancellationToken);
    return audio.BytesRead;
}
```

## Cancel a receive

Canceling a receive may abort the WebSocket. Dispose that session and create a new one to
continue. Use `CloseAsync` or `DisposeAsync` when you need graceful shutdown.

```C# Snippet:Sample_VoiceAgent_Live_Cancellation
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
```

## Audio devices

These examples read and write WAV files; they do not capture a microphone or play audio.
For live audio devices, choose an audio I/O library and your own speech-boundary policy.
Live does not provide a speech-finished event.

## Stored Live history

`StoredConversationAsync` creates a temporary agent, saves an audio conversation with `Store = true`,
and downloads recordings using the [REST samples](Sample_VoiceAgent_Live_Conversations.md).
After closing, it waits up to 30 seconds for storage status `completed`. A failed status or
cancellation stops the read.

Use `SessionStarted.ConversationId`, **not** `SessionStarted.Session.Id`, to read history.
This example deletes its conversation after downloading both recordings and always deletes
the temporary agent.

```C# Snippet:Sample_VoiceAgent_Live_Stored
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
        await WaitForPersistenceAsync(history, agentName, conversationId, cancellationToken);
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
```

This helper waits for storage to finish after the WebSocket closes:

```C# Snippet:Sample_VoiceAgent_Live_Persistence
internal static async Task WaitForPersistenceAsync(
    BetaVoiceAgentsLiveConversations history, string agentName, string conversationId, CancellationToken cancellationToken)
{
    cancellationToken.ThrowIfCancellationRequested();
    using CancellationTokenSource finalization = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    finalization.CancelAfter(TimeSpan.FromSeconds(30));
    while (true)
    {
        ClientResult<VoiceAgentLiveConversation> result = await history.GetLiveAgentConversationAsync(
            agentName, conversationId, finalization.Token);
        VoiceAgentLiveConversation conversation = result.Value;
        Console.WriteLine($"GET persistence status: HTTP {result.GetRawResponse().Status}; {conversation.Status}");
        if (conversation.Id != conversationId)
        {
            throw new InvalidOperationException("The persisted Live conversation id does not match the stored session.");
        }
        if (conversation.Status == VoiceConversationStatus.Completed)
        {
            return;
        }
        if (conversation.Status != VoiceConversationStatus.InProgress)
        {
            throw new InvalidOperationException($"Stored Live conversation persistence finalization failed with status '{conversation.Status}'.");
        }
        await Task.Delay(TimeSpan.FromMilliseconds(500), finalization.Token);
    }
}
```

Select sync/async and typed/protocol REST methods with these flags. Each run creates a new conversation:

```C#
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(3));
await Sample_VoiceAgent_Live.StoredConversationAsync(
    projectEndpoint, liveDeployment, speechWavePath, outputDirectory,
    synchronous: false, protocol: false, cancellationToken: timeout.Token);
// synchronous: true  selects the synchronous REST overloads.
// protocol: true     selects raw ClientResult/RequestOptions overloads.
```

Live history uses `/voice/live/conversations`, not Realtime history routes. For HTTP 404, check the
conversation ID, storage setting, `completed` status, and Live history availability in your deployment.
Switching to Realtime history will not read a Live conversation.

## Handle events and errors

Session metadata identifies delegation as `client`, `responses`, or `foundry_managed_agent`.
For a managed agent, it includes the agent name and resolved version. Handle local delegation
requests only when `VoiceAgentLiveDelegationItem.Target` is `VoiceAgentLiveDelegationTarget.Client`;
the service handles the other known targets. Do not execute unknown targets locally.

Handle `LiveServerEventLiveErrorEvent` in the receive loop; an error event does not always close
the session. Authentication, connection, invalid-message, shutdown, and cancellation failures
are raised as exceptions.

JSON messages are limited to 16 MiB. Prefer typed events; use `SendCommandAsync` for commands
not yet modeled by the SDK.

# GPT Live REST and WebSocket API samples

These examples use the native Live protocol through `AIProjectClient.ProjectsLiveClient`.
The existing `ProjectsRealtimeClient` remains the client for Realtime agents; its commands,
events, and transport selection must not be used with Live agents.

The complete, compilable [WebSocket sample source](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Live.cs)
contains the helper methods used below. The [conversation REST samples](Sample_VoiceAgent_Live_Conversations.md)
cover all nine operations with synchronous/asynchronous and typed/protocol overloads.

## API-to-sample coverage

These are runnable samples, not a list of APIs covered only by tests. All public Live client
operations and connection options have examples. Generated model constructors/properties,
mocking constructors, and SIP-only transport events are not separate client operations.

| WebSocket API | Executable example |
| --- | --- |
| `AIProjectClient.ProjectsLiveClient`, `ProjectsLiveClient.StartSessionAsync` | `ConnectAsync`, and every session example |
| `ProjectsLiveClient.Endpoint`, `Pipeline` | `ConnectionOptionsAsync` |
| `ProjectsLiveSessionClientOptions.Store` | `ConnectAsync` (`false`), `StoredConversationAsync` (`true`) |
| `AgentVersion`, `StructuredInputs`, `Headers`, `QueryString` | `ConnectionOptionsAsync` |
| `SessionStarted`, `SessionClosed`, `State` | `ConnectAsync`, `ConnectionOptionsAsync`, `StoredConversationAsync` |
| `SendEventAsync` | `SessionControlsAsync`, `TextConversationAsync`, `FunctionAsync` |
| `SendCommandAsync` | Raw JSON command in `SessionControlsAsync` |
| `SendInputAudioAsync(BinaryData)` | `ConversationAsync` |
| `SendInputAudioAsync(Stream)` | `StreamAudioAsync`, with a caller-paced PCM stream |
| `ReceiveEventsAsync` | Audio, controls, text, function, and cancellation receive loops |
| `CloseAsync` | `ConnectAsync`; `SessionControlsAsync` also demonstrates a typed `session.close` command |
| `Dispose` | `CancelReceiveAsync` (immediate release) and `using` scopes |
| `DisposeAsync` / `IAsyncDisposable` | `ConnectionOptionsAsync` (`await using`, graceful finalization) |

| Native client command | Example |
| --- | --- |
| `session.start` | **Foundry sends this on behalf of the caller.** `ConnectAsync` waits for `session.started`; do not send a duplicate startup command. |
| `session.update` | `SessionControlsAsync`, updating only mutable Responses delegation settings |
| `session.input_audio.append` | Chunked and streamed audio examples |
| `session.input_audio.mute`, `session.input_audio.unmute` | `SessionControlsAsync` |
| `session.thinking.append`, `session.commentary.append`, `session.instructions.append` | `SessionControlsAsync`, with correlated acknowledgments |
| `response.item.create`, `response.create` | Multi-turn text and function/tool-result examples |
| `session.close` | `CloseAsync` or the explicit typed command in `SessionControlsAsync` |

The audio receiver handles output audio, input/output captions, client-delegation requests,
cumulative usage, notices, and closure. It does not play reflected input as assistant output or
print backend text as spoken captions. Unknown and non-audio events are identified by their wire
type rather than assuming every generated event will occur in each conversation.

## Prerequisites

- A Foundry project endpoint and a deployed native GPT Live model, such as `gpt-live-1`.
- An identity authorized to create agents and connect to their voice endpoints.
- `Azure.AI.Projects` and `Azure.Identity`.
- Experimental opt-ins `AAIP001`, `AAIP002`, and `OPENAI001` where the sample uses native
  Live models or OpenAI Responses items.
- For function calls, a separate Responses-compatible model deployment in the same resource.
- For speech, an actual mono PCM16LE/24 kHz WAV file. For repository validation, the existing
  speech recording at `sdk/openai/Azure.AI.OpenAI/tests/Assets/whats_the_weather_pcm16_24khz_mono.wav`
  is suitable; the sample strips and validates its WAV header rather than sending it as audio.

The methods create uniquely named temporary agents and delete them in `finally`.
Supply a bounded `CancellationToken`, for example from a two-minute `CancellationTokenSource`.

## Connect and finalize

The client targets `/agents/{agentName}/endpoint/protocols/voice/live/sessions`, uses the
project's bearer-token provider and `VoiceAgents=V1Preview`, and does not request a WebSocket
subprotocol. Foundry starts the session from the stored agent definition; the client waits for
`session.started` before returning. It does **not** send a duplicate `session.start`.

Use `ProjectsLiveSessionClientOptions.Store`, `AgentVersion`, and `StructuredInputs` for
Foundry handshake options. `QueryString` and `Headers` allow additional supported parameters;
managed authentication and API-version values cannot be overridden.

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

`CloseAsync` sends native `session.close`, waits for `session.closed`, preserves its final
usage/reason in `SessionClosed`, then completes the WebSocket closing handshake.
A closed transport without `session.closed` does not confirm native finalization.
`Dispose` immediately releases the socket; `DisposeAsync` attempts graceful closure first.

## Scripted multi-turn text

Like the scripted text examples in the Java SDK, this example sends each user message to the
Responses backend and waits for that backend response to complete before sending the next prompt.
The same Live session retains the backend conversation across turns.

This mode prints **backend text**, not frontend spoken captions, and needs no microphone or
speaker. It does not stream silent PCM while waiting for console input.

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

## Text guidance and actual audio

Live is continuous speech, not a Realtime-style request/response text chat:

- Text context is supplied through `session.thinking.append`, `session.commentary.append`,
  or `session.instructions.append`. A null delegation ID is still present in the JSON.
- An append acknowledgment means the guidance entered the timeline, not that speech finished.
- Keep correctly paced input audio flowing while expecting context acknowledgments.
- Send raw, headerless audio. At 24 kHz, each 20 ms PCM16 chunk contains 960 bytes.
- Receive audio from `LiveOutputAudioDelta`; its `Delta` is a base64 string.
  Spoken text arrives separately as `LiveServerEventLiveOutputTranscriptDelta`.
- Frontend transcript deltas are labeled `You:` and `Assistant:`. Backend notes are not
  printed as if they were spoken captions.
- There is no `input_audio_buffer.commit`, frontend `response.create`, or audio-done event.

This sample sends real recorded speech, continues with silence to advance the timeline,
captures generated PCM audio, and writes a valid WAV file. It also sends typed text guidance.
Like the Realtime audio example, it prints received event types and the actual input, output,
and total audio bytes with KB, sample rate, channels, and PCM duration. Input totals include
the silence that was actually sent. Unlike Realtime, Live sends and receives concurrently and
uses native session closure instead of committing an input buffer or starting a frontend response.
The WAV reader, writer, and pacing helpers are in the linked sample source.

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

The receiver, paced sender, and native-finalization task are coordinated so a failure cancels
and observes the other tasks instead of leaving audio sends running after disposal:

```C# Snippet:Sample_VoiceAgent_Live_AudioTasks
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
```

The recorded-audio example sends all input speech before adding eight seconds of silence as a
demonstration window. Backpressure can extend the elapsed time but does not truncate the input
or consume the silence tail. This is **not** a service speech-completion signal and can truncate
unusually long answers. Silent PCM advances the Live timeline and **voice usage remains billable**, including
while waiting. Always supply a bounded cancellation token.

Only one event enumeration can receive from a session at a time. Sends may run concurrently
and are serialized internally. `CloseAsync` can also be awaited inside the event-consumer loop.
Continue iterating afterward if final audio or usage events are needed. Canceling a WebSocket
I/O operation may abort its transport; create a new session rather than reconnecting the
disposed session object.

## Function calling through Responses delegation

Configure `delegation.type` as `responses`. The native `response.item.create` and
`response.create` commands operate on that delegated backend, not on frontend speech.

Consume granular backend events inside `LiveServerEventLiveResponseEvent.Event`.
For a completed function call, validate its name/arguments, return a matching `call_id`
using the existing OpenAI `ResponseItem`, then explicitly continue with `response.create`.
Collect all completed function items from one backend response first. Do not send the next
`response.create` from inside `response.output_item.done`; wait for `response.completed`,
return the entire pending result batch, and continue exactly once.
Lifecycle snapshots intentionally omit full output; do not recover tools from those snapshots.

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

The shared loop performs that ordering here:

```C# Snippet:Sample_VoiceAgent_Live_ToolResults
// Finish the backend response before returning all pending results and continuing once.
foreach (ResponseItem result in pendingResults)
{
    await session.SendEventAsync(new LiveClientEventLiveResponseItemCreateParam(result), cancellationToken);
}
pendingResults.Clear();
answerReceived = false;
await session.SendEventAsync(new LiveClientEventLiveResponseCreateParam(), cancellationToken);
```

The allowlisted function returns a deliberate test value, not external service data.
Duplicate call IDs, unsupported tools/arguments, missing final text, premature disconnects,
and more than eight continuation rounds fail explicitly. Native errors retain their type
and explanatory message even when the service omits an error code.
Wrapped Responses backend errors also fail immediately with their supplied code and message,
rather than waiting for the caller's timeout.
Backend completion does not establish that the Live model spoke the result or that a user
heard it; observe output transcript/audio events separately.

## Connection options and asynchronous disposal

This example pins the created agent version, defines a structured instruction input, supplies
its runtime value, and adds a non-secret correlation header. `QueryString = "store=false"` shows
the raw-query alternative to `Store = false`; do not set the same option in both places.
The final `await using` calls `DisposeAsync`, which performs native graceful shutdown.

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
        // DisposeAsync confirms native finalization before releasing the connection.
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
        // Store is used by the other examples; this shows its raw-query alternative.
        QueryString = "store=false"
    };
    options.StructuredInputs["language"] = BinaryData.FromObjectAsJson("English");
    options.Headers["x-correlation-id"] = Guid.NewGuid().ToString();
    return options;
}
```

## Session controls, updates, and raw commands

Use the existing Responses-compatible backend deployment for this example. An active session
can update Responses delegation settings, not its frontend model, audio format, or delegation
owner. Thinking/commentary/instructions append text to the Live timeline; their acknowledgments
are **not** proof that the model spoke the text.

The example correlates every acknowledgment to its client event ID. Paced silence keeps the
timeline moving while acknowledgments arrive; this consumes billable Live audio time. The
producer is stopped without canceling an in-flight WebSocket send. A missing acknowledgment,
native service error, or premature closure is surfaced rather than reported as success.

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

## Caller-paced stream audio

`SendInputAudioAsync(Stream)` reads raw bytes until EOF, leaves the stream owned by the caller,
and does not pace a file automatically. This runnable WAV example uses a sample-only
`PacedPcmStream` to provide 20 ms reads, followed by the same eight-second silence tail as the
chunked example. It sends no WAV header over the socket and writes returned PCM as a WAV.
Its input count comes from the bytes read by the completed stream send, not the WAV file size
or a duration estimate.

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
    // The SDK reads until EOF and leaves this stream open; the caller supplies real-time pacing.
    await session.SendInputAudioAsync(audio, cancellationToken);
    return audio.BytesRead;
}
```

## Cancel receiving and immediately dispose

This example deliberately cancels a pending receive. Cancellation may abort the WebSocket;
it is not a graceful-close acknowledgment, and the old session must not be reused.
Caller cancellation still propagates. Use `CloseAsync` or `DisposeAsync` instead when native
finalization is required.

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

## Interactive audio scope

These portable .NET examples use an actual WAV recording and a generated WAV file.
They do not capture a microphone, play speakers, or coordinate a console prompt with live
spoken output. The Java PR also demonstrates those device/UI scenarios.

Live has no native speech-finished event. The Java interactive examples use speech-inactivity
and PCM-level heuristics for greeting/utterance boundaries; these are application policies,
not protocol events. A .NET device sample would need an explicitly chosen audio I/O integration
and should not present those heuristics as guaranteed speech completion.

## Stored Live history

The end-to-end sample below creates a temporary Live agent with `Store = true` in both its
definition and connection options, sends actual speech, receives audio, confirms native and
transport finalization, and only then calls the [REST samples](Sample_VoiceAgent_Live_Conversations.md).
It uses `SessionStarted.ConversationId`, **not** the native `SessionStarted.Session.Id`.
The REST sample downloads item audio and the merged recording before deleting this sample's
conversation. The temporary agent is deleted in `finally`, including on a REST failure.

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

Choose one overload family per run; each run creates its own conversation:

```C#
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(3));
await Sample_VoiceAgent_Live.StoredConversationAsync(
    projectEndpoint, liveDeployment, speechWavePath, outputDirectory,
    synchronous: false, protocol: false, cancellationToken: timeout.Token);
// synchronous: true  selects the synchronous REST overloads.
// protocol: true     selects raw ClientResult/RequestOptions overloads.
```

Live history uses dedicated `/voice/live/conversations` routes and a different item schema
from Realtime. **Do not silently fall back to `/voice/conversations`.** An HTTP 404 from the
Live route is a failed REST sample, not a passing WebSocket-only result. Verify the returned
conversation ID, effective storage setting, persistence finalization, and availability of the
Live history routes in your deployment. The samples propagate REST failures rather than
rewriting the route or reporting a successful WebSocket connection as a successful history read.

## Errors and limits

After startup, native service errors are returned as `LiveServerEventLiveErrorEvent`.
Inspect the nested error code and optional client-event correlation rather than treating
every error event as a closed session. Authentication, failed upgrades, malformed frames,
unconfirmed graceful closure, and cancellation surface as exceptions.

The client bounds each JSON WebSocket message to 16 MiB and never buffers an entire
conversation. Raw JSON commands are available through `SendCommandAsync` for forward
compatibility; typed events should be preferred for modeled protocol messages.

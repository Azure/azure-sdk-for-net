# GPT Live Voice Agent connections, multi-turn text, real speech, and function calls

These examples use the native Live protocol through `AIProjectClient.ProjectsLiveClient`.
The existing `ProjectsRealtimeClient` remains the client for Realtime agents; its commands,
events, and transport selection must not be used with Live agents.

The complete, compilable [sample source](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Live.cs)
contains the helper methods used below.

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
```

The recorded-audio example sends all input speech before adding eight seconds of silence as a
demonstration window. Backpressure can extend the elapsed time but does not truncate the input
or consume the silence tail. This is **not** a service speech-completion signal and can truncate
unusually long answers. Silent PCM advances the Live timeline and **voice usage remains billable**, including
while waiting. Always supply a bounded cancellation token.

Only one event enumeration can receive from a session at a time. Sends may run concurrently
and are serialized internally. A receive loop can run concurrently with `CloseAsync`; finish
or dispose that enumeration so shutdown can drain remaining frames. Canceling a WebSocket
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

## Interactive audio scope

These portable .NET examples use an actual WAV recording and a generated WAV file.
They do not capture a microphone, play speakers, or coordinate a console prompt with live
spoken output. The Java PR also demonstrates those device/UI scenarios.

Live has no native speech-finished event. The Java interactive examples use speech-inactivity
and PCM-level heuristics for greeting/utterance boundaries; these are application policies,
not protocol events. A .NET device sample would need an explicitly chosen audio I/O integration
and should not present those heuristics as guaranteed speech completion.

## Stored Live history

Set `Store = true` to request Foundry persistence, then use the optional
`SessionStarted.ConversationId` with
`project.AgentAdministrationClient.GetBetaVoiceAgentEndpointLiveConversations()`.
This is different from the native `SessionStarted.Session.Id`.
Live history has its own `/voice/live/conversations` routes and must not be read through
the Realtime conversation client.

## Errors and limits

After startup, native service errors are returned as `LiveServerEventLiveErrorEvent`.
Inspect the nested error code and optional client-event correlation rather than treating
every error event as a closed session. Authentication, failed upgrades, malformed frames,
unconfirmed graceful closure, and cancellation surface as exceptions.

The client bounds each JSON WebSocket message to 16 MiB and never buffers an entire
conversation. Raw JSON commands are available through `SendCommandAsync` for forward
compatibility; typed events should be preferred for modeled protocol messages.

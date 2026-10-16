# Stream audio with a Foundry Voice Agent over WebSocket

This runnable sample explicitly selects `VoiceAgentTransport.Websocket`, streams five PCM audio
chunks to a voice agent, and logs the actual input and output audio bytes alongside every received
event. It sends a text request for the voice agent to answer aloud; the generated tone exercises
the incremental audio input path but is not speech to transcribe. Replace the tone with microphone
PCM chunks for speech input.

Set `FOUNDRY_PROJECT_ENDPOINT` to your Foundry project endpoint and `FOUNDRY_REALTIME_MODEL_NAME`
to a deployed realtime model. Suppress experimental diagnostics `AAIP001`, `AAIP002`, and `OPENAI002`
when building the sample.

1. Create an audio-modality voice agent with PCM16 audio at 24 kHz and one channel.

```C# Snippet:Sample_VoiceAgent_WebSocketAudio_Create
string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
const int audioSampleRate = 24000;
string agentName = $"voice-audio-sample-{Guid.NewGuid():N}".Substring(0, 40);
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());

VoiceAgentDefinition definition = new()
{
    ModelType = VoiceModelType.SelfDeployed,
    Model = modelDeploymentName,
    Instructions = "Respond briefly and helpfully.",
    Audio = new VoiceAgentAudioConfig
    {
        Input = new VoiceAgentAudioInputConfig
        {
            Format = new RealtimePcmAudioFormat { Rate = audioSampleRate }
        },
        Output = new VoiceAgentAudioOutputConfig
        {
            Format = new RealtimePcmAudioFormat { Rate = audioSampleRate }
        }
    }
};
definition.OutputModalities.Add(VoiceOutputModality.Audio);
ClientResult<ProjectsAgentVersion> createResult = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName, new ProjectsAgentVersionCreationOptions(definition));
ProjectsAgentVersion agentVersion = createResult;
Console.WriteLine($"Created voice agent {agentName} version {agentVersion.Version}: HTTP {createResult.GetRawResponse().Status}");
```

2. Send five 100 ms PCM16 chunks over the selected WebSocket connection. Count input bytes only
after each send succeeds, and count output bytes from the received audio delta payloads.

```C# Snippet:Sample_VoiceAgent_WebSocketAudio_Stream
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
ProjectsRealtimeSessionClientOptions options = new()
{
    Transport = VoiceAgentTransport.Websocket
};
using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)
    await projectClient.ProjectsRealtimeClient.StartSessionAsync(
        agentName, intent: null, options: options, cancellationToken: timeout.Token);
await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);

long inputAudioBytes = 0;
for (int chunkIndex = 0; chunkIndex < 5; chunkIndex++)
{
    int sampleCount = audioSampleRate / 10;
    byte[] toneChunk = new byte[sampleCount * sizeof(short)];
    for (int sampleIndex = 0; sampleIndex < sampleCount; sampleIndex++)
    {
        double seconds = (chunkIndex * sampleCount + sampleIndex) / (double)audioSampleRate;
        short sample = (short)(3000 * Math.Sin(2 * Math.PI * 440 * seconds));
        BinaryPrimitives.WriteInt16LittleEndian(toneChunk.AsSpan(sampleIndex * sizeof(short)), sample);
    }
    await session.SendInputAudioAsync(BinaryData.FromBytes(toneChunk), timeout.Token);
    inputAudioBytes += toneChunk.Length;
}
await session.StartResponseAsync(timeout.Token);

long outputAudioBytes = 0;
string transcript = string.Empty;
bool sawCompletedResponse = false;
await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
{
    Console.WriteLine($"Received event: {update.Kind}");
    if (update is RealtimeServerUpdateResponseOutputAudioDelta audioDelta)
    {
        outputAudioBytes += audioDelta.Delta.ToArray().Length;
    }
    else if (update is RealtimeServerUpdateResponseOutputAudioTranscriptDone transcriptDone)
    {
        transcript = transcriptDone.Transcript;
    }
    else if (update is RealtimeServerUpdateResponseDone doneUpdate)
    {
        Console.WriteLine($"Response status: {doneUpdate.Response.Status}");
        sawCompletedResponse = doneUpdate.Response.Status == RealtimeResponseStatus.Completed;
        break;
    }
}

const int channels = 1;
int bytesPerSecond = audioSampleRate * channels * sizeof(short);
Console.WriteLine($"Input audio sent: {inputAudioBytes} bytes ({inputAudioBytes / 1024.0:F1} KB), " +
    $"{inputAudioBytes / (double)bytesPerSecond:F2}s PCM16 / {audioSampleRate} Hz / {channels} channel");
Console.WriteLine($"Output audio received: {outputAudioBytes} bytes ({outputAudioBytes / 1024.0:F1} KB), " +
    $"{outputAudioBytes / (double)bytesPerSecond:F2}s PCM16 / {audioSampleRate} Hz / {channels} channel");
Console.WriteLine($"Total audio transferred: {inputAudioBytes + outputAudioBytes} bytes " +
    $"({(inputAudioBytes + outputAudioBytes) / 1024.0:F1} KB)");
Console.WriteLine($"Output transcript: {transcript}");
if (!sawCompletedResponse || inputAudioBytes == 0 || outputAudioBytes == 0)
{
    throw new InvalidOperationException("The voice agent did not complete an audio exchange.");
}
```

3. Delete the temporary agent version, including when the audio exchange fails.

```C# Snippet:Sample_VoiceAgent_WebSocketAudio_Cleanup
ClientResult deleteResult = await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(
    agentName: agentName, agentVersion: agentVersion.Version);
Console.WriteLine($"Deleted voice agent {agentName} version {agentVersion.Version}: HTTP {deleteResult.GetRawResponse().Status}");
```

Selecting `VoiceAgentTransport.Webrtc` instead changes the signaling transport only. It does not
send WebRTC media for you; a full WebRTC application needs a separate peer connection and SDP flow.

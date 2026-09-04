# Use a Foundry voice agent with REST and realtime APIs

This sample configures and manages a voice agent over REST, exchanges OpenAI Realtime GA events over its Foundry WebSocket endpoint, streams PCM audio, and reads persisted conversations and recordings.

Set `FOUNDRY_VOICE_AGENT_NAME` to run against an existing voice agent. In that mode, the sample uses the agent's latest version and does not create, disable, enable, or delete the agent.

When creating a temporary agent, set `FOUNDRY_VOICE_MODEL_TYPE` to `managed` for a service-managed model such as `gpt-realtime`. If omitted, the sample treats `FOUNDRY_MODEL_NAME` as a self-deployed Foundry model deployment.

1. Create a managed or self-deployed voice agent. Set `Store` to `true` when its conversations and audio should be available through the Foundry REST APIs.

```C# Snippet:Sample_VoiceAgent_Create
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
```

1. Retrieve the agent and its versions, and use the same enable and disable operations shared by other Foundry agent kinds.

```C# Snippet:Sample_VoiceAgent_Manage
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
```

1. Connect to the agent's real-time endpoint, add a text turn, and stream the PCM16 audio response. The raw event payload remains available through `Data` for forward compatibility.

```C# Snippet:Sample_VoiceAgent_Realtime
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
```

1. Set `FOUNDRY_VOICE_INPUT_AUDIO_PATH` to a raw PCM16, mono, 24 kHz input file to run the audio streaming turn. Set `FOUNDRY_VOICE_OUTPUT_AUDIO_PATH` to choose where the streamed PCM16 response is written; otherwise the sample uses the system temporary directory.

```C# Snippet:Sample_VoiceAgent_AudioStreaming
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
```

1. The streaming helper sends input and receives output concurrently. It accepts any `Stream`, so applications can replace the file streams with microphone and speaker adapters without adding an audio-device dependency to the SDK.

```C# Snippet:Sample_VoiceAgent_StreamAudio
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
```

1. Use the generated Foundry conversation client to retrieve conversations persisted by an agent configured with `Store = true`.

```C# Snippet:Sample_VoiceAgent_Conversations
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
```

1. Read a persisted conversation, its inference responses, and the ordered response and conversation items.

```C# Snippet:Sample_VoiceAgent_ReadConversation
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

        await foreach (RealtimeItem conversationItem in conversationsClient.GetAgentConversationResponseItemsAsync(
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

    await foreach (RealtimeItem conversationItem in conversationsClient.GetAgentConversationItemsAsync(
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
```

1. Retrieve whole-call or per-item recording metadata. Foundry-managed audio is returned as WAV content; when `BlobUri` is present, download the recording from the configured bring-your-own-storage account instead.

```C# Snippet:Sample_VoiceAgent_ReadAudio
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
```

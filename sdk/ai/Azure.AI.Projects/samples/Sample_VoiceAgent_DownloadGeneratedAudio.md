# Download audio generated before playback was interrupted

Use this Realtime REST feature when the agent generated more audio than the listener heard.
It downloads the retained `/audio/generated` artifact, not the ordinary heard-audio recording.

## Before you start

- Reference `Azure.AI.Projects` and `Azure.Identity` and authenticate a project with
  `DefaultAzureCredential`. These Realtime generated-audio REST operations are GA and do not
  require a Voice Agents preview opt-in.
- Create a stored Realtime conversation using a deployed voice agent.
- Interrupt audio playback and truncate the assistant item to the duration actually played.
- Wait for the conversation to finish persisting.
- Use the **persisted Foundry message ID** from the response's item list. Native Realtime item IDs
  are not interchangeable with REST message IDs.
- Supply a new output file path and a bounded cancellation token.

Create the REST client from an authenticated project:

```C#
BetaVoiceAgentsConversations conversations =
    project.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();
```

## Download the generated audio

```C# Snippet:Sample_VoiceAgent_DownloadGeneratedAudio
public static async Task DownloadAsync(
    BetaVoiceAgentsConversations conversations,
    string agentName, string conversationId, string itemId,
    string outputPath, CancellationToken cancellationToken)
{
    // Use the persisted Foundry message ID, not a native Realtime event item ID.
    VoiceGeneratedAudioItem metadata = await conversations.GetAgentConversationGeneratedAudioItemAsync(
        agentName, conversationId, itemId, cancellationToken);
    if (metadata.ConversationId != conversationId || metadata.ItemId != itemId ||
        metadata.DurationMs is null || metadata.DurationMs <= TimeSpan.Zero)
    {
        throw new InvalidOperationException("No generated audio artifact was returned for this item.");
    }
    if (metadata.BlobUri != null)
    {
        throw new NotSupportedException("This item uses customer storage. Download it with your storage credentials.");
    }

    BinaryData audio = await conversations.GetAgentConversationGeneratedAudioItemContentAsync(
        agentName, conversationId, itemId, cancellationToken);
    byte[] bytes = audio.ToArray();
    using FileStream file = new(outputPath, FileMode.CreateNew, FileAccess.Write);
    await file.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
    Console.WriteLine($"Saved generated audio: {bytes.Length} WAV bytes; duration {metadata.DurationMs}.");
}
```

The output is a WAV file. A missing artifact returns 404: cancellation alone does not guarantee
that the service retained unplayed audio. Customer-storage items must be downloaded using your
own storage credentials; the service content route returns 409 for those items.

The [complete sample](../tests/Samples/VoiceAgent/Sample_VoiceAgent_DownloadGeneratedAudio.cs)
is self-contained. Call `DownloadAsync` with the stored conversation/item IDs; it creates only
the requested output file and does not create or delete your agent or conversation.

For saved messages and responses, use the existing
[Read a conversation](Sample_VoiceAgent_ReadConversation.md) sample.

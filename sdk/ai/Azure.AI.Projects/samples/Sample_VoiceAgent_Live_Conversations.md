# Read saved GPT Live conversations and recordings

Use `BetaVoiceAgentsLiveConversations` to list saved conversations, read messages, and download
audio. The examples include synchronous, asynchronous, typed, and protocol methods.

To create and save an audio conversation first, use `StoredConversationAsync` in the
[Live guide](Sample_VoiceAgent_Live.md#stored-live-history). The examples below read an
existing conversation.

## Prerequisites

- A Foundry project and a Microsoft Entra ID identity with permission to read Live conversations.
- An audio conversation saved with `Store = true`. Keep the agent name and the returned
  `SessionStarted.ConversationId`. Text-only conversations have no speech segment to download.
- A closed session with storage status `completed`. Storage can still be `in_progress` after
  the WebSocket closes; use the wait helper in the Live guide before reading.
- **Foundry-managed storage.** These examples do not support bring-your-own-storage (BYOS),
  which requires your own storage credentials to access `BlobUri`.
- `Azure.AI.Projects`, `Azure.AI.Projects.Agents`, and `Azure.Identity`. Suppress experimental
  diagnostic `AAIP001`.

## Run an example

Copy the [complete sample class](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Live_Conversations.cs)
into your application; it is sample code, not part of the SDK. Set the environment variables
to your saved session's values, then call:

```C#
using System;
using System.IO;
using System.Threading;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Tests.Samples;
using Azure.Identity;

#pragma warning disable AAIP001

string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Set FOUNDRY_PROJECT_ENDPOINT.");
string agentName = Environment.GetEnvironmentVariable("LIVE_AGENT_NAME")
    ?? throw new InvalidOperationException("Set LIVE_AGENT_NAME to the agent that stored the session.");
string conversationId = Environment.GetEnvironmentVariable("LIVE_CONVERSATION_ID")
    ?? throw new InvalidOperationException("Set LIVE_CONVERSATION_ID to the returned session.started.conversation_id.");

AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
BetaVoiceAgentsLiveConversations history =
    project.AgentAdministrationClient.GetBetaVoiceAgentEndpointLiveConversations();
Console.WriteLine($"Shares agent pipeline: {ReferenceEquals(history.Pipeline, project.AgentAdministrationClient.Pipeline)}");
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));

await Sample_VoiceAgent_Live_Conversations.ReadAsync(
    history, agentName, conversationId,
    outputDirectory: Path.Combine(Environment.CurrentDirectory, "live-recordings"),
    deleteConversation: false,
    cancellationToken: timeout.Token);
```

Choose the method that matches your application:

| Method | API style |
| --- | --- |
| `ReadAsync` | Async, using C# models |
| `Read` | Sync, using C# models |
| `ReadProtocolAsync` | Async, using raw HTTP responses and `RequestOptions` |
| `ReadProtocol` | Sync, using raw HTTP responses and `RequestOptions` |

**Deletion is irreversible and disabled by default.** Set `deleteConversation: true` only if you
want to delete the conversation after both downloads succeed. Leave it disabled when trying
multiple examples against the same conversation.

## What each example does

1. List saved conversations and items, following all pages.
2. Read the selected conversation and its first input/output speech item.
3. Download that item's audio and the full conversation recording.
4. Optionally delete the conversation after both downloads succeed.

The SDK handles authentication, API version, and Live history routes. Live history uses
different models from Realtime history. Only speech items are selected for audio downloads;
tool results and unknown item kinds are not treated as audio.

## Typed asynchronous methods

```C# Snippet:Sample_VoiceAgent_Live_Conversations_ReadAsync
public static async Task ReadAsync(
    BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
    bool deleteConversation = false, CancellationToken cancellationToken = default)
{
    ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
    await foreach (VoiceAgentLiveConversation listed in client.GetLiveAgentConversationsAsync(
        agentName, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
    {
        ReportConversation(listed);
    }

    ClientResult<VoiceAgentLiveConversation> conversation = await client.GetLiveAgentConversationAsync(
        agentName, conversationId, cancellationToken);
    ReportStatus("GET conversation", conversation);
    ValidateConversation(conversation.Value, conversationId);

    VoiceAgentLiveConversationItem speechItem = null;
    await foreach (VoiceAgentLiveConversationItem item in client.GetLiveAgentConversationItemsAsync(
        agentName, conversationId, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
    {
        ReportItem(item);
        if (speechItem == null && IsSpeechItem(item))
        {
            speechItem = item;
        }
    }
    string itemId = RequireSpeechItem(speechItem);

    ClientResult<VoiceAgentLiveConversationItem> retrievedItem = await client.GetLiveAgentConversationItemAsync(
        agentName, conversationId, itemId, cancellationToken);
    ReportStatus("GET item", retrievedItem);
    ValidateRetrievedItem(retrievedItem.Value, itemId);

    ClientResult<VoiceAudioItem> segment = await client.GetLiveAgentConversationAudioItemAsync(
        agentName, conversationId, itemId, cancellationToken);
    ReportStatus("GET item audio metadata", segment);
    ValidateSegment(segment.Value, conversationId, itemId);

    ClientResult<BinaryData> segmentContent = await client.GetLiveAgentConversationAudioItemContentAsync(
        agentName, conversationId, itemId, cancellationToken);
    ReportStatus("GET item audio content", segmentContent);
    await SaveAudioAsync(outputDirectory, "segment.wav", segmentContent.Value, cancellationToken);

    ClientResult<VoiceRecording> recording = await client.GetLiveAgentConversationAudioAsync(
        agentName, conversationId, cancellationToken);
    ReportStatus("GET recording metadata", recording);
    ValidateRecording(recording.Value, conversationId);

    ClientResult<BinaryData> recordingContent = await client.GetLiveAgentConversationAudioContentAsync(
        agentName, conversationId, cancellationToken);
    ReportStatus("GET recording content", recordingContent);
    await SaveAudioAsync(outputDirectory, "conversation.wav", recordingContent.Value, cancellationToken);

    if (deleteConversation)
    {
        ClientResult deleted = await client.DeleteLiveAgentConversationAsync(agentName, conversationId, cancellationToken);
        ReportStatus("DELETE conversation", deleted);
    }
}
```

## Typed synchronous methods

```C# Snippet:Sample_VoiceAgent_Live_Conversations_Read
public static void Read(
    BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
    bool deleteConversation = false, CancellationToken cancellationToken = default)
{
    ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
    foreach (VoiceAgentLiveConversation listed in client.GetLiveAgentConversations(
        agentName, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
    {
        ReportConversation(listed);
    }

    ClientResult<VoiceAgentLiveConversation> conversation = client.GetLiveAgentConversation(
        agentName, conversationId, cancellationToken);
    ReportStatus("GET conversation", conversation);
    ValidateConversation(conversation.Value, conversationId);

    VoiceAgentLiveConversationItem speechItem = null;
    foreach (VoiceAgentLiveConversationItem item in client.GetLiveAgentConversationItems(
        agentName, conversationId, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
    {
        ReportItem(item);
        if (speechItem == null && IsSpeechItem(item))
        {
            speechItem = item;
        }
    }
    string itemId = RequireSpeechItem(speechItem);

    ClientResult<VoiceAgentLiveConversationItem> retrievedItem = client.GetLiveAgentConversationItem(
        agentName, conversationId, itemId, cancellationToken);
    ReportStatus("GET item", retrievedItem);
    ValidateRetrievedItem(retrievedItem.Value, itemId);

    ClientResult<VoiceAudioItem> segment = client.GetLiveAgentConversationAudioItem(
        agentName, conversationId, itemId, cancellationToken);
    ReportStatus("GET item audio metadata", segment);
    ValidateSegment(segment.Value, conversationId, itemId);

    ClientResult<BinaryData> segmentContent = client.GetLiveAgentConversationAudioItemContent(
        agentName, conversationId, itemId, cancellationToken);
    ReportStatus("GET item audio content", segmentContent);
    SaveAudio(outputDirectory, "segment.wav", segmentContent.Value, cancellationToken);

    ClientResult<VoiceRecording> recording = client.GetLiveAgentConversationAudio(
        agentName, conversationId, cancellationToken);
    ReportStatus("GET recording metadata", recording);
    ValidateRecording(recording.Value, conversationId);

    ClientResult<BinaryData> recordingContent = client.GetLiveAgentConversationAudioContent(
        agentName, conversationId, cancellationToken);
    ReportStatus("GET recording content", recordingContent);
    SaveAudio(outputDirectory, "conversation.wav", recordingContent.Value, cancellationToken);

    if (deleteConversation)
    {
        ClientResult deleted = client.DeleteLiveAgentConversation(agentName, conversationId, cancellationToken);
        ReportStatus("DELETE conversation", deleted);
    }
}
```

## Protocol asynchronous methods

Protocol methods pass cancellation through `RequestOptions` and expose raw HTTP responses.
The SDK still handles pagination. The helpers parse JSON into SDK models and save audio bytes
from `GetRawResponse().Content`.

```C# Snippet:Sample_VoiceAgent_Live_Conversations_ReadProtocolAsync
public static async Task ReadProtocolAsync(
    BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
    bool deleteConversation = false, CancellationToken cancellationToken = default)
{
    ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
    RequestOptions options = new() { CancellationToken = cancellationToken };
    await foreach (ClientResult page in client.GetLiveAgentConversationsAsync(
        agentName, 2, "asc", null, null, options).GetRawPagesAsync())
    {
        ReportStatus("GET conversations page", page);
        foreach (VoiceAgentLiveConversation listed in ReadPage<VoiceAgentLiveConversation>(page))
        {
            ReportConversation(listed);
        }
    }

    ClientResult conversation = await client.GetLiveAgentConversationAsync(agentName, conversationId, options);
    ReportStatus("GET conversation", conversation);
    ValidateConversation(ReadModel<VoiceAgentLiveConversation>(conversation), conversationId);

    VoiceAgentLiveConversationItem speechItem = null;
    await foreach (ClientResult page in client.GetLiveAgentConversationItemsAsync(
        agentName, conversationId, 2, "asc", null, null, options).GetRawPagesAsync())
    {
        ReportStatus("GET items page", page);
        foreach (VoiceAgentLiveConversationItem item in ReadPage<VoiceAgentLiveConversationItem>(page))
        {
            ReportItem(item);
            if (speechItem == null && IsSpeechItem(item))
            {
                speechItem = item;
            }
        }
    }
    string itemId = RequireSpeechItem(speechItem);

    ClientResult retrievedItem = await client.GetLiveAgentConversationItemAsync(agentName, conversationId, itemId, options);
    ReportStatus("GET item", retrievedItem);
    ValidateRetrievedItem(ReadModel<VoiceAgentLiveConversationItem>(retrievedItem), itemId);

    ClientResult segment = await client.GetLiveAgentConversationAudioItemAsync(agentName, conversationId, itemId, options);
    ReportStatus("GET item audio metadata", segment);
    ValidateSegment(ReadModel<VoiceAudioItem>(segment), conversationId, itemId);

    ClientResult segmentContent = await client.GetLiveAgentConversationAudioItemContentAsync(agentName, conversationId, itemId, options);
    ReportStatus("GET item audio content", segmentContent);
    await SaveAudioAsync(outputDirectory, "segment.wav", segmentContent.GetRawResponse().Content, cancellationToken);

    ClientResult recording = await client.GetLiveAgentConversationAudioAsync(agentName, conversationId, options);
    ReportStatus("GET recording metadata", recording);
    ValidateRecording(ReadModel<VoiceRecording>(recording), conversationId);

    ClientResult recordingContent = await client.GetLiveAgentConversationAudioContentAsync(agentName, conversationId, options);
    ReportStatus("GET recording content", recordingContent);
    await SaveAudioAsync(outputDirectory, "conversation.wav", recordingContent.GetRawResponse().Content, cancellationToken);

    if (deleteConversation)
    {
        ClientResult deleted = await client.DeleteLiveAgentConversationAsync(agentName, conversationId, options);
        ReportStatus("DELETE conversation", deleted);
    }
}
```

## Protocol synchronous methods

```C# Snippet:Sample_VoiceAgent_Live_Conversations_ReadProtocol
public static void ReadProtocol(
    BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
    bool deleteConversation = false, CancellationToken cancellationToken = default)
{
    ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
    RequestOptions options = new() { CancellationToken = cancellationToken };
    foreach (ClientResult page in client.GetLiveAgentConversations(
        agentName, 2, "asc", null, null, options).GetRawPages())
    {
        ReportStatus("GET conversations page", page);
        foreach (VoiceAgentLiveConversation listed in ReadPage<VoiceAgentLiveConversation>(page))
        {
            ReportConversation(listed);
        }
    }

    ClientResult conversation = client.GetLiveAgentConversation(agentName, conversationId, options);
    ReportStatus("GET conversation", conversation);
    ValidateConversation(ReadModel<VoiceAgentLiveConversation>(conversation), conversationId);

    VoiceAgentLiveConversationItem speechItem = null;
    foreach (ClientResult page in client.GetLiveAgentConversationItems(
        agentName, conversationId, 2, "asc", null, null, options).GetRawPages())
    {
        ReportStatus("GET items page", page);
        foreach (VoiceAgentLiveConversationItem item in ReadPage<VoiceAgentLiveConversationItem>(page))
        {
            ReportItem(item);
            if (speechItem == null && IsSpeechItem(item))
            {
                speechItem = item;
            }
        }
    }
    string itemId = RequireSpeechItem(speechItem);

    ClientResult retrievedItem = client.GetLiveAgentConversationItem(agentName, conversationId, itemId, options);
    ReportStatus("GET item", retrievedItem);
    ValidateRetrievedItem(ReadModel<VoiceAgentLiveConversationItem>(retrievedItem), itemId);

    ClientResult segment = client.GetLiveAgentConversationAudioItem(agentName, conversationId, itemId, options);
    ReportStatus("GET item audio metadata", segment);
    ValidateSegment(ReadModel<VoiceAudioItem>(segment), conversationId, itemId);

    ClientResult segmentContent = client.GetLiveAgentConversationAudioItemContent(agentName, conversationId, itemId, options);
    ReportStatus("GET item audio content", segmentContent);
    SaveAudio(outputDirectory, "segment.wav", segmentContent.GetRawResponse().Content, cancellationToken);

    ClientResult recording = client.GetLiveAgentConversationAudio(agentName, conversationId, options);
    ReportStatus("GET recording metadata", recording);
    ValidateRecording(ReadModel<VoiceRecording>(recording), conversationId);

    ClientResult recordingContent = client.GetLiveAgentConversationAudioContent(agentName, conversationId, options);
    ReportStatus("GET recording content", recordingContent);
    SaveAudio(outputDirectory, "conversation.wav", recordingContent.GetRawResponse().Content, cancellationToken);

    if (deleteConversation)
    {
        ClientResult deleted = client.DeleteLiveAgentConversation(agentName, conversationId, options);
        ReportStatus("DELETE conversation", deleted);
    }
}
```

## Downloaded files and troubleshooting

The sample creates `outputDirectory` and saves:

- `segment.wav`: audio from the selected speech item.
- `conversation.wav`: the full recording, with the user on the left channel and the agent on the right.

Existing files with these names are overwritten. Keep recordings in a private directory.
The sample prints HTTP statuses, IDs, audio metadata, and byte counts, but not transcripts,
credentials, audio contents, or BYOS URIs.

Missing speech items, invalid responses, mismatched IDs, BYOS storage, and empty downloads fail
the call. Service errors and cancellation are propagated. If a later step fails, an earlier
download can remain on disk; deletion is attempted only after both recordings are saved.

For HTTP 404, check the conversation ID, storage setting, `completed` status, and Live history
availability in your deployment. Live conversations cannot be read through Realtime history routes.

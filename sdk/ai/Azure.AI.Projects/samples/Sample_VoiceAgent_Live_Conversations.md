# Stored Live conversations and audio: every REST overload

The [complete, compilable sample source](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Live_Conversations.cs)
demonstrates all **nine** `BetaVoiceAgentsLiveConversations` REST operation groups in
all **four** public overload families: synchronous/asynchronous typed methods taking a
`CancellationToken`, and synchronous/asynchronous protocol methods taking `RequestOptions`.
That is **36 SDK methods**, not counting response-status accessors or parsing helpers.

For creating an agent, connecting over WebSocket, sending actual speech, and capturing
`session.started.conversation_id`, see the [Live guide](Sample_VoiceAgent_Live.md) and its
[WebSocket source](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Live.cs), particularly
`StoredConversationAsync`. The REST samples read an existing conversation; they do not
create an empty substitute or change the project's endpoint.

## Prerequisites and callable usage

- A Foundry project endpoint and an identity authorized to read the agent's Live conversations.
- A native Live agent and an actual speech session stored with effective `Store = true`.
  Save the **returned** `session.started.conversation_id` and the agent name. Neither a
  fabricated ID nor a text-only delegation is a substitute for a stored speech segment.
- Close the session and wait for persistence finalization to reach `completed`. A session
  can remain `in_progress` after transport closure while finalization is pending. These
  samples fail explicitly for non-completed or failed persistence.
- **Foundry-managed storage** for both the segment and whole-call recording. Bring-your-own-storage (BYOS) metadata
  contains `BlobUri` without a SAS token and requires the customer's own storage credentials.
  These samples throw `NotSupportedException` for BYOS rather than following or logging the URI.
- `Azure.AI.Projects`, `Azure.AI.Projects.Agents`, and `Azure.Identity`, and the sample class
  from the linked source. The sample is not a class shipped inside the client library.
  Acknowledge the experimental `AAIP001` APIs.

For example, set the environment variables to values captured from your real stored session,
copy the complete sample class into your application, and call:

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

Replace `ReadAsync` with `Read`, `ReadProtocolAsync`, or `ReadProtocol` to run the other
families against that same stored conversation. Await only the asynchronous methods.
The synchronous methods do not block on an asynchronous implementation.

**Deletion is irreversible and defaults to `false` in every sample.** Only explicitly set
`deleteConversation: true` if you intend to delete this stored conversation after both audio
downloads have succeeded. Do not enable it while comparing all four families against one ID:
once a sample deletes that conversation, later reads of the same ID cannot succeed.

## API-to-sample coverage

All paths below are relative to the project's
`/agents/{agentName}/endpoint/protocols/voice/live/conversations` route.
The client supplies the API version, project authentication, and
`Foundry-Features: VoiceAgents=V1Preview`; the samples do not construct a Realtime URL.

| REST operation | Typed sync: `Read` (`CancellationToken`) | Typed async: `ReadAsync` (`CancellationToken`) | Protocol sync: `ReadProtocol` (`RequestOptions`) | Protocol async: `ReadProtocolAsync` (`RequestOptions`) |
| --- | --- | --- | --- | --- |
| GET conversations | `GetLiveAgentConversations` | `GetLiveAgentConversationsAsync` | `GetLiveAgentConversations` | `GetLiveAgentConversationsAsync` |
| GET `/{conversationId}` | `GetLiveAgentConversation` | `GetLiveAgentConversationAsync` | `GetLiveAgentConversation` | `GetLiveAgentConversationAsync` |
| GET `/{conversationId}/items` | `GetLiveAgentConversationItems` | `GetLiveAgentConversationItemsAsync` | `GetLiveAgentConversationItems` | `GetLiveAgentConversationItemsAsync` |
| GET `/{conversationId}/items/{itemId}` | `GetLiveAgentConversationItem` | `GetLiveAgentConversationItemAsync` | `GetLiveAgentConversationItem` | `GetLiveAgentConversationItemAsync` |
| GET `/{conversationId}/items/{itemId}/audio` | `GetLiveAgentConversationAudioItem` | `GetLiveAgentConversationAudioItemAsync` | `GetLiveAgentConversationAudioItem` | `GetLiveAgentConversationAudioItemAsync` |
| GET `/{conversationId}/items/{itemId}/audio/content` | `GetLiveAgentConversationAudioItemContent` | `GetLiveAgentConversationAudioItemContentAsync` | `GetLiveAgentConversationAudioItemContent` | `GetLiveAgentConversationAudioItemContentAsync` |
| GET `/{conversationId}/audio` | `GetLiveAgentConversationAudio` | `GetLiveAgentConversationAudioAsync` | `GetLiveAgentConversationAudio` | `GetLiveAgentConversationAudioAsync` |
| GET `/{conversationId}/audio/content` | `GetLiveAgentConversationAudioContent` | `GetLiveAgentConversationAudioContentAsync` | `GetLiveAgentConversationAudioContent` | `GetLiveAgentConversationAudioContentAsync` |
| DELETE `/{conversationId}` (explicit opt-in, last) | `DeleteLiveAgentConversation` | `DeleteLiveAgentConversationAsync` | `DeleteLiveAgentConversation` | `DeleteLiveAgentConversationAsync` |

Each method enumerates conversations and items with `limit: 2` and ascending order, letting
the SDK follow every continuation page. It verifies the requested conversation's identity and
completed status, selects the **first actual input/output speech item from history**, retrieves
that same item, reads segment metadata and bytes, then reads merged recording metadata and bytes.
Only then can the optional DELETE run.

The generated native Live DTOs are `VoiceAgentLiveConversation`,
`VoiceAgentLiveConversationItem`, `VoiceAgentLiveInputConversationItem`,
`VoiceAgentLiveOutputConversationItem`, `VoiceAudioItem`, and `VoiceRecording`.
They are **not Realtime conversation items or native turn resources**. Delegation results and
unknown items are not interpreted as speech. Unsupported item kinds rejected by generated
deserialization also propagate as failures, rather than being treated as audio.

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

The protocol examples pass all paging parameters explicitly and put the caller's token in
`RequestOptions.CancellationToken`. `GetRawPagesAsync`/`GetRawPages` preserve SDK pagination.
The shared `ReadPage<T>` helper parses `GetRawResponse().Content` with `JsonDocument` and
deserializes entries with `ModelReaderWriter`; `ReadModel<T>` also reads the raw response
content into the same generated DTOs. No alternate handwritten wire models are needed.
Audio content is taken directly from `GetRawResponse().Content`.

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

## Output, failures, and deployment availability

The shared helpers in the [source](../tests/Samples/VoiceAgent/Sample_VoiceAgent_Live_Conversations.cs)
create `outputDirectory` and write the returned WAV content to constant local filenames:

- `segment.wav`: the selected stored input/output speech segment.
- `conversation.wav`: the merged whole-call recording (user left channel, agent right channel).

These names are overwritten on a successful download; server-provided item IDs are never used
as local paths. Store these recordings in a private directory. The sample reports HTTP status,
conversation/item IDs, lifecycle status, basic audio metadata, and downloaded byte counts, but
does not print transcripts, authorization tokens, audio bytes, or BYOS blob URIs.
The asynchronous file writer uses `FileStream.WriteAsync`, including on .NET Framework.

Empty history with no speech item, malformed responses, mismatched resource IDs, BYOS metadata,
and zero-byte downloads are explicit failures. A service error or cancellation propagates;
there is no silent skip and no `finally` block that deletes the conversation after failure.
An earlier successful download can remain on disk if a later step fails. Even when deletion
is enabled, it is attempted only after both nonempty downloads have been saved.

**Deployment availability:** an HTTP 404 raises `ClientResultException`; it is not a successful
sample run. Verify the returned conversation ID, effective storage setting, persistence
finalization, and availability of the Live history routes in your deployment.
These examples do not rewrite endpoints, switch to Realtime, or use a legacy fallback.
The [mocked sample tests](../tests/VoiceAgentLiveConversationSampleTests.cs) validate all 36 SDK
methods, pagination, download bytes, deletion ordering, and these failure paths without
substituting mocked success for a real-service sample run.

# Read a voice agent's saved conversation

Save a Realtime conversation with `store=true`, close the session, and read its messages and
responses using `BetaVoiceAgentsConversations`. Reading saved history uses REST, not a WebSocket.
This sample also demonstrates explicit WebSocket transport selection and cleanup of a temporary
agent.

Follow the [Realtime prerequisites and authentication guidance](Sample_VoiceAgent.md#prerequisites).
The [complete sample](../tests/Samples/VoiceAgent/Sample_VoiceAgent_ReadConversation.cs)
includes client setup and cleanup.

Choose a unique agent name, set a timeout, and create the project client:

```C# Snippet:Sample_VoiceAgent_ReadConversation_Initialize
string agentName = $"voice-h-{Guid.NewGuid():N}";
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));

AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

1. Create a temporary voice agent that returns text.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Create
VoiceAgentDefinition definition = new()
{
    ModelType = VoiceModelType.SelfDeployed,
    Model = modelDeploymentName,
    Instructions = "Respond briefly and helpfully.",
};
definition.OutputModalities.Add(VoiceOutputModality.Text);
ClientResult<ProjectsAgentVersion> created = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: timeout.Token);
Console.WriteLine($"Created voice agent {created.Value.Name}: HTTP {created.GetRawResponse().Status}");
```

2. Select `VoiceAgentTransport.Websocket`, start a session with `store=true`, and capture the
conversation ID from a completed `response.done` event.

```C# Snippet:Sample_VoiceAgent_ReadConversation_HoldSession
ProjectsRealtimeSessionClientOptions options = new()
{
    Transport = VoiceAgentTransport.Websocket,
    QueryString = "store=true"
};
string conversationId = null;
using (ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)
    await projectClient.ProjectsRealtimeClient.StartSessionAsync(
        agentName, intent: null, options: options, cancellationToken: timeout.Token))
{
    await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);
    await session.StartResponseAsync(timeout.Token);

    string responseText = string.Empty;
    bool completed = false;
    await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
    {
        Console.WriteLine($"Received event: {update.Kind}");
        if (update is RealtimeServerUpdateResponseOutputTextDone text)
        {
            responseText = text.Text;
        }
        else if (update is RealtimeServerUpdateResponseDone done)
        {
            completed = done.Response.Status == RealtimeResponseStatus.Completed;
            conversationId = done.Response.ConversationId;
            break;
        }
    }
    if (!completed || string.IsNullOrWhiteSpace(responseText) || string.IsNullOrWhiteSpace(conversationId))
    {
        throw new InvalidOperationException("The voice agent did not complete a stored text response.");
    }
    Console.WriteLine($"Voice agent response: {responseText}");
}
```

3. After closing the session, read the saved conversation, messages, and responses.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Read
// Read the saved messages and responses over REST.
BetaVoiceAgentsConversations conversationsClient = projectClient.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();

ClientResult<VoiceConversation> conversation = await conversationsClient.GetAgentConversationAsync(
    agentName, conversationId, cancellationToken: timeout.Token);
if (conversation.Value.Id != conversationId)
{
    throw new InvalidOperationException("The saved conversation ID did not match the Realtime response.");
}
Console.WriteLine($"Conversation {conversation.Value.Id} status: {conversation.Value.Status}; HTTP {conversation.GetRawResponse().Status}");

int itemCount = 0;
await foreach (RealtimeItem item in conversationsClient.GetAgentConversationItemsAsync(
    agentName, conversationId, cancellationToken: timeout.Token))
{
    itemCount++;
    Console.WriteLine($"Conversation item: {item.Kind}");
}

int completedResponses = 0;
await foreach (VoiceResult response in conversationsClient.GetAgentConversationResponsesAsync(
    agentName, conversationId, cancellationToken: timeout.Token))
{
    if (response.Status == RealtimeResponseStatus.Completed)
    {
        completedResponses++;
    }
    Console.WriteLine($"Response {response.Id} status: {response.Status}");
}
```

4. Clean up only the temporary agent created by this sample, even if an earlier request failed.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Cleanup
using CancellationTokenSource cleanupTimeout = new(TimeSpan.FromSeconds(30));
try
{
    ClientResult deleted = await projectClient.AgentAdministrationClient.DeleteAgentAsync(
        agentName, cancellationToken: cleanupTimeout.Token);
    Console.WriteLine($"Deleted temporary voice agent {agentName}: HTTP {deleted.GetRawResponse().Status}");
}
catch (ClientResultException exception) when (exception.Status == 404)
{
    Console.WriteLine($"Temporary voice agent {agentName} is already absent.");
}
```

`VoiceAgentTransport.Webrtc` selects **signaling only**. Your application must implement the
WebRTC peer connection, audio transport, and SDP offer/answer exchange. Selecting this option
does not create a complete WebRTC application.

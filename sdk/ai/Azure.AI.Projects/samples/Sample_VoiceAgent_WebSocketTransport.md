# Select the WebSocket transport for a Foundry Voice Agent

Use `ProjectsRealtimeSessionClientOptions.Transport` to select a connection transport.
This example uses `VoiceAgentTransport.Websocket` to send a text message, save the conversation,
and read it back over REST.

Follow the [Realtime prerequisites and authentication guidance](Sample_VoiceAgent.md#prerequisites).
The [complete sample](../tests/Samples/VoiceAgent/Sample_VoiceAgent_WebSocketTransport.cs)
includes setup and cleanup.

1. Create a temporary voice agent that returns text.

```C# Snippet:Sample_VoiceAgent_WebSocketTransport_Create
string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
string agentName = $"voice-transport-sample-{Guid.NewGuid():N}".Substring(0, 40);
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());

VoiceAgentDefinition definition = new()
{
    ModelType = VoiceModelType.SelfDeployed,
    Model = modelDeploymentName,
    Instructions = "Respond briefly and helpfully.",
};
definition.OutputModalities.Add(VoiceOutputModality.Text);
ClientResult<ProjectsAgentVersion> createResult = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName, new ProjectsAgentVersionCreationOptions(definition));
ProjectsAgentVersion agentVersion = createResult;
Console.WriteLine($"Created voice agent {agentName} version {agentVersion.Version}: HTTP {createResult.GetRawResponse().Status}");
```

2. Connect over WebSocket and send a message. Set `store=true` to save the conversation.

```C# Snippet:Sample_VoiceAgent_WebSocketTransport_Connect
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
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
    bool sawCompletedResponse = false;
    await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
    {
        Console.WriteLine($"Received event: {update.Kind}");
        if (update is RealtimeServerUpdateResponseOutputTextDone textDoneUpdate)
        {
            responseText = textDoneUpdate.Text;
        }
        else if (update is RealtimeServerUpdateResponseDone doneUpdate)
        {
            Console.WriteLine($"Response status: {doneUpdate.Response.Status}");
            sawCompletedResponse = doneUpdate.Response.Status == RealtimeResponseStatus.Completed;
            conversationId = doneUpdate.Response.ConversationId;
            break;
        }
    }
    if (!sawCompletedResponse || string.IsNullOrWhiteSpace(responseText) || string.IsNullOrWhiteSpace(conversationId))
    {
        throw new InvalidOperationException("The voice agent did not complete a stored text response.");
    }
    Console.WriteLine($"Voice agent response: {responseText}");
}
```

3. After closing the session, read the saved conversation over REST.

```C# Snippet:Sample_VoiceAgent_WebSocketTransport_Read
ClientResult<VoiceConversation> conversation = await projectClient.AgentAdministrationClient
    .GetBetaVoiceAgentEndpointConversations().GetAgentConversationAsync(agentName, conversationId);
if (conversation.Value.Id != conversationId)
{
    throw new InvalidOperationException("The stored conversation ID did not match the realtime session.");
}
Console.WriteLine($"Retrieved conversation {conversationId}: HTTP {conversation.GetRawResponse().Status}");
```

4. Delete the temporary version, even if the realtime exchange fails.

```C# Snippet:Sample_VoiceAgent_WebSocketTransport_Cleanup
ClientResult deleteResult = await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(
    agentName: agentName, agentVersion: agentVersion.Version);
Console.WriteLine($"Deleted voice agent {agentName} version {agentVersion.Version}: HTTP {deleteResult.GetRawResponse().Status}");
```

`VoiceAgentTransport.Webrtc` selects **signaling only**. Your application must implement the
WebRTC peer connection, audio transport, and SDP offer/answer exchange. Changing this option
does not create a complete WebRTC application.

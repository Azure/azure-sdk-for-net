# Read a voice agent's saved conversation

Save a Realtime conversation with `store=true`, close the session, and read its messages and
responses using `BetaVoiceAgentsConversations`. Reading saved history uses REST, not a WebSocket.

Follow the [Realtime prerequisites and authentication guidance](Sample_VoiceAgent.md#prerequisites).
The [complete sample](../tests/Samples/VoiceAgent/Sample_VoiceAgent_ReadConversation.cs)
includes client setup and cleanup.

1. Create a temporary voice agent that returns text.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Create
VoiceAgentDefinition definition = new()
{
    ModelType = VoiceModelType.SelfDeployed,
    Model = modelDeploymentName,
    Instructions = "Respond briefly and helpfully.",
};
definition.OutputModalities.Add(VoiceOutputModality.Text);
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName,
    new ProjectsAgentVersionCreationOptions(definition));
```

2. Start a session with `store=true` and capture the conversation ID from `response.done`.

```C# Snippet:Sample_VoiceAgent_ReadConversation_HoldSession
// Save the conversation with store=true and get its ID from response.done.
string conversationId;
using (ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)
    await projectClient.ProjectsRealtimeClient.StartSessionAsync(
        agentName,
        intent: null,
        options: new RealtimeSessionClientOptions { QueryString = "store=true" }))
{
    await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."));
    await session.StartResponseAsync();

    conversationId = null;
    await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync())
    {
        Console.WriteLine($"Received event: {update.Kind}");
        if (update is RealtimeServerUpdateResponseDone doneUpdate)
        {
            conversationId = doneUpdate.Response.ConversationId;
            break;
        }
    }
}
```

3. After closing the session, read the saved conversation, messages, and responses.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Read
// Read the saved messages and responses over REST.
BetaVoiceAgentsConversations conversationsClient = projectClient.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();

VoiceConversation conversation = await conversationsClient.GetAgentConversationAsync(agentName, conversationId);
Console.WriteLine($"Conversation {conversation.Id} status: {conversation.Status}");

await foreach (RealtimeItem item in conversationsClient.GetAgentConversationItemsAsync(agentName, conversationId))
{
    Console.WriteLine($"Conversation item: {item.Kind}");
}

await foreach (VoiceResult response in conversationsClient.GetAgentConversationResponsesAsync(agentName, conversationId))
{
    Console.WriteLine($"Response {response.Id} status: {response.Status}");
}
```

4. Clean up the temporary agent version.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Cleanup
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);
```

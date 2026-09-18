# Read a voice agent's persisted conversation history

This sample holds a realtime session with `Store = true`, so the Foundry service persists the
conversation the session produces, then reads that conversation back afterward through the
REST-only `BetaVoiceAgentsConversations` surface -- no realtime connection needed for the read.

Set `FOUNDRY_PROJECT_ENDPOINT` to your Foundry project endpoint and `FOUNDRY_MODEL_NAME` to a
realtime-capable model deployment name before running this sample.

1. Create the client and a temporary text-modality voice agent.

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

2. Hold a realtime session with `store: true` and note the conversation ID reported by `response.done`.

```C# Snippet:Sample_VoiceAgent_ReadConversation_HoldSession
// store: true persists this session's conversation so it can be read back afterward
// through BetaVoiceAgentsConversations; the response.done event reports the resulting
// conversation ID.
string conversationId;
using (ProjectsRealtimeSessionClient session = await projectClient.GetProjectsRealtimeSessionClientAsync(
    agentName,
    store: true))
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

3. Once the session closes, read the persisted conversation, its items, and its responses back over REST.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Read
// Once the session above closes, the conversation it produced becomes readable through
// the REST-only BetaVoiceAgentsConversations surface -- no realtime connection needed.
BetaVoiceAgentsConversations conversationsClient = projectClient.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();

VoiceConversation conversation = await conversationsClient.GetAgentConversationAsync(agentName, conversationId);
Console.WriteLine($"Conversation {conversation.Id} status: {conversation.Status}");

await foreach (RealtimeItem item in conversationsClient.GetAgentConversationItemsAsync(agentName, conversationId))
{
    Console.WriteLine($"Conversation item: {item.Kind}");
}

await foreach (VoiceResponse response in conversationsClient.GetAgentConversationResponsesAsync(agentName, conversationId))
{
    Console.WriteLine($"Response {response.Id} status: {response.Status}");
}
```

4. Clean up the temporary agent version.

```C# Snippet:Sample_VoiceAgent_ReadConversation_Cleanup
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);
```

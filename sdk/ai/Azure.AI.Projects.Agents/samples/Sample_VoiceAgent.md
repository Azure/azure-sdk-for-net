# Use a Foundry voice agent in real time

This sample creates a voice-agent version, exchanges OpenAI Realtime GA events over its Foundry WebSocket endpoint, and lists the conversation persisted by the agent.

1. Create a self-deployed voice agent. Set `Store` to `true` when its conversations and audio should be available through the Foundry REST APIs.

```C# Snippet:Sample_VoiceAgent_Create
VoiceAgentDefinition definition = new(
    modelType: VoiceModelType.SelfDeployed,
    model: modelDeploymentName)
{
    Instructions = "Respond briefly and helpfully.",
    Store = true
};
agentVersion = await agentsClient.CreateAgentVersionAsync(
    agentName,
    new ProjectsAgentVersionCreationOptions(definition));
```

1. Connect to the agent's real-time endpoint and exchange forward-compatible JSON events. The session also supports binary frames through `SendBinaryAsync`.

```C# Snippet:Sample_VoiceAgent_Realtime
VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
    agentName,
    new VoiceAgentConnectionOptions { AgentVersion = agentVersion.Version, Store = true },
    timeout.Token);

await session.SendCommandAsync(BinaryData.FromObjectAsJson(new
{
    type = "conversation.item.create",
    item = new
    {
        type = "message",
        role = "user",
        content = new[] { new { type = "input_text", text = "Say hello in one sentence." } }
    }
}), timeout.Token);
await session.SendCommandAsync(
    BinaryData.FromObjectAsJson(new { type = "response.create" }),
    timeout.Token);

await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
{
    if (update.MessageType != WebSocketMessageType.Text)
    {
        continue;
    }

    using JsonDocument document = JsonDocument.Parse(update.Data);
    string eventType = document.RootElement.GetProperty("type").GetString();
    Console.WriteLine(eventType);
    if (eventType == "response.done")
    {
        break;
    }
}
await session.CloseAsync();
```

1. Use the generated Foundry conversation client to retrieve persisted conversations.

```C# Snippet:Sample_VoiceAgent_Conversations
AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
await foreach (VoiceConversation conversation in conversationsClient.GetAgentConversationsAsync(agentName))
{
    Console.WriteLine($"Conversation {conversation.Id}: {conversation.Status}");
}
```

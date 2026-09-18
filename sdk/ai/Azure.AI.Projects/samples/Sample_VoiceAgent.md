# Use a Foundry voice agent with REST and realtime APIs

This sample creates a voice agent over REST, then exchanges realtime events over its Foundry
WebSocket endpoint using `ProjectsRealtimeSessionClient`. Because that type extends OpenAI's
`RealtimeSessionClient`, it reuses OpenAI's own realtime command/event model (`AddItemAsync`,
`StartResponseAsync`, `ReceiveUpdatesAsync`, ...) -- only the WebSocket handshake targets the
Foundry voice-agent endpoint (`/agents/{agentName}/endpoint/protocols/voice`) instead of OpenAI's
generic `/realtime` endpoint.

Set `FOUNDRY_PROJECT_ENDPOINT` to your Foundry project endpoint and `FOUNDRY_MODEL_NAME` to a
realtime-capable model deployment name before running this sample.

1. Create the client and a temporary text-modality voice agent.

```C# Snippet:Sample_VoiceAgent_Create
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

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

2. Start a realtime session against the agent, send a text turn, and read the response.

```C# Snippet:Sample_VoiceAgent_Realtime
// ProjectsRealtimeSessionClient extends OpenAI's RealtimeSessionClient, so it reuses
// OpenAI's realtime command/event model (SendInputAudioAsync, AddItemAsync,
// StartResponseAsync, ReceiveUpdatesAsync, ...); only the WebSocket handshake targets
// the Foundry voice-agent endpoint instead of OpenAI's own /realtime endpoint.
using ProjectsRealtimeSessionClient session = await projectClient.GetProjectsRealtimeSessionClientAsync(agentName);

await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."));
await session.StartResponseAsync();

string responseText = string.Empty;
await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync())
{
    Console.WriteLine($"Received event: {update.Kind}");
    if (update is RealtimeServerUpdateResponseOutputTextDone textDoneUpdate)
    {
        responseText = textDoneUpdate.Text;
    }
    else if (update is RealtimeServerUpdateResponseDone)
    {
        break;
    }
}
Console.WriteLine($"Voice agent response: {responseText}");
```

3. Clean up the temporary agent version.

```C# Snippet:Sample_VoiceAgent_Cleanup
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);
```

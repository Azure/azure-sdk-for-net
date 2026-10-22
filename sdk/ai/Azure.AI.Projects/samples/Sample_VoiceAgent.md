# Use a Foundry voice agent with REST and realtime APIs

This sample creates a voice agent over REST, then exchanges realtime events over its Foundry
WebSocket endpoint using `ProjectsRealtimeSessionClient`. Because that type extends OpenAI's
`RealtimeSessionClient`, it reuses OpenAI's own realtime command/event model (`AddItemAsync`,
`StartResponseAsync`, `ReceiveUpdatesAsync`, ...) -- only the WebSocket handshake targets the
Foundry voice-agent endpoint (`/agents/{agentName}/endpoint/protocols/voice`) instead of OpenAI's
generic `/realtime` endpoint.

Set `FOUNDRY_PROJECT_ENDPOINT` to your Foundry project endpoint and `FOUNDRY_REALTIME_MODEL_NAME` to a
realtime-capable model deployment name before running this sample.

1. Create the client and a temporary text-modality voice agent.

```C# Snippet:Sample_VoiceAgent_Create
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
VoiceAgentDefinition definition = new()
{
    ModelType = VoiceModelType.SelfDeployed,
    Model = modelDeploymentName,
    Instructions = "Respond briefly and helpfully."
};
definition.OutputModalities.Add(VoiceOutputModality.Text);
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: timeout.Token);
```

2. Start a realtime session against the agent, send a text turn, and read the response.

```C# Snippet:Sample_VoiceAgent_Realtime
using RealtimeSessionClient session = await projectClient.ProjectsRealtimeClient.StartSessionAsync(
    agentName, intent: null, cancellationToken: timeout.Token);
await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);
await session.StartResponseAsync(timeout.Token);

string responseText = "";
await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
{
    Console.WriteLine($"Received event: {update.Kind}");
    if (update is RealtimeServerUpdateResponseOutputTextDone text)
    {
        responseText = text.Text;
    }
    else if (update is RealtimeServerUpdateResponseDone done)
    {
        if (done.Response.Status != RealtimeResponseStatus.Completed)
        {
            throw new InvalidOperationException("The Realtime response did not complete.");
        }
        break;
    }
}
Console.WriteLine($"Voice agent response: {responseText}");
```

3. Clean up the temporary agent version.

```C# Snippet:Sample_VoiceAgent_Cleanup
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(
    agentName, agentVersion.Version, CancellationToken.None);
```

## Call a function

This example registers `get_test_value`, handles the streamed function call, returns its
result using the matching call ID, and asks the model to continue.

```C# Snippet:Sample_VoiceAgent_Realtime_FunctionTool
VoiceAgentDefinition definition = new()
{
    ModelType = VoiceModelType.SelfDeployed,
    Model = modelDeploymentName,
    Instructions = "Call get_test_value, then report the returned value."
};
definition.OutputModalities.Add(VoiceOutputModality.Text);
definition.Tools.Add(new VoiceAgentFunctionTool("get_test_value")
{
    Description = "Returns a demonstration value. Takes no arguments.",
    Parameters = ModelReaderWriter.Read<RealtimeFunctionToolParameters>(
        BinaryData.FromString("""{"type":"object","properties":{},"additionalProperties":false}"""))
});
await project.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: timeout.Token);
try
{
    using RealtimeSessionClient session = await project.ProjectsRealtimeClient.StartSessionAsync(
        agentName, intent: null, cancellationToken: timeout.Token);
    await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Use the function and tell me its value."), timeout.Token);
    await session.StartResponseAsync(
        new RealtimeResponseOptions { ToolChoice = RealtimeDefaultToolChoice.Required }, timeout.Token);

    RealtimeServerUpdateResponseFunctionCallArgumentsDone call = null;
    bool resultSent = false;
    string answer = "";
    await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
    {
        if (update is RealtimeServerUpdateResponseFunctionCallArgumentsDone function)
        {
            using JsonDocument arguments = JsonDocument.Parse(function.FunctionArguments);
            if (function.FunctionName != "get_test_value" ||
                arguments.RootElement.ValueKind != JsonValueKind.Object || arguments.RootElement.EnumerateObject().MoveNext())
            {
                throw new InvalidOperationException("Unexpected function or arguments.");
            }
            call = function;
        }
        else if (update is RealtimeServerUpdateResponseOutputTextDone text)
        {
            answer += text.Text;
            Console.WriteLine(text.Text);
        }
        else if (update is RealtimeServerUpdateResponseDone done)
        {
            if (done.Response.Status != RealtimeResponseStatus.Completed)
            {
                throw new InvalidOperationException("The Realtime response did not complete.");
            }
            if (call == null || resultSent)
            {
                break;
            }
            await session.AddItemAsync(
                RealtimeItem.CreateFunctionCallOutputItem(call.CallId, """{"value":7}"""), timeout.Token);
            resultSent = true;
            await session.StartResponseAsync(
                new RealtimeResponseOptions { ToolChoice = RealtimeDefaultToolChoice.None }, timeout.Token);
        }
    }
}
finally
{
    await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
}
```

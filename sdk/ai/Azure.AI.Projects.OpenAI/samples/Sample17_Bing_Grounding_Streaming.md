# Sample for use of Agents with Bing grounding in Azure.AI.Projects.OpenAI in streaming scenarios.

To enable your Agent to use Bing search API, we need to use `BingGroundingAgentTool`.

1. First, we need to read the environment variables, which will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_BingGroundingStreaming
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("BING_CONNECTION_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. `BingGroundingAgentTool` requires an ID of Bing connection. In this example we will use the name of a Bing project connection as found in the "Connections" tab in your Microsoft Foundry project to get connection ID from `AIProjectConnection`. We will use created tool in the constructor of a `PromptAgentDefinition` object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_BingGroundingStreaming_Sync
AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
    searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { bingGroundingAgentTool }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_BingGroundingStreaming_Async
AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
    searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { bingGroundingAgentTool }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. To get the reference to the Web site from the response we need to parse the output items. We will do it in the helper method `GetFormattedAnnotation`.

```C# Snippet:Sample_FormatReference_BingGroundingStreaming
private static string GetFormattedAnnotation(ResponseItem item)
{
    if (item is MessageResponseItem messageItem)
    {
        foreach (ResponseContentPart content in messageItem.Content)
        {
            foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
            {
                if (annotation is UriCitationMessageAnnotation uriAnnotation)
                {
                    return $" [{uriAnnotation.Title}]({uriAnnotation.Uri})";
                }
            }
        }
    }
    return "";
}
```

4. Stream the response.

Synchronous sample:
```C# Snippet:Sample_StreamResponse_BingGroundingStreaming_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

string annotation = "";
string text = "";
foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming("How does wikipedia explain Euler's Identity?"))
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
    }
    else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
    {
        Console.WriteLine($"Delta: {textDelta.Delta}");
    }
    else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
    {
        text = textDoneUpdate.Text;
    }
    else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
    {
        if (annotation.Length == 0)
        {
            annotation = GetFormattedAnnotation(itemDoneUpdate.Item);
        }
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}");
    }
}
Console.WriteLine($"{text}{annotation}");
```

Asynchronous sample:
```C# Snippet:Sample_StreamResponse_BingGroundingStreaming_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

string annotation = "";
string text = "";
await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync("How does wikipedia explain Euler's Identity?"))
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
    }
    else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
    {
        Console.WriteLine($"Delta: {textDelta.Delta}");
    }
    else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
    {
        text = textDoneUpdate.Text;
    }
    else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
    {
        if (annotation.Length == 0)
        {
            annotation = GetFormattedAnnotation(itemDoneUpdate.Item);
        }
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}");
    }
}
Console.WriteLine($"{text}{annotation}");
```


5. Finally, delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_BingGroundingStreaming_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_BingGroundingStreaming_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

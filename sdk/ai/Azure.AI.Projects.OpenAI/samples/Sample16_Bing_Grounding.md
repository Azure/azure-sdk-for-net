# Sample for use of Agents with Bing grounding in Azure.AI.Projects.OpenAI.

## Warning
Grounding with Bing Search tool uses Grounding with Bing, which has additional costs and terms: [terms of use](https://www.microsoft.com/bing/apis/grounding-legal-enterprise) and [privacy statement](https://go.microsoft.com/fwlink/?LinkId=521839&clcid=0x409). Customer data will flow outside the Azure compliance boundary. Learn more [here](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/bing-tools).

## Samples
To enable your Agent to use Bing search API, we need to use `BingGroundingAgentTool`.

1. First, we need to read the environment variables, which will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_BingGrounding
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("BING_CONNECTION_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. `BingGroundingAgentTool` requires an ID of Bing connection. In this example we will use the name of a Bing project connection as found in the "Connections" tab in your Microsoft Foundry project to get connection ID from `AIProjectConnection`. We will use created tool in the constructor of a `PromptAgentDefinition` object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_BingGrounding_Sync
AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
    searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { bingGroundingAgentTool, }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_BingGrounding_Async
AIProjectConnection bingConnectionName = await projectClient.Connections.GetConnectionAsync(connectionName: connectionName);
BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
    searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { bingGroundingAgentTool, }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Create a `ResponseResult` object.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_BingGrounding_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseResult response = responseClient.CreateResponse("How does wikipedia explain Euler's Identity?");
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_BingGrounding_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseResult response = await responseClient.CreateResponseAsync("How does wikipedia explain Euler's Identity?");
```

4. To get the reference to the Web site from the response we need to parse the output items. We will do it in the helper method `GetFormattedAnnotation`.

```C# Snippet:Sample_FormatReference_BingGrounding
private static string GetFormattedAnnotation(ResponseResult response)
{
    foreach (ResponseItem item in response.OutputItems)
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
    }
    return "";
}
```

5. Use the helper method to output the result.

```C# Snippet:Sample_WaitForResponse_BingGrounding
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
```

6. Finally, delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_BingGrounding_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_BingGrounding_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

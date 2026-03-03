# Sample for use of Agents with Custom Bing search in Azure.AI.Projects.OpenAI.

## Warning
Grounding with Bing Custom Search tool uses Grounding with Bing, which has additional costs and terms: [terms of use](https://www.microsoft.com/bing/apis/grounding-legal-enterprise) and [privacy statement](https://go.microsoft.com/fwlink/?LinkId=521839&clcid=0x409). Customer data will flow outside the Azure compliance boundary. Learn more [here](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/web-search).

## Samples

To enable your Agent to use Custom Bing search, we need to use `BingCustomSearchPreviewTool`.

**Note:** This feature is in the preview.

1. First, we need to read the environment variables, which will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_CustomBingSearch
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CUSTOM_BING_CONNECTION_NAME");
var customInstanceName = System.Environment.GetEnvironmentVariable("BING_CUSTOM_SEARCH_INSTANCE_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. `BingCustomSearchPreviewTool` requires an ID of Grounding with Bing Custom Search connection. In this example we will use the name of this connection as found in the "Connections" tab in your Microsoft Foundry project to get connection ID from `AIProjectConnection`. We will use created tool in the constructor of a `PromptAgentDefinition` object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_CustomBingSearch_Sync
AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
BingCustomSearchPreviewTool customBingSearchAgentTool = new(new BingCustomSearchToolParameters(
    searchConfigurations: [new BingCustomSearchConfiguration(projectConnectionId: bingConnectionName.Id, instanceName: customInstanceName)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { customBingSearchAgentTool, }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_CustomBingSearch_Async
AIProjectConnection bingConnectionName = await projectClient.Connections.GetConnectionAsync(connectionName: connectionName);
BingCustomSearchPreviewTool customBingSearchAgentTool = new(new BingCustomSearchToolParameters(
    searchConfigurations: [new BingCustomSearchConfiguration(projectConnectionId: bingConnectionName.Id, instanceName: customInstanceName)]
    )
);
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent.",
    Tools = { customBingSearchAgentTool, }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Create a `ResponseResult` object.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_CustomBingSearch_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseResult response = responseClient.CreateResponse("How many medals did the USA win in the 2024 summer olympics?");
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_CustomBingSearch_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseResult response = await responseClient.CreateResponseAsync("How many medals did the USA win in the 2024 summer olympics?");
```

4. To get the reference to the Web site from the response we need to parse the output items. We will do it in the helper method `GetFormattedAnnotation`.

```C# Snippet:Sample_FormatReference_CustomBingSearch
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

```C# Snippet:Sample_WaitForResponse_CustomBingSearch
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
```

6. Finally, delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_CustomBingSearch_Sync
projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_CustomBingSearch_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

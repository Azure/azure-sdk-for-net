# Sample of web search preview tool with Agent in Azure.AI.Extensions.OpenAI.

**Note:** The Web Search Preview is deprecated, please use Web Search instead.

## Warning
Web Search Preview tool uses Grounding with Bing, which has additional costs and terms: [terms of use](https://www.microsoft.com/bing/apis/grounding-legal-enterprise) and [privacy statement](https://go.microsoft.com/fwlink/?LinkId=521839&clcid=0x409). Customer data will flow outside the Azure compliance boundary. Learn more [here](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/web-search).

## Sample
To enable your Agent to use Web Search Preview tool, we need to create .

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_WebSearchPreviewStreaming
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create an Agent capable of using Web search preview tool.


Synchronous sample:
```C# Snippet:Sample_CreateAgent_WebSearchPreviewStreaming_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that can search the web.",
    Tools = { ResponseTool.CreateWebSearchPreviewTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_WebSearchPreviewStreaming_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that can search the web.",
    Tools = { ResponseTool.CreateWebSearchPreviewTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. To get the formatted annotation we will use the `GetFormattedAnnotation` method.

```C# Snippet:Sample_FormatReference_WebSearchPreviewStreaming
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

4. Ask the question and stream the response.

Synchronous sample:
```C# Snippet:Sample_StreamResponse_WebSearchPreviewStreaming_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

string annotation = "";
string text = "";
CreateResponseOptions options = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("Show me the latest London Underground service updates") },
};

foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming(options))
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
```C# Snippet:Sample_StreamResponse_WebSearchPreviewStreaming_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

string annotation = "";
string text = "";
CreateResponseOptions options = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("Show me the latest London Underground service updates") },
};
await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync(options))
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
```C# Snippet:Sample_Cleanup_WebSearchPreviewStreaming_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_WebSearchPreviewStreaming_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

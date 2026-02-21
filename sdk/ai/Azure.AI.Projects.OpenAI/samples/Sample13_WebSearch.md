# Sample web search with agent in Azure.AI.Projects.OpenAI.

## Warning
Web Search tool uses Grounding with Bing, which has additional costs and terms: [terms of use](https://www.microsoft.com/bing/apis/grounding-legal-enterprise) and [privacy statement](https://go.microsoft.com/fwlink/?LinkId=521839&clcid=0x409). Customer data will flow outside the Azure compliance boundary. Learn more [here](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/web-search).

## Sample
In this example we will use the Agent to perform the web search in given location.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_WebSearch
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create an Agent capable of using Web search. In the `WebSearchToolLocation` we will set the location to be London.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_WebSearch_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that can search the web",
    Tools = { ResponseTool.CreateWebSearchTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_WebSearch_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that can search the web",
    Tools = { ResponseTool.CreateWebSearchTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Ask the question related to London.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_WebSearch_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseResult response = responseClient.CreateResponse("Show me the latest London Underground service updates");
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_WebSearch_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseResult response = await responseClient.CreateResponseAsync("Show me the latest London Underground service updates");
```

4. Create the response and throw an exception if the response contains the error.

```C# Snippet:Sample_WaitForResponse_WebSearch
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

5. Finally, delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_WebSearch_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_WebSearch_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

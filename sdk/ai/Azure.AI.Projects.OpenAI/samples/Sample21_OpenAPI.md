# Sample of using Agents with OpenAPI tool in Azure.AI.Projects.OpenAI.

In this example we will demonstrate the possibility to use services with [OpenAPI Specification](https://en.wikipedia.org/wiki/OpenAPI_Specification) with the Agent. We will use [wttr.in](https://wttr.in) service to get weather and its specification file [weather_openapi.json](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Agents.Persistent/tests/Samples/weather_openapi.json). To get this file we will use the utility method `GetFile`, which takes file located in the `C#` source directory.
```C# Snippet:Sample_GetFile_OpenAPI
private static string GetFile([CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine(dirName, "Assets", "weather_openapi.json");
}
```

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:Sample_CreateProjectClient_OpenAPI
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Next, we will create an Agent with `OpenAPIAgentTool` and anonymous authentication.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_OpenAPI_Sync
string filePath = GetFile();
OpenAPIFunctionDefinition toolDefinition = new(
    name: "get_weather",
    spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
    auth: new OpenAPIAnonymousAuthenticationDetails()
);
toolDefinition.Description = "Retrieve weather information for a location.";
OpenAPITool openapiTool = new(toolDefinition);

PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { openapiTool }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_OpenAPI_Async
string filePath = GetFile();
OpenAPIFunctionDefinition toolDefinition = new(
    name: "get_weather",
    spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
    auth: new OpenAPIAnonymousAuthenticationDetails()
);
toolDefinition.Description = "Retrieve weather information for a location.";
OpenAPITool openapiTool = new(toolDefinition);

PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = {openapiTool}
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Now we will create a response object and ask the question about the weather in Seattle, WA.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_OpenAPI_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseResult response = responseClient.CreateResponse(
        userInputText: "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."
    );
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_OpenAPI_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseResult response = await responseClient.CreateResponseAsync(
        userInputText: "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."
    );
Console.WriteLine(response.GetOutputText());
```

4. Finally, delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_OpenAPI_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_OpenAPI_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

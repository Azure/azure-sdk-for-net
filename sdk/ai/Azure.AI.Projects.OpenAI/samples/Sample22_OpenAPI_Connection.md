# Sample of using Agents with OpenAPI tool in Azure.AI.Projects.OpenAI on Web service, requiring authentication.

In this example we will demonstrate the possibility to use services with [OpenAPI Specification](https://en.wikipedia.org/wiki/OpenAPI_Specification) with the Agent in the scenario, requiring authentication. We will use the TripAdvisor specification. To get this file we will use the utility method `GetFile`, which takes file located in the `C#` source directory.
```C# Snippet:Sample_GetFile_OpenAPIProjectConnection
private static string GetFile([CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine(dirName, "Assets", "tripadvisor_openapi.json");
}
```

TripAdvisor service requires key-based authentication. To create a connection, in the Azure portal open Microsoft Foundry you are using, at the left panel select "Management center" and then select "Connected resources", and, finally, create new connection of "Custom keys" type; name it "tripadvisor" and add a key value pair. Add key called "key" and value with the actual TripAdvisor key.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:Sample_CreateProjectClient_OpenAPIProjectConnection
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Next, we will create an Agent with `OpenAPIAgentTool` and authentication by project connection security scheme.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_OpenAPIProjectConnection_Sync
string filePath = GetFile();
AIProjectConnection tripadvisorConnection = projectClient.Connections.GetConnection("tripadvisor");
OpenAPIFunctionDefinition toolDefinition = new(
    name: "tripadvisor",
    spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
    auth: new OpenAPIProjectConnectionAuthenticationDetails(new OpenAPIProjectConnectionSecurityScheme(
        projectConnectionId: tripadvisorConnection.Id
    ))
);
toolDefinition.Description = "Trip Advisor API to get travel information.";
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
```C# Snippet:Sample_CreateAgent_OpenAPIProjectConnection_Async
string filePath = GetFile();
AIProjectConnection tripadvisorConnection = await projectClient.Connections.GetConnectionAsync("tripadvisor");
OpenAPIFunctionDefinition toolDefinition = new(
    name: "tripadvisor",
    spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
    auth:  new OpenAPIProjectConnectionAuthenticationDetails(new OpenAPIProjectConnectionSecurityScheme(
        projectConnectionId: tripadvisorConnection.Id
    ))
);
toolDefinition.Description = "Trip Advisor API to get travel information.";
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

3. Now we will create a response object and ask the question about the hotels in France. We recommend testing the Web service access before running production scenarios. It can be done by setting
`ToolChoice = ResponseToolChoice.CreateRequiredChoice()` in the `CreateResponseOptions`. This setting will
force Agent to use tool and will trigger the error if it is not accessible.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_OpenAPIProjectConnection_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("Recommend me 5 top hotels in paris, France."),
    },
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_OpenAPIProjectConnection_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("Recommend me 5 top hotels in paris, France."),
    }
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
Console.WriteLine(response.GetOutputText());
```

4. Finally, delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_OpenAPIProjectConnection_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_OpenAPIProjectConnection_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

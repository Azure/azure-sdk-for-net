# Sample for use of an Agent with SharePoint in Azure.AI.Projets.OpenAI.

To enable your Agent to access SharePoint, use `SharepointAgentTool`.

1. First, create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_Sharepoint
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var sharepointConnectionName = System.Environment.GetEnvironmentVariable("SHAREPOINT_CONNECTION_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the SharePoint connection name as it is shown in the connections section of Microsoft Foundry to get the connection. Get the connection ID to initialize the `SharePointGroundingToolOptions`, which will be used to create `SharepointAgentTool`. We will use this tool to create an Agent.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_Sharepoint_Sync
AIProjectConnection sharepointConnection = projectClient.Connections.GetConnection(sharepointConnectionName);
SharePointGroundingToolOptions sharepointToolOption = new()
{
    ProjectConnections = { new ToolProjectConnection(projectConnectionId: sharepointConnection.Id) }
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { new SharepointPreviewTool(sharepointToolOption), }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_Sharepoint_Async
AIProjectConnection sharepointConnection = await projectClient.Connections.GetConnectionAsync(sharepointConnectionName);
SharePointGroundingToolOptions sharepointToolOption = new()
{
    ProjectConnections = { new ToolProjectConnection(projectConnectionId: sharepointConnection.Id) }
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { new SharepointPreviewTool(sharepointToolOption), }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Create the response and make sure we are always using tool.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_Sharepoint_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("What is Contoso whistleblower policy"),
    },
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_Sharepoint_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("What is Contoso whistleblower policy") },
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
```

4. SharePoint tool can create the reference to the page, grounding the data. We will create the `GetFormattedAnnotation` method to get the URI annotation.

```C# Snippet:Sample_FormatReference_Sharepoint
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

5. Print the Agent output and add the annotation at the end.

```C# Snippet:Sample_WaitForResponse_Sharepoint
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
```


6. After the sample is completed, delete the Agent we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Sharepoint_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Sharepoint_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

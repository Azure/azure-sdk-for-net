# Sample for use of an Agent with Work IQ in Azure.AI.Projets.OpenAI.

Work IQ tool allows Agent to access data from [Microsoft 365 Copilot](https://learn.microsoft.com/microsoft-agent-365/tooling-servers-overview). In this example we will create the connection to teams and ask Agent to list all meetings for today.

**Note:** This feature is in the preview.

## Create a Work IQ connection in Microsoft Foundry

1. In the **Microsoft Foundry** you are using for the experimentation, on the top panel select **Build**.
2. Choose **Tools** on the left panel and switch to the **Tools** tab on the top.
3. Create a new connection of type **Work IQ Teams** using catalog tab.


## Run the sample

To enable your Agent to access Microsoft 365 Copilot, use `WorkIQPreviewTool`.

1. First, create an Agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_WorkIQ
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var workIQConnectionName = System.Environment.GetEnvironmentVariable("WORKIQ_CONNECTION_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the Work IQ Teams connection name as it is shown in the Tools section of Microsoft Foundry to get the connection. Get the connection ID to create the `WorkIQPreviewTool`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_WorkIQ_Sync
AIProjectConnection workIQConnection = projectClient.Connections.GetConnection(workIQConnectionName);
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that can access Microsoft 365 data through WorkIQ. Use the WorkIQ tool to search and retrieve information from emails, calendar events, Teams messages, and other Microsoft 365 content to assist users with their questions.",
    Tools = { new WorkIQPreviewTool(workIQConnection.Id), }
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_WorkIQ_Async
AIProjectConnection workIQConnection = await projectClient.Connections.GetConnectionAsync(workIQConnectionName);
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that can access Microsoft 365 data through WorkIQ. Use the WorkIQ tool to search and retrieve information from emails, calendar events, Teams messages, and other Microsoft 365 content to assist users with their questions.",
    Tools = { new WorkIQPreviewTool(workIQConnection.Id), }
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Create the response and make sure we are always using tools.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_WorkIQ_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("What meetings do I have scheduled today?") },
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_WorkIQ_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("What meetings do I have scheduled today?") },
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
```

4. Print the Agent output.

```C# Snippet:Sample_GetResponse_WorkIQ
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

5. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_WorkIQ_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_WorkIQ_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

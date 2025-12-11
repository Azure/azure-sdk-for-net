# Sample for use of an Agent with Fabric Data Agent in Azure.AI.Projets.OpenAI.

The [A2A or Agent2Agent](https://a2a-protocol.org/latest/) protocol is designed to enable seamless communication between agents. In the scenario below we assume that we have the application endpoint, which complies  with A2A; the authentication is happening through header `x-api-key` value.

## Create a connection to A2A agent

1. In the **Microsoft Foundry** you are using for the experimentation, on the left panel select **Management center**.
2. Choose **Connected resources**.
3. Create a new connection of type **Custom keys**.
4. Add two key-value pairs:
   * x-api-key: \<your key\>
   * type: custom_A2A
5. Name and save the connection.


## Run the sample

To enable your Agent communication to the A2A endpoint, use `A2ATool`.

1. First, create an Agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_AgentToAgent
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var a2aConnectionName = System.Environment.GetEnvironmentVariable("A2A_CONNECTION_NAME");
var a2aBaseUri = System.Environment.GetEnvironmentVariable("A2A_BASE_URI");

AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create the `A2ATool` and provide it with the A2A connection ID and service endpoint as a `baseUri` parameter.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_AgentToAgent_Sync
AIProjectConnection a2aConnection = projectClient.Connections.GetConnection(a2aConnectionName);
A2ATool a2aTool = new(baseUri: new Uri(a2aBaseUri))
{
    ProjectConnectionId = a2aConnection.Id
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { a2aTool }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_AgentToAgent_Async
AIProjectConnection a2aConnection = projectClient.Connections.GetConnection(a2aConnectionName);
A2ATool a2aTool = new(baseUri: new Uri(a2aBaseUri))
{
    ProjectConnectionId = a2aConnection.Id
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { a2aTool }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Create the response and make sure we are always using tool.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_AgentToAgent_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseCreationOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice()
};
OpenAIResponse response = responseClient.CreateResponse("What can the secondary agent do?", options: responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_AgentToAgent_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseCreationOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice()
};
OpenAIResponse response = await responseClient.CreateResponseAsync("What can the secondary agent do?", options: responseOptions);
```

4. Print the Agent output.

```C# Snippet:Sample_WaitForResponse_AgentToAgent
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```


5.  After the sample is completed, delete the Agent we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_AgentToAgent_Sync
projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_AgentToAgent_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

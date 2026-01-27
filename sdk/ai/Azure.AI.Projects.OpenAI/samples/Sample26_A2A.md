# Sample for use of an Agent with Fabric Data Agent in Azure.AI.Projets.OpenAI.

The [A2A or Agent2Agent](https://a2a-protocol.org/latest/) protocol is designed to enable seamless communication between agents. In the scenario below we assume that we have the application endpoint, which complies  with A2A; the authentication is happening through header `x-api-key` value.

## Create a connection to A2A agent

The connection to A2A service can be created in two ways. In classic Microsoft Foundry, we need to create Custom keys connection, however in the new version of Microsoft Foundry we can create the specialized A2A connection.

### Classic Microsoft Foundry

1. In the **Microsoft Foundry** you are using for the experimentation, on the left panel select **Management center**.
2. Choose **Connected resources**.
3. Create a new connection of type **Custom keys**.
4. Add two key-value pairs:
   * x-api-key: \<your key\>
   * type: custom_A2A
5. Name and save the connection.

### New Microsoft Foundry

If we are using the Agent2agent connection, we do not need to provide the endpoint as it already contains it.

1. Click **New foundry** switch at the top of Microsoft Foundry UI.
2. Click **Tools** on the left panel.
3. Click **Connect tool** at the upper right corner.
4. In the open window select **Custom** tab.
5. Select **Agent2agent(A2A)** and click **Create**.
6. Populate **Name** and **A2A Agent Endpoint**, leave **Authentication** being "Key-based".
7. In the **Credential** Section set key "x-api-key" with the value being your secret key.

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

2. Create the `A2ATool` and provide it with the A2A connection ID. We also need to provide the service endpoint as a `baseUri` parameter if the connection is not of a `RemoteA2A` type.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_AgentToAgent_Sync
AIProjectConnection a2aConnection = projectClient.Connections.GetConnection(a2aConnectionName);
A2APreviewTool a2aTool = new()
{
    ProjectConnectionId = a2aConnection.Id
};
if (!string.Equals(a2aConnection.Type.ToString(), "RemoteA2A"))
{
    if (a2aBaseUri is null)
    {
        throw new InvalidOperationException($"The connection {a2aConnection.Name} is of {a2aConnection.Type.ToString()} type and does not carry the A2A service base URI. Please provide this value through A2A_BASE_URI environment variable.");
    }
    a2aTool.BaseUri = new Uri(a2aBaseUri);
}
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
A2APreviewTool a2aTool = new()
{
    ProjectConnectionId = a2aConnection.Id
};
if (!string.Equals(a2aConnection.Type.ToString(), "RemoteA2A"))
{
    if (a2aBaseUri is null)
    {
        throw new InvalidOperationException($"The connection {a2aConnection.Name} is of {a2aConnection.Type.ToString()} type and does not carry the A2A service base URI. Please provide this value through A2A_BASE_URI environment variable.");
    }
    a2aTool.BaseUri = new Uri(a2aBaseUri);
}
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
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("What can the secondary agent do?") },
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_AgentToAgent_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("What can the secondary agent do?"),
    },
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
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

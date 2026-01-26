# Sample for use of an Agent with Fabric Data Agent in Azure.AI.Projets.OpenAI.

As a prerequisite to this example, we will need to create Microsoft Fabric with Lakehouse data repository. Please see the end-to end tutorials on using Microsoft Fabric [here](https://learn.microsoft.com/fabric/fundamentals/end-to-end-tutorials) for more information.

## Create a Fabric Capacity

1. Create a **Fabric Capacity** resource in the Azure Portal **(attention, the rate is being applied!)**.
2. Create the workspace in [Power BI portal](https://msit.powerbi.com/home) by clicking **Workspaces** icon on the left panel.
3. At the bottom click **+ New workspace**.
4. At the right panel populate the name of a workspace, select **Fabric capacity** as a **License mode**; in the **Capacity** dropdown select Fabric Capacity resource we have just created.
5. Click **Apply**.

## Create a Lakehouse data repository

1. Click a **Lakehouse** icon in **Other items you can create with Microsoft Fabric** section and name the new data repository.
2. Download the [public holidays data set](https://github.com/microsoft/fabric-samples/raw/refs/heads/main/docs-samples/data-engineering/Lakehouse/PublicholidaysSample/publicHolidays.parquet).
3. At the Lakehouse menu select **Get data > Upload files** and upload the `publicHolidays.parquet`.
4. In the **Files** section, click on three dots next to uploaded file and click **Load to Tables > new table** and then **Load** in the opened window.
5. Delete the uploaded file, by clicking three dots and selecting **Delete**.

## Add a data agent to the Fabric

1. At the top panel select **Add to data agent > New data agent** and name the newly created Agent.
2. In the open view on the left panel select the Lakehouse "publicholidays" table and set a checkbox next to it.
4. Ask the question we will further use in the Requests API. "What was the number of public holidays in Norway in 2024?"
5. The Agent should show a table containing one column called "NumberOfPublicHolidays" with the single row, containing number 62.
6. Click **Publish** and in the description add "Agent has data about public holidays." If this stage was omitted the error, saying "Stage configuration not found." will be returned during sample run.

## Create a Fabric connection in Microsoft Foundry

After we have created the Fabric data Agent, we can connect fabric to our Microsoft Foundry.
1. Open the [Power BI](https://msit.powerbi.com/home) and select the workspace we have created.
2. In the open view select the Agent we have created.
3. The URL of the opened page will look like `https://msit.powerbi.com/groups/%workspace_id%/aiskills/%artifact_id%?experience=power-bi`, where `workspace_id` and `artifact_id` are GUIDs in a form like `811acded-d5f7-11f0-90a4-04d3b0c6010a`.
4. In the **Microsoft Foundry** you are using for the experimentation, on the left panel select **Management center**.
5. Choose **Connected resources**.
6. Create a new connection of type **Microsoft Fabric**.
7. Populate **workspace-id** and **artifact-id** fields with GUIDs found in the Microsoft Data Agent URL and name the new connection.


## Run the sample

To enable your Agent to access Microsoft Fabric Data Agent, use `MicrosoftFabricAgentTool`.

1. First, create an Agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_Fabric
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var fabricConnectionName = System.Environment.GetEnvironmentVariable("FABRIC_CONNECTION_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the Microsoft Fabric connection name as it is shown in the connections section of Microsoft Foundry to get the connection. Get the connection ID to initialize the `FabricDataAgentToolOptions`, which will be used to create `MicrosoftFabricAgentTool`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_Fabric_Sync
AIProjectConnection fabricConnection = projectClient.Connections.GetConnection(fabricConnectionName);
FabricDataAgentToolOptions fabricToolOption = new()
{
    ProjectConnections = { new ToolProjectConnection(projectConnectionId: fabricConnection.Id) }
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { new MicrosoftFabricPreviewTool(fabricToolOption), }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_Fabric_Async
AIProjectConnection fabricConnection = await projectClient.Connections.GetConnectionAsync(fabricConnectionName);
FabricDataAgentToolOptions fabricToolOption = new()
{
    ProjectConnections = { new ToolProjectConnection(projectConnectionId: fabricConnection.Id) }
};
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = { new MicrosoftFabricPreviewTool(fabricToolOption), }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Create the response and make sure we are always using tool.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_Fabric_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("What was the number of public holidays in Norway in 2024?") },
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_Fabric_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("What was the number of public holidays in Norway in 2024?") },
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
```

4. Print the Agent output.

```C# Snippet:Sample_WaitForResponse_Fabric
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```


5.  After the sample is completed, delete the Agent we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Fabric_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Fabric_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

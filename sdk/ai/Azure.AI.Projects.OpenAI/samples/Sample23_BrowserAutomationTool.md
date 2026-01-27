# Sample for use of `BrowserAutomationAgentTool` and Agents in Azure.AI.Projects.OpenAI.

Playwright is a Node.js library for browser automation. Microsoft provides the [Azure Playwright workspace](https://learn.microsoft.com/javascript/api/overview/azure/playwright-readme), which can execute Playwright-based tasks triggered by an Agent using the BrowserAutomationAgentTool.

## Create Azure Playwright workspace

1. Deploy an Azure Playwright workspace.
2. In the **Get started** section, open **2. Set up authentication**.
3. **Select Service Access Token**, then choose **Generate Token**. **Save the token immediately-once you close the page, it cannot be viewed again.**

## Configure Microsoft Foundry

1. On the left panel select **Management center**.
2. Choose **Connected resources**.
3. Create a new connection of type **Serverless Model**.
4. Provide a name, then paste your Access Token into the **Key** field.
5. Set the Playwright Workspace Browser endpoint as the **Target URI**. You can find this endpoint on the Workspace **Overview page**. It begins with `wss://`.

## Run this sample.

1. Begin by creating the Agent client and reading the required environment variables. Please note that the Browser automation operations may take longer than usual and requiring request timeout to be at least 5 minutes.

```C# Snippet:Sample_CreateProjectClient_BrowserAutomotion
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var playwrightConnectionName = System.Environment.GetEnvironmentVariable("PLAYWRIGHT_CONNECTION_NAME");
AIProjectClientOptions options = new()
{
    NetworkTimeout = TimeSpan.FromMinutes(5)
};
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
```

2. Create an Agent with  `BrowserAutomationAgentTool`. Use the serverless connection name to get the connection from the project and use the connection ID to create the tool.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_BrowserAutomotion_Sync
AIProjectConnection playwrightConnection = projectClient.Connections.GetConnection(playwrightConnectionName);
BrowserAutomationPreviewTool playwrightTool = new(
    new BrowserAutomationToolParameters(
        new BrowserAutomationToolConnectionParameters(playwrightConnection.Id)
    ));

PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are an Agent helping with browser automation tasks.\n" +
    "You can answer questions, provide information, and assist with various tasks\n" +
    "related to web browsing using the Browser Automation tool available to you.",
    Tools = { playwrightTool }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_BrowserAutomotion_Async
AIProjectConnection playwrightConnection = await projectClient.Connections.GetConnectionAsync(playwrightConnectionName);
BrowserAutomationPreviewTool playwrightTool = new(
    new BrowserAutomationToolParameters(
        new BrowserAutomationToolConnectionParameters(playwrightConnection.Id)
    ));

PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are an Agent helping with browser automation tasks.\n" +
    "You can answer questions, provide information, and assist with various tasks\n" +
    "related to web browsing using the Browser Automation tool available to you.",
    Tools = {playwrightTool}
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. To parse the stream, obtained from the Agent, we will create a helper method `ParseResponse`.

```C# Snippet:Sample_ParseResponse_BrowserAutomotion
private static void ParseResponse(StreamingResponseUpdate streamResponse)
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
        Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
    }
}
```

4. Create the response stream. We also make sure that the agent using tool by setting `ToolChoice = ResponseToolChoice.CreateRequiredChoice()` on the `CreateResponseOptions`.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    StreamingEnabled = true,
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
            "To do that, go to the website finance.yahoo.com.\n" +
            "At the top of the page, you will find a search bar.\n" +
            "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
            "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
            "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it.")
    }
};
foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreaming(responseOptions))
{
    ParseResponse(update);
}
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    StreamingEnabled = true,
    InputItems =
    {
        ResponseItem.CreateUserMessageItem("Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
            "To do that, go to the website finance.yahoo.com.\n" +
            "At the top of the page, you will find a search bar.\n" +
            "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
            "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
            "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it.")
    }
};
await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(responseOptions))
{
    ParseResponse(update);
}
```

9. After the sample is completed, delete the Agent we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

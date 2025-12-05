# Sample for use of `BrowserAutomationAgentTool` and Agents in Azure.AI.Projects.OpenAI.

Playwright is a Node.js library for browser automation. Microsoft offers the [Azue Playwright workspace](https://learn.microsoft.com/javascript/api/overview/azure/playwright-readme), allowing to run Playwright-based tasks, which can be triggered by the Agent, equipped with `BrowserAutomationAgentTool`.
To run this sample, please deploy an Azure Playwright workspace and in the "Get started" section select "2. Set up authentication." Choose "Service Access Token" and click "Generate Token". **Please save the token as when the page is closed, it will not be shown again!**. In the Microsoft Foundry you use, at the left panel select "Management center" and then select "Connected resources", and, finally, create new connection of "Serverless Model" type; name it and add an Access Token to the "Key" field and set Playwright Workspace Browser endpoint as a "Target URI". The latter can be found on the "Overview" page of a Workspace. It should start with `wss://`.

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
BrowserAutomationAgentTool playwrightTool = new(
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
BrowserAutomationAgentTool playwrightTool = new(
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

4. Create the response stream. We also make sure that the agent using tool by setting `ToolChoice = ResponseToolChoice.CreateRequiredChoice()` on the `ResponseCreationOptions`.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseCreationOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice()
};
foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreaming(
        userInputText: "Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
        "To do that, go to the website finance.yahoo.com.\n" +
        "At the top of the page, you will find a search bar.\n" +
        "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
        "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
        "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it.",
        options: responseOptions))
{
    ParseResponse(update);
}
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseCreationOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice()
};
await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(
        userInputText: "Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
        "To do that, go to the website finance.yahoo.com.\n" +
        "At the top of the page, you will find a search bar.\n" +
        "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
        "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
        "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it.",
        options: responseOptions))
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

# Sample for use of `BrowserAutomationTool` and Agents in Azure.AI.Extensions.OpenAI.

Playwright is an open-source framework for end-to-end testing and browser automation. Microsoft Playwright Workspaces provides managed cloud browsers that an agent can access through the BrowserAutomationTool.

## Create Azure Playwright workspace

1. In the Azure portal, open your Playwright workspace.
2. Under **Settings**, select **Access Management**.
3. Enable **Playwright Service Access Token**.
4. Select **Generate token**.
5. Enter a name and expiration date, and then generate the token.
6. Copy the token immediately. You can't retrieve its value later.

> **Warning:** Prefer Microsoft Entra ID authentication when supported by the Browser Automation connection. Workspace access tokens are less secure and are disabled by default. Treat an access token like a password, and never commit it to source control or include it in prompts or logs.

## Configure Microsoft Foundry

**Note:** `BrowserAutomationTool` uses a Browser Automation project connection as opposed to `BrowserAutomationPreviewTool`, which uses a Serverless connection type.

Follow [Set up Browser Automation in Microsoft Foundry](https://learn.microsoft.com/azure/foundry/agents/how-to/tools/browser-automation#set-up-browser-automation) to connect your Playwright workspace:

1. Open your project in the Microsoft Foundry portal and select **Build** > **Tools**.
2. Select **Create a toolbox** and enter a name and description.
3. Under **Tools**, select **Add**, choose **Browser Automation**, and select **Add tool**.
4. Enter a connection name, select your **Playwright Workspace**, and choose the authentication method.
5. Select **Connect**, then **Publish** to save the toolbox.
6. Set `BROWSER_AUTOMATION_NAME` to the connection name you entered. The sample looks up the connection and passes its ID to the tool.

## Run this sample.

1. Create an `AIProjectClient` and read the required environment variables. Browser automation operations can take longer than other requests, so configure a network timeout of at least five minutes.

```C# Snippet:Sample_CreateProjectClient_BrowserAutomotion
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var playwrightConnectionName = System.Environment.GetEnvironmentVariable("BROWSER_AUTOMATION_NAME");
AIProjectClientOptions options = new()
{
    NetworkTimeout = TimeSpan.FromMinutes(5)
};
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
```

2. Look up the Browser Automation connection by name, create an agent with a `BrowserAutomationTool`, and pass the returned connection ID to `BrowserAutomationToolConnectionOptions`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_BrowserAutomotion_Sync
AIProjectConnection playwrightConnection = projectClient.Connections.GetConnection(playwrightConnectionName);
BrowserAutomationTool playwrightTool = new(
    new BrowserAutomationToolOptions(
        new BrowserAutomationToolConnectionOptions(playwrightConnection.Id)
    ));

DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are an Agent helping with browser automation tasks.\n" +
    "You can answer questions, provide information, and assist with various tasks\n" +
    "related to web browsing using the Browser Automation tool available to you.",
    Tools = { playwrightTool }
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_BrowserAutomotion_Async
AIProjectConnection playwrightConnection = await projectClient.Connections.GetConnectionAsync(playwrightConnectionName);
BrowserAutomationTool playwrightTool = new(
    new BrowserAutomationToolOptions(
        new BrowserAutomationToolConnectionOptions(playwrightConnection.Id)
    ));

DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are an Agent helping with browser automation tasks.\n" +
    "You can answer questions, provide information, and assist with various tasks\n" +
    "related to web browsing using the Browser Automation tool available to you.",
    Tools = { playwrightTool }
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. Create a `ParseResponse` helper method to process streaming response updates from the agent. Handle failed or incomplete responses using the SDK's typed updates.

> **Warning:** Streaming text and complete messages can include a live-view URL that grants access to the browser session. Treat that URL as sensitive: use it only in a trusted local terminal and redact it before sharing output or saving logs.

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
        throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}, error code: {errorUpdate.Code}");
    }
    else if (streamResponse is StreamingResponseFailedUpdate failedUpdate)
    {
        throw new InvalidOperationException($"The response has failed: {failedUpdate.Response.Error?.Message}, error code: {failedUpdate.Response.Error?.Code}");
    }
    else if (streamResponse is StreamingResponseIncompleteUpdate incompleteUpdate)
    {
        throw new InvalidOperationException($"The response cannot be completed. Check the request for safety or guardrail requirements and review response {incompleteUpdate.Response.Id} for details, including output limits.");
    }
}
```

4. Create a streaming response. Require the agent to use a tool by setting `ToolChoice = ResponseToolChoice.CreateRequiredChoice()` on `CreateResponseOptions`.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
    new AgentReference(agentVersion.Name, agentVersion.Version));
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
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
    new AgentReference(agentVersion.Name, agentVersion.Version));
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

5. After the sample completes, delete the agent version that you created. Agents can be reused across responses. Delete an agent version only when it is no longer needed.

Synchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

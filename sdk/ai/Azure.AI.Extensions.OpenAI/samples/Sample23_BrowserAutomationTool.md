# Sample for use of `BrowserAutomationTool` and Agents in Azure.AI.Extensions.OpenAI.

Playwright is an open-source framework for end-to-end testing and browser automation. Microsoft Playwright Workspaces provides managed cloud browsers that an agent can access through the BrowserAutomationTool.

## Create Azure Playwright workspace

1. In the Azure portal, open your Playwright workspace.
2. Under **Settings**, select **Access Management**.
3. Enable **Playwright Service Access Token**.
4. Select **Generate token**.
5. Enter a name and expiration date, and then generate the token.
6. Copy the token immediately. You can't retrieve its value later.

> **Warning:** Use Microsoft Entra ID when the MCP client supports it. Workspace access tokens are less secure and are disabled by default. Treat an access token like a password, and never commit it to source control or include it in prompts or logs.

## Configure Microsoft Foundry

**Note:** The `BrowserAutomationTool` is using MCP connection as opposed to `BrowserAutomationPreviewTool`, which uses the serverless connection.

See the [Playwright Workspaces remote MCP quickstart](https://learn.microsoft.com/azure/app-testing/playwright-cloud-browsers/quickstart-automate-browser-tasks-remote-mcp) to configure the connection. Microsoft Entra ID is the preferred authentication method. For instructions to create a project connection, see [Automate browsers with the Playwright Workspaces remote MCP server](https://learn.microsoft.com/azure/app-testing/playwright-cloud-browsers/how-to-playwright-workspaces-remote-mcp). You can also use a workspace access token as described in the following steps.
1. In the Microsoft foundry portal select **Build**.
2. On the left panel select **Tools** sectrion and click **Connect a tool**.
3. In the opened window select **Custom** tab, choose **Model Context Protocol (MCP)** and click **Create**.
4. Name the connection.
5. Open the Playwright workspace in the Azure portal and copy the Mcp endpoint address to `Remote MCP Server endpoint` (Mcp endpoint can be found on the **Overview** section).
6. Paste the token generagted in the previous section to "Credential" section and name this key `Authorization`.
7. Click **Connect**.

## Run this sample.

1. Create an `AIProjectClient` and read the required environment variables. Browser automation operations can take longer than other requests, so configure a network timeout of at least five minutes.

```C# Snippet:Sample_CreateProjectClient_BrowserAutomotion
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var playwrightConnectionName = System.Environment.GetEnvironmentVariable("PLAYWRIGHT_MCP_CONNECTION_NAME");
AIProjectClientOptions options = new()
{
    NetworkTimeout = TimeSpan.FromMinutes(5)
};
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
```

2. Create an agent with a `BrowserAutomationTool`, and pass the MCP project connection name to `BrowserAutomationToolConnectionOptions`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_BrowserAutomotion_Sync
BrowserAutomationTool playwrightTool = new(
    new BrowserAutomationToolOptions(
        new BrowserAutomationToolConnectionOptions(playwrightConnectionName)
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
BrowserAutomationTool playwrightTool = new(
    new BrowserAutomationToolOptions(
        new BrowserAutomationToolConnectionOptions(playwrightConnectionName)
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

3. Create a `ParseResponse` helper method to process streaming response updates from the agent.

```C# Snippet:Sample_ParseResponse_BrowserAutomotion
private static void ParseResponse(StreamingResponseUpdate streamResponse)
{
    StringBuilder errorMessage = new();
    string errorCode = default;
    bool hasError = false;
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
        hasError = true;
        if (!string.IsNullOrEmpty(errorUpdate.Code))
        {
            errorCode = errorUpdate.Code;
        }
        if (!string.IsNullOrEmpty(errorUpdate.Message))
        {
            errorMessage.Append(errorUpdate.Message);
        }
    }
    if (hasError)
    {
        throw new InvalidOperationException($"The stream has failed with the error: {errorMessage}, error code: {errorCode}");
    }
}
```

4. Create a streaming response. Require the agent to use a tool by setting `ToolChoice = ResponseToolChoice.CreateRequiredChoice()` on `CreateResponseOptions`.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
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
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
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

5. After the sample completes, delete the agent version that you created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

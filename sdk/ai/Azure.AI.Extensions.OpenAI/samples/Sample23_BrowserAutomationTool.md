# Sample for use of `BrowserAutomationTool` and Agents in Azure.AI.Extensions.OpenAI.

Playwright is an open-source framework for end-to-end testing and browser automation. Microsoft Playwright Workspaces provides managed cloud browsers that an agent can access through the BrowserAutomationTool.

## Create Azure Playwright workspace

1. In the Azure portal, open your Playwright workspace.
2. Under **Settings**, select **Access Management**.
3. Enable **Playwright Service Access Token**.
4. Select **Generate token**.
5. Enter a name and expiration date, and then generate the token.
6. Copy the token immediately. You can't retrieve its value later.

> **Warning:** Prefer Microsoft Entra ID authentication when supported by the PlaywrightWorkspaces connection. Workspace access tokens are less secure and are disabled by default. Treat an access token like a password, and never commit it to source control or include it in prompts or logs.

## Configure Microsoft Foundry

**Note:** `BrowserAutomationTool` uses a PlaywrightWorkspaces connection. `BrowserAutomationPreviewTool` uses a Serverless Model connection.

Follow [Set up Browser Automation in Microsoft Foundry](https://learn.microsoft.com/azure/foundry/agents/how-to/tools/browser-automation#set-up-browser-automation) to connect your Playwright workspace. In the Foundry portal, select **Build** > **Tools**, create a toolbox, and add **Browser Automation**. Select your Playwright workspace and authentication method to create the PlaywrightWorkspaces connection. Copy the **Project connection ID** from the tool's details page for use in this sample.

## Run this sample.

1. Create an `AIProjectClient` and read the required environment variables: `FOUNDRY_PROJECT_ENDPOINT`, `FOUNDRY_MODEL_NAME`, and `BROWSER_AUTOMATION_PROJECT_CONNECTION_ID`. Set `BROWSER_AUTOMATION_PROJECT_CONNECTION_ID` to the full project connection resource ID, not just the connection name. Browser automation operations can take longer than other requests, so configure a network timeout of at least five minutes.

```C# Snippet:Sample_CreateProjectClient_BrowserAutomotion
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var playwrightConnectionId = System.Environment.GetEnvironmentVariable("BROWSER_AUTOMATION_PROJECT_CONNECTION_ID");
AIProjectClientOptions options = new()
{
    NetworkTimeout = TimeSpan.FromMinutes(5)
};
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
```

2. Create an agent with `BrowserAutomationTool`, and pass the full project connection resource ID to `BrowserAutomationToolConnectionOptions`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_BrowserAutomotion_Sync
BrowserAutomationTool playwrightTool = new(
    new BrowserAutomationToolOptions(
        new BrowserAutomationToolConnectionOptions(playwrightConnectionId)
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
        new BrowserAutomationToolConnectionOptions(playwrightConnectionId)
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

3. Create a `ParseResponse` helper method to process streaming response updates from the agent. Print each complete message once, rather than printing text deltas. Handle failed or incomplete responses using the SDK's typed updates.

> **Warning:** Complete text messages can include a live-view URL that grants access to the browser session. Treat that URL as sensitive: use it only in a trusted local terminal and redact it before sharing output or saving logs.

```C# Snippet:Sample_ParseResponse_BrowserAutomotion
private static void ParseResponse(StreamingResponseUpdate streamResponse)
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
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
        throw new InvalidOperationException($"The response is incomplete: {incompleteUpdate.Response.Id}");
    }
}
```

4. Create a streaming response using the exact agent version created above. Ask the agent to navigate Yahoo Finance and report the percent of Microsoft year-to-date stock price change.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
    new AgentReference(agentVersion.Name, agentVersion.Version));
CreateResponseOptions responseOptions = new()
{
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

Agents can be reused across responses. Delete an agent version only when it is no longer needed; administration operations may require different permissions from invoking an agent. The live sample tests clean up their created version in test teardown, outside the customer-facing snippets.

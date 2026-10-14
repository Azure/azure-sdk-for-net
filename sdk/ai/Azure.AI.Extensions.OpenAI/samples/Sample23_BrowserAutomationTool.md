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

**Note:** `BrowserAutomationTool` uses a PlaywrightWorkspaces connection, not a generic MCP connection. `BrowserAutomationPreviewTool` uses a Serverless Model connection.

Follow [Set up Browser Automation in Microsoft Foundry](https://learn.microsoft.com/azure/foundry/agents/how-to/tools/browser-automation#set-up-browser-automation) to connect your Playwright workspace. In the Foundry portal, select **Build** > **Tools**, create a toolbox, and add **Browser Automation**. Select your Playwright workspace and authentication method to create the PlaywrightWorkspaces connection. Copy the **Project connection ID** from the tool's details page for use in this sample.

## Run this sample.

1. Create an `AIProjectClient` and read the required environment variables: `FOUNDRY_PROJECT_ENDPOINT`, `FOUNDRY_MODEL_NAME`, and `PLAYWRIGHT_MCP_CONNECTION_NAME`. Despite its name, `PLAYWRIGHT_MCP_CONNECTION_NAME` must contain the full project connection resource ID, not just the connection name. Browser automation operations can take longer than other requests, so configure a network timeout of at least five minutes. `DefaultAzureCredential` can use your Azure CLI login for local development.

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

2. Create an agent with the GA `BrowserAutomationTool` (`browser_automation`), and pass the PlaywrightWorkspaces project connection resource ID to `BrowserAutomationToolConnectionOptions`.

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

3. Create a `ParseResponse` helper method to process streaming response updates from the agent. Print each complete message once on `response.output_text.done`, rather than printing text deltas. GA browser actions arrive as `remote_function_call` and `remote_function_call_output` items. These items are not strongly typed in the current SDK, so inspect their JSON to log action names, call IDs, and arguments without `browserSessionId`. Do not log raw tool outputs, which may contain sensitive session information.

> **Warning:** Complete text messages can include a live-view URL that grants access to the browser session. Treat that URL as sensitive: use it only in a trusted local terminal and redact it before sharing output or saving logs.

```C# Snippet:Sample_ParseResponse_BrowserAutomotion
private static bool ParseResponse(StreamingResponseUpdate streamResponse)
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
    }
    else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
    {
        Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
    }
    else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
    {
        // GA browser actions use remote function items, which are not strongly typed by this SDK.
        string kind = itemDoneUpdate.Item.Kind.ToString();
        if (kind == "remote_function_call" || kind == "remote_function_call_output")
        {
            JsonNode item = JsonNode.Parse(ModelReaderWriter.Write(itemDoneUpdate.Item).ToString());
            string callId = item["call_id"].GetValue<string>();
            if (kind == "remote_function_call")
            {
                JsonObject arguments = JsonNode.Parse(item["arguments"].GetValue<string>()).AsObject();
                arguments.Remove("browserSessionId");
                Console.WriteLine($"Browser action: {item["name"].GetValue<string>()}, call ID: {callId}, arguments: {arguments.ToJsonString()}");
            }
            else
            {
                Console.WriteLine($"Browser action completed: {callId}");
            }
        }
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
    return streamResponse is StreamingResponseCompletedUpdate;
}
```

4. Create a streaming response using the exact agent version created above. Ask the agent to visit `https://example.com` and report its title and description based on the browser results. Leave tool choice at its default so the agent can finish with a text answer after using the browser. Failed, incomplete, and prematurely ended streams must throw rather than appear successful.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
try
{
    ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
        new AgentReference(agentVersion.Name, agentVersion.Version));
    CreateResponseOptions responseOptions = new()
    {
        StreamingEnabled = true,
        InputItems =
        {
            ResponseItem.CreateUserMessageItem("Use the Browser Automation tool to visit https://example.com. " +
                "Read the page and report its title and the visible description paragraph. " +
                "Base your answer on the browser results, not on prior knowledge.")
        }
    };
    bool responseCompleted = false;
    foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreaming(responseOptions))
    {
        responseCompleted |= ParseResponse(update);
    }
    if (!responseCompleted)
    {
        throw new InvalidOperationException("The stream ended before the response completed.");
    }
}
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_BrowserAutomotion_Async
try
{
    ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
        new AgentReference(agentVersion.Name, agentVersion.Version));
    CreateResponseOptions responseOptions = new()
    {
        StreamingEnabled = true,
        InputItems =
        {
            ResponseItem.CreateUserMessageItem("Use the Browser Automation tool to visit https://example.com. " +
                "Read the page and report its title and the visible description paragraph. " +
                "Base your answer on the browser results, not on prior knowledge.")
        }
    };
    bool responseCompleted = false;
    await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(responseOptions))
    {
        responseCompleted |= ParseResponse(update);
    }
    if (!responseCompleted)
    {
        throw new InvalidOperationException("The stream ended before the response completed.");
    }
}
```

5. Use `finally` to delete only the agent version that you created, whether the response succeeds or fails. Do not delete the whole agent or other retained versions.

Synchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Sync
finally
{
    projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_BrowserAutomotion_Async
finally
{
    await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
```

# Sample using Agents with Toolbox and a search for a tool in Azure.AI.Extensions.OpenAI.

In this example, we are demonstrating how to use Toolbox MCP server.

1. First, we need to create project client and read in the environment variables that will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_ToolSearch
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
DefaultAzureCredential credential = new();
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: credential);
AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
```

2. Create the toolbox, containing two tools: `CodeInterpreterTool` and `McpTool`. In both cases we must convert them from `ResponseTool` to `ProjectsAgentTool` object by calling `AsAgentTool` method.

Synchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolSearch_Sync
ProjectsAgentTool mcp = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ProjectsAgentTool codeInterpreter = ResponseTool.CreateCodeInterpreterTool(
    new CodeInterpreterToolContainer(
        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
    )
).AsAgentTool();
ToolboxSearchPreviewTool searchTool = new()
{
    Name = "ToolBoxSearch",
    Description = "Search for the toolboxes"
};
ToolboxVersion toolBox = toolboxClient.CreateToolboxVersion(
    name: "myToolbox",
    tools: [mcp, codeInterpreter, searchTool],
    description: "Example toolbox created by the azure-ai-projects sample."
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolSearch_Async
ProjectsAgentTool mcp = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ProjectsAgentTool codeInterpreter = ResponseTool.CreateCodeInterpreterTool(
    new CodeInterpreterToolContainer(
        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
    )
).AsAgentTool();
ToolboxSearchPreviewTool searchTool = new()
{
    Name = "ToolBoxSearch",
    Description = "Search for the toolboxes"
};
ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
    name: "myToolbox",
    tools: [mcp, codeInterpreter, searchTool],
    description: "Example toolbox created by the azure-ai-projects sample."
);
```

3. Create Agent with the `MCPTool`. The toolbox represents the MCP endpoint. To use it we need to provide the authentication token and a header, enabling the experimental feature.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_ToolSearch_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = {
        ResponseTool.CreateMcpTool(
            serverLabel: "search-tool",
            serverUri: new Uri($"{projectEndpoint}/toolboxes/{toolBox.Name}/versions/{toolBox.Version}/mcp?api-version=v1"),
            authorizationToken: credential.GetToken(new(scopes: ["https://ai.azure.com/.default"])).Token,
            headers: new Dictionary<string, string>() {
                { "Foundry-Features", "Toolboxes=V1Preview" }
            }
        ),
    }
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_ToolSearch_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = {
        ResponseTool.CreateMcpTool(
            serverLabel: "search-tool",
            serverUri: new Uri($"{projectEndpoint}/toolboxes/{toolBox.Name}/versions/{toolBox.Version}/mcp?api-version=v1"),
            authorizationToken: credential.GetToken(new(scopes: ["https://ai.azure.com/.default"])).Token,
            headers: new Dictionary<string, string>() {
                { "Foundry-Features", "Toolboxes=V1Preview" }
            }
        ),
    }
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

4. If the tool approval is required, the response item will be of `McpToolCallApprovalRequestItem` type and will contain all the information about tool call. In our example we will check that the server label is "search-tool" and will approve the tool call, we will deny all other calls, because they should not happen given our setup, then we will print the Agent output.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_ToolSearch_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem("What tools are available?") }
};
ResponseResult latestResponse = null;

while (nextResponseOptions is not null)
{
    latestResponse = responseClient.CreateResponse(nextResponseOptions);
    nextResponseOptions = null;

    foreach (ResponseItem responseItem in latestResponse.OutputItems)
    {
        if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
        {
            nextResponseOptions = new CreateResponseOptions()
            {
                PreviousResponseId = latestResponse.Id,
            };
            if (string.Equals(mcpToolCall.ServerLabel, "search-tool"))
            {
                Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                // Automatically approve the MCP request to allow the agent to proceed
                // In production, you might want to implement more sophisticated approval logic
                nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
            }
            else
            {
                Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
            }
        }
        else if (responseItem is McpToolDefinitionListItem listItem)
        {
            Console.WriteLine("Found tools:");
            foreach (McpToolDefinition tool in listItem.ToolDefinitions)
            {
                Console.WriteLine($"    {tool.Name}");
            }
        }
    }
}
Console.WriteLine(latestResponse.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_ToolSearch_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem("What tools are available?") }
};
ResponseResult latestResponse = null;

while (nextResponseOptions is not null)
{
    latestResponse = await responseClient.CreateResponseAsync(nextResponseOptions);
    nextResponseOptions = null;

    foreach (ResponseItem responseItem in latestResponse.OutputItems)
    {
        if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
        {
            nextResponseOptions = new CreateResponseOptions()
            {
                PreviousResponseId = latestResponse.Id,
            };
            if (string.Equals(mcpToolCall.ServerLabel, "search-tool"))
            {
                Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                // Automatically approve the MCP request to allow the agent to proceed
                // In production, you might want to implement more sophisticated approval logic
                nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
            }
            else
            {
                Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
            }
        }
        else if (responseItem is McpToolDefinitionListItem listItem)
        {
            Console.WriteLine("Found tools:");
            foreach (McpToolDefinition tool in listItem.ToolDefinitions)
            {
                Console.WriteLine($"    {tool.Name}");
            }
        }
    }
}
Console.WriteLine(latestResponse.GetOutputText());
```

5. Finally, we delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_ToolSearch_Sync
toolboxClient.DeleteToolbox(name: toolBox.Name);
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ToolSearch_Async
await toolboxClient.DeleteToolboxAsync(name: toolBox.Name);
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

# Sample using Agents with Toolbox and a RAI guardrails in Azure.AI.Extensions.OpenAI.

Responsible AI (RAI) helps to limit the information, returned by an Agent, for example, it helps to protect against the jailbreak or returning the user credential. In this example, we are demonstrating how to create and use Toolbox MCP server with RAI guardrails.

1. First, we need to create project client and read in the environment variables that will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_ToolBoxWithRAI
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var raiPolicyName = System.Environment.GetEnvironmentVariable("RAI_POLICY_NAME");
DefaultAzureCredential credential = new();
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: credential);
AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
```

2. Create a toolbox with the MCP tool, using Github. also provide the RAI policy. RAI policies can be managed in Microsoft Foundry on the `Build` tab in `Guardrails` section.

Synchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolBoxWithRAI_Sync
ProjectsAgentTool mcp = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ToolboxPolicies raiPolicies = new()
{
    RaiConfig = new(raiPolicyName)
};
ToolboxVersion toolBox = toolboxClient.CreateToolboxVersion(
    name: "myToolbox",
    tools: [mcp],
    policies: raiPolicies,
    description: "Toolbox with guardrail."
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolBoxWithRAI_Async
ProjectsAgentTool mcp = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ToolboxPolicies raiPolicies = new()
{
    RaiConfig = new(raiPolicyName)
};
ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
    name: "myToolbox",
    tools: [mcp],
    policies: raiPolicies,
    description: "Toolbox with guardrail."
);
```

3. Create Agent with the `MCPTool`. The toolbox represents the MCP endpoint. To use it we need to provide the authentication token and a header, enabling the experimental feature.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_ToolBoxWithRAI_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = {
        ResponseTool.CreateMcpTool(
            serverLabel: "rai-github",
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
```C# Snippet:Sample_CreateAgent_ToolBoxWithRAI_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant.",
    Tools = {
        ResponseTool.CreateMcpTool(
            serverLabel: "rai-github",
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
```C# Snippet:Sample_CreateResponse_ToolBoxWithRAI_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme?") }
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
            if (string.Equals(mcpToolCall.ServerLabel, "rai-github"))
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
```C# Snippet:Sample_CreateResponse_ToolBoxWithRAI_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme?") }
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
            if (string.Equals(mcpToolCall.ServerLabel, "rai-github"))
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
```C# Snippet:Sample_Cleanup_ToolBoxWithRAI_Sync
toolboxClient.DeleteToolbox(name: toolBox.Name);
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ToolBoxWithRAI_Async
await toolboxClient.DeleteToolboxAsync(name: toolBox.Name);
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

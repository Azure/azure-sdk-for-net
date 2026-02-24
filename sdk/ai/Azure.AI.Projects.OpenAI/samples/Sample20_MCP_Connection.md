# Sample using Agents with MCP tool with project connection in Azure.AI.Projects.OpenAI.

In this example we are demonstrating how to authenticate in the GitHub MCP server and use it as a tool for an Agent. Before running sample, please log in to your GitHub profile, click on the profile picture at the upper right corner and select "Settings". At the left panel click "Developer Settings", select "Personal access tokens > Tokens (classic)". At the top choose "Generate new token" and enter password and create a token, which can read public repositories. **Save the token, or keep the page open as once the page is closed, token cannot be shown again!**
In the Azure portal open Microsoft Foundry you are using, at the left panel select "Management center" and then select "Connected resources". Create new connection of "Custom keys" type; name it and add a key value pair. Set the key name `Authorization` and the value should have a form of `Bearer your_github_token`.

1. First, we need to create project client and read in the environment variables that will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_MCPTool_ProjectConnection
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var mcpProjectConnectionName = System.Environment.GetEnvironmentVariable("MCP_PROJECT_CONNECTION_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create Agent with the `MCPTool`. Note that in this scenario we are using `GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval`, which means that any calls to the MCP server need to be approved. We then set the `ProjectConnectionId` property at on the `McpTool` so that agent will be able to authenticate in the GitHub.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_MCPTool_ProjectConnection_Sync
McpTool tool = ResponseTool.CreateMcpTool(
        serverLabel: "api-specs",
        serverUri: new Uri("https://api.githubcopilot.com/mcp"),
        toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
    ));
tool.ProjectConnectionId = mcpProjectConnectionName;
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
    Tools = { tool }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_MCPTool_ProjectConnection_Async
McpTool tool = ResponseTool.CreateMcpTool(
        serverLabel: "api-specs",
        serverUri: new Uri("https://api.githubcopilot.com/mcp"),
        toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
    ));
tool.ProjectConnectionId = mcpProjectConnectionName;
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
    Tools = { tool }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. If the tool approval is required, the response item will be of `McpToolCallApprovalRequestItem` type and will contain all the information about tool call. In our example we will check that the server label is "api-specs" and will approve the tool call, we will deny all other calls, because they should not happen given our setup, then we will print the Agent output.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_MCPTool_ProjectConnection_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new([ResponseItem.CreateUserMessageItem("What is my username in Github profile?")]);
ResponseResult latestResponse = null;

while (nextResponseOptions is not null)
{
    latestResponse = responseClient.CreateResponse(nextResponseOptions);
    nextResponseOptions = null;

    foreach (ResponseItem responseItem in latestResponse.OutputItems)
    {
        if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
        {
            nextResponseOptions = new()
            {
                PreviousResponseId = latestResponse.Id,
            };
            if (string.Equals(mcpToolCall.ServerLabel, "api-specs"))
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
    }
}
Console.WriteLine(latestResponse.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_MCPTool_ProjectConnection_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new([ResponseItem.CreateUserMessageItem("What is my username in Github profile?")]);
ResponseResult latestResponse = null;

while (nextResponseOptions is not null)
{
    latestResponse = await responseClient.CreateResponseAsync(nextResponseOptions);
    nextResponseOptions = null;

    foreach (ResponseItem responseItem in latestResponse.OutputItems)
    {
        if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
        {
            nextResponseOptions = new()
            {
                PreviousResponseId = latestResponse.Id,
            };
            if (string.Equals(mcpToolCall.ServerLabel, "api-specs"))
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
    }
}
Console.WriteLine(latestResponse.GetOutputText());
```

4. Finally, we delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_MCPTool_ProjectConnection_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_MCPTool_ProjectConnection_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

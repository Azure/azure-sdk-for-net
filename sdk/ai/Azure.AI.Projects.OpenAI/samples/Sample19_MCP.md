# Sample using Agents with MCP tool in Azure.AI.Projects.OpenAI.

In this example we are demonstrating how to use GitHub MCP server as a tool for an Agent.

1. First, we need to create project client and read in the environment variables that will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_MCPTool
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create Agent with the `MCPTool`. Note that in this scenario we are using `GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval`, which means that any calls to the MCP server need to be approved.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_MCPTool_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
    Tools = { ResponseTool.CreateMcpTool(
        serverLabel: "api-specs",
        serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
        toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
    )) }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_MCPTool_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
    Tools = { ResponseTool.CreateMcpTool(
        serverLabel: "api-specs",
        serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
        toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
    )) }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. If the tool approval is required, the response item will be of `McpToolCallApprovalRequestItem` type and will contain all the information about tool call. In our example we will check that the server label is "api-specs" and will approve the tool call, we will deny all other calls, because they should not happen given our setup, then we will print the Agent output.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_MCPTool_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseItem request = ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme");
List<ResponseItem> inputItems = [request];
bool mcpCalled = false;
string previousResponseId = default;
OpenAIResponse response;
do
{
    ResponseCreationOptions options = new()
    {
        PreviousResponseId = previousResponseId,
    };
    response = responseClient.CreateResponse(
        inputItems: inputItems,
        options
    );
    previousResponseId = response.Id;
    inputItems.Clear();
    mcpCalled = false;
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
        {
            mcpCalled = true;
            if (string.Equals(mcpToolCall.ServerLabel, "api-specs"))
            {
                Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                // Automatically approve the MCP request to allow the agent to proceed
                // In production, you might want to implement more sophisticated approval logic
                inputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
            }
            else
            {
                Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                inputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
            }
        }
    }
} while (mcpCalled);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_MCPTool_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseItem request = ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme");
List<ResponseItem> inputItems = [request];
bool mcpCalled = false;
string previousResponseId = default;
OpenAIResponse response;
do
{
    ResponseCreationOptions options = new()
    {
        PreviousResponseId = previousResponseId,
    };
    response = await responseClient.CreateResponseAsync(
        inputItems: inputItems,
        options
    );
    previousResponseId = response.Id;
    inputItems.Clear();
    mcpCalled = false;
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
        {
            mcpCalled = true;
            if (string.Equals(mcpToolCall.ServerLabel, "api-specs"))
            {
                Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                // Automatically approve the MCP request to allow the agent to proceed
                // In production, you might want to implement more sophisticated approval logic
                inputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
            }
            else
            {
                Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                inputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
            }
        }
    }
} while (mcpCalled);
Console.WriteLine(response.GetOutputText());
```

4. Finally, we delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_MCPTool_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_MCPTool_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

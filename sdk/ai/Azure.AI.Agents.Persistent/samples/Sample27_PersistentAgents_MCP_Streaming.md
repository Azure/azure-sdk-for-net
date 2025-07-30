# Sample for use of an agent with Model Context Protocol (MCP) tools in Azure.AI.Agents.Persistent with streaming scenarios.

To enable your Agent to use Model Context Protocol (MCP) tools, you use `MCPToolDefinition` along with server configuration and tool resources.
1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsMCPStreaming_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var mcpServerUrl = System.Environment.GetEnvironmentVariable("MCP_SERVER_URL");
var mcpServerLabel = System.Environment.GetEnvironmentVariable("MCP_SERVER_LABEL");
// Enable experimantal headers (needed only to list activity steps).
PersistentAgentsAdministrationClientOptions headerOptions = new();
CustomHeadersPolicy experimentalFeaturesHeader = new();
experimentalFeaturesHeader.AddHeader("x-ms-oai-assistants-testenv", "chat99");
headerOptions.AddPolicy(experimentalFeaturesHeader, Core.HttpPipelinePosition.PerCall);
//
PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential(), options: headerOptions);
```

2. We will create the MCP tool definition and configure allowed tools.

```C# Snippet:AgentsMCPStreamingAsync_CreateMCPTool
// Create MCP tool definition
MCPToolDefinition mcpTool = new(mcpServerLabel, mcpServerUrl);

// Configure allowed tools (optional)
string searchApiCode = "search_azure_rest_api_code";
mcpTool.AllowedTools.Add(searchApiCode);
```

3. We will use the `MCPToolDefinition` during the agent initialization.

Synchronous sample:
```C# Snippet:AgentsMCPStreaming_CreateAgent
PersistentAgent agent = agentClient.Administration.CreateAgent(
   model: modelDeploymentName,
   name: "my-mcp-agent",
   instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
   tools: [mcpTool]);
```

Asynchronous sample:
```C# Snippet:AgentsMCPStreamingAsync_CreateAgent
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-mcp-agent",
   instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
   tools: [mcpTool]
   );
```

4. Now we will create the thread, add the message containing a question for agent. We will also create tool resources, which we will use inside the streaming run on the next step.

Synchronous sample:
```C# Snippet:AgentsMCPStreaming_CreateThreadMessage
// Create thread for communication
PersistentAgentThread thread = agentClient.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "Please summarize the Azure REST API specifications Readme");

MCPToolResource mcpToolResource = new(mcpServerLabel);
mcpToolResource.UpdateHeader("SuperSecret", "123456");
ToolResources toolResources = mcpToolResource.ToToolResources();
CreateRunStreamingOptions options = new()
{
    ToolResources = toolResources
};
```

Asynchronous sample:
```C# Snippet:AgentsMCPStreamingAsync_CreateThreadMessage
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "Please summarize the Azure REST API specifications Readme");

MCPToolResource mcpToolResource = new(mcpServerLabel);
mcpToolResource.UpdateHeader("SuperSecret", "123456");
ToolResources toolResources = mcpToolResource.ToToolResources();
CreateRunStreamingOptions options = new()
{
    ToolResources = toolResources
};
```

5. To simplify the code we will use `PrintActivityStep` to display functions called and along with their parameters.

```C# Snippet:AgentsMCPStreaming_PrintActivityStep
private static void PrintActivityStep(RunStep step)
{
    if (step.StepDetails is RunStepActivityDetails activityDetails)
    {
        foreach (RunStepDetailsActivity activity in activityDetails.Activities)
        {
            foreach (KeyValuePair<string, ActivityFunctionDefinition> activityFunction in activity.Tools)
            {
                Console.WriteLine($"The function {activityFunction.Key} with description \"{activityFunction.Value.Description}\" will be called.");
                if (activityFunction.Value.Parameters.Properties.Count > 0)
                {
                    Console.WriteLine("Function parameters:");
                    foreach (KeyValuePair<string, FunctionArgument> arg in activityFunction.Value.Parameters.Properties)
                    {
                        Console.WriteLine($"\t{arg.Key}");
                        Console.WriteLine($"\t\t Type: {arg.Value.Type}");
                        if (!string.IsNullOrEmpty(arg.Value.Description))
                            Console.WriteLine($"\t\tDescription: {arg.Value.Description}");
                    }
                }
                else
                {
                    Console.WriteLine("This function has no parameters");
                }
            }
        }
    }
}
```

6. Start the streaming update loop. When asked, we will approve using tool.

Synchronous sample:
```C# Snippet:AgentsMCPStreaming_UpdateCycle
List<ToolApproval> toolApprovals = [];
ThreadRun streamRun = null;
CollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreaming(thread.Id, agent.Id, options: options);
do
{
    toolApprovals.Clear();
    foreach (StreamingUpdate streamingUpdate in stream)
    {
        if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
        {
            Console.WriteLine("--- Run started! ---");
        }
        else if (streamingUpdate is SubmitToolApprovalUpdate submitToolApprovalUpdate)
        {
            Console.WriteLine($"Approving MCP tool call: {submitToolApprovalUpdate.Name}, Arguments: {submitToolApprovalUpdate.Arguments}");
            toolApprovals.Add(new ToolApproval(submitToolApprovalUpdate.ToolCallId, approve: true)
            {
                Headers = { ["SuperSecret"] = "123456" }
            });
            streamRun = submitToolApprovalUpdate.Value;
        }
        else if (streamingUpdate is MessageContentUpdate contentUpdate)
        {
            Console.Write(contentUpdate.Text);
        }
        else if (streamingUpdate is RunStepUpdate runStepUpdate)
        {
            PrintActivityStep(runStepUpdate.Value);
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
        {
            Console.WriteLine();
            Console.WriteLine("--- Run completed! ---");
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
        {
            Console.WriteLine($"Error: {errorStep.Value.LastError}");
        }
    }
    if (toolApprovals.Count > 0)
    {
        stream = agentClient.Runs.SubmitToolOutputsToStream(streamRun, toolOutputs: [], toolApprovals: toolApprovals);
    }
}
while (toolApprovals.Count > 0);
```

Asynchronous sample:
```C# Snippet:AgentsMCPStreamingAsync_UpdateCycle
List<ToolApproval> toolApprovals = [];
ThreadRun streamRun = null;
AsyncCollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreamingAsync(thread.Id, agent.Id, options: options);
do
{
    toolApprovals.Clear();
    await foreach (StreamingUpdate streamingUpdate in stream)
    {
        if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
        {
            Console.WriteLine("--- Run started! ---");
        }
        else if (streamingUpdate is SubmitToolApprovalUpdate submitToolApprovalUpdate)
        {
            Console.WriteLine($"Approving MCP tool call: {submitToolApprovalUpdate.Name}, Arguments: {submitToolApprovalUpdate.Arguments}");
            toolApprovals.Add(new ToolApproval(submitToolApprovalUpdate.ToolCallId, approve: true)
            {
                Headers = { ["SuperSecret"] = "123456" }
            });
            streamRun = submitToolApprovalUpdate.Value;
        }
        else if (streamingUpdate is MessageContentUpdate contentUpdate)
        {
            Console.Write(contentUpdate.Text);
        }
        else if (streamingUpdate is RunStepUpdate runStepUpdate)
        {
            PrintActivityStep(runStepUpdate.Value);
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
        {
            Console.WriteLine();
            Console.WriteLine("--- Run completed! ---");
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
        {
            Console.WriteLine($"Error: {errorStep.Value.LastError}");
        }
    }
    if (toolApprovals.Count > 0)
    {
        stream = agentClient.Runs.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs: [], toolApprovals: toolApprovals);
    }
}
while (toolApprovals.Count > 0);
```

5. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:AgentsMCPStreamingCleanup
agentClient.Threads.DeleteThread(threadId: thread.Id);
agentClient.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsMCPStreamingCleanupAsync
await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
```

# Sample for Toolboxes Administration (creation, retrieval and deletion) in Azure.AI.Projects

In this example we will demonstrate how .

1. First, we need to create `AgentToolboxes` client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_ToolboxesCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
string toolboxName = "mcp";
```

2. Use the client to create versioned toolbox object.

Synchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolboxesCRUD_Sync
ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ToolboxVersion toolBox = toolboxClient.CreateToolboxVersion(
    toolboxName: toolboxName,
    tools: [tool],
    description: "Example toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"status", "created"}
    }
);
string status = "unknown status";
toolBox.Metadata?.TryGetValue("status", out status);
Console.WriteLine($"Toolbox: {toolBox.Name}, (tools: {toolBox.Tools.Count}) (status: {status}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolboxesCRUD_Async
ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
    toolboxName: toolboxName,
    tools: [tool],
    description: "Example toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"status", "created"}
    }
);
string status = "unknown status";
toolBox.Metadata?.TryGetValue("status", out status);
Console.WriteLine($"Toolbox: {toolBox.Name}, (tools: {toolBox.Tools.Count}) (status: {status}");
```

3. Retrieve the toolbox object.

Synchronous sample:
```C# Snippet:Sample_GetToolbox_ToolboxesCRUD_Sync
toolBox = toolboxClient.GetToolboxVersion(toolBox.Name, toolBox.Version);
Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
```

Asynchronous sample:
```C# Snippet:Sample_GetToolbox_ToolboxesCRUD_Async
toolBox = await toolboxClient.GetToolboxVersionAsync(toolBox.Name, toolBox.Version);
Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
```

4. List all toolboxes.

Synchronous sample:
```C# Snippet:Sample_ListToolbox_ToolboxesCRUD_Sync
List<ToolboxVersion> toolboxes = [..toolboxClient.GetToolboxVersions(toolBox.Name)];
Console.WriteLine($"Found {toolboxes.Count} toolsets");
foreach (ToolboxVersion item in toolboxes)
{
    Console.WriteLine($"  - {item.Name} ({item.Id})");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListToolbox_ToolboxesCRUD_Async
List<ToolboxVersion> toolboxes = await toolboxClient.GetToolboxVersionsAsync(toolBox.Name).ToListAsync();
Console.WriteLine($"Found {toolboxes.Count} toolsets");
foreach (ToolboxVersion item in toolboxes)
{
    Console.WriteLine($"  - {item.Name} ({item.Id})");
}
```

5. Finally, remove toolbox we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteToolbox_ToolboxesCRUD_Sync
toolboxClient.DeleteToolbox(toolBox.Name);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteToolbox_ToolboxesCRUD_Async
await toolboxClient.DeleteToolboxAsync(toolBox.Name);
```

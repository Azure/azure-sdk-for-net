# Sample for Toolboxes Administration (create, retrieve, update and deletion) in Azure.AI.Projects.Agents

In this example we will demonstrate how to create, update and delete toolboxes.
To use toolboxes we need to provide the `Foundry-Features` header in our REST requests. It can be done using `PipelinePolicy`.

```C# Snippet:Sample_Agents_ExperimentalHeader
internal class FeaturePolicy(string feature) : PipelinePolicy
{
    private const string _FEATURE_HEADER = "Foundry-Features";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

We also need to ignore the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

1. First, we need to create `AgentToolboxes` client and read the environment variables, which will be used in the next steps. We also will add the experimental header policy to the client.

```C# Snippet:Sample_CreateClient_ToolboxesAgentsCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AgentAdministrationClientOptions options = new();
options.AddPolicy(new FeaturePolicy("Toolboxes=V1Preview"), PipelinePosition.PerCall);
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
string toolboxName = "mcp";
```

2. Use the client to create two `ToolboxVersion` objects.

Synchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolboxesAgentsCRUD_Sync
ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ToolboxVersion toolBox1 = toolboxClient.CreateToolboxVersion(
    name: toolboxName,
    tools: [tool],
    description: "Example toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"team", "Engineers"}
    }
);
ToolboxVersion toolBox2 = toolboxClient.CreateToolboxVersion(
    name: toolboxName,
    tools: [tool],
    description: "Another toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"team", "Data scientists"}
    }
);
string status = "unknown status";
toolBox1.Metadata?.TryGetValue("team", out status);
Console.WriteLine($"Toolbox: {toolBox1.Name}, version: {toolBox1.Version}, (tools: {toolBox1.Tools.Count}) (team: {status}).");
```

Asynchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolboxesAgentsCRUD_Async
ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
    serverLabel: "api-specs",
    serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
    toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
));
ToolboxVersion toolBox1 = await toolboxClient.CreateToolboxVersionAsync(
    name: toolboxName,
    tools: [tool],
    description: "Example toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"team", "Engineers"}
    }
);
ToolboxVersion toolBox2 = await toolboxClient.CreateToolboxVersionAsync(
    name: toolboxName,
    tools: [tool],
    description: "Another toolbox created by the azure-ai-projects sample.",
    metadata: new Dictionary<string, string> {
        {"team", "Data scientists"}
    }
);
string status = "unknown status";
toolBox1.Metadata?.TryGetValue("team", out status);
Console.WriteLine($"Toolbox: {toolBox1.Name}, version: {toolBox1.Version}, (tools: {toolBox1.Tools.Count}) (team: {status}).");
```

3. Retrieve the `ToolboxRecord` object. This object contains the name and a default version of a toolbox.

Synchronous sample:
```C# Snippet:Sample_GetToolbox_ToolboxesAgentsCRUD_Sync
ToolboxRecord record = toolboxClient.GetToolbox(name: toolBox1.Name);
Console.WriteLine($"The default version for a toolbox {record.Name} is {record.DefaultVersion}");
```

Asynchronous sample:
```C# Snippet:Sample_GetToolbox_ToolboxesAgentsCRUD_Async
ToolboxRecord record = await toolboxClient.GetToolboxAsync(name: toolBox1.Name);
Console.WriteLine($"The default version for a toolbox {record.Name} is {record.DefaultVersion}");
```

4. Using the default version we have obtained from `ToolboxRecord` we can get the `ToolboxVersion` object for it.

Synchronous sample:
```C# Snippet:Sample_GetToolboxVersion_ToolboxesAgentsCRUD_Sync
ToolboxVersion toolBox = toolboxClient.GetToolboxVersion(record.Name, record.DefaultVersion);
Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
```

Asynchronous sample:
```C# Snippet:Sample_GetToolboxVersion_ToolboxesAgentsCRUD_Async
ToolboxVersion toolBox = await toolboxClient.GetToolboxVersionAsync(record.Name, record.DefaultVersion);
Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
```

5. To update the default version of `ToolboxRecord` we can use `UpdateToolboxAsync` or `UpdateToolbox` methods.

Synchronous sample:
```C# Snippet:Sample_UpdateToolbox_ToolboxesAgentsCRUD_Sync
string newVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
record = toolboxClient.UpdateToolbox(toolboxName, newVersion);
Console.WriteLine($"The default version for a toolbox {record.Name} is now {record.DefaultVersion}");
```

Asynchronous sample:
```C# Snippet:Sample_UpdateToolbox_ToolboxesAgentsCRUD_Async
string newVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
record = await toolboxClient.UpdateToolboxAsync(toolboxName, newVersion);
Console.WriteLine($"The default version for a toolbox {record.Name} is now {record.DefaultVersion}");
```

6. List all the toolbox versions.

Synchronous sample:
```C# Snippet:Sample_ListToolboxVersions_ToolboxesAgentsCRUD_Sync
List<ToolboxVersion> toolboxes = [.. toolboxClient.GetToolboxVersions(toolBox.Name)];
Console.WriteLine($"Found {toolboxes.Count} toolbox version(s).");
foreach (ToolboxVersion item in toolboxes)
{
    Console.WriteLine($"  - {item.Name} ({item.Version})");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListToolboxVersions_ToolboxesAgentsCRUD_Async
List<ToolboxVersion> toolboxes = await toolboxClient.GetToolboxVersionsAsync(toolBox.Name).ToListAsync();
Console.WriteLine($"Found {toolboxes.Count} toolbox version(s).");
foreach (ToolboxVersion item in toolboxes)
{
    Console.WriteLine($"  - {item.Name} ({item.Version})");
}
```

7. List all the toolboxes.

Synchronous sample:
```C# Snippet:Sample_ListToolboxes_ToolboxesAgentsCRUD_Sync
List<ToolboxRecord> records = [.. toolboxClient.GetToolboxes()];
Console.WriteLine($"Found {records.Count} toolbox(es).");
foreach (ToolboxRecord item in records)
{
    Console.WriteLine($"  - {item.Name} ({item.Id})");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListToolboxes_ToolboxesAgentsCRUD_Async
List<ToolboxRecord> records = await toolboxClient.GetToolboxesAsync().ToListAsync();
Console.WriteLine($"Found {records.Count} toolbox(es).");
foreach (ToolboxRecord item in records)
{
    Console.WriteLine($"  - {item.Name} ({item.Id})");
}
```

5. Finally, remove toolboxes we have created. We can remove the specific version of toolbox by using `DeleteToolboxVersionAsync` and `DeleteToolboxVersion`, or we can use `DeleteToolboxAsync` and `DeleteToolbox` to remove all versions at once.

Synchronous sample:
```C# Snippet:Sample_DeleteToolbox_ToolboxesAgentsCRUD_Sync
// We cannot delete the default version.
string deleteVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
toolboxClient.DeleteToolboxVersion(toolBox.Name, deleteVersion);
toolboxClient.DeleteToolbox(toolBox.Name);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteToolbox_ToolboxesAgentsCRUD_Async
// We cannot delete the default version.
string deleteVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
await toolboxClient.DeleteToolboxVersionAsync(toolBox.Name, deleteVersion);
await toolboxClient.DeleteToolboxAsync(toolBox.Name);
```

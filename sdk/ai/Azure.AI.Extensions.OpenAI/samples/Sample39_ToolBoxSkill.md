# Sample on getting responses from an Agent with skills in Azure.AI.Extensions.OpenAI

**Note:** This feature is in preview; to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

## Hosted Code Agent Deployment prerequisites

The skills in toolboxes are only supported in Hosted Agents. `Azure.AI.Projects` can be used only to create a `ProjectsAgentVersion` object; however, the hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a folder containing agent code and dependencies. In our example, it should be located in the `Assets/AgentsCodeToolbox` folder next to the sample itself (this folder is not provided).
2. Create a project and add dependencies.

```bash
dotnet new console --name ToolboxSkillAgent --output ToolboxSkillAgent
dotnet add package Azure.AI.Projects --prerelease
dotnet add package Microsoft.Agents.AI.Foundry --prerelease
dotnet add package Microsoft.Agents.AI.Foundry.Hosting --prerelease
dotnet add package Microsoft.Agents.AI.Mcp --prerelease
```

2. Populate the code in Program.cs

```C#
using Azure.AI.Projects;
using Azure.Core;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Foundry.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;
using System.Net.Http.Headers;

// Read in the environment variables
string TOOLBOX_NAME = System.Environment.GetEnvironmentVariable(nameof(TOOLBOX_NAME)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(TOOLBOX_NAME)}");
string FOUNDRY_PROJECT_ENDPOINT = System.Environment.GetEnvironmentVariable(nameof(FOUNDRY_PROJECT_ENDPOINT)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(FOUNDRY_PROJECT_ENDPOINT)}");
string FOUNDRY_MODEL_NAME = System.Environment.GetEnvironmentVariable(nameof(FOUNDRY_MODEL_NAME)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(FOUNDRY_MODEL_NAME)}");
string AGENT_NAME = System.Environment.GetEnvironmentVariable(nameof(AGENT_NAME)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(AGENT_NAME)}");
//
DefaultAzureCredential credential = new();
using var httpClient = new HttpClient(new BearerTokenHandler(credential, "https://ai.azure.com/.default") { CheckCertificateRevocationList = true });
await using var mcpClient = await McpClient.CreateAsync(
    new HttpClientTransport(
        new HttpClientTransportOptions
        {
            Endpoint = new Uri($"{FOUNDRY_PROJECT_ENDPOINT.TrimEnd('/')}/toolboxes/{TOOLBOX_NAME}/mcp?api-version=v1"),
            Name = TOOLBOX_NAME,
            TransportMode = HttpTransportMode.StreamableHttp,
            AdditionalHeaders = new Dictionary<string, string>
            {
                ["Foundry-Features"] = "Toolboxes=V1Preview",
            },
        },
        httpClient));
AgentSkillsProvider skillProvider = new AgentSkillsProviderBuilder()
    .UseMcpSkills(mcpClient)
    .Build();
AIAgent agent = new AIProjectClient(endpoint: new(FOUNDRY_PROJECT_ENDPOINT), credential)
    .AsAIAgent(new ChatClientAgentOptions()
    {
        ChatOptions = new ChatOptions()
        {
            ModelId = FOUNDRY_MODEL_NAME,
            Instructions = "You are a helpful assistant.",
        },
        AIContextProviders = [
            skillProvider
        ],
        Name = AGENT_NAME,
        Description = "Agent with Skill in the Toolbox."
    });
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddFoundryResponses(agent);
var app = builder.Build();
app.MapFoundryResponses();
app.Run();


// ---------------------------------------------------------------------------
// HttpClientHandler: attaches a fresh Foundry bearer token to every request
// ---------------------------------------------------------------------------
internal sealed class BearerTokenHandler(TokenCredential credential, string scope) : HttpClientHandler
{
    private readonly TokenRequestContext _tokenContext = new([scope]);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        AccessToken token = await credential.GetTokenAsync(this._tokenContext, cancellationToken).ConfigureAwait(false);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
```

3. Compile the application.

```bash
dotnet publish
```

This will create the publish output in the `bin\Release\net%version%\publish\` folder, where `%version%` is the .NET version used to build the application.
4. Copy the contents of `publish` folder to `Assets/AgentsCodeToolbox`.

# Run the sample

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ToolBoxSkill
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
ProjectAgentSkills skillsClient = projectClient.AgentAdministrationClient.GetAgentSkills();
```

2. Create a skill, add it to the toolbox, and create an MCP server tool using the toolbox.

Synchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolBoxSkill_Sync
SkillVersion skill = skillsClient.CreateSkillVersion(
    name: "shipping-cost-skill",
    inlineContent: new SkillInlineContent(
        description: "Compute shipping cost for a package given weight and destination.",
        instructions: "You are a shipping cost calculator. When asked to compute " +
          "shipping cost, use this formula: cost (USD) = 5 + 2 * weight_kg " +
          "for domestic destinations, and cost (USD) = 15 + 4 * weight_kg " +
          "for international destinations. Always state the formula you used."
    )
);
Console.WriteLine($"Created skill {skill.Name}, v. {skill.Version}.");
ToolboxSkillReference reference = new(skill.Name)
{
    Version = skill.Version
};
ToolboxVersion toolBox = toolboxClient.CreateVersion(
    name: "mySkillToolbox",
    tools: [new ToolboxSearchPreviewToolboxTool()],
    skills: [reference],
    description: "Toolbox exposing a shipping-cost skill."
);
Console.WriteLine($"Created toolbox {toolBox.Name}, v. {toolBox.Version}.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateToolbox_ToolBoxSkill_Async
SkillVersion skill = await skillsClient.CreateSkillVersionAsync(
    name: "shipping-cost-skill",
    inlineContent: new SkillInlineContent(
        description: "Compute shipping cost for a package given weight and destination.",
        instructions: "You are a shipping cost calculator. When asked to compute " +
          "shipping cost, use this formula: cost (USD) = 5 + 2 * weight_kg " +
          "for domestic destinations, and cost (USD) = 15 + 4 * weight_kg " +
          "for international destinations. Always state the formula you used."
    )
);
Console.WriteLine($"Created skill {skill.Name}, v. {skill.Version}.");
ToolboxSkillReference reference = new(skill.Name)
{
    Version = skill.Version
};
ToolboxVersion toolBox = await toolboxClient.CreateVersionAsync(
    name: "mySkillToolbox",
    tools: [new ToolboxSearchPreviewToolboxTool()],
    skills: [reference],
    description: "Toolbox exposing a shipping-cost skill."
);
Console.WriteLine($"Created toolbox {toolBox.Name}, v. {toolBox.Version}.");
```

3. In this example, we will use files that should be in the `Assets/AgentsCodeToolbox` folder next to the sample source code. To get the file location, we will use the `GetDirectory` method.

```C# Snippet:Sample_GetPath_ToolBoxSkill
protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine(dirName, path);
}
```

4. For brevity, we will create a method that returns the `AgentVersionFromCodeMetadata` object. It contains all environment variables needed to access the toolbox from the Hosted Agent.
**Note:** In this example we are uploading the project. It is also possible to place source codes and a C# project file to the `Assets/AgentsCodeToolbox` folder. In this case we will need to set `dependencyResolution: CodeDependencyResolution.RemoteBuild`.

```C# Snippet:Sample_CodeAgentMetadata_ToolBoxSkill
private static AgentVersionFromCodeMetadata GetAgentMetadata(string middlewareAgentName, string toolboxName, string foundryProjectEndpoint, string modelDeploymentName)
{
    HostedAgentDefinition agentDefinition = new(
        cpu: "0.5",
        memory: "1Gi"
    )
    {
        Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "2.0.0") },
        CodeConfiguration = new(
            runtime: "dotnet_10",
            entryPoint: ["dotnet", "ToolboxSkillAgent.dll"],
            dependencyResolution: CodeDependencyResolution.Bundled
        ),
        EnvironmentVariables = {
            { "AGENT_NAME", middlewareAgentName},
            { "TOOLBOX_NAME", toolboxName},
            { "FOUNDRY_PROJECT_ENDPOINT", foundryProjectEndpoint},
            { "FOUNDRY_MODEL_NAME", modelDeploymentName },
            { "ASPNETCORE_URLS", "http://+:8088"},
        }
    };
    AgentVersionFromCodeMetadata metadata = new(agentDefinition);
    metadata.Metadata["enableVnextExperience"] = "true";
    return metadata;
}
```

5. Create the Hosted Agent from code and wait for deployment to complete.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_ToolBoxSkill_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
    agentName: "myCodeAgentSkill",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeToolbox"])),
    metadata: GetAgentMetadata(
        middlewareAgentName: "codeAgentMiddleware1",
        toolboxName: toolBox.Name,
        foundryProjectEndpoint: projectEndpoint,
        modelDeploymentName: modelDeploymentName
    )
);
while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
{
    Thread.Sleep(500);
    agentVersion = projectClient.AgentAdministrationClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
if (agentVersion.Status != AgentVersionStatus.Active)
{
    throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
}
Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
Console.WriteLine($"The Agent's identity ID is {agentVersion.InstanceIdentity.ClientId}. Please use it to set \"Foundry User\" permission if needed.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_ToolBoxSkill_Async
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
    agentName: "myCodeAgentSkill",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeToolbox"])),
    metadata: GetAgentMetadata(
        middlewareAgentName: "codeAgentMiddleware1",
        toolboxName: toolBox.Name,
        foundryProjectEndpoint: projectEndpoint,
        modelDeploymentName: modelDeploymentName
    )
);
while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
{
    await Task.Delay(500);
    agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
if (agentVersion.Status != AgentVersionStatus.Active)
{
    throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
}
Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
Console.WriteLine($"The Agent's identity ID is {agentVersion.InstanceIdentity.ClientId}. Please use it to set \"Foundry User\" permission if needed.");
```

6. Get the response from the Agent. The toolbox works as an MCP server. In our server-side Python example, we did not set up automatic approval, so we need to approve the MCP call in our code.
**Note:** To access the toolbox with the skill, the Agent needs to have the "Foundry User" permission with regard to the account (one level above the project). Please set this permission if the Agent cannot access Skill.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);

CreateResponseOptions nextResponseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem("Compute the shipping cost for a 3 kg package shipped domestically.") }
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
            if (string.Equals(mcpToolCall.ServerLabel, "agent_framework"))
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
        else if (responseItem is FunctionCallResponseItem functionCallResponse)
        {
            Console.WriteLine($"Calling function {functionCallResponse.FunctionName} with arguments {functionCallResponse.FunctionArguments}");
        }
    }
}
Console.WriteLine(latestResponse.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
CreateResponseOptions nextResponseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem("Compute the shipping cost for a 3 kg package shipped domestically.") }
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
            if (string.Equals(mcpToolCall.ServerLabel, "agent_framework"))
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
        else if (responseItem is FunctionCallResponseItem functionCallResponse)
        {
            Console.WriteLine($"Calling function {functionCallResponse.FunctionName} with arguments {functionCallResponse.FunctionArguments}");
        }
    }
}
Console.WriteLine(latestResponse.GetOutputText());
```

7. Delete the Skill and the Toolbox we have created. We do not remove the Agent, to allow setting permissions and re-running the sample.

Synchronous sample:
```C# Snippet:DeleteToolBoxSkill_ToolBoxSkill_Sync
// projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
toolboxClient.Delete(name: toolBox.Name);
skillsClient.DeleteSkill(name: skill.Name);
```

Asynchronous sample:
```C# Snippet:DeleteToolBoxSkill_ToolBoxSkill_Async
// await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
await toolboxClient.DeleteAsync(name: toolBox.Name);
await skillsClient.DeleteSkillAsync(name: skill.Name);
```

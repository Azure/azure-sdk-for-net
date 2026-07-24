# Sample on getting responses from an Agent with skills in Azure.AI.Extensions.OpenAI

**Note:** This feature is in preview; to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

## Hosted Code Agent Deployment prerequisites

The skills in toolboxes are only supported in Hosted Agents. `Azure.AI.Projects` can be used only to create a `ProjectsAgentVersion` object; however, the hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a folder containing agent code and dependencies. In our example, it should be located in the `Assets/AgentsCodeToolbox` folder next to the sample itself (this folder is not provided).
2. Create the file `main.py` containing the logic for the hosted Agent.

```python
import asyncio
import os
from collections.abc import AsyncGenerator

from agent_framework import Agent, AgentSession
from agent_framework_foundry import FoundryChatClient
from agent_framework_foundry_hosting import ResponsesHostServer, FoundryToolbox
from azure.ai.agentserver.invocations import InvocationAgentServerHost
from azure.identity import DefaultAzureCredential
from starlette.requests import Request
from starlette.responses import JSONResponse, Response, StreamingResponse

DEFAULT_TOOLBOX_SCOPE = "https://ai.azure.com/.default"

# Read in the environment variables
TOOLBOX_NAME = os.environ["TOOLBOX_NAME"]
FOUNDRY_PROJECT_ENDPOINT = os.environ["FOUNDRY_PROJECT_ENDPOINT"]
FOUNDRY_MODEL_NAME = os.environ["FOUNDRY_MODEL_NAME"]
AGENT_NAME = os.environ["AGENT_NAME"]
####


class MultiProtocolHost(ResponsesHostServer, InvocationAgentServerHost):
    def __init__(self, agent: Agent, **kwargs) -> None:
        super().__init__(agent, **kwargs)
        self._invocation_sessions: dict[str, AgentSession] = {}
        self.invoke_handler(self._handle_invoke)

    async def _handle_invoke(self, request: Request) -> Response:
        data = await request.json()
        session_id: str = request.state.session_id
        stream = data.get("stream", False)
        user_message = data.get("message") or data.get("input")
        if user_message is None:
            error = "Missing 'message' in request"
            if stream:
                return StreamingResponse(content=error, status_code=400)
            return Response(content=error, status_code=400)

        await self._ensure_agent_ready()
        session = self._invocation_sessions.setdefault(
            session_id,
            AgentSession(session_id=session_id),
        )

        if stream:

            async def stream_response() -> AsyncGenerator[str]:
                async for update in self._agent.run(user_message, session=session, stream=True):
                    if update.text:
                        yield update.text

            return StreamingResponse(
                stream_response(),
                media_type="text/event-stream",
                headers={"Cache-Control": "no-cache", "Connection": "keep-alive"},
            )

        response = await self._agent.run([user_message], session=session, stream=False)
        return JSONResponse({"response": response.text, "session_id": session_id})


async def main() -> None:
    credential = DefaultAzureCredential()
    toolbox = FoundryToolbox(
        credential,
        load_prompts=True,
        load_tools=False,
    )
    toolbox._header_provider = lambda _: {
        "x-aml-agent-name": AGENT_NAME,
        "Foundry-Features": "Toolboxes=V1Preview,Skills=V1Preview"}
    client = FoundryChatClient(
        project_endpoint=FOUNDRY_PROJECT_ENDPOINT,
        model=FOUNDRY_MODEL_NAME,
        credential=credential,
    )
    agent = Agent(
        client=client,
        instructions="You are a helpful assistant.",
        tools=toolbox,
        context_providers=[toolbox.as_skills_provider()],
        default_options={"store": False},
    )
    server = MultiProtocolHost(agent)
    await server.run_async()


if __name__ == "__main__":
    asyncio.run(main())
```

3. Create the `requirements.txt` in the `Assets/AgentsCodeToolbox` folder with the following contents.

```
agent-framework-foundry
agent-framework-foundry-hosting>=1.0.0a260630
azure-identity>=1.25.0
```

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
            runtime: "python_3_14",
            entryPoint: ["python", "main.py"],
            dependencyResolution: CodeDependencyResolution.RemoteBuild
        ),
        EnvironmentVariables = {
            { "AGENT_NAME", middlewareAgentName},
            { "TOOLBOX_NAME", toolboxName},
            { "FOUNDRY_PROJECT_ENDPOINT", foundryProjectEndpoint},
            { "FOUNDRY_MODEL_NAME", modelDeploymentName },
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

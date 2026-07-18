# Sample on using reminder tool with Hosted Agent in Azure.AI.Extensions.OpenAI.

## Hosted Code Agent Deployment prerequisites

## Python code sample

`Azure.AI.Projects` can be used only to create a `ProjectsAgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a folder, containing agent code and dependencies. In our example, it should be located `Assets/AgentsCodeToolbox` folder next to the sample itself (this folder is not provided).
2. Create the file `main.py` containing the logic for hosted Agent.

```python
import asyncio
import os
from collections.abc import AsyncGenerator

import httpx
from agent_framework import Agent, AgentSession, MCPStreamableHTTPTool
from agent_framework.foundry import FoundryChatClient
from agent_framework_foundry_hosting import ResponsesHostServer
from azure.ai.agentserver.invocations import InvocationAgentServerHost
from azure.ai.agentserver.core import get_request_context
from azure.identity import DefaultAzureCredential
from starlette.requests import Request
from starlette.responses import JSONResponse, Response, StreamingResponse

DEFAULT_TOOLBOX_SCOPE = "https://ai.azure.com/.default"

SYSTEM_PROMPT = """You are a helpful assistant that can schedule reminders.

When a user asks to set, create, schedule, or remind them about something after
some number of minutes, call the `schedule_reminder` tool with the best integer
`minutes` value you can extract from the request.

After the tool call succeeds, briefly confirm that the reminder was scheduled
and include the created reminder name if the tool returned one.

Do not pretend a reminder was created if the tool call failed.
Keep your answers brief.
"""

# Read in the environment variables
TOOLBOX_NAME = os.environ["TOOLBOX_NAME"]
FOUNDRY_PROJECT_ENDPOINT = os.environ["FOUNDRY_PROJECT_ENDPOINT"]
FOUNDRY_MODEL_NAME = os.environ["FOUNDRY_MODEL_NAME"]
AGENT_NAME = os.environ["AGENT_NAME"]
####


class _ToolboxAuth(httpx.Auth):
    def __init__(self, credential: DefaultAzureCredential, scope: str, agent_name: str) -> None:
        self._credential = credential
        self._scope = scope
        self._agent_name = agent_name

    def auth_flow(self, request: httpx.Request):
        token = self._credential.get_token(self._scope).token
        request.headers["Authorization"] = f"Bearer {token}"
        for key, value in get_request_context().platform_headers().items():
            request.headers[key] = value
        if self._agent_name:
            request.headers["x-aml-agent-name"] = self._agent_name
        yield request


class ReminderFoundryToolbox(MCPStreamableHTTPTool):
    def __init__(
        self,
        credential: DefaultAzureCredential,
        *,
        timeout: float = 120.0,
    ) -> None:
        endpoint = f"{FOUNDRY_PROJECT_ENDPOINT.rstrip('/')}/toolboxes/{TOOLBOX_NAME}/mcp?api-version=v1"
        http_client = httpx.AsyncClient(
            auth=_ToolboxAuth(credential, DEFAULT_TOOLBOX_SCOPE, AGENT_NAME),
            headers={
                "x-aml-agent-name": AGENT_NAME,
                "Foundry-Features": "Toolboxes=V1Preview"
                },
            timeout=timeout,
        )
        super().__init__(
            name=TOOLBOX_NAME,
            url=endpoint,
            http_client=http_client,
            load_prompts=False,
            load_tools=True,
        )

    async def close(self) -> None:
        try:
            await super().close()
        finally:
            client = self._httpx_client
            if client is not None:
                self._httpx_client = None
                await client.aclose()


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
    toolbox = ReminderFoundryToolbox(credential)
    client = FoundryChatClient(
        project_endpoint=FOUNDRY_PROJECT_ENDPOINT,
        model=FOUNDRY_MODEL_NAME,
        credential=credential,
    )
    agent = Agent(
        client=client,
        instructions=SYSTEM_PROMPT,
        tools=toolbox,
        default_options={"store": False},
    )
    server = MultiProtocolHost(agent)
    await server.run_async()


if __name__ == "__main__":
    asyncio.run(main())
```

3. Create the `requirements.txt` in `Assets` folder with the next contents.

```
agent-framework-foundry
agent-framework-foundry-hosting>=1.0.0a260630
azure-identity>=1.25.0
```


# Run the sample.

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_CodeAgent
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. For brevity we will create the method, returning the `CreateAgentVersionFromCodeMetadata` object.

```C# Snippet:Sample_CodeAgentMetadata_CodeAgent
private static AgentVersionFromCodeMetadata GetAgentMetadata()
{
    HostedAgentDefinition agentDefinition = new(
        cpu: "0.5",
        memory: "1Gi"
    )
    {
        Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0") },
        CodeConfiguration = new(
            runtime: "python_3_14",
            entryPoint: ["python", "main.py"],
            dependencyResolution: CodeDependencyResolution.RemoteBuild
        ),
    };
    AgentVersionFromCodeMetadata metadata = new(agentDefinition);
    metadata.Metadata["enableVnextExperience"] = "true";
    return metadata;
}
```

3. In this example we will use files which should be located in the `Assets/AgentsCode` folder next to the sample source code. To get the file location we will use the `GetDirectory` method.

```C# Snippet:Sample_GetPath_CodeAgent
protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine([dirName, path]);
}
```

4. Create the hosted agent object from code.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgent_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
    agentName: "myCodeAgent",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
    metadata: GetAgentMetadata()
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgent_Async
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
    agentName: "myCodeAgent",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
    metadata: GetAgentMetadata()
);
```

5. Wait while Agent will get to the active state; throw error if the deployment fails.

Synchronous sample:
```C# Snippet:Sample_WaitForDeployment_CodeAgent_Sync
while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
{
    Thread.Sleep(500);
    agentVersion = projectClient.AgentAdministrationClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
if (agentVersion.Status != AgentVersionStatus.Active)
{
    throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForDeployment_CodeAgent_Async
while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
{
    await Task.Delay(500);
    agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
if (agentVersion.Status != AgentVersionStatus.Active)
{
    throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
}
```

6. Create the response client to communicate with an Agent and get the response. If hosted agent is not functioning properly, the `session_not_ready` error is raised. In this case we will extract session ID, get the session logs and print the error.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgent_Sync
try
{
    ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
    ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");

    Console.WriteLine(response.GetOutputText());
}
catch (ClientResultException e)
{
    MatchCollection session = Regex.Matches(e.Message, "'[^']+'");
    if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) != -1 && session.Count > 0)
    {
        SessionLogEvent logEvent = projectClient.AgentAdministrationClient.GetSessionLogStream(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session[0].Value.Trim('\''));
        Console.WriteLine(logEvent.Data);
    }
    throw;
}
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgent_Async
try
{
    ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
    ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");

    Console.WriteLine(response.GetOutputText());
}
catch (ClientResultException e)
{
    MatchCollection session = Regex.Matches(e.Message, "'[^']+'");
    if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) !=-1 && session.Count > 0)
    {
        SessionLogEvent logEvent = await projectClient.AgentAdministrationClient.GetSessionLogStreamAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session[0].Value.Trim('\''));
        Console.WriteLine(logEvent.Data);
    }
    throw;
}
```

7. Download the code, used by the Agent.

Synchronous sample:
```C# Snippet:Sample_DownloadCode_CodeAgent_Sync
string downloadPath = Path.GetFullPath("./AgentCode");
projectClient.AgentAdministrationClient.DownloadAgentCode(agentName: agentVersion.Name, path: downloadPath);
Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
```

Asynchronous sample:
```C# Snippet:Sample_DownloadCode_CodeAgent_Async
string downloadPath = Path.GetFullPath("./AgentCode");
await projectClient.AgentAdministrationClient.DownloadAgentCodeAsync(agentName: agentVersion.Name, path: downloadPath);
Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
```

8. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:DeleteCodeAgent_CodeAgent_Sync
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:DeleteCodeAgent_CodeAgent_Async
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```

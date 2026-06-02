# Sample on getting the responses from hosted code Agent with skills in Azure.AI.Extensions.OpenAI.

**Note:** This feature is in the preview, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

Hosted agents simplify the custom agent deployment on fully controlled environment [see more](https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents). `Azure.AI.Projects` allow interactions with hosted agents using `HostedAgentDefinition`. In this example we will deploy the hosted agent and use it from the `Azure.AI.Extensions.OpenAI`.

## Hosted Code Agent Deployment prerequisites

In this example we will use the code from the simple [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py). The service defined in this file just gets the request, adds "Echo: " to it and sends it back using the responses protocol.

## Run the sample
`Azure.AI.Projects` can be used only to create an `ProjectsAgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a folder, containing agent code and dependencies. In our example, it should be located `Assets/AgentsCode` folder next to the sample itself (this folder is not provided).
2. Crreate the `main.py` file with the next contents:

```python
import asyncio
import io
import logging
import os
import re
import urllib.error
import urllib.parse
import urllib.request
import zipfile

from azure.ai.agentserver.responses import (
    CreateResponse,
    ResponseContext,
    ResponsesAgentServerHost,
    TextResponse,
)


logging.basicConfig(level=logging.INFO)
logger = logging.getLogger("foundry_skill_agent")

PROJECT_ENDPOINT = os.environ.get("AZURE_AI_PROJECT_ENDPOINT") or os.environ.get(
    "FOUNDRY_PROJECT_ENDPOINT"
)
SKILL_NAME = os.environ.get("FOUNDRY_SKILL_NAME", "pirate-greeting")
API_VERSION = os.environ.get("FOUNDRY_SKILLS_API_VERSION", "v1")
FEATURES = "Skills=V1Preview"

_skill_markdown: str | None = None
_skill_lock = asyncio.Lock()


def _get_managed_identity_token() -> str:
    endpoint = os.environ.get("IDENTITY_ENDPOINT")
    header = os.environ.get("IDENTITY_HEADER")
    if not endpoint or not header:
        raise RuntimeError("IDENTITY_ENDPOINT and IDENTITY_HEADER are required")

    query = urllib.parse.urlencode(
        {"api-version": "2019-08-01", "resource": "https://ai.azure.com"}
    )
    separator = "&" if "?" in endpoint else "?"
    request = urllib.request.Request(
        f"{endpoint}{separator}{query}",
        headers={"X-IDENTITY-HEADER": header, "Metadata": "true"},
    )

    with urllib.request.urlopen(request, timeout=20) as response:
        payload = response.read().decode("utf-8")

    import json

    return json.loads(payload)["access_token"]


def _download_skill_markdown() -> str:
    if not PROJECT_ENDPOINT:
        raise RuntimeError("AZURE_AI_PROJECT_ENDPOINT or FOUNDRY_PROJECT_ENDPOINT is required")

    endpoint = PROJECT_ENDPOINT.rstrip("/")
    url = f"{endpoint}/skills/{SKILL_NAME}/content?api-version={API_VERSION}"
    request = urllib.request.Request(
        url,
        headers={
            "Authorization": f"Bearer {_get_managed_identity_token()}",
            "Accept": "application/zip",
            "Foundry-Features": FEATURES,
        },
    )

    try:
        with urllib.request.urlopen(request, timeout=30) as response:
            payload = response.read()
    except urllib.error.HTTPError as exc:
        detail = exc.read().decode("utf-8", errors="replace")
        raise RuntimeError(f"Failed to download skill {SKILL_NAME}: HTTP {exc.code}: {detail}") from exc

    with zipfile.ZipFile(io.BytesIO(payload)) as archive:
        try:
            return archive.read("SKILL.md").decode("utf-8")
        except KeyError as exc:
            raise RuntimeError(f"Skill {SKILL_NAME} package did not contain SKILL.md") from exc


async def _get_skill_markdown() -> str:
    global _skill_markdown
    if _skill_markdown is not None:
        return _skill_markdown

    async with _skill_lock:
        if _skill_markdown is None:
            _skill_markdown = await asyncio.to_thread(_download_skill_markdown)
            logger.info("Loaded Foundry skill %s (%d bytes)", SKILL_NAME, len(_skill_markdown))
        return _skill_markdown


def _strip_front_matter(markdown: str) -> str:
    return re.sub(r"^---\s*\n.*?\n---\s*\n", "", markdown, flags=re.DOTALL).strip()


def _extract_name(text: str) -> str | None:
    match = re.search(r"\b(?:my name is|i am|i'm|for)\s+([A-Z][A-Za-z-]{1,40})\b", text)
    return match.group(1) if match else None


def _answer(prompt: str, skill_markdown: str) -> str:
    instructions = _strip_front_matter(skill_markdown)
    name = _extract_name(prompt)
    subject = f", {name}" if name else ""

    if any(word in prompt.lower() for word in ("hello", "hi", "greet", "welcome", "intro")):
        return (
            f"Ahoy{subject}! Welcome aboard, matey - glad to see ye.\n\n"
            f"Loaded skill: {SKILL_NAME}. Instruction excerpt: {instructions[:120]}"
        )

    return (
        f"I loaded the Foundry skill '{SKILL_NAME}' directly from the Skills API "
        "inside this hosted-agent container. Try: 'greet me, my name is Ada'."
    )


app = ResponsesAgentServerHost()


@app.response_handler
async def handler(
    request: CreateResponse, context: ResponseContext, cancellation_signal: asyncio.Event
):
    del cancellation_signal
    prompt = await context.get_input_text()
    skill_markdown = await _get_skill_markdown()
    return TextResponse(context, request, text=_answer(prompt, skill_markdown))


if __name__ == "__main__":
    app.run(port=int(os.environ.get("PORT", "8088")))
```

3. Create the `requirements.txt` in `Assets` with the next dependenciues.

```
azure-ai-agentserver-responses==1.0.0b7
```


# Run the sample.

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ToolBoxSkill
```

2. For brevity we will create the method, returning the `CreateAgentVersionFromCodeMetadata` object.

```C# Snippet:Sample_CodeAgentMetadata_ToolBoxSkill
```

3. In this example we will use files which should be located in the `Assets/AgentsCode` folder next to the sample source code. To get the file location we will use the `GetDirectory` method.

```C# Snippet:Sample_GetPath_ToolBoxSkill
```

4. Create a toolbox and an corresponding MCP server tool.

4. Create the hosted agent object from code.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_ToolBoxSkill_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
    agentName: "myToolBoxSkill",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
    metadata: GetAgentMetadata()
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_ToolBoxSkill_Async
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
    agentName: "myToolBoxSkill",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
    metadata: GetAgentMetadata()
);
```

5. Wait while Agent will get to the active state; throw error if the deployment fails.

Synchronous sample:
```C# Snippet:Sample_WaitForDeployment_ToolBoxSkill_Sync
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
```C# Snippet:Sample_WaitForDeployment_ToolBoxSkill_Async
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
```C# Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Sync
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
```C# Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Async
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
```C# Snippet:Sample_DownloadCode_ToolBoxSkill_Sync
string downloadPath = Path.GetFullPath("./AgentCode");
projectClient.AgentAdministrationClient.DownloadAgentCode(agentName: agentVersion.Name, path: downloadPath);
Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
```

Asynchronous sample:
```C# Snippet:Sample_DownloadCode_ToolBoxSkill_Async
string downloadPath = Path.GetFullPath("./AgentCode");
await projectClient.AgentAdministrationClient.DownloadAgentCodeAsync(agentName: agentVersion.Name, path: downloadPath);
Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
```

8. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:DeleteToolBoxSkill_ToolBoxSkill_Sync
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:DeleteToolBoxSkill_ToolBoxSkill_Async
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```

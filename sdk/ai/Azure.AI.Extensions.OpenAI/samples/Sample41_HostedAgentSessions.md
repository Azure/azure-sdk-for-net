# Sample on getting the responses from hosted Agent from the specific session in Azure.AI.Extensions.OpenAI.

## Hosted Agent Deployment prerequisites

In this example we will build the docker image for hosted Agent based on the simple [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py). The service defined in this file just gets the request, adds "Echo: " to it and sends it back using the responses protocol.

## Hosted agent deployment
`Azure.AI.Projects` can be used only to create a `ProjectsAgentVersion` object, while the hosted Agent represents the running container, which exposes the OpenAI-compatible API. In this example we will use a simple Agent, which replies with the prompt prefixed by "Echo". Please see this and other Hosted Agent samples [here](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples)
1. Create a project and add `Azure.AI.AgentServer.Responses` package as a dependency.

```bash
dotnet new console --name EchoBot --output EchoBot
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

2. Populate the code in Program.cs

```C#
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

ResponsesServer.Run<EchoHandler>();

public class EchoHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            createText: async ct =>
            {
                var input = await context.GetInputTextAsync(cancellationToken: ct);
                return $"Echo: {input}";
            });
    }
}
```

3. Compile the application.

```bash
dotnet publish
```

This will create the publish output in the `bin\Release\net%version%\publish\` folder, where `%version%` is the .NET version used to build the application.

4. Create folder `image`, copy published library there and create the docker file with the next contents. Please note that the `dll` name at the `ENTRYPOINT` must be the same as the name of an application built above.

```
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY publish/ .
ENV ASPNETCORE_URLS=http://+:8088
EXPOSE 8088
ENTRYPOINT ["dotnet", "EchoBot.dll"]
```

5. Build the docker image and push it to the Azure Container registry you have created.

Set docker username variable for convenience:
- bash
```bash
export DOCKER_USERNAME="your_docker_username"
```

- PowerShell
```powershell
$DOCKER_USERNAME="your_docker_username"
```

- CMD
```
set DOCKER_USERNAME=your_docker_username
```

```bash
docker build -t "$DOCKER_USERNAME/echo-bot-agent" .
docker image tag "$DOCKER_USERNAME/echo-bot-agent:latest" "$DOCKER_USERNAME.azurecr.io/$DOCKER_USERNAME/echo-bot-agent:latest"
docker login "$DOCKER_USERNAME.azurecr.io"
docker push "$DOCKER_USERNAME.azurecr.io/$DOCKER_USERNAME/echo-bot-agent:latest"
```

## Run the sample.

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_HostedAgentSessions
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
Uri uriEndpoint = new(projectEndpoint);
AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());
```

2. For brevity we will create the method, returning the `HostedAgentDefinition` object.

```C# Snippet:Sample_HostedAgentSessionsDefinition_HostedAgentSessions
private static HostedAgentDefinition GetAgentDefinition(string dockerImage)
{
    HostedAgentDefinition agentDefinition = new(
        versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
        cpu: "0.5",
        memory: "1Gi"
    )
    {
        ContainerConfiguration = new(dockerImage)
    };
    return agentDefinition;
}
```

3. Create the hosted agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_HostedAgentSessions_Sync
HostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage
);
ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
creationOptions.Metadata["enableVnextExperience"] = "true";
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myHostedAgent",
    options: creationOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_HostedAgentSessions_Async
HostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage
);
ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
creationOptions.Metadata["enableVnextExperience"] = "true";
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myHostedAgent",
    options: creationOptions);
```

4. Wait while Agent will get to the active state; throw error if the deployment fails.

Synchronous sample:
```C# Snippet:Sample_WaitForDeployment_HostedAgentSessions_Sync
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
```C# Snippet:Sample_WaitForDeployment_HostedAgentSessions_Async
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

5. Configure an Agent endpoint for Responses protocol.

Synchronous sample:
```C# Snippet:Sample_CreateTheEndpoint_HostedAgentSessions_Sync
AgentEndpointConfiguration config = new()
{
    VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
    ProtocolConfiguration = new()
    {
        Responses = new()
    }
};
PatchAgentOptions patchOptions = new()
{
    AgentEndpoint = config,
};
ProjectsAgentRecord patchedRecord = projectClient.AgentAdministrationClient.PatchAgent(
    agentName: agentVersion.Name,
    patchAgentOptions: patchOptions);
Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateTheEndpoint_HostedAgentSessions_Async
AgentEndpointConfiguration config = new()
{
    VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
    ProtocolConfiguration = new()
    {
        Responses = new()
    }
};
PatchAgentOptions patchOptions = new()
{
    AgentEndpoint = config,
};
ProjectsAgentRecord patchedRecord = await projectClient.AgentAdministrationClient.PatchAgentAsync(
    agentName: agentVersion.Name,
    patchAgentOptions: patchOptions);
Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
```

6. Create the session and response client to communicate with an Agent and get the response. In this case we will use `GetProjectResponsesClientForAgentEndpoint` method.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgentSessions_Sync
ProjectAgentSession session1 = projectClient.AgentAdministrationClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
{
    Thread.Sleep(500);
    session1 = projectClient.AgentAdministrationClient.GetSession(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
}
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem($"Hello, tell me a joke in session {session1.AgentSessionId}.") },
    SessionId = session1.AgentSessionId
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgentSessions_Async
ProjectAgentSession session1 = await projectClient.AgentAdministrationClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
{
    await Task.Delay(500);
    session1 = await projectClient.AgentAdministrationClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
}
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem($"Hello, tell me a joke in session {session1.AgentSessionId}.") },
    SessionId = session1.AgentSessionId
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
Console.WriteLine(response.GetOutputText());
```

7. Disable Agent and try to create a new session; this operation should fail.

Synchronous sample:
```C# Snippet:Sample_DisableTheAgent_HostedAgentSessions_Sync
projectClient.AgentAdministrationClient.DisableAgent(agentVersion.Name);
// The new session cannot be created.
try
{
    projectClient.AgentAdministrationClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
    throw new InvalidOperationException("Stopped Agent was unexpectedly able to create session.");
}
catch (ClientResultException ex)
{
    if (ex.Status != 403)
    {
        throw;
    }
    Console.WriteLine(ex.Message);
}
```

Asynchronous sample:
```C# Snippet:Sample_DisableTheAgent_HostedAgentSessions_Async
await projectClient.AgentAdministrationClient.DisableAgentAsync(agentVersion.Name);
// The new session cannot be created.
try
{
    await projectClient.AgentAdministrationClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
    throw new InvalidOperationException("Stopped Agent was unexpectedly able to create session.");
}
catch (ClientResultException ex)
{
    if (ex.Status != 403)
    {
        throw;
    }
    Console.WriteLine(ex.Message);
}
```

8. Enable the Agent Again. Now we can create another session and use it to get the response.

Synchronous sample:
```C# Snippet:Sample_EnableTheAgent_HostedAgentSessions_Sync
projectClient.AgentAdministrationClient.EnableAgent(agentVersion.Name);
ProjectAgentSession session2 = projectClient.AgentAdministrationClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
{
    Thread.Sleep(500);
    session2 = projectClient.AgentAdministrationClient.GetSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
}
responseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem($"Hello, tell me another joke in new session {session2.AgentSessionId}.") },
    SessionId = session2.AgentSessionId
};
response = responseClient.CreateResponse(responseOptions);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_EnableTheAgent_HostedAgentSessions_Async
await projectClient.AgentAdministrationClient.EnableAgentAsync(agentVersion.Name);
ProjectAgentSession session2 = await projectClient.AgentAdministrationClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
{
    await Task.Delay(500);
    session2 = await projectClient.AgentAdministrationClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
}
responseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem($"Hello, tell me another joke in new session {session2.AgentSessionId}.") },
    SessionId = session2.AgentSessionId
};
response = await responseClient.CreateResponseAsync(responseOptions);
Console.WriteLine(response.GetOutputText());
```

9. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:DeleteHostedAgentSessions_HostedAgentSessions_Sync
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:DeleteHostedAgentSessions_HostedAgentSessions_Async
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```

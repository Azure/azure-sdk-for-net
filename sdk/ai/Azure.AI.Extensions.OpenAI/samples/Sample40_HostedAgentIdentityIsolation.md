# Sample on getting the responses from hosted Agent for two different user identities in Azure.AI.Extensions.OpenAI.

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

```C# Snippet:Sample_CreateAgentClient_HostedAgentIdentityIsolation
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
Uri uriEndpoint = new(projectEndpoint);
DefaultAzureCredential credential = new();
AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: credential);
```

2. For brevity we will create the method, returning the `HostedAgentDefinition` object.

```C# Snippet:Sample_HostedAgentIdentityIsolationDefinition_HostedAgentIdentityIsolation
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
```C# Snippet:Sample_CreateAgent_HostedAgentIdentityIsolation_Sync
HostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage
);
ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
creationOptions.Metadata["enableVnextExperience"] = "true";
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myHostedAgent1",
    options: creationOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_HostedAgentIdentityIsolation_Async
HostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage
);
ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
creationOptions.Metadata["enableVnextExperience"] = "true";
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myHostedAgent1",
    options: creationOptions);
```

4. Wait while Agent will get to the active state; throw error if the deployment fails.

Synchronous sample:
```C# Snippet:Sample_WaitForDeployment_HostedAgentIdentityIsolation_Sync
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
```C# Snippet:Sample_WaitForDeployment_HostedAgentIdentityIsolation_Async
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
```C# Snippet:Sample_CreateTheEndpoint_HostedAgentIdentityIsolation_Sync
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
```C# Snippet:Sample_CreateTheEndpoint_HostedAgentIdentityIsolation_Async
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

6. Create a policy, adding the `x-ms-user-identity` header with the user identity to http request.

```C# Snippet:Sample_IdentityHeader_HostedAgentIdentityIsolation
internal class UserIdentityHeaderPolicy(string userIdentity) : PipelinePolicy
{
    private const string _imageDeploymentHeader = "x-ms-user-identity";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_imageDeploymentHeader, userIdentity);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        // Add your desired header name and value
        message.Request.Headers.Add(_imageDeploymentHeader, userIdentity);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

7. Create a couple of identities and get the response for the first one.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpointUser1_HostedAgentIdentityIsolation_Sync
string userID1 = Guid.NewGuid().ToString();
string userID2 = Guid.NewGuid().ToString();
ProjectOpenAIClientOptions options = new();
options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
ResponseResult response = responseClient.CreateResponse("1 + 1 = ?");
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpointUser1_HostedAgentIdentityIsolation_Async
string userID1 = Guid.NewGuid().ToString();
string userID2 = Guid.NewGuid().ToString();
ProjectOpenAIClientOptions options = new();
options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
ResponseResult response = await responseClient.CreateResponseAsync("1 + 1 = ?");
Console.WriteLine(response.GetOutputText());
```

8. Try to ask the follow-up question to the response received by using its ID as a previous response ID. This request will result in 404 error.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpointUser2_HostedAgentIdentityIsolation_Sync
options = new();
options.AddPolicy(new UserIdentityHeaderPolicy(userID2), PipelinePosition.PerCall);
responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
try
{
    ResponseResult followUp1 = responseClient.CreateResponse("Then add 10 to the previous result", previousResponseId: response.Id);
    throw new InvalidOperationException($"The {response.Id} was created for identity {userID1}, but was found for {userID2}.");
}
catch (ClientResultException ex)
{
    if (ex.Status == 404)
    {
        Console.WriteLine("Agent: Expected isolation behavior confirmed. A different delegated user cannot continue the previous response chain and must start a new conversation.");
    }
    else
    {
        throw;
    }
}
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpointUser2_HostedAgentIdentityIsolation_Async
options = new();
options.AddPolicy(new UserIdentityHeaderPolicy(userID2), PipelinePosition.PerCall);
responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
try
{
    ResponseResult followUp1 = await responseClient.CreateResponseAsync("Then add 10 to the previous result", previousResponseId: response.Id);
    throw new InvalidOperationException($"The {response.Id} was created for identity {userID1}, but was found for {userID2}.");
}
catch (ClientResultException ex)
{
    if (ex.Status == 404)
    {
        Console.WriteLine("Agent: Expected isolation behavior confirmed. A different delegated user cannot continue the previous response chain and must start a new conversation.");
    }
    else
    {
        throw;
    }
}
```

9. Now use the same follow-up question, but with the first identity.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpointUser1Again_HostedAgentIdentityIsolation_Sync
options = new();
options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
ResponseResult followUp = responseClient.CreateResponse("Then add 10 to the previous result", previousResponseId: response.Id);
Console.WriteLine(followUp.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpointUser1Again_HostedAgentIdentityIsolation_Async
options = new();
options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
ResponseResult followUp = await responseClient.CreateResponseAsync("Then add 10 to the previous result", previousResponseId: response.Id);
Console.WriteLine(followUp.GetOutputText());
```

10. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:DeleteHostedAgentIdentityIsolation_HostedAgentIdentityIsolation_Sync
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:DeleteHostedAgentIdentityIsolation_HostedAgentIdentityIsolation_Async
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```

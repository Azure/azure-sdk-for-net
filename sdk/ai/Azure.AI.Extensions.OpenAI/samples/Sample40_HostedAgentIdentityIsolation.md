# Sample on getting the responses from hosted Agent for two different user identities in Azure.AI.Extensions.OpenAI.

## Hosted Agent Deployment prerequisites

In this example we will build the Docker image for hosted Agent based on the simple [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py). The service defined in this file just gets the request, adds "Echo: " to it and sends it back using the responses protocol.

## Hosted agent deployment
`Azure.AI.Projects` can be used only to create a `ProjectsAgentVersion` object; however the hosted Agent represents the running container that exposes the OpenAI-compatible API.
1. Create Azure Container registry in the same resource group and region as Microsoft Foundry project. Find the docker login at Settings>Access keys section at the left panel of created container registry in the Azure portal. Check the box "Admin user" to generate the password for the default user account marked as `<DOCKER_USERNAME>` below.
2. Assign the `AcrPull` role to the project's Managed Identity for the Azure Container Registry.
3. Assign the `Azure AI User` role to the project's Managed Identity for resource group (This operation only may be performed by the group owner).
4. Copy the contents of a [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py) to the file main.py
5. At the same directory create the file called `requirements.txt` with the next content:

```
azure-ai-agentserver-core
azure-ai-agentserver-invocations
azure-ai-agentserver-responses
openai
```

6. Create a file `Dockerfile`, which instructs docker to copy the contents of the current directory, install the requirements and run `main.py`, which will start the service:

```
FROM python:3.12-slim

WORKDIR /app

COPY . user_agent/
WORKDIR /app/user_agent

RUN if [ -f requirements.txt ]; then \
        pip install -r requirements.txt; \
    else \
        echo "No requirements.txt found"; \
    fi

EXPOSE 8088

CMD ["python", "main.py"]
```

7. Build the docker image and push it to the Azure Container registry you have created.

```bash
docker build -t <DOCKER_USERNAME>/workflow-agent .
docker image tag <DOCKER_USERNAME>/workflow-agent:latest <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
docker login <DOCKER_USERNAME>.azurecr.io
docker push <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
```

This example requires allowing permission for User to perform the identity impersonation. Please refer to the [documentation](https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agent-permissions#delegate-the-end-user-identity).


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

# Sample on getting the responses from hosted Agent in Azure.AI.Extensions.OpenAI.

**Note:** This feature is in the preview, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

Hosted agents simplify the custom agent deployment on fully controlled environment [see more](https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents). `Azure.AI.Projects` allow interactions with hosted agents using `HostedAgentDefinition`. In this example we will deploy the hosted agent and use it from the `Azure.AI.Extensions.OpenAI`.

## Hosted Agent Deployment prerequisites

In this example we will build the docker image for hosted Agent based of the simple [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py). The service defined in this file just gets the request, adds "Echo: " to it and sends it back using the responses protocol.

## Run the sample
`Azure.AI.Projects` can be used only to create an `ProjectsAgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API.
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

5. Build the docker image and push it to the Azure Container registry you have created.

```bash
docker build -t <DOCKER_USERNAME>/workflow-agent .
docker image tag <DOCKER_USERNAME>/workflow-agent:latest <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
docker login <DOCKER_USERNAME>.azurecr.io
docker push <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
```

# Run the sample.

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_HostedAgent
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var containerImage = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_CONTAINER_IMAGE");
var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
Uri uriEndpoint = new(projectEndpoint);
DefaultAzureCredential credential = new();
AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: credential);
```

2. For brevity we will create the method, returning the `HostedAgentDefinition` object.

```C# Snippet:Sample_HostedAgentDefinition_HostedAgent
private static HostedAgentDefinition GetAgentDefinition(string dockerImage)
{
    HostedAgentDefinition agentDefinition = new(
        versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
        cpu: "0.5",
        memory: "1Gi"
    )
    {
        Image = dockerImage,
    };
    return agentDefinition;
}
```

3. Create the hosted agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_HostedAgent_Sync
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
```C# Snippet:Sample_CreateAgent_HostedAgent_Async
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
```C# Snippet:Sample_WaitForDeployment_HostedAgent_Sync
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
```C# Snippet:Sample_WaitForDeployment_HostedAgent_Async
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
```C# Snippet:Sample_CreateTheEndpoint_HostedAgent_Sync
AgentEndpoint config = new()
{
    VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
    Protocols = { AgentEndpointProtocol.Responses }
};
PatchAgentOptions patchOptions = new()
{
    AgentEndpoint = config,
};
ProjectsAgentRecord patchedRecord = projectClient.AgentAdministrationClient.PatchAgentObject(
    agentName: agentVersion.Name,
    patchAgentOptions: patchOptions);
Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateTheEndpoint_HostedAgent_Async
AgentEndpoint config = new()
{
    VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
    Protocols = { AgentEndpointProtocol.Responses }
};
PatchAgentOptions patchOptions = new()
{
    AgentEndpoint = config,
};
ProjectsAgentRecord patchedRecord = await projectClient.AgentAdministrationClient.PatchAgentObjectAsync(
    agentName: agentVersion.Name,
    patchAgentOptions: patchOptions);
Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
```

6. Create the response client to communicate with an Agent and get the response.
**Note:** In this scenario we cannot use the `ProjectOpenAIClient` from `projectClient.ProjectOpenAIClient` property as we need to access customized endpoint, for the Agent, we have created. We set its name in `ProjectOpenAIClientOptions`.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgent_Sync
ProjectOpenAIClientOptions responsesOptions = new()
{
    AgentName = agentVersion.Name
};
ProjectOpenAIClient openAIClient = new(uriEndpoint, credential, responsesOptions);
ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClient();
ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgent_Async
ProjectOpenAIClientOptions responsesOptions = new()
{
    AgentName = agentVersion.Name
};
ProjectOpenAIClient openAIClient = new(uriEndpoint, credential, responsesOptions);
ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClient();
ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");
Console.WriteLine(response.GetOutputText());
```

7. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:DeleteHostedAgent_HostedAgent_Sync
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name);
```

Asynchronous sample:
```C# Snippet:DeleteHostedAgent_HostedAgent_Async
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name);
```

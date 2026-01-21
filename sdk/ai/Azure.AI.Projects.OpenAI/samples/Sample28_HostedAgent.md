# Sample on getting the responses from hosted Agent in Azure.AI.Projects.OpenAI.

Hosted agents simplify the custom agent deployment on fully controlled environment [see more](https://learn.microsoft.com/azure/ai-foundry/agents/concepts/hosted-agents). `Azure.AI.Projects` allow interactions with hosted agents using `ImageBasedHostedAgentDefinition`. In this example we will deploy the hosted agent and use it from the `Azure.AI.Projects.OpenAI`.

## Hosted Agent Deployment prerequisites

In this example we will use agent capable of doing product release defined [here](https://github.com/microsoft-foundry/foundry-samples/tree/main/samples/python/hosted-agents/agent_framework/agents_in_workflow). The agent's logic is defined in the file [main.py](https://github.com/microsoft-foundry/foundry-samples/blob/main/samples/python/hosted-agents/agent_framework/agents_in_workflow/main.py). Its [docker file](https://github.com/microsoft-foundry/foundry-samples/blob/main/samples/python/hosted-agents/agent_framework/agents_in_workflow/Dockerfile) installs the required python dependencies, exposes 8088 port and runs `main.py`, which will serve agent on this port.
As a prerequisite this sample will require [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli).

## Run the sample
Azure.AI.Projects can be used only to create an `AgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API and in this case `AgentVersion` serves as an agent blueprint and the attempt to get the response from it will result in error. To use the Agent, it needs to be deployed using Azure CLI commands. Removal of the deployed agent also will result in an error as the deployment needs to be removed before the Agent.

1. Create Azure Container registry in the same resource group and region as Microsoft Foundry project. Find the docker login at Settings>Access keys section at the left panel of created container registry in the Azure portal. Check the box "Admin user" to generate the password for the default user account marked as `<DOCKER_USERNAME>` below.
2. Assign the `AcrPull` role to the project's Managed Identity for the Azure Container Registry.
3. Assign the `Azure AI User` role to the project's Managed Identity for resource group (This operation only may be performed by the group owner).
4. Add a capability host to the Azure Foundry by running the next script in PowerShell.

```bash
TOKEN=$(az account get-access-token --resource https://management.azure.com/ --query accessToken -o tsv)
curl --request PUT \
  --url 'https://management.azure.com/subscriptions/[SUBSCRIPTIONID]/resourceGroups/[RESOURCEGROUPNAME]/providers/Microsoft.CognitiveServices/accounts/[ACCOUNTNAME]/capabilityHosts/accountcaphost?api-version=2025-10-01-preview' \
  --header 'content-type: application/json' \
  --header "authorization: Bearer $TOKEN"\
  --data '{
  "properties": {
    "capabilityHostKind": "Agents",
    "enablePublicHostingEnvironment": true
    }
 }'
```

4. Clone the repository and get to the directory with the hosted agent definition.

```bash
git clone https://github.com/azure-ai-foundry/foundry-samples.git
cd foundry-samples/samples/python/hosted-agents/agent_framework/agents_in_workflow/
```

5. Build the docker image and push it to the Azure Container registry you have created.

```bash
docker build -t <DOCKER_USERNAME>/workflow-agent .
docker image tag <DOCKER_USERNAME>/workflow-agent:latest <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
docker login <DOCKER_USERNAME>.azurecr.io
docker push <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
```

# Run the sample.

1. Read the environment variables, which will be used in the next steps and get the clean endpoint URL. Parse the project endpoint for future use.

```C# Snippet:Sample_CreateAgentClient_HostedAgent
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var applicationInsightConnectionString = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
Uri uriEndpoint = new(projectEndpoint);
string[] pathParts = uriEndpoint.AbsolutePath.Split('/');
string projectName = pathParts[pathParts.Length - 1];
string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());
```

2. For brevity we will create the method, returning the `ImageBasedHostedAgentDefinition` object.

```C# Snippet:Sample_ImageBasedHostedAgentDefinition_HostedAgent
private static  ImageBasedHostedAgentDefinition GetAgentDefinition(string dockerImage, string modelDeploymentName, string accountId, string applicationInsightConnectionString, string projectEndpoint)
{
    ImageBasedHostedAgentDefinition agentDefinition = new(
        containerProtocolVersions: [new ProtocolVersionRecord(AgentCommunicationMethod.ActivityProtocol, "v1")],
        cpu: "1",
        memory: "2Gi",
        image: dockerImage
    )
    {
        EnvironmentVariables = {
            { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
            { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", modelDeploymentName },
            // Optional variables, used for logging
            { "APPLICATIONINSIGHTS_CONNECTION_STRING", applicationInsightConnectionString },
            { "AGENT_PROJECT_RESOURCE_ID", projectEndpoint },
        }
    };
    return agentDefinition;
}
```

3. Create the hosted agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_HostedAgent_Sync
ImageBasedHostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage,
    modelDeploymentName: modelDeploymentName,
    accountId: accountId,
    applicationInsightConnectionString: projectName,
    projectEndpoint: projectEndpoint
);
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myHostedAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_HostedAgent_Async
ImageBasedHostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage,
    modelDeploymentName: modelDeploymentName,
    accountId: accountId,
    applicationInsightConnectionString: projectName,
    projectEndpoint: projectEndpoint
);
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myHostedAgent",
    options: new(agentDefinition));
```

4. Print out the instructions on agent deployment.

```C# Snippet:WriteDeploymentInstructions_HostedAgent
Console.WriteLine("The agent has been created, to start it please run the next commands in the terminal:");
Console.WriteLine("az login");
Console.WriteLine($"az cognitiveservices agent start --account-name {accountId} --project-name {projectName} --name {agentVersion.Name} --agent-version {agentVersion.Version}");
Console.WriteLine("Wait while the Agent will arrive to the \"Running\" state in the Microsoft Foundry portal and use GetAgentVersion call to use it.");
```

5. Run the printed commands, they should look as below. Monitor the agent state on Microsoft Foundry portal.

```bash
az login
az cognitiveservices agent start --account-name ACCOUNTNAME --project-name PROJECTNAME --name myHostedAgent --agent-version 1
```

6. After the Agent has arrived to the "Running" state, we can proceed on C# code. First we will need to get the Agent, if the object we have created above is not available.

Synchronous sample:
```C# Snippet:Sample_GetAgent_HostedAgent_Sync
AgentVersion agentVersion = projectClient.Agents.GetAgentVersion(
    agentName: "myHostedAgent", agentVersion: "1");
```

Asynchronous sample:
```C# Snippet:Sample_GetAgent_HostedAgent_Async
AgentVersion agentVersion = await projectClient.Agents.GetAgentVersionAsync(
    agentName: "myHostedAgent", agentVersion: "1");
```

7. Create a `ProjectResponsesClient`.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_HostedAgent_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseResult response = responseClient.CreateResponse("Describe the of Contoso VR glasses release process.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_HostedAgent_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseResult response = await responseClient.CreateResponseAsync("Describe the of Contoso VR glasses release process.");
```

8. Get the response and print it.

```C# Snippet:Sample_WaitForResponse_HostedAgent
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

9. Print out the instructions on deletion of a deployed and Agent.

```C# Snippet:WriteUnDeploymentInstructions_HostedAgent
Console.WriteLine("The agent cannot be removed, before the active deployment associated with it is deleted.");
Console.WriteLine("Please run the next command in the terminal to delete the deployment.");
Console.WriteLine($"az cognitiveservices agent delete-deployment --account-name {accountId} --project-name {projectName} --name {agentVersion.Name} --agent-version {agentVersion.Version}");
Console.WriteLine($"az cognitiveservices agent delete --account-name {accountId} --project-name {projectName} --name {agentVersion.Name}");
Console.WriteLine("Monitor the Agent deletion on Microsoft Foundry portal.");
```

9. **Run the instructions only after you are done with the sample!**. The two commands are required to remove a deployed Agent. The first one deletes the container and the second one removes the agent itself.

```bash
az cognitiveservices agent delete-deployment --account-name ACCOUNTNAME --project-name PROJECTNAME --name myHostedAgent --agent-version 1
az cognitiveservices agent delete --account-name ACCOUNTNAME --project-name PROJECTNAME --name myHostedAgent --agent-version 1
```

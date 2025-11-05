```C# Snippet:SingleFileSamples_HeaderAndDirectives
// GUIDANCE: Instructions to run this code: https://aka.ms/oai/net/start
#:package Azure.AI.Agents@2.*-*
#:package Azure.Identity@1.*
#:property PublishAot=false
```
```C#

using Azure.AI.Agents;
using Azure.Identity;

```
```C# Snippet:SingleFileSamples_ContainerAgentCreate
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");
string AGENT_IMAGE_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_IMAGE_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_IMAGE_NAME'");

AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

AgentDefinition agentDefinition = new ImageBasedHostedAgentDefinition(
    containerProtocolVersions: [new(AgentCommunicationMethod.Responses, "v1")],
    cpu: "1",
    memory: "2Gi",
    image: AGENT_IMAGE_NAME);

AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, agentDefinition);
Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
```

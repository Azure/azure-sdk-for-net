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
```C# Snippet:SingleFileSamples_PromptAgentCreate
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());

AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
{
    Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
};

AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, agentDefinition);
Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
```
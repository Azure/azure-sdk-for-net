```C# Snippet:SingleFileSamples_HeaderAndDirectives
// GUIDANCE: Instructions to run this code: https://aka.ms/oai/net/start
#:package Azure.AI.Agents@2.*-*
#:package Azure.Identity@1.*
#:property PublishAot=false
```
```C#
#:property NoWarn=OPENAI001

using Azure.AI.Agents;
using Azure.Identity;
using OpenAI.Responses;

```
```C# Snippet:SingleFileSamples_PromptAgentWithToolsCreate
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = "TestPiratePromptAgentWithToolsFromDotnetSamples";

AgentsClient client = new(
    new Uri(RAW_PROJECT_ENDPOINT),
    new AzureCliCredential());

AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
{
    Instructions = "You are a helpful agent that happens to always talk like a pirate.",
    Tools =
    {
        ResponseTool.CreateFunctionTool(
            functionName: "get_user_name",
            functionParameters: BinaryData.FromString("{}"),
            strictModeEnabled: false,
            functionDescription: "Gets the user's name, as used for friendly address."
        )
    }
};

AgentVersion newAgentVersion = await client.CreateAgentVersionAsync(
    AGENT_NAME,
    agentDefinition,
    new AgentVersionCreationOptions()
    {
        Metadata =
        {
    ["can_delete_this"] = "true"
        }
    });

Console.WriteLine($"Created new agent version: {newAgentVersion.Name}");
```

```C#
// This sample combines each step of creating and running agents and conversations into a single example.
// In practice, you would typically separate these steps into different applications.
//
```
```
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
using OpenAI;
using OpenAI.Responses;

```
```C# Snippet:SingleFileSamples_PromptAgentEndToEnd
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

//
// Create an agent version for a new prompt agent
//

AgentDefinition agentDefinition = new PromptAgentDefinition(MODEL_DEPLOYMENT)
{
    Instructions = "You are a foo bar agent. In EVERY response you give, ALWAYS include both `foo` and `bar` strings somewhere in the response.",
};
AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, agentDefinition);

//
// Create a conversation to maintain state between calls
//

AgentConversationCreationOptions conversationOptions = new()
{
    Items = { ResponseItem.CreateSystemMessageItem("Your preferred genre of story today is: horror.") },
    Metadata = { ["foo"] = "bar" },
};
AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync(conversationOptions);

//
// Add items to an existing conversation to supplement the interaction state
//
string EXISTING_CONVERSATION_ID = conversation.Id;

_ = await agentsClient.GetConversationClient().CreateConversationItemsAsync(
    EXISTING_CONVERSATION_ID,
    [ResponseItem.CreateSystemMessageItem("Story theme to use: department of licensing.")]);

//
// Use the agent and conversation in a response
//

ResponseCreationOptions responseCreationOptions = new();
responseCreationOptions.SetAgentReference(AGENT_NAME);
responseCreationOptions.SetConversationReference(EXISTING_CONVERSATION_ID);

List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Tell me a one-line story.")];
OpenAIResponse response = await responseClient.CreateResponseAsync(items, responseCreationOptions);

Console.WriteLine(response.GetOutputText());
```

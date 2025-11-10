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
```C# Snippet:SingleFileSamples_PromptAgentWithToolsRun
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = "TestPiratePromptAgentWithToolsFromDotnetSamples";

AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

ResponseCreationOptions responseCreationOptions = new();
responseCreationOptions.SetAgentReference(AGENT_NAME);

// Optionally, use a conversation to automatically maintain state between calls.
bool useConversation = true;

if (useConversation)
{
    AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync();
    responseCreationOptions.SetConversationReference(conversation);
}

string userInput = "Hello, agent! Greet me by name.";
Console.WriteLine($" >>> [User]: {userInput}");
OpenAIResponse response = await responseClient.CreateResponseAsync(
    [ResponseItem.CreateUserMessageItem(userInput)],
    responseCreationOptions);

if (response.OutputItems.Count > 0 && response.OutputItems.Last() is FunctionCallResponseItem functionCall)
{
    Console.WriteLine($" <<< [Function Called]: {functionCall.FunctionName} (call id: {functionCall.CallId})");
    if (!useConversation)
    {
        Console.WriteLine($" | Setting previous_response_id (no conversation use): {response.Id}");
        responseCreationOptions.PreviousResponseId = response.Id;
    }
    Console.WriteLine($" >>> [Function Output (reply)]: Ishmael");
    response = await responseClient.CreateResponseAsync(
        [ResponseItem.CreateFunctionCallOutputItem(functionCall.CallId, "Ishmael")],
        responseCreationOptions);
}

Console.WriteLine($" <<< [Output]: {response.GetOutputText()}");
```
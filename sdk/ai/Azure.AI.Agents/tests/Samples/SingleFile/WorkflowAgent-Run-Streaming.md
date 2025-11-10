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
```C# Snippet:SingleFileSamples_WorkflowAgentRunStreaming
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_MODEL_DEPLOYMENT'");
string AGENT_NAME = Environment.GetEnvironmentVariable("AZURE_AI_FOUNDRY_AGENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'AZURE_AI_FOUNDRY_AGENT_NAME'");

AgentsClient agentsClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential());
OpenAIClient openAIClient = agentsClient.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(MODEL_DEPLOYMENT);

ResponseCreationOptions responseCreationOptions = new();
responseCreationOptions.SetAgentReference(AGENT_NAME);

// Optionally, use a conversation to automatically maintain state between calls.
AgentConversation conversation = await agentsClient.GetConversationClient().CreateConversationAsync();
responseCreationOptions.SetConversationReference(conversation);

List<ResponseItem> items = [ResponseItem.CreateUserMessageItem("Let's go!")];

await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(items, responseCreationOptions))
{
    if (update is StreamingResponseOutputItemAddedUpdate itemAddedUpdate
        && itemAddedUpdate.Item.AsAgentResponseItem() is AgentWorkflowActionResponseItem newWorkflowActionItem)
    {
        Console.WriteLine($"WORKFLOW ITEM ADDED: {newWorkflowActionItem.ActionId} (previous: {newWorkflowActionItem.PreviousActionId}) -- {newWorkflowActionItem.Status}");
    }
    else if (update is StreamingResponseOutputItemDoneUpdate itemDoneUpdate
        && itemDoneUpdate.Item.AsAgentResponseItem() is AgentWorkflowActionResponseItem finishedWorkflowActionItem)
    {
        Console.WriteLine($"WORKFLOW ITEM DONE: {finishedWorkflowActionItem.ActionId} (previous: {finishedWorkflowActionItem.PreviousActionId}) -- {finishedWorkflowActionItem.Status}");
    }
    else if (update is StreamingResponseOutputTextDeltaUpdate textDeltaUpdate)
    {
        Console.Write(textDeltaUpdate.Delta);
    }
    else if (update is StreamingResponseOutputTextDoneUpdate)
    {
        Console.WriteLine();
    }
}
```
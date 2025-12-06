using System.Text.Json;

using Azure;
using Azure.AI.Agents.V2;
using Azure.AI.Agents.V2.Models;
using Azure.AI.AgentsHosting.Ingress.Common.Http.Json;
using Azure.AI.AgentsHosting.Ingress.Invocation;

using Microsoft.Agents.Workflows;
using Microsoft.Agents.Workflows.Reflection;
using Microsoft.Extensions.AI;

namespace FoundryConversation.Executors;

public class RetrieveChatHistoryExecutor(AgentsClient agentsClient)
    : ReflectingExecutor<RetrieveChatHistoryExecutor>,
        IMessageHandler<List<ChatMessage>>,
        IMessageHandler<TurnToken>
{
    private static readonly JsonSerializerOptions Json = JsonExtensions.DefaultJsonSerializerOptions;

    public async ValueTask HandleAsync(TurnToken message, IWorkflowContext context)
    {
        await context.SendMessageAsync(message);
    }

    public async ValueTask HandleAsync(List<ChatMessage> messages, IWorkflowContext context)
    {
        if (AgentInvocationContext.Current == null)
        {
            await context.SendMessageAsync(messages);
            return;
        }

        var conversationId = AgentInvocationContext.Current.ConversationId;
        var conversation = agentsClient.GetConversationsClient()
            .GetConversationItemsAsync(conversationId, null, null, null, null, null, new RequestContext());

        await foreach (var item in conversation)
        {
            if (item == null)
            {
                continue;
            }

            var itemResource = item.ToObject<ItemResource>(Json);
            switch (itemResource)
            {
                case ResponsesMessageItemResource responsesMessage:
                    await context.SendMessageAsync(ConvertResponsesMessage(responsesMessage));
                    break;
                case FunctionToolCallItemResource functionCall:
                    var funcCall = new FunctionCallContent(functionCall.CallId, functionCall.Name,
                        JsonSerializer.Deserialize<IDictionary<string, object?>>(functionCall.Arguments));
                    await context.SendMessageAsync(new ChatMessage(ChatRole.Tool, [funcCall])
                    {
                        MessageId = functionCall.Id,
                    });
                    break;
                case FunctionToolCallOutputItemResource functionToolCallOutput:
                    var funcResult = new FunctionResultContent(functionToolCallOutput.CallId, functionToolCallOutput.Output);
                    await context.SendMessageAsync(new ChatMessage(ChatRole.Tool, [funcResult])
                    {
                        MessageId = functionToolCallOutput.Id,
                    });
                    break;
            }
        }

        await context.SendMessageAsync(messages);
    }

    private static ChatMessage ConvertResponsesMessage(ResponsesMessageItemResource responsesMessage)
    {
        var (role, contents) = responsesMessage switch
        {
            ResponsesUserMessageItemResource responsesUserMessage => (ChatRole.User, ConvertContents(responsesUserMessage.Content)),
            ResponsesAssistantMessageItemResource responsesAgentMessage => (ChatRole.Assistant, ConvertContents(responsesAgentMessage.Content)),
            ResponsesSystemMessageItemResource responsesSystemMessage => (ChatRole.System, ConvertContents(responsesSystemMessage.Content)),
            _ => throw new InvalidOperationException($"Unknown message type: {responsesMessage.GetType().FullName}"),
        };

        return new ChatMessage(role, contents.ToList())
        {
            MessageId = responsesMessage.Id,
        };
    }

    private static IEnumerable<AIContent> ConvertContents(IEnumerable<ItemContent> contents)
    {
        foreach (var content in contents)
        {
            switch (content)
            {
                case ItemContentOutputText textContent:
                    yield return new TextContent(textContent.Text);
                    break;
            }
        }
    }
}

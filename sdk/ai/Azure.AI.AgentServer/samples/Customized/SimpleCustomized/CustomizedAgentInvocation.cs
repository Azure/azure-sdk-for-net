using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Common.Id;
using Azure.AI.AgentServer.Responses.Invocation;

namespace SimpleCustomized;

public class CustomizedAgentInvocation : IAgentInvocation
{
    public Task<Response> InvokeAsync(CreateResponseRequest request, AgentInvocationContext context,
        CancellationToken cancellationToken = default)
    {
        var inputText = GetInputText(request);

        var text = "I am a mock agent with no intelligence. You said: " + inputText;

        IList<ItemContent> contents =
            [new ItemContentOutputText(text: text, annotations: [])];

        IList<ItemResource> outputs =
        [
            new ResponsesAssistantMessageItemResource(
                id: Guid.NewGuid().ToString(),
                status: ResponsesMessageItemResourceStatus.Completed,
                content: contents
            )
        ];

        return Task.FromResult(ToResponse(request, context, output: outputs));
    }

    public async IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var seq = -1;

        #region response.*

        yield return new ResponseCreatedEvent(++seq,
            ToResponse(request, context, status: ResponseStatus.InProgress));

        #region response.output_item.*

        var itemId = context.IdGenerator.GenerateMessageId();
        yield return new ResponseOutputItemAddedEvent(++seq, 0,
            item: new ResponsesAssistantMessageItemResource(
                id: itemId,
                status: ResponsesMessageItemResourceStatus.InProgress,
                content: []
            )
        );

        #region response.content_part.*

        yield return new ResponseContentPartAddedEvent(++seq, itemId, 0, 0,
            new ItemContentOutputText(text: "", annotations: [])
        );

        #region response.output_text.*

        var inputText = GetInputText(request);
        var text = "I am a mock agent with no intelligence. You said: " + inputText;
        foreach (var part in text.Split(" "))
        {
            await Task.Delay(100, cancellationToken).ConfigureAwait(false);
            yield return new ResponseTextDeltaEvent(++seq, itemId, 0, 0, part + " ");
        }

        yield return new ResponseTextDoneEvent(++seq, itemId, 0, 0, text);

        #endregion response.output_text.*

        var content = new ItemContentOutputText(text: text, annotations: []);
        yield return new ResponseContentPartDoneEvent(++seq, itemId, 0, 0, content);

        #endregion response.content_part.*

        var item = new ResponsesAssistantMessageItemResource(id: itemId, ResponsesMessageItemResourceStatus.Completed,
            content: [content]);
        yield return new ResponseOutputItemDoneEvent(++seq, 0, item);

        #endregion response.output_item.*

        yield return new ResponseCompletedEvent(++seq,
            ToResponse(request, context, status: ResponseStatus.Completed, output: [item]));

        #endregion response.*
    }

    private static string GetInputText(CreateResponseRequest request)
    {
        var items = request.Input.ToObject<IList<ItemParam>>();
        if (items is { Count: > 0 })
        {
            return items.Select(item =>
                {
                    return item switch
                    {
                        ResponsesUserMessageItemParam userMessage => userMessage.Content
                            .ToObject<IList<ItemContentInputText>>()?
                            .FirstOrDefault()?
                            .Text ?? "",
                        _ => ""
                    };
                })
                .FirstOrDefault() ?? "";
        }

        // implicit user message of text input
        return request.Input.ToString();
    }

    private static Response ToResponse(CreateResponseRequest request, AgentInvocationContext context,
        ResponseStatus status = ResponseStatus.Completed,
        IEnumerable<ItemResource>? output = null)
    {
        return request.ToResponse(context: context, output: output, status: status);
    }
}

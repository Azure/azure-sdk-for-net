# Sample 1: Getting Started — Q&A Assistant

This sample shows the minimal implementation of `ResponseHandler` — a Q&A assistant that answers user questions by streaming a text response.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

```C# Snippet:Responses_Sample1_QnAHandler
public class QnAHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        // In a real agent, call your model or knowledge base here.
        var question = request.GetInputText();
        var answer = $"You asked: \"{question}\". " +
                     "This is where your agent logic produces an answer.";

        yield return text.EmitDelta(answer);
        yield return text.EmitDone(answer);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
```

## Start the server

```C# Snippet:Responses_Sample1_StartServer
ResponsesServer.Run<QnAHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "qna", "input": "What is Azure AI Foundry?"}' \
  --no-buffer
```

# Sample 3: Streaming — Code Generation Agent

This sample builds a code generation agent that streams results back to the caller using **Server-Sent Events (SSE)**. The agent receives a natural-language prompt and streams generated code token by token, giving the caller real-time feedback.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Implement the handler

```C# Snippet:Invocations_Sample3_CodeGenHandler
public class CodeGenHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var input = await request.ReadFromJsonAsync<CodeGenInput>(cancellationToken);
        var prompt = input?.Prompt ?? "// no prompt provided";

        // Stream the response as Server-Sent Events.
        response.ContentType = "text/event-stream";
        response.Headers.CacheControl = "no-cache";

        // In a real agent, call a code model and stream tokens as they arrive.
        var codeTokens = new[]
        {
            "public class ",
            "Calculator\n",
            "{\n",
            "    public int ",
            "Add(int a, int b)",
            " => a + b;\n",
            "}\n"
        };

        foreach (var token in codeTokens)
        {
            if (cancellationToken.IsCancellationRequested)
                break;

            var data = JsonSerializer.Serialize(new { type = "token", content = token });
            await response.WriteAsync($"data: {data}\n\n", cancellationToken);
            await response.Body.FlushAsync(cancellationToken);

            // Simulate model generation latency.
            await Task.Delay(150, cancellationToken);
        }

        // Signal completion.
        var done = JsonSerializer.Serialize(new
        {
            type = "done",
            invocation_id = context.InvocationId
        });
        await response.WriteAsync($"data: {done}\n\n", cancellationToken);
        await response.Body.FlushAsync(cancellationToken);
    }
}

public record CodeGenInput(string Prompt);
```

## Start the server

```C# Snippet:Invocations_Sample3_StartServer
InvocationsServer.Run<CodeGenHandler>();
```

## Test the endpoint

```bash
curl -N -X POST http://localhost:8088/invocations \
  -H "Content-Type: application/json" \
  -d '{"prompt":"Write a Calculator class with an Add method"}'
```

You will see SSE events arrive incrementally:

```
data: {"type":"token","content":"public class "}

data: {"type":"token","content":"Calculator\n"}

data: {"type":"token","content":"{\n"}

...

data: {"type":"done","invocation_id":"..."}
```

## Implementation pattern

This is the **SSE Streaming** pattern from the Invocations protocol. The agent controls the `Content-Type` and writes directly to the response stream. The Core framework's SSE keep-alive ensures the connection stays open for slow consumers.

Use this when your agent generates output incrementally — code generation, text completion, log tailing, or any scenario where the caller benefits from seeing partial results.

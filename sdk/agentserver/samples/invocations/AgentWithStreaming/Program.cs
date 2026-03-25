// Code Gen Agent — Demonstrates server-sent events (SSE) streaming with the
// Invocations protocol. The handler streams generated code tokens one at a time,
// producing a real-time "typing" effect for the caller.

using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;

var builder = AgentHost.CreateBuilder(args);
builder.AddInvocations<CodeGenHandler>();
builder.Build().Run();

public class CodeGenHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var prompt = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);

        response.ContentType = "text/event-stream";
        response.Headers["Cache-Control"] = "no-cache";

        var tokens = new[]
        {
            "public ", "class ", "Hello", "World ", "{\n",
            "  public ", "static ", "void ", "Main() ", "{\n",
            "    Console", ".WriteLine", "(\"Hello!", "\");\n",
            "  }\n",
            "}\n"
        };

        foreach (var token in tokens)
        {
            await response.WriteAsync($"data: {token}\n\n", cancellationToken);
            await response.Body.FlushAsync(cancellationToken);
            await Task.Delay(100, cancellationToken);
        }

        await response.WriteAsync("data: [DONE]\n\n", cancellationToken);
        await response.Body.FlushAsync(cancellationToken);
    }
}

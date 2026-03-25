// Echo Agent — The simplest possible invocation handler: read plain text in, write plain text out.

using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;

var builder = AgentHost.CreateBuilder(args);
builder.AddInvocations<EchoHandler>();
builder.Build().Run();

public class EchoHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
        await response.WriteAsync($"You said: {input}", cancellationToken);
    }
}

# Azure AI Agent Server libraries for .NET

The Azure AI Agent Server libraries let you build ASP.NET Core servers that implement Azure AI agent protocols. Deploy existing agents — whether built with supported agent frameworks or custom code — into Microsoft AI Foundry with minimal effort.

## Packages

| Package | Description | NuGet |
|---------|-------------|-------|
| [Azure.AI.AgentServer.Core](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core) | Shared hosting foundation: library-owned ASP.NET Core host with OpenTelemetry, health checks, server version header, inbound request logging, and multi-protocol composition. | [![NuGet](https://img.shields.io/nuget/vpre/Azure.AI.AgentServer.Core.svg)](https://www.nuget.org/packages/Azure.AI.AgentServer.Core) |
| [Azure.AI.AgentServer.Responses](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses) | Responses protocol implementation: SSE streaming, background execution, response lifecycle management, and `ResponseHandler` interface. | [![NuGet](https://img.shields.io/nuget/vpre/Azure.AI.AgentServer.Responses.svg)](https://www.nuget.org/packages/Azure.AI.AgentServer.Responses) |
| [Azure.AI.AgentServer.Invocations](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations) | Invocations protocol implementation: `InvocationHandler` abstract class, session resolution, client header forwarding, and invocation lifecycle. | [![NuGet](https://img.shields.io/nuget/vpre/Azure.AI.AgentServer.Invocations.svg)](https://www.nuget.org/packages/Azure.AI.AgentServer.Invocations) |

## When to use which package

- **Core** is the foundation — install it when you need a server host. It is automatically referenced by both protocol packages.
- **Responses** implements the Azure AI Responses API (SSE streaming, function calling, conversation history). Use it when your agent communicates via the Responses protocol.
- **Invocations** implements the Azure AI Invocations protocol (request/response handler pattern). Use it when your agent communicates via the Invocations protocol.
- **Both protocols together**: Use `AgentHostBuilder` with `.AddResponses<T>()` and `.AddInvocations<T>()` to compose both protocols on a single host.

## Getting started

### Responses protocol

The fastest way to get a Responses protocol server running:

```C# Snippet:Responses_ReadMe_ConfigureServer_Tier1
ResponsesServer.Run<EchoHandler>();
```

Where `EchoHandler` implements the Responses protocol:

```C# Snippet:Responses_ReadMe_EchoHandler
public class EchoHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            createText: async ct =>
            {
                var input = await context.GetInputTextAsync(cancellationToken: ct);
                return $"Echo: {input}";
            });
    }
}
```

### Invocations protocol

The fastest way to get an Invocations protocol server running:

```C# Snippet:Invocations_Sample1_StartServer
InvocationsServer.Run<EchoHandler>();
```

Where `EchoHandler` implements the Invocations protocol:

```C# Snippet:Invocations_Sample1_EchoHandler
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
```

See each package's README for detailed getting started instructions.

## Contributing

See the [Azure SDK CONTRIBUTING.md][contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com


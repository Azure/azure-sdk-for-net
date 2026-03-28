# Azure AI Agent Server libraries for .NET

The Azure AI Agent Server libraries let you build ASP.NET Core servers that implement Azure AI agent protocols. Deploy existing agents — whether built with supported agent frameworks or custom code — into Microsoft AI Foundry with minimal effort.

## Packages

| Package | Description | NuGet |
|---------|-------------|-------|
| [Azure.AI.AgentServer.Core](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core) | Shared hosting foundation: library-owned ASP.NET Core host with OpenTelemetry, health checks, server user-agent header, and multi-protocol composition. | [![NuGet](https://img.shields.io/nuget/vpre/Azure.AI.AgentServer.Core.svg)](https://www.nuget.org/packages/Azure.AI.AgentServer.Core) |
| Azure.AI.AgentServer.Responses *(coming soon)* | Responses protocol implementation: SSE streaming, background execution, response lifecycle management, and `IResponseHandler` interface. | [![NuGet](https://img.shields.io/nuget/vpre/Azure.AI.AgentServer.Responses.svg)](https://www.nuget.org/packages/Azure.AI.AgentServer.Responses) |
| Azure.AI.AgentServer.Invocations *(coming soon)* | Invocations protocol implementation: `InvocationHandler` abstract class, session resolution, client header forwarding, and invocation lifecycle. | [![NuGet](https://img.shields.io/nuget/vpre/Azure.AI.AgentServer.Invocations.svg)](https://www.nuget.org/packages/Azure.AI.AgentServer.Invocations) |

## When to use which package

- **Core** is the foundation — install it when you need a server host. It is automatically referenced by both protocol packages.
- **Responses** implements the Azure AI Responses API (SSE streaming, function calling, conversation history). Use it when your agent communicates via the Responses protocol.
- **Invocations** implements the Azure AI Invocations protocol (request/response handler pattern). Use it when your agent communicates via the Invocations protocol.
- **Both protocols together**: Use `AgentHostBuilder` with `.AddResponses<T>()` and `.AddInvocations<T>()` to compose both protocols on a single host.

## Getting started

The fastest way to get a server running:

```csharp
using Azure.AI.AgentServer.Core;

var builder = AgentHost.CreateBuilder();

// Protocol packages provide extension methods to register their endpoints.
// Example (requires a protocol package such as Azure.AI.AgentServer.Responses):
// builder.AddResponses<MyHandler>();

var app = builder.Build();
app.Run();
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


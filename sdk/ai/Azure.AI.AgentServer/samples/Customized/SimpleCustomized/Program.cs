// See https://aka.ms/new-console-template for more information

using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Extensions.DependencyInjection;

using SimpleCustomized;

// Run container agents adapter with customized agent invocation factory
// Use IServiceProvider.GetRequiredService<IAgentInvocation> as factory if you are using DI.
await AgentServerApplication.RunAsync(new ApplicationOptions(
    ConfigureServices: services => services.AddSingleton<IAgentInvocation, CustomizedAgentInvocation>()
)).ConfigureAwait(false);

public partial class CustomizedAgentInvocationProgram { } // for integration test

// See https://aka.ms/new-console-template for more information

using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Extensions.DependencyInjection;

namespace  Agents.Customized.Integration.Tests;

public partial class Program
{
    private static async Task Main()
    {
        // Run Agent Server with customized agent invocation factory
        // Use IServiceProvider.GetRequiredService<IAgentInvocation> as factory if you are using DI.
        await AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services => services.AddSingleton<IAgentInvocation, CustomizedAgentInvocation>()
        )).ConfigureAwait(false);
    }
}

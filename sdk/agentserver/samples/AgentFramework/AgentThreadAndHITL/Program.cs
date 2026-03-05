using System.ComponentModel;
using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.AgentServer.AgentFramework.Persistence;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI.Chat;

namespace AgengThreadAndHITL;

public partial class Program
{
    public static async Task Main()
    {
        var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
        var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";

        // Create a sample function tool that the agent can use.
        [Description("Get the weather for a given location.")]
        static string GetWeather([Description("The location to get the weather for.")] string location)
            => $"The weather in {location} is cloudy with a high of 15°C.";

        // Create the chat client and agent.
        // Note that we are wrapping the function tool with ApprovalRequiredAIFunction to require user approval before invoking it.
        // user should reply with 'approve' or 'reject' when prompted.

        AIAgent agent = new AzureOpenAIClient(
            new Uri(endpoint),
            new AzureCliCredential())
            .GetChatClient(deploymentName)
            .AsAIAgent(
                instructions: "You are a helpful assistant",
                tools: [new ApprovalRequiredAIFunction(AIFunctionFactory.Create(GetWeather))]
            );

        var threadRespository = new InMemoryAgentThreadRepository(agent);
        await agent.RunAIAgentAsync(telemetrySourceName: "Agents", threadRepository: threadRespository);
    }
}

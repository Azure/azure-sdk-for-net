using System.ComponentModel;
using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ??
               throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";

[Description("Get the weather for a given location.")]
static string GetWeather([Description("The location to get the weather for.")] string location)
    => $"The weather in {location} is cloudy with a high of 15°C.";

var chatClient = new AzureOpenAIClient(
        new Uri(endpoint),
        new DefaultAzureCredential())
    .GetChatClient(deploymentName)
    .AsIChatClient()
    .AsBuilder()
    .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
    .Build();

var agent = new ChatClientAgent(chatClient,
        name: "test-agent",
        instructions: "You are a helpful assistant, you can help the user with weather information.",
        tools: [AIFunctionFactory.Create(GetWeather)])
    .AsBuilder()
    .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
    .Build();

// Run container agent adapter
await agent.RunAIAgentAsync(telemetrySourceName: "Agents");

// for integration test
public partial class MinimalConsoleProgram { }
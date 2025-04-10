using Azure;
using Azure.AI.Projects;
using Azure.AI.Projects.OneDP;
using Azure.Identity;
using Microsoft.Identity.Client;
using Thread = Azure.AI.Projects.OneDP.Thread;

namespace AgentSampleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await RunEphemeralAgentAsync();
            await RunPersistentAgentAsync();
        }

        public static async Task SimpleRunEphemeralAgentAsync()
        {
            string? endpoint = Environment.GetEnvironmentVariable("AI_PROJECT_ENDPOINT");
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new InvalidOperationException("AI_PROJECT_ENDPOINT environment variable is not set.");
            }

            AIProjectClient aiProjectClient = new AIProjectClient(
                new Uri(endpoint),
                new DefaultAzureCredential()
            );

            AgentsClient agentsClient = aiProjectClient.GetAgentsClient();
            Run run = (await agentsClient.RunAsync(
                modelId: "gpt-4o",
                instructions: "you are a helpful agent",
                message: "Tell me a joke"
            )).Value;

            foreach (var textMessage in run.RunOutputs.GetTextMessages())
            {
                Console.WriteLine("AGENT: " + textMessage);
            }
        }

        public static async Task SimpleRunPersistentAgentAsync()
        {
            string? endpoint = Environment.GetEnvironmentVariable("AI_PROJECT_ENDPOINT");
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new InvalidOperationException("AI_PROJECT_ENDPOINT environment variable is not set.");
            }

            AIProjectClient aiProjectClient = new AIProjectClient(
                new Uri(endpoint),
                new DefaultAzureCredential()
            );

            AgentsClient agentsClient = aiProjectClient.GetAgentsClient();
            Agent agent = (await agentsClient.CreateAgentAsync(
                displayName: "PersistentAgent",
                modelId: "gpt-4o",
                instructions: "You're a helpful assistant.")).Value;

            Response<Run> runResponse = await agentsClient.RunAsync(agentId: agent.AgentId, message: "Tell me a joke");
            foreach (var textMessage in runResponse.Value.RunOutputs.GetTextMessages())
            {
                Console.WriteLine("AGENT: " + textMessage);
            }

            agentsClient.DeleteAgent(agent.AgentId);
        }

        public static async Task RunEphemeralAgentAsync()
        {
            string? endpoint = Environment.GetEnvironmentVariable("AI_PROJECT_ENDPOINT");
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new InvalidOperationException("AI_PROJECT_ENDPOINT environment variable is not set.");
            }

            var aiProjectClient = new AIProjectClient(
                new Uri(endpoint),
                new DefaultAzureCredential()
            );

            var agentsClient = aiProjectClient.GetAgentsClient();

            var inputMessages = new List<ChatMessage>
            {
                new UserMessage(new List<AIContent>
                {
                    new TextContent("Tell me a joke")
                })
                {
                    AuthorName = "User"
                }
            };

            AgentConfigurationOptions agentConfigurationOptions = new AgentConfigurationOptions();
            agentConfigurationOptions.AgentModel = new AzureAgentModel("gpt-4o");
            agentConfigurationOptions.Instructions = "You're a helpful assistant.";

            RunInputs inputs = new RunInputs(inputMessages);
            Response<Run> runResponse = await agentsClient.RunAsync(
                options: agentConfigurationOptions,
                inputs: inputs
            );

            foreach (ChatMessage chatMsg in runResponse.Value.RunOutputs.Messages)
            {
                foreach (AIContent item in chatMsg.Content)
                {
                    if (item is TextContent text)
                    {
                        Console.WriteLine("AGENT: " + text.Text);
                    }
                }
            }
        }

        public static async Task RunPersistentAgentAsync()
        {
            string? endpoint = Environment.GetEnvironmentVariable("AI_PROJECT_ENDPOINT");
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new InvalidOperationException("AI_PROJECT_ENDPOINT environment variable is not set.");
            }

            var aiProjectClient = new AIProjectClient(
                new Uri(endpoint),
                new DefaultAzureCredential()
            );

            var agentsClient = aiProjectClient.GetAgentsClient();

            AgentConfigurationOptions agentConfigurationOptions = new AgentConfigurationOptions();
            agentConfigurationOptions.AgentModel = new AzureAgentModel("gpt-4o");
            agentConfigurationOptions.Instructions = "You're a helpful assistant.";

            AgentCreationOptions agentCreationOptions = new AgentCreationOptions("PersistentAgent", agentConfigurationOptions);

            var agentResponse = await agentsClient.CreateAgentAsync(agentCreationOptions);
            var agent = agentResponse.Value;

            var inputMessages = new List<ChatMessage>
            {
                new UserMessage(new List<AIContent>
                {
                    new TextContent("Say 'this is a test.'")
                })
                {
                    AuthorName = "Unknown"
                }
            };
            RunInputs inputs = new RunInputs(inputMessages);
            inputs.AgentId = agent.AgentId;

            Response<Run> runResponse = await agentsClient.RunAsync(
                new AgentConfigurationOptions(),
                inputs: inputs
            );

            foreach (ChatMessage chatMsg in runResponse.Value.RunOutputs.Messages)
            {
                foreach (AIContent item in chatMsg.Content)
                {
                    if (item is TextContent text)
                    {
                        Console.WriteLine("AGENT: " + text.Text);
                    }
                }
            }

            agentsClient.DeleteAgent(agent.AgentId);
        }

        public static async Task RunPersistentAgentUsingThreadAsync()
        {
            string? endpoint = Environment.GetEnvironmentVariable("AI_PROJECT_ENDPOINT");
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new InvalidOperationException("AI_PROJECT_ENDPOINT environment variable is not set.");
            }

            var aiProjectClient = new AIProjectClient(
                new Uri(endpoint),
                new DefaultAzureCredential()
            );

            var agentsClient = aiProjectClient.GetAgentsClient();

            AgentConfigurationOptions agentConfigurationOptions = new AgentConfigurationOptions();
            agentConfigurationOptions.AgentModel = new AzureAgentModel("gpt-4o");
            agentConfigurationOptions.Instructions = "You're a helpful assistant.";
            AgentCreationOptions agentCreationOptions = new AgentCreationOptions("PersistentAgent", agentConfigurationOptions);

            var agentResponse = await agentsClient.CreateAgentAsync(agentCreationOptions);
            var agent = agentResponse.Value;

            var inputMessages = new List<ChatMessage>
            {
                new UserMessage(new List<AIContent>
                {
                    new TextContent("Say 'this is a test.'")
                })
                {
                    AuthorName = "Unknown"
                }
            };
            RunInputs inputs = new RunInputs(inputMessages);
            inputs.AgentId = agent.AgentId;

            var threadsClient = aiProjectClient.GetThreadsClient();
            var initialMessage = new UserMessage(new List<AIContent>
            {
                new TextContent("Tell me a joke")
            })
            {
                AuthorName = "User"
            };
            Response<Thread> threadResponse = await threadsClient.CreateThreadAsync(new List<ChatMessage> { initialMessage });
            inputs.ThreadId = threadResponse.Value.ThreadId;
            Response<Run> runResponse = await agentsClient.RunAsync(
                new AgentConfigurationOptions(),
                inputs: inputs
            );

            foreach (ChatMessage chatMsg in runResponse.Value.RunOutputs.Messages)
            {
                foreach (AIContent item in chatMsg.Content)
                {
                    if (item is TextContent text)
                    {
                        Console.WriteLine("AGENT: " + text.Text);
                    }
                }
            }

            agentsClient.DeleteAgent(agent.AgentId);
        }
    }
}

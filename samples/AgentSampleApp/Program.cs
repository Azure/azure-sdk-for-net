using Azure;
using Azure.AI.Projects;
using Azure.AI.Projects.OneDP;
using Azure.Identity;
using Microsoft.Identity.Client;
using Conversation = Azure.AI.Projects.OneDP.Conversation;

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

            foreach (var textMessage in run.GetTextMessages())
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

            Run run = (await agentsClient.RunAsync(agentId: agent.AgentId, message: "Tell me a joke")).Value;
            foreach (var textMessage in run.GetTextMessages())
            {
                Console.WriteLine("AGENT: " + textMessage);
            }

            agentsClient.DeleteAgent(agent.AgentId);
        }

        // Fix for CS0122: Use a factory method or appropriate constructor to create an instance of AgentConfigurationOptions.
        // Fix for IDE0090: Simplify 'new' expression where applicable.

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

            var agentConfigurationOptions = new AgentConfigurationOptions("MyAgent");
            agentConfigurationOptions.AgentModel = new AzureAgentModel("gpt-4o");

            Response<Run> runResponse = await agentsClient.RunAsync(
                input: inputMessages,
                agentConfiguration: agentConfigurationOptions
            );

            foreach (ChatMessage chatMsg in runResponse.Value.Output)
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

            var agentResponse = await agentsClient.CreateAgentAsync(
                displayName: "MyAgent",
                agentModel: new AzureAgentModel("gpt-4o"),
                instructions: "You're a helpful assistant.");
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


            Response<Run> runResponse = await agentsClient.RunAsync(
                input: inputMessages,
                agentId: agent.AgentId
            );

            foreach (ChatMessage chatMsg in runResponse.Value.Output)
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

        public static async Task RunPersistentAgentUsingConversationAsync()
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


            var agentResponse = await agentsClient.CreateAgentAsync(
                displayName: "MyAgent",
                agentModel: new AzureAgentModel("gpt-4o"),
                instructions: "You're a helpful assistant.");
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

            var conversationsClient = aiProjectClient.GetConversationsClient();
            var initialMessage = new UserMessage(new List<AIContent>
            {
                new TextContent("Tell me a joke")
            })
            {
                AuthorName = "User"
            };
            Response<Conversation> conversationResponse = await conversationsClient.CreateConversationAsync(new List<ChatMessage> { initialMessage });
            
            Response<Run> runResponse = await agentsClient.RunAsync(
                input: inputMessages,
                agentId: agent.AgentId,
                conversationId: conversationResponse.Value.ConversationId
            );

            foreach (ChatMessage chatMsg in runResponse.Value.Output)
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

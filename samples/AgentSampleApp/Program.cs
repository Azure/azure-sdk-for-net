using Azure;
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

            Response<Run> runResponse = await agentsClient.RunAsync(
                agentModel: new AzureAgentModel("gpt-4o"),
                instructions: new List<DeveloperMessage>
                {
                    new DeveloperMessage(new List<AIContent>
                    {
                        new TextContent("You're a helpful assistant.")
                    })
                },
                input: inputMessages
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
            var agent = await agentsClient.CreateAgentAsync(
                name: "PersistentAgent",
                agentModel: new AzureAgentModel("gpt-4o"),
                instructions: new List<DeveloperMessage>
                {
                    new DeveloperMessage(new List<AIContent>
                    {
                        new TextContent("You're a helpful assistant.")
                    })
                }
            );

            string agentId = "MyPersistedAgent"; // Replace with your actual agent ID
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
                agentId: agentId
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
            var agentResponse = await agentsClient.CreateAgentAsync(
                name: "PersistentAgent",
                agentModel: new AzureAgentModel("gpt-4o"),
                instructions: new List<DeveloperMessage>
                {
                    new DeveloperMessage(new List<AIContent>
                    {
                        new TextContent("You're a helpful assistant.")
                    })
                }
            );
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

            var threadsClient = aiProjectClient.GetThreadsClient();

            var initialMessage = new UserMessage(new List<AIContent>
            {
                new TextContent("Tell me a joke")
            })
            {
                AuthorName = "User"
            };

            Response<Thread> threadResponse = await threadsClient.CreateThreadAsync(new List<ChatMessage> { initialMessage });

            Response<Run> runResponse = await agentsClient.RunAsync(
                input: inputMessages,
                agentId: agent.AgentId,
                threadId: threadResponse.Value.ThreadId
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
    }
}

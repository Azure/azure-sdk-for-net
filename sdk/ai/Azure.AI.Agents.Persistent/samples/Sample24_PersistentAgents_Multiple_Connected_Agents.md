# Sample for use of an agent with multiple connected agent tools in Azure.AI.Agents.Persistent.

To enable your Agent to use multiple other agents as tools (sub-agents), you use multiple `ConnectedAgentToolDefinition` instances, each with their own connected agent details.
1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsMultipleConnectedAgents_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");
PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
```

2. In the example below we will create two agents, one is returning the Microsoft stock price and another returns weather. Note that the `ConnectedAgentDetails` does not support local functions, we will use Azure function to return weather. The code of that function is given below; please see [Azure Function Call](#create-agent-with-azure-function-call) section for the instructions on how to deploy Azure Function. Here is the text of function we deployed to serve the toy weather forecast.
**Note:** The Azure Function may be only used in standard agent setup. Please follow the [instruction](https://github.com/azure-ai-foundry/foundry-samples/tree/main/samples/microsoft/infrastructure-setup/41-standard-agent-setup) to deploy an agent, capable of calling Azure Functions.

```C#
namespace WeatherAzureFuncNet
{
    public class GetWeather
    {
        private readonly ILogger<GetWeather> _logger;

        public GetWeather(ILogger<GetWeather> logger)
        {
            _logger = logger;
        }

        [Function("GetWeather")]
        [QueueOutput("weather-output", Connection = "AzureWebJobsStorage")]
        public string Run([QueueTrigger("weather-input", Connection = "AzureWebJobsStorage")] QueueMessage queueMessage, FunctionContext functionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var payload = JsonSerializer.Deserialize<WeatherPayload>(queueMessage.Body.ToString());
            object result;
            result = new
            {
                Value = payload.location.Equals("Seattle") ? "60 degrees and cloudy" : "10 degrees and sunny",
                payload.CorrelationId
            };
            return JsonSerializer.Serialize(result);
        }
    }

    public class WeatherPayload
    {
        public string CorrelationId { get; set; } = null!;
        public string location { get; set; } = null!;
    }
}
```

We create the `AzureFunctionToolDefinition` in the method called `GetAzureFunction`. This method will be used by the `weatherAgent` in the next step.

```C# Snippet:AgentsMultipleConnectedAgents_AzureFunction
private static AzureFunctionToolDefinition GetAzureFunction(string storageQueueUri)
{
    return new AzureFunctionToolDefinition(
        name: "GetWeather",
        description: "Get answers from the weather bot.",
        inputBinding: new AzureFunctionBinding(
            new AzureFunctionStorageQueue(
                queueName: "weather-input",
                storageServiceEndpoint: storageQueueUri
            )
        ),
        outputBinding: new AzureFunctionBinding(
            new AzureFunctionStorageQueue(
                queueName: "weather-output",
                storageServiceEndpoint: storageQueueUri
            )
        ),
        parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Location = new
                        {
                            Type = "string",
                            Description = "The location to get the weather for.",
                        }
                    },
                },
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
        )
    );
}
```

3. We will create multiple sub-agents first that will be used as connected agent tools.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgents_CreateSubAgents
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent weatherAgent = agentClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "weather-bot",
    instructions: "Your job is to get the weather for a given location. " +
                  "Use the provided function to get the weather in the given location.",
    tools: [GetAzureFunction(storageQueueUri)]
);

// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent stockPriceAgent = agentClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "stock-price-bot",
    instructions: "Your job is to get the stock price of a company. If asked for the Microsoft stock price, always return $350.");
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsAsync_CreateSubAgents
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent weatherAgent = await agentClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "weather-bot",
    instructions: "Your job is to get the weather for a given location. " +
                  "Use the provided function to get the weather in the given location.",
    tools: [GetAzureFunction(storageQueueUri)]
);

// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent stockPriceAgent = await agentClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "stock-price-bot",
    instructions: "Your job is to get the stock price of a company. If asked for the Microsoft stock price, always return $350.");
```

4. We will use the sub-agents details to initialize multiple `ConnectedAgentToolDefinition` instances.

```C# Snippet:AgentsMultipleConnectedAgents_GetConnectedAgents
ConnectedAgentToolDefinition stockPriceConnectedAgentTool = new(
    new ConnectedAgentDetails(
        id: stockPriceAgent.Id,
        name: "stock_price_bot",
        description: "Gets the stock price of a company"
    )
);

ConnectedAgentToolDefinition weatherConnectedAgentTool = new(
    new ConnectedAgentDetails(
        id: weatherAgent.Id,
        name: "weather_bot",
        description: "Gets the weather for a given location"
    )
);
```

5. We will use both `ConnectedAgentToolDefinition` instances during the main agent initialization.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgents_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = agentClient.Administration.CreateAgent(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant, and use the connected agents to get stock prices and weather.",
   tools: [stockPriceConnectedAgentTool, weatherConnectedAgentTool]);
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsAsync_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant, and use the connected agents to get stock prices and weather.",
   tools: [stockPriceConnectedAgentTool, weatherConnectedAgentTool]);
```

6. Now we will create the thread, add the message containing a question for agent and start the run.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgents_CreateThreadMessage
PersistentAgentThread thread = agentClient.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the stock price of Microsoft and the weather in Seattle?");

// Run the agent
ThreadRun run = agentClient.Runs.CreateRun(thread, agent);
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = agentClient.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsAsync_CreateThreadMessage
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the stock price of Microsoft and the weather in Seattle?");

// Run the agent
ThreadRun run = await agentClient.Runs.CreateRunAsync(thread, agent);
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await agentClient.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

7. Print the agent messages to console in chronological order.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgents_Print
Pageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

foreach (PersistentThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            Console.Write(textItem.Text);
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}>");
        }
        Console.WriteLine();
    }
}
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsAsync_Print
AsyncPageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

await foreach (PersistentThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            Console.Write(textItem.Text);
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}>");
        }
        Console.WriteLine();
    }
}
```

8. Clean up resources by deleting thread, main agent, and all sub-agents.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsCleanup
// NOTE: Comment out these four lines if you plan to reuse the agent later.
agentClient.Threads.DeleteThread(threadId: thread.Id);
agentClient.Administration.DeleteAgent(agentId: agent.Id);
agentClient.Administration.DeleteAgent(agentId: stockPriceAgent.Id);
agentClient.Administration.DeleteAgent(agentId: weatherAgent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsCleanupAsync
// NOTE: Comment out these four lines if you plan to reuse the agent later.
await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: stockPriceAgent.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: weatherAgent.Id);
```

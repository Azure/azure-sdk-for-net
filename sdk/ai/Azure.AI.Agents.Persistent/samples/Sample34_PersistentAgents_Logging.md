# Sample for logging of network calls in Azure.AI.Agents.Persistent.

In this example we will demonstrate how to log the network calls to the console in Azure.AI.Agents.Persistent.

1. Create a `LoggingPolicy` by inheriting the `HttpPipelinePolicy`. This class implements two methods `Process` and `ProcessAsync`. The Azure pipeline calls the chain of policies, where the preceding one calls the next policy, hence by placing calls to `ProcessMessage` method before and after `ProcessNext` we can print request and response. The `ProcessMessage` method contains logic to show the contents of web request and response along with headers and URI paths.

```C# Snippet:Logging_LoggingPolicy
public class LoggingPolicy : HttpPipelinePolicy
{
    private static void ProcessMessage(HttpMessage message)
    {
        if (message.Request is not null && !message.HasResponse)
        {
            Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
            Console.WriteLine($"--- New request ---");
            IEnumerable<string> headerPairs = message?.Request?.Headers.Select(header => $"\n    {header.Name}={(header.Name.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Request headers:{headers}");
            if (message.Request?.Content != null)
            {
                string contentType = "Unknown Content Type";
                if (message.Request.Headers.TryGetValue("Content-Type", out contentType) == true
                    && contentType == "application/json")
                {
                    using MemoryStream stream = new();
                    message.Request.Content.WriteTo(stream, default);
                    stream.Position = 0;
                    using StreamReader reader = new(stream);
                    string requestDump = reader.ReadToEnd();
                    stream.Position = 0;
                    requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                    // Make sure JSON string is properly formatted.
                    JsonSerializerOptions jsonOptions = new()
                    {
                        WriteIndented = true,
                    };
                    JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(requestDump);
                    Console.WriteLine("--- Begin request content ---");
                    Console.WriteLine(JsonSerializer.Serialize(jsonElement, jsonOptions));
                    Console.WriteLine("--- End request content ---");
                }
                else
                {
                    string length = message.Request.Content.TryComputeLength(out long numberLength)
                        ? $"{numberLength} bytes"
                        : "unknown length";
                    Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                }
            }
        }
        if (message.HasResponse)
        {
            IEnumerable<string> headerPairs = message?.Response?.Headers.Select(header => $"\n    {header.Name}={(header.Name.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Response headers:{headers}");
            if (message.BufferResponse)
            {
                Console.WriteLine("--- Begin response content ---");
                Console.WriteLine(message.Response.Content?.ToString());
                Console.WriteLine("--- End of response content ---");
            }
            else
            {
                Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
            }
        }
    }
    public LoggingPolicy() { }

    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ProcessMessage(message); // for request
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            ProcessNext(message, pipeline);
        }
        finally
        {
            Console.WriteLine($"Response time {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        ProcessMessage(message); // for response
    }

    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ProcessMessage(message); // for request
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            await ProcessNextAsync(message, pipeline);
        }
        finally
        {
            Console.WriteLine($"Response time {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        ProcessMessage(message); // for response
    }
}
```

2. We need to create an Agent client and read the environment variables, which will be used in the next steps. Note, that we added `LoggingPolicy` into the pipeline and it will be executed on a per-call bases.
```C# Snippet:Logging_CreateAgentClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsAdministrationClientOptions options = new();
options.AddPolicy(new LoggingPolicy(), HttpPipelinePosition.PerCall);
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential(), options);
```

3. Next we will need to create an Agent.

Synchronous sample:
```C# Snippet:Logging_CreateAgent_Sync
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);
```

Asynchronous sample:
```C# Snippet:Logging_CreateAgent_Async
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);
```

4. Create thread as a separate resource.

Synchronous sample:
```C# Snippet:Logging_CreateThread_Sync
PersistentAgentThread thread = client.Threads.CreateThread();
```

Asynchronous sample:
```C# Snippet:Logging_CreateThread_Async
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
```

5. Add the message to the thread, containing a question for agent. This message must have `User` role.

Synchronous sample:
```C# Snippet:Logging_CreateMessage_Sync
PersistentThreadMessage message = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
```

Asynchronous sample:
```C# Snippet:Logging_CreateMessage_Async
PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
```

6. Now we will need to create the run, which will assign agent to the thread.

Synchronous sample:
```C# Snippet:Logging_CreateRun_Sync
ThreadRun run = client.Runs.CreateRun(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

Asynchronous sample:
```C# Snippet:Logging_CreateRun_Async
ThreadRun run = await client.Runs.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

7. It may take some time to get the response from agent, so we will wait, when it will get to the terminal state. If the run is not successful, we will raise the assertion error with the last error message.

Synchronous sample:
```C# Snippet:Logging_WaitForRun_Sync
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:Logging_WaitForRun_Async
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

8. Print the agent's messages to console in chronological order.

Synchronous sample:
```C# Snippet:Logging_ListUpdatedMessages_Sync
Pageable<PersistentThreadMessage> messages
    = client.Messages.GetMessages(
        threadId: thread.Id, order: ListSortOrder.Ascending);

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
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

Asynchronous sample:
```C# Snippet:Logging_ListUpdatedMessages_Async
AsyncPageable<PersistentThreadMessage> messages
    = client.Messages.GetMessagesAsync(
        threadId: thread.Id, order: ListSortOrder.Ascending);

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
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

9. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:Logging_Cleanup_Sync
// NOTE: Comment out these two lines if you plan to reuse the agent later.
client.Threads.DeleteThread(threadId: thread.Id);
client.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:Logging_Cleanup_Async
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await client.Threads.DeleteThreadAsync(threadId: thread.Id);
await client.Administration.DeleteAgentAsync(agentId: agent.Id);
```

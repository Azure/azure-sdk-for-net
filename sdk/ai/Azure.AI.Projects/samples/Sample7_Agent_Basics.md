# Sample for basic use of an agent in Azure.AI.Projects.

In this example we will demonstrate creation and basic use of an agent step by step.

1. First we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:OverviewCreateAgentClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(connectionString, new DefaultAzureCredential());
```

2. Next we will need to create an agent.

Synchronous sample:
```C# Snippet:OverviewCreateAgentSync
Agent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);
```

Asynchronous sample:
```C# Snippet:OverviewCreateAgent
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);
```

3. We will create thread as a separate resource.

Synchronous sample:
```C# Snippet:OverviewCreateThreadSync
AgentThread thread = client.CreateThread();
```

Asynchronous sample:
```C# Snippet:OverviewCreateThread
AgentThread thread = await client.CreateThreadAsync();
```

4. We will add the message to the thread, containing a question for agent. This message must have `User` role.

Synchronous sample:
```C# Snippet:OverviewCreateMessageSync
ThreadMessage message = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
```

Asynchronous sample:
```C# Snippet:OverviewCreateMessage
ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
```

5. Now we will need to create the run, which will assign agent to the thread.

Synchronous sample:
```C# Snippet:OverviewCreateRunSync
ThreadRun run = client.CreateRun(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

Asynchronous sample:
```C# Snippet:OverviewCreateRun
ThreadRun run = await client.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

6. It may take some time to get the response from agent, so we will wait, when agent will get to the terminal state. If the run is not successful, we will raise the assertion error with the last error message.

Synchronous sample:
```C# Snippet:OverviewWaitForRunSync
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:OverviewWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
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
```C# Snippet:OverviewListUpdatedMessagesSync
PageableList<ThreadMessage> messages
    = client.GetMessages(
        threadId: thread.Id, order: ListSortOrder.Ascending);

foreach (ThreadMessage threadMessage in messages)
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
```C# Snippet:OverviewListUpdatedMessages
PageableList<ThreadMessage> messages
    = await client.GetMessagesAsync(
        threadId: thread.Id, order: ListSortOrder.Ascending);

foreach (ThreadMessage threadMessage in messages)
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

8. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:OverviewCleanupSync
client.DeleteThread(threadId: thread.Id);
client.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:OverviewCleanup
await client.DeleteThreadAsync(threadId: thread.Id);
await client.DeleteAgentAsync(agentId: agent.Id);
```
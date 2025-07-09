# Sample for using additional messages while creating agent run in Azure.AI.Agents.Persistent.

1. Create an agent client and use it to create and an agent.

Synchronous sample:
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_Create
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var agentClient = new PersistentAgentsClient(
    projectEndpoint,
    new DefaultAzureCredential());

// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = agentClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
    tools: [new CodeInterpreterToolDefinition()]);
```

Asynchronous sample:
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_CreateAsync
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var agentClient = new PersistentAgentsClient(
    projectEndpoint,
    new DefaultAzureCredential());

// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
    tools: [new CodeInterpreterToolDefinition()]);
```

2. Create the thread and run. In this example we are adding two extra messages to the thread, one with `Agent` and another with `User` role.

Synchronous sample:
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_Run
PersistentAgentThread thread = agentClient.Threads.CreateThread();
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the impedance formula?");

ThreadRun agentRun = agentClient.Runs.CreateRun(
    threadId: thread.Id,
    agent.Id,
    additionalMessages: [
        new ThreadMessageOptions(
            role: MessageRole.Agent,
            content: "E=mc^2"
        ),
        new ThreadMessageOptions(
            role: MessageRole.User,
            content: "What is the impedance formula?"
        ),
    ]
);

do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    agentRun = agentClient.Runs.GetRun(thread.Id, agentRun.Id);
}
while (agentRun.Status == RunStatus.Queued
    || agentRun.Status == RunStatus.InProgress);
```

Asynchronous sample:
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_RunAsync
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the impedance formula?");

ThreadRun agentRun = await agentClient.Runs.CreateRunAsync(
    threadId: thread.Id,
    agent.Id,
    additionalMessages: [
        new ThreadMessageOptions(
            role: MessageRole.Agent,
            content: "E=mc^2"
        ),
        new ThreadMessageOptions(
            role: MessageRole.User,
            content: "What is the impedance formula?"
        ),
    ]
);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    agentRun = await agentClient.Runs.GetRunAsync(thread.Id, agentRun.Id);
}
while (agentRun.Status == RunStatus.Queued
    || agentRun.Status == RunStatus.InProgress);
```

3. Finally, we print out all the messages to the console.

Synchronous sample:
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_Print
Pageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessages(thread.Id, order: ListSortOrder.Ascending);

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
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_PrintAsync
AsyncPageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessagesAsync(thread.Id, order:ListSortOrder.Ascending);

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

4. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
agentClient.Threads.DeleteThread(thread.Id);
agentClient.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:Sample_PersistentAgent_Multiple_Messages_CleanupAsync
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await agentClient.Threads.DeleteThreadAsync(thread.Id);
await agentClient.Administration.DeleteAgentAsync(agent.Id);
```

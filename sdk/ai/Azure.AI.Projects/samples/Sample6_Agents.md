# Sample using `Azure.AI.Agents` Extension in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `persistent agents` methods.

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.Agents.Persistent package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.

## Asynchronous sample

1. We need to create the agents client and read in some environment variables.

```C# Snippet:AI_Projects_ExtensionsAgentsBasicsAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();
```

1. Create an agent.

```C# Snippet:AI_Projects_ExtensionsAgentsOverviewCreateAgent
PersistentAgent agent = await agentsClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);
```

3. Create a thread.

```C# Snippet:AI_Projects_ExtensionsAgentsOverviewCreateThread
PersistentAgentThread thread = await agentsClient.Threads.CreateThreadAsync();
```

4. Add a message to a thread.

```C# Snippet:AI_Projects_ExtensionsAgentsOverviewCreateMessage
PersistentThreadMessage message = await agentsClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");
```

5. Run the agent.

```C# Snippet:AI_Projects_ExtensionsAgentsOverviewCreateRun
ThreadRun run = await agentsClient.Runs.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

6 . Whait while run complete.

```C# Snippet:AI_Projects_ExtensionsAgentsOverviewWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await agentsClient.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

7. List messages in chronological order.

```C# Snippet:AI_Projects_ExtensionsAgentsOverviewListUpdatedMessages
AsyncPageable<PersistentThreadMessage> messages
    = agentsClient.Messages.GetMessagesAsync(
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

8. Clean up the resources.

```C# Snippet:AI_Projects_ExtensionsAgentsOverviewCleanup
await agentsClient.Threads.DeleteThreadAsync(threadId: thread.Id);

await agentsClient.Administration.DeleteAgentAsync(agentId: agent.Id);
```


## Synchronous Sample

```C# Snippet:AI_Projects_ExtensionsAgentsBasicsSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

// Step 1: Create an agent
PersistentAgent agent = agentsClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);

//// Step 2: Create a thread
PersistentAgentThread thread = agentsClient.Threads.CreateThread();

// Step 3: Add a message to a thread
PersistentThreadMessage message = agentsClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");

// Intermission: message is now correlated with thread
// Intermission: listing messages will retrieve the message just added

List<PersistentThreadMessage> messagesList = [.. agentsClient.Messages.GetMessages(thread.Id)];
Assert.AreEqual(message.Id, messagesList[0].Id);

// Step 4: Run the agent
ThreadRun run = agentsClient.Runs.CreateRun(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = agentsClient.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);

Pageable<PersistentThreadMessage> messages
    = agentsClient.Messages.GetMessages(
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

agentsClient.Threads.DeleteThread(threadId: thread.Id);
agentsClient.Administration.DeleteAgent(agentId: agent.Id);
```
tsClient agentsClient = projectClient.GetPersistentAgentsClient();
```


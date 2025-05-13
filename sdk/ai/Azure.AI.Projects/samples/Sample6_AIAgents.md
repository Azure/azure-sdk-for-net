# Sample for Azure.AI.Projects Agent extensions

`PersistentAgentsClient` can be used to perform agentic tasks on `Serverless` models. To make the next samples work, please create the Serverless connection in the workspace, which supports Agents SDK.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the model deployment to use against your endpoint.

## Agent extensions

The Agent API can be called synchronously and asynchronously.

Synchronous sample:
```C# Snippet:ExtensionsAgentsBasicsSync
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
ThreadMessage message = agentsClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");

// Intermission: message is now correlated with thread
// Intermission: listing messages will retrieve the message just added

List<ThreadMessage> messagesList = [.. agentsClient.Messages.GetMessages(thread.Id)];
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

Pageable<ThreadMessage> messages
    = agentsClient.Messages.GetMessages(
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

agentsClient.Threads.DeleteThread(threadId: thread.Id);
agentsClient.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:ExtensionsAgentsBasicsAsync

var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

// Step 1: Create an agent
PersistentAgent agent = await agentsClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal math tutor. Write and run code to answer math questions."
);

//// Step 2: Create a thread
PersistentAgentThread thread = await agentsClient.Threads.CreateThreadAsync();

// Step 3: Add a message to a thread
ThreadMessage message = await agentsClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "I need to solve the equation `3x + 11 = 14`. Can you help me?");

// Intermission: message is now correlated with thread
// Intermission: listing messages will retrieve the message just added

AsyncPageable<ThreadMessage> messagesList = agentsClient.Messages.GetMessagesAsync(thread.Id);
List<ThreadMessage> messagesOne = await messagesList.ToListAsync();
Assert.AreEqual(message.Id, messagesOne[0].Id);

// Step 4: Run the agent
ThreadRun run = await agentsClient.Runs.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");

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

AsyncPageable<ThreadMessage> messages
    = agentsClient.Messages.GetMessagesAsync(
        threadId: thread.Id, order: ListSortOrder.Ascending);

await foreach (ThreadMessage threadMessage in messages)
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
await agentsClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentsClient.Administration.DeleteAgentAsync(agentId: agent.Id);
```


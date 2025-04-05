# Sample for using additional messages while creating assistant run in Azure.AI.Assistants.

1. Create an assistant client and use it to create and an assistant.

Synchronous sample:
```C# Snippet:Sample_Assistant_Multiple_Messages_Create
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var assistantClient = new AssistantsClient(
    connectionString,
    new DefaultAzureCredential());

Assistant assistant = assistantClient.CreateAssistant(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
    tools: [new CodeInterpreterToolDefinition()]);
```

Asynchronous sample:
```C# Snippet:Sample_Assistant_Multiple_Messages_CreateAsync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var assistantClient = new AssistantsClient(
    connectionString,
    new DefaultAzureCredential());

Assistant assistant = await assistantClient.CreateAssistantAsync(
    model: modelDeploymentName,
    name: "Math Tutor",
    instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
    tools: [new CodeInterpreterToolDefinition()]);
```

2. Create the thread and run. In this example we are adding two extra messages to the thread, one with `Assistant` and another with `User` role.

Synchronous sample:
```C# Snippet:Sample_Assistant_Multiple_Messages_Run
AssistantThread thread = assistantClient.CreateThread();
ThreadMessage message = assistantClient.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the impedance formula?");

ThreadRun assistantRun = assistantClient.CreateRun(
    threadId: thread.Id,
    assistant.Id,
    additionalMessages: [
        new ThreadMessageOptions(
            role: MessageRole.Assistant,
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
    assistantRun = assistantClient.GetRun(thread.Id, assistantRun.Id);
}
while (assistantRun.Status == RunStatus.Queued
    || assistantRun.Status == RunStatus.InProgress);
```

Asynchronous sample:
```C# Snippet:Sample_Assistant_Multiple_Messages_RunAsync
AssistantThread thread = await assistantClient.CreateThreadAsync();
ThreadMessage message = await assistantClient.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the impedance formula?");

ThreadRun assistantRun = await assistantClient.CreateRunAsync(
    threadId: thread.Id,
    assistant.Id,
    additionalMessages: [
        new ThreadMessageOptions(
            role: MessageRole.Assistant,
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
    assistantRun = await assistantClient.GetRunAsync(thread.Id, assistantRun.Id);
}
while (assistantRun.Status == RunStatus.Queued
    || assistantRun.Status == RunStatus.InProgress);
```

3. Finally, we print out all the messages to the console.

Synchronous sample:
```C# Snippet:Sample_Assistant_Multiple_Messages_Print
PageableList<ThreadMessage> messages = assistantClient.GetMessages(thread.Id, order: ListSortOrder.Ascending);

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
```C# Snippet:Sample_Assistant_Multiple_Messages_PrintAsync
PageableList<ThreadMessage> messages = await assistantClient.GetMessagesAsync(thread.Id, order:ListSortOrder.Ascending);

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
# Sample file search on assistant with message attachment and code interpreter in Azure.AI.Assistants.

In this example we demonstrate, how to use file search with `MessageAttachment`.

1. First we need to create assistant client and read the environment variables, which will be used in the next steps.
```C# Snippet:AssistantsCodeInterpreterFileAttachment_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. We need to create an assistant, create and upload file and `ThreadMessage` with the uploaded file ID in the `MessageAttachment`.

Synchronous sample:
```C# Snippet:AssistantsCreateAgentWithInterpreterToolSync
List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
Assistant assistant = client.CreateAssistant(
    model: modelDeploymentName,
    name: "my-assistant",
    instructions: "You are a helpful assistant that can help fetch data from files you know about.",
    tools: tools
);

System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
AssistantFile uploadedAssistantFile = client.UploadFile(
    filePath: "sample_file_for_upload.txt",
    purpose: AssistantFilePurpose.Assistants);
var fileId = uploadedAssistantFile.Id;

var attachment = new MessageAttachment(
    fileId: fileId,
    tools: tools
);

AssistantThread thread = client.CreateThread();

ThreadMessage message = client.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "Can you give me the documented codes for 'banana' and 'orange'?",
    attachments: [attachment]
);
```

Asynchronous sample:
```C# Snippet:AssistantsCreateAgentWithInterpreterTool
List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
Assistant assistant = await client.CreateAssistantAsync(
    model: modelDeploymentName,
    name: "my-assistant",
    instructions: "You are a helpful assistant that can help fetch data from files you know about.",
    tools: tools
);

System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
AssistantFile uploadedAssistantFile = await client.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: AssistantFilePurpose.Assistants);
var fileId = uploadedAssistantFile.Id;

var attachment = new MessageAttachment(
    fileId: fileId,
    tools: tools
);

AssistantThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "Can you give me the documented codes for 'banana' and 'orange'?",
    attachments: [ attachment ]
);
```

3. Next we will create a `ThreadRun` and wait until the run is completed. If the run was not successful we will print the last error message.

Synchronous sample:
```C# Snippet:AssistantsCodeInterpreterFileAttachmentSync_CreateRun
ThreadRun run = client.CreateRun(
    thread.Id,
    assistant.Id
);

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
```C# Snippet:AssistantsCodeInterpreterFileAttachment_CreateRun
ThreadRun run = await client.CreateRunAsync(
    thread.Id,
    assistant.Id
);

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

4. In this example we will use the utility function `WriteMessages`, to print messages to the console.
```C# Snippet:AssistantsCodeInterpreterFileAttachment_Print
private static void WriteMessages(IEnumerable<ThreadMessage> messages)
{
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
}
```

5. Print the messages to the console in chronological order.

Synchronous sample:
```C# Snippet:AssistantsCodeInterpreterFileAttachmentSync_PrintMessages
PageableList<ThreadMessage> messages = client.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages);
```

Asynchronous sample:
```C# Snippet:AssistantsCodeInterpreterFileAttachment_PrintMessages
PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages);
```

6. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AssistantsCodeInterpreterFileAttachmentSync_Cleanup
client.DeleteThread(thread.Id);
client.DeleteAssistant(assistant.Id);
```

Asynchronous sample:
```C# Snippet:AssistantsCodeInterpreterFileAttachment_Cleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAssistantAsync(assistant.Id);
```

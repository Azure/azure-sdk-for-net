# Sample file search with agent in Azure.AI.Projects.

In this example we will create the local file, upload it to the newly created `VectorStore`, which will be used in the file search.

1. First we need to create agent client and read the environment variables that will be used in the next steps.
```C# Snippet:FilesSearchExample_CreateClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(connectionString, new DefaultAzureCredential());
```

2. Now we will create a file and upload it to the data store.

Synchronous sample:
```C# Snippet:UploadAgentFilesToUse_Sync
// Upload a file and wait for it to be processed
File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
AgentFile uploadedAgentFile = client.UploadFile(
    filePath: "sample_file_for_upload.txt",
    purpose: AgentFilePurpose.Agents);
Dictionary<string, string> fileIds = new()
{
    { uploadedAgentFile.Id, uploadedAgentFile.Filename }
};
```

Asynchronous sample:
```C# Snippet:UploadAgentFilesToUse
// Upload a file and wait for it to be processed
File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
AgentFile uploadedAgentFile = await client.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: AgentFilePurpose.Agents);
Dictionary<string, string> fileIds = new()
{
    { uploadedAgentFile.Id, uploadedAgentFile.Filename }
};
```

3.  To create agent capable of using file search, we will create `VectorStore`, with the ID of uploaded file.

Synchronous sample:
```C# Snippet:CreateVectorStore_Sync
// Create a vector store with the file and wait for it to be processed.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
VectorStore vectorStore = client.CreateVectorStore(
    fileIds: new List<string> { uploadedAgentFile.Id },
    name: "my_vector_store");
```

Asynchronous sample:
```C# Snippet:CreateVectorStore
// Create a vector store with the file and wait for it to be processed.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
VectorStore vectorStore = await client.CreateVectorStoreAsync(
    fileIds:  new List<string> { uploadedAgentFile.Id },
    name: "my_vector_store");
```


4  The ID of the created vector store will be used in the `FileSearchToolResource` used for agent creation.

Synchronous sample:
```C# Snippet:CreateAgentWithFiles_Sync
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an agent with toolResources and process assistant run
Agent agent = client.CreateAgent(
        model: modelDeploymentName,
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
```

Asynchronous sample:
```C# Snippet:CreateAgentWithFiles
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an agent with toolResources and process assistant run
Agent agent = await client.CreateAgentAsync(
        model: modelDeploymentName,
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
```

5. To properly render the links to the file name we use the `WriteMessages` method, which internally calls `replaceReferences` method to replace reference placeholders by file IDs or by file names.
```C# Snippet:FilesSearchExample_Print
private static void WriteMessages(IEnumerable<ThreadMessage> messages, Dictionary<string, string> fileIds)
{
    foreach (ThreadMessage threadMessage in messages)
    {
        Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
        foreach (MessageContent contentItem in threadMessage.ContentItems)
        {
            if (contentItem is MessageTextContent textItem)
            {
                if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
                {
                    string strMessage = textItem.Text;
                    foreach (MessageTextAnnotation annotation in textItem.Annotations)
                    {
                        if (annotation is MessageTextFilePathAnnotation pathAnnotation)
                        {
                            strMessage = replaceReferences(fileIds, pathAnnotation.FileId, pathAnnotation.Text, strMessage);
                        }
                        else if (annotation is MessageTextFileCitationAnnotation citationAnnotation)
                        {
                            strMessage = replaceReferences(fileIds, citationAnnotation.FileId, citationAnnotation.Text, strMessage);
                        }
                    }
                    Console.Write(strMessage);
                }
                else
                {
                    Console.Write(textItem.Text);
                }
            }
            else if (contentItem is MessageImageFileContent imageFileItem)
            {
                Console.Write($"<image from ID: {imageFileItem.FileId}");
            }
            Console.WriteLine();
        }
    }
}

private static string replaceReferences(Dictionary<string, string> fileIds, string fileID, string placeholder, string text)
{
    if (fileIds.TryGetValue(fileID, out string replacement))
        return text.Replace(placeholder, $" [{replacement}]");
    else
        return text.Replace(placeholder, $" [{fileID}]");
}
```

6. We will ask a question to the file contents and add it to the thread, create run and wait while it will terminate. If the run was successful, we will render the response and provide the reference to the uploaded file.

Synchronous sample:
```C# Snippet:FilesSearchExample_CreateThreadAndRun_Sync
// Create thread for communication
AgentThread thread = client.CreateThread();

// Create message to thread
ThreadMessage messageResponse = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "Can you give me the documented codes for 'banana' and 'orange'?");

// Run the agent
ThreadRun run = client.CreateRun(thread, agent);

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
PageableList<ThreadMessage> messages = client.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages, fileIds);
```

Asynchronous sample:
```C# Snippet:FilesSearchExample_CreateThreadAndRun
// Create thread for communication
AgentThread thread = await client.CreateThreadAsync();

// Create message to thread
ThreadMessage messageResponse = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "Can you give me the documented codes for 'banana' and 'orange'?");

// Run the agent
ThreadRun run = await client.CreateRunAsync(thread, agent);

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
PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages, fileIds);
```

7. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:FilesSearchExample_Cleanup_Sync
client.DeleteVectorStore(vectorStore.Id);
client.DeleteFile(uploadedAgentFile.Id);
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:FilesSearchExample_Cleanup
await client.DeleteVectorStoreAsync(vectorStore.Id);
await client.DeleteFileAsync(uploadedAgentFile.Id);
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
# Sample for Azure.AI.Agents.Persistent and batch file search.

1. To perform batch file search by an agent, we first need to upload a file, create a vector store, and associate the file to the vector store. Here is an example:

Synchronous sample:
```C# Snippet:AgentsVectorStoreBatchFileSearchCreateVectorStore
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var filePath = GetFile();
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
    name: "sample_vector_store"
);

PersistentAgentFileInfo file = client.Files.UploadFile(filePath, PersistentAgentFilePurpose.Agents);
Dictionary<string, string> dtReferences = new()
{
    {file.Id, Path.GetFileName(file.Filename)}
};

var uploadTask = client.VectorStores.CreateVectorStoreFileBatch(
    vectorStoreId: vectorStore.Id,
    fileIds: [file.Id]
);
Console.WriteLine($"Created vector store file batch, vector store file batch ID: {uploadTask.Value.Id}");

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

List<ToolDefinition> tools = [new FileSearchToolDefinition()];
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: tools,
    toolResources: new ToolResources() { FileSearch = fileSearchResource }
);
```

Asynchronous sample:
```C# Snippet:AgentsVectorStoreBatchFileAsyncSearchCreateVectorStore
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var filePath = GetFile();
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
    name: "sample_vector_store"
);

PersistentAgentFileInfo file = await client.Files.UploadFileAsync(filePath, PersistentAgentFilePurpose.Agents);
Dictionary<string, string> dtReferences = new()
{
    {file.Id, Path.GetFileName(file.Filename)}
};

VectorStoreFileBatch uploadTask = await client.VectorStores.CreateVectorStoreFileBatchAsync(
    vectorStoreId: vectorStore.Id,
    fileIds: [file.Id]
);
Console.WriteLine($"Created vector store file batch, vector store file batch ID: {uploadTask.Id}");

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

List<ToolDefinition> tools = [new FileSearchToolDefinition()];
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: tools,
    toolResources: new ToolResources() { FileSearch = fileSearchResource }
);
```

2. Then we need to create thread, add the message and start the run. If the run did not completed successfully, we will show the last error message, otherwise we will list messages in chronological order.

Synchronous sample:
```C# Snippet:AgentsVectorStoreBatchFileSearchThreadAndResponse
PersistentAgentThread thread = client.Threads.CreateThread();

PersistentThreadMessage message = client.Messages.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What feature does Smart Eyewear offer?"
    );

ThreadRun run = client.Runs.CreateRun(
    thread.Id,
    agent.Id
);

do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.Runs.GetRun(thread.Id,  run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages, dtReferences);
```

Asynchronous sample:
```C# Snippet:AgentsVectorStoreBatchFileSearchAsyncThreadAndResponse
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What feature does Smart Eyewear offer?"
);

ThreadRun run = await client.Runs.CreateRunAsync(
    thread.Id,
    agent.Id
);

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
List<PersistentThreadMessage> messages = await client.Messages.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
).ToListAsync();
WriteMessages(messages, dtReferences);
```

3. After the run complete, we will use `WriteMessages` method to swap reference placeholders by the actual file names or IDs.
```C# Snippet:AgentsVectorStoreBatchFileSearchParseResults
private static void WriteMessages(IEnumerable<PersistentThreadMessage> messages, Dictionary<string, string> fileIds)
{
    foreach (PersistentThreadMessage threadMessage in messages)
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

4. Finally we will clean up the resources.

Synchronous sample:
```C# Snippet:AgentsVectorStoreBatchFileSearchCleanup
bool delTask = client.VectorStores.DeleteVectorStore(vectorStore.Id);
if (delTask)
{
    Console.WriteLine($"Deleted vector store {vectorStore.Id}");
}
else
{
    Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
}
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsVectorStoreBatchFileSearchAsyncCleanup
bool delTask = await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
if (delTask)
{
    Console.WriteLine($"Deleted vector store {vectorStore.Id}");
}
else
{
    Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
}
await client.Administration.DeleteAgentAsync(agent.Id);
```

# Sample enterprise file search with agent in Azure.AI.Agents.

In the enterprise file search, as opposed to regular file search, we are assuming that user has uploaded the file to Azure and have registered it in the Azure AI Foundry. In the example below we will utilize the asset ID from Azure as a data source for the `VectorStore`.

1. First we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:AgentsEnterpriseFileSearch_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. To create agent capable of using Enterprise file search, we will create `VectorStoreDataSource` and will supply it to `VectorStore` constructor. The ID of the created vector store will be used in the `FileSearchToolResource` used for agent creation. 
Synchronous sample: 
```C# Snippet:AgentsCreateVectorStoreBlobSync
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);
VectorStore vectorStore = client.CreateVectorStore(
    name: "sample_vector_store",
    storeConfiguration: new VectorStoreConfiguration(
        dataSources: [ds]
    )
);

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

List<ToolDefinition> tools = [new FileSearchToolDefinition()];
PersistentAgent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: tools,
    toolResources: new ToolResources() { FileSearch = fileSearchResource }
);
```

Asynchronous sample:
```C# Snippet:AgentsCreateVectorStoreBlob
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);
VectorStore vectorStore = await client.CreateVectorStoreAsync(
    name: "sample_vector_store",
    storeConfiguration: new VectorStoreConfiguration(
        dataSources: [ ds ]
    )
);

FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

List<ToolDefinition> tools = [new FileSearchToolDefinition()];
PersistentAgent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: tools,
    toolResources: new ToolResources() { FileSearch = fileSearchResource }
);
```

3. In this example we will ask a question to the file contents and add it to the thread; we will create run and wait while it will terminate.

Synchronous sample:
```C# Snippet:AgentsEnterpriseFileSearch_CreateThreadMessage
PersistentAgentThread thread = client.CreateThread();

ThreadMessage message = client.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What feature does Smart Eyewear offer?"
);

ThreadRun run = client.CreateRun(
    thread.Id,
    agent.Id
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
```C# Snippet:AgentsEnterpriseFileSearchAsync_CreateThreadMessage
PersistentAgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What feature does Smart Eyewear offer?"
    );

ThreadRun run = await client.CreateRunAsync(
    thread.Id,
    agent.Id
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

4. When we create `VectorStore`, it ingests the contents of the Azure Blob, provided in the `VectorStoreDataSource` object and associates it with File ID. To provide the file name we will need to get the file name by ID, which in our case will be Azure Resource ID and take its last segment.

Synchronous sample:
```C# Snippet:AgentsEnterpriseFileSearch_ListUpdatedMessages
PageableList<ThreadMessage> messages = client.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
// Build the map of file IDs to file names.
string after = null;
PersistentAgentPageableListOfVectorStoreFile storeFiles;
Dictionary<string, string> dtFiles = [];
do
{
    storeFiles = client.GetVectorStoreFiles(
        vectorStoreId: vectorStore.Id,
        after: after
    );
    after = storeFiles.LastId;
    foreach (VectorStoreFile fle in storeFiles.Data)
    {
        PersistentAgentFile agentFile = client.GetFile(fle.Id);
        Uri uriFile = new(agentFile.Filename);
        dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
    }
}
while (storeFiles.HasMore);
WriteMessages(messages, dtFiles);
```

Asynchronous sample:
```C# Snippet:AgentsEnterpriseFileSearchAsync_ListUpdatedMessages
PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
// Build the map of file IDs to file names.
string after = null;
PersistentAgentPageableListOfVectorStoreFile storeFiles;
Dictionary<string, string> dtFiles = [];
do
{
    storeFiles = await client.GetVectorStoreFilesAsync(
        vectorStoreId: vectorStore.Id,
        after: after
    );
    after = storeFiles.LastId;
    foreach (VectorStoreFile fle in storeFiles.Data)
    {
        PersistentAgentFile agentFile = await client.GetFileAsync(fle.Id);
        Uri uriFile = new(agentFile.Filename);
        dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
    }
}
while (storeFiles.HasMore);
WriteMessages(messages, dtFiles);
```

5. To properly render the links to the file name we use the `WriteMessages` method, which internally calls `replaceReferences` method to replace reference placeholders by file IDs or by file names.
```C# Snippet:AgentsEnterpriseFileSearch_WriteMessages
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

6. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentsEnterpriseFileSearch_Cleanup
VectorStoreDeletionStatus delTask = client.DeleteVectorStore(vectorStore.Id);
if (delTask.Deleted)
{
    Console.WriteLine($"Deleted vector store {vectorStore.Id}");
}
else
{
    Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
}
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsEnterpriseFileSearchAsync_Cleanup
VectorStoreDeletionStatus delTask = await client.DeleteVectorStoreAsync(vectorStore.Id);
if (delTask.Deleted)
{
    Console.WriteLine($"Deleted vector store {vectorStore.Id}");
}
else
{
    Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
}
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
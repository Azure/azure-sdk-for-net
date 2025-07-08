# Sample file search using `VectorStoreFile` and agents in Azure.AI.Agents.Persistent.

This example demonstrates how to use a local file with a vector store and Agents in Azure.AI.Agents.Persistent. You will upload a file, add its file ID to a new vector store, and then examine the run steps performed by the Agent.
1. Begin by creating the Agent client and reading the required environment variables.

```C# Snippet:PersistentAgents_VectorStoreFileSearch_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. Write a sample file to disk and upload it to the data store. Store the uploaded file's ID and name in a dictionary for later reference.

Synchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_FilesToUse_Sync
// Upload a file and wait for it to be processed
System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
PersistentAgentFileInfo uploadedAgentFile = client.Files.UploadFile(
    filePath: "sample_file_for_upload.txt",
    purpose: PersistentAgentFilePurpose.Agents);
Dictionary<string, string> fileIds = new()
{
    { uploadedAgentFile.Id, uploadedAgentFile.Filename }
};
```

Asynchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_FilesToUse_Async
// Upload a file and wait for it to be processed
System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
PersistentAgentFileInfo uploadedAgentFile = await client.Files.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: PersistentAgentFilePurpose.Agents);
Dictionary<string, string> fileIds = new()
{
    { uploadedAgentFile.Id, uploadedAgentFile.Filename }
};
```

3. Create a new vector store and add the uploaded file's ID to it. This enables the Agent to search the file's contents.

Synchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_VectorStore_Sync
// Create a vector store with the file and wait for it to be processed.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
    name: "my_vector_store");
// Add file ID to vector store.
VectorStoreFile vctFile = client.VectorStores.CreateVectorStoreFile(
    vectorStoreId: vectorStore.Id,
    fileId: uploadedAgentFile.Id
);
Console.WriteLine($"Added file to vector store. The id file in the vector store is {vctFile.Id}.");
```

Asynchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_VectorStore_Async
// Create a vector store.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
    name: "my_vector_store");
// Add file ID to vector store.
VectorStoreFile vctFile =  await client.VectorStores.CreateVectorStoreFileAsync(
    vectorStoreId: vectorStore.Id,
    fileId: uploadedAgentFile.Id
);
Console.WriteLine($"Added file to vector store. The id file in the vector store is {vctFile.Id}.");
```

4. Create a `FileSearchToolResource` and add the vector store's ID. Use this resource when creating the Agent, so it can access the file search capability.

Synchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_CreateAgent_Sync
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an Agent with toolResources and process Agent run
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
        model: modelDeploymentName,
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
```

Asynchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_CreateAgent_Async
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an Agent with toolResources and process Agent run
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
        model: modelDeploymentName,
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
```

5. To display file names instead of IDs in Agent responses, use a helper method to replace reference placeholders with the actual file names.

```C# Snippet:PersistentAgents_VectorStoreFileSearch_Print
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

6. Start a new thread, send a question to the Agent about the file's contents, and create a run. Wait for the run to complete, then display the Agent's response, including file references.

Synchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_CreateThreadAndRun_Sync
// Create thread for communication
PersistentAgentThread thread = client.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage messageResponse = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "Can you give me the documented codes for 'banana' and 'orange'?");

// Run the Agent
ThreadRun run = client.Runs.CreateRun(thread, agent);

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
Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages, fileIds);
```

Asynchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_CreateThreadAndRun_Async
// Create thread for communication
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage messageResponse = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "Can you give me the documented codes for 'banana' and 'orange'?");

// Run the Agent
ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

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
WriteMessages(messages, fileIds);
```

7. Use a helper function to print detailed information about each run step, such as message creation or tool calls, including any file search results.

```C# Snippet:PersistentAgents_VectorStoreFileSearch_PrintSteps
private static void printRunStepInfo(RunStep step)
{
    if (step.StepDetails is RunStepMessageCreationDetails messageCreationDetails)
    {
        Console.WriteLine($"Message creation step: messageID {messageCreationDetails.MessageCreation.MessageId}");
    }
    else if (step.StepDetails is RunStepToolCallDetails toolCallDetails)
    {
        Console.WriteLine($"Tool call step: Tool count: {toolCallDetails.ToolCalls.Count}; First tool {toolCallDetails.ToolCalls.First().Type}");
        if (toolCallDetails.ToolCalls[0] is RunStepFileSearchToolCall fileSearch)
        {
            Console.WriteLine($"\tFile search returned {fileSearch.FileSearch.Results.Count} result(s).");
            if (fileSearch.FileSearch.Results.Count > 0)
            {
                Console.WriteLine($"\t\tFound result in file {fileSearch.FileSearch.Results[0].FileName}");
            }
        }
    }
    else
    {
        Console.WriteLine(step.RunId);
    }
}
```

8. Iterate through all run steps to review the Agent's actions and outputs.

Synchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_ShowRunSteps_Sync
foreach (RunStep step in client.Runs.GetRunSteps(run))
{
    printRunStepInfo(step);
}
```

Asynchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_ShowRunSteps_Async
await foreach (RunStep step in client.Runs.GetRunStepsAsync(run))
{
    printRunStepInfo(step);
}
```

9. After the sample completes, delete all resources you created: the vector store, file, thread, and Agent.

Synchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_Cleanup_Sync
// NOTE: Comment out these four lines if you plan to reuse the agent later.
client.VectorStores.DeleteVectorStore(vectorStore.Id);
client.Files.DeleteFile(uploadedAgentFile.Id);
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:PersistentAgents_VectorStoreFileSearch_Cleanup_Async
// NOTE: Comment out these four lines if you plan to reuse the agent later.
await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
await client.Files.DeleteFileAsync(uploadedAgentFile.Id);
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```

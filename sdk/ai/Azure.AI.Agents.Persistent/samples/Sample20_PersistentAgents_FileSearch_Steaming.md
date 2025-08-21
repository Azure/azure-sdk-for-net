# Sample file search with agent and streaming in Azure.AI.Agents.Persistent.

In this example we will create the local file, upload it to the newly created `VectorStore`, which will be used in the file search. In this example we will stream the result.

1. First we need to create agent client and read the environment variables that will be used in the next steps.
```C# Snippet:AgentsFilesSearchStreamingExample_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. Create a file and upload it to the data store.

Synchronous sample:
```C# Snippet:AgentsUploadAgentFilesToUseStreaming_Sync
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
```C# Snippet:AgentsUploadAgentFilesToUseStreaming
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

3. To create agent capable of using file search, we will create `VectorStore`, with the ID of uploaded file.

Synchronous sample:
```C# Snippet:AgentsCreateVectorStoreStreaming_Sync
// Create a vector store with the file and wait for it to be processed.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
    fileIds: new List<string> { uploadedAgentFile.Id },
    name: "my_vector_store");
```

Asynchronous sample:
```C# Snippet:AgentsCreateVectorStoreStreaming
// Create a vector store with the file and wait for it to be processed.
// If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
    fileIds:  new List<string> { uploadedAgentFile.Id },
    name: "my_vector_store");
```


4  The ID of the created vector store will be used in the `FileSearchToolResource` needed for agent creation.

Synchronous sample:
```C# Snippet:AgentsCreateAgentWithFilesStreaming_Sync
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an agent with toolResources and process agent run
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
        model: modelDeploymentName,
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
```

Asynchronous sample:
```C# Snippet:AgentsCreateAgentWithFilesStreaming
FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

// Create an agent with toolResources and process agent run
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
        model: modelDeploymentName,
        name: "SDK Test Agent - Retrieval",
        instructions: "You are a helpful agent that can help fetch data from files you know about.",
        tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
        toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
```

5. To parse and print stream output, we will use the `ParseStreamingUdate` method, which replaces reference placeholders by file IDs or by file names and also prints cited text.
```C# Snippet:AgentsFilesSearchExampleStreaming_Print
private static void ParseStreamingUdate(StreamingUpdate streamingUpdate, Dictionary<string, string> fileIds)
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine("--- Run started! ---");
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        if (contentUpdate.TextAnnotation != null)
        {
            if (fileIds.TryGetValue(contentUpdate.TextAnnotation.InputFileId, out string annotation))
            {
                Console.Write($" [see {annotation}]");
            }
            else
            {
                Console.Write($" [see {contentUpdate.TextAnnotation.InputFileId}]");
            }
        }
        else
        {
            //Detect the reference placeholder and skip it. Instead we will print the actual reference.
            if (contentUpdate.Text[0] != (char)12304 || contentUpdate.Text[contentUpdate.Text.Length - 1] != (char)12305)
                Console.Write(contentUpdate.Text);
        }
    }
    else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunStepCompleted)
    {
        if (streamingUpdate is RunStepUpdate runStep)
        {
            if (runStep.Value.StepDetails is RunStepToolCallDetails toolCallDetails)
            {
                foreach (RunStepToolCall toolCall in toolCallDetails.ToolCalls)
                {
                    if (toolCall is RunStepFileSearchToolCall fileSearh)
                    {
                        Console.WriteLine($"The search tool has found the next relevant content in the file {fileSearh.FileSearch.Results[0].FileName}:");
                        Console.WriteLine(fileSearh.FileSearch.Results[0].Content[0].Text);
                        Console.WriteLine("===============================================================");
                    }
                }
            }
        }
    }
    else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
    {
        Console.WriteLine();
        Console.WriteLine("--- Run completed! ---");
    }
    else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
    {
        throw new InvalidOperationException($"Error: {errorStep.Value.LastError}");
    }
}
```

6. Now we will create thread and message used to ask a question to an Agent.

Synchronous sample:
```C# Snippet:AgentsFilesSearchExampleStreaming_CreateThreadMessage_Sync
// Create thread for communication
PersistentAgentThread thread = client.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage messageResponse = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "Can you give me the documented codes for 'banana' and 'orange'?");
```

Asynchronous sample:
```C# Snippet:AgentsFilesSearchExampleStreaming_CreateThreadMessage
// Create thread for communication
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage messageResponse = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "Can you give me the documented codes for 'banana' and 'orange'?");
```

7. Stream the results.

Synchronous sample:
```C# Snippet:AgentsFilesSearchExampleStreaming_StreamResults_Sync
// Create the stream and parse output
CreateRunStreamingOptions runOptions = new()
{
    Include = [RunAdditionalFieldList.FileSearchContents]
};
CollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreaming(thread.Id, agent.Id, options: runOptions);
foreach (StreamingUpdate streamingUpdate in stream)
{
    ParseStreamingUdate(streamingUpdate, fileIds);
}
```

Asynchronous sample:
```C# Snippet:AgentsFilesSearchExampleStreaming_StreamResults
// Create the stream and parse output.
CreateRunStreamingOptions runOptions = new()
{
    Include = [RunAdditionalFieldList.FileSearchContents]
};
AsyncCollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id, options: runOptions);
await foreach (StreamingUpdate streamingUpdate in stream)
{
    ParseStreamingUdate(streamingUpdate, fileIds);
}
```

8. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentsFilesSearchExampleSteaming_Cleanup_Sync
// NOTE: Comment out these four lines if you plan to reuse the agent later.
client.VectorStores.DeleteVectorStore(vectorStore.Id);
client.Files.DeleteFile(uploadedAgentFile.Id);
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsFilesSearchExampleSteaming_Cleanup
// NOTE: Comment out these four lines if you plan to reuse the agent later.
await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
await client.Files.DeleteFileAsync(uploadedAgentFile.Id);
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```
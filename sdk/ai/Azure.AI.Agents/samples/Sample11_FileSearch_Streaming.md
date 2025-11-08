# Sample file search with agent in Azure.AI.Agents in streaming scenarios.

In this example we will create the local file, upload it to Azure and will use it in the newly created `VectorStore` for file search.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_FileSearch_Streaming
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
OpenAIClient openAIClient = client.GetOpenAIClient();
```

2. We will create a toy example file and upload it using OpenAI mechanism.

Synchronous sample: 
```C# Snippet:Sample_UploadFile_FileSearch_Streaming_Sync
string filePath = "sample_file_for_upload.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
File.Delete(filePath);
```

Asynchronous sample:
```C# Snippet:Sample_UploadFile_FileSearch_Streaming_Async
string filePath = "sample_file_for_upload.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
File.Delete(filePath);
```

3. Create the `VectorStore` and provide it with uploaded file ID.

Synchronous sample:
```C# Snippet:Sample_CreateVectorStore_FileSearch_Streaming_Sync
VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
VectorStoreCreationOptions options = new()
{
    Name = "MySampleStore",
    FileIds = { uploadedFile.Id }
};
VectorStore vectorStore = vctStoreClient.CreateVectorStore(options);
```

Asynchronous sample:
```C# Snippet:Sample_CreateVectorStore_FileSearch_Streaming_Async
VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
VectorStoreCreationOptions options = new()
{
    Name = "MySampleStore",
    FileIds = { uploadedFile.Id }
};
VectorStore vectorStore = await vctStoreClient.CreateVectorStoreAsync(options);
```

2. Now we can create an agent capable of using File search. 

Synchronous sample:
```C# Snippet:Sample_CreateAgent_FileSearch_Streaming_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can help fetch data from files you know about.",
    Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
};
AgentVersion agentVersion = client.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_FileSearch_Streaming_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can help fetch data from files you know about.",
    Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
};
AgentVersion agentVersion = await client.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

3. In this example we will ask a question to the file contents.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_FileSearch_Streaming_Sync
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
ConversationClient conversationClient = client.GetConversationClient();
AgentConversation conversation = conversationClient.CreateConversation();
responseOptions.SetConversationReference(conversation.Id);
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

ResponseItem request = ResponseItem.CreateUserMessageItem("Can you give me the documented codes for 'banana' and 'orange'?");
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_FileSearch_Streaming_Async
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
ConversationClient conversationClient = client.GetConversationClient();
AgentConversation conversation = await conversationClient.CreateConversationAsync();
responseOptions.SetConversationReference(conversation.Id);
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

ResponseItem request = ResponseItem.CreateUserMessageItem("Can you give me the documented codes for 'banana' and 'orange'?");
```

4. To format streaming response output we will create a helper method `ParseResponse`. If the stream ends up in error state, it will throw an error. 

```C# Snippet:Sample_ParseResponse_FileSearch_Streaming
private static void ParseResponse(StreamingResponseUpdate streamResponse)
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
    }
    else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
    {
        Console.WriteLine($"Delta: {textDelta.Delta}");
    }
    else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
    {
        Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
    }
    else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
    {
        if (itemDoneUpdate.Item is MessageResponseItem messageItem)
        {
            foreach (ResponseContentPart part in messageItem.Content)
            {
                foreach (ResponseMessageAnnotation annotation in part.OutputTextAnnotations)
                {
                    if (annotation is FileCitationMessageAnnotation fileAnnotation)
                    {
                        // Note fileAnnotation.Filename will be available in OpenAI package versions
                        // greater then 2.6.0.
                        Console.WriteLine($"File Citation - File ID: {fileAnnotation.FileId}");
                    }
                }
            }
        }
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
    }
}
```

5. Wait for the stream to complete.

Synchronous sample:
```C# Snippet:Sample_StreamingResponse_FileSearch_Streaming_Sync
foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming([request], responseOptions))
{
    ParseResponse(streamResponse);
}
```

Asynchronous sample:
```C# Snippet:Sample_StreamingResponse_FileSearch_Streaming_Async
await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync([request], responseOptions))
{
    ParseResponse(streamResponse);
}
```

6. Ask follow up question and start a new stream.

Synchronous sample:
```C# Snippet:Sample_FollowUp_FileSearch_Streaming_Sync
Console.WriteLine("Demonstrating follow-up query with streaming...");
request = ResponseItem.CreateUserMessageItem("What was my previous question about?");
foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming([request], responseOptions))
{
    ParseResponse(streamResponse);
}
```

Asynchronous sample:
```C# Snippet:Sample_FollowUp_FileSearch_Streaming_Async
Console.WriteLine("Demonstrating follow-up query with streaming...");
request = ResponseItem.CreateUserMessageItem("What was my previous question about?");
await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync([request], responseOptions))
{
    ParseResponse(streamResponse);
}
```

5. Finally, delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_FileSearch_Streaming_Sync
client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
vctStoreClient.DeleteVectorStore(vectorStoreId: vectorStore.Id);
fileClient.DeleteFile(uploadedFile.Id);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_FileSearch_Streaming_Async
await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
await vctStoreClient.DeleteVectorStoreAsync(vectorStoreId: vectorStore.Id);
await fileClient.DeleteFileAsync(uploadedFile.Id);
```

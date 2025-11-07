# Sample file search with agent in Azure.AI.Agents.

In this example we will create the local file, upload it to Azure and will use it in the newly created `VectorStore` for file search.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_FileSearch
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
OpenAIClient openAIClient = client.GetOpenAIClient();
```

2. We will create a toy example file and upload it using OpenAI mechanism.

Synchronous sample: 
```C# Snippet:Sample_UploadFile_FileSearch_Sync
string filePath = "sample_file_for_upload.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
File.Delete(filePath);
```

Asynchronous sample:
```C# Snippet:Sample_UploadFile_FileSearch_Async
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
```C# Snippet:Sample_CreateVectorStore_FileSearch_Sync
VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
VectorStoreCreationOptions options = new()
{
    Name = "MySampleStore",
    FileIds = { uploadedFile.Id }
};
VectorStore vectorStore = vctStoreClient.CreateVectorStore(options: options);
```

Asynchronous sample:
```C# Snippet:Sample_CreateVectorStore_FileSearch_Async
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
```C# Snippet:Sample_CreateAgent_FileSearch_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can help fetch data from files you know about.",
    Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
};
AgentVersion agentVersion = client.CreateAgentVersion(
    agentName: "myAgent",
    definition: agentDefinition,
    options: null);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_FileSearch_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful agent that can help fetch data from files you know about.",
    Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
};
AgentVersion agentVersion = await client.CreateAgentVersionAsync(
    agentName: "myAgent",
    definition: agentDefinition,
    options: null);
```

3. In this example we will ask a question to the file contents.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_FileSearch_Sync
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

ResponseItem request = ResponseItem.CreateUserMessageItem("The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
OpenAIResponse response = responseClient.CreateResponse(
    [request],
    responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_FileSearch_Async
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

ResponseItem request = ResponseItem.CreateUserMessageItem("The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
OpenAIResponse response = await responseClient.CreateResponseAsync(
    [request],
    responseOptions);
```

4. Wait for the response and throw an exception if the response contains the error.

Synchronous sample:
```C# Snippet:Sample_WaitForResponse_FileSearch_Sync
List<ResponseItem> updateItems = [request];
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    response = responseClient.GetResponse(responseId: response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WaitForResponse_FileSearch_Async
List<ResponseItem> updateItems = [request];
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId: response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

5. Finally, delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_FileSearch_Sync
client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
vctStoreClient.DeleteVectorStore(vectorStoreId: vectorStore.Id);
fileClient.DeleteFile(uploadedFile.Id);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_FileSearch_Async
await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
await vctStoreClient.DeleteVectorStoreAsync(vectorStoreId: vectorStore.Id);
await fileClient.DeleteFileAsync(uploadedFile.Id);
```

# Agents migration guide from Hub-based projects to Endpoint-based projects.
This guide describes migration from hub-based to Endpoint-based projects. To create an Endpoint-based project, please use one of the deployment scripts on [foundry samples repository](https://github.com/azure-ai-foundry/foundry-samples/tree/main/samples/microsoft/infrastructure-setup) appropriate for your scenario, also you can use Azure AI Foundry UI. The support of hub-based projects was dropped in `Azure.AI.Projects` version `1.0.0-beta.9`. In this document, we show the operation implementation of before `1.0.0-beta.9` in **Hub-based** section, followed by code for `azure-ai-projects` version `1.0.0-beta.9` or later in **Endpoint-based**.

## Installation
Starting from version `1.0.0-beta.9`, the operations, related to agents were moved to a separate package `Azure.AI.Agents.Persistent`. To use agents please add both `Azure.AI.Projects` and `Azure.AI.Agents.Persistent` packages into the project.
```
dotnet add package Azure.AI.Projects --version 1.0.0-beta.9
dotnet add package Azure.AI.Agents.Persistent --version 1.1.0-beta.3
```

## Namespace changes
Agents were moved to a new package and namespace `Azure.AI.Agents.Persistent`.

## Class renamings
| Hub-based | Endpoint-based |
|-|-|
| New in `1.0.0-beta.9` | `PersistentAgentsClient` |
| `AgentsClient` | `PersistentAgentsAdministrationClient` |
| `AgentsClientOptions` | `PersistentAgentsAdministrationClientOptions` |
| `Agent` | `PersistentAgent` |
| `AgentThread` | `PersistentAgentThread`|
| `ThreadMessage` | `PersistentThreadMessage` |
| `ThreadRun` | `ThreadRun` |
| `AgentFile` | `PersistentAgentFileInfo` |
| `VectorStore` | `PersistentAgentsVectorStore` |

## Class structure changes
Here `projectClient` is `AIProjectClient` and `agentClient` is `PersistentAgentsClient` for version `1.0.0-beta.9` and `AgentsClient` for earlier versions.

Agents Operations

| Hub-based | Endpoint-based |
|-|-|
| `projectClient.GetAgentsClient` | `projectClient.GetPersistentAgentsClient` |
| `agentClient.CreateAgent` | `agentClient.Administration.CreateAgent` |
| `agentClient.GetAgents` | `agentClient.Administration.GetAgents` |
| `agentClient.GetAgent` | `agentClient.Administration..GetAgent` |
| `agentClient.UpdateAgent` | `agentClient.Administration.UpdateAgent` |
| `agentClient.Delete_agent` | `agentClient.Administration.DeleteAgent` |
| `agentClient.CreateThreadAndRun` | `agentClient.CreateThreadAndRun` |

Threads Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.CreateThread` | `agentClient.Threads.CreateThread` |
| `agentClient.GetThread` | `agentClient.Threads.GetThread` |
| `agentClient.UpdateThread` | `agentClient.Threads.UpdateThread` |
| `agentClient.GetThreads` | `agentClient.Threads.GetThreads` |
| `agentClient.DeleteThread` | `agentClient.Threads.DeleteThread` |

Messages Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.CreateMessage` | `agentClient.Messages.CreateMessage` |
| `agentClient.GetMessages` | `agentClient.Messages.GetMessages` |
| `agentClient.GetMessage` | `pagentClient.Messages.GetMessage` |
| `agentClient.UpdateMessage` | `agentClient.Messages.UpdateMessage` |

Runs Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.CreateRun` | `agentClient.Runs.CreateRun` |
| `agentClient.GetRun` | `agentClient.Runs.GetRun` |
| `agentClient.GetRuns` | `agentClient.Runs.GetRuns` |
| `agentClient.UpdateRun` | `agentClient.Runs.UpdateRun` |
| `agentClient.CreateRunStreaming` | `agentClient.Runs.CreateRunStreaming` |
| `agentClient.SubmitToolOutputsToRun` | `agentClient.Runs.SubmitToolOutputsToRun` |
| `agentClient.SubmitToolOutputsToStream` | `agentClient.Runs.SubmitToolOutputsToStream` |
| `agentClient.CancelRun` | `agentClient.Runs.CancelRun` |

Run Steps Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.GetRunStep` | `agentClient.Runs.GetRunStep` |
| `agentClient.GetRunSteps` | `agentClient.Runs.GetRunSteps` |

Vector Stores Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.CreateVectorStore` | `agentClient.VectorStores.CreateVectorStore |
| `agentClient.GetVectorStores` | `agentClient.VectorStores.GetVectorStores |
| `agentClient.GetVectorStore` | `agentClient.VectorStores.GetVectorStore |
| `agentClient.ModifyVectorStore` | `agentClient.VectorStores.ModifyVectorStore |
| `agentClient.DeleteVectorStore` | `agentClient.VectorStores.DeleteVectorStore |

Vector Store Files Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.GetVectorStoreFiles` | `agentClient.VectorStores.GetVectorStoreFiles` |
| `agentClient.CreateVectorStoreFile` | `agentClient.VectorStores.CreateVectorStoreFile` |
| `agentClient.GetVectorStoreFile` | `agentClient.VectorStores.GetVectorStoreFile` |
| `agentClient.DeleteVectorStoreFile` | `agentClient.VectorStores.DeleteVectorStoreFile` |

Vector Store File Batches Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.CreateVectorStoreFileBatch` | `agentClient.VectorStores.CreateVectorStoreFileBatch`|
| `agentClient.GetVectorStoreFileBatch` | `agentClient.VectorStores.GetVectorStoreFileBatch`|
| `agentClient.GetVectorSroreFileBatchFiles` | `agentClient.VectorStores.GetVectorStoreFileBatchFiles`|
| `agentClient.CancelVectorStoreFileBatch` | `agentClient.VectorStores.CancelVectorStoreFileBatch`|

Files Operations

| Hub-based | Endpoint-based |
|-|-|
| `agentClient.UploadFile` | `agentClient.Files.UploadFile` |
| `agentClient.GetFile` | `agentClient.Files.GetFile` |
| `agentClient.GetFileContent` | `agentClient.Files.GetFileContent` |
| `agentClient.GetFiles` | `agentClient.Files.GetFiles` |
| `agentClient.DeleteFile` | `agentClient.Files.DeleteFile` |

## API changes
1. Create project. The connection string is replaced by the endpoint. The project endpoint URL has the form https://\<your-ai-services-account-name\>.services.ai.azure.com/api/projects/\<your-project-name\>. It can be found in your Azure AI Foundry Project overview page.

    **Hub-based**
    ```C#
    AIProjectClient projectClient = new (
        connectionString: connectionString,
        credential: new DefaultAzureCredential());
    ```

    **Endpoint-based**
    ```C#
    AIProjectClient projectClient = new(endpoint: endpoint, credential: new DefaultAzureCredential())
    ```
2. Agents client. In the new `Azure.AI.Projects` version `1.0.0-beta.9` agents are managed using `PersistentAgentsClient` class. It can be obtained from `AIProjectClient` instance or can be created using constructor. The letter allows to provide additional options for the `PersistentAgentsClient`.

    **Hub-based**
    ```C#
    AgentsClient agentClient = projectClient.GetAgentsClient();
    ```

    **Endpoint-based**
    Create agent using `AIProjectClient`.
    ```C#
    PersistentAgentsClient agentClient = projectClient.GetPersistentAgentsClient();
    ```

    We can create the agentClient using consructor and provide the additional options.
    ```C#
    PersistentAgentsClient agentClient = new(
        endpoint: projectEndpoint,
        credential: new DefaultAzureCredential(),
        options: new PersistentAgentsAdministrationClientOptions(version: PersistentAgentsAdministrationClientOptions.ServiceVersion.V2025_05_01)
    )
    ```

2. Create an agent. In the new versions of SDK, the agent can be created using `AgentsClient`'s `Administration` client.

    **Hub-based**
    ```python
    Agent agent = agentClient.CreateAgent(
        model: "gpt-4o",
        name: "my-agent",
        instructions: "You are helpful agent"
    );
    ```
    **Endpoint-based** 
    ```C#
    PersistentAgent agentClient = client.Administration.CreateAgent(
        model: "gpt-4o",
        name: "my-agent",
        instructions: "You are helpful agent"
    );
    ```

3. List agents. New version of SDK allows more convenient ways of listing agents by returning `Pageable` and `AsyncPageable`. The list of returned items is split by pages, which may be consequently returned to user. Below we will demonstrate this mechanism for agents. The `limit` parameter defines the number of items on the page. This example is also applicable for listing threads, runs, run steps, vector stores, files in vector store, and messages.

    **Hub-based**
    ```C#
    bool hasMore = true;
    int pageNum = 0;
    string lastID = default;
    while (hasMore)
    {
        Console.WriteLine($"Items on page {pageNum}");
        PageableList<Agent> agents = agentClient.GetAgents(after: lastID, limit: 2);
        foreach (Agent oneAgent in agents)
        {
            Console.WriteLine(oneAgent.Id);
        }
        hasMore = agents.HasMore;
        lastID = agents.LastId;
        pageNum++;
    }
    ```

    **Endpoint-based**
    ```C#
    Pageable<PersistentAgent> agents = agentClient.Administration.GetAgents(limit: 2);
    // Iterate items by page. Each page will be limited by two items.
    int pageNum = 0;
    foreach (Page<PersistentAgent> pgAgent in agents.AsPages())
    {
        Console.WriteLine($"Items on page {pageNum}");
        pageNum++;
        foreach (PersistentAgent oneAgent in pgAgent.Values)
        {
            Console.WriteLine(oneAgent.Id);
        }
    }

    // Iterate over all agents. Note, the agent list object needs to be re instantiated, the same object cannot be reused after iteration.
    Pageable<PersistentAgent> agents = agentClient.Administration.GetAgents();
    foreach (PersistentAgent oneAgent in agents)
    {
        Console.WriteLine(oneAgent.Id);
    }
    ```

4. Delete an agent.

    **Hub-based**
    ```C#
    bool isDeleted = agentClient.DeleteAgent(agentId: agent.Id);
    Console.WriteLine(isDeleted);
    ```

    **Endpoint-based**
    ```C#
    bool isDeleted = agentClient.Administration.DeleteAgent(agentId: agent.Id);
    Console.WriteLine(isDeleted);
    ```

5. Create a thread. In `Azure.AI.Agents.Persistent` the threads are managed by `Threads` client.

    **Hub-based**
    ```C#
    AgentThread thread = agentClient.CreateThread();
    ```
    **Endpoint-based**
    ```C#
    PersistentAgentThread thread = agentClient.Threads.CreateThread();
    ```
6. List threads.

    **Hub-based**
    ```C#
    bool hasMore = true;
    int pageNum = 0;
    string lastID = default;
    while (hasMore)
    {
        PageableList<AgentThread> threads = agentClient.GetThreads(after: lastID, limit: 2);
        Console.WriteLine($"Items on page {pageNum}");
        foreach (AgentThread oneThread in threads)
        {
            Console.WriteLine(oneThread.Id);
        }
        pageNum++;
        lastID = threads.LastId;
        hasMore = threads.HasMore;
    }
    ```

    **Endpoint-based**
    ```C#
    Pageable<PersistentAgentThread> threads = agentClient.Threads.GetThreads(limit: 2);
    // Iterate items by page. Each page will be limited by two items.
    int pageNum = 0;
    foreach (Page<PersistentAgentThread> pgThread in threads.AsPages())
    {
        Console.WriteLine($"Items on page {pageNum}");
        pageNum++;
        foreach (PersistentAgentThread oneThread in pgThread.Values)
        {
            Console.WriteLine(oneThread.Id);
        }
    }

    // Iterate over all threads. Note, the thread list object needs to be re-instantiated, the same object cannot be reused after iteration.
    Pageable<PersistentAgentThread> threads = agentClient.Threads.GetThreads();
    foreach (PersistentAgentThread oneThread in threads)
    {
        Console.WriteLine(oneThread.Id);
    }
    ```

7. Delete the thread.

    **Hub-based**
    ```C#
    bool isDeleted = agentClient.DeleteThread(threadId: tread.id);
    Console.WriteLine(isDeleted);
    ```

    **Endpoint-based**
    ```C#
    bool isDeleted = agentClient.Threads.DeleteThread(threadId: thread.Id);
    Console.WriteLine(isDeleted);
    ```
8. Create the message on a thread. In `Azure.AI.Agents.Persistent` the messages are managed by `Messages` client.

    **Hub-based**
    ```C#
    ThreadMessage message = agentClient.CreateMessage(
        threadId: thread.Id,
        role: MessageRole.User,
        content: "The message text.");
    ```

    **Endpoint-based**
    ```C#
    PersistentThreadMessage message = agentClient.Messages.CreateMessage(
        threadId: thread.Id,
        role: MessageRole.User,
        content: "The message text.");
    ```
9. Create and get the run. In `Azure.AI.Agents.Persistent` the runs are managed by `Runs` client.

    **Hub-based**
    ```C#
    ThreadRun run = agentClient.CreateRun(threadId: thread.Id, assistantId: agent.Id);
    run = agentClient.GetRun(threadId: thread.id, assistantId: run.id);
    ```

    **Endpoint-based**
    ```C#
    ThreadRun run = agentClient.Runs.CreateRun(threadId: thread.Id, assistantId: agent.Id);
    run = agentClient.Runs.GetRun(threadId: thread.Id, runId: run.Id);
    ```
10. List Runs.

    **Hub-based**
    ```C#
    bool hasMore = true;
    int pageNum = 0;
    string lastID = default;
    while (hasMore)
    {
        PageableList<ThreadRun> runs = agentClient.GetRuns(threadId: thread.Id, after: lastID);
        foreach (ThreadRun oneRun in runs)
        {
            Console.WriteLine(oneRun.Id);
        }
        hasMore = runs.HasMore;
        lastID = runs.LastId;
        pageNum++;
    }
    ```

    **Endpoint-based**
    ```C#
    Pageable<ThreadRun> runs = agentClient.Runs.GetRuns(threadId: thread.Id);
    foreach (ThreadRun oneRun in runs)
    {
        Console.WriteLine(oneRun.Id);
    }
    ```

11. List Run steps. In `Azure.AI.Agents.Persistent` the run steps are managed by `Runs` client.

    **Hub-based**
    ```C#
    bool hasMore = true;
    int pageNum = 0;
    string lastID = default;
    while (hasMore)
    {
        Console.WriteLine($"Items on page {pageNum}");
        PageableList<RunStep> runSteps = agentClient.GetRunSteps(threadId: thread.Id, runId: run.Id, after: lastID);
        foreach (RunStep oneRunStep in runSteps)
        {
            Console.WriteLine(oneRunStep.Id);
        }
        hasMore = runSteps.HasMore;
        lastID = runSteps.LastId;
        pageNum++;
    }
    ```

    **Endpoint-based**
    ```C#
    Pageable<RunStep> runSteps = agentClient.Runs.GetRunSteps(runId: run.Id, threadId: thread.Id);
    foreach (RunStep runStep in runSteps)
    {
        Console.WriteLine(runStep.Id);
    }
    ```

12. Using streams. In `Azure.AI.Agents.Persistent` the streams are managed by `Runs` client.

    **Hub-based**
    ```C#
    foreach (StreamingUpdate streamingUpdate in agentClient.CreateRunStreaming(threadId: thread.Id, assistantId: agent.Id))
    {
        if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
        {
            Console.WriteLine($"--- Run started! ---");
        }
        else if (streamingUpdate is MessageContentUpdate contentUpdate)
        {
            Console.Write(contentUpdate.Text);
            if (contentUpdate.ImageFileId is not null)
            {
                Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
            }
        }
    }
    ```

    **Endpoint-based**
    ```C#
    foreach (StreamingUpdate streamingUpdate in agentClient.Runs.CreateRunStreaming(threadId: thread.Id, agentId: agent.Id))
    {
        if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
        {
            Console.WriteLine($"--- Run started! ---");
        }
        else if (streamingUpdate is MessageContentUpdate contentUpdate)
        {
            Console.Write(contentUpdate.Text);
            if (contentUpdate.ImageFileId is not null)
            {
                Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
            }
        }
    }
    ```

13. List messages.

    **Hub-based**
    ```C#
    PageableList<ThreadMessage> messages = await agentClient.GetMessagesAsync(
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
    ```

    **Endpoint-based**
    ```C#
    Pageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessages(
        threadId: thread.Id, order: ListSortOrder.Ascending);

    foreach (PersistentThreadMessage threadMessage in messages)
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
14. Create, list and delete files are now handled by file operations. In `Azure.AI.Agents.Persistent` the files managed by `Files` client.

    **Hub-based**
    ```C#
    // Create file
    AgentFile uploadedAgentFile = client.UploadFile(filePath: "sample_file_for_upload.txt", purpose: AgentFilePurpose.Agents);
    // List and enumerate files
    IReadOnlyList<AgentFile> files = agentClient.GetFiles().Value;
    foreach (AgentFile oneFile in files)
    {
        Console.WriteLine(oneFile.Id);
    }
    // Delete file.
    bool isDeleted = agentClient.DeleteFile(fileId: file.Id);
    Console.WriteLine(isDeleted);
    ```

    **Endpoint-based**
    ```C#
    // Create file
    PersistentAgentFileInfo uploadedAgentFile = agentClient.Files.UploadFile(filePath: "sample_file_for_upload.txt", purpose: PersistentAgentFilePurpose.Agents);
    // List files
    IReadOnlyList<PersistentAgentFileInfo> files = agentClient.Files.GetFiles().Value;
    foreach (PersistentAgentFileInfo oneFile in files)
    {
        Console.WriteLine(oneFile.Id);
    }
    // Delete file.
    bool isDeleted = agentClient.Files.DeleteFile(fileId: oneFile.Id);
    Console.WriteLine(isDeleted)
    ```
15. Create, list vector store files list and delete vector stores. In `Azure.AI.Agents.Persistent`, the operation of file in the vector store or vector store deletion retuens boolean value instead of `VectorStoreFileDeletionStatus` and `VectorStoreDeletionStatus` respectively. In `Azure.AI.Agents.Persistent` the vector stores are managed by `VectorStores` client.

    **Hub-based**
    ```python
    // Create a vector store.
    VectorStore vectorStore = client.CreateVectorStore(fileIds: new List<string> { uploadedAgentFile.Id }, name: "my_vector_store");
    // List vector stores
    bool hasMore = true;
    string lastID = default;
    while (hasMore)
    {
        AgentPageableListOfVectorStore vectorStores = agentClient.GetVectorStores(after: lastID);
        foreach (VectorStore oneVectorStore in vectorStores.Data)
        {
            Console.WriteLine(oneVectorStore.Id);
        }
        hasMore = vectorStores.HasMore;
        lastID = vectorStores.LastId;
    }
    // List files in the vector store.
    bool hasMore = true;
    string lastID = default;
    while (hasMore)
    {
        AgentPageableListOfVectorStoreFile vectorStoresFiles = agentClient.GetVectorStoreFiles(
            vectorStoreId: vectorStore.Id, after: lastID);
        foreach (VectorStoreFile oneFile in vectorStoresFiles.Data)
        {
            Console.WriteLine(oneFile.Id);
        }
        hasMore = vectorStoresFiles.HasMore;
        lastID = vectorStoresFiles.LastId;
    }
    // Delete file from vector store
    VectorStoreFileDeletionStatus isDeleted = agentClient.DeleteVectorStoreFile(vectorStoreId: vectorStore.Id, fileId: lastID);
    Console.WriteLine(isDeleted.Deleted);
    // Delete vector store.
    VectorStoreDeletionStatus isDeleted = agentClient.DeleteVectorStore(vectorStoreId: vectorStore.Id);
    Console.WriteLine(isDeleted.Deleted);
    ```

    **Endpoint-based**
    ```C#
    // Create a vector store.
    PersistentAgentsVectorStore vectorStore = agentClient.VectorStores.CreateVectorStore(
        fileIds: new List<string> { uploadedAgentFile.Id },
        name: "my_vector_store");
    // List vector stores
    Pageable<PersistentAgentsVectorStore> vectorStores = agentClient.VectorStores.GetVectorStores();
    foreach (PersistentAgentsVectorStore oneVectorStore in vectorStores)
    {
        Console.WriteLine(oneVectorStore.Id);
    }
    // List files in the vector store.
    Pageable<VectorStoreFile> files = agentClient.VectorStores.GetVectorStoreFiles(vectorStoreId: vectorStore.Id);
    foreach (VectorStoreFile oneFile in files)
    {
        Console.WriteLine(oneFile.Id);
    }
    // Delete file from vector store
    bool isDeleted = agentClient.VectorStores.DeleteVectorStoreFile()(vectorStoreId: vector_store.id, fileId: file.id)
    Console.WriteLine(isDeleted);
    // Delete vector store.
    bool isDeleted = agentClient.VectorStores.DeleteVectorStore(vectorStoreId: vectorStore.Id);
    Console.WriteLine(isDeleted);
    ```

16. Vector store batch file search. In `Azure.AI.Agents.Persistent` the vector stores batches are managed by `VectorStores` client.

    **Hub-based**
    ```C#
    // Batch upload files
    VectorStoreFileBatch batch = agentClient.CreateVectorStoreFileBatch(
        vectorStoreId: vectorStore.Id,
        fileIds: [file.Id]
    );
    // List file in the batch
    bool hasMore = true;
    string lastID = default;
    while (hasMore)
    {
        AgentPageableListOfVectorStoreFile vectorStoresFiles = agentClient.GetVectorStoreFileBatchFiles(
            vectorStoreId: vectorStore.Id, batchId: batch.Id, after: lastID);
        foreach (VectorStoreFile oneFile in vectorStoresFiles.Data)
        {
            Console.WriteLine(oneFile.Id);
        }
        hasMore = vectorStoresFiles.HasMore;
        lastID = vectorStoresFiles.LastId;
    }
    // Try to cancel batch upload
    agentClient.CancelVectorStoreFileBatch(vectorStoreId: vectorStore.Id, batchId: batch.Id);
    ```

    **Endpoint-based**
    ```C#
    // Batch upload files
    VectorStoreFileBatch uploadTask = agentClient.VectorStores.CreateVectorStoreFileBatch(
        vectorStoreId: vectorStore.Id,
        fileIds: [file.Id]
    );
    // List file in the batch
    Pageable<VectorStoreFile> files = agentClient.VectorStores.GetVectorStoreFileBatchFiles(vectorStoreId: vectorStore.Id, batchId: uploadTask.Id);
    foreach (VectorStoreFile oneFile in files)
    {
        Console.WriteLine(oneFile.Id);
    }
    // Try to cancel batch upload
    agentClient.VectorStores.CancelVectorStoreFileBatch(vectorStoreId: vectorStore.Id, batchId: uploadTask.Id);
    ```

# Sample for use of an agent with Bing grounding in Azure.AI.Agents.Persistent in streaming scenarios.

To enable your Agent to perform search through Bing search API, you use `BingGroundingToolDefinition` along with a connection.
1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsBingGroundingStreaming_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONNECTION_ID");
PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
```

2. We will use the Bing connection ID to initialize the `BingGroundingToolDefinition`.

```C# Snippet:AgentsBingGroundingStreaming_GetConnection
BingGroundingToolDefinition bingGroundingTool = new(
    new BingGroundingSearchToolParameters(
        [new BingGroundingSearchConfiguration(connectionId)]
    )
);
```

3. We will use the `BingGroundingToolDefinition` during the agent initialization.

Synchronous sample:
```C# Snippet:AgentsBingGroundingStreaming_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = agentClient.Administration.CreateAgent(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.",
   tools: [bingGroundingTool]);
```

Asynchronous sample:
```C# Snippet:AgentsBingGroundingStreamingAsync_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.",
   tools: [ bingGroundingTool ]);
```

4. To display output we will create a helper method `ParseStreamingUpdate`. In this method we will
  - Output the text messages.
  - Replace the reference placeholders by links in Markdown format.
  - List the request URL-s used by the `BingGroundingTool`.

```C# Snippet:AgentsBingGroundingStreaming_Print
private static void ParseStreamingUpdate(StreamingUpdate streamingUpdate)
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine("--- Run started! ---");
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        if (contentUpdate.TextAnnotation is TextAnnotationUpdate uriAnnotation)
        {
            Console.Write($" [see {uriAnnotation.Title}]({uriAnnotation.Url})");
        }
        else
        {
            //Detect the reference placeholder and skip it. Instead we will print the actual reference.
            if (contentUpdate.Text[0] != (char)12304 || contentUpdate.Text[contentUpdate.Text.Length - 1] != (char)12305)
                Console.Write(contentUpdate.Text);
        }
    }
    else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
    {
        Console.WriteLine();
        Console.WriteLine("--- Run completed! ---");
    }
    else if (streamingUpdate is RunStepUpdate runStepUpdate)
    {
        if (runStepUpdate.Value.StepDetails is RunStepToolCallDetails toolCallDetails)
        {
            foreach (RunStepToolCall call in toolCallDetails.ToolCalls)
            {
                if (call is RunStepBingGroundingToolCall bingCall)
                {
                    if (bingCall.BingGrounding.TryGetValue("requesturl", out string reqURI))
                        Console.WriteLine($"Request url: {reqURI}");
                }
            }
        }
    }
    else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunFailed && streamingUpdate is RunUpdate errorStep)
    {
        throw new InvalidOperationException($"Error: {errorStep.Value.LastError}");
    }
}
```

5. Now we will create the thread, add the message, containing a question for agent and start the stream.

Synchronous sample:
```C# Snippet:AgentsBingGroundingStreaming_CreateThreadMessageAndStream
PersistentAgentThread thread = agentClient.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

// Create the stream.
CollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreaming(thread.Id, agent.Id);
foreach (StreamingUpdate streamingUpdate in stream)
{
    ParseStreamingUpdate(streamingUpdate);
}
```

Asynchronous sample:
```C# Snippet:AgentsBingGroundingStreamingAsync_CreateThreadMessageAndStream
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

// Create the stream.
AsyncCollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);
await foreach (StreamingUpdate streamingUpdate in stream)
{
    ParseStreamingUpdate(streamingUpdate);
}
```


6. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:AgentsBingGroundingStreamingCleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
agentClient.Threads.DeleteThread(threadId: thread.Id);
agentClient.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsBingGroundingStreamingCleanupAsync
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
```

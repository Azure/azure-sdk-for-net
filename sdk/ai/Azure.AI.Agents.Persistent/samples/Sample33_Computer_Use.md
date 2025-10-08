# Sample for use of an agent with Computer Use tool in Azure.AI.Agents.Persistent.

To enable your Agent to Computer Use tool, you use `ComputerUseToolDefinition` along with server configuration and tool resources.
1. First, we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:ComputerUse_CreateAgentClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var environment = System.Environment.GetEnvironmentVariable("COMPUTER_USE_ENVIRONMENT", "windows");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. We will create the `ComputerUseToolDefinition` and use it during the agent initialization.

Synchronous sample:
```C# Snippet:ComputerUse_CreateAgent_Sync
ComputerUseToolDefinition computerUse = new(
    computerUsePreview: new ComputerUseToolParameters(
        displayWidth: 1026,
        displayHeight: 769,
        environment: environment
    )
);

// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "my-agent-computer-use",
    instructions: "You are an computer automation assistant. Use the computer_use_preview tool to interact with the screen when needed.",
    tools: [computerUse]
);
```

Asynchronous sample:
```C# Snippet:ComputerUse_CreateAgent_Async
ComputerUseToolDefinition computerUse = new(
    computerUsePreview: new ComputerUseToolParameters(
        displayWidth: 1026,
        displayHeight: 769,
        environment: environment
    )
);

// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-agent-computer-use",
    instructions: "You are an computer automation assistant. Use the computer_use_preview tool to interact with the screen when needed.",
    tools: [computerUse]
);
```

3. Now we will create the thread.

Synchronous sample:
```C# Snippet:ComputerUse_CreateThread_Sync
PersistentAgentThread thread = client.Threads.CreateThread();
```

Asynchronous sample:
```C# Snippet:ComputerUse_CreateThread_Async
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
```

4. Create a helper method to encode locally stored image as Base64 string.

```C# Snippet:ComputerUse_GetEncodedImage
private static string GetEncodedImage(string name, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    string imagePath = Path.Combine(dirName, name);
    string imageBase64 = Convert.ToBase64String(File.ReadAllBytes(imagePath));
    return $"data:image/jpeg;base64,{imageBase64}";
}
```

5. Create a User message, consisting of image and text block.

Synchronous sample:
```C# Snippet:ComputerUse_CreateMessage_Sync
string messageText = "I can see a web browser with bing.com open and the cursor in the search box. Type 'movies near me' without pressing Enter or any other key. Only type 'movies near me'.";
List<MessageInputContentBlock> contentBlocks = [
    new MessageInputTextBlock(text: messageText),
    new MessageInputImageUriBlock(imageUrl: new MessageImageUriParam(uri: GetEncodedImage("cua_screenshot.jpg")))
];
PersistentThreadMessage message = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    contentBlocks: contentBlocks
);
```

Asynchronous sample:
```C# Snippet:ComputerUse_CreateMessage_Async
string messageText = "I can see a web browser with bing.com open and the cursor in the search box. Type 'movies near me' without pressing Enter or any other key. Only type 'movies near me'.";
List<MessageInputContentBlock> contentBlocks = [
    new MessageInputTextBlock(text: messageText),
    new MessageInputImageUriBlock(imageUrl: new MessageImageUriParam(uri: GetEncodedImage("cua_screenshot.jpg")))
];
PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    contentBlocks: contentBlocks
);
```

6. Create a helper method, used to prepare the `ComputerScreenshot` object if the tool output is required.

```C# Snippet:ComputerUse_ResolveOutput
private static ComputerToolOutput GetResolvedToolOutput(RequiredToolCall toolCall, string imageUri)
{
    if (toolCall is RequiredComputerUseToolCall computerUseToolCall)
    {
        Console.WriteLine($"Executing computer use action: {computerUseToolCall.ComputerUsePreview.Action.Type}");
        ComputerScreenshot screenshot = new()
        {
            ImageUrl = imageUri
        };
        if (computerUseToolCall.ComputerUsePreview.Action is TypeAction typeAction)
        {
            Console.WriteLine($"    Text to type: {typeAction.Text}");
            // (add hook to input text in managed environment API here)

            ComputerToolOutput output = new(output: screenshot);
            output.ToolCallId = toolCall.Id;
            return output;
        }
        if (computerUseToolCall.ComputerUsePreview.Action is ScreenshotAction screenshotAction)
        {
            Console.WriteLine($"    Screenshot requested");
            // (add hook to take screenshot in managed environment API here)

            ComputerToolOutput output = new(output: screenshot);
            output.ToolCallId = toolCall.Id;
            return output;
        }
    }
    return null;
}
```

7. Create the run and supply `ComputerToolOutput` objects if needed.

Synchronous sample:
```C# Snippet:ComputerUse_Run_Sync
ThreadRun run = client.Runs.CreateRun(
    thread.Id,
    agent.Id);

do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.Runs.GetRun(thread.Id, run.Id);

    if (run.Status == RunStatus.RequiresAction
        && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
    {
        Console.WriteLine("Run requires action:");
        if (submitToolOutputsAction.ToolCalls == null || !submitToolOutputsAction.ToolCalls.Any())
        {
            Console.WriteLine("No tool calls provided - cancelling run");
            client.Runs.CancelRun(threadId: run.ThreadId, runId: run.Id);
            break;
        }

        List<ComputerToolOutput> toolOutputs = [];
        foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
        {
            ComputerToolOutput toolOutput = GetResolvedToolOutput(toolCall: toolCall, imageUri: GetEncodedImage("cua_screenshot_next.jpg"));
            if (toolOutput != null)
            {
                toolOutputs.Add(toolOutput);
                Console.WriteLine($"Tool outputs: {toolOutput}");
            }
        }
        run = client.Runs.SubmitToolOutputsToRun(run, toolOutputs: toolOutputs, toolApprovals: null);
    }
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:ComputerUse_Run_Async
ThreadRun run = await client.Runs.CreateRunAsync(
    thread.Id,
    agent.Id);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);

    if (run.Status == RunStatus.RequiresAction
        && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
    {
        Console.WriteLine("Run requires action:");
        if (submitToolOutputsAction.ToolCalls == null || !submitToolOutputsAction.ToolCalls.Any())
        {
            Console.WriteLine("No tool calls provided - cancelling run");
            await client.Runs.CancelRunAsync(threadId: run.ThreadId, runId: run.Id);
            break;
        }

        List<ComputerToolOutput> toolOutputs = [];
        foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
        {
            ComputerToolOutput toolOutput = GetResolvedToolOutput(toolCall: toolCall, imageUri: GetEncodedImage("cua_screenshot_next.jpg"));
            if (toolOutput != null)
            {
                toolOutputs.Add(toolOutput);
                Console.WriteLine($"Tool outputs: {toolOutput}");
            }
        }
        run = await client.Runs.SubmitToolOutputsToRunAsync(run, toolOutputs: toolOutputs, toolApprovals: null);
    }
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

8. To print out the messages from the agent create the method `ListMessages`.

```C# Snippet:ComputerUse_ListMessages
private static void ListMessages(IEnumerable<PersistentThreadMessage> messages)
{
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
}
```

9. Use the created method to print out the messages.

Synchronous sample:
```C# Snippet:ComputerUse_ListMessages_Sync
IEnumerable<PersistentThreadMessage> messages = [.. client.Messages.GetMessages(threadId: thread.Id, order: ListSortOrder.Ascending)];
ListMessages(messages);
```

Asynchronous sample:
```C# Snippet:ComputerUse_ListMessages_Async
IEnumerable<PersistentThreadMessage> messages = await client.Messages.GetMessagesAsync(threadId: thread.Id, order: ListSortOrder.Ascending).ToListAsync();
ListMessages(messages);
```

10. We will create the helper method `ListRunSteps` to list the tool calls.

```C# Snippet:ComputerUse_ListRunSteps
private static void ListRunSteps(IEnumerable<RunStep> steps)
{
    foreach (RunStep step in steps)
    {
        Console.WriteLine($"Step {step.Id} status: {step.Status}");
        Console.WriteLine(step.ToString());
        if (step.StepDetails is RunStepToolCallDetails toolCallDetails)
        {
            Console.WriteLine("    Tool calls:");
            foreach (RunStepToolCall call in toolCallDetails.ToolCalls)
            {
                Console.WriteLine($"    Tool call ID: {call.Id}");
                Console.WriteLine($"    Tool call type: {call.Type}");
                if (call is RunStepComputerUseToolCall computerCall)
                {
                    Console.WriteLine($"    Computer use action type: {computerCall.ComputerUsePreview.Action.Type}");
                }
            }
        }
    }
}
```

11. Print the steps.

Synchronous sample:
```C# Snippet:ComputerUse_ListSteps_Sync
IEnumerable<RunStep> steps = [.. client.Runs.GetRunSteps(threadId: run.ThreadId, runId: run.Id)];
ListRunSteps(steps);
```

Asynchronous sample:
```C# Snippet:ComputerUse_ListSteps_Async
IEnumerable < RunStep> steps = await client.Runs.GetRunStepsAsync(threadId: run.ThreadId, runId: run.Id).ToListAsync();
ListRunSteps(steps);
```

12. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:ComputerUse_Cleanup_Sync
// NOTE: Comment out these two lines if you plan to reuse the agent later.
client.Threads.DeleteThread(threadId: thread.Id);
client.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:ComputerUse_Cleanup_Async
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await client.Threads.DeleteThreadAsync(threadId: thread.Id);
await client.Administration.DeleteAgentAsync(agentId: agent.Id);
```

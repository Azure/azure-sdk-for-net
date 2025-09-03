# Sample for use of an agent with DeepResearch model in Azure.AI.Agents.Persistent.

To use the deep research with the agent we need to deploy the model, supporting it, for example, `o3-deep-research`.
1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:DeepResearch_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var deepResearchModelDeploymentName = System.Environment.GetEnvironmentVariable("DEEP_RESEARCH_MODEL_DEPLOYMENT_NAME");
var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONECTION_ID");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. `DeepResearchToolDefinition` should be initialized with the name of deep research model and the Bing connection ID, needed to perform the search in the internet.

```C# Snippet:DeepResearch_CreateTools
DeepResearchToolDefinition deepResearch = new(
    new DeepResearchDetails(
        model: deepResearchModelDeploymentName,
        bingGroundingConnections: [
            new DeepResearchBingGroundingConnection(connectionId)
        ]
    )
);
```

3. Create an agent.

Synchronous sample:
```C# Snippet:DeepResearchSync_CreateAgent
// NOTE: To reuse existing agent, fetch it with get_agent(agent_id)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "Science Tutor",
    instructions: "You are a helpful Agent that assists in researching scientific topics.",
    tools: [deepResearch]
);
```

Asynchronous sample:
```C# Snippet:DeepResearch_CreateAgent
// NOTE: To reuse existing agent, fetch it with get_agent(agent_id)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Science Tutor",
    instructions: "You are a helpful Agent that assists in researching scientific topics.",
    tools: [deepResearch]
);
```

4. Create a thread and run and wait for the run to complete.

Synchronous sample:
```C# Snippet:DeepResearchSync_CreateThreadAndRun
PersistentAgentThreadCreationOptions threadOp = new();
threadOp.Messages.Add(new ThreadMessageOptions(
        role: MessageRole.User,
        content: "Research the current state of studies on orca intelligence and orca language, " +
        "including what is currently known about orcas' cognitive capabilities, " +
        "communication systems and problem-solving reflected in recent publications in top thier scientific " +
        "journals like Science, Nature and PNAS."
    ));
ThreadAndRunOptions opts = new()
{
    ThreadOptions = threadOp,
};
ThreadRun run = client.CreateThreadAndRun(
    assistantId: agent.Id,
    options: opts
);

Console.WriteLine("Start processing the message... this may take a few minutes to finish. Be patient!");
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.Runs.GetRun(run.ThreadId, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:DeepResearch_CreateThreadAndRun
PersistentAgentThreadCreationOptions threadOp = new();
threadOp.Messages.Add(new ThreadMessageOptions(
        role: MessageRole.User,
        content: "Research the current state of studies on orca intelligence and orca language, " +
        "including what is currently known about orcas' cognitive capabilities, " +
        "communication systems and problem-solving reflected in recent publications in top thier scientific " +
        "journals like Science, Nature and PNAS."
    ));
ThreadAndRunOptions opts = new()
{
    ThreadOptions = threadOp,
};
ThreadRun run = await client.CreateThreadAndRunAsync(
    assistantId: agent.Id,
    options: opts
);

Console.WriteLine("Start processing the message... this may take a few minutes to finish. Be patient!");
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(run.ThreadId, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

5. We will create a helper function `PrintMessagesAndSaveSummary`, which prints the response from the agent, and replaces the reference placeholders by links in Markdown format. It also saves the research summary in the file for convenience.

```C# Snippet:DeepResearch_PrintMessages
private static void PrintMessagesAndSaveSummary(IEnumerable<PersistentThreadMessage> messages, string summaryFilePath)
{
    string lastAgentMessage = default;
    foreach (PersistentThreadMessage threadMessage in messages)
    {
        StringBuilder sbAgentMessage = new();
        Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
        foreach (MessageContent contentItem in threadMessage.ContentItems)
        {
            if (contentItem is MessageTextContent textItem)
            {
                string response = textItem.Text;
                if (textItem.Annotations != null)
                {
                    foreach (MessageTextAnnotation annotation in textItem.Annotations)
                    {
                        if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                        {
                            response = response.Replace(uriAnnotation.Text, $" [{uriAnnotation.UriCitation.Title}]({uriAnnotation.UriCitation.Uri})");
                        }
                    }
                }
                if (threadMessage.Role == MessageRole.Agent)
                    sbAgentMessage.Append(response);
                Console.Write($"Agent response: {response}");
            }
            else if (contentItem is MessageImageFileContent imageFileItem)
            {
                Console.Write($"<image from ID: {imageFileItem.FileId}");
            }
            Console.WriteLine();
        }
        if (threadMessage.Role == MessageRole.Agent)
            lastAgentMessage = sbAgentMessage.ToString();
    }
    if (!string.IsNullOrEmpty(lastAgentMessage))
    {
        File.WriteAllText(
            path: summaryFilePath,
            contents: lastAgentMessage);
    }
}
```

6. List the messages, print them and save the result in `research_summary.md` file. Please note, that the file will be saved next to the comiled executable.

Synchronous sample:
```C# Snippet:DeepResearchSync_ListMessages
Pageable<PersistentThreadMessage> messages
    = client.Messages.GetMessages(
        threadId: run.ThreadId, order: ListSortOrder.Ascending);
PrintMessagesAndSaveSummary([..messages], "research_summary.md");
```

Asynchronous sample:
```C# Snippet:DeepResearch_ListMessages
AsyncPageable<PersistentThreadMessage> messages
    = client.Messages.GetMessagesAsync(
        threadId: run.ThreadId, order: ListSortOrder.Ascending);

PrintMessagesAndSaveSummary(await messages.ToListAsync(), "research_summary.md");
```

6. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:DeepResearchSync_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
client.Threads.DeleteThread(threadId: run.ThreadId);
client.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:DeepResearch_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await client.Threads.DeleteThreadAsync(threadId: run.ThreadId);
await client.Administration.DeleteAgentAsync(agentId: agent.Id);
```

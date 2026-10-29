# Sample 2: Tasks and artifacts

Use the native `TaskUpdater` to submit a Task, add an artifact, and complete it.

## Implement the handler

Use the Agent Card from [getting started](Sample1_GettingStarted.md) and
implement a task-producing handler:

```C# Snippet:A2A_TaskAgent
public class TaskAgent : IAgentHandler
{
    public async Task ExecuteAsync(
        global::A2A.RequestContext context,
        AgentEventQueue eventQueue,
        CancellationToken cancellationToken)
    {
        var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
        await task.SubmitAsync(cancellationToken: cancellationToken);
        await task.AddArtifactAsync(
            [Part.FromText($"Echo: {context.UserText}")],
            cancellationToken: cancellationToken);
        await task.CompleteAsync(cancellationToken: cancellationToken);
    }
}
```

## Start the server

```C# Snippet:A2A_TaskServer
A2AAgentServer.Run<TaskAgent>(CreateCard());
```

Send the same `SendMessage` request shown in the getting-started sample. The
response contains `result.task` instead of `result.message`; its status is
`TASK_STATE_COMPLETED`, and its artifact contains the Echo text.

## Retrieve the Task

Keep the returned task ID and use it in a native `GetTask` request:

```powershell
$taskId = $response.result.task.id
$getTask = @{
    jsonrpc = "2.0"
    id = "lookup-1"
    method = "GetTask"
    params = @{ id = $taskId }
} | ConvertTo-Json

$stored = Invoke-RestMethod -Uri "http://localhost:8088/a2a" `
    -Method Post -ContentType "application/json" -Body $getTask
$stored.result.status.state
$stored.result.artifacts[0].parts[0].text
```

Expected output is `TASK_STATE_COMPLETED` and the original Echo text. Send
`GetTask` through the same caller scope used to create the Task.

## Storage lifetime

`TaskUpdater` emits task events; the configured native `ITaskStore` owns their
snapshots. The default local store is in-memory and loses Tasks when the process
stops. Hosted handler registration selects `FoundryTaskStore` unless an explicit
native store is registered. An existing request handler keeps its own storage.

Persisting snapshots does not restart interrupted execution or restore live
subscriptions. See [task storage](../README.md#task-storage) for configuration
and caller-isolation requirements.

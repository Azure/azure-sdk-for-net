# Sample 3: Multi-turn

Ask for missing input, then continue the same native Task with the user's answer.

## Implement the handler

Use the package setup and `CreateCard` function from
[getting started](Sample1_GettingStarted.md).
The first request submits a Task and moves it to `TASK_STATE_INPUT_REQUIRED`.
The next request addresses that Task and supplies the name to greet.

```C# Snippet:A2A_Sample3_Handler
public class ClarificationAgent : IAgentHandler
{
    public async Task ExecuteAsync(
        global::A2A.RequestContext context,
        AgentEventQueue eventQueue,
        CancellationToken cancellationToken)
    {
        var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
        if (context.Task is null)
        {
            await task.SubmitAsync(cancellationToken: cancellationToken);
            await task.RequireInputAsync(new Message
            {
                MessageId = Guid.NewGuid().ToString("N"),
                Role = Role.Agent,
                Parts = [Part.FromText("Who should I greet?")],
            }, cancellationToken: cancellationToken);
            return;
        }

        if (string.IsNullOrWhiteSpace(context.UserText))
        {
            throw new A2AException("Provide a name as text.", A2AErrorCode.InvalidParams);
        }

        await task.StartWorkAsync(cancellationToken: cancellationToken);
        await task.AddArtifactAsync(
            [Part.FromText($"Hello, {context.UserText}!")],
            cancellationToken: cancellationToken);
        await task.CompleteAsync(cancellationToken: cancellationToken);
    }
}
```

## Start the server

```C# Snippet:A2A_Sample3_Start
A2AAgentServer.Run<ClarificationAgent>(CreateCard());
```

## Send both turns

Use PowerShell to send JSON-RPC requests and reject protocol errors, including
those transported with HTTP 200:

```powershell
function Send-A2A($parameters) {
    $body = @{
        jsonrpc = "2.0"
        id = [guid]::NewGuid().ToString("N")
        method = "SendMessage"
        params = $parameters
    } | ConvertTo-Json -Depth 10
    $response = Invoke-RestMethod -Uri "http://localhost:8088/a2a" `
        -Method Post -ContentType "application/json" -Body $body
    if ($response.error) { throw ($response.error | ConvertTo-Json) }
    return $response.result.task
}

$first = Send-A2A @{
    message = @{
        messageId = "turn-1"
        role = "ROLE_USER"
        parts = @(@{ text = "Prepare a greeting" })
    }
}
$first.status.state
$first.status.message.parts[0].text

$second = Send-A2A @{
    message = @{
        messageId = "turn-2"
        role = "ROLE_USER"
        taskId = $first.id
        contextId = $first.contextId
        parts = @(@{ text = "Ada" })
    }
}
$second.status.state
$second.artifacts[0].parts[0].text
```

The first turn returns `TASK_STATE_INPUT_REQUIRED` and `Who should I greet?`.
The second returns `TASK_STATE_COMPLETED` and `Hello, Ada!`, with the same task
and context IDs.

`taskId` identifies the Task being continued. Reusing only `contextId` can start
another Task in the same context; it does not select an existing Task.
Use unique message IDs and do not try to continue an already completed Task.
The default local store retains these snapshots only for the life of the process.

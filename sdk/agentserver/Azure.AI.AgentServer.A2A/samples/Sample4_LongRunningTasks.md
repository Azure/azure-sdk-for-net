# Sample 4: Long-running tasks

Return a Task before application work finishes, then poll for its result.

## Define the application work

Use `CreateCard` from [getting started](Sample1_GettingStarted.md).
This service simulates a slow report generator without requiring an external
service or a model deployment:

```C# Snippet:A2A_Sample4_Work
public interface IReportWriter
{
    Task<string> WriteAsync(string input, CancellationToken cancellationToken);
}

public class ReportWriter : IReportWriter
{
    public async Task<string> WriteAsync(string input, CancellationToken cancellationToken)
    {
        // Stand in for a slow application service.
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        return $"Report: {input}";
    }
}
```

## Implement the handler

The native handler emits submitted and working states before awaiting the
application service:

```C# Snippet:A2A_Sample4_Handler
public class ReportAgent(IReportWriter writer) : IAgentHandler
{
    public async Task ExecuteAsync(
        global::A2A.RequestContext context,
        AgentEventQueue eventQueue,
        CancellationToken cancellationToken)
    {
        var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
        await task.SubmitAsync(cancellationToken: cancellationToken);
        await task.StartWorkAsync(cancellationToken: cancellationToken);
        string report = await writer.WriteAsync(context.UserText ?? string.Empty, cancellationToken);
        await task.AddArtifactAsync([Part.FromText(report)], cancellationToken: cancellationToken);
        await task.CompleteAsync(cancellationToken: cancellationToken);
    }
}
```

## Register and start

Use `Microsoft.Extensions.DependencyInjection` to register the service:

```C# Snippet:A2A_Sample4_Start
var builder = AgentHost.CreateBuilder();
builder.Services.AddSingleton<IReportWriter, ReportWriter>();
builder.AddA2A<ReportAgent>(CreateCard());
builder.Build().Run();
```

## Return immediately and poll

The native request's `configuration.returnImmediately` selects detached
execution. This is different from the HTTP client abandoning a normal request.

```powershell
function Invoke-A2ARpc($method, $parameters) {
    $body = @{
        jsonrpc = "2.0"
        id = [guid]::NewGuid().ToString("N")
        method = $method
        params = $parameters
    } | ConvertTo-Json -Depth 10
    $response = Invoke-RestMethod -Uri "http://localhost:8088/a2a" `
        -Method Post -ContentType "application/json" -Body $body
    if ($response.error) { throw ($response.error | ConvertTo-Json) }
    return $response.result
}

$initial = Invoke-A2ARpc "SendMessage" @{
    configuration = @{ returnImmediately = $true }
    message = @{
        messageId = "report-1"
        role = "ROLE_USER"
        parts = @(@{ text = "quarterly results" })
    }
}
$taskId = $initial.task.id
$deadline = [DateTime]::UtcNow.AddSeconds(30)
do {
    $task = Invoke-A2ARpc "GetTask" @{ id = $taskId }
    $state = $task.status.state
    if ($state -eq "TASK_STATE_COMPLETED") { break }
    if ($state -notin @("TASK_STATE_SUBMITTED", "TASK_STATE_WORKING")) {
        throw "Unexpected Task state: $state"
    }
    if ([DateTime]::UtcNow -ge $deadline) { throw "Timed out waiting for the report." }
    Start-Sleep -Milliseconds 250
} while ($true)
$task.artifacts[0].parts[0].text
```

Expected output: `Report: quarterly results`. The first response can contain
submitted, working, or completed state depending on how quickly the work runs.

This sample runs work in the server process. The application service must honor
its cancellation token. Process termination interrupts execution; configuring
persistent Task snapshots does not make the report generator restartable.

# Sample 2: Long-Running Operations — Document Analysis Agent

This sample builds a document analysis agent using the **LRO (Long-Running Operation)** pattern. The agent accepts a document URL, returns `202 Accepted` immediately, and the caller polls `GET /invocations/{id}` until the analysis completes. This pattern is ideal for operations that take seconds to minutes.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Implement the handler

Override `HandleAsync` to accept the job and `GetAsync` to report status. Optionally override `CancelAsync` to support cancellation.

```C# Snippet:Invocations_Sample2_DocumentAnalysisHandler
public class DocumentAnalysisHandler : InvocationHandler
{
    // Handlers are scoped (new instance per request), so state must live
    // outside the handler. Use a static store here for simplicity; in
    // production, use a database or distributed cache.
    private static readonly ConcurrentDictionary<string, JobState> s_jobs = new();

    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var input = await request.ReadFromJsonAsync<AnalysisInput>(cancellationToken);

        // Store the job and kick off background work.
        var job = new JobState(context.InvocationId, input?.DocumentUrl ?? "", Status: "running");
        s_jobs[context.InvocationId] = job;

        _ = Task.Run(() => AnalyzeInBackground(context.InvocationId), CancellationToken.None);

        // Return 202 Accepted — the caller should poll GET /invocations/{id}.
        response.StatusCode = 202;
        response.Headers["Retry-After"] = "2";
        await response.WriteAsJsonAsync(new
        {
            invocation_id = context.InvocationId,
            status = "running"
        }, cancellationToken);
    }

    public override async Task GetAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        if (!s_jobs.TryGetValue(invocationId, out var job))
        {
            response.StatusCode = 404;
            return;
        }

        if (job.Status == "running")
        {
            response.Headers["Retry-After"] = "2";
        }

        await response.WriteAsJsonAsync(new
        {
            invocation_id = invocationId,
            status = job.Status,
            result = job.Result
        }, cancellationToken);
    }

    public override Task CancelAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        if (s_jobs.TryGetValue(invocationId, out var job))
        {
            s_jobs[invocationId] = job with { Status = "cancelled" };
            response.StatusCode = 200;
        }
        else
        {
            response.StatusCode = 404;
        }

        return Task.CompletedTask;
    }

    private static async Task AnalyzeInBackground(string invocationId)
    {
        // Simulate analysis work.
        await Task.Delay(TimeSpan.FromSeconds(5));

        if (s_jobs.TryGetValue(invocationId, out var job) && job.Status == "running")
        {
            s_jobs[invocationId] = job with
            {
                Status = "completed",
                Result = $"Analysis of {job.DocumentUrl}: 3 pages, 2 tables, 1 chart detected."
            };
        }
    }
}

public record AnalysisInput(string DocumentUrl);
public record JobState(string InvocationId, string DocumentUrl, string Status, string? Result = null);
```

## Start the server

```C# Snippet:Invocations_Sample2_StartServer
InvocationsServer.Run<DocumentAnalysisHandler>();
```

## Test the endpoint

### Step 1 — Submit the document

```bash
curl -X POST http://localhost:8088/invocations \
  -H "Content-Type: application/json" \
  -d '{"documentUrl":"https://example.com/report.pdf"}'
```

Response (`202 Accepted`):

```json
{ "invocation_id": "inv-123", "status": "running" }
```

### Step 2 — Poll for results

```bash
curl http://localhost:8088/invocations/inv-123
```

While running: `{ "status": "running" }` with `Retry-After: 2`.
When complete: `{ "status": "completed", "result": "Analysis of ... 3 pages, 2 tables, 1 chart detected." }`.

### Step 3 — Cancel (optional)

```bash
curl -X POST http://localhost:8088/invocations/inv-123/cancel
```

## Implementation pattern

This is the **LRO** pattern from the Invocations protocol:

```
1. POST /invocations          → 202 { "status": "running" }
2. GET  /invocations/{id}     → 200 { "status": "running" }     Retry-After: 2
3. GET  /invocations/{id}     → 200 { "status": "completed", "result": {...} }
```

Use this when your agent's work takes more than a few seconds — document processing, batch analysis, model training, etc.

// Document Analysis Agent — Demonstrates the long-running operations (LRO) pattern
// with the Invocations protocol. Submit a document for analysis, poll for progress,
// and retrieve results when the analysis is complete.

using System.Collections.Concurrent;
using System.Text.Json;
using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;

var handler = new DocumentAnalysisHandler();
var builder = AgentHost.CreateBuilder(args);
builder.AddInvocations(handler);
builder.Build().Run();

public class DocumentAnalysisHandler : InvocationHandler
{
    private readonly ConcurrentDictionary<string, JobState> _jobs = new();

    // POST /invocations — accept a document and start background analysis
    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var body = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
        var invocationId = Guid.NewGuid().ToString();

        _jobs[invocationId] = new JobState
        {
            Status = "running",
            Input = body,
            StartedAt = DateTime.UtcNow
        };

        // Simulate background work completing after 3 seconds
        _ = Task.Run(async () =>
        {
            await Task.Delay(3000, CancellationToken.None);
            if (_jobs.TryGetValue(invocationId, out var job) && job.Status == "running")
            {
                job.Status = "completed";
                job.Result = $"Analysis complete: '{body}' contains {body.Split(' ').Length} words";
            }
        });

        response.StatusCode = 202;
        response.Headers["Location"] = $"/invocations/{invocationId}";
        await response.WriteAsync(
            JsonSerializer.Serialize(new { invocationId, status = "running" }),
            cancellationToken);
    }

    // GET /invocations/{invocationId} — poll for status
    public override async Task GetAsync(
        string invocationId, HttpRequest request, HttpResponse response,
        CancellationToken cancellationToken)
    {
        if (!_jobs.TryGetValue(invocationId, out var job))
        {
            response.StatusCode = 404;
            return;
        }

        if (job.Status == "running")
        {
            response.StatusCode = 202;
            await response.WriteAsync(
                JsonSerializer.Serialize(new { invocationId, status = "running" }),
                cancellationToken);
            return;
        }

        response.StatusCode = 200;
        response.ContentType = "application/json";
        await response.WriteAsync(
            JsonSerializer.Serialize(new { invocationId, status = job.Status, result = job.Result }),
            cancellationToken);
    }

    // POST /invocations/{invocationId}/cancel — cancel a running analysis
    public override async Task CancelAsync(
        string invocationId, HttpRequest request, HttpResponse response,
        CancellationToken cancellationToken)
    {
        if (_jobs.TryGetValue(invocationId, out var job))
        {
            job.Status = "cancelled";
            response.StatusCode = 200;
            await response.WriteAsync(
                JsonSerializer.Serialize(new { invocationId, status = "cancelled" }),
                cancellationToken);
        }
        else
        {
            response.StatusCode = 404;
        }
    }

    private class JobState
    {
        public string Status { get; set; } = "pending";
        public string Input { get; set; } = "";
        public string? Result { get; set; }
        public DateTime StartedAt { get; set; }
    }
}

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Responses.Tests.Cache;

public class ResponseExecutionTrackerTests : IDisposable
{
    private readonly ResponseExecutionTracker _tracker;

    public ResponseExecutionTrackerTests()
    {
        _tracker = new ResponseExecutionTracker(NullLogger<ResponseExecutionTracker>.Instance);
    }

    [Test]
    public void Create_AddsExecution_TryGetReturnsIt()
    {
        var execution = _tracker.Create("resp_001");

        Assert.IsTrue(_tracker.TryGet("resp_001", out var found));
        Assert.AreSame(execution, found);
    }

    [Test]
    public void TryGet_UnknownId_ReturnsFalse()
    {
        Assert.IsFalse(_tracker.TryGet("resp_missing", out _));
    }

    [Test]
    public void Create_DuplicateId_Throws()
    {
        _tracker.Create("resp_dup");

        Assert.Throws<InvalidOperationException>(
            () => _tracker.Create("resp_dup"));
    }

    [Test]
    public void MarkCompleted_SetsCompletedAt()
    {
        _tracker.Create("resp_002");
        _tracker.MarkCompleted("resp_002");

        _tracker.TryGet("resp_002", out var execution);
        Assert.IsNotNull(execution!.CompletedAt);
    }

    [Test]
    public async Task StopAsync_CancelsInFlightExecutions()
    {
        await _tracker.StartAsync(CancellationToken.None);

        var execution = _tracker.Create("resp_stop");

        // Verify token is not cancelled yet
        Assert.IsFalse(execution.CancellationTokenSource.Token.IsCancellationRequested);

        await _tracker.StopAsync(CancellationToken.None);

        // After stop, in-flight should be cancelled
        Assert.IsTrue(execution.CancellationTokenSource.Token.IsCancellationRequested);
    }

    [Test]
    public async Task StopAsync_SetsShutdownRequested_OnInFlightExecutions()
    {
        await _tracker.StartAsync(CancellationToken.None);

        var execution = _tracker.Create("resp_shutdown");
        var context = new ResponseContext("resp_shutdown");
        execution.Context = context;

        Assert.IsFalse(execution.ShutdownRequested);
        Assert.IsFalse(context.IsShutdownRequested);

        await _tracker.StopAsync(CancellationToken.None);

        Assert.IsTrue(execution.ShutdownRequested);
        Assert.IsTrue(context.IsShutdownRequested);
    }

    public void Dispose()
    {
        _tracker.Dispose();
    }
}

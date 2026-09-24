// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Core;
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
        var execution = _tracker.Create("resp_001", PlatformContext.Empty);

        Assert.That(_tracker.TryGet("resp_001", PlatformContext.Empty, out var found), Is.True);
        Assert.That(found, Is.SameAs(execution));
    }

    [Test]
    public void TryGet_UnknownId_ReturnsFalse()
    {
        Assert.That(_tracker.TryGet("resp_missing", PlatformContext.Empty, out _), Is.False);
    }

    [Test]
    public void Create_DuplicateId_Throws()
    {
        _tracker.Create("resp_dup", PlatformContext.Empty);

        Assert.Throws<InvalidOperationException>(
            () => _tracker.Create("resp_dup", PlatformContext.Empty));
    }

    [Test]
    public void TryEvict_RemovesExecution_TryGetReturnsFalse()
    {
        _tracker.Create("resp_002", PlatformContext.Empty);
        var evicted = _tracker.TryEvict("resp_002", PlatformContext.Empty);

        Assert.That(evicted, Is.True);
        Assert.That(_tracker.TryGet("resp_002", PlatformContext.Empty, out _), Is.False);
    }

    [Test]
    public void TryEvict_UnknownId_ReturnsFalse()
    {
        Assert.That(_tracker.TryEvict("resp_missing", PlatformContext.Empty), Is.False);
    }

    [Test]
    public async Task StopAsync_CancelsInFlightExecutions()
    {
        await _tracker.StartAsync(CancellationToken.None);

        var execution = _tracker.Create("resp_stop", PlatformContext.Empty);

        // Verify token is not cancelled yet
        Assert.That(execution.CancellationTokenSource.Token.IsCancellationRequested, Is.False);

        await _tracker.StopAsync(CancellationToken.None);

        // After stop, in-flight should be cancelled
        Assert.That(execution.CancellationTokenSource.Token.IsCancellationRequested, Is.True);
    }

    [Test]
    public async Task StopAsync_SetsShutdownRequested_OnInFlightExecutions()
    {
        await _tracker.StartAsync(CancellationToken.None);

        var execution = _tracker.Create("resp_shutdown", PlatformContext.Empty);
        var context = new ResponseContext("resp_shutdown");
        execution.Context = context;

        Assert.That(execution.ShutdownRequested, Is.False);
        Assert.That(context.IsShutdownRequested, Is.False);

        await _tracker.StopAsync(CancellationToken.None);

        Assert.That(execution.ShutdownRequested, Is.True);
        Assert.That(context.IsShutdownRequested, Is.True);
    }

    [Test]
    public void SameResponseId_IsIndependentAcrossUserPartitions()
    {
        var firstContext = new PlatformContext("user-a", null);
        var secondContext = new PlatformContext("user-b", null);

        var first = _tracker.Create("resp_shared", firstContext);
        var second = _tracker.Create("resp_shared", secondContext);

        Assert.That(_tracker.TryGet("resp_shared", firstContext, out var foundFirst), Is.True);
        Assert.That(_tracker.TryGet("resp_shared", secondContext, out var foundSecond), Is.True);
        Assert.That(foundFirst, Is.SameAs(first));
        Assert.That(foundSecond, Is.SameAs(second));
    }

    public void Dispose()
    {
        _tracker.Dispose();
    }
}

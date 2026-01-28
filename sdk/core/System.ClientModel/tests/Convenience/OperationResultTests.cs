// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

/// <summary>
/// Unit tests for operation results.
/// </summary>
public class OperationResultTests : SyncAsyncTestBase
{
    public OperationResultTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanWaitForCompletion()
    {
        int updateCount = 0;
        int completeAfterCount = 2;
        MockPipelineResponse initialResponse = new(200);

        MockOperationResult operation = new(initialResponse, completeAfterCount);
        operation.OnUpdate = () => updateCount++;

        if (IsAsync)
        {
            await operation.WaitForCompletionAsync();
        }
        else
        {
            operation.WaitForCompletion();
        }

        Assert.That(completeAfterCount, Is.EqualTo(updateCount));
        Assert.That(operation.HasCompleted, Is.True);
        Assert.That(initialResponse, Is.Not.EqualTo(operation.GetRawResponse()));
    }

    [Test]
    public async Task CanPollWithCustomInterval()
    {
        int updateCount = 0;
        int completeAfterCount = 2;
        MockPipelineResponse initialResponse = new(200);

        MockOperationResult operation = new(initialResponse, completeAfterCount);
        operation.OnUpdate = () => updateCount++;

        while (!operation.HasCompleted)
        {
            PipelineResponse priorResponse = operation.GetRawResponse();

            ClientResult result = IsAsync ?
               await operation.UpdateStatusAsync() :
               operation.UpdateStatus();

            // Custom interval: no wait.

            Assert.That(priorResponse, Is.Not.EqualTo(operation.GetRawResponse()));
        }

        Assert.That(completeAfterCount, Is.EqualTo(updateCount));
        Assert.That(operation.HasCompleted, Is.True);
    }

    [Test]
    public void CanCancelWaitForCompletion()
    {
        int updateCount = 0;
        int completeAfterCount = 2;
        MockPipelineResponse initialResponse = new(200);

        MockOperationResult operation = new(initialResponse, completeAfterCount);
        operation.OnUpdate = () => updateCount++;

        using CancellationTokenSource source = new CancellationTokenSource();

        // Default OperationResult polling interval is 1s.  This will cancel
        // before first call to UpdateStatus.
        source.CancelAfter(100);

        if (IsAsync)
        {
            Assert.That(async () => await operation.WaitForCompletionAsync(source.Token),
                Throws.InstanceOf<OperationCanceledException>());
        }
        else
        {
            Assert.That(() => operation.WaitForCompletion(source.Token),
                Throws.InstanceOf<OperationCanceledException>());
        }

        Assert.That(source.IsCancellationRequested, Is.True);

        Assert.That(updateCount, Is.EqualTo(0));
        Assert.That(operation.HasCompleted, Is.False);
    }

    [Test]
    public async Task WaitForCompletionResponseRetryAfterHeader()
    {
        int updateCount = 0;
        int completeAfterCount = 2;
        int retryAfterSeconds = 2;
        int defaultWaitSeconds = 1;

        static PipelineResponse GetResponse(int retryAfterSeconds)
        {
            MockPipelineResponse response = new(200);
            response.SetHeader("Retry-After", retryAfterSeconds.ToString());
            return response;
        }

        MockOperationResult operation = new(GetResponse(retryAfterSeconds), completeAfterCount);
        operation.OnUpdate = () => updateCount++;
        operation.GetNextResponse = () => GetResponse(retryAfterSeconds);

        Stopwatch stopwatch = Stopwatch.StartNew();

        if (IsAsync)
        {
            await operation.WaitForCompletionAsync();
        }
        else
        {
            operation.WaitForCompletion();
        }

        stopwatch.Stop();

        Assert.That(completeAfterCount, Is.EqualTo(updateCount));
        Assert.That(operation.HasCompleted, Is.True);

        Assert.That(stopwatch.Elapsed, Is.GreaterThan(TimeSpan.FromSeconds(completeAfterCount * defaultWaitSeconds)));
    }
}

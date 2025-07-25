// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A test-aware base class for OperationResult that supports different polling strategies
/// based on the test mode (Live, Record, Playback).
/// </summary>
public abstract class TestAwareOperationResult : OperationResult
{
    private readonly IPollingStrategy _pollingStrategy;

    /// <summary>
    /// Initializes a new instance of TestAwareOperationResult.
    /// </summary>
    /// <param name="response">The response from the service.</param>
    /// <param name="testMode">The current test mode.</param>
    protected TestAwareOperationResult(PipelineResponse response, RecordedTestMode testMode) 
        : base(response)
    {
        // Use zero polling strategy only in playback mode for fast test execution
        _pollingStrategy = testMode == RecordedTestMode.Playback 
            ? ZeroPollingStrategy.Instance 
            : DefaultPollingStrategy.Instance;
    }

    /// <summary>
    /// Initializes a new instance of TestAwareOperationResult with a custom polling strategy.
    /// </summary>
    /// <param name="response">The response from the service.</param>
    /// <param name="pollingStrategy">The polling strategy to use.</param>
    protected TestAwareOperationResult(PipelineResponse response, IPollingStrategy pollingStrategy) 
        : base(response)
    {
        _pollingStrategy = pollingStrategy;
    }

    /// <summary>
    /// Waits for the operation to complete processing on the service using the configured polling strategy.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous wait operation.</returns>
    public override async ValueTask WaitForCompletionAsync(CancellationToken cancellationToken = default)
    {
        while (!HasCompleted)
        {
            PipelineResponse response = GetRawResponse();

            await _pollingStrategy.WaitAsync(response, cancellationToken).ConfigureAwait(false);

            RequestOptions? options = RequestOptions.FromCancellationToken(cancellationToken);
            ClientResult result = await UpdateStatusAsync(options).ConfigureAwait(false);

            SetRawResponse(result.GetRawResponse());
        }
    }

    /// <summary>
    /// Waits for the operation to complete processing on the service using the configured polling strategy.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    public override void WaitForCompletion(CancellationToken cancellationToken = default)
    {
        while (!HasCompleted)
        {
            PipelineResponse response = GetRawResponse();

            _pollingStrategy.Wait(response, cancellationToken);

            RequestOptions? options = RequestOptions.FromCancellationToken(cancellationToken);
            ClientResult result = UpdateStatus(options);

            SetRawResponse(result.GetRawResponse());
        }
    }
}

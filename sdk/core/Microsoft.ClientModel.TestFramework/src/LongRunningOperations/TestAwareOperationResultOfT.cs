// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// A test-aware base class for typed OperationResult that supports different polling strategies
/// based on the test mode (Live, Record, Playback).
/// </summary>
/// <typeparam name="T">The type of the operation result value.</typeparam>
public abstract class TestAwareOperationResult<T> : TestAwareOperationResult
{
    /// <summary>
    /// Initializes a new instance of TestAwareOperationResult{T}.
    /// </summary>
    /// <param name="response">The response from the service.</param>
    /// <param name="testMode">The current test mode.</param>
    protected TestAwareOperationResult(PipelineResponse response, RecordedTestMode testMode) 
        : base(response, testMode)
    {
    }

    /// <summary>
    /// Initializes a new instance of TestAwareOperationResult{T} with a custom polling strategy.
    /// </summary>
    /// <param name="response">The response from the service.</param>
    /// <param name="pollingStrategy">The polling strategy to use.</param>
    protected TestAwareOperationResult(PipelineResponse response, IPollingStrategy pollingStrategy) 
        : base(response, pollingStrategy)
    {
    }

    /// <summary>
    /// Gets the final result of the long-running operation.
    /// </summary>
    /// <remarks>
    /// This property should only be accessed after the operation has completed.
    /// Check the <see cref="OperationResult.HasCompleted"/> property before accessing this value.
    /// </remarks>
    public abstract T Value { get; }
}

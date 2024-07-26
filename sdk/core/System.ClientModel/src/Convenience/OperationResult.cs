// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents an operation that runs asynchronously on a cloud service.  Cloud
/// services use long-running operations to allow users to start an operation
/// with one request and then monitor progress of the operation until it has
/// completed.  <see cref="OperationResult"/> enables waiting for completion of
/// long-running operations.  Client libraries provide derived types that add
/// properties such as <code>Value</code> or <code>Status</code> as applicable
/// for a given service operation.
/// </summary>
public abstract class OperationResult : ClientResult
{
    /// <summary>
    /// Create a new instance of <see cref="OperationResult"/>.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> received from
    /// the service in response to the request that started the operation.</param>
    /// <remarks>Derived types will call
    /// <see cref="ClientResult.SetRawResponse(PipelineResponse)"/> when a new
    /// response is received that updates the status of the operation.</remarks>
    protected OperationResult(PipelineResponse response)
        : base(response)
    {
    }

    /// <summary>
    /// Gets a value that indicates whether the operation has completed.
    /// </summary>
    /// <value><c>true</c> if the operation has reached a terminal state
    /// (that is, is has finished successfully, ended due to an error condition,
    /// or has been cancelled by a user); otherwise, <c>false</c>.
    /// </value>
    public abstract bool IsCompleted { get; protected set; }

    /// <summary>
    /// Gets a token that can be used to rehydrate the operation.
    /// </summary>
    /// <value>A token that can be used to rehydrate the operation, for example
    /// to monitor its progress or to obtain its final result, from a process
    /// different thatn the one that started the operation.</value>
    public abstract ContinuationToken? RehydrationToken { get; protected set; }

    /// <summary>
    /// Waits for the operation to complete processing on the service.
    /// </summary>
    /// <remarks>Derived types may implement <see cref="WaitForCompletionAsync"/>
    /// using different mechanisms to obtain updates from the service regarding
    /// the progress of the operation.  If the derived type polls for status
    /// updates, it provides overloads of <see cref="WaitForCompletionAsync"/>
    /// that allow the caller to specify the polling interval or delay strategy
    /// used to wait between sending request for updates.
    /// </remarks>
    /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/>
    /// was cancelled.</exception>
    public abstract Task WaitForCompletionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Waits for the operation to complete processing on the service.
    /// </summary>
    /// <remarks>Derived types may implement <see cref="WaitForCompletion"/>
    /// using different mechanisms to obtain updates from the service regarding
    /// the progress of the operation.  If the derived type polls for status
    /// updates, it provides overloads of <see cref="WaitForCompletion"/>
    /// that allow the caller to specify the polling interval or delay strategy
    /// used to wait between sending request for updates.
    /// </remarks>
    /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/>
    /// was cancelled.</exception>
    public abstract void WaitForCompletion(CancellationToken cancellationToken = default);
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
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
public abstract class OperationResult
{
    private PipelineResponse _response;

    /// <summary>
    /// Creates a new instance of <see cref="OperationResult"/>.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> received from
    /// the service in response to the request that started the operation.</param>
    protected OperationResult(PipelineResponse response)
    {
        _response = response;
    }

    /// <summary>
    /// Gets a value that indicates whether the operation has completed.
    /// </summary>
    /// <value><c>true</c> if the operation has reached a terminal state
    /// (that is, it has finished successfully, ended due to an error condition,
    /// or has been cancelled by a user); otherwise, <c>false</c>.
    /// </value>
    /// <remarks><see cref="HasCompleted"/> is updated by the
    /// <see cref="UpdateStatus"/> method, based on the response received from
    /// the service regarding the operation's status.  Users must call
    /// <see cref="WaitForCompletion"/>, <see cref="UpdateStatus"/>, or other
    /// method provided by the derived type to ensure that the value of the
    /// <see cref="HasCompleted"/> property reflects the current status of the
    /// operation running on the service.
    /// </remarks>
    public bool HasCompleted { get; protected set; }

    /// <summary>
    /// Gets a token that can be used to rehydrate the operation.
    /// </summary>
    /// <value>A token that can be used to rehydrate the operation, for example
    /// to monitor its progress or to obtain its final result, from a process
    /// different than the one that started the operation.</value>
    /// <remarks>This property is abstract so that derived types that do not
    /// support rehydration can return null without using a backing field for
    /// an unused <see cref="ContinuationToken"/>.</remarks>
    public abstract ContinuationToken? RehydrationToken { get; protected set; }

    /// <summary>
    /// Sends a request to the service to get the current status of the
    /// operation and updates <see cref="HasCompleted"/> and other relevant
    /// properties.
    /// </summary>
    /// <param name="options">The <see cref="RequestOptions"/> to be used when
    /// sending the request to the service.</param>
    /// <returns>The <see cref="ClientResult"/> returned from the service call.
    /// </returns>
    /// <remarks>This method updates the value returned from
    /// <see cref="ClientResult.GetRawResponse"/> and will update
    /// <see cref="HasCompleted"/> to <c>true</c> once the operation has finished
    /// running on the service.  It will also update <c>Value</c> or
    /// <c>Status</c> properties if present on the <see cref="OperationResult"/>
    /// derived type.</remarks>
    public abstract ValueTask<ClientResult> UpdateStatusAsync(RequestOptions? options = default);

    /// <summary>
    /// Sends a request to the service to get the current status of the
    /// operation and updates <see cref="HasCompleted"/> and other relevant
    /// properties.
    /// </summary>
    /// <param name="options">The <see cref="RequestOptions"/> to be used when
    /// sending the request to the service.</param>
    /// <returns>The <see cref="ClientResult"/> returned from the service call.
    /// </returns>
    /// <remarks>This method updates the value returned from
    /// <see cref="ClientResult.GetRawResponse"/> and will update
    /// <see cref="HasCompleted"/> to <c>true</c> once the operation has finished
    /// running on the service.  It will also update <c>Value</c> or
    /// <c>Status</c> properties if present on the <see cref="OperationResult"/>
    /// derived type.</remarks>
    public abstract ClientResult UpdateStatus(RequestOptions? options = default);

    /// <summary>
    /// Waits for the operation to complete processing on the service.
    /// </summary>
    /// <remarks>Derived types may override <see cref="WaitForCompletionAsync"/>
    /// to implement different mechanisms for obtaining updates from the service
    /// regarding the progress of the operation. For example, if the derived
    /// type polls for status updates, it may provides overloads of
    /// <see cref="WaitForCompletionAsync"/>
    /// that allow the caller to specify the polling interval or delay strategy
    /// used to wait between sending request for updates.  By default,
    /// <see cref="WaitForCompletionAsync"/> waits a default interval between
    /// calling <see cref="UpdateStatusAsync"/> to obtain a status updates, so
    /// if updates are delivered via streaming or another mechanism where a wait
    /// time is not required, derived types can override this method to update
    /// the status more frequently.
    /// </remarks>
    /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/>
    /// was cancelled.</exception>
    public virtual async ValueTask WaitForCompletionAsync(CancellationToken cancellationToken = default)
    {
        PollingInterval pollingInterval = new();

        while (!HasCompleted)
        {
            PipelineResponse response = GetRawResponse();

            await pollingInterval.WaitAsync(response, cancellationToken).ConfigureAwait(false);

            RequestOptions? options = RequestOptions.FromCancellationToken(cancellationToken);
            ClientResult result = await UpdateStatusAsync(options).ConfigureAwait(false);

            SetRawResponse(result.GetRawResponse());
        }
    }

    /// <summary>
    /// Waits for the operation to complete processing on the service.
    /// </summary>
    /// <remarks>Derived types may override <see cref="WaitForCompletion"/>
    /// to implement different mechanisms for obtaining updates from the service
    /// regarding the progress of the operation. For example, if the derived
    /// type polls for status updates, it may provides overloads of
    /// <see cref="WaitForCompletion"/>
    /// that allow the caller to specify the polling interval or delay strategy
    /// used to wait between sending request for updates.  By default,
    /// <see cref="WaitForCompletion"/> waits a default interval between
    /// calling <see cref="UpdateStatus"/> to obtain a status updates, so
    /// if updates are delivered via streaming or another mechanism where a wait
    /// time is not required, derived types can override this method to update
    /// the status more frequently.
    /// </remarks>
    /// <exception cref="OperationCanceledException">The <paramref name="cancellationToken"/>
    /// was cancelled.</exception>
    public virtual void WaitForCompletion(CancellationToken cancellationToken = default)
    {
        PollingInterval pollingInterval = new();

        while (!HasCompleted)
        {
            PipelineResponse response = GetRawResponse();

            pollingInterval.Wait(response, cancellationToken);

            RequestOptions? options = RequestOptions.FromCancellationToken(cancellationToken);
            ClientResult result = UpdateStatus(options);

            SetRawResponse(result.GetRawResponse());
        }
    }

    /// <summary>
    /// Gets the <see cref="PipelineResponse"/> corresponding to the most
    /// recent update received from the service.
    /// </summary>
    /// <returns>The most recent <see cref="PipelineResponse"/> received
    /// from the service.
    /// </returns>
    public PipelineResponse GetRawResponse() => _response;

    /// <summary>
    /// Update the value returned from <see cref="GetRawResponse"/>.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> to return
    /// from <see cref="GetRawResponse"/>.</param>
    protected void SetRawResponse(PipelineResponse response)
    {
        Argument.AssertNotNull(response, nameof(response));

        _response = response;
    }
}

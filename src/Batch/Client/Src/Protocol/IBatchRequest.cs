namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    /// <summary>
    /// Represents a request to the Batch service.
    /// </summary>
    public interface IBatchRequest
    {
        /// <summary>
        /// Gets the REST client that will be used for this request.
        /// </summary>
        Protocol.BatchServiceClient RestClient { get; }

        /// <summary>
        /// Gets the options needed by the REST proxy for the current request.
        /// </summary>
        IOptions Options { get; }

        /// <summary>
        /// Gets or sets the retry policy to be applied.
        /// Null means no retries will be attempted.
        /// </summary>
        IRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets the operation context associated with this <see cref="IBatchRequest"/>.
        /// </summary>
        OperationContext OperationContext { get; }

        /// <summary>
        /// Gets or sets the client side timeout for a request to the Batch service.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This timeout applies to a single Batch service request; if a retry policy is specified, then each retry will be granted the
        /// full duration of this value.
        /// </para>
        /// </remarks>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CancellationToken"/> associated with this <see cref="IBatchRequest"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Cancelling this token will cancel the currently ongoing request. This applies to the initial request as well
        /// as any subsequent requests created due to <see cref="RetryPolicy"/>. Cancelling this token also forbids all
        /// future retries of this <see cref="IBatchRequest"/>.
        /// </para>
        /// </remarks>
        CancellationToken CancellationToken { get; set;  }

        /// <summary>
        /// Gets or sets the <see cref="ClientRequestIdProvider"/> used by this request to generate client request ids.
        /// </summary>
        ClientRequestIdProvider ClientRequestIdProvider { get; set; }

    }

    /// <summary>
    /// Represents a request to the Batch Service with a particular response type.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response returned by the Batch service.</typeparam>
    public interface IBatchRequest<TResponse> : IBatchRequest
    {
        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <returns>An asynchronous operation of return type <typeparamref name="TResponse"/>.</returns>
        Task<TResponse> ExecuteRequestAsync();
    }
}

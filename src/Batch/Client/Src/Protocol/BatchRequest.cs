namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.Rest.Azure;
    using Models;
    
    /// <summary>
    /// A base class for all Batch service requests. Represents the information required to make a particular call with no request body to the Batch service REST API.
    /// </summary>
    /// <typeparam name="TOptions">The type of the parameters passed outside the request body associated with the request.</typeparam>
    /// <typeparam name="TResponse">The response type expected from the request.</typeparam>
    public abstract class BatchRequestBase<TOptions, TResponse> : IBatchRequest<TResponse>
        where TOptions : IOptions, new()
        where TResponse : IAzureOperationResponse
    {
        private volatile bool hasRequestExecutionStarted;
        private Func<CancellationToken, Task<TResponse>> serviceRequestFunc;
        private TOptions options;
        private IRetryPolicy retryPolicy;
        private TimeSpan timeout;
        private CancellationToken cancellationToken;
        private ClientRequestIdProvider clientRequestIdProvider;

        /// <summary>
        /// Gets the headers used for the request.
        /// </summary>
        public Dictionary<string, List<string>> CustomHeaders { get; private set; }

        /// <summary>
        /// Gets or sets the function which will create a <see cref="Task"/> calling the Batch service.
        /// </summary>
        public Func<CancellationToken, Task<TResponse>> ServiceRequestFunc 
        {
            get { return this.serviceRequestFunc; }
            set
            {
                this.ThrowIfRequestExecutionHasStarted();
                this.serviceRequestFunc = value;
            }
        }

        /// <summary>
        /// Gets or sets the options used for the request.
        /// </summary>
        public TOptions Options
        {
            get { return this.options; }
            set
            {
                this.ThrowIfRequestExecutionHasStarted();
                this.options = value;
            }
        }

        /// <summary>
        /// Gets the options needed by the REST proxy for the current request.
        /// </summary>
        IOptions IBatchRequest.Options { get { return Options; } }

        /// <summary>
        /// Gets the REST client that will be used for this request.
        /// </summary>
        public Protocol.BatchServiceClient RestClient { get; private set; }

        /// <summary>
        /// Gets or sets the retry policy to be applied.
        /// Null means no retries will be attempted.
        /// </summary>
        public IRetryPolicy RetryPolicy
        {
            get { return this.retryPolicy; }
            set
            {
                this.ThrowIfRequestExecutionHasStarted();
                this.retryPolicy = value;
            }
        }

        /// <summary>
        /// Gets the operation context associated with this <see cref="IBatchRequest"/>.
        /// </summary>
        public OperationContext OperationContext { get; private set; }

        /// <summary>
        /// Gets or sets the client side timeout for a request to the Batch service.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This timeout applies to a single Batch service request; if a retry policy is specified, then each retry will be granted the
        /// full duration of this value.
        /// </para>
        /// </remarks>
        public TimeSpan Timeout
        {
            get { return this.timeout; }
            set
            {
                this.ThrowIfRequestExecutionHasStarted();
                this.timeout = value;
            }
        }

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
        public CancellationToken CancellationToken
        {
            get { return this.cancellationToken; }
            set
            {
                this.ThrowIfRequestExecutionHasStarted();
                this.cancellationToken = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="ClientRequestIdProvider"/> used by this request to generate client request ids.
        /// </summary>
        public ClientRequestIdProvider ClientRequestIdProvider
        {
            get { return this.clientRequestIdProvider; }
            set
            {
                this.ThrowIfRequestExecutionHasStarted();
                this.clientRequestIdProvider = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRequestBase{TOptions,TResponse}"/> class.
        /// </summary>
        /// <param name="restClient">The REST client to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        protected BatchRequestBase(Protocol.BatchServiceClient restClient, CancellationToken cancellationToken)
        {
            //Construct a default set of options
            this.Options = new TOptions();
            this.OperationContext = new OperationContext();
            this.RestClient = restClient;
            this.Timeout = Constants.DefaultSingleRestRequestClientTimeout;
            this.CancellationToken = cancellationToken;
            this.CustomHeaders = new Dictionary<string, List<string>>();
            this.hasRequestExecutionStarted = false;
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <returns>An asynchronous operation of return type <typeparamref name="TResponse"/>.</returns>
        public async Task<TResponse> ExecuteRequestAsync()
        {
            this.hasRequestExecutionStarted = true;

            bool shouldRetry;
            do
            {
                shouldRetry = false; //Start every request execution assuming there will be no retry
                Task<TResponse> serviceRequestTask = null;
                Exception capturedException;

                //Participate in cooperative cancellation
                this.CancellationToken.ThrowIfCancellationRequested();

                try
                {
                    this.ApplyClientRequestIdBehaviorToParams();

                    serviceRequestTask = this.ExecuteRequestWithCancellationAsync(this.ServiceRequestFunc);

                    TResponse response = await serviceRequestTask.ConfigureAwait(continueOnCapturedContext: false);

                    //TODO: It would be nice if we could add to OperationContext.RequestResults here
                    return response;
                }
                catch (Exception e)
                {
                    //If the caught exception was a BatchErrorException, we wrap it in the object model exception type
                    BatchException batchException = null;
                    if (e is BatchErrorException)
                    {
                        batchException = new BatchException(e as BatchErrorException);
                    }

                    Exception wrappedException = batchException ?? e;

                    if (this.RetryPolicy != null &&
                        //If cancellation is requested at this point, just skip calling the retry policy and throw
                        //This is the most honest thing to do since we will not be issuing another request on the users behalf
                        //(since the cancellation token has already been set) and thus calling their retry policy would just
                        //be confusing.
                        !this.CancellationToken.IsCancellationRequested)
                    {
                        RequestInformation requestInformation;

                        if (batchException != null)
                        {
                            //If there is a BatchException, extract the RequestInformation and capture it
                            requestInformation = batchException.RequestInformation;
                        }
                        else
                        {
                            requestInformation = new RequestInformation()
                            {
                                ClientRequestId = this.ExtractClientRequestId()
                            };
                        }

                        this.OperationContext.RequestResults.Add(new RequestResult(requestInformation, wrappedException) { Task = serviceRequestTask });
                        capturedException = wrappedException;
                    }
                    else
                    {
                        if (batchException != null)
                        {
                            throw batchException; //Just forward the wrapped exception if there was one
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                if (capturedException != null)
                {
                    //On an exception, invoke the retry policy
                    RetryDecision retryDecision = await this.RetryPolicy.ShouldRetryAsync(capturedException, this.OperationContext).ConfigureAwait(continueOnCapturedContext: false);
                    shouldRetry = retryDecision.ShouldRetry;

                    if (!shouldRetry)
                    {
                        //Rethrow the exception and explicitly preserve the stack trace
                        ExceptionDispatchInfo.Capture(capturedException).Throw();
                    }
                    else
                    {
                        if (retryDecision.RetryDelay.HasValue)
                        {
                            await Task.Delay(retryDecision.RetryDelay.Value).ConfigureAwait(continueOnCapturedContext: false);
                        }
                        else
                        {
                            Debug.Assert(false, "RetryDecision.ShouldRetry = true but RetryDelay has no value");
                        }
                    }
                }

            } while (shouldRetry);

            //Reaching here is a bug, by now the request should have either thrown or returned
            const string errorMessage = "Exited ExecuteRequestAsync without throwing or returning";
            Debug.Assert(false, errorMessage);
            throw new InvalidOperationException(errorMessage);
        }

        /// <summary>
        /// Throws an exception if request execution has started.
        /// </summary>
        protected void ThrowIfRequestExecutionHasStarted()
        {
            if (this.hasRequestExecutionStarted)
            {
                throw new InvalidOperationException(BatchErrorMessages.BatchRequestCannotBeModified);
            }
        }

        /// <summary>
        /// Extracts the client request ID from the options.
        /// </summary>
        /// <returns>The client request ID GUID or null if there wasn't one.</returns>
        private Guid? ExtractClientRequestId()
        {
            Guid? result = string.IsNullOrEmpty(this.Options.ClientRequestId)
                ? default(Guid?)
                : Guid.Parse(this.Options.ClientRequestId);

            return result;
        }

        /// <summary>
        /// Executes the specified function with a cancellation token which is a composite token for the <see cref="IBatchRequest.Timeout"/>
        /// and the <see cref="IBatchRequest.CancellationToken"/>.
        /// </summary>
        /// <param name="func">The function defining what work to be called in a cancellable way</param>
        /// <returns>A task with the async state of the func</returns>
        private async Task<TResponse> ExecuteRequestWithCancellationAsync(Func<CancellationToken, Task<TResponse>> func)
        {
            //CancellationToken(from outside) should cancel BOTH the retries and the currently ongoing REST request
            //CancellationToken(from timeout) should cancel just the currently ongoing REST request

            using (CancellationTokenSource timeoutCancellationTokenSource = new CancellationTokenSource(this.Timeout))
            {
                CancellationToken timeoutToken = timeoutCancellationTokenSource.Token;
                using (CancellationTokenSource linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutToken, this.CancellationToken))
                {
                    return await func(linkedTokenSource.Token).ConfigureAwait(continueOnCapturedContext: false);
                }
            }
        }

        private void ApplyClientRequestIdBehaviorToParams()
        {
            if (this.ClientRequestIdProvider == null)
            {
                Guid clientRequestId = Guid.NewGuid();
                this.Options.ClientRequestId = clientRequestId.ToString();
            }
            else
            {
                this.Options.ClientRequestId = this.ClientRequestIdProvider.GenerateClientRequestIdFunc(this).ToString();
            }
        }
    }

    /// <summary>
    /// Represents the information required to make a particular call with no request body to the Batch service REST API.
    /// </summary>
    /// <typeparam name="TOptions">The type of the parameters passed outside the request body associated with the request.</typeparam>
    /// <typeparam name="TResponse">The response type expected from the request.</typeparam>
    public class BatchRequest<TOptions, TResponse> : BatchRequestBase<TOptions, TResponse>
        where TOptions : IOptions, new()
        where TResponse : IAzureOperationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRequest{TOptions,TResponse}"/> class.
        /// </summary>
        /// <param name="restClient">The REST client to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public BatchRequest(BatchServiceClient restClient, CancellationToken cancellationToken)
            : base(restClient, cancellationToken)
        {
        }
    }

    /// <summary>
    /// Represents the information required to make a particular call with a request body of type <typeparamref name="TBody"/> to the Batch service REST API.
    /// </summary>
    /// <typeparam name="TBody">The type of the body parameters associated with the request.</typeparam>
    /// <typeparam name="TOptions">The type of the parameters passed outside the request body associated with the request.</typeparam>
    /// <typeparam name="TResponse">The response type expected from the request.</typeparam>
    public class BatchRequest<TBody, TOptions, TResponse> : BatchRequestBase<TOptions, TResponse>
        where TOptions: IOptions, new()
        where TResponse : IAzureOperationResponse
    {
        private TBody parameters;

        /// <summary>
        /// Gets or sets the parameters passed in the REST API request body.
        /// </summary>
        public TBody Parameters
        {
            get { return this.parameters; }
            set
            {
                this.ThrowIfRequestExecutionHasStarted();
                this.parameters = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRequest{TParameters,TOptions,TResponse}"/> class.
        /// </summary>
        /// <param name="restClient">The REST client to use.</param>
        /// <param name="parameters">The parameters to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public BatchRequest(Protocol.BatchServiceClient restClient, TBody parameters, CancellationToken cancellationToken) : base(restClient, cancellationToken)
        {
            Parameters = parameters;
        }
    }
}
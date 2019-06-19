namespace Microsoft.Azure.Batch.Protocol
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using System;

    /// <summary>
    /// A BatchClientBehavior that enables inspection and modification of the BatchResponse.
    /// </summary>
    public class ResponseInterceptor : BatchClientBehavior
    {
        /// <summary>
        /// A callback that can inspect and modify a BatchResponse.
        /// </summary>
        /// <param name="response">The response to be inspected and optionally modified.</param>
        /// <param name="request">The request to which the <paramref name="response"/> is a response.</param>
        public delegate System.Threading.Tasks.Task<IAzureOperationResponse> BatchResponseInterceptHandler(IAzureOperationResponse response, IBatchRequest request);

        private ResponseInterceptor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseInterceptor"/> class.
        /// </summary>
        /// <param name="responseInterceptHandler">The method to invoke on the intercepted response.</param>
        public ResponseInterceptor(BatchResponseInterceptHandler responseInterceptHandler)
        {
            this.ResponseInterceptHandler = responseInterceptHandler;
        }

        /// <summary>
        /// Gets or sets the method to invoke on the intercepted response.
        /// </summary>
        public BatchResponseInterceptHandler ResponseInterceptHandler
        {
            get;
            set;
        }
    }
}

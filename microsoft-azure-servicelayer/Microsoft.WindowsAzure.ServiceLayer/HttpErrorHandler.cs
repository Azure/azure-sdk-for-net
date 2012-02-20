using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    class HttpErrorHandler: MessageProcessingHandler
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        internal HttpErrorHandler()
            : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="innerHandler">Inner HTTP handler</param>
        internal HttpErrorHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <summary>
        /// Processes outhoing HTTP requests.
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Processed HTTP request</returns>
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // We're not interested in outgoing requests; do nothing.
            return request;
        }

        /// <summary>
        /// Processes incoming HTTP responses.
        /// </summary>
        /// <param name="response">HTTP response</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Processed HTTP response</returns>
        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, System.Threading.CancellationToken cancellationToken)
        {
            if (!response.IsSuccessStatusCode)
                throw new AzureServiceException();
            return response;
        }
    }
}

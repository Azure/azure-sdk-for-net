namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    /// <summary>
    /// This is an attribute that can be used to validate the returned HttpStatusCode of RestCall.
    /// </summary>
    internal sealed class ExpectedStatusCodeValidatorAttribute : Attribute, IHttpMessageProcessingHandler
    {
        private readonly HttpStatusCode[] _codes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectedStatusCodeValidatorAttribute" /> class.
        /// </summary>
        /// <param name="codes">The expected status codes.</param>
        /// <exception cref="System.ArgumentException">Status code validation is only done for non error status codes [100,400).</exception>
        public ExpectedStatusCodeValidatorAttribute(HttpStatusCode[] codes)
        {
            this._codes = codes;
        }

        /// <summary>
        /// Gets the expected status codes.
        /// </summary>
        /// <value>
        /// The expected status codes.
        /// </value>
        public IEnumerable<HttpStatusCode> ExpectedStatusCodes
        {
            get { return this._codes; }
        }

        private class StatusCodeValidatingHandler : MessageProcessingHandler
        {
            private readonly ExpectedStatusCodeValidatorAttribute _parent;

            public StatusCodeValidatingHandler(ExpectedStatusCodeValidatorAttribute parent)
            {
                this._parent = parent;
            }

            protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return request;
            }

            protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
            {
                if (!this._parent.ExpectedStatusCodes.Any(c => c == response.StatusCode))
                {
                    throw new InvalidExpectedStatusCodeException(response.StatusCode, this._parent.ExpectedStatusCodes, response);
                }

                return response;
            }
        }

        /// <summary>
        /// Gets the message processing handler.
        /// </summary>
        /// <returns>A DelegatingHandler.</returns>
        /// <value>
        /// The message processing handler.
        ///   </value>
        /// <remarks>
        /// This method should return a new handler every time for it to be thread safe.
        /// </remarks>
        public DelegatingHandler CreateHandler()
        {
            return new StatusCodeValidatingHandler(this);
        }
    }
}

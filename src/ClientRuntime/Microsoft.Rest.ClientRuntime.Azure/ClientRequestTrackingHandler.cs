// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Enables adding a correlation id to messages so that messages that are part of a long-running
    /// operation can be grouped together
    /// </summary>
    public class ClientRequestTrackingHandler
        : MessageProcessingHandler
    {
        /// <summary>
        /// The tracking ID for the operation
        /// </summary>
        public string TrackingId { get; private set; }

        /// <summary>
        /// Creates a request tracking handler with the specified tracking ID
        /// </summary>
        /// <param name="trackingId">The tracking correlation ID to be added to each http message</param>
        public ClientRequestTrackingHandler(string trackingId)
            : base()
        {
            TrackingId = trackingId;
        }

        /// <summary>
        /// Adds the tracking ID for this operation to the outgoing request header
        /// </summary>
        /// <param name="request">The http request message</param>
        /// <param name="cancellationToken">A token that allows canceling the http operation</param>
        /// <returns>The outgoing http request message with the tracking ID header added</returns>
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            request.Headers.Add("client-tracking-id", TrackingId);
            return request;
        }

         /// <summary>
        /// Adds the tracking ID for this operation to the incoming response header
        /// </summary>
        /// <param name="response">The http response message</param>
        /// <param name="cancellationToken">A token that allows canceling the http operation</param>
        /// <returns>The incoming http response message with the tracking ID header added</returns>
       protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, 
           CancellationToken cancellationToken)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }
            response.Headers.Add("client-tracking-id", TrackingId);
            return response;
        }
    }
}

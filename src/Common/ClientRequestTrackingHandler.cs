//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net.Http;
using System.Threading;

namespace Microsoft.Azure
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
        /// <param name="cancellationToken">A token that allows cancelling the http operation</param>
        /// <returns>The outgoing http request message with the tracking ID header added</returns>
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("client-tracking-id", TrackingId);
            return request;
        }

         /// <summary>
        /// Adds the tracking ID for this operation to the incoming response header
        /// </summary>
        /// <param name="response">The http response message</param>
        /// <param name="cancellationToken">A token that allows cancelling the http operation</param>
        /// <returns>The incoming http response message with the tracking ID header added</returns>
       protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            response.Headers.Add("client-tracking-id", TrackingId);
            return response;
        }
    }
}

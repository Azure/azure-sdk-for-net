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
    /// Handler for adding tracking headers to http requests and responses
    /// </summary>
    public class ClientRequestTrackingHandler
        : MessageProcessingHandler
    {
        /// <summary>
        /// The tracking header value to add
        /// </summary>
        public string TrackingId { get; private set; }

        /// <summary>
        /// Create a new ClientRequestTrackingHnalder with the given tracking Id
        /// </summary>
        /// <param name="trackingId">The header value for the tracking id header</param>
        public ClientRequestTrackingHandler(string trackingId)
            : base()
        {
            TrackingId = trackingId;
        }

        /// <summary>
        /// Add a tracking header to the outgoing request message
        /// </summary>
        /// <param name="request">The outgoing request</param>
        /// <param name="cancellationToken">A cacellation token for the asychronous method</param>
        /// <returns>Returns the request with the trackign header added</returns>
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("client-tracking-id", TrackingId);
            return request;
        }
        /// <summary>
        /// Add a tracking header to the incoming response message
        /// </summary>
        /// <param name="response">The incoming response</param>
        /// <param name="cancellationToken">A cacellation token for the asychronous method</param>
        /// <returns>Returns the request with the trackign header added</returns>
        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            response.Headers.Add("client-tracking-id", TrackingId);
            return response;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    /// <summary>
    /// Response for event.
    /// </summary>
    [DataContract]
    public abstract class SocketIOEventHandlerResponse
    {
        [DataMember(Name = "statusCode")]
        internal HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Construct an successful response.
        /// </summary>
        public SocketIOEventHandlerResponse()
        {
            StatusCode = HttpStatusCode.OK;
        }

        /// <summary>
        /// Construct an response with status code.
        /// </summary>
        /// <param name="statusCode"></param>
        public SocketIOEventHandlerResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}

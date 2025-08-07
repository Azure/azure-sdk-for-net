// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebPubSub.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    /// <summary>
    /// Response for connect event.
    /// </summary>
    [DataContract]
    public class SocketIOConnectResponse: SocketIOEventHandlerResponse
    {
        /// <summary>
        /// Construct an successful response.
        /// </summary>
        public SocketIOConnectResponse() : base()
        {
        }

        /// <summary>
        /// Construct an response with status code.
        /// </summary>
        /// <param name="statusCode"></param>
        public SocketIOConnectResponse(HttpStatusCode statusCode) : base(statusCode)
        {
        }
    }
}

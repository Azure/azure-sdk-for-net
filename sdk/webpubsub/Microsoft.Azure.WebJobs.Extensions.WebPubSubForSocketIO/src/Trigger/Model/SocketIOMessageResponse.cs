// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class SocketIOMessageResponse: SocketIOEventHandlerResponse
    {
        /// <summary>
        /// The response for the event.
        /// </summary>
        public IList<object> Parameters { get; }

        /// <summary>
        /// Construct an successful response.
        /// </summary>
        public SocketIOMessageResponse() : base()
        {
        }

        /// <summary>
        /// Construct an successful response with response data.
        /// </summary>
        /// <param name="parameters">response data</param>
        public SocketIOMessageResponse(IList<object> parameters): this(HttpStatusCode.OK, parameters)
        {
        }

        /// <summary>
        /// Construct an response with status code.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="parameters">response data</param>
        public SocketIOMessageResponse(HttpStatusCode statusCode, IList<object> parameters) : base(statusCode)
        {
            Parameters = parameters;
        }
    }
}

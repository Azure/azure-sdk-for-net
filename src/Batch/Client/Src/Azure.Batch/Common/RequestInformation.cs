// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Net;

    /// <summary>
    /// A set of common information associated with a request.
    /// </summary>
    public class RequestInformation
    {
        /// <summary>
        /// Gets or sets the Batch Error information which contains detailed metadata around 
        /// the specific error encountered.
        /// </summary>
        public BatchError BatchError { get; protected internal set; }
        
        /// <summary>
        /// Gets or sets the HTTP status message for the request.
        /// </summary>
        public string HttpStatusMessage { get; protected internal set; }

        /// <summary>
        /// Gets or sets the HTTP status code for the request.
        /// In cases where an HTTP response was never recieved (for example on client side timeout) this property is null.
        /// </summary>
        public HttpStatusCode? HttpStatusCode { get; protected internal set; }

        // /// <summary>
        // /// Gets or sets the start time of the request.
        // /// </summary>
        //public DateTime RequestStartTime { get; set; }

        /// <summary>
        /// Gets or sets the client-request-id set by the client.
        /// </summary>
        public Guid? ClientRequestId { get; protected internal set; }

        /// <summary>
        /// Gets or sets the service request ID for this request.
        /// </summary>
        public string ServiceRequestId { get; protected internal set; }
    }
}

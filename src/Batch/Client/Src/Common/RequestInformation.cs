// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
        /// Gets or sets the Azure Error information which contains detailed metadata around 
        /// the specific error encountered.
        /// </summary>
        [Obsolete("Obselete after 2/2016, use the BatchError property instead")]
        public BatchError AzureError
        {
            get { return this.BatchError; }
        }

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

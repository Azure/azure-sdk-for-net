// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Hyak.Common
{
    /// <summary>
    /// A standard service response including an HTTP status code and request
    /// ID.
    /// </summary>
    public class HttpOperationResponse
    {
        /// <summary>
        /// Gets or sets the standard HTTP status code from the REST API 
        /// operations for the Service Management API.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}
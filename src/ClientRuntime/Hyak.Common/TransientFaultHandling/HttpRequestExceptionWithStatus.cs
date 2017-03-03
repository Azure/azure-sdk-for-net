// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Hyak.Common.TransientFaultHandling
{
    /// <summary>
    /// Inherits HttpRequestException adding HttpStatusCode to the exception.
    /// </summary>
    public class HttpRequestExceptionWithStatus : HttpRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestExceptionWithStatus"/> class.
        /// </summary>
        public HttpRequestExceptionWithStatus() : base() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestExceptionWithStatus"/> class
        /// with a specific message that describes the current exception.
        /// </summary>
        /// <param name="message">A message that describes the current exception.</param>
        public HttpRequestExceptionWithStatus(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestExceptionWithStatus"/> class
        /// with a specific message that describes the current exception and an inner
        /// exception.
        /// </summary>
        /// <param name="message">A message that describes the current exception.</param>
        /// <param name="inner">The inner exception.</param>
        public HttpRequestExceptionWithStatus(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Http status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}

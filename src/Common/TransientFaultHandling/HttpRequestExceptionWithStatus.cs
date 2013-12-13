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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Microsoft.WindowsAzure.Common.TransientFaultHandling
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

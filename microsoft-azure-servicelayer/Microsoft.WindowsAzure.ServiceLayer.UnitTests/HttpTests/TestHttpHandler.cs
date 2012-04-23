//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.Http;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.HttpTests
{
    /// <summary>
    /// HTTP handler for testing pipelining.
    /// </summary>
    internal class TestHttpHandler: IHttpHandler
    {
        internal int RequestCount { get; set; }
        internal int ResponseCount { get; set; }

        /// <summary>
        /// Initializes the object.
        /// </summary>
        internal TestHttpHandler()
        {
            RequestCount = 0;
            ResponseCount = 0;
        }

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="request">Request to process.</param>
        /// <returns>Processed request.</returns>
        HttpRequest IHttpHandler.ProcessRequest(HttpRequest request)
        {
            RequestCount++;
            return request;
        }

        /// <summary>
        /// Processes the response.
        /// </summary>
        /// <param name="response">Response to process.</param>
        /// <returns>Processed response.</returns>
        HttpResponse IHttpHandler.ProcessResponse(HttpResponse response)
        {
            ResponseCount++;
            return response;
        }
    }
}

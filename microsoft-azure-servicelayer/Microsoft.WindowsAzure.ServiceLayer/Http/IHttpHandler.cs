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

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// HTTP handler processes HTTP requests.
    /// </summary>
    public interface IHttpHandler: IDisposable
    {
        /// <summary>
        /// Processes HTTP request.
        /// </summary>
        /// <param name="request">Request to process.</param>
        /// <returns>Processed request.</returns>
        /// <remarks>The channel processes the request by passing it through
        /// all handlers. Processing stops if any request handler indicates
        /// failure, in which case the error from the handler gets returned
        /// by the channel's SendAsync method.</remarks>
        HttpRequest ProcessRequest(HttpRequest request);

        /// <summary>
        /// Processes HTTP response.
        /// </summary>
        /// <param name="response">Response to process.</param>
        /// <returns>Processed response.</returns>
        HttpResponse ProcessResponse(HttpResponse response);
    }
}

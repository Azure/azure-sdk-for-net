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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// Exception that occurs when HTTP call to Azure service fails.
    /// </summary>
    internal class WindowsAzureHttpException: WindowsAzureException
    {
        /// <summary>
        /// Initializes the exception with data from the given HTTP response.
        /// </summary>
        /// <param name="response">HTTP response.</param>
        internal WindowsAzureHttpException(HttpResponse response)
        {
            HResult = GetComErrorCode(response.StatusCode, ErrorSource.ServiceBus);

            //TODO: error message.
        }

        /// <summary>
        /// Initializes an empty exception.
        /// </summary>
        /// <remarks>This constructor is only used from derived classes that 
        /// set required properties directly.</remarks>
        protected WindowsAzureHttpException()
        {
        }

        /// <summary>
        /// Generates HRESULT for the given HTTP status code.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="errorSource">Error source.</param>
        /// <returns>HRESULT with embedded status code and source.</returns>
        internal static int GetComErrorCode(int statusCode, ErrorSource errorSource)
        {
            // 10 bits should be enough for the error code!
            Debug.Assert((statusCode & 0xFC00) == 0);
            uint code = 0x80040000;
            code |= ((uint)errorSource) << 10;
            code |= (uint)statusCode;
            return (int)code;
        }
    }
}

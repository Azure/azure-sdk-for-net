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
    /// WRAP authentication exception.
    /// </summary>
    /// <remarks>The exception occurs when WRAP authentication request fails.</remarks>
    internal class WrapAuthenticationException: WindowsAzureHttpException
    {
        /// <summary>
        /// Initializes the exception.
        /// </summary>
        /// <param name="response">Response.</param>
        internal WrapAuthenticationException(HttpResponse response)
        {
            HResult = GetComErrorCode(response.StatusCode, ErrorSource.WrapAuthentication);
            //TODO: error message!
        }
    }
}

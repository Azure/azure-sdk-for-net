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
using System.Globalization;
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
        /// <param name="message">Error message.</param>
        /// <param name="response">HTTP response.</param>
        internal WindowsAzureHttpException(string message, HttpResponse response)
            : this(message, WindowsAzureErrorSource.ServiceBus, response)
        {
        }

        /// <summary>
        /// Initializes the exception.
        /// </summary>
        /// <param name="message">Short error message.</param>
        /// <param name="source">Error source.</param>
        /// <param name="response">HTTP response that triggered the exception.</param>
        protected WindowsAzureHttpException(string message, WindowsAzureErrorSource source, HttpResponse response)
            : base(GetHttpErrorMessage(message, response))
        {
            HResult = HttpErrorHelper.CreateComErrorCode(source, response.StatusCode);
        }

        /// <summary>
        /// Generates result message for an exception.
        /// </summary>
        /// <param name="message">Short message.</param>
        /// <param name="response">HTTP response with more details.</param>
        /// <returns>Error message.</returns>
        protected static string GetHttpErrorMessage(string message, HttpResponse response)
        {
            string details = string.Format(CultureInfo.CurrentUICulture, Resources.HttpDetails, response.StatusCode, response.ReasonPhrase);
            return string.Format(CultureInfo.CurrentUICulture, Resources.HttpErrorMessage, message, details);
        }
    }
}

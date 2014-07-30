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
using System.Net;
using System.Net.Http;

namespace Microsoft.WindowsAzure.Common.TransientFaultHandling
{
    /// <summary>
    /// Default Http error detection strategy based on Http Status Code.
    /// </summary>
    public class DefaultHttpErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        /// <summary>
        /// Returns true if status code in HttpRequestExceptionWithStatus exception is greater 
        /// than or equal to 500 and not NotImplemented (501) or HttpVersionNotSupported (505).
        /// </summary>
        /// <param name="ex">Exception to check against.</param>
        /// <returns>True if exception is transient otherwise false.</returns>
        public bool IsTransient(Exception ex)
        {
            if (ex != null)
            {
                HttpRequestExceptionWithStatus httpException;
                if ((httpException = ex as HttpRequestExceptionWithStatus) != null)
                {
                    if (httpException.StatusCode == HttpStatusCode.RequestTimeout || 
                        (httpException.StatusCode >= HttpStatusCode.InternalServerError &&
                        httpException.StatusCode != HttpStatusCode.NotImplemented &&
                        httpException.StatusCode != HttpStatusCode.HttpVersionNotSupported))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

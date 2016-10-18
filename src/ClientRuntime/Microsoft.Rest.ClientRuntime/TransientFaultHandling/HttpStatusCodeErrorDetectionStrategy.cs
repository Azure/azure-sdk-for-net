// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;

namespace Microsoft.Rest.TransientFaultHandling
{
    /// <summary>
    /// Default Http error detection strategy based on Http Status Code.
    /// </summary>
    public class HttpStatusCodeErrorDetectionStrategy : ITransientErrorDetectionStrategy
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
                HttpRequestWithStatusException httpException;
                if ((httpException = ex as HttpRequestWithStatusException) != null)
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
//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.KeyVault
{
    /// <summary>
    /// KeyVault Request Exception
    /// </summary>
    public class KeyVaultClientException : Exception
    {
        private static string GetExceptionMessage( Error error )
        {
            if ( error != null && !string.IsNullOrWhiteSpace( error.Message ) )
                return error.Message;

            return "Service Error information was not available";
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyVaultClientException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="status">The HTTP response status code</param>
        /// <param name="error">The Error object returned by the service</param>
        public KeyVaultClientException( HttpStatusCode status, Uri requestUri, Error error = null )
            : base( GetExceptionMessage( error ) )
        {
            Error      = error;
            RequestUri = requestUri;
            Status     = status;
        }

        /// <summary>
        /// The HTTP response status code
        /// </summary>
        public HttpStatusCode Status
        {
            get;
            private set;
        }

        /// <summary>
        /// The Error object returned by the service
        /// </summary>
        public Error Error
        {
            get;
            private set;
        }

        /// <summary>
        /// The Uri that the request was made to.
        /// </summary>
        public Uri RequestUri
        {
            get;
            private set;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="NoOpAuthenticationHandler.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Auth.Protocol
{
    using System;
    using System.Net;

    /// <summary>
    /// Represents a handler that signs HTTP requests with no authentication information.
    /// </summary>
    public sealed class NoOpAuthenticationHandler : IAuthenticationHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoOpAuthenticationHandler"/> class.
        /// </summary>
        public NoOpAuthenticationHandler()
        {
        }

        /// <summary>
        /// Signs the specified HTTP request with no authentication information.
        /// </summary>
        /// <param name="request">The HTTP request to sign.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        public void SignRequest(HttpWebRequest request, OperationContext operationContext)
        {
            // no op
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="IAuthenticationHandler.cs" company="Microsoft">
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
    using System.Net;

    /// <summary>
    /// Represents a handler that signs HTTP requests.
    /// </summary>
    public interface IAuthenticationHandler
    {
        /// <summary>
        /// Signs the specified HTTP request so it can be authenticated by the Windows Azure storage services.
        /// </summary>
        /// <param name="request">The HTTP request to sign.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        void SignRequest(HttpWebRequest request, OperationContext operationContext);
    }
}

//-----------------------------------------------------------------------
// <copyright file="StorageErrorCode.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the StorageErrorCode enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Describes error codes that may be returned by the Windows Azure storage services or the storage client library.
    /// </summary>
    public enum StorageErrorCode
    {
        /// <summary>
        /// No error specified.
        /// </summary>
        None = 0,

        /// <summary>
        /// An internal server occurred (server-side error).
        /// </summary>
        ServiceInternalError = 1,

        /// <summary>
        /// The service timed out (server-side error).
        /// </summary>
        ServiceTimeout,

        /// <summary>
        /// A service integrity check failed (server-side error).
        /// </summary>
        ServiceIntegrityCheckFailed,

        /// <summary>
        /// A transport error occurred (server-side error).
        /// </summary>
        TransportError,
        
        /// <summary>
        /// The service returned a bad response (server-side error).
        /// </summary>
        ServiceBadResponse,

        /// <summary>
        /// The specified resource was not found (client-side error).
        /// </summary>
        ResourceNotFound,

        /// <summary>
        /// The specified account was not found (client-side error).
        /// </summary>
        AccountNotFound,
        
        /// <summary>
        /// The specified container was not found (client-side error).
        /// </summary>
        ContainerNotFound,

        /// <summary>
        /// The specified blob was not found (client-side error).
        /// </summary>
        BlobNotFound,

        /// <summary>
        /// An authentication error occurred (client-side error).
        /// </summary>
        AuthenticationFailure,

        /// <summary>
        /// Access was denied (client-side error).
        /// </summary>
        AccessDenied,

        /// <summary>
        /// The specified resource already exists (client-side error).
        /// </summary>
        ResourceAlreadyExists,

        /// <summary>
        /// The specified container already exists (client-side error).
        /// </summary>
        ContainerAlreadyExists,

        /// <summary>
        /// The specified blob already exists (client-side error).
        /// </summary>
        BlobAlreadyExists,

        /// <summary>
        /// The request was incorrect or badly formed (client-side error).
        /// </summary>
        BadRequest,

        /// <summary>
        /// The specified condition failed (client-side error).
        /// </summary>
        ConditionFailed,

        /// <summary>
        /// There was an error with the gateway used for the request (client-side error).
        /// </summary>
        BadGateway,

        /// <summary>
        /// The requested operation is not implemented on the specified resource (client-side error).
        /// </summary>
        NotImplemented,

        /// <summary>
        /// The request version header is not supported (client-side error).
        /// </summary>
        HttpVersionNotSupported,
    }
}

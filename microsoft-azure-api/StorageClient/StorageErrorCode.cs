//-----------------------------------------------------------------------
// <copyright file="StorageErrorCode.cs" company="Microsoft">
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

        /// <summary>
        /// A lease is required to perform the operation.
        /// </summary>
        LeaseIdMissing,

        /// <summary>
        /// The given lease ID does not match the current lease.
        /// </summary>
        LeaseIdMismatch,

        /// <summary>
        /// A lease ID was used when no lease currently is held.
        /// </summary>
        LeaseNotPresent,

        /// <summary>
        /// The given lease ID has expired.
        /// </summary>
        LeaseLost,

        /// <summary>
        /// The lease is already present when trying to acquire.
        /// </summary>
        LeaseAlreadyPresent,
        
        /// <summary>
        /// The lease is already broken with a lower break period.
        /// </summary>
        LeaseAlreadyBroken,

        /// <summary>
        /// The lease cannot be renewed because it is broken.
        /// </summary>
        LeaseIsBrokenAndCannotBeRenewed,

        /// <summary>
        /// The lease cannot be acquired because it is breaking.
        /// </summary>
        LeaseIsBreakingAndCannotBeAcquired,

        /// <summary>
        /// The lease cannot be changed because it is breaking.
        /// </summary>
        LeaseIsBreakingAndCannotBeChanged,

        /// <summary>
        /// The current copy was aborted.
        /// </summary>
        CopyAborted,

        /// <summary>
        /// The pending copy failed.
        /// </summary>
        CopyFailed,

        /// <summary>
        /// The given copy ID is no longer stored in the <see cref="CopyState"/>.
        /// </summary>
        CopyIdLost,

        /// <summary>
        /// The copy can't be aborted because the copy ID does not match.
        /// </summary>
        CopyIdMismatch,

        /// <summary>
        /// There is currently no pending copy operation to abort.
        /// </summary>
        NoPendingCopyOperation,

        /// <summary>
        /// The operation is not allowed because of a pending copy operation.
        /// </summary>
        PendingCopyOperation,

        /// <summary>
        /// The source of the copy is inaccessible.
        /// </summary>
        CannotVerifyCopySource,

        /// <summary>
        /// The destination of a copy operation must not have an active lease of fixed duration.
        /// </summary>
        InfiniteLeaseDurationRequired
    }
}

//-----------------------------------------------------------------------
// <copyright file="BlobErrorCodeStrings.cs" company="Microsoft">
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
//    Contains code for the BlobErrorCodeStrings class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    /// <summary>
    /// Provides error code strings that are specific to the Blob service.
    /// </summary>
    public static class BlobErrorCodeStrings
    {
        /// <summary>
        /// Error code that may be returned when a block ID is invalid.
        /// </summary>
        public const string InvalidBlockId = "InvalidBlockId";

        /// <summary>
        /// Error code that may be returned when a blob with the specified address cannot be found.
        /// </summary>
        public const string BlobNotFound = "BlobNotFound";

        /// <summary>
        /// Error code that may be returned when a client attempts to create a blob that already exists.
        /// </summary>
        public const string BlobAlreadyExists = "BlobAlreadyExists";

        /// <summary>
        /// Error code that may be returned when the specified block or blob is invalid.
        /// </summary>
        public const string InvalidBlobOrBlock = "InvalidBlobOrBlock";

        /// <summary>
        /// Error code that may be returned when a block list is invalid.
        /// </summary>
        public const string InvalidBlockList = "InvalidBlockList";

        /// <summary>
        /// Error code that may be returned when there is currently no lease on the blob.
        /// </summary>
        public const string LeaseNotPresentWithBlobOperation = "LeaseNotPresentWithBlobOperation";

        /// <summary>
        /// Error code that may be returned when there is currently no lease on the container.
        /// </summary>
        public const string LeaseNotPresentWithContainerOperation = "LeaseNotPresentWithContainerOperation";

        /// <summary>
        /// Error code that may be returned when a lease ID was specified, but the lease has expired.
        /// </summary>
        public const string LeaseLost = "LeaseLost";

        /// <summary>
        /// Error code that may be returned when the lease ID specified did not match the lease ID for the blob.
        /// </summary>
        public const string LeaseIdMismatchWithBlobOperation = "LeaseIdMismatchWithBlobOperation";

        /// <summary>
        /// Error code that may be returned when the lease ID specified did not match the lease ID for the container.
        /// </summary>
        public const string LeaseIdMismatchWithContainerOperation = "LeaseIdMismatchWithContainerOperation";

        /// <summary>
        /// Error code that may be returned when there is currently a lease on the resource and no lease ID was specified in the request.
        /// </summary>
        public const string LeaseIdMissing = "LeaseIdMissing";

        /// <summary>
        /// Error code that may be returned when there is currently no lease on the resource.
        /// </summary>
        public const string LeaseNotPresentWithLeaseOperation = "LeaseNotPresentWithLeaseOperation";

        /// <summary>
        /// Error code that may be returned when the lease ID specified did not match the lease ID.
        /// </summary>
        public const string LeaseIdMismatchWithLeaseOperation = "LeaseIdMismatchWithLeaseOperation";

        /// <summary>
        /// Error code that may be returned when there is already a lease present.
        /// </summary>
        public const string LeaseAlreadyPresent = "LeaseAlreadyPresent";

        /// <summary>
        /// Error code that may be returned when the lease has already been broken and cannot be broken again.
        /// </summary>
        public const string LeaseAlreadyBroken = "LeaseAlreadyBroken";

        /// <summary>
        /// Error code that may be returned when the lease ID matched, but the lease has been broken explicitly and cannot be renewed.
        /// </summary>
        public const string LeaseIsBrokenAndCannotBeRenewed = "LeaseIsBrokenAndCannotBeRenewed";

        /// <summary>
        /// Error code that may be returned when the lease ID matched, but the lease is breaking and cannot be acquired.
        /// </summary>
        public const string LeaseIsBreakingAndCannotBeAcquired = "LeaseIsBreakingAndCannotBeAcquired";

        /// <summary>
        /// Error code that may be returned when the lease ID matched, but the lease is breaking and cannot be changed.
        /// </summary>
        public const string LeaseIsBreakingAndCannotBeChanged = "LeaseIsBreakingAndCannotBeChanged";

        /// <summary>
        /// Error code that may be returned when the copy ID specified in an Abort Copy operation does not match the current pending copy ID.
        /// </summary>
        public const string CopyIdMismatch = "CopyIdMismatch";

        /// <summary>
        /// Error code that may be returned when an Abort Copy operation is called when there is no pending copy.
        /// </summary>
        public const string NoPendingCopyOperation = "NoPendingCopyOperation";

        /// <summary>
        /// Error code that may be returned when an attempt to modify the destination of a pending copy is made.
        /// </summary>
        public const string PendingCopyOperation = "PendingCopyOperation";

        /// <summary>
        /// Error code that may be returned when the source of a copy cannot be accessed.
        /// </summary>
        public const string CannotVerifyCopySource = "CannotVerifyCopySource";

        /// <summary>
        /// Error code that may be returned when the destination of a copy operation has a lease of fixed duration.
        /// </summary>
        public const string InfiniteLeaseDurationRequired = "InfiniteLeaseDurationRequired";
    }
}
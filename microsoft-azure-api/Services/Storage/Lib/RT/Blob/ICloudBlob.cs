// -----------------------------------------------------------------------------------------
// <copyright file="ICloudBlob.cs" company="Microsoft">
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Storage;
    using Windows.Storage.Streams;

    /// <summary>
    /// An interface required for Windows Azure blob types. The <see cref="CloudBlockBlob"/> and <see cref="CloudPageBlob"/> classes implement the <see cref="ICloudBlob"/> interface.
    /// </summary>
    public partial interface ICloudBlob : IListBlobItem, IRandomAccessStreamReference
    {
        /// <summary>
        /// Opens a stream for reading from the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A stream to be used for reading from the blob.</returns>
        IAsyncOperation<IRandomAccessStreamWithContentType> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Uploads a stream to the Windows Azure Blob Service. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromStreamAsync(IInputStream source);

        /// <summary>
        /// Uploads a stream to a blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromStreamAsync(IInputStream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Uploads a stream to a blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromStreamAsync(IInputStream source, long length);

        /// <summary>
        /// Uploads a stream to a blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromStreamAsync(IInputStream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        
        /// Uploads a file to the Windows Azure Blob Service. 
        /// </summary>
        /// <param name="source">The file providing the blob content.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromFileAsync(StorageFile source);

        /// <summary>
        /// Uploads a file to a blob. 
        /// </summary>
        /// <param name="source">The file providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromFileAsync(StorageFile source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Uploads the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromByteArrayAsync([ReadOnlyArray] byte[] buffer, int index, int count);

        /// <summary>
        /// Uploads the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction UploadFromByteArrayAsync([ReadOnlyArray] byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DownloadToStreamAsync(IOutputStream target);

        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DownloadToStreamAsync(IOutputStream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Downloads the contents of a blob to a file.
        /// </summary>
        /// <param name="target">The target file.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DownloadToFileAsync(StorageFile target);

        /// <summary>
        /// Downloads the contents of a blob to a file.
        /// </summary>
        /// <param name="target">The target file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DownloadToFileAsync(StorageFile target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Downloads a range of bytes from a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        IAsyncOperation<int> DownloadToByteArrayAsync([WriteOnlyArray] byte[] target, int index);       

        /// <summary>
        /// Downloads a range of bytes from a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        IAsyncOperation<int> DownloadToByteArrayAsync([WriteOnlyArray] byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Downloads a range of bytes from a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data range, in bytes.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DownloadRangeToStreamAsync(IOutputStream target, long? offset, long? length);

        /// <summary>
        /// Downloads a range of bytes from a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data range, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DownloadRangeToStreamAsync(IOutputStream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Downloads a range of bytes from a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data range, in bytes.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        IAsyncOperation<int> DownloadRangeToByteArrayAsync([WriteOnlyArray] byte[] target, int index, long? blobOffset, long? length);
       
        /// <summary>
        /// Downloads a range of bytes from a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data range, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        IAsyncOperation<int> DownloadRangeToByteArrayAsync([WriteOnlyArray] byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Checks whether the blob exists.
        /// </summary>
        /// <returns><c>true</c> if the blob exists.</returns>
        IAsyncOperation<bool> ExistsAsync();

        /// <summary>
        /// Checks whether the blob exists.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the blob exists.</returns>
        IAsyncOperation<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Populates a blob's properties and metadata.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction FetchAttributesAsync();

        /// <summary>
        /// Populates a blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Updates the blob's metadata.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction SetMetadataAsync();

        /// <summary>
        /// Updates the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Updates the blob's properties.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction SetPropertiesAsync();

        /// <summary>
        /// Updates the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Deletes the blob.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DeleteAsync();

        /// <summary>
        /// Deletes the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Deletes the blob if it already exists.
        /// </summary>
        /// <returns><c>true</c> if the blob did not already exist and was created; otherwise <c>false</c>.</returns>
        IAsyncOperation<bool> DeleteIfExistsAsync();

        /// <summary>
        /// Deletes the blob if it already exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the blob did not already exist and was created; otherwise <c>false</c>.</returns>
        IAsyncOperation<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Acquires a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease.</param>
        /// <returns>The ID of the acquired lease.</returns>
        IAsyncOperation<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId);

        /// <summary>
        /// Acquires a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The ID of the acquired lease.</returns>
        IAsyncOperation<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Renews a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction RenewLeaseAsync(AccessCondition accessCondition);

        /// <summary>
        /// Renews a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Changes the lease ID on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>The new lease ID.</returns>
        IAsyncOperation<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition);

        /// <summary>
        /// Changes the lease ID on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The new lease ID.</returns>
        IAsyncOperation<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Releases the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction ReleaseLeaseAsync(AccessCondition accessCondition);

        /// <summary>
        /// Releases the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Breaks the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        IAsyncOperation<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod);

        /// <summary>
        /// Breaks the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        IAsyncOperation<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Aborts an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction AbortCopyAsync(string copyId);

        /// <summary>
        /// Aborts an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        IAsyncAction AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
    }
}

// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlockBlob.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Blob.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.Foundation.Metadata;
    using Windows.Storage;
    using Windows.Storage.Streams;

    /// <summary>
    /// Represents a blob that is uploaded as a set of blocks.
    /// </summary>
    public sealed partial class CloudBlockBlob : ICloudBlob
    {
        /// <summary>
        /// Opens a stream for reading from the blob.
        /// </summary>
        /// <returns>A stream to be used for reading from the blob.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IRandomAccessStreamWithContentType> OpenReadAsync()
        {
            return this.OpenReadAsync(null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Opens a stream for reading from the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A stream to be used for reading from the blob.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IRandomAccessStreamWithContentType> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return AsyncInfo.Run<IRandomAccessStreamWithContentType>(async (token) =>
            {
                await this.FetchAttributesAsync(accessCondition, options, operationContext).AsTask(token);
                AccessCondition streamAccessCondition = AccessCondition.CloneConditionWithETag(accessCondition, this.Properties.ETag);
                BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, this.BlobType, this.ServiceClient, false);
                return new BlobReadStreamHelper(this, streamAccessCondition, modifiedOptions, operationContext);
            });
        }

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <returns>A stream to be used for writing to the blob.</returns>
        public IAsyncOperation<ICloudBlobStream> OpenWriteAsync()
        {
            return this.OpenWriteAsync(null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A stream to be used for writing to the blob.</returns>
        public IAsyncOperation<ICloudBlobStream> OpenWriteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.attributes.AssertNoSnapshot();
            operationContext = operationContext ?? new OperationContext();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, this.BlobType, this.ServiceClient, false);

            if ((accessCondition != null) && accessCondition.IsConditional)
            {
                return AsyncInfo.Run(async (token) =>
                {
                    try
                    {
                        await this.FetchAttributesAsync(accessCondition, options, operationContext).AsTask(token);
                    }
                    catch (Exception)
                    {
                        if ((operationContext.LastResult != null) &&
                            (operationContext.LastResult.HttpStatusCode == (int)HttpStatusCode.NotFound) &&
                            string.IsNullOrEmpty(accessCondition.IfMatchETag))
                        {
                            // If we got a 404 and the condition was not an If-Match,
                            // we should continue with the operation.
                        }
                        else
                        {
                            throw;
                        }
                    }

                    ICloudBlobStream stream = new BlobWriteStreamHelper(this, accessCondition, modifiedOptions, operationContext);
                    return stream;
                });
            }
            else
            {
                ICloudBlobStream stream = new BlobWriteStreamHelper(this, accessCondition, modifiedOptions, operationContext);
                return Task.FromResult(stream).AsAsyncOperation();
            }
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadFromStreamAsync(IInputStream source)
        {
            return this.UploadFromStreamAsyncHelper(source, null /* length*/, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadFromStreamAsync(IInputStream source, long length)
        {
            return this.UploadFromStreamAsyncHelper(source, length, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadFromStreamAsync(IInputStream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.UploadFromStreamAsyncHelper(source, null /* length */, accessCondition, options, operationContext);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadFromStreamAsync(IInputStream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.UploadFromStreamAsyncHelper(source, length, accessCondition, options, operationContext);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        internal IAsyncAction UploadFromStreamAsyncHelper(IInputStream source, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("source", source);

            Stream sourceAsStream = source.AsStreamForRead();

            if (length.HasValue)
            {
                CommonUtility.AssertInBounds("length", length.Value, 1);

                if (sourceAsStream.CanSeek && length > sourceAsStream.Length - sourceAsStream.Position)
                {
                    throw new ArgumentOutOfRangeException("length", SR.StreamLengthShortError);
                }
            }

            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();
            ExecutionState<NullType> tempExecutionState = CommonUtility.CreateTemporaryExecutionState(modifiedOptions);

            return AsyncInfo.Run(async (token) =>
            {
                bool lessThanSingleBlobThreshold = sourceAsStream.CanSeek
                                                   && (length ?? sourceAsStream.Length - sourceAsStream.Position)
                                                   <= this.ServiceClient.SingleBlobUploadThresholdInBytes;
                if (this.ServiceClient.ParallelOperationThreadCount == 1 && lessThanSingleBlobThreshold)
                {
                    string contentMD5 = null;
                    if (modifiedOptions.StoreBlobContentMD5.Value)
                    {
                        StreamDescriptor streamCopyState = new StreamDescriptor();
                        long startPosition = sourceAsStream.Position;
                        await sourceAsStream.WriteToAsync(Stream.Null, length, null /* maxLength */, true, tempExecutionState, streamCopyState, token);
                        sourceAsStream.Position = startPosition;
                        contentMD5 = streamCopyState.Md5;
                    }
                    else
                    {
                        if (modifiedOptions.UseTransactionalMD5.Value)
                        {
                            throw new ArgumentException(SR.PutBlobNeedsStoreBlobContentMD5, "options");
                        }
                    }

                    await Executor.ExecuteAsyncNullReturn(
                        this.PutBlobImpl(sourceAsStream, length, contentMD5, accessCondition, modifiedOptions),
                        modifiedOptions.RetryPolicy,
                        operationContext,
                        token);
                }
                else
                {
                    using (ICloudBlobStream blobStream = await this.OpenWriteAsync(accessCondition, options, operationContext).AsTask(token))
                    {
                        // We should always call AsStreamForWrite with bufferSize=0 to prevent buffering. Our
                        // stream copier only writes 64K buffers at a time anyway, so no buffering is needed.
                        await sourceAsStream.WriteToAsync(blobStream.AsStreamForWrite(0), length, null /* maxLength */, false, tempExecutionState, null /* streamCopyState */, token);
                        await blobStream.CommitAsync().AsTask(token);
                    }
                }
            });
        }

        /// <summary>
        /// Uploads a file to the Windows Azure Blob Service. 
        /// </summary>
        /// <param name="source">The file providing the blob content.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadFromFileAsync(StorageFile source)
        {
            return this.UploadFromFileAsync(source, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Uploads a file to a blob. 
        /// </summary>
        /// <param name="source">The file providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadFromFileAsync(StorageFile source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("source", source);

            return AsyncInfo.Run(async (token) =>
            {
                using (IRandomAccessStreamWithContentType stream = await source.OpenReadAsync().AsTask(token))
                {
                    await this.UploadFromStreamAsync(stream, accessCondition, options, operationContext).AsTask(token);
                }
            });
        }

        /// <summary>
        /// Uploads the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadFromByteArrayAsync([ReadOnlyArray] byte[] buffer, int index, int count)
        {
            return this.UploadFromByteArrayAsync(buffer, index, count, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

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
        [DoesServiceRequest]
        public IAsyncAction UploadFromByteArrayAsync([ReadOnlyArray] byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("buffer", buffer);

            SyncMemoryStream stream = new SyncMemoryStream(buffer, index, count);
            return this.UploadFromStreamAsync(stream.AsInputStream(), accessCondition, options, operationContext);
        }

        /// <summary>
        /// Uploads a string of text to a blob. 
        /// </summary>
        /// <param name="content">The text to upload, encoded as a UTF-8 string.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadTextAsync(string content)
        {
            return this.UploadTextAsync(content, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Uploads a string of text to a blob. 
        /// </summary>
        /// <param name="content">The text to upload, encoded as a UTF-8 string.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UploadTextAsync(string content, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("content", content);

            byte[] contentAsBytes = Encoding.UTF8.GetBytes(content);
            return this.UploadFromByteArrayAsync(contentAsBytes, 0, contentAsBytes.Length, accessCondition, options, operationContext);
        }

        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DownloadToStreamAsync(IOutputStream target)
        {
            return this.DownloadToStreamAsync(target, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DownloadToStreamAsync(IOutputStream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadRangeToStreamAsync(target, null /* offset */, null /* length */, accessCondition, options, operationContext);
        }

        /// <summary>
        /// Downloads the contents of a blob to a file.
        /// </summary>
        /// <param name="target">The target file.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DownloadToFileAsync(StorageFile target)
        {
            return this.DownloadToFileAsync(target, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Downloads the contents of a blob to a file.
        /// </summary>
        /// <param name="target">The target file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DownloadToFileAsync(StorageFile target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("target", target);

            return AsyncInfo.Run(async (token) =>
            {
                using (StorageStreamTransaction transaction = await target.OpenTransactedWriteAsync().AsTask(token))
                {
                    await this.DownloadToStreamAsync(transaction.Stream, accessCondition, options, operationContext).AsTask(token);
                    await transaction.CommitAsync();
                }
            });
        }

        /// <summary>
        /// Downloads the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<int> DownloadToByteArrayAsync([WriteOnlyArray] byte[] target, int index)
        {
            return this.DownloadToByteArrayAsync(target, index, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Downloads the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<int> DownloadToByteArrayAsync([WriteOnlyArray] byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadRangeToByteArrayAsync(target, index, null /* blobOffset */, null /* length */, accessCondition, options, operationContext);
        }

        /// <summary>
        /// Downloads a range of bytes from a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DownloadRangeToStreamAsync(IOutputStream target, long? offset, long? length)
        {
            return this.DownloadRangeToStreamAsync(target, offset, length, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Downloads the blob's contents as a string.
        /// </summary>
        /// <returns>The contents of the blob, as a string.</returns>
        public IAsyncOperation<string> DownloadTextAsync()
        {
            return this.DownloadTextAsync(null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Downloads the blob's contents as a string.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The contents of the blob, as a string.</returns>
        public IAsyncOperation<string> DownloadTextAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return AsyncInfo.Run(async (token) =>
            {
                using (SyncMemoryStream stream = new SyncMemoryStream())
                {
                    await this.DownloadToStreamAsync(stream.AsOutputStream(), accessCondition, options, operationContext).AsTask(token);
                    byte[] streamAsBytes = stream.ToArray();
                    return Encoding.UTF8.GetString(streamAsBytes, 0, streamAsBytes.Length);
                }
            });
        }

        /// <summary>
        /// Downloads a range of bytes from a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DownloadRangeToStreamAsync(IOutputStream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("target", target);

            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);

            // We should always call AsStreamForWrite with bufferSize=0 to prevent buffering. Our
            // stream copier only writes 64K buffers at a time anyway, so no buffering is needed.
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.GetBlobImpl(this, this.attributes, target.AsStreamForWrite(0), offset, length, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Downloads a range of bytes from a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data range, in bytes.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<int> DownloadRangeToByteArrayAsync([WriteOnlyArray] byte[] target, int index, long? blobOffset, long? length)
        {
            return this.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

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
        [DoesServiceRequest]
        public IAsyncOperation<int> DownloadRangeToByteArrayAsync([WriteOnlyArray] byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return AsyncInfo.Run(async (token) =>
            {
                using (SyncMemoryStream stream = new SyncMemoryStream(target, index))
                {
                    await this.DownloadRangeToStreamAsync(stream.AsOutputStream(), blobOffset, length, accessCondition, options, operationContext).AsTask(token);
                    return (int)stream.Position;
                }
            });
        }

        /// <summary>
        /// Checks existence of the blob.
        /// </summary>
        /// <returns><c>true</c> if the blob exists.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> ExistsAsync()
        {
            return this.ExistsAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Checks existence of the blob.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the blob exists.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                CloudBlobSharedImpl.ExistsImpl(this, this.attributes, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Populates a blob's properties and metadata.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction FetchAttributesAsync()
        {
            return this.FetchAttributesAsync(null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Populates a blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.FetchAttributesImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Updates the blob's metadata.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetMetadataAsync()
        {
            return this.SetMetadataAsync(null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Updates the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.SetMetadataImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Updates the blob's properties.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetPropertiesAsync()
        {
            return this.SetPropertiesAsync(null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Updates the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.SetPropertiesImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Deletes the blob.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteAsync()
        {
            return this.DeleteAsync(DeleteSnapshotsOption.None, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Deletes the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.DeleteBlobImpl(this, this.attributes, deleteSnapshotsOption, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Deletes the blob if it already exists.
        /// </summary>
        /// <returns><c>true</c> if the blob already existed and was deleted; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> DeleteIfExistsAsync()
        {
            return this.DeleteIfExistsAsync(DeleteSnapshotsOption.None, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Deletes the blob if it already exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the blob already existed and was deleted; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, this.BlobType, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) =>
            {
                bool exists = await this.ExistsAsync(modifiedOptions, operationContext).AsTask(token);

                if (!exists)
                {
                    return false;
                }

                try
                {
                    await this.DeleteAsync(deleteSnapshotsOption, accessCondition, modifiedOptions, operationContext).AsTask(token);
                    return true;
                }
                catch (Exception)
                {
                    if (operationContext.LastResult.HttpStatusCode == (int)HttpStatusCode.NotFound)
                    {
                        StorageExtendedErrorInformation extendedInfo = operationContext.LastResult.ExtendedErrorInformation;
                        if ((extendedInfo == null) ||
                            (extendedInfo.ErrorCode == BlobErrorCodeStrings.BlobNotFound))
                        {
                            return false;
                        }
                        else
                        {
                            throw;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            });
        }

        /// <summary>
        /// Creates a snapshot of the blob.
        /// </summary>
        /// <returns>A blob snapshot.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<CloudBlockBlob> CreateSnapshotAsync()
        {
            return this.CreateSnapshotAsync(null /* metadata */, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Creates a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An object that specifies additional options for the request, or <c>null</c>.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>A blob snapshot.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<CloudBlockBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.CreateSnapshotImpl(metadata, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Acquires a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <returns>The ID of the acquired lease.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId)
        {
            return this.AcquireLeaseAsync(leaseTime, proposedLeaseId, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Acquires a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The ID of the acquired lease.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                CloudBlobSharedImpl.AcquireLeaseImpl(this, this.attributes, leaseTime, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Renews a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction RenewLeaseAsync(AccessCondition accessCondition)
        {
            return this.RenewLeaseAsync(accessCondition, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Renews a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.RenewLeaseImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Changes the lease ID on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>The new lease ID.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.ChangeLeaseAsync(proposedLeaseId, accessCondition, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Changes the lease ID on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The new lease ID.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                CloudBlobSharedImpl.ChangeLeaseImpl(this, this.attributes, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Releases the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            return this.ReleaseLeaseAsync(accessCondition, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Releases the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.ReleaseLeaseImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Breaks the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            return this.BreakLeaseAsync(breakPeriod, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Breaks the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                CloudBlobSharedImpl.BreakLeaseImpl(this, this.attributes, breakPeriod, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Uploads a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction PutBlockAsync(string blockId, IInputStream blockData, string contentMD5)
        {
            return this.PutBlockAsync(blockId, blockData, contentMD5, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Uploads a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction PutBlockAsync(string blockId, IInputStream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            bool requiresContentMD5 = (contentMD5 == null) && modifiedOptions.UseTransactionalMD5.Value;
            operationContext = operationContext ?? new OperationContext();
            ExecutionState<NullType> tempExecutionState = CommonUtility.CreateTemporaryExecutionState(modifiedOptions);

            return AsyncInfo.Run(async (token) =>
            {
                Stream blockDataAsStream = blockData.AsStreamForRead();
                Stream seekableStream = blockDataAsStream;
                if (!blockDataAsStream.CanSeek || requiresContentMD5)
                {
                    Stream writeToStream;
                    if (blockDataAsStream.CanSeek)
                    {
                        writeToStream = Stream.Null;
                    }
                    else
                    {
                        seekableStream = new MultiBufferMemoryStream(this.ServiceClient.BufferManager);
                        writeToStream = seekableStream;
                    }

                    StreamDescriptor streamCopyState = new StreamDescriptor();
                    long startPosition = seekableStream.Position;
                    await blockDataAsStream.WriteToAsync(writeToStream, null /* copyLength */, Constants.MaxBlockSize, requiresContentMD5, tempExecutionState, streamCopyState, token);
                    seekableStream.Position = startPosition;

                    if (requiresContentMD5)
                    {
                        contentMD5 = streamCopyState.Md5;
                    }
                }

                await Executor.ExecuteAsyncNullReturn(
                    this.PutBlockImpl(seekableStream, blockId, contentMD5, accessCondition, modifiedOptions),
                    modifiedOptions.RetryPolicy,
                    operationContext,
                    token);
            });
        }

        /// <summary>
        /// Uploads a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction PutBlockListAsync(IEnumerable<string> blockList)
        {
            return this.PutBlockListAsync(blockList, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Uploads a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction PutBlockListAsync(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            IEnumerable<PutBlockListItem> items = blockList.Select(i => new PutBlockListItem(i, BlockSearchMode.Latest));
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.PutBlockListImpl(items, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Returns an enumerable collection of the committed blocks comprising the blob.
        /// </summary>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IEnumerable<ListBlockItem>> DownloadBlockListAsync()
        {
            return this.DownloadBlockListAsync(BlockListingFilter.Committed, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Returns an enumerable collection of the blob's blocks, using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IEnumerable<ListBlockItem>> DownloadBlockListAsync(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.GetBlockListImpl(blockListingFilter, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Requests that the service start to copy an existing blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        [DoesServiceRequest]
        [DefaultOverload]
        public IAsyncOperation<string> StartCopyFromBlobAsync(Uri source)
        {
            return this.StartCopyFromBlobAsync(source, null /* sourceAccessCondition */, null /* destAccessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Requests that the service start to copy an existing blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        [DoesServiceRequest]
        public IAsyncOperation<string> StartCopyFromBlobAsync(CloudBlockBlob source)
        {
            return this.StartCopyFromBlobAsync(CloudBlobSharedImpl.SourceBlobToUri(source));
        }

        /// <summary>
        /// Requests that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        [DoesServiceRequest]
        [DefaultOverload]
        public IAsyncOperation<string> StartCopyFromBlobAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("source", source);
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                CloudBlobSharedImpl.StartCopyFromBlobImpl(this, this.attributes, source, sourceAccessCondition, destAccessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Requests that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        [DoesServiceRequest]
        public IAsyncOperation<string> StartCopyFromBlobAsync(CloudBlockBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.StartCopyFromBlobAsync(CloudBlobSharedImpl.SourceBlobToUri(source), sourceAccessCondition, destAccessCondition, options, operationContext);
        }

        /// <summary>
        /// Aborts an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction AbortCopyAsync(string copyId)
        {
            return this.AbortCopyAsync(copyId, null /* accessCondition */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Aborts an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An asynchronous handler called when the operation is complete.</returns>
        [DoesServiceRequest]
        public IAsyncAction AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                CloudBlobSharedImpl.AbortCopyImpl(this, this.attributes, copyId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Implementation for the CreateSnapshot method.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot, or null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that creates the snapshot.</returns>
        /// <remarks>If the <c>metadata</c> parameter is <c>null</c> then no metadata is associated with the request.</remarks>
        internal RESTCommand<CloudBlockBlob> CreateSnapshotImpl(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<CloudBlockBlob> putCmd = new RESTCommand<CloudBlockBlob>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) =>
            {
                HttpRequestMessage msg = BlobHttpRequestMessageFactory.Snapshot(cmd.Uri, cmd.ServerTimeoutInSeconds, accessCondition, cnt, ctx);
                if (metadata != null)
                {
                    BlobHttpRequestMessageFactory.AddMetadata(msg, metadata);
                }

                return msg;
            };

            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, null /* retVal */, cmd, ex);
                DateTimeOffset snapshotTime = NavigationHelper.ParseSnapshotTime(BlobHttpResponseParsers.GetSnapshotTime(resp));
                CloudBlockBlob snapshot = new CloudBlockBlob(this.Name, snapshotTime, this.Container);
                snapshot.attributes.Metadata = new Dictionary<string, string>(metadata ?? this.Metadata);
                snapshot.attributes.Properties = new BlobProperties(this.Properties);
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(snapshot.attributes, resp);
                return snapshot;
            };

            return putCmd;
        }

        /// <summary>
        /// Uploads the full blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="SynchronousTask"/> that gets the stream.</returns>
        private RESTCommand<NullType> PutBlobImpl(Stream stream, long? length, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options)
        {
            long offset = stream.Position;
            length = length ?? stream.Length - offset;
            this.Properties.ContentMD5 = contentMD5;

            CappedLengthReadOnlyStream cappedStream = new CappedLengthReadOnlyStream(stream, length.Value + offset);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(cappedStream, offset, length, null /* md5 */, cmd, ctx);
            putCmd.BuildRequest = (cmd, cnt, ctx) =>
            {
                HttpRequestMessage msg = BlobHttpRequestMessageFactory.Put(cmd.Uri, cmd.ServerTimeoutInSeconds, this.Properties, BlobType.BlockBlob, 0, accessCondition, cnt, ctx);
                BlobHttpRequestMessageFactory.AddMetadata(msg, this.Metadata);
                return msg;
            };
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(this.attributes, resp);
                this.Properties.Length = length.Value;
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Uploads the block.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="blockId">The block ID.</param>
        /// <param name="contentMD5">The content MD5.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that uploads the block.</returns>
        internal RESTCommand<NullType> PutBlockImpl(Stream source, string blockId, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options)
        {
            long offset = source.Position;
            long length = source.Length - offset;

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(source, offset, length, contentMD5, cmd, ctx);
            putCmd.BuildRequest = (cmd, cnt, ctx) => BlobHttpRequestMessageFactory.PutBlock(cmd.Uri, cmd.ServerTimeoutInSeconds, blockId, accessCondition, cnt, ctx);
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Uploads the block list.
        /// </summary>
        /// <param name="blocks">The blocks to upload.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that uploads the block list.</returns>
        internal RESTCommand<NullType> PutBlockListImpl(IEnumerable<PutBlockListItem> blocks, AccessCondition accessCondition, BlobRequestOptions options)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            BlobRequest.WriteBlockListBody(blocks, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            string contentMD5 = memoryStream.ComputeMD5Hash();

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, contentMD5, cmd, ctx);
            putCmd.BuildRequest = (cmd, cnt, ctx) =>
            {
                HttpRequestMessage msg = BlobHttpRequestMessageFactory.PutBlockList(cmd.Uri, cmd.ServerTimeoutInSeconds, this.Properties, accessCondition, cnt, ctx);
                BlobHttpRequestMessageFactory.AddMetadata(msg, this.Metadata);
                return msg;
            };
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(this.attributes, resp);
                this.Properties.Length = -1;
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Gets the download block list.
        /// </summary>
        /// <param name="typesOfBlocks">The types of blocks.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the download block list.</returns>
        internal RESTCommand<IEnumerable<ListBlockItem>> GetBlockListImpl(BlockListingFilter typesOfBlocks, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<IEnumerable<ListBlockItem>> getCmd = new RESTCommand<IEnumerable<ListBlockItem>>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.BuildRequest = (cmd, cnt, ctx) => BlobHttpRequestMessageFactory.GetBlockList(cmd.Uri, cmd.ServerTimeoutInSeconds, this.SnapshotTime, typesOfBlocks, accessCondition, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(this.attributes, resp);
                return Task.Factory.StartNew(() =>
                {
                    GetBlockListResponse responseParser = new GetBlockListResponse(cmd.ResponseStream);
                    IEnumerable<ListBlockItem> blocks = new List<ListBlockItem>(responseParser.Blocks);
                    return blocks;
                });
            };

            return getCmd;
        }
    }
}

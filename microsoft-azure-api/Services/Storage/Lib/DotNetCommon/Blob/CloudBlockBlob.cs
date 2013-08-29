//-----------------------------------------------------------------------
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using Microsoft.WindowsAzure.Storage.Blob.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a blob that is uploaded as a set of blocks.
    /// </summary>
    public sealed partial class CloudBlockBlob : ICloudBlob
    {
#if SYNC
        /// <summary>
        /// Opens a stream for reading from the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A stream to be used for reading from the blob.</returns>
        /// <remarks>On the <see cref="System.IO.Stream"/> object returned by this method, the <see cref="System.IO.Stream.EndRead(IAsyncResult)"/> method must be called exactly once for every <see cref="System.IO.Stream.BeginRead(byte[], int, int, AsyncCallback, Object)"/> call. Failing to end a read process before beginning another read can cause unknown behavior.</remarks>
        [DoesServiceRequest]
        public Stream OpenRead(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.FetchAttributes(accessCondition, options, operationContext);
            AccessCondition streamAccessCondition = AccessCondition.CloneConditionWithETag(accessCondition, this.Properties.ETag);
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, this.BlobType, this.ServiceClient, false);
            return new BlobReadStream(this, streamAccessCondition, modifiedOptions, operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to open a stream for reading from the blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginOpenRead(AsyncCallback callback, object state)
        {
            return this.BeginOpenRead(null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to open a stream for reading from the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginOpenRead(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            StorageAsyncResult<Stream> storageAsyncResult = new StorageAsyncResult<Stream>(callback, state);

            ICancellableAsyncResult result = this.BeginFetchAttributes(
                accessCondition,
                options,
                operationContext,
                ar =>
                {
                    try
                    {
                        this.EndFetchAttributes(ar);
                        storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);
                        AccessCondition streamAccessCondition = AccessCondition.CloneConditionWithETag(accessCondition, this.Properties.ETag);
                        BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, this.BlobType, this.ServiceClient, false);
                        storageAsyncResult.Result = new BlobReadStream(this, streamAccessCondition, modifiedOptions, operationContext);
                        storageAsyncResult.OnComplete();
                    }
                    catch (Exception e)
                    {
                        storageAsyncResult.OnComplete(e);
                    }
                },
                null /* state */);

            storageAsyncResult.CancelDelegate = result.Cancel;
            return storageAsyncResult;
        }

        /// <summary>
        /// Ends an asynchronous operation to open a stream for reading from the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A stream to be used for reading from the blob.</returns>
        public Stream EndOpenRead(IAsyncResult asyncResult)
        {
            StorageAsyncResult<Stream> storageAsyncResult = (StorageAsyncResult<Stream>)asyncResult;
            storageAsyncResult.End();
            return storageAsyncResult.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for reading from the blob.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<Stream> OpenReadAsync()
        {
            return this.OpenReadAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for reading from the blob.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginOpenRead, this.EndOpenRead, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for reading from the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.OpenReadAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for reading from the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginOpenRead, this.EndOpenRead, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A stream to be used for writing to the blob.</returns>
        public CloudBlobStream OpenWrite(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, this.BlobType, this.ServiceClient, false);

            if ((accessCondition != null) && accessCondition.IsConditional)
            {
                try
                {
                    this.FetchAttributes(accessCondition, options, operationContext);
                }
                catch (StorageException e)
                {
                    if ((e.RequestInformation != null) &&
                        (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound) &&
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
            }

            return new BlobWriteStream(this, accessCondition, modifiedOptions, operationContext);
        }

#endif

        /// <summary>
        /// Begins an asynchronous operation to open a stream for writing to the blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginOpenWrite(AsyncCallback callback, object state)
        {
            return this.BeginOpenWrite(null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to open a stream for writing to the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginOpenWrite(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            this.attributes.AssertNoSnapshot();

            StorageAsyncResult<CloudBlobStream> storageAsyncResult = new StorageAsyncResult<CloudBlobStream>(callback, state);
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, this.BlobType, this.ServiceClient, false);

            if ((accessCondition != null) && accessCondition.IsConditional)
            {
                ICancellableAsyncResult result = this.BeginFetchAttributes(
                    accessCondition,
                    options,
                    operationContext,
                    ar =>
                    {
                        storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

                        try
                        {
                            this.EndFetchAttributes(ar);
                        }
                        catch (StorageException e)
                        {
                            if ((e.RequestInformation != null) &&
                                (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound) &&
                                string.IsNullOrEmpty(accessCondition.IfMatchETag))
                            {
                                // If we got a 404 and the condition was not an If-Match,
                                // we should continue with the operation.
                            }
                            else
                            {
                                storageAsyncResult.OnComplete(e);
                                return;
                            }
                        }
                        catch (Exception e)
                        {
                            storageAsyncResult.OnComplete(e);
                            return;
                        }

                        storageAsyncResult.Result = new BlobWriteStream(this, accessCondition, modifiedOptions, operationContext);
                        storageAsyncResult.OnComplete();
                    },
                    null /* state */);

                storageAsyncResult.CancelDelegate = result.Cancel;
            }
            else
            {
                storageAsyncResult.Result = new BlobWriteStream(this, accessCondition, modifiedOptions, operationContext);
                storageAsyncResult.OnComplete();
            }

            return storageAsyncResult;
        }

        /// <summary>
        /// Ends an asynchronous operation to open a stream for writing to the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A stream to be used for writing to the blob.</returns>
        public CloudBlobStream EndOpenWrite(IAsyncResult asyncResult)
        {
            StorageAsyncResult<CloudBlobStream> storageAsyncResult = (StorageAsyncResult<CloudBlobStream>)asyncResult;
            storageAsyncResult.End();
            return storageAsyncResult.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for writing to the blob.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlobStream> OpenWriteAsync()
        {
            return this.OpenWriteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for writing to the blob.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlobStream> OpenWriteAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginOpenWrite, this.EndOpenWrite, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for writing to the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlobStream> OpenWriteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.OpenWriteAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to open a stream for writing to the blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlobStream> OpenWriteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginOpenWrite, this.EndOpenWrite, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void UploadFromStream(Stream source, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.UploadFromStreamHelper(source, null /* length */, accessCondition, options, operationContext);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void UploadFromStream(Stream source, long length, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.UploadFromStreamHelper(source, length, accessCondition, options, operationContext);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        internal void UploadFromStreamHelper(Stream source, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CommonUtility.AssertNotNull("source", source);

            if (length.HasValue)
            {
                CommonUtility.AssertInBounds("length", length.Value, 1);

                if (source.CanSeek && length > source.Length - source.Position)
                {
                    throw new ArgumentOutOfRangeException("length", SR.StreamLengthShortError);
                }
            }

            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            bool lessThanSingleBlobThreshold = source.CanSeek
                                               && (length ?? source.Length - source.Position)
                                               <= this.ServiceClient.SingleBlobUploadThresholdInBytes;
            if (this.ServiceClient.ParallelOperationThreadCount == 1 && lessThanSingleBlobThreshold)
            {
                string contentMD5 = null;
                if (modifiedOptions.StoreBlobContentMD5.Value)
                {
                    using (ExecutionState<NullType> tempExecutionState = CommonUtility.CreateTemporaryExecutionState(modifiedOptions))
                    {
                        StreamDescriptor streamCopyState = new StreamDescriptor();
                        long startPosition = source.Position;
                        source.WriteToSync(Stream.Null, length, null /* maxLength */, true, true, tempExecutionState, streamCopyState);
                        source.Position = startPosition;
                        contentMD5 = streamCopyState.Md5;
                    }
                }
                else
                {
                    // Throw exception if we need to use Transactional MD5 but cannot store it
                    if (modifiedOptions.UseTransactionalMD5.Value)
                    {
                        throw new ArgumentException(SR.PutBlobNeedsStoreBlobContentMD5, "options");
                    }
                }

                Executor.ExecuteSync(
                    this.PutBlobImpl(source, length, contentMD5, accessCondition, modifiedOptions),
                    modifiedOptions.RetryPolicy,
                    operationContext);
            }
            else
            {
                using (CloudBlobStream blobStream = this.OpenWrite(accessCondition, modifiedOptions, operationContext))
                {
                    using (ExecutionState<NullType> tempExecutionState = CommonUtility.CreateTemporaryExecutionState(modifiedOptions))
                    {
                        source.WriteToSync(blobStream, length, null /* maxLength */, false, true, tempExecutionState, null /* streamCopyState */);
                        blobStream.Commit();
                    }
                }
            }
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to upload a stream to a block blob.
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromStream(Stream source, AsyncCallback callback, object state)
        {
            return this.BeginUploadFromStreamHelper(source, null /* length */, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromStream(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginUploadFromStreamHelper(source, null /* length */, accessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a stream to a block blob.
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromStream(Stream source, long length, AsyncCallback callback, object state)
        {
            return this.BeginUploadFromStreamHelper(source, length, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromStream(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginUploadFromStreamHelper(source, length, accessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        internal ICancellableAsyncResult BeginUploadFromStreamHelper(Stream source, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("source", source);

            if (length.HasValue)
            {
                CommonUtility.AssertInBounds("length", length.Value, 1);

                if (source.CanSeek && length > source.Length - source.Position)
                {
                    throw new ArgumentOutOfRangeException("length", SR.StreamLengthShortError);
                }
            }

            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);

            ExecutionState<NullType> tempExecutionState = CommonUtility.CreateTemporaryExecutionState(modifiedOptions);
            StorageAsyncResult<NullType> storageAsyncResult = new StorageAsyncResult<NullType>(callback, state);

            bool lessThanSingleBlobThreshold = source.CanSeek &&
                (length ?? source.Length - source.Position) <= this.ServiceClient.SingleBlobUploadThresholdInBytes;
            if (this.ServiceClient.ParallelOperationThreadCount == 1 && lessThanSingleBlobThreshold)
            {
                if (modifiedOptions.StoreBlobContentMD5.Value)
                {
                    long startPosition = source.Position;
                    StreamDescriptor streamCopyState = new StreamDescriptor();
                    source.WriteToAsync(
                        Stream.Null,
                        length,
                        null /* maxLength */,
                        true,
                        tempExecutionState,
                        streamCopyState,
                        completedState =>
                        {
                            storageAsyncResult.UpdateCompletedSynchronously(completedState.CompletedSynchronously);

                            try
                            {
                                lock (storageAsyncResult.CancellationLockerObject)
                                {
                                    storageAsyncResult.CancelDelegate = null;
                                    if (completedState.ExceptionRef != null)
                                    {
                                        storageAsyncResult.OnComplete(completedState.ExceptionRef);
                                    }
                                    else
                                    {
                                        source.Position = startPosition;
                                        this.UploadFromStreamHandler(
                                            source,
                                            length,
                                            streamCopyState.Md5,
                                            accessCondition,
                                            operationContext,
                                            modifiedOptions,
                                            storageAsyncResult);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                storageAsyncResult.OnComplete(e);
                            }
                        });

                    // We do not need to do this inside a lock, as storageAsyncResult is
                    // not returned to the user yet.
                    storageAsyncResult.CancelDelegate = tempExecutionState.Cancel;
                }
                else
                {
                    if (modifiedOptions.UseTransactionalMD5.Value)
                    {
                        throw new ArgumentException(SR.PutBlobNeedsStoreBlobContentMD5, "options");
                    }

                    this.UploadFromStreamHandler(
                        source,
                        length,
                        null /* contentMD5 */,
                        accessCondition,
                        operationContext,
                        modifiedOptions,
                        storageAsyncResult);
                }
            }
            else
            {
                ICancellableAsyncResult result = this.BeginOpenWrite(
                    accessCondition,
                    modifiedOptions,
                    operationContext,
                    ar =>
                    {
                        storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

                        lock (storageAsyncResult.CancellationLockerObject)
                        {
                            storageAsyncResult.CancelDelegate = null;
                            try
                            {
                                CloudBlobStream blobStream = this.EndOpenWrite(ar);
                                storageAsyncResult.OperationState = blobStream;

                                source.WriteToAsync(
                                    blobStream,
                                    length,
                                    null /* maxLength */,
                                    false,
                                    tempExecutionState,
                                    null /* streamCopyState */,
                                    completedState =>
                                    {
                                        storageAsyncResult.UpdateCompletedSynchronously(completedState.CompletedSynchronously);
                                        if (completedState.ExceptionRef != null)
                                        {
                                            storageAsyncResult.OnComplete(completedState.ExceptionRef);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                lock (storageAsyncResult.CancellationLockerObject)
                                                {
                                                    storageAsyncResult.CancelDelegate = null;
                                                    ICancellableAsyncResult commitResult = blobStream.BeginCommit(
                                                            CloudBlobSharedImpl.BlobOutputStreamCommitCallback,
                                                            storageAsyncResult);

                                                    storageAsyncResult.CancelDelegate = commitResult.Cancel;
                                                    if (storageAsyncResult.CancelRequested)
                                                    {
                                                        storageAsyncResult.Cancel();
                                                    }
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                storageAsyncResult.OnComplete(e);
                                            }
                                        }
                                    });

                                storageAsyncResult.CancelDelegate = tempExecutionState.Cancel;
                                if (storageAsyncResult.CancelRequested)
                                {
                                    storageAsyncResult.Cancel();
                                }
                            }
                            catch (Exception e)
                            {
                                storageAsyncResult.OnComplete(e);
                            }
                        }
                    },
                    null /* state */);

                // We do not need to do this inside a lock, as storageAsyncResult is
                // not returned to the user yet.
                storageAsyncResult.CancelDelegate = result.Cancel;
            }

            return storageAsyncResult;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed.")]
        private void UploadFromStreamHandler(Stream source, long? length, string contentMD5, AccessCondition accessCondition, OperationContext operationContext, BlobRequestOptions options, StorageAsyncResult<NullType> storageAsyncResult)
        {
            ICancellableAsyncResult result = Executor.BeginExecuteAsync(
                this.PutBlobImpl(source, length, contentMD5, accessCondition, options),
                options.RetryPolicy,
                operationContext,
                ar =>
                {
                    storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

                    try
                    {
                        Executor.EndExecuteAsync<NullType>(ar);
                        storageAsyncResult.OnComplete();
                    }
                    catch (Exception e)
                    {
                        storageAsyncResult.OnComplete(e);
                    }
                },
                null /* asyncState */);

            storageAsyncResult.CancelDelegate = result.Cancel;
            if (storageAsyncResult.CancelRequested)
            {
                storageAsyncResult.Cancel();
            }
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndUploadFromStream(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)asyncResult;
            storageAsyncResult.End();
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source)
        {
            return this.UploadFromStreamAsync(source, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromStream, this.EndUploadFromStream, source, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.UploadFromStreamAsync(source, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromStream, this.EndUploadFromStream, source, accessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source, long length)
        {
            return this.UploadFromStreamAsync(source, length, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source, long length, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromStream, this.EndUploadFromStream, source, length, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="length">The number of bytes to write from the source stream at its current position.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromStream, this.EndUploadFromStream, source, length, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Uploads a file to the Blob service. 
        /// </summary>
        /// <param name="path">The file providing the blob content.</param>
        /// <param name="mode">A constant that determines how to open the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void UploadFromFile(string path, FileMode mode, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("path", path);

            using (FileStream fileStream = new FileStream(path, mode, FileAccess.Read))
            {
                this.UploadFromStream(fileStream, accessCondition, options, operationContext);
            }
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to upload a file to a blob.
        /// </summary>
        /// <param name="path">The file providing the blob content.</param>
        /// <param name="mode">A constant that determines how to open the file.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>        
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromFile(string path, FileMode mode, AsyncCallback callback, object state)
        {
            return this.BeginUploadFromFile(path, mode, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a file to a blob. 
        /// </summary>
        /// <param name="path">The file providing the blob content.</param>
        /// <param name="mode">A constant that determines how to open the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromFile(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("path", path);

            FileStream fileStream = new FileStream(path, mode, FileAccess.Read);
            StorageAsyncResult<NullType> storageAsyncResult = new StorageAsyncResult<NullType>(callback, state)
            {
                OperationState = fileStream
            };

            try
            {
                ICancellableAsyncResult asyncResult = this.BeginUploadFromStream(fileStream, accessCondition, options, operationContext, this.UploadFromFileCallback, storageAsyncResult);
                storageAsyncResult.CancelDelegate = asyncResult.Cancel;
                return storageAsyncResult;
            }
            catch (Exception)
            {
                fileStream.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Called when the asynchronous UploadFromStream operation completes.
        /// </summary>
        /// <param name="asyncResult">The result of the asynchronous operation.</param>
        private void UploadFromFileCallback(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)asyncResult.AsyncState;
            Exception exception = null;

            try
            {
                this.EndUploadFromStream(asyncResult);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // We should do FileStream disposal in a separate try-catch block
            // because we want to close the file even if the operation fails.
            try
            {
                FileStream fileStream = (FileStream)storageAsyncResult.OperationState;
                fileStream.Dispose();
            }
            catch (Exception e)
            {
                exception = e;
            }

            storageAsyncResult.OnComplete(exception);
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a file to a blob. 
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndUploadFromFile(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> res = (StorageAsyncResult<NullType>)asyncResult;
            res.End();
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a file to a blob.
        /// </summary>
        /// <param name="path">The file providing the blob content.</param>
        /// <param name="mode">A constant that determines how to open the file.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromFileAsync(string path, FileMode mode)
        {
            return this.UploadFromFileAsync(path, mode, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a file to a blob.
        /// </summary>
        /// <param name="path">The file providing the blob content.</param>
        /// <param name="mode">A constant that determines how to open the file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromFileAsync(string path, FileMode mode, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromFile, this.EndUploadFromFile, path, mode, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a file to a blob.
        /// </summary>
        /// <param name="path">The file providing the blob content.</param>
        /// <param name="mode">A constant that determines how to open the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.UploadFromFileAsync(path, mode, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a file to a blob.
        /// </summary>
        /// <param name="path">The file providing the blob content.</param>
        /// <param name="mode">A constant that determines how to open the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromFile, this.EndUploadFromFile, path, mode, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Uploads the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void UploadFromByteArray(byte[] buffer, int index, int count, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("buffer", buffer);

            using (SyncMemoryStream stream = new SyncMemoryStream(buffer, index, count))
            {
                this.UploadFromStream(stream, accessCondition, options, operationContext);
            }
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to upload the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromByteArray(byte[] buffer, int index, int count, AsyncCallback callback, object state)
        {
            return this.BeginUploadFromByteArray(buffer, index, count, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadFromByteArray(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("buffer", buffer);

            SyncMemoryStream stream = new SyncMemoryStream(buffer, index, count);
            return this.BeginUploadFromStream(stream, accessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to upload the contents of a byte array to a blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndUploadFromByteArray(IAsyncResult asyncResult)
        {
            this.EndUploadFromStream(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromByteArrayAsync(byte[] buffer, int index, int count)
        {
            return this.UploadFromByteArrayAsync(buffer, index, count, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromByteArray, this.EndUploadFromByteArray, buffer, index, count, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload the contents of a byte array to a blob.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="index">The zero-based byte offset in buffer at which to begin uploading bytes to the blob.</param>
        /// <param name="count">The number of bytes to be written to the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadFromByteArray, this.EndUploadFromByteArray, buffer, index, count, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Uploads a string of text to a blob. 
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="encoding">An object that indicates the text encoding to use. If null, UTF-8 will be used.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void UploadText(string content, Encoding encoding = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("content", content);

            byte[] contentAsBytes = (encoding ?? Encoding.UTF8).GetBytes(content);
            this.UploadFromByteArray(contentAsBytes, 0, contentAsBytes.Length, accessCondition, options, operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to upload a string of text to a blob. 
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadText(string content, AsyncCallback callback, object state)
        {
            return this.BeginUploadText(content, null /* encoding */, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a string of text to a blob. 
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="encoding">An object that indicates the text encoding to use. If null, UTF-8 will be used.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUploadText(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("content", content);

            byte[] contentAsBytes = (encoding ?? Encoding.UTF8).GetBytes(content);
            return this.BeginUploadFromByteArray(contentAsBytes, 0, contentAsBytes.Length, accessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a string of text to a blob. 
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndUploadText(IAsyncResult asyncResult)
        {
            this.EndUploadFromByteArray(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a string of text to a blob.
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadTextAsync(string content)
        {
            return this.UploadTextAsync(content, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a string of text to a blob.
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadTextAsync(string content, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadText, this.EndUploadText, content, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a string of text to a blob.
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="encoding">An object that indicates the text encoding to use. If null, UTF-8 will be used.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.UploadTextAsync(content, encoding, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a string of text to a blob.
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="encoding">An object that indicates the text encoding to use. If null, UTF-8 will be used.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUploadText, this.EndUploadText, content, encoding, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void DownloadToStream(Stream target, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.DownloadRangeToStream(target, null /* offset */, null /* length */, accessCondition, options, operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadToStream(Stream target, AsyncCallback callback, object state)
        {
            return this.BeginDownloadToStream(target, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadToStream(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginDownloadRangeToStream(target, null /* offset */, null /* length */, accessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndDownloadToStream(IAsyncResult asyncResult)
        {
            this.EndDownloadRangeToStream(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToStreamAsync(Stream target)
        {
            return this.DownloadToStreamAsync(target, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToStreamAsync(Stream target, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDownloadToStream, this.EndDownloadToStream, target, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadToStreamAsync(target, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDownloadToStream, this.EndDownloadToStream, target, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Downloads the contents of a blob to a file.
        /// </summary>
        /// <param name="path">The target file.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void DownloadToFile(string path, FileMode mode, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("path", path);

            using (FileStream fileStream = new FileStream(path, mode, FileAccess.Write))
            {
                this.DownloadToStream(fileStream, accessCondition, options, operationContext);
            }
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a file.
        /// </summary>
        /// <param name="path">The target file.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadToFile(string path, FileMode mode, AsyncCallback callback, object state)
        {
            return this.BeginDownloadToFile(path, mode, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a file.
        /// </summary>
        /// <param name="path">The target file.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadToFile(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("path", path);

            FileStream fileStream = new FileStream(path, mode, FileAccess.Write);
            StorageAsyncResult<NullType> storageAsyncResult = new StorageAsyncResult<NullType>(callback, state)
            {
                OperationState = fileStream
            };

            try
            {
                ICancellableAsyncResult asyncResult = this.BeginDownloadToStream(fileStream, accessCondition, options, operationContext, this.DownloadToFileCallback, storageAsyncResult);
                storageAsyncResult.CancelDelegate = asyncResult.Cancel;
                return storageAsyncResult;
            }
            catch (Exception)
            {
                fileStream.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Called when the asynchronous DownloadToStream operation completes.
        /// </summary>
        /// <param name="asyncResult">The result of the asynchronous operation.</param>
        private void DownloadToFileCallback(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)asyncResult.AsyncState;
            Exception exception = null;

            try
            {
                this.EndDownloadToStream(asyncResult);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // We should do FileStream disposal in a separate try-catch block
            // because we want to close the file even if the operation fails.
            try
            {
                FileStream fileStream = (FileStream)storageAsyncResult.OperationState;
                fileStream.Dispose();
            }
            catch (Exception e)
            {
                exception = e;
            }

            storageAsyncResult.OnComplete(exception);
        }

        /// <summary>
        /// Ends an asynchronous operation to download the contents of a blob to a file.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndDownloadToFile(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> res = (StorageAsyncResult<NullType>)asyncResult;
            res.End();
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a file.
        /// </summary>
        /// <param name="path">The target file.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToFileAsync(string path, FileMode mode)
        {
            return this.DownloadToFileAsync(path, mode, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a file.
        /// </summary>
        /// <param name="path">The target file.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToFileAsync(string path, FileMode mode, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDownloadToFile, this.EndDownloadToFile, path, mode, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a file.
        /// </summary>
        /// <param name="path">The target file.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadToFileAsync(path, mode, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a file.
        /// </summary>
        /// <param name="path">The target file.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDownloadToFile, this.EndDownloadToFile, path, mode, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Downloads the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        [DoesServiceRequest]
        public int DownloadToByteArray(byte[] target, int index, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            return this.DownloadRangeToByteArray(target, index, null /* blobOffset */, null /* length */, accessCondition, options, operationContext);
        }

#endif
        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadToByteArray(byte[] target, int index, AsyncCallback callback, object state)
        {
            return this.BeginDownloadToByteArray(target, index, null /* accessCondition */, null /* options */, null /*operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadToByteArray(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginDownloadRangeToByteArray(target, index, null /* blobOffset */, null /* length */, accessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        public int EndDownloadToByteArray(IAsyncResult asyncResult)
        {
            return this.EndDownloadRangeToByteArray(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadToByteArrayAsync(byte[] target, int index)
        {
            return this.DownloadToByteArrayAsync(target, index, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadToByteArrayAsync(byte[] target, int index, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadToByteArray, this.EndDownloadToByteArray, target, index, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadToByteArray, this.EndDownloadToByteArray, target, index, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Downloads the blob's contents as a string.
        /// </summary>
        /// <param name="encoding">An object that indicates the text encoding to use.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The contents of the blob, as a string.</returns>
        public string DownloadText(Encoding encoding = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            using (SyncMemoryStream stream = new SyncMemoryStream())
            {
                this.DownloadToStream(stream, accessCondition, options, operationContext);
                byte[] streamAsBytes = stream.GetBuffer();
                return (encoding ?? Encoding.UTF8).GetString(streamAsBytes, 0, (int)stream.Length);
            }
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to download the blob's contents as a string.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginDownloadText(AsyncCallback callback, object state)
        {
            return this.BeginDownloadText(null /* encoding */, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the blob's contents as a string.
        /// </summary>
        /// <param name="encoding">An object that indicates the text encoding to use.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginDownloadText(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            SyncMemoryStream stream = new SyncMemoryStream();
            StorageAsyncResult<string> storageAsyncResult = new StorageAsyncResult<string>(callback, state) { OperationState = Tuple.Create(stream, encoding) };

            ICancellableAsyncResult result = this.BeginDownloadToStream(
                stream,
                accessCondition,
                options,
                operationContext,
                this.DownloadTextCallback,
                storageAsyncResult);

            storageAsyncResult.CancelDelegate = result.Cancel;
            return storageAsyncResult;
        }

        /// <summary>
        /// Called when the asynchronous DownloadToStream operation completes.
        /// </summary>
        /// <param name="asyncResult">The result of the asynchronous operation.</param>
        private void DownloadTextCallback(IAsyncResult asyncResult)
        {
            StorageAsyncResult<string> storageAsyncResult = (StorageAsyncResult<string>)asyncResult.AsyncState;

            try
            {
                this.EndDownloadToStream(asyncResult);

                Tuple<SyncMemoryStream, Encoding> state = (Tuple<SyncMemoryStream, Encoding>)storageAsyncResult.OperationState;
                byte[] streamAsBytes = state.Item1.GetBuffer();
                storageAsyncResult.Result = (state.Item2 ?? Encoding.UTF8).GetString(streamAsBytes, 0, (int)state.Item1.Length);
                storageAsyncResult.OnComplete();
            }
            catch (Exception e)
            {
                storageAsyncResult.OnComplete(e);
            }
        }

        /// <summary>
        /// Ends an asynchronous operation to download the blob's contents as a string.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The contents of the blob, as a string.</returns>
        public string EndDownloadText(IAsyncResult asyncResult)
        {
            StorageAsyncResult<string> res = (StorageAsyncResult<string>)asyncResult;
            res.End();
            return res.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the blob's contents as a string.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> DownloadTextAsync()
        {
            return this.DownloadTextAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the blob's contents as a string.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> DownloadTextAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadText, this.EndDownloadText, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the blob's contents as a string.
        /// </summary>
        /// <param name="encoding">An object that indicates the text encoding to use.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadTextAsync(encoding, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the blob's contents as a string.
        /// </summary>
        /// <param name="encoding">An object that indicates the text encoding to use.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadText, this.EndDownloadText, encoding, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void DownloadRangeToStream(Stream target, long? offset, long? length, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("target", target);

            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.GetBlobImpl(this, this.attributes, target, offset, length, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadRangeToStream(Stream target, long? offset, long? length, AsyncCallback callback, object state)
        {
            return this.BeginDownloadRangeToStream(target, offset, length, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadRangeToStream(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("target", target);

            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.GetBlobImpl(this, this.attributes, target, offset, length, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndDownloadRangeToStream(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length)
        {
            return this.DownloadRangeToStreamAsync(target, offset, length, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDownloadRangeToStream, this.EndDownloadRangeToStream, target, offset, length, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadRangeToStreamAsync(target, offset, length, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="offset">The offset at which to begin downloading the blob, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDownloadRangeToStream, this.EndDownloadRangeToStream, target, offset, length, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Downloads the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        [DoesServiceRequest]
        public int DownloadRangeToByteArray(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            using (SyncMemoryStream stream = new SyncMemoryStream(target, index))
            {
                this.DownloadRangeToStream(stream, blobOffset, length, accessCondition, options, operationContext);
                return (int)stream.Position;
            }
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadRangeToByteArray(byte[] target, int index, long? blobOffset, long? length, AsyncCallback callback, object state)
        {
            return this.BeginDownloadRangeToByteArray(target, index, blobOffset, length, null /* accesCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadRangeToByteArray(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            SyncMemoryStream stream = new SyncMemoryStream(target, index);
            StorageAsyncResult<int> storageAsyncResult = new StorageAsyncResult<int>(callback, state) { OperationState = stream };

            ICancellableAsyncResult result = this.BeginDownloadRangeToStream(
                stream,
                blobOffset,
                length,
                accessCondition,
                options,
                operationContext,
                this.DownloadRangeToByteArrayCallback,
                storageAsyncResult);

            storageAsyncResult.CancelDelegate = result.Cancel;
            return storageAsyncResult;
        }

        /// <summary>
        /// Called when the asynchronous DownloadRangeToStream operation completes.
        /// </summary>
        /// <param name="asyncResult">The result of the asynchronous operation.</param>
        private void DownloadRangeToByteArrayCallback(IAsyncResult asyncResult)
        {
            StorageAsyncResult<int> storageAsyncResult = (StorageAsyncResult<int>)asyncResult.AsyncState;

            try
            {
                this.EndDownloadRangeToStream(asyncResult);

                SyncMemoryStream stream = (SyncMemoryStream)storageAsyncResult.OperationState;
                storageAsyncResult.Result = (int)stream.Position;
                storageAsyncResult.OnComplete();
            }
            catch (Exception e)
            {
                storageAsyncResult.OnComplete(e);
            }
        }

        /// <summary>
        /// Ends an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        public int EndDownloadRangeToByteArray(IAsyncResult asyncResult)
        {
            StorageAsyncResult<int> res = (StorageAsyncResult<int>)asyncResult;
            res.End();
            return res.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length)
        {
            return this.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadRangeToByteArray, this.EndDownloadRangeToByteArray, target, index, blobOffset, length, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to download the contents of a blob to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array.</param>
        /// <param name="blobOffset">The starting offset of the data range, in bytes.</param>
        /// <param name="length">The length of the data to download from the blob, in bytes.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadRangeToByteArray, this.EndDownloadRangeToByteArray, target, index, blobOffset, length, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Checks existence of the blob.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the blob exists.</returns>
        [DoesServiceRequest]
        public bool Exists(BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.ExecuteSync(
                CloudBlobSharedImpl.ExistsImpl(this, this.attributes, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request to check existence of the blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            return this.BeginExists(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to check existence of the blob.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExists(BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.ExistsImpl(this, this.attributes, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to check existence of the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the blob exists.</returns>
        public bool EndExists(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<bool>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the blob.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync()
        {
            return this.ExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the blob.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginExists, this.EndExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the blob.
        /// </summary>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.ExistsAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the blob.
        /// </summary>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginExists, this.EndExists, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Populates a blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void FetchAttributes(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.FetchAttributesImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            return this.BeginFetchAttributes(null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginFetchAttributes(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.FetchAttributesImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndFetchAttributes(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync()
        {
            return this.FetchAttributesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginFetchAttributes, this.EndFetchAttributes, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.FetchAttributesAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginFetchAttributes, this.EndFetchAttributes, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Updates the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void SetMetadata(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.SetMetadataImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            return this.BeginSetMetadata(null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetMetadata(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.SetMetadataImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndSetMetadata(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync()
        {
            return this.SetMetadataAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetMetadata, this.EndSetMetadata, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.SetMetadataAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetMetadata, this.EndSetMetadata, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Updates the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void SetProperties(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.SetPropertiesImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetProperties(AsyncCallback callback, object state)
        {
            return this.BeginSetProperties(null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetProperties(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.SetPropertiesImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndSetProperties(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPropertiesAsync()
        {
            return this.SetPropertiesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPropertiesAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetProperties, this.EndSetProperties, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.SetPropertiesAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetProperties, this.EndSetProperties, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Deletes the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void Delete(DeleteSnapshotsOption deleteSnapshotsOption = DeleteSnapshotsOption.None, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.DeleteBlobImpl(this, this.attributes, deleteSnapshotsOption, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return this.BeginDelete(DeleteSnapshotsOption.None, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.DeleteBlobImpl(this, this.attributes, deleteSnapshotsOption, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndDelete(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete the blob.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDelete, this.EndDelete, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteAsync(deleteSnapshotsOption, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDelete, this.EndDelete, deleteSnapshotsOption, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Deletes the blob if it already exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the blob did already exist and was deleted; otherwise <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool DeleteIfExists(DeleteSnapshotsOption deleteSnapshotsOption = DeleteSnapshotsOption.None, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            bool exists = this.Exists(modifiedOptions, operationContext);
            if (!exists)
            {
                return false;
            }

            try
            {
                this.Delete(deleteSnapshotsOption, accessCondition, modifiedOptions, operationContext);
                return true;
            }
            catch (StorageException e)
            {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
                {
                    if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                        (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.BlobNotFound))
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
        }
#endif

        /// <summary>
        /// Begins an asynchronous request to delete the blob if it already exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return this.BeginDeleteIfExists(DeleteSnapshotsOption.None, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to delete the blob if it already exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            StorageAsyncResult<bool> storageAsyncResult = new StorageAsyncResult<bool>(callback, state)
            {
                RequestOptions = modifiedOptions,
                OperationContext = operationContext,
            };

            this.DeleteIfExistsHandler(deleteSnapshotsOption, accessCondition, modifiedOptions, operationContext, storageAsyncResult);
            return storageAsyncResult;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed.")]
        private void DeleteIfExistsHandler(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, StorageAsyncResult<bool> storageAsyncResult)
        {
            lock (storageAsyncResult.CancellationLockerObject)
            {
                ICancellableAsyncResult savedExistsResult = this.BeginExists(
                    options,
                    operationContext,
                    existsResult =>
                    {
                        storageAsyncResult.UpdateCompletedSynchronously(existsResult.CompletedSynchronously);
                        lock (storageAsyncResult.CancellationLockerObject)
                        {
                            storageAsyncResult.CancelDelegate = null;
                            try
                            {
                                bool exists = this.EndExists(existsResult);
                                if (!exists)
                                {
                                    storageAsyncResult.Result = false;
                                    storageAsyncResult.OnComplete();
                                    return;
                                }

                                ICancellableAsyncResult savedDeleteResult = this.BeginDelete(
                                    deleteSnapshotsOption,
                                    accessCondition,
                                    options,
                                    operationContext,
                                    deleteResult =>
                                    {
                                        storageAsyncResult.UpdateCompletedSynchronously(deleteResult.CompletedSynchronously);
                                        storageAsyncResult.CancelDelegate = null;
                                        try
                                        {
                                            this.EndDelete(deleteResult);
                                            storageAsyncResult.Result = true;
                                            storageAsyncResult.OnComplete();
                                        }
                                        catch (StorageException e)
                                        {
                                            if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
                                            {
                                                if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                                                    (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.BlobNotFound))
                                                {
                                                    storageAsyncResult.Result = false;
                                                    storageAsyncResult.OnComplete();
                                                }
                                                else
                                                {
                                                    storageAsyncResult.OnComplete(e);
                                                }
                                            }
                                            else
                                            {
                                                storageAsyncResult.OnComplete(e);
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            storageAsyncResult.OnComplete(e);
                                        }
                                    },
                                    null /* state */);

                                storageAsyncResult.CancelDelegate = savedDeleteResult.Cancel;
                                if (storageAsyncResult.CancelRequested)
                                {
                                    storageAsyncResult.Cancel();
                                }
                            }
                            catch (Exception e)
                            {
                                storageAsyncResult.OnComplete(e);
                            }
                        }
                    },
                    null /* state */);

                storageAsyncResult.CancelDelegate = savedExistsResult.Cancel;
                if (storageAsyncResult.CancelRequested)
                {
                    storageAsyncResult.Cancel();
                }
            }
        }

        /// <summary>
        /// Returns the result of an asynchronous request to delete the blob if it already exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the blob did already exist and was deleted; otherwise, <c>false</c>.</returns>
        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            StorageAsyncResult<bool> res = (StorageAsyncResult<bool>)asyncResult;
            res.End();
            return res.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the blob if it already exists.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync()
        {
            return this.DeleteIfExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the blob if it already exists.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDeleteIfExists, this.EndDeleteIfExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the blob if it already exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteIfExistsAsync(deleteSnapshotsOption, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the blob if it already exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDeleteIfExists, this.EndDeleteIfExists, deleteSnapshotsOption, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Creates a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request, or <c>null</c>.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A blob snapshot.</returns>
        [DoesServiceRequest]
        public CloudBlockBlob CreateSnapshot(IDictionary<string, string> metadata = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.ExecuteSync(
                this.CreateSnapshotImpl(metadata, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateSnapshot(AsyncCallback callback, object state)
        {
            return this.BeginCreateSnapshot(null /* metadata */, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request, or <c>null</c>.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateSnapshot(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            this.attributes.AssertNoSnapshot();
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.CreateSnapshotImpl(metadata, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A blob snapshot.</returns>
        public CloudBlockBlob EndCreateSnapshot(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<CloudBlockBlob>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlockBlob> CreateSnapshotAsync()
        {
            return this.CreateSnapshotAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlockBlob> CreateSnapshotAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginCreateSnapshot, this.EndCreateSnapshot, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlockBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.CreateSnapshotAsync(metadata, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudBlockBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginCreateSnapshot, this.EndCreateSnapshot, metadata, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
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
        public string AcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.ExecuteSync(
                CloudBlobSharedImpl.AcquireLeaseImpl(this, this.attributes, leaseTime, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AsyncCallback callback, object state)
        {
            return this.BeginAcquireLease(leaseTime, proposedLeaseId, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.AcquireLeaseImpl(this, this.attributes, leaseTime, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>The ID of the acquired lease.</returns>
        public string EndAcquireLease(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<string>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId)
        {
            return this.AcquireLeaseAsync(leaseTime, proposedLeaseId, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginAcquireLease, this.EndAcquireLease, leaseTime, proposedLeaseId, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginAcquireLease, this.EndAcquireLease, leaseTime, proposedLeaseId, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Renews a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void RenewLease(AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.RenewLeaseImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginRenewLease(accessCondition, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.RenewLeaseImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndRenewLease(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task RenewLeaseAsync(AccessCondition accessCondition)
        {
            return this.RenewLeaseAsync(accessCondition, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task RenewLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginRenewLease, this.EndRenewLease, accessCondition, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.RenewLeaseAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginRenewLease, this.EndRenewLease, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Changes the lease ID on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The new lease ID.</returns>
        [DoesServiceRequest]
        public string ChangeLease(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.ExecuteSync(
                CloudBlobSharedImpl.ChangeLeaseImpl(this, this.attributes, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginChangeLease(proposedLeaseId, accessCondition, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.ChangeLeaseImpl(this, this.attributes, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>The new lease ID.</returns>
        public string EndChangeLease(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<string>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.ChangeLeaseAsync(proposedLeaseId, accessCondition, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginChangeLease, this.EndChangeLease, proposedLeaseId, accessCondition, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginChangeLease, this.EndChangeLease, proposedLeaseId, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Releases the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void ReleaseLease(AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.ReleaseLeaseImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginReleaseLease(accessCondition, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.ReleaseLeaseImpl(this, this.attributes, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndReleaseLease(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            return this.ReleaseLeaseAsync(accessCondition, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ReleaseLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginReleaseLease, this.EndReleaseLease, accessCondition, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.ReleaseLeaseAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginReleaseLease, this.EndReleaseLease, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
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
        public TimeSpan BreakLease(TimeSpan? breakPeriod = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.ExecuteSync(
                CloudBlobSharedImpl.BreakLeaseImpl(this, this.attributes, breakPeriod, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AsyncCallback callback, object state)
        {
            return this.BeginBreakLease(breakPeriod, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.BreakLeaseImpl(this, this.attributes, breakPeriod, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        public TimeSpan EndBreakLease(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TimeSpan>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            return this.BreakLeaseAsync(breakPeriod, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginBreakLease, this.EndBreakLease, breakPeriod, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginBreakLease, this.EndBreakLease, breakPeriod, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Uploads a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void PutBlock(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("blockData", blockData);

            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            bool requiresContentMD5 = (contentMD5 == null) && modifiedOptions.UseTransactionalMD5.Value;
            operationContext = operationContext ?? new OperationContext();

            Stream seekableStream = blockData;
            if (!blockData.CanSeek || requiresContentMD5)
            {
                ExecutionState<NullType> tempExecutionState = CommonUtility.CreateTemporaryExecutionState(modifiedOptions);

                Stream writeToStream;
                if (blockData.CanSeek)
                {
                    writeToStream = Stream.Null;
                }
                else
                {
                    seekableStream = new MultiBufferMemoryStream(this.ServiceClient.BufferManager);
                    writeToStream = seekableStream;
                }

                long startPosition = seekableStream.Position;
                StreamDescriptor streamCopyState = new StreamDescriptor();
                blockData.WriteToSync(writeToStream, null /* copyLength */, Constants.MaxBlockSize, requiresContentMD5, true, tempExecutionState, streamCopyState);
                seekableStream.Position = startPosition;

                if (requiresContentMD5)
                {
                    contentMD5 = streamCopyState.Md5;
                }
            }

            Executor.ExecuteSync(
                this.PutBlockImpl(seekableStream, blockId, contentMD5, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPutBlock(string blockId, Stream blockData, string contentMD5, AsyncCallback callback, object state)
        {
            return this.BeginPutBlock(blockId, blockData, contentMD5, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPutBlock(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("blockData", blockData);

            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            bool requiresContentMD5 = (contentMD5 == null) && modifiedOptions.UseTransactionalMD5.Value;
            operationContext = operationContext ?? new OperationContext();
            StorageAsyncResult<NullType> storageAsyncResult = new StorageAsyncResult<NullType>(callback, state);

            if (blockData.CanSeek && !requiresContentMD5)
            {
                this.PutBlockHandler(blockId, blockData, contentMD5, accessCondition, modifiedOptions, operationContext, storageAsyncResult);
            }
            else
            {
                ExecutionState<NullType> tempExecutionState = CommonUtility.CreateTemporaryExecutionState(modifiedOptions);
                storageAsyncResult.CancelDelegate = tempExecutionState.Cancel;

                Stream seekableStream;
                Stream writeToStream;
                if (blockData.CanSeek)
                {
                    seekableStream = blockData;
                    writeToStream = Stream.Null;
                }
                else
                {
                    seekableStream = new MultiBufferMemoryStream(this.ServiceClient.BufferManager);
                    writeToStream = seekableStream;
                }

                long startPosition = seekableStream.Position;
                StreamDescriptor streamCopyState = new StreamDescriptor();
                blockData.WriteToAsync(
                    writeToStream,
                    null /* copyLength */,
                    Constants.MaxBlockSize,
                    requiresContentMD5,
                    tempExecutionState,
                    streamCopyState,
                    completedState =>
                    {
                        storageAsyncResult.UpdateCompletedSynchronously(completedState.CompletedSynchronously);

                        if (completedState.ExceptionRef != null)
                        {
                            storageAsyncResult.OnComplete(completedState.ExceptionRef);
                        }
                        else
                        {
                            try
                            {
                                if (requiresContentMD5)
                                {
                                    contentMD5 = streamCopyState.Md5;
                                }

                                seekableStream.Position = startPosition;
                                this.PutBlockHandler(blockId, seekableStream, contentMD5, accessCondition, modifiedOptions, operationContext, storageAsyncResult);
                            }
                            catch (Exception e)
                            {
                                storageAsyncResult.OnComplete(e);
                            }
                        }
                    });
            }

            return storageAsyncResult;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Reviewed.")]
        private void PutBlockHandler(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, StorageAsyncResult<NullType> storageAsyncResult)
        {
            lock (storageAsyncResult.CancellationLockerObject)
            {
                ICancellableAsyncResult result = Executor.BeginExecuteAsync(
                    this.PutBlockImpl(blockData, blockId, contentMD5, accessCondition, options),
                    options.RetryPolicy,
                    operationContext,
                    ar =>
                    {
                        storageAsyncResult.UpdateCompletedSynchronously(ar.CompletedSynchronously);

                        try
                        {
                            Executor.EndExecuteAsync<NullType>(ar);
                            storageAsyncResult.OnComplete();
                        }
                        catch (Exception e)
                        {
                            storageAsyncResult.OnComplete(e);
                        }
                    },
                    null /* asyncState */);

                storageAsyncResult.CancelDelegate = result.Cancel;
                if (storageAsyncResult.CancelRequested)
                {
                    storageAsyncResult.Cancel();
                }
            }
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndPutBlock(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> storageAsyncResult = (StorageAsyncResult<NullType>)asyncResult;
            storageAsyncResult.End();
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockAsync(string blockId, Stream blockData, string contentMD5)
        {
            return this.PutBlockAsync(blockId, blockData, contentMD5, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockAsync(string blockId, Stream blockData, string contentMD5, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginPutBlock, this.EndPutBlock, blockId, blockData, contentMD5, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockAsync(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.PutBlockAsync(blockId, blockData, contentMD5, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a single block.
        /// </summary>
        /// <param name="blockId">A base64-encoded block ID that identifies the block.</param>
        /// <param name="blockData">A stream that provides the data for the block.</param>
        /// <param name="contentMD5">An optional hash value that will be used to set the <see cref="BlobProperties.ContentMD5"/> property
        /// on the blob. May be <c>null</c> or an empty string.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockAsync(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginPutBlock, this.EndPutBlock, blockId, blockData, contentMD5, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Uploads a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void PutBlockList(IEnumerable<string> blockList, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            IEnumerable<PutBlockListItem> items = blockList.Select(i => new PutBlockListItem(i, BlockSearchMode.Latest));
            Executor.ExecuteSync(
                this.PutBlockListImpl(items, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPutBlockList(IEnumerable<string> blockList, AsyncCallback callback, object state)
        {
            return this.BeginPutBlockList(blockList, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPutBlockList(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            IEnumerable<PutBlockListItem> items = blockList.Select(i => new PutBlockListItem(i, BlockSearchMode.Latest));
            return Executor.BeginExecuteAsync(
                this.PutBlockListImpl(items, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a list of blocks to a new or existing blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndPutBlockList(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockListAsync(IEnumerable<string> blockList)
        {
            return this.PutBlockListAsync(blockList, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockListAsync(IEnumerable<string> blockList, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginPutBlockList, this.EndPutBlockList, blockList, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockListAsync(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.PutBlockListAsync(blockList, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to upload a list of blocks to a new or existing blob. 
        /// </summary>
        /// <param name="blockList">An enumerable collection of block IDs, as base64-encoded strings.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task PutBlockListAsync(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginPutBlockList, this.EndPutBlockList, blockList, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Returns an enumerable collection of the blob's blocks, using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        [DoesServiceRequest]
        public IEnumerable<ListBlockItem> DownloadBlockList(BlockListingFilter blockListingFilter = BlockListingFilter.Committed, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.ExecuteSync(
                this.GetBlockListImpl(blockListingFilter, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadBlockList(AsyncCallback callback, object state)
        {
            return this.BeginDownloadBlockList(BlockListingFilter.Committed, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDownloadBlockList(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.GetBlockListImpl(blockListingFilter, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>An enumerable collection of objects implementing <see cref="ListBlockItem"/>.</returns>
        public IEnumerable<ListBlockItem> EndDownloadBlockList(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<IEnumerable<ListBlockItem>>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<ListBlockItem>> DownloadBlockListAsync()
        {
            return this.DownloadBlockListAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<ListBlockItem>> DownloadBlockListAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadBlockList, this.EndDownloadBlockList, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<ListBlockItem>> DownloadBlockListAsync(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DownloadBlockListAsync(blockListingFilter, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return an enumerable collection of the blob's blocks, 
        /// using the specified block list filter.
        /// </summary>
        /// <param name="blockListingFilter">One of the enumeration values that indicates whether to return 
        /// committed blocks, uncommitted blocks, or both.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<ListBlockItem>> DownloadBlockListAsync(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDownloadBlockList, this.EndDownloadBlockList, blockListingFilter, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Requests that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        [DoesServiceRequest]
        public string StartCopyFromBlob(Uri source, AccessCondition sourceAccessCondition = null, AccessCondition destAccessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("source", source);
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.ExecuteSync(
                CloudBlobSharedImpl.StartCopyFromBlobImpl(this, this.attributes, source, sourceAccessCondition, destAccessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }

        /// <summary>
        /// Requests that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        [DoesServiceRequest]
        public string StartCopyFromBlob(CloudBlockBlob source, AccessCondition sourceAccessCondition = null, AccessCondition destAccessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            return this.StartCopyFromBlob(CloudBlobSharedImpl.SourceBlobToUri(source), sourceAccessCondition, destAccessCondition, options, operationContext);
        }

#endif
        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginStartCopyFromBlob(Uri source, AsyncCallback callback, object state)
        {
            return this.BeginStartCopyFromBlob(source, null /* sourceAccessCondition */, null /* destAccessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginStartCopyFromBlob(CloudBlockBlob source, AsyncCallback callback, object state)
        {
            return this.BeginStartCopyFromBlob(CloudBlobSharedImpl.SourceBlobToUri(source), callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginStartCopyFromBlob(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("source", source);
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.StartCopyFromBlobImpl(this, this.attributes, source, sourceAccessCondition, destAccessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>        
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginStartCopyFromBlob(CloudBlockBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginStartCopyFromBlob(CloudBlobSharedImpl.SourceBlobToUri(source), sourceAccessCondition, destAccessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to request that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        public string EndStartCopyFromBlob(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<string>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(Uri source)
        {
            return this.StartCopyFromBlobAsync(source, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(Uri source, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginStartCopyFromBlob, this.EndStartCopyFromBlob, source, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(CloudBlockBlob source)
        {
            return this.StartCopyFromBlobAsync(source, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(CloudBlockBlob source, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginStartCopyFromBlob, this.EndStartCopyFromBlob, source, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.StartCopyFromBlobAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginStartCopyFromBlob, this.EndStartCopyFromBlob, source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(CloudBlockBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.StartCopyFromBlobAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlockBlob"/> object.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If <c>null</c>, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> StartCopyFromBlobAsync(CloudBlockBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginStartCopyFromBlob, this.EndStartCopyFromBlob, source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Aborts an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void AbortCopy(string copyId, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            Executor.ExecuteSync(
                CloudBlobSharedImpl.AbortCopyImpl(this, this.attributes, copyId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginAbortCopy(string copyId, AsyncCallback callback, object state)
        {
            return this.BeginAbortCopy(copyId, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginAbortCopy(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.BlockBlob, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                CloudBlobSharedImpl.AbortCopyImpl(this, this.attributes, copyId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndAbortCopy(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AbortCopyAsync(string copyId)
        {
            return this.AbortCopyAsync(copyId, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AbortCopyAsync(string copyId, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginAbortCopy, this.EndAbortCopy, copyId, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.AbortCopyAsync(copyId, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">An <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginAbortCopy, this.EndAbortCopy, copyId, accessCondition, options, operationContext, cancellationToken);
        }
#endif

        /// <summary>
        /// Implementation for the CreateSnapshot method.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot, or null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that creates the snapshot.</returns>
        /// <remarks>If the <c>metadata</c> parameter is <c>null</c> then no metadata is associated with the request.</remarks>
        internal RESTCommand<CloudBlockBlob> CreateSnapshotImpl(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<CloudBlockBlob> putCmd = new RESTCommand<CloudBlockBlob>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Snapshot(uri, serverTimeout, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) =>
            {
                if (metadata != null)
                {
                    BlobHttpWebRequestFactory.AddMetadata(r, metadata);
                }
            };
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
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
        /// Uploads the full blob from a seekable stream.
        /// </summary>
        /// <param name="stream">The content stream. Must be seekable.</param>
        /// <param name="length">Number of bytes to upload from the content stream starting at its current position.</param>
        /// <param name="contentMD5">The content MD5.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that gets the stream.</returns>
        private RESTCommand<NullType> PutBlobImpl(Stream stream, long? length, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options)
        {
            long offset = stream.Position;
            this.Properties.ContentMD5 = contentMD5;

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.SendStream = stream;
            putCmd.SendStreamLength = length ?? stream.Length - offset;
            putCmd.RecoveryAction = (cmd, ex, ctx) => RecoveryActions.SeekStream(cmd, offset);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.Put(uri, serverTimeout, this.Properties, BlobType.BlockBlob, 0, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) => BlobHttpWebRequestFactory.AddMetadata(r, this.Metadata);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(this.attributes, resp);
                this.Properties.Length = putCmd.SendStreamLength.Value;
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
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that uploads the block.</returns>
        internal RESTCommand<NullType> PutBlockImpl(Stream source, string blockId, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options)
        {
            long offset = source.Position;

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.SendStream = source;
            putCmd.RecoveryAction = (cmd, ex, ctx) => RecoveryActions.SeekStream(cmd, offset);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.PutBlock(uri, serverTimeout, blockId, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) =>
            {
                if (!string.IsNullOrEmpty(contentMD5))
                {
                    r.Headers[HttpRequestHeader.ContentMd5] = contentMD5;
                }
            };
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Uploads the block list.
        /// </summary>
        /// <param name="blocks">The blocks to upload.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the blob. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that uploads the block list.</returns>
        internal RESTCommand<NullType> PutBlockListImpl(IEnumerable<PutBlockListItem> blocks, AccessCondition accessCondition, BlobRequestOptions options)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(this.ServiceClient.BufferManager);
            BlobRequest.WriteBlockListBody(blocks, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
#if !WINDOWS_PHONE
            string contentMD5 = memoryStream.ComputeMD5Hash();
            memoryStream.Seek(0, SeekOrigin.Begin);
#endif

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.PutBlockList(uri, serverTimeout, this.Properties, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) =>
            {
#if !WINDOWS_PHONE
                r.Headers[HttpRequestHeader.ContentMd5] = contentMD5;
#endif
                BlobHttpWebRequestFactory.AddMetadata(r, this.Metadata);
            };
            putCmd.SendStream = memoryStream;
            putCmd.RecoveryAction = RecoveryActions.RewindStream;
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
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
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that gets the download block list.</returns>
        internal RESTCommand<IEnumerable<ListBlockItem>> GetBlockListImpl(BlockListingFilter typesOfBlocks, AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<IEnumerable<ListBlockItem>> getCmd = new RESTCommand<IEnumerable<ListBlockItem>>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => BlobHttpWebRequestFactory.GetBlockList(uri, serverTimeout, this.SnapshotTime, typesOfBlocks, accessCondition, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                CloudBlobSharedImpl.UpdateETagLMTAndSequenceNumber(this.attributes, resp);
                GetBlockListResponse responseParser = new GetBlockListResponse(cmd.ResponseStream);
                IEnumerable<ListBlockItem> blocks = new List<ListBlockItem>(responseParser.Blocks);
                return blocks;
            };

            return getCmd;
        }
    }
}

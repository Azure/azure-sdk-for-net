//-----------------------------------------------------------------------
// <copyright file="CloudBlobContainer.cs" company="Microsoft">
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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a container in the Windows Azure Blob service.
    /// </summary>
    /// <remarks>Containers hold directories, which are encapsulated as <see cref="CloudBlobDirectory"/> objects, and directories hold block blobs and page blobs. Directories can also contain sub-directories.</remarks>
    public sealed partial class CloudBlobContainer
    {
#if SYNC
        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <param name="requestOptions">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object
        /// is used to track requests to the storage service, and to provide additional runtime information about the operation. </param>
        [DoesServiceRequest]
        public void Create(BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            this.Create(BlobContainerPublicAccessType.Off, requestOptions, operationContext);
        }

        /// <summary>
        /// Creates the container and specifies the level of access to the container's data.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and what level of access is to be allowed.</param>
        /// <param name="requestOptions">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object
        /// is used to track requests to the storage service, and to provide additional runtime information about the operation. </param>
        [DoesServiceRequest]
        public void Create(BlobContainerPublicAccessType accessType, BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(requestOptions, BlobType.Unspecified, this.ServiceClient);
            Executor.ExecuteSync(
                this.CreateContainerImpl(modifiedOptions, accessType),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to create a container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return this.BeginCreate(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a container.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreate(BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginCreate(BlobContainerPublicAccessType.Off, options, operationContext, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a container and specify the level of access to the container's data.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and what level of access is to be allowed.</param>                
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreate(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.CreateContainerImpl(modifiedOptions, accessType),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndCreate(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that creates a container.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync()
        {
            return this.CreateAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that creates a container.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginCreate, this.EndCreate, cancellationToken);
        }

        /// <summary>
        /// Returns a task that creates a container.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and what level of access is to be allowed.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.CreateAsync(accessType, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that creates a container and specifies the level of access to the container's data.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and what level of access is to be allowed.</param>                                
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginCreate, this.EndCreate, accessType, options, operationContext, cancellationToken);
        }
#endif
#if SYNC
        /// <summary>
        /// Creates the container if it does not already exist.
        /// </summary>
        /// <param name="requestOptions">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool CreateIfNotExists(BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            return this.CreateIfNotExists(BlobContainerPublicAccessType.Off, requestOptions, operationContext);
        }

        /// <summary>
        /// Creates the container if it does not already exist and specifies whether the container or its blobs are publicly accessible.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and what level of access is to be allowed.</param>                                        
        /// <param name="requestOptions">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool CreateIfNotExists(BlobContainerPublicAccessType accessType, BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(requestOptions, BlobType.Unspecified, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            bool exists = this.Exists(modifiedOptions, operationContext);

            if (exists)
            {
                return false;
            }

            try
            {
                this.Create(accessType, modifiedOptions, operationContext);
                return true;
            }
            catch (StorageException e)
            {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.Conflict)
                {
                    if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                        (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.ContainerAlreadyExists))
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
        /// Begins an asynchronous request to create the container if it does not already exist.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state)
        {
            return this.BeginCreateIfNotExists(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to create the container if it does not already exist.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateIfNotExists(BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginCreateIfNotExists(BlobContainerPublicAccessType.Off, options, operationContext, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to create the container if it does not already exist.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and the level of access.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateIfNotExists(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            StorageAsyncResult<bool> storageAsyncResult = new StorageAsyncResult<bool>(callback, state)
            {
                RequestOptions = modifiedOptions,
                OperationContext = operationContext,
            };

            this.CreateIfNotExistsHandler(accessType, modifiedOptions, operationContext, storageAsyncResult);

            return storageAsyncResult;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool thread.")]
        private void CreateIfNotExistsHandler(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, StorageAsyncResult<bool> storageAsyncResult)
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
                                if (exists)
                                {
                                    storageAsyncResult.Result = false;
                                    storageAsyncResult.OnComplete();
                                    return;
                                }

                                ICancellableAsyncResult savedCreateResult = this.BeginCreate(
                                    accessType,
                                    options,
                                    operationContext,
                                    createResult =>
                                    {
                                        storageAsyncResult.UpdateCompletedSynchronously(createResult.CompletedSynchronously);
                                        storageAsyncResult.CancelDelegate = null;
                                        try
                                        {
                                            this.EndCreate(createResult);
                                            storageAsyncResult.Result = true;
                                            storageAsyncResult.OnComplete();
                                        }
                                        catch (StorageException e)
                                        {
                                            if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.Conflict)
                                            {
                                                if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                                                    (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.ContainerAlreadyExists))
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

                                storageAsyncResult.CancelDelegate = savedCreateResult.Cancel;
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
        /// Returns the result of an asynchronous request to create the container if it does not already exist.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise, <c>false</c>.</returns>
        public bool EndCreateIfNotExists(IAsyncResult asyncResult)
        {
            StorageAsyncResult<bool> res = asyncResult as StorageAsyncResult<bool>;
            CommonUtility.AssertNotNull("AsyncResult", res);
            res.End();
            return res.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that creates the container if it does not already exist.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync()
        {
            return this.CreateIfNotExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that creates the container if it does not already exist.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginCreateIfNotExists, this.EndCreateIfNotExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that creates the container if it does not already exist.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.CreateIfNotExistsAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that creates the container if it does not already exist.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginCreateIfNotExists, this.EndCreateIfNotExists, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Returns a task that creates the container if it does not already exist.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and the level of access.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.CreateIfNotExistsAsync(accessType, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that creates the container if it does not already exist.
        /// </summary>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and the level of access.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginCreateIfNotExists, this.EndCreateIfNotExists, accessType, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Deletes the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void Delete(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            Executor.ExecuteSync(
                this.DeleteContainerImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return this.BeginDelete(null /* accessCondition */, null /* options */, null /*operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.DeleteContainerImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndDelete(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that deletes the container.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that deletes the container.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDelete, this.EndDelete, cancellationToken);
        }

        /// <summary>
        /// Returns a task that deletes the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that deletes the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDelete, this.EndDelete, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Deletes the container if it already exists.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool DeleteIfExists(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            bool exists = this.Exists(modifiedOptions, operationContext);
            if (!exists)
            {
                return false;
            }

            try
            {
                this.Delete(accessCondition, modifiedOptions, operationContext);
                return true;
            }
            catch (StorageException e)
            {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
                {
                    if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                        (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.ContainerNotFound))
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
        /// Begins an asynchronous request to delete the container if it already exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return this.BeginDeleteIfExists(null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to delete the container if it already exists.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            StorageAsyncResult<bool> storageAsyncResult = new StorageAsyncResult<bool>(callback, state)
            {
                RequestOptions = modifiedOptions,
                OperationContext = operationContext,
            };

            this.DeleteIfExistsHandler(accessCondition, modifiedOptions, operationContext, storageAsyncResult);
            return storageAsyncResult;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool thread.")]
        private void DeleteIfExistsHandler(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, StorageAsyncResult<bool> storageAsyncResult)
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
                                                    (e.RequestInformation.ExtendedErrorInformation.ErrorCode == BlobErrorCodeStrings.ContainerNotFound))
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
        /// Returns the result of an asynchronous request to delete the container if it already exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise, <c>false</c>.</returns>
        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            StorageAsyncResult<bool> res = asyncResult as StorageAsyncResult<bool>;
            CommonUtility.AssertNotNull("AsyncResult", res);
            res.End();
            return res.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that deletes the container if it already exists.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync()
        {
            return this.DeleteIfExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that deletes the container if it already exists.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDeleteIfExists, this.EndDeleteIfExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that deletes the container if it already exists.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteIfExistsAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that deletes the container if it already exists.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDeleteIfExists, this.EndDeleteIfExists, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A reference to the blob.</returns>
        [DoesServiceRequest]
        public ICloudBlob GetBlobReferenceFromServer(string blobName, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNullOrEmpty("blobName", blobName);
            Uri blobUri = NavigationHelper.AppendPathToUri(this.Uri, blobName);

            return this.ServiceClient.GetBlobReferenceFromServer(blobUri, accessCondition, options, operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to get a reference to a blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetBlobReferenceFromServer(string blobName, AsyncCallback callback, object state)
        {
            return this.BeginGetBlobReferenceFromServer(blobName, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to get a reference to a blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetBlobReferenceFromServer(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNullOrEmpty("blobName", blobName);
            Uri blobUri = NavigationHelper.AppendPathToUri(this.Uri, blobName);

            return this.ServiceClient.BeginGetBlobReferenceFromServer(blobUri, accessCondition, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get a reference to a blob in this container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A reference to the blob.</returns>
        public ICloudBlob EndGetBlobReferenceFromServer(IAsyncResult asyncResult)
        {
            return this.ServiceClient.EndGetBlobReferenceFromServer(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName)
        {
            return this.GetBlobReferenceFromServerAsync(blobName, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetBlobReferenceFromServer, this.EndGetBlobReferenceFromServer, blobName, cancellationToken);
        }

        /// <summary>
        /// Returns a task that gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.GetBlobReferenceFromServerAsync(blobName, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetBlobReferenceFromServer, this.EndGetBlobReferenceFromServer, blobName, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Returns an enumerable collection of the blobs in the container that are retrieved lazily.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="useFlatBlobListing">Specifies whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/> and are retrieved lazily.</returns>
        [DoesServiceRequest]
        public IEnumerable<IListBlobItem> ListBlobs(string prefix = null, bool useFlatBlobListing = false, BlobListingDetails blobListingDetails = BlobListingDetails.None, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return CommonUtility.LazyEnumerable(
                token => this.ListBlobsSegmentedCore(prefix, useFlatBlobListing, blobListingDetails, null /* maxResults */, (BlobContinuationToken)token, modifiedOptions, operationContext),
                long.MaxValue);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [DoesServiceRequest]
        public BlobResultSegment ListBlobsSegmented(BlobContinuationToken currentToken)
        {
            return this.ListBlobsSegmented(null /* prefix */, false, BlobListingDetails.None, null /* maxResults */, currentToken, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [DoesServiceRequest]
        public BlobResultSegment ListBlobsSegmented(string prefix, BlobContinuationToken currentToken)
        {
            return this.ListBlobsSegmented(prefix, false, BlobListingDetails.None, null /* maxResults */, currentToken, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="useFlatBlobListing">Specifies whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [DoesServiceRequest]
        public BlobResultSegment ListBlobsSegmented(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            ResultSegment<IListBlobItem> resultSegment = this.ListBlobsSegmentedCore(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, modifiedOptions, operationContext);
            return new BlobResultSegment(resultSegment.Results, (BlobContinuationToken)resultSegment.ContinuationToken);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="useFlatBlobListing">Specifies whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>  
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        private ResultSegment<IListBlobItem> ListBlobsSegmentedCore(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return Executor.ExecuteSync(
                this.ListBlobsImpl(prefix, maxResults, useFlatBlobListing, blobListingDetails, options, currentToken),
                options.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginListBlobsSegmented(BlobContinuationToken currentToken, AsyncCallback callback, object state)
        {
            return this.BeginListBlobsSegmented(null /* prefix */, false, BlobListingDetails.None, null /* maxResults */, currentToken, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginListBlobsSegmented(string prefix, BlobContinuationToken currentToken, AsyncCallback callback, object state)
        {
            return this.BeginListBlobsSegmented(prefix, false, BlobListingDetails.None, null /* maxResults */, currentToken, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="useFlatBlobListing">Specifies whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>  
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginListBlobsSegmented(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.ListBlobsImpl(prefix, maxResults, useFlatBlobListing, blobListingDetails, modifiedOptions, currentToken),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public BlobResultSegment EndListBlobsSegmented(IAsyncResult asyncResult)
        {
            ResultSegment<IListBlobItem> resultSegment = Executor.EndExecuteAsync<ResultSegment<IListBlobItem>>(asyncResult);
            return new BlobResultSegment(resultSegment.Results, (BlobContinuationToken)resultSegment.ContinuationToken);
        }

#if TASK
        /// <summary>
        /// Returns a task that returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        [DoesServiceRequest]
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(BlobContinuationToken currentToken)
        {
            return this.ListBlobsSegmentedAsync(currentToken, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        [DoesServiceRequest]
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(BlobContinuationToken currentToken, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListBlobsSegmented, this.EndListBlobsSegmented, currentToken, cancellationToken);
        }

        /// <summary>
        /// Returns a task that returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        [DoesServiceRequest]
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, BlobContinuationToken currentToken)
        {
            return this.ListBlobsSegmentedAsync(prefix, currentToken, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        [DoesServiceRequest]
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, BlobContinuationToken currentToken, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListBlobsSegmented, this.EndListBlobsSegmented, prefix, currentToken, cancellationToken);
        }

        /// <summary>
        /// Returns a task that returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="useFlatBlobListing">Specifies whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>  
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="prefix">The blob name prefix.</param>
        /// <param name="useFlatBlobListing">Specifies whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>  
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListBlobsSegmented, this.EndListBlobsSegmented, prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void SetPermissions(BlobContainerPermissions permissions, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            Executor.ExecuteSync(
                this.SetPermissionsImpl(permissions, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request to set permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, AsyncCallback callback, object state)
        {
            return this.BeginSetPermissions(permissions, null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.SetPermissionsImpl(permissions, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Returns the result of an asynchronous request to set permissions for the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(BlobContainerPermissions permissions)
        {
            return this.SetPermissionsAsync(permissions, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(BlobContainerPermissions permissions, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetPermissions, this.EndSetPermissions, permissions, cancellationToken);
        }

        /// <summary>
        /// Returns a task that sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.SetPermissionsAsync(permissions, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetPermissions, this.EndSetPermissions, permissions, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Gets the permissions settings for the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The container's permissions.</returns>
        [DoesServiceRequest]
        public BlobContainerPermissions GetPermissions(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.ExecuteSync(
                this.GetPermissionsImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return this.BeginGetPermissions(null /* accessCondition */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetPermissions(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.GetPermissionsImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The container's permissions.</returns>
        public BlobContainerPermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<BlobContainerPermissions>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that gets the permissions settings for the container.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<BlobContainerPermissions> GetPermissionsAsync()
        {
            return this.GetPermissionsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that gets the permissions settings for the container.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<BlobContainerPermissions> GetPermissionsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetPermissions, this.EndGetPermissions, cancellationToken);
        }

        /// <summary>
        /// Returns a task that gets the permissions settings for the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.GetPermissionsAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that gets the permissions settings for the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param> 
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetPermissions, this.EndGetPermissions, accessCondition, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Checks whether the container exists.
        /// </summary>
        /// <param name="requestOptions">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the container exists.</returns>
        [DoesServiceRequest]
        public bool Exists(BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(requestOptions, BlobType.Unspecified, this.ServiceClient);
            return Executor.ExecuteSync(
                this.ExistsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif
        /// <summary>
        /// Begins an asynchronous request to check whether the container exists.
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
        /// Begins an asynchronous request to check whether the container exists.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExists(BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.ExistsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to check whether the container exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the container exists.</returns>
        public bool EndExists(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<bool>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that checks whether the container exists.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync()
        {
            return this.ExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that checks whether the container exists.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginExists, this.EndExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that checks whether the container exists.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.ExistsAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that checks whether the container exists.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
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
        /// Retrieves the container's attributes.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void FetchAttributes(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            Executor.ExecuteSync(
                this.FetchAttributesImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to retrieve the container's attributes.
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
        /// Begins an asynchronous operation to retrieve the container's attributes.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginFetchAttributes(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.FetchAttributesImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to retrieve the container's attributes.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndFetchAttributes(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that retrieves the container's attributes.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync()
        {
            return this.FetchAttributesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that retrieves the container's attributes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginFetchAttributes, this.EndFetchAttributes, cancellationToken);
        }

        /// <summary>
        /// Returns a task that retrieves the container's attributes.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.FetchAttributesAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that retrieves the container's attributes.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
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
        /// Sets the container's user-defined metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void SetMetadata(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            Executor.ExecuteSync(
                this.SetMetadataImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the container.
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
        /// Begins an asynchronous operation to set user-defined metadata on the container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetMetadata(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.SetMetadataImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous request operation to set user-defined metadata on the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndSetMetadata(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that sets container's user-defined metadata.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync()
        {
            return this.SetMetadataAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that sets container's user-defined metadata.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetMetadata, this.EndSetMetadata, cancellationToken);
        }

        /// <summary>
        /// Returns a task that sets container's user-defined metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.SetMetadataAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that sets container's user-defined metadata.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
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
        /// Acquires a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The ID of the acquired lease.</returns>
        [DoesServiceRequest]
        public string AcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.ExecuteSync(
                this.AcquireLeaseImpl(leaseTime, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to acquire a lease on this container.
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
        /// Begins an asynchronous operation to acquire a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.AcquireLeaseImpl(leaseTime, proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to acquire a lease on this container.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>The ID of the acquired lease.</returns>
        public string EndAcquireLease(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<string>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that acquires a lease on this container.
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
        /// Returns a task that acquires a lease on this container.
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
        /// Returns a task that acquires a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that acquires a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
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
        /// Renews a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void RenewLease(AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            Executor.ExecuteSync(
                this.RenewLeaseImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginRenewLease(accessCondition, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.RenewLeaseImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to renew a lease on this container.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndRenewLease(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that renews a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task RenewLeaseAsync(AccessCondition accessCondition)
        {
            return this.RenewLeaseAsync(accessCondition, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that renews a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task RenewLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginRenewLease, this.EndRenewLease, accessCondition, cancellationToken);
        }

        /// <summary>
        /// Returns a task that renews a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.RenewLeaseAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that renews a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
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
        /// Changes the lease ID on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The new lease ID.</returns>
        [DoesServiceRequest]
        public string ChangeLease(string proposedLeaseId, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.ExecuteSync(
                this.ChangeLeaseImpl(proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to change the lease on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginChangeLease(proposedLeaseId, accessCondition, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to change the lease on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.ChangeLeaseImpl(proposedLeaseId, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to change the lease on this container.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>The new lease ID.</returns>
        public string EndChangeLease(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<string>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that changes the lease ID on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.ChangeLeaseAsync(proposedLeaseId, accessCondition, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that changes the lease ID on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginChangeLease, this.EndChangeLease, proposedLeaseId, accessCondition, cancellationToken);
        }

        /// <summary>
        /// Returns a task that changes the lease ID on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that changes the lease ID on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
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
        /// Releases the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void ReleaseLease(AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            Executor.ExecuteSync(
                this.ReleaseLeaseImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to release the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginReleaseLease(accessCondition, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to release the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.ReleaseLeaseImpl(accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to release the lease on this container.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndReleaseLease(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that releases the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            return this.ReleaseLeaseAsync(accessCondition, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that releases the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ReleaseLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginReleaseLease, this.EndReleaseLease, accessCondition, cancellationToken);
        }

        /// <summary>
        /// Returns a task that releases the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.ReleaseLeaseAsync(accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that releases the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
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
        /// Breaks the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        [DoesServiceRequest]
        public TimeSpan BreakLease(TimeSpan? breakPeriod = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.ExecuteSync(
                this.BreakLeaseImpl(breakPeriod, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to break the current lease on this container.
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
        /// Begins an asynchronous operation to break the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. If <c>null</c>, default options will be used.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            BlobRequestOptions modifiedOptions = BlobRequestOptions.ApplyDefaults(options, BlobType.Unspecified, this.ServiceClient);
            return Executor.BeginExecuteAsync(
                this.BreakLeaseImpl(breakPeriod, accessCondition, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to break the current lease on this container.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        public TimeSpan EndBreakLease(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TimeSpan>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that breaks the current lease on this container.
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
        /// Returns a task that breaks the current lease on this container.
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
        /// Returns a task that breaks the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that breaks the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If <c>null</c>, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginBreakLease, this.EndBreakLease, breakPeriod, accessCondition, options, operationContext, cancellationToken);
        }
#endif

        /// <summary>
        /// Generates a RESTCommand for acquiring a lease.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If <c>null</c>, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. This parameter must not be null.</param>
        /// <returns>A RESTCommand implementing the acquire lease operation.</returns>
        internal RESTCommand<string> AcquireLeaseImpl(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            int leaseDuration = -1;
            if (leaseTime.HasValue)
            {
                CommonUtility.AssertInBounds("leaseTime", leaseTime.Value, TimeSpan.FromSeconds(1), TimeSpan.MaxValue);
                leaseDuration = (int)leaseTime.Value.TotalSeconds;
            }

            RESTCommand<string> putCmd = new RESTCommand<string>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Acquire, proposedLeaseId, leaseDuration, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, null /* retVal */, cmd, ex);
                return BlobHttpResponseParsers.GetLeaseId(resp);
            };

            return putCmd;
        }

        /// <summary>
        /// Generates a RESTCommand for renewing a lease.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation, including the current lease ID.
        /// This cannot be null.</param>
        /// <returns>A RESTCommand implementing the renew lease operation.</returns>
        internal RESTCommand<NullType> RenewLeaseImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtility.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDRenewing, "accessCondition");
            }

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Renew, null /* proposedLeaseId */, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Generates a RESTCommand for changing a lease ID.
        /// </summary>
        /// <param name="proposedLeaseId">The proposed new lease ID.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation, including the current lease ID. This cannot be null.</param>
        /// <returns>A RESTCommand implementing the change lease ID operation.</returns>
        internal RESTCommand<string> ChangeLeaseImpl(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtility.AssertNotNull("accessCondition", accessCondition);
            CommonUtility.AssertNotNull("proposedLeaseId", proposedLeaseId);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDChanging, "accessCondition");
            }

            RESTCommand<string> putCmd = new RESTCommand<string>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Change, proposedLeaseId, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
                return BlobHttpResponseParsers.GetLeaseId(resp);
            };

            return putCmd;
        }

        /// <summary>
        /// Generates a RESTCommand for releasing a lease.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation, including the current lease ID.
        /// This cannot be null.</param>
        /// <returns>A RESTCommand implementing the release lease operation.</returns>
        internal RESTCommand<NullType> ReleaseLeaseImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtility.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException(SR.MissingLeaseIDReleasing, "accessCondition");
            }

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Release, null /* proposedLeaseId */, null /* leaseDuration */, null /* leaseBreakPeriod */, accessCondition, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Generates a RESTCommand for breaking a lease.
        /// </summary>
        /// <param name="breakPeriod">The amount of time to allow the lease to remain, rounded down to seconds.
        /// If <c>null</c>, the break period is the remainder of the current lease, or zero for infinite leases.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">The options for this operation. Cannot be null.</param>
        /// <returns>A RESTCommand implementing the break lease operation.</returns>
        internal RESTCommand<TimeSpan> BreakLeaseImpl(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options)
        {
            int? breakSeconds = null;
            if (breakPeriod.HasValue)
            {
                CommonUtility.AssertInBounds("breakPeriod", breakPeriod.Value, TimeSpan.Zero, TimeSpan.MaxValue);
                breakSeconds = (int)breakPeriod.Value.TotalSeconds;
            }

            RESTCommand<TimeSpan> putCmd = new RESTCommand<TimeSpan>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.Lease(uri, serverTimeout, LeaseAction.Break, null /* proposedLeaseId */, null /* leaseDuration */, breakSeconds, accessCondition, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, TimeSpan.Zero, cmd, ex);

                int? remainingLeaseTime = BlobHttpResponseParsers.GetRemainingLeaseTime(resp);
                if (!remainingLeaseTime.HasValue)
                {
                    // Unexpected result from service.
                    throw new StorageException(cmd.CurrentResult, SR.LeaseTimeNotReceived, null /* inner */);
                }

                return TimeSpan.FromSeconds(remainingLeaseTime.Value);
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the Create method.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="accessType">An <see cref="BlobContainerPublicAccessType"/> object that specifies whether data in the container may be accessed publicly and the level of access.</param>        
        /// <returns>A <see cref="RESTCommand{T}"/> that creates the container.</returns>
        private RESTCommand<NullType> CreateContainerImpl(BlobRequestOptions options, BlobContainerPublicAccessType accessType)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.Create(uri, serverTimeout, ctx, accessType);
            putCmd.SetHeaders = (r, ctx) => ContainerHttpWebRequestFactory.AddMetadata(r, this.Metadata);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);
                this.Properties = ContainerHttpResponseParsers.GetProperties(resp);
                this.Metadata = ContainerHttpResponseParsers.GetMetadata(resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the Delete method.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that deletes the container.</returns>
        private RESTCommand<NullType> DeleteContainerImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.Delete(uri, serverTimeout, accessCondition, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Implementation for the FetchAttributes method.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that fetches the attributes.</returns>
        private RESTCommand<NullType> FetchAttributesImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> getCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.GetProperties(uri, serverTimeout, accessCondition, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                this.Properties = ContainerHttpResponseParsers.GetProperties(resp);
                this.Metadata = ContainerHttpResponseParsers.GetMetadata(resp);
                return NullType.Value;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the Exists method.
        /// </summary>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that checks existence.</returns>
        private RESTCommand<bool> ExistsImpl(BlobRequestOptions options)
        {
            RESTCommand<bool> getCmd = new RESTCommand<bool>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.GetProperties(uri, serverTimeout, null /* accessCondition */, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, true, cmd, ex);
                this.Properties = ContainerHttpResponseParsers.GetProperties(resp);
                this.Metadata = ContainerHttpResponseParsers.GetMetadata(resp);
                return true;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the SetMetadata method.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that sets the metadata.</returns>
        private RESTCommand<NullType> SetMetadataImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.SetMetadata(uri, serverTimeout, accessCondition, ctx);
            putCmd.SetHeaders = (r, ctx) => ContainerHttpWebRequestFactory.AddMetadata(r, this.Metadata);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                this.ParseSizeAndLastModified(resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the SetPermissions method.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that sets the permissions.</returns>
        private RESTCommand<NullType> SetPermissionsImpl(BlobContainerPermissions acl, AccessCondition accessCondition, BlobRequestOptions options)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            BlobRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.SetAcl(uri, serverTimeout, acl.PublicAccess, accessCondition, ctx);
            putCmd.SendStream = memoryStream;
            putCmd.RecoveryAction = RecoveryActions.RewindStream;
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                this.ParseSizeAndLastModified(resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="accessCondition">An <see cref="AccessCondition"/> object that represents the access conditions for the container. If <c>null</c>, no condition is used.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that gets the permissions.</returns>
        private RESTCommand<BlobContainerPermissions> GetPermissionsImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            BlobContainerPermissions containerAcl = null;

            RESTCommand<BlobContainerPermissions> getCmd = new RESTCommand<BlobContainerPermissions>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.GetAcl(uri, serverTimeout, accessCondition, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
                containerAcl = new BlobContainerPermissions()
                {
                    PublicAccess = ContainerHttpResponseParsers.GetAcl(resp),
                };
                return containerAcl;
            };
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                ContainerHttpResponseParsers.ReadSharedAccessIdentifiers(cmd.ResponseStream, containerAcl);
                this.ParseSizeAndLastModified(resp);
                return containerAcl;
            };

            return getCmd;
        }

        /// <summary>
        /// Selects the protocol response.
        /// </summary>
        /// <param name="protocolItem">The protocol item.</param>
        /// <returns>The parsed <see cref="IListBlobItem"/>.</returns>
        private IListBlobItem SelectListBlobItem(IListBlobEntry protocolItem)
        {
            ListBlobEntry blob = protocolItem as ListBlobEntry;
            if (blob != null)
            {
                BlobAttributes attributes = blob.Attributes;
                if (attributes.Properties.BlobType == BlobType.BlockBlob)
                {
                    return new CloudBlockBlob(attributes, this.ServiceClient);
                }
                else if (attributes.Properties.BlobType == BlobType.PageBlob)
                {
                    return new CloudPageBlob(attributes, this.ServiceClient);
                }
                else
                {
                    throw new InvalidOperationException(SR.InvalidBlobListItem);
                }
            }

            ListBlobPrefixEntry blobPrefix = protocolItem as ListBlobPrefixEntry;
            if (blobPrefix != null)
            {
                return this.GetDirectoryReference(blobPrefix.Name);
            }

            throw new InvalidOperationException(SR.InvalidBlobListItem);
        }

        /// <summary>
        /// Core implementation of the ListBlobs method.
        /// </summary>
        /// <param name="prefix">The blob prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="useFlatBlobListing">Specifies whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">A <see cref="BlobRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="currentToken">A continuation token returned by a previous listing operation.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that lists the blobs.</returns>
        private RESTCommand<ResultSegment<IListBlobItem>> ListBlobsImpl(string prefix, int? maxResults, bool useFlatBlobListing, BlobListingDetails blobListingDetails, BlobRequestOptions options, BlobContinuationToken currentToken)
        {
            if (!useFlatBlobListing
                && (blobListingDetails & BlobListingDetails.Snapshots) == BlobListingDetails.Snapshots)
            {
                throw new ArgumentException(SR.ListSnapshotsWithDelimiterError, "blobListingDetails");
            }

            string delimiter = useFlatBlobListing ? null : this.ServiceClient.DefaultDelimiter;
            BlobListingContext listingContext = new BlobListingContext(prefix, maxResults, delimiter, blobListingDetails)
            {
                Marker = currentToken != null ? currentToken.NextMarker : null
            };

            RESTCommand<ResultSegment<IListBlobItem>> getCmd = new RESTCommand<ResultSegment<IListBlobItem>>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => ContainerHttpWebRequestFactory.ListBlobs(uri, serverTimeout, listingContext, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                ListBlobsResponse listBlobsResponse = new ListBlobsResponse(cmd.ResponseStream);
                List<IListBlobItem> blobList = new List<IListBlobItem>(
                    listBlobsResponse.Blobs.Select(item => this.SelectListBlobItem(item)));
                BlobContinuationToken continuationToken = null;
                if (listBlobsResponse.NextMarker != null)
                {
                    continuationToken = new BlobContinuationToken()
                    {
                        NextMarker = listBlobsResponse.NextMarker,
                    };
                }

                return new ResultSegment<IListBlobItem>(blobList)
                {
                    ContinuationToken = continuationToken,
                };
            };

            return getCmd;
        }

        /// <summary>
        /// Retrieve ETag and LastModified date time from response.
        /// </summary>
        /// <param name="response">The response to parse.</param>
        private void ParseSizeAndLastModified(HttpWebResponse response)
        {
            BlobContainerProperties parsedProperties = ContainerHttpResponseParsers.GetProperties(response);
            this.Properties.ETag = parsedProperties.ETag;
            this.Properties.LastModified = parsedProperties.LastModified;
        }
    }
}

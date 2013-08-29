// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueue.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This class represents a queue in the Windows Azure Queue service.
    /// </summary>
    public sealed partial class CloudQueue
    {
#if SYNC
        /// <summary>
        /// Creates the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void Create(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.CreateQueueImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to create a queue.
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
        /// Begins an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreate(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.CreateQueueImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndCreate(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync()
        {
            return this.CreateAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginCreate, this.EndCreate, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.CreateAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task CreateAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginCreate, this.EndCreate, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Creates the queue if it does not already exist.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns><c>true</c> if the queue did not already exist and was created; otherwise <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool CreateIfNotExists(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            bool exists = this.Exists(modifiedOptions, operationContext);
            if (exists)
            {
                return false;
            }

            try
            {
                this.Create(modifiedOptions, operationContext);
                if (operationContext.LastResult.HttpStatusCode == (int)HttpStatusCode.NoContent)
                {
                    return false;
                }

                return true;
            }
            catch (StorageException e)
            {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.Conflict)
                {
                    if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                        (e.RequestInformation.ExtendedErrorInformation.ErrorCode == QueueErrorCodeStrings.QueueAlreadyExists))
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
        /// Begins an asynchronous request to create the queue if it does not already exist.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state)
        {
            return this.BeginCreateIfNotExists(null /* options */, null /*operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to create the queue if it does not already exist.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginCreateIfNotExists(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            StorageAsyncResult<bool> storageAsyncResult = new StorageAsyncResult<bool>(callback, state)
            {
                RequestOptions = modifiedOptions,
                OperationContext = operationContext,
            };

            lock (storageAsyncResult.CancellationLockerObject)
            {
                ICancellableAsyncResult currentRes = this.BeginExists(modifiedOptions, operationContext, this.CreateIfNotExistsHandler, storageAsyncResult);
                storageAsyncResult.CancelDelegate = currentRes.Cancel;

                // Check if cancellation was requested prior to begin
                if (storageAsyncResult.CancelRequested)
                {
                    storageAsyncResult.CancelDelegate();
                }
            }

            return storageAsyncResult;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void CreateIfNotExistsHandler(IAsyncResult asyncResult)
        {
            StorageAsyncResult<bool> storageAsyncResult = asyncResult.AsyncState as StorageAsyncResult<bool>;
            bool exists = false;

            lock (storageAsyncResult.CancellationLockerObject)
            {
                storageAsyncResult.CancelDelegate = null;
                storageAsyncResult.UpdateCompletedSynchronously(asyncResult.CompletedSynchronously);

                try
                {
                    exists = this.EndExists(asyncResult);

                    if (exists)
                    {
                        storageAsyncResult.Result = false;
                        storageAsyncResult.OnComplete();
                    }
                    else
                    {
                        ICancellableAsyncResult currentRes = this.BeginCreate(
                             (QueueRequestOptions)storageAsyncResult.RequestOptions,
                             storageAsyncResult.OperationContext,
                             createRes =>
                             {
                                 storageAsyncResult.CancelDelegate = null;
                                 storageAsyncResult.UpdateCompletedSynchronously(createRes.CompletedSynchronously);

                                 try
                                 {
                                     this.EndCreate(createRes);
                                     storageAsyncResult.Result = true;
                                     storageAsyncResult.OnComplete();
                                 }
                                 catch (StorageException e)
                                 {
                                     if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.Conflict)
                                     {
                                         if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                                             (e.RequestInformation.ExtendedErrorInformation.ErrorCode == QueueErrorCodeStrings.QueueAlreadyExists))
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
                                 catch (Exception createEx)
                                 {
                                     storageAsyncResult.OnComplete(createEx);
                                 }
                             },
                             null);

                        storageAsyncResult.CancelDelegate = currentRes.Cancel;
                    }
                }
                catch (Exception ex)
                {
                    storageAsyncResult.OnComplete(ex);
                }
            }
        }

        /// <summary>
        /// Returns the result of an asynchronous request to create the queue if it does not already exist.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the queue did not already exist and was created; otherwise, <c>false</c>.</returns>
        public bool EndCreateIfNotExists(IAsyncResult asyncResult)
        {
            StorageAsyncResult<bool> res = asyncResult as StorageAsyncResult<bool>;
            CommonUtility.AssertNotNull("AsyncResult", res);
            res.End();
            return res.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous request to create the queue if it does not already exist.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync()
        {
            return this.CreateIfNotExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to create the queue if it does not already exist.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginCreateIfNotExists, this.EndCreateIfNotExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to create the queue if it does not already exist.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.CreateIfNotExistsAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to create the queue if it does not already exist.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginCreateIfNotExists, this.EndCreateIfNotExists, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Deletes the queue if it already exists.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns><c>true</c> if the queue did not already exist and was created; otherwise <c>false</c>.</returns>
        [DoesServiceRequest]
        public bool DeleteIfExists(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            bool exists = this.Exists(modifiedOptions, operationContext);
            if (!exists)
            {
                return false;
            }

            try
            {
                this.Delete(modifiedOptions, operationContext);
                return true;
            }
            catch (StorageException e)
            {
                if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
                {
                    if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                        (e.RequestInformation.ExtendedErrorInformation.ErrorCode == QueueErrorCodeStrings.QueueNotFound))
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
        /// Begins an asynchronous request to delete the queue if it already exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return this.BeginDeleteIfExists(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to delete the queue if it already exists.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteIfExists(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            StorageAsyncResult<bool> storageAsyncResult = new StorageAsyncResult<bool>(callback, state)
            {
                RequestOptions = modifiedOptions,
                OperationContext = operationContext,
            };

            lock (storageAsyncResult.CancellationLockerObject)
            {
                ICancellableAsyncResult currentRes = this.BeginExists(modifiedOptions, operationContext, this.DeleteIfExistsHandler, storageAsyncResult);
                storageAsyncResult.CancelDelegate = currentRes.Cancel;

                // Check if cancellation was requested prior to begin
                if (storageAsyncResult.CancelRequested)
                {
                    storageAsyncResult.CancelDelegate();
                }
            }

            return storageAsyncResult;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void DeleteIfExistsHandler(IAsyncResult asyncResult)
        {
            StorageAsyncResult<bool> storageAsyncResult = asyncResult.AsyncState as StorageAsyncResult<bool>;
            bool exists = false;
            lock (storageAsyncResult.CancellationLockerObject)
            {
                storageAsyncResult.CancelDelegate = null;
                storageAsyncResult.UpdateCompletedSynchronously(asyncResult.CompletedSynchronously);

                try
                {
                    exists = this.EndExists(asyncResult);

                    if (!exists)
                    {
                        storageAsyncResult.Result = false;
                        storageAsyncResult.OnComplete();
                    }
                    else
                    {
                        ICancellableAsyncResult currentRes = this.BeginDelete(
                            (QueueRequestOptions)storageAsyncResult.RequestOptions,
                            storageAsyncResult.OperationContext,
                            (deleteRes) =>
                            {
                                storageAsyncResult.CancelDelegate = null;
                                storageAsyncResult.UpdateCompletedSynchronously(deleteRes.CompletedSynchronously);

                                try
                                {
                                    this.EndDelete(deleteRes);
                                    storageAsyncResult.Result = true;
                                    storageAsyncResult.OnComplete();
                                }
                                catch (StorageException e)
                                {
                                    if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
                                    {
                                        if ((e.RequestInformation.ExtendedErrorInformation == null) ||
                                            (e.RequestInformation.ExtendedErrorInformation.ErrorCode == QueueErrorCodeStrings.QueueNotFound))
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
                                catch (Exception createEx)
                                {
                                    storageAsyncResult.OnComplete(createEx);
                                }
                            },
                            null);

                        storageAsyncResult.CancelDelegate = currentRes.Cancel;
                    }
                }
                catch (Exception ex)
                {
                    storageAsyncResult.OnComplete(ex);
                }
            }
        }

        /// <summary>
        /// Returns the result of an asynchronous request to delete the queue if it already exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the queue did not already exist and was created; otherwise, <c>false</c>.</returns>
        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            StorageAsyncResult<bool> res = asyncResult as StorageAsyncResult<bool>;
            CommonUtility.AssertNotNull("AsyncResult", res);
            res.End();
            return res.Result;
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the queue if it already exists.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync()
        {
            return this.DeleteIfExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the queue if it already exists.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDeleteIfExists, this.EndDeleteIfExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the queue if it already exists.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteIfExistsAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to delete the queue if it already exists.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginDeleteIfExists, this.EndDeleteIfExists, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Deletes the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void Delete(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.DeleteQueueImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return this.BeginDelete(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>    
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDelete(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.DeleteQueueImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndDelete(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDelete, this.EndDelete, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDelete, this.EndDelete, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Sets permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void SetPermissions(QueuePermissions permissions, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.SetPermissionsImpl(permissions, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetPermissions(QueuePermissions permissions, AsyncCallback callback, object state)
        {
            return this.BeginSetPermissions(permissions, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetPermissions(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.SetPermissionsImpl(permissions, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Returns the result of an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(QueuePermissions permissions)
        {
            return this.SetPermissionsAsync(permissions, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(QueuePermissions permissions, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetPermissions, this.EndSetPermissions, permissions, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.SetPermissionsAsync(permissions, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetPermissions, this.EndSetPermissions, permissions, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Gets the permissions settings for the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns>The queue's permissions.</returns>
        [DoesServiceRequest]
        public QueuePermissions GetPermissions(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.ExecuteSync(
                this.GetPermissionsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return this.BeginGetPermissions(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetPermissions(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.GetPermissionsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The queue's permissions.</returns>
        public QueuePermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<QueuePermissions>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous request to get the permissions settings for the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueuePermissions> GetPermissionsAsync()
        {
            return this.GetPermissionsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueuePermissions> GetPermissionsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetPermissions, this.EndGetPermissions, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.GetPermissionsAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetPermissions, this.EndGetPermissions, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Checks existence of the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns><c>true</c> if the queue exists.</returns>
        [DoesServiceRequest]
        public bool Exists(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.ExecuteSync(
                this.ExistsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous request to check existence of the queue.
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
        /// Begins an asynchronous request to check existence of the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginExists(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.ExistsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to check existence of the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the queue exists.</returns>
        public bool EndExists(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<bool>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync()
        {
            return this.ExistsAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginExists, this.EndExists, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.ExistsAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous request to check existence of the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginExists, this.EndExists, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Sets the queue's user-defined metadata.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void SetMetadata(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.SetMetadataImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            return this.BeginSetMetadata(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetMetadata(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.SetMetadataImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous request operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndSetMetadata(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync()
        {
            return this.SetMetadataAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetMetadata, this.EndSetMetadata, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.SetMetadataAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set user-defined metadata on the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetMetadata, this.EndSetMetadata, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Fetches the queue's attributes.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void FetchAttributes(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.FetchAttributesImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            return this.BeginFetchAttributes(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginFetchAttributes(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.FetchAttributesImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to fetch a queue's attributes.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndFetchAttributes(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync()
        {
            return this.FetchAttributesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginFetchAttributes, this.EndFetchAttributes, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.FetchAttributesAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginFetchAttributes, this.EndFetchAttributes, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Adds a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void AddMessage(CloudQueueMessage message, TimeSpan? timeToLive = null, TimeSpan? initialVisibilityDelay = null, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("message", message);

            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.AddMessageImpl(message, timeToLive, initialVisibilityDelay, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginAddMessage(CloudQueueMessage message, AsyncCallback callback, object state)
        {
            return this.BeginAddMessage(message, null /* timeToLive */, null /* initialVisibilityDelay */, null /* options */, null /*operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>        
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginAddMessage(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("message", message);

            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.AddMessageImpl(message, timeToLive, initialVisibilityDelay, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndAddMessage(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AddMessageAsync(CloudQueueMessage message)
        {
            return this.AddMessageAsync(message, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AddMessageAsync(CloudQueueMessage message, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginAddMessage, this.EndAddMessage, message, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.AddMessageAsync(message, timeToLive, initialVisibilityDelay, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginAddMessage, this.EndAddMessage, message, timeToLive, initialVisibilityDelay, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Updates the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">Flags of <see cref="MessageUpdateFields"/> values that specifies which parts of the message are to be updated.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        [DoesServiceRequest]
        public void UpdateMessage(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.UpdateMessageImpl(message, visibilityTimeout, updateFields, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">An EnumSet of <see cref="MessageUpdateFields"/> values that specifies which parts of the message are to be updated.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUpdateMessage(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, AsyncCallback callback, object state)
        {
            return this.BeginUpdateMessage(message, visibilityTimeout, updateFields, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">An EnumSet of <see cref="MessageUpdateFields"/> values that specifies which parts of the message are to be updated.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginUpdateMessage(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("message", message);

            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.UpdateMessageImpl(message, visibilityTimeout, updateFields, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndUpdateMessage(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">An EnumSet of <see cref="MessageUpdateFields"/> values that specifies which parts of the message are to be updated.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields)
        {
            return this.UpdateMessageAsync(message, visibilityTimeout, updateFields, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">An EnumSet of <see cref="MessageUpdateFields"/> values that specifies which parts of the message are to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUpdateMessage, this.EndUpdateMessage, message, visibilityTimeout, updateFields, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">An EnumSet of <see cref="MessageUpdateFields"/> values that specifies which parts of the message are to be updated.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.UpdateMessageAsync(message, visibilityTimeout, updateFields, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">An EnumSet of <see cref="MessageUpdateFields"/> values that specifies which parts of the message are to be updated.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginUpdateMessage, this.EndUpdateMessage, message, visibilityTimeout, updateFields, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Deletes a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void DeleteMessage(CloudQueueMessage message, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("message", message);

            this.DeleteMessage(message.Id, message.PopReceipt, options, operationContext);
        }

        /// <summary>
        /// Deletes the specified message from the queue.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void DeleteMessage(string messageId, string popReceipt, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            CommonUtility.AssertNotNull("messageId", messageId);
            CommonUtility.AssertNotNull("popReceipt", popReceipt);

            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.DeleteMessageImpl(messageId, popReceipt, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteMessage(CloudQueueMessage message, AsyncCallback callback, object state)
        {
            return this.BeginDeleteMessage(message, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteMessage(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("message", message);

            return this.BeginDeleteMessage(message.Id, message.PopReceipt, options, operationContext, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteMessage(string messageId, string popReceipt, AsyncCallback callback, object state)
        {
            return this.BeginDeleteMessage(messageId, popReceipt, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginDeleteMessage(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("messageId", messageId);
            CommonUtility.AssertNotNull("popReceipt", popReceipt);

            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.DeleteMessageImpl(messageId, popReceipt, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndDeleteMessage(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(CloudQueueMessage message)
        {
            return this.DeleteMessageAsync(message, null /* options */, null /* operationContext */, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(CloudQueueMessage message, CancellationToken cancellationToken)
        {
            return this.DeleteMessageAsync(message, null /* options */, null /* operationContext */, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteMessageAsync(message, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDeleteMessage, this.EndDeleteMessage, message, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(string messageId, string popReceipt)
        {
            return this.DeleteMessageAsync(messageId, popReceipt, null /* options */, null /* operationContext */, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken)
        {
            return this.DeleteMessageAsync(messageId, popReceipt, null /* options */, null /* operationContext */, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteMessageAsync(messageId, popReceipt, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginDeleteMessage, this.EndDeleteMessage, messageId, popReceipt, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Gets the specified number of messages from the queue using the specified request options and 
        /// operation context. This operation marks the retrieved messages as invisible in the queue for the default 
        /// visibility timeout period. 
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        [DoesServiceRequest]
        public IEnumerable<CloudQueueMessage> GetMessages(int messageCount, TimeSpan? visibilityTimeout = null, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.ExecuteSync(
                this.GetMessagesImpl(messageCount, visibilityTimeout, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetMessages(int messageCount, AsyncCallback callback, object state)
        {
            return this.BeginGetMessages(messageCount, null /* visibilityTimeout */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to get the specified number of messages from the queue using the 
        /// specified request options and operation context. This operation marks the retrieved messages as invisible in the 
        /// queue for the default visibility timeout period.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetMessages(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.GetMessagesImpl(messageCount, visibilityTimeout, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        public IEnumerable<CloudQueueMessage> EndGetMessages(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<IEnumerable<CloudQueueMessage>>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount)
        {
            return this.GetMessagesAsync(messageCount, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetMessages, this.EndGetMessages, messageCount, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the specified number of messages from the queue using the 
        /// specified request options and operation context. This operation marks the retrieved messages as invisible in the 
        /// queue for the default visibility timeout period.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.GetMessagesAsync(messageCount, visibilityTimeout, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the specified number of messages from the queue using the 
        /// specified request options and operation context. This operation marks the retrieved messages as invisible in the 
        /// queue for the default visibility timeout period.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetMessages, this.EndGetMessages, messageCount, visibilityTimeout, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Gets a message from the queue using the default request options. This operation marks the retrieved message as invisible in the queue for the default visibility timeout period. 
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns>A message.</returns>
        [DoesServiceRequest]
        public CloudQueueMessage GetMessage(TimeSpan? visibilityTimeout = null, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            return this.GetMessages(1, visibilityTimeout, options, operationContext).FirstOrDefault();
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetMessage(AsyncCallback callback, object state)
        {
            return this.BeginGetMessage(null /* visibilityTimeout */, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to get a single message from the queue, and specifies how long the message should be 
        /// reserved before it becomes visible, and therefore available for deletion.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetMessage(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginGetMessages(1, visibilityTimeout, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A message.</returns>
        public CloudQueueMessage EndGetMessage(IAsyncResult asyncResult)
        {
            IEnumerable<CloudQueueMessage> resultList = Executor.EndExecuteAsync<IEnumerable<CloudQueueMessage>>(asyncResult);

            return resultList.FirstOrDefault();
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> GetMessageAsync()
        {
            return this.GetMessageAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> GetMessageAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetMessage, this.EndGetMessage, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue, and specifies how long the message should be 
        /// reserved before it becomes visible, and therefore available for deletion.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.GetMessageAsync(visibilityTimeout, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue, and specifies how long the message should be 
        /// reserved before it becomes visible, and therefore available for deletion.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetMessage, this.EndGetMessage, visibilityTimeout, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Peeks a message from the queue, using the specified request options and operation context. A peek request retrieves a message from the queue without changing its visibility. 
        /// </summary>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        [DoesServiceRequest]
        public IEnumerable<CloudQueueMessage> PeekMessages(int messageCount, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.ExecuteSync(
                this.PeekMessagesImpl(messageCount, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPeekMessages(int messageCount, AsyncCallback callback, object state)
        {
            return this.BeginPeekMessages(messageCount, null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPeekMessages(int messageCount, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.PeekMessagesImpl(messageCount, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        public IEnumerable<CloudQueueMessage> EndPeekMessages(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<IEnumerable<CloudQueueMessage>>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount)
        {
            return this.PeekMessagesAsync(messageCount, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginPeekMessages, this.EndPeekMessages, messageCount, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.PeekMessagesAsync(messageCount, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to peek messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to peek.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginPeekMessages, this.EndPeekMessages, messageCount, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Peeks a single message from the queue. A peek request retrieves a message from the queue without changing its visibility.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <returns>A message.</returns>
        [DoesServiceRequest]
        public CloudQueueMessage PeekMessage(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            return this.PeekMessages(1, options, operationContext).FirstOrDefault();
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPeekMessage(AsyncCallback callback, object state)
        {
            return this.BeginPeekMessage(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to peek a single message from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginPeekMessage(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            return this.BeginPeekMessages(1, options, operationContext, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to peek a single message from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A message.</returns>
        public CloudQueueMessage EndPeekMessage(IAsyncResult asyncResult)
        {
            IEnumerable<CloudQueueMessage> resultList = Executor.EndExecuteAsync<IEnumerable<CloudQueueMessage>>(asyncResult);

            return resultList.FirstOrDefault();
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> PeekMessageAsync()
        {
            return this.PeekMessageAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> PeekMessageAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginPeekMessage, this.EndPeekMessage, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.PeekMessageAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginPeekMessage, this.EndPeekMessage, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Clears all messages from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void Clear(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            Executor.ExecuteSync(
                this.ClearMessagesImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginClear(AsyncCallback callback, object state)
        {
            return this.BeginClear(null /* options */, null /* operationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests to the storage service, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginClear(QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.ClearMessagesImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndClear(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ClearAsync()
        {
            return this.ClearAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ClearAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginClear, this.EndClear, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ClearAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            return this.ClearAsync(options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task ClearAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginClear, this.EndClear, options, operationContext, cancellationToken);
        }
#endif

        /// <summary>
        /// Ends an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [Obsolete("This class is improperly named; use class EndClear instead.")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Reviewed.")]
        public void EndBeginClear(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

        /// <summary>
        /// Implementation for the ClearMessages method.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that gets the permissions.</returns>
        private RESTCommand<NullType> ClearMessagesImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.ClearMessages(uri, serverTimeout, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Implementation for the Create method.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that creates the queue.</returns>
        private RESTCommand<NullType> CreateQueueImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.Create(uri, serverTimeout, ctx);
            putCmd.SetHeaders = (r, ctx) => QueueHttpWebRequestFactory.AddMetadata(r, this.Metadata);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpStatusCode[] expectedHttpStatusCodes = new HttpStatusCode[2];
                expectedHttpStatusCodes[0] = HttpStatusCode.Created;
                expectedHttpStatusCodes[1] = HttpStatusCode.NoContent;
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(expectedHttpStatusCodes, resp, NullType.Value, cmd, ex);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the Delete method.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that deletes the queue.</returns>
        private RESTCommand<NullType> DeleteQueueImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.Delete(uri, serverTimeout, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Implementation for the FetchAttributes method.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that fetches the attributes.</returns>
        private RESTCommand<NullType> FetchAttributesImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> getCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.GetMetadata(uri, serverTimeout, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                GetMessageCountAndMetadataFromResponse(resp);
                return NullType.Value;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the Exists method.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that checks existence.</returns>
        private RESTCommand<bool> ExistsImpl(QueueRequestOptions options)
        {
            RESTCommand<bool> getCmd = new RESTCommand<bool>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.GetMetadata(uri, serverTimeout, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                if (resp.StatusCode == HttpStatusCode.PreconditionFailed)
                {
                    return true;
                }

                return HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, true, cmd, ex);
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the SetMetadata method.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that sets the metadata.</returns>
        private RESTCommand<NullType> SetMetadataImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.SetMetadata(uri, serverTimeout, ctx);
            putCmd.SetHeaders = (r, ctx) => QueueHttpWebRequestFactory.AddMetadata(r, this.Metadata);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the SetPermissions method.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that sets the permissions.</returns>
        private RESTCommand<NullType> SetPermissionsImpl(QueuePermissions acl, QueueRequestOptions options)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            QueueRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.SetAcl(uri, serverTimeout, ctx);
            putCmd.SendStream = memoryStream;
            putCmd.RecoveryAction = RecoveryActions.RewindStream;
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that gets the permissions.</returns>
        private RESTCommand<QueuePermissions> GetPermissionsImpl(QueueRequestOptions options)
        {
            RESTCommand<QueuePermissions> getCmd = new RESTCommand<QueuePermissions>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.GetAcl(uri, serverTimeout, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                QueuePermissions queueAcl = new QueuePermissions();
                QueueHttpResponseParsers.ReadSharedAccessIdentifiers(cmd.ResponseStream, queueAcl);
                return queueAcl;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the AddMessageImpl method.
        /// </summary>
        /// <param name="message">A queue message.</param>
        /// <param name="timeToLive">A value indicating the message time-to-live.</param>
        /// <param name="initialVisibilityDelay">The visibility delay for the message.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that sets the permissions.</returns>
        private RESTCommand<NullType> AddMessageImpl(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options)
        {
            int? timeToLiveInSeconds = null;
            int? initialVisibilityDelayInSeconds = null;

            if (timeToLive != null)
            {
                CommonUtility.AssertInBounds<TimeSpan>("timeToLive", timeToLive.Value, TimeSpan.Zero, CloudQueueMessage.MaxTimeToLive);
                timeToLiveInSeconds = (int)timeToLive.Value.TotalSeconds;
            }

            if (initialVisibilityDelay != null)
            {
                CommonUtility.AssertInBounds<TimeSpan>("initialVisibilityDelay", initialVisibilityDelay.Value, TimeSpan.Zero, timeToLive ?? CloudQueueMessage.MaxTimeToLive);
                initialVisibilityDelayInSeconds = (int)initialVisibilityDelay.Value.TotalSeconds;
            }

            CommonUtility.AssertNotNull("message", message);

            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            QueueRequest.WriteMessageContent(message.GetMessageContentForTransfer(this.EncodeMessage), memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.AddMessage(putCmd.Uri, serverTimeout, timeToLiveInSeconds, initialVisibilityDelayInSeconds, ctx);
            putCmd.SendStream = memoryStream;
            putCmd.RecoveryAction = RecoveryActions.RewindStream;
            putCmd.SetHeaders = (r, ctx) =>
            {
                if (timeToLive != null)
                {
#if WINDOWS_PHONE
                    r.Headers[Constants.QueryConstants.MessageTimeToLive] = timeToLive.Value.TotalSeconds.ToString(CultureInfo.InvariantCulture);
#else
                    r.Headers.Set(Constants.QueryConstants.MessageTimeToLive, timeToLive.Value.TotalSeconds.ToString(CultureInfo.InvariantCulture));
#endif
                }

                if (initialVisibilityDelay != null)
                {
#if WINDOWS_PHONE
                    r.Headers[Constants.QueryConstants.VisibilityTimeout] = initialVisibilityDelay.Value.TotalSeconds.ToString(CultureInfo.InvariantCulture);
#else
                    r.Headers.Set(Constants.QueryConstants.VisibilityTimeout, initialVisibilityDelay.Value.TotalSeconds.ToString(CultureInfo.InvariantCulture));
#endif
                }
            };

            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the UpdateMessage method.
        /// </summary>
        /// <param name="message">A queue message.</param>
        /// <param name="visibilityTimeout">The visibility timeout for the message.</param>
        /// <param name="updateFields">Indicates whether to update the visibility delay, message contents, or both.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that sets the permissions.</returns>
        private RESTCommand<NullType> UpdateMessageImpl(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options)
        {
            CommonUtility.AssertNotNull("message", message);
            CommonUtility.AssertNotNullOrEmpty("messageId", message.Id);
            CommonUtility.AssertNotNullOrEmpty("popReceipt", message.PopReceipt);
            CommonUtility.AssertInBounds<TimeSpan>("visibilityTimeout", visibilityTimeout, TimeSpan.Zero, CloudQueueMessage.MaxTimeToLive);

            if ((updateFields & MessageUpdateFields.Visibility) == 0)
            {
                throw new ArgumentException(SR.UpdateMessageVisibilityRequired, "updateFields");
            }

            Uri messageUri = this.GetIndividualMessageAddress(message.Id);
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, messageUri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.UpdateMessage(putCmd.Uri, serverTimeout, message.PopReceipt, visibilityTimeout.RoundUpToSeconds(), ctx);

            if ((updateFields & MessageUpdateFields.Content) != 0)
            {
                MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(this.ServiceClient.BufferManager, (int)(1 * Constants.KB));
                QueueRequest.WriteMessageContent(message.GetMessageContentForTransfer(this.EncodeMessage), memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                putCmd.SendStream = memoryStream;
                putCmd.RecoveryAction = RecoveryActions.RewindStream;
            }

            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);
                GetPopReceiptAndNextVisibleTimeFromResponse(message, resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the DeleteMessage method.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that deletes the queue.</returns>
        private RESTCommand<NullType> DeleteMessageImpl(string messageId, string popReceipt, QueueRequestOptions options)
        {
            Uri messageUri = this.GetIndividualMessageAddress(messageId);
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, messageUri);

            putCmd.ApplyRequestOptions(options);
            putCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.DeleteMessage(putCmd.Uri, serverTimeout, popReceipt, ctx);
            putCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that gets the permissions.</returns>
        private RESTCommand<IEnumerable<CloudQueueMessage>> GetMessagesImpl(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options)
        {
            RESTCommand<IEnumerable<CloudQueueMessage>> getCmd = new RESTCommand<IEnumerable<CloudQueueMessage>>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.GetMessages(getCmd.Uri, serverTimeout, messageCount, visibilityTimeout, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                GetMessagesResponse getMessagesResponse = new GetMessagesResponse(cmd.ResponseStream);

                List<CloudQueueMessage> messagesList = new List<CloudQueueMessage>(
                    getMessagesResponse.Messages.Select(item => SelectGetMessageResponse(item)));

                return messagesList;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the PeekMessages method.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="options">An <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that gets the permissions.</returns>
        private RESTCommand<IEnumerable<CloudQueueMessage>> PeekMessagesImpl(int messageCount, QueueRequestOptions options)
        {
            RESTCommand<IEnumerable<CloudQueueMessage>> getCmd = new RESTCommand<IEnumerable<CloudQueueMessage>>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.PeekMessages(getCmd.Uri, serverTimeout, messageCount, ctx);
            getCmd.SignRequest = this.ServiceClient.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                GetMessagesResponse getMessagesResponse = new GetMessagesResponse(cmd.ResponseStream);

                List<CloudQueueMessage> messagesList = new List<CloudQueueMessage>(
                    getMessagesResponse.Messages.Select(item => SelectPeekMessageResponse(item)));

                return messagesList;
            };

            return getCmd;
        }

        /// <summary>
        /// Gets the ApproximateMessageCount and metadata from response.
        /// </summary>
        /// <param name="webResponse">The web response.</param>
        private void GetMessageCountAndMetadataFromResponse(HttpWebResponse webResponse)
        {
            this.Metadata = QueueHttpResponseParsers.GetMetadata(webResponse);

            string count = QueueHttpResponseParsers.GetApproximateMessageCount(webResponse);
            this.ApproximateMessageCount = string.IsNullOrEmpty(count) ? (int?)null : int.Parse(count, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Update the message pop receipt and next visible time.
        /// </summary>
        /// <param name="message">The Cloud Queue Message.</param>
        /// <param name="webResponse">The web response.</param>
        private static void GetPopReceiptAndNextVisibleTimeFromResponse(CloudQueueMessage message, HttpWebResponse webResponse)
        {
            message.PopReceipt = webResponse.Headers[Constants.HeaderConstants.PopReceipt];
            message.NextVisibleTime = DateTime.Parse(
                webResponse.Headers[Constants.HeaderConstants.NextVisibleTime],
                DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.AdjustToUniversal);
        }
    }
}

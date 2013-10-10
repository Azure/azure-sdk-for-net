// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueueClient.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Auth.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a client-side logical representation of the Windows Azure Queue service. This client is used to configure and execute requests against the Queue service.
    /// </summary>
    /// <remarks>The service client encapsulates the base URI for the Queue service. If the service client will be used for authenticated access, it also encapsulates the credentials for accessing the storage account.</remarks>
    public sealed partial class CloudQueueClient
    {
        private IAuthenticationHandler authenticationHandler;

        /// <summary>
        /// Gets or sets the authentication scheme to use to sign HTTP requests.
        /// </summary>
        public AuthenticationScheme AuthenticationScheme
        {
            get
            {
                return this.authenticationScheme;
            }

            set
            {
                if (value != this.authenticationScheme)
                {
                    this.authenticationScheme = value;
                    this.authenticationHandler = null;
                }
            }
        }

        /// <summary>
        /// Gets the authentication handler used to sign HTTP requests.
        /// </summary>
        /// <value>The authentication handler.</value>
        internal IAuthenticationHandler AuthenticationHandler
        {
            get
            {
                IAuthenticationHandler result = this.authenticationHandler;
                if (result == null)
                {
                    if (this.Credentials.IsSharedKey)
                    {
                        result = new SharedKeyAuthenticationHandler(
                            this.GetCanonicalizer(),
                            this.Credentials,
                            this.Credentials.AccountName);
                    }
                    else
                    {
                        result = new NoOpAuthenticationHandler();
                    }

                    this.authenticationHandler = result;
                }

                return result;
            }
        }

#if SYNC
        /// <summary>
        /// Returns an enumerable collection of the queues in the storage account whose names begin with the specified prefix and that are retrieved lazily.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="queueListingDetails">An enumeration value that indicates which details to include in the listing.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="CloudQueue"/> and are retrieved lazily.</returns>
        public IEnumerable<CloudQueue> ListQueues(string prefix = null, QueueListingDetails queueListingDetails = QueueListingDetails.None, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this);
            operationContext = operationContext ?? new OperationContext();

            return CommonUtility.LazyEnumerable(
                (token) => this.ListQueuesSegmentedCore(prefix, queueListingDetails, null, token as QueueContinuationToken, modifiedOptions, operationContext),
                long.MaxValue);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues in the storage account.
        /// </summary>
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> continuation token returned by a previous listing operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="CloudQueue"/>.</returns>
        public QueueResultSegment ListQueuesSegmented(QueueContinuationToken currentToken)
        {
            return this.ListQueuesSegmented(null, QueueListingDetails.None, null, currentToken, null, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues in the storage account.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> continuation token returned by a previous listing operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="CloudQueue"/>.</returns>
        public QueueResultSegment ListQueuesSegmented(string prefix, QueueContinuationToken currentToken)
        {
            return this.ListQueuesSegmented(prefix, QueueListingDetails.None, null, currentToken, null, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues in the storage account.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="queueListingDetails">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="CloudQueue"/>.</returns>
        public QueueResultSegment ListQueuesSegmented(string prefix, QueueListingDetails queueListingDetails, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this);
            operationContext = operationContext ?? new OperationContext();

            ResultSegment<CloudQueue> resultSegment = this.ListQueuesSegmentedCore(prefix, queueListingDetails, maxResults, currentToken, modifiedOptions, operationContext);
            return new QueueResultSegment(resultSegment.Results, (QueueContinuationToken)resultSegment.ContinuationToken);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues in the storage account.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="queueListingDetails">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        /// <returns>A result segment.</returns>
        private ResultSegment<CloudQueue> ListQueuesSegmentedCore(string prefix, QueueListingDetails queueListingDetails, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext)
        {
            return Executor.ExecuteSync(
                this.ListQueuesImpl(prefix, maxResults, queueListingDetails, options, currentToken),
                options.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginListQueuesSegmented(QueueContinuationToken currentToken, AsyncCallback callback, object state)
        {
            return this.BeginListQueuesSegmented(null, QueueListingDetails.None, null, currentToken, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginListQueuesSegmented(string prefix, QueueContinuationToken currentToken, AsyncCallback callback, object state)
        {
            return this.BeginListQueuesSegmented(prefix, QueueListingDetails.None, null, currentToken, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="queueListingDetails">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        public ICancellableAsyncResult BeginListQueuesSegmented(string prefix, QueueListingDetails queueListingDetails, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this);

            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                this.ListQueuesImpl(prefix, maxResults, queueListingDetails, modifiedOptions, currentToken),
                modifiedOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A queue result segment.</returns>
        public QueueResultSegment EndListQueuesSegmented(IAsyncResult asyncResult)
        {
            ResultSegment<CloudQueue> resultSegment = Executor.EndExecuteAsync<ResultSegment<CloudQueue>>(asyncResult);
            return new QueueResultSegment(resultSegment.Results, (QueueContinuationToken)resultSegment.ContinuationToken);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>      
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueueResultSegment> ListQueuesSegmentedAsync(QueueContinuationToken currentToken)
        {
            return this.ListQueuesSegmentedAsync(currentToken, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>     
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueueResultSegment> ListQueuesSegmentedAsync(QueueContinuationToken currentToken, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListQueuesSegmented, this.EndListQueuesSegmented, currentToken, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>  
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueContinuationToken currentToken)
        {
            return this.ListQueuesSegmentedAsync(prefix, currentToken, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>    
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueContinuationToken currentToken, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListQueuesSegmented, this.EndListQueuesSegmented, prefix, currentToken, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="queueListingDetails">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails queueListingDetails, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.ListQueuesSegmentedAsync(prefix, queueListingDetails, maxResults, currentToken, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to return a result segment containing a collection of queue items.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="queueListingDetails">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is null, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="currentToken">A <see cref="QueueContinuationToken"/> returned by a previous listing operation.</param> 
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<QueueResultSegment> ListQueuesSegmentedAsync(string prefix, QueueListingDetails queueListingDetails, int? maxResults, QueueContinuationToken currentToken, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginListQueuesSegmented, this.EndListQueuesSegmented, prefix, queueListingDetails, maxResults, currentToken, options, operationContext, cancellationToken);
        }
#endif

        /// <summary>
        /// Core implementation of the ListQueues method.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is <c>null</c>, the maximum possible number of results will be returned, up to 5000.</param>
        /// <param name="queueListingDetails">A <see cref="QueueListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">An object that specifies additional options for the request.</param>
        /// <param name="currentToken">The continuation token.</param>
        /// <returns>A <see cref="RESTCommand{T}"/> that lists the queues.</returns>
        private RESTCommand<ResultSegment<CloudQueue>> ListQueuesImpl(string prefix, int? maxResults, QueueListingDetails queueListingDetails, QueueRequestOptions options, QueueContinuationToken currentToken)
        {
            QueueListingContext listingContext = new QueueListingContext(prefix, maxResults, queueListingDetails)
            {
                Marker = currentToken != null ? currentToken.NextMarker : null
            };

            RESTCommand<ResultSegment<CloudQueue>> getCmd = new RESTCommand<ResultSegment<CloudQueue>>(this.Credentials, this.BaseUri);

            getCmd.ApplyRequestOptions(options);
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequestDelegate = (uri, builder, serverTimeout, ctx) => QueueHttpWebRequestFactory.List(uri, serverTimeout, listingContext, queueListingDetails, ctx);
            getCmd.SignRequest = this.AuthenticationHandler.SignRequest;
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                ListQueuesResponse listQueuesResponse = new ListQueuesResponse(cmd.ResponseStream);

                List<CloudQueue> queuesList = new List<CloudQueue>(
                    listQueuesResponse.Queues.Select(item => new CloudQueue(item.Name, this)));

                QueueContinuationToken continuationToken = null;
                if (listQueuesResponse.NextMarker != null)
                {
                    continuationToken = new QueueContinuationToken()
                    {
                        NextMarker = listQueuesResponse.NextMarker,
                    };
                }

                return new ResultSegment<CloudQueue>(queuesList)
                {
                    ContinuationToken = continuationToken,
                };
            };

            return getCmd;
        }

        #region Analytics

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            return this.BeginGetServiceProperties(null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginGetServiceProperties(QueueRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = QueueRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return Executor.BeginExecuteAsync(
                this.GetServicePropertiesImpl(requestOptions),
                requestOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginGetServiceProperties(AsyncCallback, object)"/>.</param>
        /// <returns>A <see cref="ServiceProperties"/> object containing the queue service properties.</returns>
        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<ServiceProperties>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync()
        {
            return this.GetServicePropertiesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync(CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetServiceProperties, this.EndGetServiceProperties, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            return this.GetServicePropertiesAsync(requestOptions, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task{T}"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task<ServiceProperties> GetServicePropertiesAsync(QueueRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromApm(this.BeginGetServiceProperties, this.EndGetServiceProperties, requestOptions, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Gets the properties of the queue service.
        /// </summary>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        /// <returns>The queue service properties.</returns>
        [DoesServiceRequest]
        public ServiceProperties GetServiceProperties(QueueRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = QueueRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return Executor.ExecuteSync(
                this.GetServicePropertiesImpl(requestOptions),
                requestOptions.RetryPolicy,
                operationContext);
        }
#endif

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            return this.BeginSetServiceProperties(properties, null /* RequestOptions */, null /* OperationContext */, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="ICancellableAsyncResult"/> that references the asynchronous operation.</returns>
        [DoesServiceRequest]
        public ICancellableAsyncResult BeginSetServiceProperties(ServiceProperties properties, QueueRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            requestOptions = QueueRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            return Executor.BeginExecuteAsync(
                this.SetServicePropertiesImpl(properties, requestOptions),
                requestOptions.RetryPolicy,
                operationContext,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginSetServiceProperties(ServiceProperties, AsyncCallback, object)"/>.</param>
        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            Executor.EndExecuteAsync<NullType>(asyncResult);
        }

#if TASK
        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties)
        {
            return this.SetServicePropertiesAsync(properties, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetServiceProperties, this.EndSetServiceProperties, properties, cancellationToken);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.SetServicePropertiesAsync(properties, options, operationContext, CancellationToken.None);
        }

        /// <summary>
        /// Returns a task that performs an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the current operation.</returns>
        [DoesServiceRequest]
        public Task SetServicePropertiesAsync(ServiceProperties properties, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return AsyncExtensions.TaskFromVoidApm(this.BeginSetServiceProperties, this.EndSetServiceProperties, properties, options, operationContext, cancellationToken);
        }
#endif

#if SYNC
        /// <summary>
        /// Sets the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="requestOptions">A <see cref="QueueRequestOptions"/> object that specifies additional options for the request. Specifying null will use the default request options from the associated service client (<see cref="CloudQueueClient"/>).</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation. This object is used to track requests, and to provide additional runtime information about the operation.</param>
        [DoesServiceRequest]
        public void SetServiceProperties(ServiceProperties properties, QueueRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            requestOptions = QueueRequestOptions.ApplyDefaults(requestOptions, this);
            operationContext = operationContext ?? new OperationContext();
            Executor.ExecuteSync(this.SetServicePropertiesImpl(properties, requestOptions), requestOptions.RetryPolicy, operationContext);
        }
#endif

        private RESTCommand<ServiceProperties> GetServicePropertiesImpl(QueueRequestOptions requestOptions)
        {
            RESTCommand<ServiceProperties> retCmd = new RESTCommand<ServiceProperties>(this.Credentials, this.BaseUri);
            retCmd.BuildRequestDelegate = QueueHttpWebRequestFactory.GetServiceProperties;
            retCmd.SignRequest = this.AuthenticationHandler.SignRequest;
            retCmd.RetrieveResponseStream = true;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            retCmd.PostProcessResponse =
                (cmd, resp, ctx) => QueueHttpResponseParsers.ReadServiceProperties(cmd.ResponseStream);
            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        private RESTCommand<NullType> SetServicePropertiesImpl(ServiceProperties properties, QueueRequestOptions requestOptions)
        {
            MultiBufferMemoryStream str = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            try
            {
                properties.WriteServiceProperties(str);
            }
            catch (InvalidOperationException invalidOpException)
            {
                throw new ArgumentException(invalidOpException.Message, "properties");
            }

            str.Seek(0, SeekOrigin.Begin);

            RESTCommand<NullType> retCmd = new RESTCommand<NullType>(this.Credentials, this.BaseUri);
            retCmd.SendStream = str;
            retCmd.BuildRequestDelegate = QueueHttpWebRequestFactory.SetServiceProperties;
            retCmd.RecoveryAction = RecoveryActions.RewindStream;
            retCmd.SignRequest = this.AuthenticationHandler.SignRequest;
            retCmd.PreProcessResponse =
                (cmd, resp, ex, ctx) =>
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(System.Net.HttpStatusCode.Accepted, resp, NullType.Value, cmd, ex);
            retCmd.ApplyRequestOptions(requestOptions);
            return retCmd;
        }

        #endregion
    }
}

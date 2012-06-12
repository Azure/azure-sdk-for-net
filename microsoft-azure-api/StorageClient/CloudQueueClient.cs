//-----------------------------------------------------------------------
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
// <summary>
//    Contains code for the CloudQueueClient class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Provides a client for accessing the Windows Azure Queue service.
    /// </summary>
    public class CloudQueueClient
    {
        /// <summary>
        /// The default server and client timeout interval.
        /// </summary>
        private TimeSpan timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueClient"/> class using the specified
        /// Queue service endpoint and account credentials.
        /// </summary>
        /// <param name="baseAddress">The Queue service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudQueueClient(string baseAddress, StorageCredentials credentials)
            : this(new Uri(baseAddress), credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueClient"/> class using the specified
        /// Queue service endpoint and account credentials.
        /// </summary>
        /// <param name="baseAddressUri">The Queue service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudQueueClient(Uri baseAddressUri, StorageCredentials credentials)
            : this(null, baseAddressUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueClient"/> class.
        /// </summary>
        /// <param name="baseAddress">The base address.</param>
        /// <param name="credentials">The credentials.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> [use path style Uris].</param>
        internal CloudQueueClient(string baseAddress, StorageCredentials credentials, bool usePathStyleUris)
            : this(usePathStyleUris, new Uri(baseAddress), credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueClient"/> class.
        /// </summary>
        /// <param name="baseAddressUri">The base address Uri.</param>
        /// <param name="credentials">The credentials.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> [use path style Uris].</param>
        internal CloudQueueClient(Uri baseAddressUri, StorageCredentials credentials, bool usePathStyleUris)
            : this(usePathStyleUris, baseAddressUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueueClient"/> class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="baseAddressUri">The base address Uri.</param>
        /// <param name="credentials">The credentials.</param>
        internal CloudQueueClient(bool? usePathStyleUris, Uri baseAddressUri, StorageCredentials credentials)
        {
            CommonUtils.AssertNotNull("baseAddress", baseAddressUri);
            CommonUtils.AssertNotNull("credentials", credentials);

            this.BaseUri = baseAddressUri;

            if (!this.BaseUri.IsAbsoluteUri)
            {
                CommonUtils.ArgumentOutOfRange("baseAddress", baseAddressUri);
            }
            
            this.Timeout = Constants.DefaultClientSideTimeout;
            this.RetryPolicy = RetryPolicies.RetryExponential(RetryPolicies.DefaultClientRetryCount, RetryPolicies.DefaultClientBackoff);
            this.Credentials = credentials;
       
            if (usePathStyleUris.HasValue)
            {
                this.UsePathStyleUris = usePathStyleUris.Value;
            }
            else
            {
                // Automatically decide whether to use host style uri or path style uri
                this.UsePathStyleUris = CommonUtils.UsePathStyleAddressing(this.BaseUri);
            }
        }
        
        /// <summary>
        /// Occurs when a response is received from the server.
        /// </summary>
        public event EventHandler<ResponseReceivedEventArgs> ResponseReceived;

        /// <summary>
        /// Gets or sets the default retry policy for requests made via the Queue service client.
        /// </summary>
        /// <value>The retry policy.</value>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the server timeout for requests made via the Queue service client.
        /// </summary>
        /// <value>The server timeout interval.</value>
        public TimeSpan Timeout
        {
            get
            {
                return this.timeout;
            }

            set
            {
                Utilities.CheckTimeoutBounds(value);
                this.timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the lifetime of the approximate message count cache. Obsolete.
        /// </summary>
        /// <value>The lifetime of the approximate message count cache.</value>
        /// <remarks>The approximate message count is not cached. This is an obsolete property that has no effect.</remarks>
        [System.Obsolete("The approximate message count cache is obsolete. Use FetchAttributes to refresh the approximate message count as needed.")]
        public TimeSpan ApproximateMessageCountCacheLength { get; set; }

        /// <summary>
        /// Gets a value indicating whether requests made via the Queue service client will employ path-style URIs.
        /// </summary>
        /// <value><c>True</c> to use path-style URIs; otherwise, <c>false</c>.</value>
        public bool UsePathStyleUris { get; private set; }

        /// <summary>
        /// Gets the account credentials used to create the Queue service client.
        /// </summary>
        /// <value>An object of type <see cref="StorageCredentials"/>.</value>
        public StorageCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets the base URI for the Queue service client.
        /// </summary>
        /// <value>The base URI used to construct the Queue service client.</value>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets a reference to the queue at the specified address.
        /// </summary>
        /// <param name="queueAddress">Either the name of the queue, or the absolute URI to the queue.</param>
        /// <returns>A reference to the queue.</returns>
        public CloudQueue GetQueueReference(string queueAddress)
        {
            Uri queueUri = NavigationHelper.AppendPathToUri(this.BaseUri, queueAddress);

            return new CloudQueue(queueUri, this);
        }
        
        /// <summary>
        /// Returns an enumerable collection of the queues in the storage account.
        /// </summary>
        /// <returns>An enumerable collection of queues.</returns>
        public IEnumerable<CloudQueue> ListQueues()
        {
            return this.ListQueues(String.Empty);
        }

        /// <summary>
        /// Returns an enumerable collection of the queues in the storage account whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <returns>An enumerable collection of queues.</returns>
        public IEnumerable<CloudQueue> ListQueues(string prefix)
        {
            return this.ListQueues(prefix, QueueListingDetails.None);
        }
        
        /// <summary>
        /// Returns an enumerable collection of the queues in the storage account whose names begin with the specified prefix and that are retrieved lazily.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="detailsIncluded">One of the enumeration values that indicates which details to include in the listing.</param>
        /// <returns>An enumerable collection of queues that are retrieved lazily.</returns>
        public IEnumerable<CloudQueue> ListQueues(string prefix, QueueListingDetails detailsIncluded)
        {
            return CommonUtils.LazyEnumerateSegmented<CloudQueue>(
                (setResult) => this.ListQueuesImpl(prefix, detailsIncluded, null, null, setResult),
                this.RetryPolicy);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues
        /// in the storage account. 
        /// </summary>
        /// <returns>A result segment containing a collection of queues.</returns>
        public ResultSegment<CloudQueue> ListQueuesSegmented()
        {
            return this.ListQueuesSegmented(String.Empty, QueueListingDetails.None);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues
        /// in the storage account. 
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="detailsIncluded">One of the enumeration values that indicates which details to include in the listing.</param>
        /// <returns>A result segment containing a collection of queues.</returns>
        public ResultSegment<CloudQueue> ListQueuesSegmented(string prefix, QueueListingDetails detailsIncluded)
        {
            return this.ListQueuesSegmented(prefix, detailsIncluded, 0, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of queues
        /// whose names begin with the specified prefix. 
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="detailsIncluded">One of the enumeration values that indicates which details to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <returns>A result segment containing a collection of queues.</returns>
        public ResultSegment<CloudQueue> ListQueuesSegmented(string prefix, QueueListingDetails detailsIncluded, int maxResults, ResultContinuation continuationToken)
        {
            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<CloudQueue>>(
                (setResult) => this.ListQueuesImpl(prefix, detailsIncluded, continuationToken, maxResults, setResult),
                this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of queues
        /// in the storage account.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListQueuesSegmented(AsyncCallback callback, object state)
        {
            return this.BeginListQueuesSegmented(String.Empty, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of queues
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListQueuesSegmented(string prefix, AsyncCallback callback, object state)
        {
            return this.BeginListQueuesSegmented(prefix, QueueListingDetails.None, callback, state);
        }
        
        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of queues
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="detailsIncluded">One of the enumeration values that indicates which details to include in the listing.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListQueuesSegmented(string prefix, QueueListingDetails detailsIncluded, AsyncCallback callback, object state)
        {
            return this.BeginListQueuesSegmented(prefix, detailsIncluded, 0, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of queues
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The queue name prefix.</param>
        /// <param name="detailsIncluded">One of the enumeration values that indicates which details to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListQueuesSegmented(string prefix, QueueListingDetails detailsIncluded, int maxResults, ResultContinuation continuationToken, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ResultSegment<CloudQueue>>(
                (setResult) => this.ListQueuesImpl(prefix, detailsIncluded, continuationToken, maxResults, setResult),
                this.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection of queues.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment containing the results of the first request.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public ResultSegment<CloudQueue> EndListQueuesSegmented(IAsyncResult asyncResult) 
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<CloudQueue>>(asyncResult);
        }

        /// <summary>
        /// Gets the properties of the queue service.
        /// </summary>
        /// <returns>The queue service properties.</returns>
        public ServiceProperties GetServiceProperties()
        {
            return TaskImplHelper.ExecuteImplWithRetry<ServiceProperties>((setResult) => this.GetServicePropertiesImpl(setResult), this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ServiceProperties>((setResult) => this.GetServicePropertiesImpl(setResult), this.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get the properties of the queue service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginGetServiceProperties"/>.</param>
        /// <returns>The queue service properties.</returns>
        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ServiceProperties>(asyncResult);
        }

        /// <summary>
        /// Sets the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        public void SetServiceProperties(ServiceProperties properties)
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.SetServicePropertiesImpl(properties), this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(() => this.SetServicePropertiesImpl(properties), this.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to set the properties of the queue service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginSetServiceProperties"/>.</param>
        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Ends the get response.
        /// </summary>
        /// <param name="asyncresult">The asynchronous result.</param>
        /// <param name="req">The request.</param>
        /// <returns>The web response.</returns>
        internal WebResponse EndGetResponse(IAsyncResult asyncresult, WebRequest req)
        {
            return EventHelper.ProcessWebResponse(req, asyncresult, this.ResponseReceived, this);
        }

        /// <summary>
        /// Generates a task sequence for accessing the queue service.
        /// </summary>
        /// <param name="webRequest">A web request for accessing the queue service.</param>
        /// <param name="writeRequestAction">An action for writing data to the body of a web request.</param>
        /// <param name="processResponseAction">An action for processing the response received.</param>
        /// <param name="readResponseAction">An action for reading the response stream.</param>
        /// <returns>A task sequence for the operation.</returns>
        internal TaskSequence GenerateWebTask(
            HttpWebRequest webRequest,
            Action<Stream> writeRequestAction,
            Action<HttpWebResponse> processResponseAction,
            Action<Stream> readResponseAction)
        {
            return ProtocolHelper.GenerateServiceTask(
                webRequest,
                writeRequestAction,
                (request) => this.Credentials.SignRequest(request),
                (request) => request.GetResponseAsyncWithTimeout(this, this.Timeout),
                processResponseAction,
                readResponseAction);
        }

        /// <summary>
        /// Lists the queues impl.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="detailsIncluded">The details included.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="maxResults">The max results.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> for listing the queues.</returns>
        private TaskSequence ListQueuesImpl(
            string prefix,
            QueueListingDetails detailsIncluded,
            ResultContinuation continuationToken,
            int? maxResults,
            Action<ResultSegment<CloudQueue>> setResult)
        {
            ResultPagination pagination = new ResultPagination(maxResults.GetValueOrDefault());

            return this.ListQueuesImplCore(
                prefix,
                detailsIncluded,
                continuationToken,
                pagination,
                setResult);
        }

        /// <summary>
        /// Lists the queues impl core.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="detailsIncluded">The details included.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="pagination">The pagination.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> for listing the queues.</returns>
        private TaskSequence ListQueuesImplCore(
            string prefix,
            QueueListingDetails detailsIncluded,
            ResultContinuation continuationToken,
            ResultPagination pagination,
            Action<ResultSegment<CloudQueue>> setResult)
        {
            CommonUtils.AssertContinuationType(continuationToken, ResultContinuation.ContinuationType.Queue);

            ListingContext listingContext = new ListingContext(prefix, pagination.GetNextRequestPageSize())
            {
                Marker = continuationToken != null ? continuationToken.NextMarker : null
            };

            var queueList = new List<CloudQueue>();
            
            var webRequest = QueueRequest.List(this.BaseUri, this.Timeout.RoundUpToSeconds(), listingContext, detailsIncluded);
            this.Credentials.SignRequest(webRequest);

            var listTask = webRequest.GetResponseAsyncWithTimeout(this, this.Timeout);
            yield return listTask;

            string nextMarker;

            using (var response = listTask.Result as HttpWebResponse)
            {
                var parsedResponse = QueueResponse.List(response);

                // Materialize the results so that we can close the response
                queueList.AddRange(parsedResponse.Queues.Select((Func<QueueEntry, CloudQueue>)this.SelectResponse));

                nextMarker = parsedResponse.NextMarker;
            }

            ResultContinuation newContinuationToken = new ResultContinuation() { NextMarker = nextMarker, Type = ResultContinuation.ContinuationType.Queue };

            ResultSegment.CreateResultSegment(
                setResult,
                queueList,
                newContinuationToken,
                pagination,
                this.RetryPolicy,
                (paginationArg, continuationArg, resultSegment) =>
                    this.ListQueuesImplCore(prefix, detailsIncluded, continuationArg, paginationArg, resultSegment));
        }

        /// <summary>
        /// Selects the response.
        /// </summary>
        /// <param name="item">The item to parse.</param>
        /// <returns>A <see cref="CloudQueue"/> object representing the item.</returns>
        private CloudQueue SelectResponse(QueueEntry item)
        {
            CloudQueue info = new CloudQueue(item.Attributes, this);
            return info;
        }

        /// <summary>
        /// Generates a task sequence for getting the properties of the queue service.
        /// </summary>
        /// <param name="setResult">A delegate to receive the service properties.</param>
        /// <returns>A task sequence that gets the properties of the queue service.</returns>
        private TaskSequence GetServicePropertiesImpl(Action<ServiceProperties> setResult)
        {
            return this.GenerateWebTask(
                QueueRequest.GetServiceProperties(this.BaseUri, this.Timeout.RoundUpToSeconds()),
                null /* no request body */,
                null /* no response header processing */,
                (stream) => setResult(QueueResponse.ReadServiceProperties(stream)));
        }

        /// <summary>
        /// Generates a task sequence for setting the properties of the queue service.
        /// </summary>
        /// <param name="properties">The queue service properties to set.</param>
        /// <returns>A task sequence that sets the properties of the queue service.</returns>
        private TaskSequence SetServicePropertiesImpl(ServiceProperties properties)
        {
            CommonUtils.AssertNotNull("properties", properties);

            return this.GenerateWebTask(
                QueueRequest.SetServiceProperties(this.BaseUri, this.Timeout.RoundUpToSeconds()),
                (stream) =>
                {
                    try
                    {
                        QueueRequest.WriteServiceProperties(properties, stream);
                    }
                    catch (InvalidOperationException invalidOpException)
                    {
                        throw new ArgumentException(invalidOpException.Message, "properties");
                    }
                },
                null /* no response header processing */,
                null /* no response body */);
        }
    }
}

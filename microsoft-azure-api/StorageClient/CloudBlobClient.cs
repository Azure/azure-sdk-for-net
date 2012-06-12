//-----------------------------------------------------------------------
// <copyright file="CloudBlobClient.cs" company="Microsoft">
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
//    Contains code for the CloudBlobClient class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Tasks.ITask>;

    /// <summary>
    /// Provides a client for accessing the Windows Azure Blob service.
    /// </summary>
    public class CloudBlobClient
    {
        /// <summary>
        /// Constant for the max value of ParallelOperationThreadCount.
        /// </summary>
        private const int MaxParallelOperationThreadCount = 64;

        /// <summary>
        /// Stores the default delimiter.
        /// </summary>
        private string defaultDelimiter;

        /// <summary>
        /// Stores the parallelism factor.
        /// </summary>
        private int parallelismFactor = -1;

        /// <summary>
        /// Default is 32 MB.
        /// </summary>
        private long singleBlobUploadThresholdInBytes = Constants.MaxSingleUploadBlobSize / 2;

        /// <summary>
        /// Default is 4 MB.
        /// </summary>
        private long writeBlockSizeInBytes = Constants.DefaultWriteBlockSizeBytes;

        /// <summary>
        /// The default server and client timeout interval.
        /// </summary>
        private TimeSpan timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobClient"/> class to be used for anonymous access.
        /// </summary>
        /// <param name="baseAddress">The Blob service endpoint to use to create the client.</param>
        public CloudBlobClient(string baseAddress)
            : this(baseAddress, StorageCredentialsAnonymous.Anonymous)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobClient"/> class using the specified Blob service endpoint
        /// and account credentials.
        /// </summary>
        /// <param name="baseAddress">The Blob service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlobClient(string baseAddress, StorageCredentials credentials)
            : this(new Uri(baseAddress), credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobClient"/> class using the specified Blob service endpoint
        /// and account credentials.
        /// </summary>
        /// <param name="baseUri">The Blob service endpoint to use to create the client.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlobClient(Uri baseUri, StorageCredentials credentials)
            : this(null, baseUri, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobClient"/> class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="baseUri">The base Uri.</param>
        /// <param name="credentials">The credentials.</param>
        internal CloudBlobClient(bool? usePathStyleUris, Uri baseUri, StorageCredentials credentials)
        {
            CommonUtils.AssertNotNull("baseUri", baseUri);
            if (credentials == null)
            {
                credentials = StorageCredentialsAnonymous.Anonymous;
            }

            if (!baseUri.IsAbsoluteUri)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.RelativeAddressNotPermitted, baseUri.ToString());
                throw new ArgumentException(errorMessage, "baseUri");
            }

            this.BaseUri = baseUri;
            this.Credentials = credentials;
            this.RetryPolicy = RetryPolicies.RetryExponential(RetryPolicies.DefaultClientRetryCount, RetryPolicies.DefaultClientBackoff);
            this.Timeout = Constants.DefaultClientSideTimeout;
            this.DefaultDelimiter = "/";
            this.ReadAheadInBytes = Constants.DefaultReadAheadSizeBytes;
            this.UseIntegrityControlForStreamReading = true;

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
        /// Gets the account credentials used to create the Blob service client.
        /// </summary>
        /// <value>The account credentials.</value>
        public StorageCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets the base URI for the Blob service client.
        /// </summary>
        /// <value>The base URI used to construct the Blob service client.</value>
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Gets or sets the default retry policy for requests made via the Blob service client.
        /// </summary>
        /// <value>The retry policy.</value>
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the default server and client timeout for requests made by the Blob service client.
        /// </summary>
        /// <value>The server and client timeout interval.</value>
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
        /// Gets or sets the default delimiter that may be used to create a virtual directory structure of blobs.
        /// </summary>
        /// <value>The default delimiter.</value>
        public string DefaultDelimiter
        {
            get
            {
                return this.defaultDelimiter;
            }

            set
            {
                CommonUtils.AssertNotNullOrEmpty("DefaultDelimiter", value);
                this.defaultDelimiter = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum size of a blob in bytes that may be uploaded as a single blob. 
        /// </summary>
        /// <value>The maximum size of a blob, in bytes, that may be uploaded as a single blob,
        /// ranging from between 1 and 64 MB inclusive.</value>
        public long SingleBlobUploadThresholdInBytes
        {
            get
            {
                return this.singleBlobUploadThresholdInBytes;
            }

            set
            {
                if (value > Constants.MaxSingleUploadBlobSize || value < 1 * Constants.MB)
                {
                    throw new ArgumentOutOfRangeException("SingleBlobUploadThresholdInBytes");
                }

                this.singleBlobUploadThresholdInBytes = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum block size for writing to a block blob.
        /// </summary>
        /// <value>The maximum size of a block, in bytes, ranging from between 1 and 4 MB inclusive.</value>
        public long WriteBlockSizeInBytes
        {
            get
            {
                return this.writeBlockSizeInBytes;
            }

            set
            {
                if (value > Constants.DefaultWriteBlockSizeBytes || value < 1 * Constants.MB)
                {
                    throw new ArgumentOutOfRangeException("WriteBlockSizeInBytes");
                }

                this.writeBlockSizeInBytes = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of bytes to pre-fetch when reading from a stream.
        /// </summary>
        /// <value>The number of bytes to read ahead from a stream.</value>
        public long ReadAheadInBytes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the integrity of each block should be verified when reading from a stream.
        /// </summary>
        /// <value><c>True</c> if using integrity control for stream reading; otherwise, <c>false</c>. The default value is <c>true</c>.</value>
        public bool UseIntegrityControlForStreamReading { get; set; }

        /// <summary>
        /// Gets or sets the number of blocks that may be simultaneously uploaded when uploading a blob that is greater than 
        /// the value specified by the <see cref="SingleBlobUploadThresholdInBytes"/> property.
        /// in size.
        /// </summary>
        /// <value>The number of parallel operations that may proceed.</value>
        public int ParallelOperationThreadCount
        {
            get
            {
                if (this.parallelismFactor == -1)
                {
                    int workerThreads;
                    int ioThreads;
                    ThreadPool.GetMinThreads(out workerThreads, out ioThreads);
                    this.parallelismFactor = ioThreads;
                }

                return this.parallelismFactor;
            }

            set
            {
                CommonUtils.AssertInBounds("UploadParallelActiveTasks", value, 1, MaxParallelOperationThreadCount);

                this.parallelismFactor = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the service client is used with Path style or Host style.
        /// </summary>
        /// <value>Is <c>true</c> if use path style uris; otherwise, <c>false</c>.</value>
        internal bool UsePathStyleUris { get; private set; }

        /// <summary>
        /// Gets the properties of the blob service.
        /// </summary>
        /// <returns>The blob service properties.</returns>
        public ServiceProperties GetServiceProperties()
        {
            return TaskImplHelper.ExecuteImplWithRetry<ServiceProperties>((setResult) => this.GetServicePropertiesImpl(setResult), this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to get the properties of the blob service.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetServiceProperties(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ServiceProperties>((setResult) => this.GetServicePropertiesImpl(setResult), this.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get the properties of the blob service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginGetServiceProperties"/>.</param>
        /// <returns>The blob service properties.</returns>
        public ServiceProperties EndGetServiceProperties(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ServiceProperties>(asyncResult);
        }

        /// <summary>
        /// Sets the properties of the blob service.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        public void SetServiceProperties(ServiceProperties properties)
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.SetServicePropertiesImpl(properties), this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to set the properties of the blob service.
        /// </summary>
        /// <param name="properties">The blob service properties.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user defined object to be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetServiceProperties(ServiceProperties properties, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(() => this.SetServicePropertiesImpl(properties), this.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to set the properties of the blob service.
        /// </summary>
        /// <param name="asyncResult">The result returned from a prior call to <see cref="BeginSetServiceProperties"/>.</param>
        public void EndSetServiceProperties(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudPageBlob"/> object with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <returns>A reference to a page blob.</returns>
        [Obsolete]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CloudPageBlob GetPageBlob(string blobAddress)
        {
            return this.GetPageBlobReference(blobAddress);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudPageBlob"/> object with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <returns>A reference to a page blob.</returns>
        public CloudPageBlob GetPageBlobReference(string blobAddress)
        {
            return this.GetPageBlobReference(blobAddress, null);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudPageBlob"/> object with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a page blob.</returns>
        public CloudPageBlob GetPageBlobReference(string blobAddress, DateTime? snapshotTime)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAbsoluteUriString", blobAddress);
            return new CloudPageBlob(blobAddress, snapshotTime, this);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlockBlob"/> object with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <returns>A reference to a block blob.</returns>
        [Obsolete]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CloudBlockBlob GetBlockBlob(string blobAddress)
        {
            return this.GetBlockBlobReference(blobAddress);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlockBlob"/> with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string blobAddress)
        {
            return this.GetBlockBlobReference(blobAddress, null);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlockBlob"/> with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string blobAddress, DateTime? snapshotTime)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAbsoluteUriString", blobAddress);
            return new CloudBlockBlob(blobAddress, snapshotTime, this);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlob"/> with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <returns>A reference to a blob.</returns>
        public CloudBlob GetBlobReference(string blobAddress)
        {
            return this.GetBlobReference(blobAddress, null);
        }

        /// <summary>
        /// Returns a reference to a blob with the specified address.
        /// </summary>
        /// <param name="blobAddress">The absolute URI to the blob, or a relative URI beginning with the container name.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a blob.</returns>
        public CloudBlob GetBlobReference(string blobAddress, DateTime? snapshotTime)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAbsoluteUriString", blobAddress);
            return new CloudBlob(blobAddress, snapshotTime, this);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlobContainer"/> object with the specified address.
        /// </summary>
        /// <param name="containerAddress">The name of the container, or an absolute URI to the container.</param>
        /// <returns>A reference to a container.</returns>
        public CloudBlobContainer GetContainerReference(string containerAddress)
        {
            CommonUtils.AssertNotNullOrEmpty("containerAddress", containerAddress);
            return new CloudBlobContainer(containerAddress, this);
        }

        /// <summary>
        /// Returns a reference to a <see cref="CloudBlobDirectory"/> object with the specified address.
        /// </summary>
        /// <param name="blobDirectoryAddress">The absolute URI to the virtual directory, 
        /// or a relative URI beginning with the container name.</param>
        /// <returns>A reference to a virtual directory.</returns>
        public CloudBlobDirectory GetBlobDirectoryReference(string blobDirectoryAddress)
        {
            CommonUtils.AssertNotNullOrEmpty("blobDirectoryAddress", blobDirectoryAddress);
            return new CloudBlobDirectory(blobDirectoryAddress, this);
        }

        /// <summary>
        /// Returns an enumerable collection of containers.
        /// </summary>
        /// <returns>An enumerable collection of containers.</returns>
        public IEnumerable<CloudBlobContainer> ListContainers()
        {
            return this.ListContainers(null, ContainerListingDetails.None);
        }

        /// <summary>
        /// Returns an enumerable collection of containers whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <returns>An enumerable collection of containers.</returns>
        public IEnumerable<CloudBlobContainer> ListContainers(string prefix)
        {
            return this.ListContainers(prefix, ContainerListingDetails.None);
        }

        /// <summary>
        /// Returns an enumerable collection of containers whose names 
        /// begin with the specified prefix and that are retrieved lazily.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param>
        /// <returns>An enumerable collection of containers that are retrieved lazily.</returns>
        public IEnumerable<CloudBlobContainer> ListContainers(string prefix, ContainerListingDetails detailsIncluded)
        {
            return CommonUtils.LazyEnumerateSegmented<CloudBlobContainer>(
                (setResult) => this.ListContainersImpl(prefix, detailsIncluded, null, null, setResult),
                this.RetryPolicy);
        }

        /// <summary>
        /// Returns a result segment containing a collection of containers.
        /// </summary>
        /// <returns>A result segment of containers.</returns>
        public ResultSegment<CloudBlobContainer> ListContainersSegmented()
        {
            return this.ListContainersSegmented(null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of containers
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <returns>A result segment of containers.</returns>
        public ResultSegment<CloudBlobContainer> ListContainersSegmented(string prefix)
        {
            return this.ListContainersSegmented(prefix, ContainerListingDetails.None, 0, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of containers
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned 
        /// in the result segment, up to the per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <returns>A result segment of containers.</returns>
        public ResultSegment<CloudBlobContainer> ListContainersSegmented(
            string prefix,
            ContainerListingDetails detailsIncluded,
            int maxResults,
            ResultContinuation continuationToken)
        {
            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<CloudBlobContainer>>(
                (setResult) => this.ListContainersImpl(prefix, detailsIncluded, continuationToken, maxResults, setResult),
                this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of containers.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListContainersSegmented(AsyncCallback callback, object state)
        {
            return this.BeginListContainersSegmented(null, ContainerListingDetails.None, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of containers
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListContainersSegmented(string prefix, AsyncCallback callback, object state)
        {
            return this.BeginListContainersSegmented(prefix, ContainerListingDetails.None, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of containers
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded, AsyncCallback callback, object state)
        {
            return this.BeginListContainersSegmented(prefix, detailsIncluded, 0, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of containers
        /// whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The container name prefix.</param>
        /// <param name="detailsIncluded">A value that indicates whether to return container metadata with the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned 
        /// in the result segment, up to the per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListContainersSegmented(
            string prefix,
            ContainerListingDetails detailsIncluded,
            int maxResults,
            ResultContinuation continuationToken,
            AsyncCallback callback,
            object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ResultSegment<CloudBlobContainer>>(
                (setResult) => this.ListContainersImpl(prefix, detailsIncluded, continuationToken, maxResults, setResult),
                this.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection of containers.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment of containers.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public ResultSegment<CloudBlobContainer> EndListContainersSegmented(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<CloudBlobContainer>>(asyncResult);
        }

        /// <summary>
        /// Returns an enumerable collection of blob items whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute URI to the container.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/>.</returns>
        public IEnumerable<IListBlobItem> ListBlobsWithPrefix(string prefix)
        {
            return this.ListBlobsWithPrefix(prefix, false, BlobListingDetails.None, null);
        }

        /// <summary>
        /// Returns an enumerable collection of blob items whose names begin with the specified prefix and that are retrieved lazily. 
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute URI to the container.</param>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/> and are retrieved lazily.</returns>
        public IEnumerable<IListBlobItem> ListBlobsWithPrefix(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, BlobRequestOptions options)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this, options);

            return CommonUtils.LazyEnumerateSegmented<IListBlobItem>(
                (setResult) => this.ListBlobImpl(prefix, null, null, useFlatBlobListing, blobListingDetails, fullModifier, setResult),
                this.RetryPolicy);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items whose names
        /// begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute path to the container.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsWithPrefixSegmented(string prefix)
        {
            return this.ListBlobsWithPrefixSegmented(prefix, 0, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items whose names
        /// begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute path to the container.</param>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsWithPrefixSegmented(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails)
        {
            return this.ListBlobsWithPrefixSegmented(prefix, 0, null, useFlatBlobListing, blobListingDetails, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items whose names
        /// begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute path to the container.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the per-operation limit of 5000. 
        /// If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsWithPrefixSegmented(
            string prefix,
            int maxResults,
            ResultContinuation continuationToken)
        {
            return this.ListBlobsWithPrefixSegmented(prefix, maxResults, continuationToken, false, BlobListingDetails.None, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items whose names
        /// begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute path to the container.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the per-operation limit of 5000. 
        /// If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsWithPrefixSegmented(
            string prefix,
            int maxResults,
            ResultContinuation continuationToken,
            bool useFlatBlobListing,
            BlobListingDetails blobListingDetails,
            BlobRequestOptions options)
        {
            var fullModifier = BlobRequestOptions.CreateFullModifier(this, options);

            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<IListBlobItem>>(
               (setResult) => this.ListBlobImpl(prefix, continuationToken, maxResults, useFlatBlobListing, blobListingDetails, fullModifier, setResult),
               this.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection 
        /// of blob items whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute path to the container.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsWithPrefixSegmented(string prefix, AsyncCallback callback, object state)
        {
            return this.BeginListBlobsWithPrefixSegmented(prefix, 0, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection 
        /// of blob items whose names begin with the specified prefix.
        /// </summary>
        /// <param name="prefix">The blob name prefix. This value must be preceded either by the name of the container or by the absolute path to the container.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsWithPrefixSegmented(
            string prefix,
            int maxResults,
            ResultContinuation continuationToken,
            AsyncCallback callback,
            object state)
        {
            return TaskImplHelper.BeginImplWithRetry<ResultSegment<IListBlobItem>>(
                (setResult) => this.ListBlobImpl(prefix, continuationToken, maxResults, false, BlobListingDetails.None, null, setResult),
                this.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection 
        /// of blob items whose names begin with the specified prefix.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public ResultSegment<IListBlobItem> EndListBlobsWithPrefixSegmented(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<IListBlobItem>>(asyncResult);
        }

        /// <summary>
        /// Selects the protocol response.
        /// </summary>
        /// <param name="protocolItem">The protocol item.</param>
        /// <param name="service">The service.</param>
        /// <param name="container">The container.</param>
        /// <returns>The parsed <see cref="IListBlobItem"/>.</returns>
        internal static IListBlobItem SelectProtocolResponse(IListBlobEntry protocolItem, CloudBlobClient service, CloudBlobContainer container)
        {
            BlobEntry blob = protocolItem as BlobEntry;
            if (blob != null)
            {
                var attributes = blob.Attributes;
                CloudBlob cloudBlob;
                if (attributes.Properties.BlobType == BlobType.BlockBlob)
                {
                    cloudBlob = new CloudBlockBlob(attributes, service, ConvertDateTimeToSnapshotString(attributes.Snapshot));
                }
                else if (attributes.Properties.BlobType == BlobType.PageBlob)
                {
                    cloudBlob = new CloudPageBlob(attributes, service, ConvertDateTimeToSnapshotString(attributes.Snapshot));
                }
                else
                {
                    cloudBlob = new CloudBlob(attributes, service, ConvertDateTimeToSnapshotString(attributes.Snapshot));
                }

                return cloudBlob;
            }

            BlobPrefixEntry blobPrefix = protocolItem as BlobPrefixEntry;

            if (blobPrefix != null)
            {
                if (container != null)
                {
                    return container.GetDirectoryReference(blobPrefix.Name);
                }
                else
                {
                    return new CloudBlobDirectory(blobPrefix.Name, service);
                }
            }

            throw new InvalidOperationException("Invalid blob list item returned");
        }

        /// <summary>
        /// Ends the asynchronous GetResponse operation.
        /// </summary>
        /// <param name="asyncresult">An <see cref="IAsyncResult"/> that references the asynchronous operation.</param>
        /// <param name="req">The request to end the operation on.</param>
        /// <returns>The <see cref="WebResponse"/> from the asynchronous request.</returns>
        internal WebResponse EndGetResponse(IAsyncResult asyncresult, WebRequest req)
        {
            return EventHelper.ProcessWebResponse(req, asyncresult, this.ResponseReceived, this);
        }

        /// <summary>
        /// Gets the response for the operation.
        /// </summary>
        /// <param name="req">The request to end the operation on.</param>
        /// <returns>The <see cref="WebResponse"/> from the request.</returns>
        internal WebResponse GetResponse(WebRequest req)
        {
            return EventHelper.ProcessWebResponseSync(req, this.ResponseReceived, this);
        }

        /// <summary>
        /// Generates a task sequence for accessing the blob service.
        /// </summary>
        /// <param name="webRequestFunction">A function from timeout values to web requests.</param>
        /// <param name="writeRequestAction">An action for writing data to the body of a web request.</param>
        /// <param name="processResponseAction">An action for processing the response received.</param>
        /// <param name="readResponseAction">An action for reading the response stream.</param>
        /// <param name="options">The blob request options.</param>
        /// <returns>A task sequence for the operation.</returns>
        internal TaskSequence GenerateWebTask(
            Func<int, HttpWebRequest> webRequestFunction,
            Action<Stream> writeRequestAction,
            Action<HttpWebResponse> processResponseAction,
            Action<Stream> readResponseAction,
            BlobRequestOptions options)
        {
            return ProtocolHelper.GenerateServiceTask(
                ProtocolHelper.GetWebRequest(this, options, webRequestFunction),
                writeRequestAction,
                (request) => this.Credentials.SignRequest(request),
                (request) => request.GetResponseAsyncWithTimeout(this, options.Timeout),
                processResponseAction,
                readResponseAction);
        }

        /// <summary>
        /// Parses the user prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="listingPrefix">The listing prefix.</param>
        private static void ParseUserPrefix(string prefix, out string containerName, out string listingPrefix)
        {
            containerName = null;
            listingPrefix = null;

            string[] prefixParts = prefix.Split(NavigationHelper.SlashAsSplitOptions, 2, StringSplitOptions.None);
            if (prefixParts.Length == 1)
            {
                // No slash in prefix
                // Case abc => container = $root, prefix=abc; Listing with prefix at root
                listingPrefix = prefixParts[0];
            }
            else
            {
                // Case "/abc" => container=$root, prefix=abc; Listing with prefix at root
                // Case "abc/" => container=abc, no prefix; Listing all under a container
                // Case "abc/def" => container = abc, prefix = def; Listing with prefix under a container
                // Case "/" => container=$root, no prefix; Listing all under root
                containerName = prefixParts[0];
                listingPrefix = prefixParts[1];
            }

            if (string.IsNullOrEmpty(containerName))
            {
                containerName = "$root";
            }

            if (string.IsNullOrEmpty(listingPrefix))
            {
                listingPrefix = null;
            }
        }

        /// <summary>
        /// Converts the date time to snapshot string.
        /// </summary>
        /// <param name="snapshot">The snapshot time to convert.</param>
        /// <returns>A string representing the snapshot time.</returns>
        private static string ConvertDateTimeToSnapshotString(DateTime? snapshot)
        {
            if (snapshot.HasValue)
            {
                return Protocol.Request.ConvertDateTimeToSnapshotString(snapshot.Value);
            }

            return null;
        }

        /// <summary>
        /// Implementation for the ListContainers method.
        /// </summary>
        /// <param name="prefix">The container prefix.</param>
        /// <param name="detailsIncluded">The details included.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="maxResults">The maximum results to return.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the containers.</returns>
        private TaskSequence ListContainersImpl(
            string prefix,
            ContainerListingDetails detailsIncluded,
            ResultContinuation continuationToken,
            int? maxResults,
            Action<ResultSegment<CloudBlobContainer>> setResult)
        {
            ResultPagination pagination = new ResultPagination(maxResults.GetValueOrDefault());

            return this.ListContainersImplCore(prefix, detailsIncluded, continuationToken, pagination, setResult);
        }

        /// <summary>
        /// Core implementation for the ListContainers method.
        /// </summary>
        /// <param name="prefix">The container prefix.</param>
        /// <param name="detailsIncluded">The details included.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="pagination">The pagination.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the containers.</returns>
        private TaskSequence ListContainersImplCore(
            string prefix,
            ContainerListingDetails detailsIncluded,
            ResultContinuation continuationToken,
            ResultPagination pagination,
            Action<ResultSegment<CloudBlobContainer>> setResult)
        {
            CommonUtils.AssertContinuationType(continuationToken, ResultContinuation.ContinuationType.Container);

            ListingContext listingContext = new ListingContext(prefix, pagination.GetNextRequestPageSize())
            {
                Marker = continuationToken != null ? continuationToken.NextMarker : null
            };

            var containersList = new List<CloudBlobContainer>();

            var request = ContainerRequest.List(this.BaseUri, this.Timeout.RoundUpToSeconds(), listingContext, detailsIncluded);

            this.Credentials.SignRequest(request);

            var listTask = request.GetResponseAsyncWithTimeout(this, this.Timeout);

            yield return listTask;

            string nextMarker;

            using (var response = listTask.Result as HttpWebResponse)
            {
                ListContainersResponse listContainersResponse = ContainerResponse.List(response);

                containersList.AddRange(listContainersResponse.Containers.Select((item) => new CloudBlobContainer(item.Attributes, this)));

                nextMarker = listContainersResponse.NextMarker;
            }

            ResultContinuation newContinuationToken = new ResultContinuation() { NextMarker = nextMarker, Type = ResultContinuation.ContinuationType.Container };

            ResultSegment.CreateResultSegment(
                setResult,
                containersList,
                newContinuationToken,
                pagination,
                this.RetryPolicy,
                (paginationArg, continuationArg, resultSegmentArg) =>
                    this.ListContainersImplCore(
                        prefix,
                        detailsIncluded,
                        continuationArg,
                        paginationArg,
                        resultSegmentArg));
        }

        /// <summary>
        /// Implementation for the ListBlobs method.
        /// </summary>
        /// <param name="prefix">The blob prefix.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="maxResults">The max results.</param>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>
        /// A <see cref="TaskSequence"/> that lists the blobs.
        /// </returns>
        private TaskSequence ListBlobImpl(
            string prefix,
            ResultContinuation continuationToken,
            int? maxResults,
            bool useFlatBlobListing,
            BlobListingDetails blobListingDetails,
            BlobRequestOptions options,
            Action<ResultSegment<IListBlobItem>> setResult)
        {
            CommonUtils.AssertContinuationType(continuationToken, ResultContinuation.ContinuationType.Blob);

            string containerName = null;
            string listingPrefix = null;

            ParseUserPrefix(prefix, out containerName, out listingPrefix);
            var containerInfo = new CloudBlobContainer(containerName, this);

            var fullModifier = BlobRequestOptions.CreateFullModifier(this, options);

            return containerInfo.ListBlobsImpl(listingPrefix, useFlatBlobListing, blobListingDetails, fullModifier, continuationToken, maxResults, setResult);
        }

        /// <summary>
        /// Generates a task sequence for getting the properties of the blob service.
        /// </summary>
        /// <param name="setResult">A delegate to receive the service properties.</param>
        /// <returns>A task sequence that gets the properties of the blob service.</returns>
        private TaskSequence GetServicePropertiesImpl(Action<ServiceProperties> setResult)
        {
            return this.GenerateWebTask(
                (timeout) => BlobRequest.GetServiceProperties(this.BaseUri, timeout),
                null /* no request body */,
                null /* no response header processing */,
                (stream) => setResult(BlobResponse.ReadServiceProperties(stream)),
                BlobRequestOptions.CreateFullModifier<BlobRequestOptions>(this, null));
        }

        /// <summary>
        /// Generates a task sequence for setting the properties of the blob service.
        /// </summary>
        /// <param name="properties">The blob service properties to set.</param>
        /// <returns>A task sequence that sets the properties of the blob service.</returns>
        private TaskSequence SetServicePropertiesImpl(ServiceProperties properties)
        {
            CommonUtils.AssertNotNull("properties", properties);

            return this.GenerateWebTask(
                (timeout) => BlobRequest.SetServiceProperties(this.BaseUri, timeout),
                (stream) =>
                {
                    try
                    {
                        BlobRequest.WriteServiceProperties(properties, stream);
                    }
                    catch (InvalidOperationException invalidOpException)
                    {
                        throw new ArgumentException(invalidOpException.Message, "properties");
                    }
                },
                null /* no response header processing */,
                null /* no response body */,
                BlobRequestOptions.CreateFullModifier<BlobRequestOptions>(this, null));
        }
    }
}

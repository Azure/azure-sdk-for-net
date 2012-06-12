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
// <summary>
//    Contains code for the CloudBlobContainer class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Web;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Tasks.ITask>;

    /// <summary>
    /// Represents a container in the Windows Azure Blob service.
    /// </summary>
    public class CloudBlobContainer
    {
        /// <summary>
        /// Stores the transformed address.
        /// </summary>
        private Uri transformedAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerAddress">The absolute URI to the container.</param>
        public CloudBlobContainer(string containerAddress)
            : this(null, containerAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerAddress">The absolute URI to the container.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlobContainer(string containerAddress, StorageCredentials credentials)
            : this(containerAddress, new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(containerAddress, null), credentials))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerAddress">Either the absolute URI to the container, or the container name.</param>
        /// <param name="service">A client object that specifies the endpoint for the Blob service.</param>
        public CloudBlobContainer(string containerAddress, CloudBlobClient service)
        {
            this.Attributes = new BlobContainerAttributes();
            this.ServiceClient = service;

            Uri completeUri = NavigationHelper.AppendPathToUri(this.ServiceClient.BaseUri, containerAddress);

            this.ParseQueryAndVerify(completeUri, this.ServiceClient, this.ServiceClient.UsePathStyleUris);

            this.Name = NavigationHelper.GetContainerNameFromContainerAddress(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class with the given address and path style Uri preference.
        /// </summary>
        /// <param name="containerAddress">The container's address.</param>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        internal CloudBlobContainer(string containerAddress, bool usePathStyleUris)
            : this(usePathStyleUris, containerAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerAddress">The container address.</param>
        /// <param name="credentials">The credentials.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> path style Uris are used.</param>
        internal CloudBlobContainer(string containerAddress, StorageCredentials credentials, bool usePathStyleUris)
            : this(containerAddress, new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(containerAddress, usePathStyleUris), credentials))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="attrib">The attributes for the container (NOTE: Stored by reference).</param>
        /// <param name="client">The client to be used.</param>
        internal CloudBlobContainer(BlobContainerAttributes attrib, CloudBlobClient client)
        {
            this.ServiceClient = client;
            this.Attributes = attrib;

            Uri completeUri = NavigationHelper.AppendPathToUri(this.ServiceClient.BaseUri, attrib.Uri.AbsoluteUri);

            this.ParseQueryAndVerify(completeUri, this.ServiceClient, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="containerAddress">The container's address.</param>
        internal CloudBlobContainer(bool? usePathStyleUris, string containerAddress)
        {
            this.Attributes = new BlobContainerAttributes();

            Uri completeUri = new Uri(containerAddress);

            this.ParseQueryAndVerify(completeUri, null, usePathStyleUris);
        }

        /// <summary>
        /// Gets the service client for the container.
        /// </summary>
        /// <value>A client object that specifies the endpoint for the Blob service.</value>
        public CloudBlobClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the container's URI.
        /// </summary>
        /// <value>The absolute URI to the container.</value>
        public Uri Uri
        {
            get
            {
                return this.Attributes.Uri;
            }

            private set
            {
                this.Attributes.Uri = value;
            }
        }

        /// <summary>
        /// Gets the name of the container.
        /// </summary>
        /// <value>The container's name.</value>
        public string Name
        {
            get
            {
                return this.Attributes.Name;
            }

            private set
            {
                this.Attributes.Name = value;
            }
        }

        /// <summary>
        /// Gets the container's metadata.
        /// </summary>
        /// <value>The container's metadata.</value>
        public NameValueCollection Metadata
        {
            get
            {
                return this.Attributes.Metadata;
            }
        }

        /// <summary>
        /// Gets the container's attributes.
        /// </summary>
        /// <value>The container's attributes.</value>
        public BlobContainerAttributes Attributes { get; internal set; }

        /// <summary>
        /// Gets the container's system properties.
        /// </summary>
        /// <value>The container's properties.</value>
        public BlobContainerProperties Properties
        {
            get
            {
                return this.Attributes.Properties;
            }
        }

        /// <summary>
        /// Gets the Uri after applying authentication transformation.
        /// </summary>
        internal Uri TransformedAddress
        {
            get
            {
                if (this.ServiceClient.Credentials.NeedsTransformUri)
                {
                    // This is required to support key rotation
                    // Potential improvement: cache the value of credential and derived Uri to avoid recomputation
                    this.transformedAddress = new Uri(this.ServiceClient.Credentials.TransformUri(this.Uri.AbsoluteUri));

                    return this.transformedAddress;
                }
                else
                {
                    return this.Uri;
                }
            }
        }

        /// <summary>
        /// Gets a reference to a blob in this container.
        /// </summary>
        /// <param name="blobAddressUri">The name of the blob, or the absolute URI to the blob.</param>
        /// <returns>A reference to a blob.</returns>
        public CloudBlob GetBlobReference(string blobAddressUri)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAddressUri", blobAddressUri);

            return new CloudBlob(this.GetBlobAbsoluteUri(blobAddressUri), this.ServiceClient, this);
        }

        /// <summary>
        /// Gets a reference to a page blob in this container.
        /// </summary>
        /// <param name="blobAddressUri">The name of the blob, or the absolute URI to the blob.</param>
        /// <returns>A reference to a page blob.</returns>
        public CloudPageBlob GetPageBlobReference(string blobAddressUri)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAbsoluteUri", blobAddressUri);

            return new CloudPageBlob(this.GetBlobAbsoluteUri(blobAddressUri), this.ServiceClient, this);
        }

        /// <summary>
        /// Gets a reference to a block blob in this container.
        /// </summary>
        /// <param name="blobAddressUri">The name of the blob, or the absolute URI to the blob.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string blobAddressUri)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAbsoluteUri", blobAddressUri);

            return new CloudBlockBlob(this.GetBlobAbsoluteUri(blobAddressUri), this.ServiceClient, this);
        }

        /// <summary>
        /// Gets a reference to a virtual blob directory beneath this container.
        /// </summary>
        /// <param name="relativeAddress">The name of the virtual blob directory, or the absolute URI to the virtual blob directory.</param>
        /// <returns>A reference to a virtual blob directory.</returns>
        public CloudBlobDirectory GetDirectoryReference(string relativeAddress)
        {
            CommonUtils.AssertNotNullOrEmpty("relativeAddress", relativeAddress);

            var blobDirectoryUri = NavigationHelper.AppendPathToUri(this.Uri, relativeAddress);
            return new CloudBlobDirectory(blobDirectoryUri.AbsoluteUri, this.ServiceClient);
        }

        /// <summary>
        /// Returns an enumerable collection of the blobs in the container.
        /// </summary>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/>.</returns>
        public IEnumerable<IListBlobItem> ListBlobs()
        {
            return this.ListBlobs(false, BlobListingDetails.None, null);
        }

        /// <summary>
        /// Returns an enumerable collection of the blobs in the container that are retrieved lazily.
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/> and are retrieved lazily.</returns>
        public IEnumerable<IListBlobItem> ListBlobs(bool useFlatBlobListing, BlobListingDetails blobListingDetails)
        {
            return this.ListBlobs(useFlatBlobListing, blobListingDetails, null);
        }
        
        /// <summary>
        /// Returns an enumerable collection of the blobs in the container that are retrieved lazily.
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/> and are retrieved lazily.</returns>
        public IEnumerable<IListBlobItem> ListBlobs(bool useFlatBlobListing, BlobListingDetails blobListingDetails, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return CommonUtils.LazyEnumerateSegmented<IListBlobItem>(
                (setResult) => this.ListBlobsImpl(null, useFlatBlobListing, blobListingDetails, fullModifiers, null, null, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsSegmented()
        {
            return this.ListBlobsSegmented(false, BlobListingDetails.None);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsSegmented(bool useFlatBlobListing, BlobListingDetails blobListingDetails)
        {
            return this.ListBlobsSegmented(useFlatBlobListing, blobListingDetails, 0, null, null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsSegmented(bool useFlatBlobListing, BlobListingDetails blobListingDetails, int maxResults, ResultContinuation continuationToken, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<IListBlobItem>>(
                (setResult) => this.ListBlobsImpl(null, useFlatBlobListing, blobListingDetails, fullModifiers, continuationToken, maxResults, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsSegmented(AsyncCallback callback, object state)
        {
            return this.BeginListBlobsSegmented(false, BlobListingDetails.None, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsSegmented(bool useFlatBlobListing, BlobListingDetails blobListingDetails, AsyncCallback callback, object state)
        {
            return this.BeginListBlobsSegmented(useFlatBlobListing, blobListingDetails, 0, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsSegmented(
            bool useFlatBlobListing,
            BlobListingDetails blobListingDetails,
            int maxResults,
            ResultContinuation continuationToken,
            BlobRequestOptions options,
            AsyncCallback callback,
            object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<ResultSegment<IListBlobItem>>(
                (setResult) => this.ListBlobsImpl(null, useFlatBlobListing, blobListingDetails, fullModifiers, continuationToken, maxResults, setResult),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public ResultSegment<IListBlobItem> EndListBlobsSegmented(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<IListBlobItem>>(asyncResult);
        }

        /// <summary>
        /// Creates the container.
        /// </summary>
        public void Create()
        {
            this.Create(null);
        }

        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void Create(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(
                () => this.CreateContainerImpl(fullModifiers),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return this.BeginCreate(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreate(BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.CreateContainerImpl(fullModifiers),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndCreate(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Creates the container if it does not already exist.
        /// </summary>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise, <c>false</c>.</returns>
        public bool CreateIfNotExist()
        {
            return this.CreateIfNotExist(null);
        }

        /// <summary>
        /// Creates the container if it does not already exist.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise <c>false</c>.</returns>
        public bool CreateIfNotExist(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<bool>(
                (setResult) => this.CreateContainerIfNotExistImpl(fullModifiers, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to create the container if it does not already exist.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateIfNotExist(AsyncCallback callback, object state)
        {
            return this.BeginCreateIfNotExist(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to create the container if it does not already exist.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateIfNotExist(BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<bool>(
                (setResult) => this.CreateContainerIfNotExistImpl(fullModifiers, setResult),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Returns the result of an asynchronous request to create the container if it does not already exist.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the container did not already exist and was created; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndCreateIfNotExist(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Deletes the container.
        /// </summary>
        public void Delete()
        {
            this.Delete(null, null);
        }

        /// <summary>
        /// Deletes the container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void Delete(AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.DeleteContainerImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return this.BeginDelete(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDelete(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.DeleteContainerImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndDelete(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        public void SetPermissions(BlobContainerPermissions permissions)
        {
            this.SetPermissions(permissions, null, null);
        }

        /// <summary>
        /// Sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void SetPermissions(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.SetPermissionsImpl(permissions, accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, AsyncCallback callback, object state)
        {
            return this.BeginSetPermissions(permissions, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.SetPermissionsImpl(permissions, accessCondition, fullModifiers),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Returns the result of an asynchronous request to set permissions for the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Gets the permissions settings for the container.
        /// </summary>
        /// <returns>The container's permissions.</returns>
        public BlobContainerPermissions GetPermissions()
        {
            return this.GetPermissions(null, null);
        }

        /// <summary>
        /// Gets the permissions settings for the container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>The container's permissions.</returns>
        public BlobContainerPermissions GetPermissions(AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<BlobContainerPermissions>(
                (setResult) => this.GetPermissionsImpl(accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return this.BeginGetPermissions(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetPermissions(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<BlobContainerPermissions>(
                (setResult) => this.GetPermissionsImpl(accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The container's permissions.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public BlobContainerPermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<BlobContainerPermissions>(asyncResult);
        }

        /// <summary>
        /// Retrieves the container's attributes.
        /// </summary>
        public void FetchAttributes()
        {
            this.FetchAttributes(null, null);
        }

        /// <summary>
        /// Retrieves the container's attributes.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void FetchAttributes(AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.FetchAttributesImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve the container's attributes.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            return this.BeginFetchAttributes(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve the container's attributes.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginFetchAttributes(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.FetchAttributesImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to retrieve the container's attributes.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndFetchAttributes(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Sets the container's user-defined metadata.
        /// </summary>
        public void SetMetadata()
        {
            this.SetMetadata(null, null);
        }

        /// <summary>
        /// Sets the container's user-defined metadata.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void SetMetadata(AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            TaskImplHelper.ExecuteImplWithRetry(() => this.SetMetadataImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            return this.BeginSetMetadata(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetMetadata(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.SetMetadataImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous request operation to set user-defined metadata on the container.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndSetMetadata(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Returns a shared access signature for the container.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <returns>A shared access signature.</returns>
        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.GetSharedAccessSignature(policy, null);
        }

        /// <summary>
        /// Returns a shared access signature for the container.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="groupPolicyIdentifier">A container-level access policy.</param>
        /// <returns>A shared access signature.</returns>
        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        {
            if (!this.ServiceClient.Credentials.CanSignRequest)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
                throw new InvalidOperationException(errorMessage);
            }

            string resourceName = this.GetSharedAccessCanonicalName();

            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(policy, groupPolicyIdentifier, resourceName, this.ServiceClient);

            string accountKeyName = null;

            if (this.ServiceClient.Credentials is StorageCredentialsAccountAndKey)
            {
                accountKeyName = (this.ServiceClient.Credentials as StorageCredentialsAccountAndKey).AccountKeyName;
            }

            // Future resource type changes from "c" => "container"
            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(policy, groupPolicyIdentifier, "c", signature, accountKeyName);

            return builder.ToString();
        }

        /// <summary>
        /// Acquires a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <returns>The ID of the acquired lease.</returns>
        public string AcquireLease(TimeSpan? leaseTime, string proposedLeaseId)
        {
            return this.AcquireLease(leaseTime, proposedLeaseId, null, null);
        }

        /// <summary>
        /// Acquires a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <returns>The ID of the acquired lease.</returns>
        public string AcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CloudBlob.AcquireLeaseValidation(leaseTime, proposedLeaseId);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<string>(
                (setResult) => this.AcquireLeaseImpl(leaseTime, proposedLeaseId, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to acquire a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AsyncCallback callback, object state)
        {
            return this.BeginAcquireLease(leaseTime, proposedLeaseId, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to acquire a lease on this container.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            CloudBlob.AcquireLeaseValidation(leaseTime, proposedLeaseId);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<string>(
                (setResult) => this.AcquireLeaseImpl(leaseTime, proposedLeaseId, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy,
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
            return TaskImplHelper.EndImpl<string>(asyncResult);
        }

        /// <summary>
        /// Renews a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        public void RenewLease(AccessCondition accessCondition)
        {
            this.RenewLease(accessCondition, null);
        }

        /// <summary>
        /// Renews a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        public void RenewLease(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CloudBlob.RenewLeaseValidation(accessCondition);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(
                () => this.RenewLeaseImpl(accessCondition, fullModifiers),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginRenewLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginRenewLease(accessCondition, null, callback, state);
        }
        
        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginRenewLease(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            CloudBlob.RenewLeaseValidation(accessCondition);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.RenewLeaseImpl(accessCondition, fullModifiers),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to renew a lease on this container.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndRenewLease(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Changes the lease ID on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <returns>The new lease ID.</returns>
        public string ChangeLease(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.ChangeLease(proposedLeaseId, accessCondition, null);
        }
        
        /// <summary>
        /// Changes the lease ID on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <returns>The new lease ID.</returns>
        public string ChangeLease(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CloudBlob.ChangeLeaseValidation(proposedLeaseId, accessCondition);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<string>(
                (setResult) => this.ChangeLeaseImpl(proposedLeaseId, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy);
        }

         /// <summary>
        /// Begins an asynchronous operation to change the lease on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginChangeLease(proposedLeaseId, accessCondition, null, callback, state);
        }
        
        /// <summary>
        /// Begins an asynchronous operation to change the lease on this container.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            CloudBlob.ChangeLeaseValidation(proposedLeaseId, accessCondition);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<string>(
                (setResult) => this.ChangeLeaseImpl(proposedLeaseId, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy,
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
            return TaskImplHelper.EndImpl<string>(asyncResult);
        }

         /// <summary>
        /// Releases the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        public void ReleaseLease(AccessCondition accessCondition)
        {
            this.ReleaseLease(accessCondition, null);
        }
        
        /// <summary>
        /// Releases the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        public void ReleaseLease(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CloudBlob.ReleaseLeaseValidation(accessCondition);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(
                () => this.ReleaseLeaseImpl(accessCondition, fullModifiers),
                fullModifiers.RetryPolicy);
        }

         /// <summary>
        /// Begins an asynchronous operation to release the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginReleaseLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginReleaseLease(accessCondition, null, callback, state);
        }
        
        /// <summary>
        /// Begins an asynchronous operation to release the lease on this container.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container, including a required lease ID.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginReleaseLease(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            CloudBlob.ReleaseLeaseValidation(accessCondition);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.ReleaseLeaseImpl(accessCondition, fullModifiers),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to release the lease on this container.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndReleaseLease(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

         /// <summary>
        /// Breaks the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If null, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        public TimeSpan BreakLease(TimeSpan? breakPeriod)
        {
            return this.BreakLease(breakPeriod, null, null);
        }
        
        /// <summary>
        /// Breaks the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If null, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        public TimeSpan BreakLease(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CloudBlob.BreakLeaseValidation(breakPeriod);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<TimeSpan>(
                (setResult) => this.BreakLeaseImpl(breakPeriod, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy);
        }

          /// <summary>
        /// Begins an asynchronous operation to break the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If null, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AsyncCallback callback, object state)
        {
            return this.BeginBreakLease(breakPeriod, null, null, callback, state);
        }
        
        /// <summary>
        /// Begins an asynchronous operation to break the current lease on this container.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If null, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation. If null, default options will be used.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            CloudBlob.BreakLeaseValidation(breakPeriod);

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<TimeSpan>(
                (setResult) => this.BreakLeaseImpl(breakPeriod, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy,
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
            return TaskImplHelper.EndImpl<TimeSpan>(asyncResult);
        }

        /// <summary>
        /// Implementation for the ListBlobs method.
        /// </summary>
        /// <param name="prefix">The blob prefix.</param>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="maxResults">The maximum result size.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the blobs.</returns>
        internal TaskSequence ListBlobsImpl(
            string prefix,
            bool useFlatBlobListing,
            BlobListingDetails blobListingDetails,
            BlobRequestOptions options,
            ResultContinuation continuationToken,
            int? maxResults,
            Action<ResultSegment<IListBlobItem>> setResult)
        {
            ResultPagination pagination = new ResultPagination(maxResults.GetValueOrDefault());

            return this.ListBlobsImplCore(prefix, useFlatBlobListing, blobListingDetails, options, continuationToken, pagination, setResult);
        }

        /// <summary>
        /// Retrieve ETag and LastModified date time from response.
        /// </summary>
        /// <param name="response">The response to parse.</param>
        protected void ParseETagAndLastModified(HttpWebResponse response)
        {
            BlobContainerAttributes newProperties = ContainerResponse.GetAttributes(response);
            this.Properties.ETag = newProperties.Properties.ETag;
            this.Properties.LastModifiedUtc = newProperties.Properties.LastModifiedUtc;
        }

        /// <summary>
        /// Generates a task sequence for acquiring a lease.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation. This parameter must not be null.</param>
        /// <param name="setResult">A delegate for setting the result, which is the new lease ID.</param>
        /// <returns>A task sequence implementing the acquire lease operation.</returns>
        internal TaskSequence AcquireLeaseImpl(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, Action<string> setResult)
        {
            // The client library should always supply default options.
            CommonUtils.AssertNotNull("options", options);

            int leaseDuration = -1;

            if (leaseTime.HasValue)
            {
                // Lease duration is rounded down to seconds.
                leaseDuration = (int)leaseTime.Value.TotalSeconds;
            }

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => ContainerRequest.Lease(
                    this.TransformedAddress,
                    timeout,
                    LeaseAction.Acquire,
                    proposedLeaseId,
                    leaseDuration,
                    null /* break period */,
                    accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            Task<WebResponse> task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
                string leaseId = ContainerResponse.GetLeaseId(webResponse);

                setResult(leaseId);
            }
        }

        /// <summary>
        /// Generates a task sequence for renewing a lease.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation, including the current lease ID.
        /// This cannot be null.</param>
        /// <returns>A task sequence implementing the renew lease operation.</returns>
        internal TaskSequence RenewLeaseImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            // The client library should always supply default options.
            CommonUtils.AssertNotNull("options", options);

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => ContainerRequest.Lease(
                    this.TransformedAddress,
                    timeout,
                    LeaseAction.Renew,
                    null /* proposed lease ID */,
                    null /* lease duration */,
                    null /* break period */,
                    accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            Task<WebResponse> task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Generates a task sequence for changing a lease ID.
        /// </summary>
        /// <param name="proposedLeaseId">The proposed new lease ID.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation, including the current lease ID. This cannot be null.</param>
        /// <param name="setResult">A delegate for setting the result, which is the new lease ID.</param>
        /// <returns>A task sequence implementing the change lease ID operation.</returns>
        internal TaskSequence ChangeLeaseImpl(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, Action<string> setResult)
        {
            // The client library should always supply default options.
            CommonUtils.AssertNotNull("options", options);

            // The client library should always set a proposed lease ID.
            CommonUtils.AssertNotNull("proposedLeaseId", proposedLeaseId);

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => ContainerRequest.Lease(
                    this.TransformedAddress,
                    timeout,
                    LeaseAction.Change,
                    proposedLeaseId,
                    null /* lease duration */,
                    null /* break period */,
                    accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            Task<WebResponse> task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
                string leaseId = ContainerResponse.GetLeaseId(webResponse);

                setResult(leaseId);
            }
        }

        /// <summary>
        /// Generates a task sequence for releasing a lease.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation, including the current lease ID.
        /// This cannot be null.</param>
        /// <returns>A task sequence implementing the release lease operation.</returns>
        internal TaskSequence ReleaseLeaseImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            // The client library should always supply default options.
            CommonUtils.AssertNotNull("options", options);

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => ContainerRequest.Lease(
                    this.TransformedAddress,
                    timeout,
                    LeaseAction.Release,
                    null /* proposed lease ID */,
                    null /* lease duration */,
                    null /* break period */,
                    accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            Task<WebResponse> task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Generates a task sequence for breaking a lease.
        /// </summary>
        /// <param name="breakPeriod">The amount of time to allow the lease to remain, rounded down to seconds.
        /// If null, the break period is the remainder of the current lease, or zero for infinite leases.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">The options for this operation. Cannot be null.</param>
        /// <param name="setResult">A delegate for setting the result, which is the remaining time for the lease.</param>
        /// <returns>A task sequence implementing the break lease operation.</returns>
        internal TaskSequence BreakLeaseImpl(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, Action<TimeSpan> setResult)
        {
            // The client library should always supply default options.
            CommonUtils.AssertNotNull("options", options);

            int? breakSeconds = null;

            if (breakPeriod.HasValue)
            {
                // Break period is rounded down to seconds.
                breakSeconds = (int)breakPeriod.Value.TotalSeconds;
            }

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => ContainerRequest.Lease(
                    this.TransformedAddress,
                    timeout,
                    LeaseAction.Break,
                    null /* proposed lease ID */,
                    null /* lease duration */,
                    breakSeconds,
                    accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            Task<WebResponse> task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
                int? remainingLeaseTime = ContainerResponse.GetRemainingLeaseTime(webResponse);

                if (!remainingLeaseTime.HasValue)
                {
                    // Unexpected result from service.
                    throw new StorageClientException(StorageErrorCode.ServiceBadResponse, "Valid lease time expected but not received from the service.", webResponse.StatusCode, null, null);
                }

                setResult(TimeSpan.FromSeconds(remainingLeaseTime.Value));
            }
        }

        /// <summary>
        /// Converts the ACL string to a <see cref="BlobContainerPermissions"/> object.
        /// </summary>
        /// <param name="aclstring">The string to convert.</param>
        /// <returns>The resulting <see cref="BlobContainerPermissions"/> object.</returns>
        private static BlobContainerPermissions GetContainerAcl(string aclstring)
        {
            BlobContainerPublicAccessType accessType = BlobContainerPublicAccessType.Off;

            if (!string.IsNullOrEmpty(aclstring))
            {
                switch (aclstring.ToLower())
                {
                    case "container":
                        accessType = BlobContainerPublicAccessType.Container;
                        break;
                    case "blob":
                        accessType = BlobContainerPublicAccessType.Blob;
                        break;
                    default:
                        string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.InvalidAclType, aclstring);
                        throw new InvalidOperationException(errorMessage);
                }
            }

            return new BlobContainerPermissions()
            {
                PublicAccess = accessType
            };
        }

        /// <summary>
        /// Parse Uri for SAS (Shared access signature) information.
        /// </summary>
        /// <param name="completeUri">The complete Uri.</param>
        /// <param name="existingClient">The client to use.</param>
        /// <param name="usePathStyleUris">If true, path style Uris are used.</param>
        /// <remarks>
        /// Validate that no other query parameters are passed in.
        /// Any SAS information will be recorded as corresponding credentials instance.
        /// If existingClient is passed in, any SAS information found will not be supported.
        /// Otherwise a new client is created based on SAS information or as anonymous credentials.
        /// </remarks>
        private void ParseQueryAndVerify(Uri completeUri, CloudBlobClient existingClient, bool? usePathStyleUris)
        {
            CommonUtils.AssertNotNull("completeUri", completeUri);

            if (!completeUri.IsAbsoluteUri)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.RelativeAddressNotPermitted, completeUri.ToString());
                throw new ArgumentException(errorMessage, "address");
            }

            this.Uri = new Uri(completeUri.GetLeftPart(UriPartial.Path));

            StorageCredentialsSharedAccessSignature sasCreds;

            var queryParameters = HttpUtility.ParseQueryString(completeUri.Query);
            SharedAccessSignatureHelper.ParseQuery(queryParameters, out sasCreds);

            if (existingClient != null)
            {
                if (sasCreds != null && existingClient.Credentials != null && sasCreds != existingClient.Credentials)
                {
                    string error = string.Format(CultureInfo.CurrentCulture, SR.MultipleCredentialsProvided);
                    throw new ArgumentException(error);
                }
            }
            else
            {
                this.ServiceClient = new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(this.Uri.AbsoluteUri, usePathStyleUris), sasCreds);
            }
        }

        /// <summary>
        /// Returns the canonical name for shared access.
        /// </summary>
        /// <returns>The canonical name.</returns>
        private string GetSharedAccessCanonicalName()
        {
            if (this.ServiceClient.UsePathStyleUris)
            {
                return this.Uri.AbsolutePath;
            }
            else
            {
                return NavigationHelper.GetCanonicalPathFromCreds(this.ServiceClient.Credentials, this.Uri.AbsolutePath);
            }
        }

        /// <summary>
        /// Gets the absolute Uri of the blob.
        /// </summary>
        /// <param name="blobName">Name of the blob.</param>
        /// <returns>The blob's absolute Uri.</returns>
        private string GetBlobAbsoluteUri(string blobName)
        {
            var blobUri = NavigationHelper.AppendPathToUri(this.Uri, blobName);
            return blobUri.AbsoluteUri;
        }

        /// <summary>
        /// Core implementation of the ListBlobs method.
        /// </summary>
        /// <param name="prefix">The blob prefix.</param>
        /// <param name="useFlatBlobListing">Whether to list blobs in a flat listing, or whether to list blobs hierarchically, by virtual directory.</param>
        /// <param name="blobListingDetails">A <see cref="BlobListingDetails"/> enumeration describing which items to include in the listing.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="pagination">The pagination.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the blobs.</returns>
        private TaskSequence ListBlobsImplCore(
            string prefix,
            bool useFlatBlobListing,
            BlobListingDetails blobListingDetails,
            BlobRequestOptions options,
            ResultContinuation continuationToken,
            ResultPagination pagination,
            Action<ResultSegment<IListBlobItem>> setResult)
        {
            CommonUtils.AssertContinuationType(continuationToken, ResultContinuation.ContinuationType.Blob);
            CommonUtils.AssertNotNull("options", options);

            if (!useFlatBlobListing
                && (blobListingDetails & BlobListingDetails.Snapshots) == BlobListingDetails.Snapshots)
            {
                throw new ArgumentException(SR.ListSnapshotsWithDelimiterError, "blobListingDetails");
            }

            var delimiter = useFlatBlobListing ? null : this.ServiceClient.DefaultDelimiter;

            BlobListingContext listingContext = new BlobListingContext(prefix, pagination.GetNextRequestPageSize(), delimiter, blobListingDetails)
            {
                Marker = continuationToken != null ? continuationToken.NextMarker : null
            };

            var blobList = new List<IListBlobItem>();

            var request = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => BlobRequest.List(this.TransformedAddress, timeout, listingContext));
            this.ServiceClient.Credentials.SignRequest(request);
            var listTask = request.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return listTask;

            string nextMarker;
            using (var response = listTask.Result as HttpWebResponse)
            {
                ListBlobsResponse listBlobResponse = BlobResponse.List(response);
                blobList.AddRange(listBlobResponse.Blobs.Select(
                    (item) => CloudBlobClient.SelectProtocolResponse(item, this.ServiceClient, this)));

                nextMarker = listBlobResponse.NextMarker;
            }

            ResultContinuation newContinuationToken = new ResultContinuation() { NextMarker = nextMarker, Type = ResultContinuation.ContinuationType.Blob };

            ResultSegment.CreateResultSegment(
                setResult,
                blobList,
                newContinuationToken,
                pagination,
                options.RetryPolicy,
                (paginationArg, continuationArg, resultSegmentArg) =>
                    this.ListBlobsImplCore(prefix, useFlatBlobListing, blobListingDetails, options, continuationArg, paginationArg, resultSegmentArg));
        }

        /// <summary>
        /// Implementation for the Create method.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that creates the container.</returns>
        private TaskSequence CreateContainerImpl(BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.Create(this.Uri, timeout));
            ContainerRequest.AddMetadata(webRequest, this.Metadata);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                this.Attributes = ContainerResponse.GetAttributes(webResponse);
            }
        }

        /// <summary>
        /// Implementation for the CreateIfNotExist method.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that creates the container if it does not exist.</returns>
        private TaskSequence CreateContainerIfNotExistImpl(BlobRequestOptions options, Action<bool> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            var task = new InvokeTaskSequenceTask(() => this.CreateContainerImpl(options));
            yield return task;

            try
            {
                // Materialize exceptions
                var scratch = task.Result;
                setResult(true);
            }
            catch (StorageClientException e)
            {
                if (e.StatusCode == HttpStatusCode.Conflict && e.ExtendedErrorInformation.ErrorCode == StorageErrorCodeStrings.ContainerAlreadyExists)
                {
                    setResult(false);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Implementation for the Delete method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that deletes the container.</returns>
        private TaskSequence DeleteContainerImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.Delete(this.TransformedAddress, timeout, accessCondition));
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Implementation for the FetchAttributes method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that fetches the attributes.</returns>
        private TaskSequence FetchAttributesImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.GetProperties(this.TransformedAddress, timeout, accessCondition));
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                this.Attributes = ContainerResponse.GetAttributes(webResponse);
            }
        }

        /// <summary>
        /// Implementation for the SetMetadata method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the metadata.</returns>
        private TaskSequence SetMetadataImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.SetMetadata(this.TransformedAddress, timeout, accessCondition));
            ContainerRequest.AddMetadata(webRequest, this.Metadata);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                this.ParseETagAndLastModified(webResponse);
            }
        }

        /// <summary>
        /// Implementation for the SetPermissions method.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the permissions.</returns>
        private TaskSequence SetPermissionsImpl(BlobContainerPermissions acl, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            return this.ServiceClient.GenerateWebTask(
                (timeout) => ContainerRequest.SetAcl(this.TransformedAddress, timeout, acl.PublicAccess, accessCondition),
                (stream) => ContainerRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, stream),
                (response) => this.ParseETagAndLastModified(response),
                null /* no response body */,
                options);
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the container. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the permissions.</returns>
        private TaskSequence GetPermissionsImpl(AccessCondition accessCondition, BlobRequestOptions options, Action<BlobContainerPermissions> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            BlobContainerPermissions containerAcl = null;

            return this.ServiceClient.GenerateWebTask(
                (timeout) => ContainerRequest.GetAcl(this.TransformedAddress, timeout, accessCondition),
                null /* no request body */,
                (response) => 
                    {
                        containerAcl = GetContainerAcl(ContainerResponse.GetAcl(response));
                        this.ParseETagAndLastModified(response);
                    },
                (stream) => 
                {
                    // Get the policies from the web response.
                    ContainerResponse.ReadSharedAccessIdentifiers(stream, containerAcl);                   

                    setResult(containerAcl);
            },
            options);
        }
    }
}

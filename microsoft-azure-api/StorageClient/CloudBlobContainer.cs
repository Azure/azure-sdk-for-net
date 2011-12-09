//-----------------------------------------------------------------------
// <copyright file="CloudBlobContainer.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
            return this.ListBlobs(null);
        }

        /// <summary>
        /// Returns an enumerable collection of the blobs in the container that are retrieved lazily.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/> and are retrieved lazily.</returns>
        public IEnumerable<IListBlobItem> ListBlobs(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return CommonUtils.LazyEnumerateSegmented<IListBlobItem>(
                (setResult) => this.ListBlobsImpl(null, fullModifiers, null, null, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsSegmented(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<IListBlobItem>>(
                (setResult) => this.ListBlobsImpl(null, fullModifiers, null, null, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsSegmented(int maxResults, ResultContinuation continuationToken, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<IListBlobItem>>(
                (setResult) => this.ListBlobsImpl(null, fullModifiers, continuationToken, maxResults, setResult),
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
            return this.BeginListBlobsSegmented(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsSegmented(BlobRequestOptions options, AsyncCallback callback, object state)
        {
            return this.BeginListBlobsSegmented(0, null, options, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to return a result segment containing a collection of blob items 
        /// in the container.
        /// </summary>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsSegmented(
            int maxResults,
            ResultContinuation continuationToken,
            BlobRequestOptions options,
            AsyncCallback callback,
            object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<ResultSegment<IListBlobItem>>(
                (setResult) => this.ListBlobsImpl(null, fullModifiers, continuationToken, maxResults, setResult),
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
            this.Delete(null);
        }

        /// <summary>
        /// Deletes the container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void Delete(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.DeleteContainerImpl(fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return this.BeginDelete(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDelete(BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.DeleteContainerImpl(fullModifiers), fullModifiers.RetryPolicy, callback, state);
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
            this.SetPermissions(permissions, null);
        }

        /// <summary>
        /// Sets permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void SetPermissions(BlobContainerPermissions permissions, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.SetPermissionsImpl(permissions, fullModifiers), fullModifiers.RetryPolicy);
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
            return this.BeginSetPermissions(permissions, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the container.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the container.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetPermissions(BlobContainerPermissions permissions, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.SetPermissionsImpl(permissions, fullModifiers),
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
            return this.GetPermissions(null);
        }

        /// <summary>
        /// Gets the permissions settings for the container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>The container's permissions.</returns>
        public BlobContainerPermissions GetPermissions(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<BlobContainerPermissions>(
                (setResult) => this.GetPermissionsImpl(fullModifiers, setResult),
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
            return this.BeginGetPermissions(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetPermissions(BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<BlobContainerPermissions>(
                (setResult) => this.GetPermissionsImpl(fullModifiers, setResult),
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
            this.FetchAttributes(null);
        }

        /// <summary>
        /// Retrieves the container's attributes.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void FetchAttributes(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.FetchAttributesImpl(fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve the container's attributes.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            return this.BeginFetchAttributes(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to retrieve the container's attributes.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginFetchAttributes(BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.FetchAttributesImpl(fullModifiers), fullModifiers.RetryPolicy, callback, state);
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
            this.SetMetadata(null);
        }

        /// <summary>
        /// Sets the container's user-defined metadata.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void SetMetadata(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            TaskImplHelper.ExecuteImplWithRetry(() => this.SetMetadataImpl(fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the container.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            return this.BeginSetMetadata(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to set user-defined metadata on the container.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetMetadata(BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.SetMetadataImpl(fullModifiers), fullModifiers.RetryPolicy, callback, state);
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
        public string GetSharedAccessSignature(SharedAccessPolicy policy)
        {
            return this.GetSharedAccessSignature(policy, null);
        }

        /// <summary>
        /// Returns a shared access signature for the container.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="groupPolicyIdentifier">A container-level access policy.</param>
        /// <returns>A shared access signature.</returns>
        public string GetSharedAccessSignature(SharedAccessPolicy policy, string groupPolicyIdentifier)
        {
            if (!this.ServiceClient.Credentials.CanSignRequest)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
                throw new InvalidOperationException(errorMessage);
            }

            string resourceName = this.GetSharedAccessCanonicalName();

            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(policy, groupPolicyIdentifier, resourceName, this.ServiceClient);

            // Future resource type changes from "c" => "container"
            var builder = SharedAccessSignatureHelper.GetShareAccessSignatureImpl(policy, groupPolicyIdentifier, "c", signature);

            return builder.ToString();
        }

        /// <summary>
        /// Implementation for the ListBlobs method.
        /// </summary>
        /// <param name="prefix">The blob prefix.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="maxResults">The maximum result size.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the blobs.</returns>
        internal TaskSequence ListBlobsImpl(
            string prefix,
            BlobRequestOptions options,
            ResultContinuation continuationToken,
            int? maxResults,
            Action<ResultSegment<IListBlobItem>> setResult)
        {
            ResultPagination pagination = new ResultPagination(maxResults.GetValueOrDefault());

            return this.ListBlobsImplCore(prefix, options, continuationToken, pagination, setResult);
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
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="continuationToken">The continuation token.</param>
        /// <param name="pagination">The pagination.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that lists the blobs.</returns>
        private TaskSequence ListBlobsImplCore(
            string prefix,
            BlobRequestOptions options,
            ResultContinuation continuationToken,
            ResultPagination pagination,
            Action<ResultSegment<IListBlobItem>> setResult)
        {
            CommonUtils.AssertContinuationType(continuationToken, ResultContinuation.ContinuationType.Blob);
            CommonUtils.AssertNotNull("options", options);

            if (!options.UseFlatBlobListing
                && (options.BlobListingDetails & BlobListingDetails.Snapshots) == BlobListingDetails.Snapshots)
            {
                throw new ArgumentException(SR.ListSnapshotsWithDelimiterError, "options");
            }

            var delimiter = options.UseFlatBlobListing ? null : this.ServiceClient.DefaultDelimiter;

            BlobListingContext listingContext = new BlobListingContext(prefix, pagination.GetNextRequestPageSize(), delimiter, options.BlobListingDetails)
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
                    this.ListBlobsImplCore(prefix, options, continuationArg, paginationArg, resultSegmentArg));
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
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that deletes the container.</returns>
        private TaskSequence DeleteContainerImpl(BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.Delete(this.TransformedAddress, timeout));
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
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that fetches the attributes.</returns>
        private TaskSequence FetchAttributesImpl(BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.GetProperties(this.TransformedAddress, timeout));
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
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the metadata.</returns>
        private TaskSequence SetMetadataImpl(BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.SetMetadata(this.TransformedAddress, timeout));
            ContainerRequest.AddMetadata(webRequest, this.Metadata);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Implementation for the SetPermissions method.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the permissions.</returns>
        private TaskSequence SetPermissionsImpl(BlobContainerPermissions acl, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => ContainerRequest.SetAcl(this.TransformedAddress, timeout, acl.PublicAccess));

            using (var memoryStream = new SmallBlockMemoryStream(Constants.DefaultBufferSize))
            {
                ContainerRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, memoryStream);

                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);

                CommonUtils.ApplyRequestOptimizations(webRequest, memoryStream.Length);

                this.ServiceClient.Credentials.SignRequest(webRequest);

                var requestStreamTask = webRequest.GetRequestStreamAsync();
                yield return requestStreamTask;

                using (var requestStream = requestStreamTask.Result)
                {
                    // Copy the data
                    var copyTask = new InvokeTaskSequenceTask(() => { return memoryStream.WriteTo(requestStream); });
                    yield return copyTask;

                    // Materialize any exceptions
                    var scratch = copyTask.Result;
                }
            }

            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the permissions.</returns>
        private TaskSequence GetPermissionsImpl(BlobRequestOptions options, Action<BlobContainerPermissions> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(this.ServiceClient, options, (timeout) => ContainerRequest.GetAcl(this.TransformedAddress, timeout));
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                string publicAccess = ContainerResponse.GetAcl(webResponse);
                var containerAcl = GetContainerAcl(publicAccess);

                // Materialize results so that we can close the response
                AccessPolicyResponse policyResponse = new AccessPolicyResponse(webResponse.GetResponseStream());
                foreach (var item in policyResponse.AccessIdentifiers)
                {
                    containerAcl.SharedAccessPolicies.Add(item.Key, item.Value);
                }

                setResult(containerAcl);
            }
        }
    }
}

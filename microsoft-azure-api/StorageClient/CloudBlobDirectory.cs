//-----------------------------------------------------------------------
// <copyright file="CloudBlobDirectory.cs" company="Microsoft">
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
//    Contains code for the CloudBlobDirectory class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a virtual directory of blobs, designated by a delimiter character.
    /// </summary>
    public class CloudBlobDirectory : IListBlobItem
    {
        /// <summary>
        /// Stores the parent directory.
        /// </summary>
        private CloudBlobDirectory parent;

        /// <summary>
        /// Stores the parent container.
        /// </summary>
        private CloudBlobContainer container;

        /// <summary>
        /// Stores the prefix this directory represents.
        /// </summary>
        private string prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobDirectory"/> class given an address and a client.
        /// </summary>
        /// <param name="address">The blob directory's address.</param>
        /// <param name="service">The client to use.</param>
        internal CloudBlobDirectory(string address, CloudBlobClient service)
        {
            CommonUtils.AssertNotNullOrEmpty("address", address);
            CommonUtils.AssertNotNull("service", service);
            
            this.ServiceClient = service;
            
            if (!address.EndsWith(this.ServiceClient.DefaultDelimiter))
            {
                address = address + this.ServiceClient.DefaultDelimiter;
            }

            this.Uri = NavigationHelper.AppendPathToUri(service.BaseUri, address);            
        }

        /// <summary>
        /// Gets the service client for the virtual directory.
        /// </summary>
        /// <value>A client object that specifies the endpoint for the Blob service.</value>
        public CloudBlobClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the URI that identifies the virtual directory.
        /// </summary>
        /// <value>The URI to the virtual directory.</value>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the container for the virtual directory.
        /// </summary>
        /// <value>The container for the virtual directory.</value>
        public CloudBlobContainer Container
        {
            get
            {
                if (this.container == null)
                {
                    this.container = new CloudBlobContainer(
                        NavigationHelper.GetContainerAddress(this.Uri, this.ServiceClient.UsePathStyleUris),
                        this.ServiceClient.Credentials);
                }

                return this.container;
            }
        }

        /// <summary>
        /// Gets the parent directory for the virtual directory.
        /// </summary>
        /// <value>The virtual directory's parent directory.</value>
        public CloudBlobDirectory Parent
        {
            get
            {
                if (this.parent == null)
                {
                    this.parent = new CloudBlobDirectory(
                        NavigationHelper.GetParentAddress(
                            this.Uri,
                            this.ServiceClient.DefaultDelimiter,
                            this.ServiceClient.UsePathStyleUris),
                        this.ServiceClient);
                }

                return this.parent;
            }
        }

        /// <summary>
        /// Gets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        internal string Prefix
        {
            get
            {
                if (this.prefix == null)
                {
                    this.InitializePrefix();
                }

                return this.prefix;
            }
        }

        /// <summary>
        /// Returns a reference to a blob in this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the blob.</param>
        /// <returns>A reference to a blob.</returns>
        public CloudBlob GetBlobReference(string itemName) 
        {
            return this.GetBlobReference(itemName, null);
        }

        /// <summary>
        /// Returns a reference to a blob in this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a blob.</returns>
        public CloudBlob GetBlobReference(string itemName, DateTime? snapshotTime)
        {
            CommonUtils.AssertNotNull("itemName", itemName);

            Uri blobUri = NavigationHelper.AppendPathToUri(this.Uri, itemName, this.ServiceClient.DefaultDelimiter);
            return new CloudBlob(blobUri.AbsoluteUri, snapshotTime, this.ServiceClient);
        }

        /// <summary>
        /// Returns a reference to a page blob in this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the page blob.</param>
        /// <returns>A reference to a page blob.</returns>
        public CloudPageBlob GetPageBlobReference(string itemName) 
        {
            return this.GetPageBlobReference(itemName, null);
        }

        /// <summary>
        /// Returns a reference to a page blob in this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the page blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a page blob.</returns>
        public CloudPageBlob GetPageBlobReference(string itemName, DateTime? snapshotTime)
        {
            CommonUtils.AssertNotNull("itemName", itemName);

            Uri blobUri = NavigationHelper.AppendPathToUri(this.Uri, itemName, this.ServiceClient.DefaultDelimiter);
            return new CloudPageBlob(blobUri.AbsoluteUri, snapshotTime, this.ServiceClient);
        }

        /// <summary>
        /// Returns a reference to a block blob in this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the block blob.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string itemName) 
        {
            return this.GetBlockBlobReference(itemName, null);
        }

        /// <summary>
        /// Returns a reference to a block blob in this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the block blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string itemName, DateTime? snapshotTime)
        {
            CommonUtils.AssertNotNull("itemName", itemName);

            Uri blobUri = NavigationHelper.AppendPathToUri(this.Uri, itemName, this.ServiceClient.DefaultDelimiter);
            return new CloudBlockBlob(blobUri.AbsoluteUri, snapshotTime, this.ServiceClient);
        }

        /// <summary>
        /// Returns a virtual subdirectory within this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the virtual subdirectory.</param>
        /// <returns>A <see cref="CloudBlobDirectory"/> object representing the virtual subdirectory.</returns>
        public CloudBlobDirectory GetSubdirectory(string itemName) 
        {
            CommonUtils.AssertNotNull("itemName", itemName);
    
            Uri subdirectoryUri = NavigationHelper.AppendPathToUri(this.Uri, itemName, this.ServiceClient.DefaultDelimiter);
            return new CloudBlobDirectory(subdirectoryUri.AbsoluteUri, this.ServiceClient);
        }

        /// <summary>
        /// Returns an enumerable collection of blob items in this virtual directory that is lazily retrieved, either as a flat listing or by virtual subdirectory.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/> and are retrieved lazily.</returns>
        public IEnumerable<IListBlobItem> ListBlobs(BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return CommonUtils.LazyEnumerateSegmented<IListBlobItem>((setResult) => this.Container.ListBlobsImpl(this.Prefix, fullModifiers, null, null, setResult), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Returns an enumerable collection of blob items in this virtual directory, either as a flat listing or by virtual subdirectory.
        /// </summary>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobItem"/>.</returns>
        public IEnumerable<IListBlobItem> ListBlobs()
        {
            return this.ListBlobs(null);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items. 
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsSegmented(BlobRequestOptions options)
        {
            return this.ListBlobsSegmented(0, null, options);
        }

        /// <summary>
        /// Returns a result segment containing a collection of blob items. 
        /// </summary>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        public ResultSegment<IListBlobItem> ListBlobsSegmented(int maxResults, ResultContinuation continuationToken, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<ResultSegment<IListBlobItem>>((setResult) => this.Container.ListBlobsImpl(this.Prefix, fullModifiers, continuationToken, maxResults, setResult), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of blob items.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsSegmented(AsyncCallback callback, object state)
        {
            return this.BeginListBlobsSegmented(null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous request to return a result segment containing a collection of blob items.
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
        /// Begins an asynchronous request to return a result segment containing a collection of blob items.
        /// </summary>
        /// <param name="maxResults">A non-negative integer value that indicates the maximum number of results to be returned at a time, up to the 
        /// per-operation limit of 5000. If this value is zero, the maximum possible number of results will be returned, up to 5000.</param>         
        /// <param name="continuationToken">A continuation token returned by a previous listing operation.</param> 
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginListBlobsSegmented(int maxResults, ResultContinuation continuationToken, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<ResultSegment<IListBlobItem>>((setResult) => this.Container.ListBlobsImpl(this.Prefix, fullModifiers, continuationToken, maxResults, setResult), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous request to return a result segment containing a collection of blob items.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A result segment containing objects that implement <see cref="IListBlobItem"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public ResultSegment<IListBlobItem> EndListBlobsSegmented(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<ResultSegment<IListBlobItem>>(asyncResult);
        }

        /// <summary>
        /// Initializes the prefix.
        /// </summary>
        private void InitializePrefix()
        {
            // Need to add the trailing slash or MakeRelativeUri will return the containerName again
            var parentUri = new Uri(this.Container.Uri + NavigationHelper.Slash);

            this.prefix = Uri.UnescapeDataString(parentUri.MakeRelativeUri(this.Uri).OriginalString);
        }
    }
}

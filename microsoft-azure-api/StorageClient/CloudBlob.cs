//-----------------------------------------------------------------------
// <copyright file="CloudBlob.cs" company="Microsoft">
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
//    Contains code for the CloudBlob class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Tasks.ITask>;

    /// <summary>
    /// Represents a Windows Azure blob.
    /// </summary>
    public class CloudBlob : IListBlobItem
    {
        /// <summary>
        /// Stores the blob's attributes.
        /// </summary>
        private readonly BlobAttributes attributes;

        /// <summary>
        /// Stores the default timeout of a copy operation.
        /// </summary>
        private static readonly TimeSpan DefaultCopyTimeout = TimeSpan.FromHours(1);

        /// <summary>
        /// Stores the default polling interval of a copy operation.
        /// </summary>
        private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Stores the <see cref="CloudBlobContainer"/> that contains this blob.
        /// </summary>
        private CloudBlobContainer container;

        /// <summary>
        /// Stores the name of this blob.
        /// </summary>
        private string name;

        /// <summary>
        /// Stores the blob's parent <see cref="CloudBlobDirectory"/>.
        /// </summary>
        private CloudBlobDirectory parent;

        /// <summary>
        /// Stores the blob's transformed address.
        /// </summary>
        private Uri transformedAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        public CloudBlob(string blobAbsoluteUri)
            : this(null, blobAbsoluteUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class using an absolute URI to the blob
        /// and a set of credentials.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlob(string blobAbsoluteUri, StorageCredentials credentials)
            : this(blobAbsoluteUri, new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(blobAbsoluteUri, null), credentials))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class using an absolute URI to the blob, and the snapshot timestamp,
        /// if the blob is a snapshot.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlob(string blobAbsoluteUri, DateTime? snapshotTime, StorageCredentials credentials)
            : this(blobAbsoluteUri, snapshotTime, new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(blobAbsoluteUri, null), credentials))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class using a relative URI to the blob, and the snapshot timestamp,
        /// if the blob is a snapshot.
        /// </summary>
        /// <param name="blobUri">The relative URI to the blob, beginning with the container name.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="serviceClient">A client object that specifies the endpoint for the Blob service.</param>
        public CloudBlob(string blobUri, DateTime? snapshotTime, CloudBlobClient serviceClient)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAbsoluteUri", blobUri);
            CommonUtils.AssertNotNull("serviceClient", serviceClient);

            this.attributes = new BlobAttributes();
            this.ServiceClient = serviceClient;

            var completeUri = NavigationHelper.AppendPathToUri(this.ServiceClient.BaseUri, blobUri);

            this.ParseQueryAndVerify(completeUri, this.ServiceClient, this.ServiceClient.UsePathStyleUris);
            
            if (snapshotTime != null)
            {
                if (this.SnapshotTime != null)
                {
                    throw new ArgumentException(SR.SnapshotTimePassedTwice);
                }
                else
                {
                    this.SnapshotTime = snapshotTime;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class using a relative URI to the blob.
        /// </summary>
        /// <param name="blobUri">The relative URI to the blob, beginning with the container name.</param>
        /// <param name="serviceClient">A client object that specifies the endpoint for the Blob service.</param>
        public CloudBlob(string blobUri, CloudBlobClient serviceClient)
            : this(blobUri, null, serviceClient)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class based on an existing instance.
        /// </summary>
        /// <param name="cloudBlob">An existing reference to a blob.</param>
        public CloudBlob(CloudBlob cloudBlob)
        {
            this.attributes = cloudBlob.Attributes;
            this.container = cloudBlob.container;
            this.parent = cloudBlob.parent;

            this.ServiceClient = cloudBlob.ServiceClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class.
        /// </summary>
        /// <param name="blobAbsoluteUri">Absolute Uri.</param>
        /// <param name="usePathStyleUris">True to use path style Uri.</param>
        /// <remarks>
        /// Any authentication information inside the address will be used.
        /// Otherwise a blob for anonymous access is created.
        /// Any snapshot information as part of the address will be recorded
        /// Explicitly specify whether to use host style or path style Uri
        /// </remarks>
        internal CloudBlob(string blobAbsoluteUri, bool usePathStyleUris)
            : this(usePathStyleUris, blobAbsoluteUri)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class creating a new service client.
        /// </summary>
        /// <param name="blobAbsoluteUri">Complete Uri.</param>
        /// <param name="credentials">Storage credentials.</param>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        internal CloudBlob(string blobAbsoluteUri, StorageCredentials credentials, bool usePathStyleUris)
            : this(blobAbsoluteUri, new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(blobAbsoluteUri, usePathStyleUris), credentials))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class with the given absolute Uri.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="blobAbsoluteUri">The absolute blob Uri.</param>
        internal CloudBlob(bool? usePathStyleUris, string blobAbsoluteUri)
        {
            CommonUtils.AssertNotNullOrEmpty("blobAbsoluteUriString", blobAbsoluteUri);

            this.attributes = new BlobAttributes();

            var completeUri = new Uri(blobAbsoluteUri);

            this.ParseQueryAndVerify(completeUri, null, usePathStyleUris);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class with existing attributes.
        /// </summary>
        /// <param name="attributes">The attributes (NOTE: Saved by reference, does not make a copy).</param>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="snapshotTime">The snapshot time.</param>
        internal CloudBlob(BlobAttributes attributes, CloudBlobClient serviceClient, string snapshotTime)
        {
            this.attributes = attributes;
            this.ServiceClient = serviceClient;

            this.ParseQueryAndVerify(attributes.Uri, this.ServiceClient, this.ServiceClient.UsePathStyleUris);

            if (!string.IsNullOrEmpty(snapshotTime))
            {
                this.SnapshotTime = this.ParseSnapshotTime(snapshotTime);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class using the specified blob Uri.
        /// Note that this is just a reference to a blob instance and no requests are issued to the service
        /// yet to update the blob properties, attribute or metadata. FetchAttributes is the API that 
        /// issues such request to the service.
        /// </summary>
        /// <param name="blobUri">A relative Uri to the blob.</param>
        /// <param name="serviceClient">A <see cref="CloudBlobClient"/> object that specifies the endpoint for the Blob service.</param>
        /// <param name="containerReference">The reference to the parent container.</param>
        internal CloudBlob(string blobUri, CloudBlobClient serviceClient, CloudBlobContainer containerReference)
            : this(blobUri, null, serviceClient)
        {
            this.container = containerReference;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlob"/> class using the specified relative blob Uri.
        /// If snapshotTime is not null, the blob instance represents a Snapshot.
        /// Note that this is just a reference to a blob instance and no requests are issued to the service
        /// yet to update the blob properties, attribute or metadata. FetchAttributes is the API that 
        /// issues such request to the service.
        /// </summary>
        /// <param name="blobUri">A relative Uri to the blob.</param>
        /// <param name="snapshotTime">Snapshot time in case the blob is a snapshot.</param>
        /// <param name="serviceClient">A <see cref="CloudBlobClient"/> object that specifies the endpoint for the Blob service.</param>
        /// <param name="containerReference">The reference to the parent container.</param>
        internal CloudBlob(string blobUri, DateTime? snapshotTime, CloudBlobClient serviceClient, CloudBlobContainer containerReference)
            : this(blobUri, snapshotTime, serviceClient)
        {
            this.container = containerReference;
        }

        /// <summary>
        /// Gets the <see cref="DateTime"/> value that uniquely identifies the snapshot, if this blob is a snapshot.
        /// </summary>
        /// <value>A value that uniquely identifies the snapshot.</value>
        /// <remarks>
        /// If the blob is not a snapshot, this property returns <c>null</c>.
        /// </remarks>
        public DateTime? SnapshotTime
        {
            get { return this.attributes.Snapshot; }
            internal set { this.attributes.Snapshot = value; }
        }

        /// <summary>
        /// Gets the <see cref="CloudBlobClient"/> object that represents the Blob service.
        /// </summary>
        /// <value>A client object that specifies the Blob service endpoint.</value>
        public CloudBlobClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the URI that identifies the blob.
        /// </summary>
        /// <value>The address of the blob.</value>
        public Uri Uri
        {
            get
            {
                return this.attributes.Uri;
            }
        }

        /// <summary>
        /// Gets the <see cref="BlobAttributes"/> object that represents the blob's attributes.
        /// </summary>
        /// <value>The blob's attributes.</value>
        public BlobAttributes Attributes
        {
            get { return this.attributes; }
        }

        /// <summary>
        /// Gets the blob's user-defined metadata.
        /// </summary>
        /// <value>The blob's metadata.</value>
        public NameValueCollection Metadata
        {
            get
            {
                return this.attributes.Metadata;
            }

            internal set
            {
                this.attributes.Metadata = value;
            }
        }

        /// <summary>
        /// Gets the blob's system properties.
        /// </summary>
        /// <value>The blob's system properties.</value>
        public BlobProperties Properties
        {
            get
            {
                return this.attributes.Properties;
            }

            internal set
            {
                this.attributes.Properties = value;
            }
        }

        /// <summary>
        /// Gets the state of the most recent or pending copy operation.
        /// </summary>
        /// <value>A <see cref="CopyState"/> object containing the copy state, or null if no copy blob state exists for this blob.</value>
        public CopyState CopyState
        {
            get
            {
                return this.attributes.CopyState;
            }

            internal set
            {
                this.attributes.CopyState = value;
            }
        }

        /// <summary>
        /// Gets the blob's name.
        /// </summary>
        /// <value>The blob's name.</value>
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.name))
                {
                    this.name = Uri.UnescapeDataString(NavigationHelper.GetBlobName(this.Uri, this.ServiceClient.UsePathStyleUris));
                }

                return this.name;
            }
        }

        /// <summary>
        /// Gets a <see cref="CloudBlobContainer"/> object representing the blob's container.
        /// </summary>
        /// <value>The blob's container.</value>
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
        /// Gets the <see cref="CloudBlobDirectory"/> object representing the
        /// virtual parent directory for the blob.
        /// </summary>
        /// <value>The blob's virtual parent directory.</value>
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
        /// Gets a <see cref="CloudPageBlob"/> object based on this blob.
        /// </summary>
        /// <value>A reference to a page blob.</value>
        public CloudPageBlob ToPageBlob
        {
            get
            {
                var pageBlob = this as CloudPageBlob;

                if (pageBlob != null)
                {
                    return pageBlob;
                }

                return new CloudPageBlob(this);
            }
        }

        /// <summary>
        /// Gets a <see cref="CloudBlockBlob"/> object based on this blob.
        /// </summary>
        /// <value>A reference to a block blob.</value>
        public CloudBlockBlob ToBlockBlob
        {
            get
            {
                var blockBlob = this as CloudBlockBlob;

                if (blockBlob != null)
                {
                    return blockBlob;
                }

                return new CloudBlockBlob(this);
            }
        }

        /// <summary>
        /// Gets the Uri after applying authentication transformation.
        /// </summary>
        /// <value>The transformed address.</value>
        internal Uri TransformedAddress
        {
            get
            {
                if (this.ServiceClient.Credentials.NeedsTransformUri)
                {
                    // This is required to support key rotation
                    // Potential Improvement: Could get the latest credentials and compare against a cached
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
        /// Populates a blob's properties and metadata.
        /// </summary>
        public void FetchAttributes()
        {
            this.FetchAttributes(null, null);
        }

        /// <summary>
        /// Populates a blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void FetchAttributes(AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.FetchAttributesImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            return this.BeginFetchAttributes(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
        /// Ends an asynchronous operation to populate the blob's properties and metadata.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public void EndFetchAttributes(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Updates the blob's metadata.
        /// </summary>
        public void SetMetadata()
        {
            this.SetMetadata(null, null);
        }

        /// <summary>
        /// Updates the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void SetMetadata(AccessCondition accessCondition, BlobRequestOptions options)
        {
            this.VerifyNoWriteOperationForSnapshot();

            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.SetMetadataImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            return this.BeginSetMetadata(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetMetadata(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            this.VerifyNoWriteOperationForSnapshot();

            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.SetMetadataImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to update the blob's metadata.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public void EndSetMetadata(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Updates the blob's properties.
        /// </summary>
        public void SetProperties()
        {
            this.SetProperties(null, null);
        }

        /// <summary>
        /// Updates the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void SetProperties(AccessCondition accessCondition, BlobRequestOptions options)
        {
            this.VerifyNoWriteOperationForSnapshot();

            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.SetPropertiesImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetProperties(AsyncCallback callback, object state)
        {
            return this.BeginSetProperties(null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetProperties(AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            this.VerifyNoWriteOperationForSnapshot();

            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.SetPropertiesImpl(accessCondition, fullModifiers), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to update the blob's properties.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public void EndSetProperties(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }
        
        /// <summary>
        /// Requests that the service start to copy an existing blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        public string StartCopyFromBlob(CloudBlob source)
        {
            return this.StartCopyFromBlob(SourceBlobToUri(source), null, null, null);
        }

        /// <summary>
        /// Requests that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        public string StartCopyFromBlob(
            CloudBlob source,
            AccessCondition sourceAccessCondition,
            AccessCondition destAccessCondition,
            BlobRequestOptions options)
        {
            return this.StartCopyFromBlob(SourceBlobToUri(source), sourceAccessCondition, destAccessCondition, options);
        }

        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginStartCopyFromBlob(CloudBlob source, AsyncCallback callback, object state)
        {
            return this.BeginStartCopyFromBlob(SourceBlobToUri(source), null, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlob"/> object.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginStartCopyFromBlob(
            CloudBlob source,
            AccessCondition sourceAccessCondition,
            AccessCondition destAccessCondition,
            BlobRequestOptions options,
            AsyncCallback callback,
            object state)
        {
            return this.BeginStartCopyFromBlob(SourceBlobToUri(source), sourceAccessCondition, destAccessCondition, options, callback, state);
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
        public string StartCopyFromBlob(Uri source)
        {
            return this.StartCopyFromBlob(source, null, null, null);
        }

        /// <summary>
        /// Requests that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>The copy ID associated with the copy operation.</returns>
        /// <remarks>
        /// This method fetches the blob's ETag, last modified time, and part of the copy state.
        /// The copy ID and copy status fields are fetched, and the rest of the copy state is cleared.
        /// </remarks>
        public string StartCopyFromBlob(
            Uri source,
            AccessCondition sourceAccessCondition,
            AccessCondition destAccessCondition,
            BlobRequestOptions options)
        {
            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<string>(
                (setResult) => this.StartCopyFromBlobImpl(
                    source,
                    sourceAccessCondition,
                    destAccessCondition,
                    fullModifiers,
                    (getResult) => setResult(getResult())),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy a blob's contents, properties, and metadata to a new blob.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginStartCopyFromBlob(Uri source, AsyncCallback callback, object state)
        {
            return this.BeginStartCopyFromBlob(source, null, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to request that the service start to copy another blob's contents, properties, and metadata
        /// to the blob referenced by this <see cref="CloudBlob"/> object.
        /// </summary>
        /// <param name="source">The URI of a source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginStartCopyFromBlob(
            Uri source,
            AccessCondition sourceAccessCondition,
            AccessCondition destAccessCondition,
            BlobRequestOptions options,
            AsyncCallback callback,
            object state)
        {
            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<Func<string>>(
                (setResult) => this.StartCopyFromBlobImpl(source, sourceAccessCondition, destAccessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy,
                callback,
                state);
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public string EndStartCopyFromBlob(IAsyncResult asyncResult)
        {
            Func<string> getResultAndUpdate = TaskImplHelper.EndImpl<Func<string>>(asyncResult);
            return getResultAndUpdate();
        }

        /// <summary>
        /// Aborts an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        public void AbortCopy(string copyId)
        {
            this.AbortCopy(copyId, null, null);
        }

        /// <summary>
        /// Aborts an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void AbortCopy(string copyId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(
                () => this.AbortCopyImpl(copyId, accessCondition, fullModifiers),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginAbortCopy(string copyId, AsyncCallback callback, object state)
        {
            return this.BeginAbortCopy(copyId, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="copyId">A string identifying the copy operation.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginAbortCopy(string copyId, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.AbortCopyImpl(copyId, accessCondition, fullModifiers),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to abort an ongoing blob copy operation.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public void EndAbortCopy(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Deletes the blob.
        /// </summary>
        public void Delete()
        {
            this.Delete(DeleteSnapshotsOption.None, null, null);
        }

        /// <summary>
        /// Deletes the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void Delete(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImplWithRetry(() => this.DeleteBlobImpl(deleteSnapshotsOption, accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return this.BeginDelete(DeleteSnapshotsOption.None, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDelete(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry(() => this.DeleteBlobImpl(deleteSnapshotsOption, accessCondition, fullModifiers), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public void EndDelete(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Deletes the blob if it exists.
        /// </summary>
        /// <returns><c>true</c> if the blob was deleted; otherwise, <c>false</c>.</returns>
        public bool DeleteIfExists()
        {
            return this.DeleteIfExists(DeleteSnapshotsOption.None, null, null);
        }

        /// <summary>
        /// Deletes the blob if it exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns><c>true</c> if the blob was deleted; otherwise, <c>false</c>.</returns>
        public bool DeleteIfExists(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<bool>((setResult) => this.DeleteBlobIfExistsImpl(deleteSnapshotsOption, accessCondition, fullModifiers, setResult), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the blob if it exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            return this.BeginDeleteIfExists(DeleteSnapshotsOption.None, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the blob if it exists.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDeleteIfExists(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<bool>((setResult) => this.DeleteBlobIfExistsImpl(deleteSnapshotsOption, accessCondition, fullModifiers, setResult), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete the blob if it exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns><c>true</c> if the blob was successfully deleted; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<bool>(asyncResult);
        }

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <returns>A stream to be used for writing to the blob.</returns>
        public virtual BlobStream OpenWrite()
        {
            return this.OpenWrite(null, null);
        }

        /// <summary>
        /// Opens a stream for writing to the blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A stream to be used for writing to the blob.</returns>
        public virtual BlobStream OpenWrite(AccessCondition accessCondition, BlobRequestOptions options)
        {
            this.VerifyNoWriteOperationForSnapshot();

            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return new BlobWriteStream(this.ToBlockBlob, accessCondition, fullModifier, this.ServiceClient.WriteBlockSizeInBytes);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        public virtual void UploadFromStream(Stream source)
        {
            this.UploadFromStream(source, null, null);
        }

        /// <summary>
        /// Uploads a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public virtual void UploadFromStream(Stream source, AccessCondition accessCondition, BlobRequestOptions options)
        {
            this.VerifyNoWriteOperationForSnapshot();

            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            TaskImplHelper.ExecuteImpl(() => { return UploadFromStreamDispatch(source, accessCondition, fullModifier); });
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a stream to a block blob.
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public virtual IAsyncResult BeginUploadFromStream(Stream source, AsyncCallback callback, object state)
        {
            return this.BeginUploadFromStream(source, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="source">The stream providing the blob content.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public virtual IAsyncResult BeginUploadFromStream(Stream source, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            this.VerifyNoWriteOperationForSnapshot();

            var fullModifier = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImpl(() => { return this.UploadFromStreamDispatch(source, accessCondition, fullModifier); }, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to upload a stream to a block blob. 
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        public virtual void EndUploadFromStream(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Uploads a string of text to a block blob. 
        /// </summary>
        /// <param name="content">The text to upload, encoded as a UTF-8 string.</param>
        public virtual void UploadText(string content)
        {
            this.UploadText(content, Encoding.UTF8, null, null);
        }

        /// <summary>
        /// Uploads a string of text to a block blob. 
        /// </summary>
        /// <param name="content">The text to upload.</param>
        /// <param name="encoding">An object that indicates the text encoding to use.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public virtual void UploadText(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options)
        {
            this.UploadByteArray(encoding.GetBytes(content), accessCondition, options);
        }

        /// <summary>
        /// Uploads a file from the file system to a block blob.
        /// </summary>
        /// <param name="fileName">The path and file name of the file to upload.</param>
        public virtual void UploadFile(string fileName)
        {
            this.UploadFile(fileName, null, null);
        }

        /// <summary>
        /// Uploads a file from the file system to a block blob.
        /// </summary>
        /// <param name="fileName">The path and file name of the file to upload.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public virtual void UploadFile(string fileName, AccessCondition accessCondition, BlobRequestOptions options)
        {
            using (var data = File.OpenRead(fileName))
            {
                this.UploadFromStream(data, accessCondition, options);
            }
        }

        /// <summary>
        /// Uploads an array of bytes to a block blob.
        /// </summary>
        /// <param name="content">The array of bytes to upload.</param>
        public virtual void UploadByteArray(byte[] content)
        {
            this.UploadByteArray(content, null, null);
        }

        /// <summary>
        /// Uploads an array of bytes to a blob.
        /// </summary>
        /// <param name="content">The array of bytes to upload.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public virtual void UploadByteArray(byte[] content, AccessCondition accessCondition, BlobRequestOptions options)
        {
            using (var data = new MemoryStream(content))
            {
                this.UploadFromStream(data, accessCondition, options);
            }
        }

        /// <summary>
        /// Opens a stream for reading the blob's contents.
        /// </summary>
        /// <returns>A stream to use for reading from the blob.</returns>
        public BlobStream OpenRead()
        {
            return this.OpenRead(null, null);
        }

        /// <summary>
        /// Opens a stream for reading the blob's contents.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A stream to use for reading from the blob.</returns>
        public BlobStream OpenRead(AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            return new BlobReadStream(this, accessCondition, fullModifiers, this.ServiceClient.ReadAheadInBytes, this.ServiceClient.UseIntegrityControlForStreamReading);
        }

        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        public void DownloadToStream(Stream target)
        {
            this.DownloadToStream(target, null, null);
        }

        /// <summary>
        /// Downloads the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void DownloadToStream(Stream target, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            TaskImplHelper.ExecuteSyncTaskWithRetry(this.DownloadToStreamSyncImpl(target, accessCondition, fullModifiers), fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDownloadToStream(Stream target, AsyncCallback callback, object state)
        {
            return this.BeginDownloadToStream(target, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDownloadToStream(Stream target, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            var fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            return TaskImplHelper.BeginImplWithRetry(() => this.DownloadToStreamImpl(target, accessCondition, fullModifiers), fullModifiers.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to download the contents of a blob to a stream.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public void EndDownloadToStream(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Downloads the blob's contents.
        /// </summary>
        /// <returns>The contents of the blob, as a string.</returns>
        public string DownloadText()
        {
            return this.DownloadText(null, null);
        }

        /// <summary>
        /// Downloads the blob's contents.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>The contents of the blob, as a string.</returns>
        public string DownloadText(AccessCondition accessCondition, BlobRequestOptions options)
        {
            Encoding encoding = GetDefaultEncoding();

            byte[] array = this.DownloadByteArray(accessCondition, options);

            return encoding.GetString(array);
        }

        /// <summary>
        /// Downloads the blob's contents to a file.
        /// </summary>
        /// <param name="fileName">The path and file name of the target file.</param>
        public void DownloadToFile(string fileName)
        {
            this.DownloadToFile(fileName, null, null);
        }

        /// <summary>
        /// Downloads the blob's contents to a file.
        /// </summary>
        /// <param name="fileName">The path and file name of the target file.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        public void DownloadToFile(string fileName, AccessCondition accessCondition, BlobRequestOptions options)
        {
            using (var fileStream = File.Create(fileName))
            {
                this.DownloadToStream(fileStream, accessCondition, options);
            }
        }

        /// <summary>
        /// Downloads the blob's contents as an array of bytes.
        /// </summary>
        /// <returns>The contents of the blob, as an array of bytes.</returns>
        public byte[] DownloadByteArray()
        {
            return this.DownloadByteArray(null, null);
        }

        /// <summary>
        /// Downloads the blob's contents as an array of bytes. 
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>The contents of the blob, as an array of bytes.</returns>
        public byte[] DownloadByteArray(AccessCondition accessCondition, BlobRequestOptions options)
        {
            using (var memoryStream = new MemoryStream())
            {
                this.DownloadToStream(memoryStream, accessCondition, options);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Creates a snapshot of the blob.
        /// </summary>
        /// <returns>A blob snapshot.</returns>
        public CloudBlob CreateSnapshot()
        {
            return this.CreateSnapshot(null, null, null);
        }

        /// <summary>
        /// Creates a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <returns>A blob snapshot.</returns>
        public CloudBlob CreateSnapshot(NameValueCollection metadata)
        {
            return this.CreateSnapshot(metadata, null, null);
        }

        /// <summary>
        /// Creates a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request, or <c>null</c>.</param>
        /// <returns>A blob snapshot.</returns>
        public CloudBlob CreateSnapshot(NameValueCollection metadata, AccessCondition accessCondition, BlobRequestOptions options)
        {
            this.VerifyNoWriteOperationForSnapshot();

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.ExecuteImplWithRetry<CloudBlob>(
                (setResult) => this.CreateSnapshotImpl(metadata, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateSnapshot(AsyncCallback callback, object state)
        {
            return this.BeginCreateSnapshot(null, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateSnapshot(NameValueCollection metadata, AsyncCallback callback, object state)
        {
            return this.BeginCreateSnapshot(metadata, null, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request, or <c>null</c>.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateSnapshot(NameValueCollection metadata, AccessCondition accessCondition, BlobRequestOptions options, AsyncCallback callback, object state)
        {
            this.VerifyNoWriteOperationForSnapshot();

            BlobRequestOptions fullModifiers = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);

            return TaskImplHelper.BeginImplWithRetry<CloudBlob>(
                (setResult) => this.CreateSnapshotImpl(metadata, accessCondition, fullModifiers, setResult),
                fullModifiers.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a snapshot of the blob.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A blob snapshot.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public CloudBlob EndCreateSnapshot(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<CloudBlob>(asyncResult);
        }

        /// <summary>
        /// Returns a shared access signature for the blob.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <returns>A shared access signature.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the current credentials don't support creating a shared access signature.</exception>
        /// <exception cref="NotSupportedException">Thrown if blob is a snapshot.</exception>
        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.GetSharedAccessSignature(policy, null);
        }

        /// <summary>
        /// Returns a shared access signature for the blob.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="groupPolicyIdentifier">A container-level access policy.</param>
        /// <returns>A shared access signature.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the current credentials don't support creating a shared access signature.</exception>
        /// <exception cref="NotSupportedException">Thrown if blob is a snapshot.</exception>
        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        {
            if (!this.ServiceClient.Credentials.CanSignRequest)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
                throw new InvalidOperationException(errorMessage);
            }

            if (this.SnapshotTime != null)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASForSnapshot);
                throw new NotSupportedException(errorMessage);
            }

            string resourceName = this.GetCanonicalName(true);

            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(policy, groupPolicyIdentifier, resourceName, this.ServiceClient);

            string accountKeyName = null;

            if (this.ServiceClient.Credentials is StorageCredentialsAccountAndKey)
            {
                accountKeyName = (this.ServiceClient.Credentials as StorageCredentialsAccountAndKey).AccountKeyName;
            }

            // Future resource type changes from "b" => "blob"
            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(policy, groupPolicyIdentifier, "b", signature, accountKeyName);

            return builder.ToString();
        }

        /// <summary>
        /// Acquires a lease on this blob.
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
        /// Acquires a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
        /// Begins an asynchronous operation to acquire a lease on this blob.
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
        /// Begins an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
        /// Ends an asynchronous operation to acquire a lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>The ID of the acquired lease.</returns>
        public string EndAcquireLease(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<string>(asyncResult);
        }

        /// <summary>
        /// Renews a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
        public void RenewLease(AccessCondition accessCondition)
        {
            this.RenewLease(accessCondition, null);
        }

        /// <summary>
        /// Renews a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
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
        /// Begins an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginRenewLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginRenewLease(accessCondition, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
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
        /// Ends an asynchronous operation to renew a lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndRenewLease(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Changes the lease ID on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <returns>The new lease ID.</returns>
        public string ChangeLease(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.ChangeLease(proposedLeaseId, accessCondition, null);
        }

        /// <summary>
        /// Changes the lease ID on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
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
        /// Begins an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginChangeLease(proposedLeaseId, accessCondition, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease. This cannot be null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
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
        /// Ends an asynchronous operation to change the lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>The new lease ID.</returns>
        public string EndChangeLease(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<string>(asyncResult);
        }

        /// <summary>
        /// Releases the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
        public void ReleaseLease(AccessCondition accessCondition)
        {
            this.ReleaseLease(accessCondition, null);
        }

        /// <summary>
        /// Releases the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
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
        /// Begins an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
        /// <param name="callback">An optional callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginReleaseLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            return this.BeginReleaseLease(accessCondition, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob, including a required lease ID.</param>
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
        /// Ends an asynchronous operation to release the lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        public void EndReleaseLease(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Breaks the current lease on this blob.
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
        /// Breaks the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If null, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
        /// Begins an asynchronous operation to break the current lease on this blob.
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
        /// Begins an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="breakPeriod">A <see cref="TimeSpan"/> representing the amount of time to allow the lease to remain,
        /// which will be rounded down to seconds. If null, the break period is the remainder of the current lease,
        /// or zero for infinite leases.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
        /// Ends an asynchronous operation to break the current lease on this blob.
        /// </summary>
        /// <param name="asyncResult">An IAsyncResult that references the pending asynchronous operation.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the amount of time before the lease ends, to the second.</returns>
        public TimeSpan EndBreakLease(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<TimeSpan>(asyncResult);
        }

        /// <summary>
        /// Validates the parameters to an AcquireLease operation.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease.</param>
        internal static void AcquireLeaseValidation(TimeSpan? leaseTime, string proposedLeaseId)
        {
            if (leaseTime.HasValue)
            {
                CommonUtils.AssertInBounds("leaseTime", leaseTime.Value, TimeSpan.FromSeconds(1), TimeSpan.MaxValue);
            }
        }

        /// <summary>
        /// Validates the parameters to a RenewLease operation.
        /// </summary>
        /// <param name="accessCondition">The access condition for this operation.</param>
        internal static void RenewLeaseValidation(AccessCondition accessCondition)
        {
            CommonUtils.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException("A lease ID must be specified when renewing a lease.", "accessCondition");
            }
        }

        /// <summary>
        /// Validates the parameters to a ChangeLease operation.
        /// </summary>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease.</param>
        /// <param name="accessCondition">The access condition for this operation.</param>
        internal static void ChangeLeaseValidation(string proposedLeaseId, AccessCondition accessCondition)
        {
            CommonUtils.AssertNotNull("accessCondition", accessCondition);
            CommonUtils.AssertNotNull("proposedLeaseId", proposedLeaseId);

            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException("A lease ID must be specified when changing a lease.", "accessCondition");
            }
        }

        /// <summary>
        /// Validates the parameters to a ReleaseLease operation.
        /// </summary>
        /// <param name="accessCondition">The access condition for this operation.</param>
        internal static void ReleaseLeaseValidation(AccessCondition accessCondition)
        {
            CommonUtils.AssertNotNull("accessCondition", accessCondition);
            if (accessCondition.LeaseId == null)
            {
                throw new ArgumentException("A lease ID must be specified when releasing a lease.", "accessCondition");
            }
        }

        /// <summary>
        /// Validates the parameters to a BreakLease operation.
        /// </summary>
        /// <param name="breakPeriod">The amount of time to allow the lease to remain, rounded down to seconds.
        /// If null, the break period is the remainder of the current lease, or zero for infinite leases.</param>
        internal static void BreakLeaseValidation(TimeSpan? breakPeriod)
        {
            if (breakPeriod.HasValue)
            {
                CommonUtils.AssertInBounds("breakPeriod", breakPeriod.Value, TimeSpan.FromSeconds(0), TimeSpan.MaxValue);
            }
        }

        /// <summary>
        /// Dispatches the stream upload to a specific implementation method.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the stream.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Stream provides no way to determine if Length is accessible so we must catch all exceptions.")]
        internal TaskSequence UploadFromStreamDispatch(Stream source, AccessCondition accessCondition, BlobRequestOptions options)
        {
            options = BlobRequestOptions.CreateFullModifier(this.ServiceClient, options);
            var blockSize = this.ServiceClient.WriteBlockSizeInBytes;
            long streamLength = -1;

            // If the stream is unseekable, buffer it for retries
            if (!source.CanSeek)
            {
                if (this.ServiceClient.ParallelOperationThreadCount == 1)
                {
                    return this.UploadBlobWithBuffering(source, accessCondition, options, blockSize);
                }
                else
                {
                    return this.ParallelUploadBlobWithBlocks(source, blockSize, accessCondition, options);
                }
            }

            // Check if the source stream has length. If length is unavailable, buffer it up for sending.
            // Otherwise set streamLength as delta between lenght and position
            try
            {
                streamLength = source.Length - source.Position;
            }
            catch (System.Exception)
            {
                if (this.ServiceClient.ParallelOperationThreadCount == 1)
                {
                    return this.UploadUnknownSizeStream(source, accessCondition, options, blockSize);
                }
                else
                {
                    return this.ParallelUploadBlobWithBlocks(source, blockSize, accessCondition, options);
                }
            }

            // If the blob is below the upload threshold, upload it as single version
            if (streamLength < this.ServiceClient.SingleBlobUploadThresholdInBytes)
            {
                return this.UploadFullBlobWithRetrySequenceImpl(source, accessCondition, options);
            }

            if (this.ServiceClient.ParallelOperationThreadCount == 1)
            {
                return this.UploadBlobWithBlocks(source, accessCondition, options, blockSize);
            }
            else
            {
                return this.ParallelUploadBlobWithBlocks(source, blockSize, accessCondition, options);
            }
        }

        /// <summary>
        /// Uploads the blob with buffering.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="blockSize">The size of the block.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the blob.</returns>
        internal TaskSequence UploadBlobWithBuffering(Stream source, AccessCondition accessCondition, BlobRequestOptions options, long blockSize)
        {
            CommonUtils.AssertNotNull("modifers", options);

            var target = this.OpenWrite(accessCondition, options);

            target.BlockSize = blockSize;
            return source.WriteToAndCloseOutput(target);
        }

        /// <summary>
        /// Uploads the full blob with retry.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the blob.</returns>
        internal Task<NullTaskReturn> UploadFullBlobWithRetryImpl(Stream source, AccessCondition accessCondition, BlobRequestOptions options)
        {
            var position = source.Position;

            // The stream should be always seekable, since they are under our control
            var retryPolicy = source.CanSeek ? options.RetryPolicy : RetryPolicies.NoRetry();

            return TaskImplHelper.GetRetryableAsyncTask(
                () =>
                {
                    // This shouldn't ever be false happen, since source streams are under our control
                    if (source.CanSeek)
                    {
                        source.Position = position;
                    }

                    return UploadFullBlobImpl(source, accessCondition, options);
                },
                retryPolicy);
        }

        /// <summary>
        /// Uploads the full blob.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the blob.</returns>
        internal TaskSequence UploadFullBlobImpl(Stream source, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("modifers", options);

            this.Properties.BlobType = BlobType.BlockBlob;
            var request = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Put(this.TransformedAddress, timeout, this.Properties, this.Properties.BlobType, 0, accessCondition));
            BlobRequest.AddMetadata(request, this.Metadata);
            var length = source.Length - source.Position;
            CommonUtils.ApplyRequestOptimizations(request, length);
            this.ServiceClient.Credentials.SignRequest(request);

            var uploadTask = new InvokeTaskSequenceTask<WebResponse>((result) =>
            {
                return UploadData(request, source, result);
            });
            yield return uploadTask;

            using (var response = uploadTask.Result as HttpWebResponse)
            {
                // Retrieve the ETag/LastModified
                this.ParseSizeAndLastModified(response);

                this.Properties.Length = length;
            }
        }

        /// <summary>
        /// Uploads the blob in parallel with blocks.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="blockSize">The size of the block.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the blob.</returns>
        internal TaskSequence ParallelUploadBlobWithBlocks(Stream source, long blockSize, AccessCondition accessCondition, BlobRequestOptions options)
        {
            ParallelUpload uploader = new ParallelUpload(source, accessCondition, options, blockSize, this.ToBlockBlob);

            return uploader.ParallelExecute(this.UploadBlockWithRetry);
        }

        /// <summary>
        /// Uploads the block with retry.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="blockId">The block IS.</param>
        /// <param name="contentMD5">The content MD5.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="Task&lt;NullTaskReturn&gt;"/> that uploads the block.</returns>
        internal Task<NullTaskReturn> UploadBlockWithRetry(Stream source, string blockId, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options)
        {
            // Used by our internal code. We always try to set the blockId as MD5
            var position = source.Position;
            var retryPolicy = source.CanSeek ? options.RetryPolicy : RetryPolicies.NoRetry();

            return TaskImplHelper.GetRetryableAsyncTask(
                () =>
                {
                    if (source.CanSeek)
                    {
                        source.Position = position;
                    }

                    return UploadBlock(source, blockId, contentMD5, accessCondition, options);
                },
                retryPolicy);
        }

        /// <summary>
        /// Uploads the block.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="blockId">The block ID.</param>
        /// <param name="contentMD5">The content MD5.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the block.</returns>
        internal TaskSequence UploadBlock(Stream source, string blockId, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options)
        {
            int id = Environment.TickCount;
            TraceHelper.WriteLine("Starting upload for id {0}", id);
            CommonUtils.AssertNotNull("options", options);

            var request = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.PutBlock(
                    this.TransformedAddress,
                    timeout,
                    blockId,
                    accessCondition));

            var length = source.Length - source.Position;
            CommonUtils.ApplyRequestOptimizations(request, length);

            if (!string.IsNullOrEmpty(contentMD5))
            {
                request.Headers.Set(HttpRequestHeader.ContentMd5, contentMD5);
            }

            this.ServiceClient.Credentials.SignRequest(request);

            var uploadTask = new InvokeTaskSequenceTask<WebResponse>((result) =>
            {
                return UploadData(request, source, result);
            });

            yield return uploadTask;

            uploadTask.Result.Close();

            TraceHelper.WriteLine("Ending upload for id {0}", id);
        }

        /// <summary>
        /// Uploads the data into the web request.
        /// </summary>
        /// <param name="request">The request that is setup for a put.</param>
        /// <param name="source">The source of data.</param>
        /// <param name="result">The response from the server.</param>
        /// <returns>The sequence used for uploading data.</returns>
        internal TaskSequence UploadData(HttpWebRequest request, Stream source, Action<WebResponse> result)
        {
            // Retrieve the stream
            var requestStreamTask = request.GetRequestStreamAsync();
            yield return requestStreamTask;

            // Copy the data
            using (var outputStream = requestStreamTask.Result)
            {
                var copyTask = new InvokeTaskSequenceTask(() => { return source.WriteTo(outputStream); });
                yield return copyTask;

                // Materialize any exceptions
                var scratch = copyTask.Result;
            }

            // Get the response
            var responseTask = request.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return responseTask;

            // Return the response object
            var response = responseTask.Result;

            result(response);
        }

        /// <summary>
        /// Implements the FetchAttributes method. The attributes are updated immediately.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that fetches the attributes.</returns>
        internal TaskSequence FetchAttributesImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            return this.FetchAttributesImpl(accessCondition, options, this.UpdateAfterFetchAttributes);
        }

        /// <summary>
        /// Implements the FetchAttributes method. Result is a <see cref="BlobAttributes"/> object
        /// containing the information returned from the service.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">A delegate for setting the result, which is a <see cref="BlobAttributes"/> object.</param>
        /// <returns>A <see cref="TaskSequence"/> that fetches the attributes.</returns>
        internal TaskSequence FetchAttributesImpl(AccessCondition accessCondition, BlobRequestOptions options, Action<BlobAttributes> setResult)
        {
            return this.ServiceClient.GenerateWebTask(
                (timeout) => BlobRequest.GetProperties(this.TransformedAddress, timeout, this.SnapshotTime, accessCondition),
                null /* no request body */,
                (webResponse) =>
                {
                    BlobAttributes attributes = BlobResponse.GetAttributes(webResponse);

                    // If BlobType is specified and the value returned from cloud is different, 
                    // then it's a client error and we need to throw.
                    if (this.attributes.Properties.BlobType != BlobType.Unspecified && this.attributes.Properties.BlobType != attributes.Properties.BlobType)
                    {
                        throw new InvalidOperationException(SR.BlobTypeMismatchExceptionMessage);
                    }

                    setResult(attributes);
                },
                null /* no response body */,
                options);
        }

        /// <summary>
        /// Generates a task sequence for acquiring a lease.
        /// </summary>
        /// <param name="leaseTime">A <see cref="TimeSpan"/> representing the span of time for which to acquire the lease,
        /// which will be rounded down to seconds. If null, an infinite lease will be acquired. If not null, this must be
        /// greater than zero.</param>
        /// <param name="proposedLeaseId">A string representing the proposed lease ID for the new lease, or null if no lease ID is proposed.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
                (timeout) => BlobRequest.Lease(
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
                string leaseId = BlobResponse.GetLeaseId(webResponse);
                
                setResult(leaseId);
            }
        }

        /// <summary>
        /// Generates a task sequence for renewing a lease.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
                (timeout) => BlobRequest.Lease(
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
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">The options for this operation, including the current lease ID. This cannot be null.</param>
        /// <param name="setResult">A delegate for setting the result, which is the new lease ID.</param>
        /// <returns>A task sequence implementing the change lease ID operation.</returns>
        internal TaskSequence ChangeLeaseImpl(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, Action<string> setResult)
        {
            // The client library should always supply default options.
            CommonUtils.AssertNotNull("options", options);

            HttpWebRequest webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Lease(
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
                string leaseId = BlobResponse.GetLeaseId(webResponse);

                setResult(leaseId);
            }
        }

        /// <summary>
        /// Generates a task sequence for releasing a lease.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
                (timeout) => BlobRequest.Lease(
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
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
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
                (timeout) => BlobRequest.Lease(
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
                int? remainingLeaseTime = BlobResponse.GetRemainingLeaseTime(webResponse);

                if (!remainingLeaseTime.HasValue)
                {
                    // Unexpected result from service.
                    throw new StorageClientException(StorageErrorCode.ServiceBadResponse, "Valid lease time expected but not received from the service.", webResponse.StatusCode, null, null);
                }

                setResult(TimeSpan.FromSeconds(remainingLeaseTime.Value));
            }
        }

        /// <summary>
        /// Implements the DownloadToStream method.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that downloads the blob to the stream.</returns>
        internal TaskSequence DownloadToStreamImpl(Stream target, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webResponseTask = new InvokeTaskSequenceTask<Stream>((result) => { return GetStreamImpl(accessCondition, options, result); });
            yield return webResponseTask;

            using (var responseStream = webResponseTask.Result)
            {
                var copyTask = new InvokeTaskSequenceTask(() => { return responseStream.WriteTo(target); });
                yield return copyTask;

                // Materialize any exceptions
                var scratch = copyTask.Result;
            }
        }

        /// <summary>
        /// Implements the DownloadToStream method.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="SynchronousTask"/> that downloads the blob to the stream.</returns>
        internal SynchronousTask DownloadToStreamSyncImpl(Stream target, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            return new SynchronousTask(() =>
            {
                using (var responseStream = GetStreamSyncImpl(accessCondition, options))
                {
                    responseStream.WriteToSync(target);
                }
            });
        }

        /// <summary>
        /// Implements getting the stream.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the stream.</returns>
        internal TaskSequence GetStreamImpl(AccessCondition accessCondition, BlobRequestOptions options, long offset, long count, Action<Stream> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Get(this.TransformedAddress, timeout, this.SnapshotTime, offset, count, accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            // Retrieve the stream
            var responseTask = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return responseTask;

            // Retrieve the response
            var response = responseTask.Result as HttpWebResponse;

            BlobAttributes attributes = BlobResponse.GetAttributes(response);
            this.UpdateAfterFetchAttributes(attributes);

            setResult(response.GetResponseStream());
        }

        /// <summary>
        /// Implements getting the stream without specifying a range.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="SynchronousTask"/> that gets the stream.</returns>
        internal Stream GetStreamSyncImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Get(this.TransformedAddress, timeout, this.SnapshotTime, accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            // Retrieve the response
            webRequest.Timeout = (int)options.Timeout.Value.TotalMilliseconds;
            
            var response = this.ServiceClient.GetResponse(webRequest) as HttpWebResponse;
            
            BlobAttributes attributes = BlobResponse.GetAttributes(response);
            this.UpdateAfterFetchAttributes(attributes);

            return response.GetResponseStream();
        }

        /// <summary>
        /// Implements getting the stream without specifying a range.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the stream.</returns>
        internal TaskSequence GetStreamImpl(AccessCondition accessCondition, BlobRequestOptions options, Action<Stream> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Get(this.TransformedAddress, timeout, this.SnapshotTime, accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            // Retrieve the stream
            var responseTask = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);
            yield return responseTask;

            // Retrieve the response
            var response = responseTask.Result as HttpWebResponse;

            BlobAttributes attributes = BlobResponse.GetAttributes(response);
            this.UpdateAfterFetchAttributes(attributes);

            setResult(response.GetResponseStream());
        }

        /// <summary>
        /// Retreive ETag and LastModified date time from response.
        /// </summary>
        /// <param name="response">The response to parse.</param>
        protected void ParseSizeAndLastModified(HttpWebResponse response)
        {
            var newProperties = BlobResponse.GetAttributes(response);
            this.Properties.ETag = newProperties.Properties.ETag ?? this.Properties.ETag;
            this.Properties.LastModifiedUtc = newProperties.Properties.LastModifiedUtc;
            if (newProperties.Properties.Length != 0)
            {
                this.Properties.Length = newProperties.Properties.Length;
            }
        }

        /// <summary>
        /// Parses the blob address query and returns snapshot and SAS.
        /// </summary>
        /// <param name="query">The query to parse.</param>
        /// <param name="snapshot">The snapshot value, if any.</param>
        /// <param name="sasCreds">The SAS credentials.</param>
        private static void ParseBlobAddressQuery(string query, out string snapshot, out StorageCredentialsSharedAccessSignature sasCreds)
        {
            snapshot = null;
            sasCreds = null;

            var queryParameters = HttpUtility.ParseQueryString(query);

            if (queryParameters.AllKeys.Contains(Constants.QueryConstants.Snapshot))
            {
                snapshot = queryParameters[Constants.QueryConstants.Snapshot];
            }

            SharedAccessSignatureHelper.ParseQuery(queryParameters, out sasCreds);
        }

        /// <summary>
        /// Gets the default encoding for the blob, which is UTF-8.
        /// </summary>
        /// <returns>The default <see cref="Encoding"/> object.</returns>
        private static Encoding GetDefaultEncoding()
        {
            Encoding encoding = Encoding.UTF8;

            return encoding;
        }

        /// <summary>
        /// Converts the source blob of a copy operation to an appropriate access URI, taking Shared Access Signature credentials into account.
        /// </summary>
        /// <param name="source">The source blob.</param>
        /// <returns>A URI addressing the source blob, using SAS if appropriate.</returns>
        private static Uri SourceBlobToUri(CloudBlob source)
        {
            Uri sourceUri = source.TransformedAddress;

            if (source.SnapshotTime.HasValue)
            {
                UriQueryBuilder builder = new UriQueryBuilder();
                builder.Add("snapshot", Request.ConvertDateTimeToSnapshotString(source.SnapshotTime.Value.ToUniversalTime()));
                sourceUri = builder.AddToUri(sourceUri);
            }

            return sourceUri;
        }

        /// <summary>
        /// Throws an exception based on the contents of the given copy error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        private static void ProcessCopyFailedStatus(string errorMessage)
        {
            throw new StorageClientException(
                StorageErrorCode.CopyFailed,
                string.Format(SR.CopyFailed, errorMessage),
                HttpStatusCode.Unused,
                null /* extendedErrorInfo */,
                null /* innerException */);
        }

        /// <summary>
        /// Performs input validation on polling parameters.
        /// </summary>
        /// <param name="pollingInterval">The polling interval.</param>
        /// <param name="maxTimeToWait">The maximum time to wait.</param>
        private static void PollingValidation(TimeSpan? pollingInterval, TimeSpan? maxTimeToWait)
        {
            if (pollingInterval.HasValue && pollingInterval.Value <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(
                    "pollingInterval",
                    pollingInterval.Value,
                    "The polling interval parameter must be positive.");
            }

            if (maxTimeToWait.HasValue && maxTimeToWait.Value <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(
                    "maxTimeToWait",
                    maxTimeToWait.Value,
                    "The maximum time to wait parameter must be positive.");
            }
        }

        /// <summary>
        /// Gets the canonical name of the blob, formatted as /&lt;account-name&gt;/&lt;container-name&gt;/&lt;blob-name&gt;.
        /// If <c>ignoreSnapshotTime</c> is <c>false</c> and this blob is a snapshot, the canonical name is augmented with a
        /// query of the form ?snapshot=&lt;snapshot-time&gt;.
        /// <para>This is used by both Shared Access and Copy blob operations.</para>
        /// </summary>
        /// <param name="ignoreSnapshotTime">Indicates if the snapshot time is ignored.</param>
        /// <returns>The canonical name of the blob.</returns>
        private string GetCanonicalName(bool ignoreSnapshotTime)
        {
            string accountName = this.ServiceClient.Credentials.AccountName;
            string containerName = this.Container.Name;
            string blobName = this.Name;

            string canonicalName = string.Format("/{0}/{1}/{2}", accountName, containerName, blobName);

            if (!ignoreSnapshotTime && this.SnapshotTime != null)
            {
                canonicalName += "?snapshot=" + Request.ConvertDateTimeToSnapshotString(this.SnapshotTime.Value.ToUniversalTime());
            }

            return canonicalName;
        }

        /// <summary>
        /// Uploads a stream that doesn't have a known length. In this case we can't do any optimizations like creating a request before we read all of the data.
        /// </summary>
        /// <param name="source">The stream that is the source of data.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="blockSize">The block size to be used (null - no blocks).</param>
        /// <returns>A sequence that represents uploading the blob.</returns>
        /// <remarks>This is implemented by creating a BlobStream and using that to buffer data until we have sufficient amount to be sent.</remarks>
        private TaskSequence UploadUnknownSizeStream(Stream source, AccessCondition accessCondition, BlobRequestOptions options, long blockSize)
        {
            // Potential Improvement: is there a better uploading scheme in absense of a known length
            // This function is more a defensive measure; it should be rarely called, if ever. (Can seekable stream not have length?
            // Cannot close as this is deferred execution
            var target = this.OpenWrite(accessCondition, options);

            target.BlockSize = blockSize;
            return source.WriteToAndCloseOutput(target);
        }

        /// <summary>
        /// Uploads the blob with blocks.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="blockSize">The size of the block.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the blob.</returns>
        private TaskSequence UploadBlobWithBlocks(Stream source, AccessCondition accessCondition, BlobRequestOptions options, long blockSize)
        {
            CommonUtils.AssertNotNull("modifers", options);

            var target = this.OpenWrite(accessCondition, options);

            target.BlockSize = blockSize;
            return source.WriteToAndCloseOutput(target);
        }

        /// <summary>
        /// Uploads the full blob with a retry sequence. The stream must be seekable.
        /// </summary>
        /// <param name="source">The source stream, which must be seekable.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that uploads the blob.</returns>
        private TaskSequence UploadFullBlobWithRetrySequenceImpl(Stream source, AccessCondition accessCondition, BlobRequestOptions options)
        {
            // Save the stream position
            long streamPos = source.Position;

            // Compute the MD5
            Task<string> md5Task = new InvokeTaskSequenceTask<string>(source.ComputeMD5);
            yield return md5Task;

            // Store the MD5 and rewind the stream
            this.Properties.ContentMD5 = md5Task.Result;
            source.Seek(streamPos, SeekOrigin.Begin);

            // Upload the blob
            Task<NullTaskReturn> uploadTask = this.UploadFullBlobWithRetryImpl(source, accessCondition, options);
            yield return uploadTask;

            // Materialize any exceptions
            NullTaskReturn scratch = uploadTask.Result;
        }

        /// <summary>
        /// Implementation of the StartCopyFromBlob method. Result is a BlobAttributes object derived from the response headers.
        /// </summary>
        /// <param name="source">The URI of the source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">A delegate for setting the BlobAttributes result.</param>
        /// <returns>A <see cref="TaskSequence"/> that starts to copy the blob.</returns>
        private TaskSequence StartCopyFromBlobImpl(
            Uri source,
            AccessCondition sourceAccessCondition,
            AccessCondition destAccessCondition,
            BlobRequestOptions options,
            Action<BlobAttributes> setResult)
        {
            CommonUtils.AssertNotNull("options", options);
            if (sourceAccessCondition != null && !string.IsNullOrEmpty(sourceAccessCondition.LeaseId))
            {
                throw new ArgumentException("A lease condition cannot be specified on the source of a copy.", "sourceAccessCondition");
            }

            return this.ServiceClient.GenerateWebTask(
                (timeout) =>
                {
                    HttpWebRequest request = BlobRequest.CopyFrom(this.TransformedAddress, timeout, source, sourceAccessCondition, destAccessCondition);
                    BlobRequest.AddMetadata(request, this.Metadata);
                    return request;
                },
                null /* no request body */,
                (response) =>
                {
                    setResult(BlobResponse.GetAttributes(response));
                },
                null /* no response body */,
                options);
        }

        /// <summary>
        /// Implementation of the StartCopyFromBlob method. Result is a function that updates the blob's attributes and returns the copy ID.
        /// </summary>
        /// <param name="source">The URI of the source blob.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">A delegate for setting the resulting update function.</param>
        /// <returns>A <see cref="TaskSequence"/> that starts to copy the blob.</returns>
        private TaskSequence StartCopyFromBlobImpl(
            Uri source,
            AccessCondition sourceAccessCondition,
            AccessCondition destAccessCondition,
            BlobRequestOptions options,
            Action<Func<string>> setResult)
        {
            return this.StartCopyFromBlobImpl(
                source,
                sourceAccessCondition,
                destAccessCondition,
                options,
                (attributes) =>
                {
                    setResult(() =>
                        {
                            this.UpdateAfterCopy(attributes);
                            return attributes.CopyState.CopyId;
                        });
                });
        }

        /// <summary>
        /// Implementation of the AbortCopy method. No result is produced.
        /// </summary>
        /// <param name="copyId">The copy ID of the copy operation to abort.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the operation. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that copies the blob.</returns>
        private TaskSequence AbortCopyImpl(string copyId, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);
            CommonUtils.AssertNotNull("copyId", copyId);

            return this.ServiceClient.GenerateWebTask(
                (timeout) =>
                {
                    HttpWebRequest request = BlobRequest.AbortCopy(this.TransformedAddress, timeout, copyId, accessCondition);
                    return request;
                },
                null /* no request body */,
                null /* no response header processing */,
                null /* no response body */,
                options);
        }

        /// <summary>
        /// Implementation of the CopyFromBlob method. Result is an action that updates the blob's properties.
        /// Do not apply retries to the task sequence returned by this method.
        /// </summary>
        /// <param name="source">The URI of the source blob.</param>
        /// <param name="pollingInterval">The amount of time to wait between attempts to poll for completion, or null for default polling.</param>
        /// <param name="maxTimeToWait">The maximum time to allow for the copy to complete, or null for default max time.</param>
        /// <param name="sourceAccessCondition">An object that represents the access conditions for the source blob. If null, no condition is used.</param>
        /// <param name="destAccessCondition">An object that represents the access conditions for the destination blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">A delegate for setting the resulting update action.</param>
        /// <returns>A <see cref="TaskSequence"/> that copies the blob.</returns>
        private TaskSequence CopyFromBlobImpl(
            Uri source,
            TimeSpan? pollingInterval,
            TimeSpan? maxTimeToWait,
            AccessCondition sourceAccessCondition,
            AccessCondition destAccessCondition,
            BlobRequestOptions options,
            Action<Action> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            TimeSpan finalPollingInterval = pollingInterval ?? DefaultPollingInterval;
            TimeSpan finalMaxTimeToWait = maxTimeToWait ?? DefaultCopyTimeout;
            DateTime targetTime = DateTime.UtcNow.Add(finalMaxTimeToWait);

            // Start the copy (with retries).
            Task<BlobAttributes> startCopyTask = TaskImplHelper.GetRetryableAsyncTask<BlobAttributes>(
                (setStartCopyResult) => this.StartCopyFromBlobImpl(
                    source,
                    sourceAccessCondition,
                    destAccessCondition,
                    options,
                    setStartCopyResult),
                options.RetryPolicy);

            yield return startCopyTask;

            BlobAttributes blobState = startCopyTask.Result;

            if (blobState.CopyState.Status == CopyStatus.Pending)
            {
                // Wait for the asynchronous copy to complete.
                Task<BlobAttributes> waitForCopyTask = new InvokeTaskSequenceTask<BlobAttributes>(
                    (setWaitForCopyResult) => this.WaitForCopyImpl(
                        blobState.CopyState.CopyId,
                        finalPollingInterval,
                        finalMaxTimeToWait,
                        targetTime,
                        destAccessCondition,
                        options,
                        setWaitForCopyResult));

                yield return waitForCopyTask;

                blobState = waitForCopyTask.Result;
            }

            setResult(() => this.UpdateAfterCopy(blobState));
        }

        /// <summary>
        /// Implementation of the WaitForCopy method. Result is an action that updates the blob's properties.
        /// Do not apply retries to the task sequence returned by this method.
        /// </summary>
        /// <param name="copyId">The copy ID of the operation to wait for.</param>
        /// <param name="pollingInterval">The amount of time to wait between attempts to poll for completion, or null for default polling.</param>
        /// <param name="maxTimeToWait">The maximum time to allow for the copy to complete, or null for default max time.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the operation. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">A delegate for setting the resulting update action.</param>
        /// <returns>A <see cref="TaskSequence"/> that waits for a blob copy.</returns>
        private TaskSequence WaitForCopyImpl(
            string copyId,
            TimeSpan? pollingInterval,
            TimeSpan? maxTimeToWait,
            AccessCondition accessCondition,
            BlobRequestOptions options,
            Action<BlobAttributes> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            TimeSpan finalPollingInterval = pollingInterval ?? DefaultPollingInterval;
            TimeSpan finalMaxTimeToWait = maxTimeToWait ?? DefaultCopyTimeout;
            DateTime targetTime = DateTime.UtcNow.Add(finalMaxTimeToWait);
            
            return this.WaitForCopyImpl(
                copyId,
                finalPollingInterval,
                finalMaxTimeToWait,
                targetTime,
                accessCondition,
                options,
                setResult);
        }

        /// <summary>
        /// Implementation of the WaitForCopy method. Result is an action that updates the blob's properties.
        /// Do not apply retries to the task sequence returned by this method.
        /// </summary>
        /// <param name="copyId">The copy ID of the operation to wait for.</param>
        /// <param name="pollingInterval">The amount of time to wait between attempts to poll for completion.</param>
        /// <param name="maxTimeToWait">The original maximum time to allow for the copy to complete, for reporting.</param>
        /// <param name="targetTime">The copy operation client-side timeout upper limit.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the operation. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">A delegate for setting the resulting update action.</param>
        /// <returns>A <see cref="TaskSequence"/> that waits for a blob copy.</returns>
        private TaskSequence WaitForCopyImpl(
            string copyId,
            TimeSpan pollingInterval,
            TimeSpan maxTimeToWait,
            DateTime targetTime,
            AccessCondition accessCondition,
            BlobRequestOptions options,
            Action<BlobAttributes> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            if (accessCondition != null)
            {
                accessCondition = AccessCondition.GenerateLeaseCondition(accessCondition.LeaseId);
            }

            CopyState prevState = null;
            CopyState currentState = null;
            BlobAttributes currentAttributes = null;

            // Loop until polling is over
            do
            {
                if (currentState != null)
                {
                    if (DateTime.UtcNow >= targetTime)
                    {
                        // timeout has elapsed
                        throw TimeoutHelper.GenerateTimeoutError(maxTimeToWait);
                    }

                    // TODO: Reuse a single timer here.
                    using (DelayTask delayTask = new DelayTask(pollingInterval))
                    {
                        yield return delayTask;
                        NullTaskReturn scratch = delayTask.Result;
                    }

                    prevState = currentState;
                }

                // Refresh the current copy state
                Task<BlobAttributes> fetchAtrributesTask = TaskImplHelper.GetRetryableAsyncTask<BlobAttributes>(
                    (setFetchResult) => this.FetchAttributesImpl(
                        accessCondition,
                        options,
                        setFetchResult),
                    options.RetryPolicy);

                yield return fetchAtrributesTask;
                currentAttributes = fetchAtrributesTask.Result;
                currentState = currentAttributes.CopyState;
            }
            while (
                currentState != null
                && currentState.Status == CopyStatus.Pending
                && currentState.CopyId == copyId);

            // Check for error conditions
            if (currentState == null || currentState.CopyId != copyId)
            {
                throw new StorageClientException(StorageErrorCode.CopyIdLost, SR.CopyUnknownId, HttpStatusCode.Unused, null, null);
            }
            else
            {
                switch (currentState.Status)
                {
                    case CopyStatus.Aborted:
                        throw new StorageClientException(StorageErrorCode.CopyAborted, SR.CopyAborted, HttpStatusCode.Unused, null, null);
                    case CopyStatus.Failed:
                        ProcessCopyFailedStatus(currentState.StatusDescription);
                        break;
                    case CopyStatus.Success:
                        setResult(currentAttributes);
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected copy status found.");
                }
            }
        }

        /// <summary>
        /// Updates this blob with the given attributes a the end of a copy operation.
        /// </summary>
        /// <param name="attributes">The new attributes.</param>
        private void UpdateAfterCopy(BlobAttributes attributes)
        {
            this.Properties.ETag = attributes.Properties.ETag;
            this.Properties.LastModifiedUtc = attributes.Properties.LastModifiedUtc;
            this.Attributes.CopyState = new CopyState
            {
                CopyId = attributes.CopyState.CopyId,
                Status = attributes.CopyState.Status
            };
        }

        /// <summary>
        /// Updates this blob with the given attributes a the end of a fetch attributes operation.
        /// </summary>
        /// <param name="attributes">The new attributes.</param>
        private void UpdateAfterFetchAttributes(BlobAttributes attributes)
        {
            this.attributes.Properties = attributes.Properties;
            this.attributes.Metadata = attributes.Metadata;
            this.attributes.CopyState = attributes.CopyState;
        }

        /// <summary>
        /// Implements the DeleteBlob method.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that deletes the blob.</returns>
        private TaskSequence DeleteBlobImpl(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Delete(this.TransformedAddress, timeout, this.SnapshotTime, deleteSnapshotsOption, accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Implementation for the DeleteIfExists method.
        /// </summary>
        /// <param name="deleteSnapshotsOption">Whether to only delete the blob, to delete the blob and all snapshots, or to only delete the snapshots.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that deletes the blob if it exists.</returns>
        private TaskSequence DeleteBlobIfExistsImpl(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, Action<bool> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            var task = new InvokeTaskSequenceTask(() => this.DeleteBlobImpl(deleteSnapshotsOption, accessCondition, options));

            yield return task;

            try
            {
                // Materialize exceptions
                var scratch = task.Result;

                setResult(true);
            }
            catch (StorageClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
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
        /// Implementation for the CreateSnapshot method.
        /// </summary>
        /// <param name="metadata">A collection of name-value pairs defining the metadata of the snapshot, or null.</param>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that creates the snapshot.</returns>
        /// <remarks>If the <c>metadata</c> parameter is <c>null</c> then no metadata is associated with the request.</remarks>
        private TaskSequence CreateSnapshotImpl(NameValueCollection metadata, AccessCondition accessCondition, BlobRequestOptions options, Action<CloudBlob> setResult)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.Snapshot(this.TransformedAddress, timeout, accessCondition));

            BlobAttributes snapshotAttributes = new BlobAttributes(this.attributes);
            
            // If metadata was supplied it should be passed to the request.
            // Otherwise, no metadata should be sent.
            if (metadata != null)
            {
                BlobRequest.AddMetadata(webRequest, metadata);

                // Update the snapshot's attributes to reflect the new metadata.
                snapshotAttributes.Metadata.Clear();
                snapshotAttributes.Metadata.Add(metadata);
            }

            this.ServiceClient.Credentials.SignRequest(webRequest);

            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                string snapshotTime = BlobResponse.GetSnapshotTime(webResponse);

                CloudBlob snapshot = new CloudBlob(snapshotAttributes, this.ServiceClient, snapshotTime);

                snapshot.ParseSizeAndLastModified(webResponse);

                setResult(snapshot);
            }
        }

        /// <summary>
        /// Implementation for the SetMetadata method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the metadata.</returns>
        private TaskSequence SetMetadataImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.SetMetadata(this.TransformedAddress, timeout, accessCondition));

            BlobRequest.AddMetadata(webRequest, this.Metadata);

            this.ServiceClient.Credentials.SignRequest(webRequest);

            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            // Parse the response
            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
                this.ParseSizeAndLastModified(webResponse);
            }
        }

        /// <summary>
        /// Implementation for the SetProperties method.
        /// </summary>
        /// <param name="accessCondition">An object that represents the access conditions for the blob. If null, no condition is used.</param>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the properties.</returns>
        private TaskSequence SetPropertiesImpl(AccessCondition accessCondition, BlobRequestOptions options)
        {
            CommonUtils.AssertNotNull("options", options);

            if (this.Properties == null)
            {
                throw new InvalidOperationException("BlobProperties is null");
            }

            var webRequest = ProtocolHelper.GetWebRequest(
                this.ServiceClient,
                options,
                (timeout) => BlobRequest.SetProperties(this.TransformedAddress, timeout, this.Properties, null, accessCondition));

            this.ServiceClient.Credentials.SignRequest(webRequest);

            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, options.Timeout);

            yield return task;

            // Parse the response
            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
                this.ParseSizeAndLastModified(webResponse);
            }
        }

        /// <summary>
        /// Verifies that write operation is not done for snapshot.
        /// </summary>
        private void VerifyNoWriteOperationForSnapshot()
        {
            if (this.SnapshotTime != null)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotModifySnapshot);
                throw new ArgumentException(errorMessage);
            }
        }

        /// <summary>
        /// Parses the snapshot time.
        /// </summary>
        /// <param name="snapshotTime">The snapshot time.</param>
        /// <returns>The parsed snapshot time.</returns>
        private DateTime ParseSnapshotTime(string snapshotTime)
        {
            DateTime snapshotDateTime;

            if (!DateTime.TryParse(
                snapshotTime,
               CultureInfo.InvariantCulture,
               DateTimeStyles.AdjustToUniversal,
               out snapshotDateTime))
            {
                CommonUtils.ArgumentOutOfRange("snapshotTime", snapshotTime);
            }

            if (this.SnapshotTime != null && this.SnapshotTime != snapshotDateTime)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.MultipleSnapshotTimesProvided, snapshotDateTime, this.SnapshotTime);
                throw new ArgumentException(errorMessage);
            }

            return snapshotDateTime;
        }

        /// <summary>
        /// Parse Uri for any snapshot and SAS (Shared access signature) information. Validate that no other query parameters are passed in.
        /// </summary>
        /// <param name="completeUri">The complete Uri.</param>
        /// <param name="existingClient">The existing blob client.</param>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <remarks>
        /// Any snapshot information will be saved.
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
                throw new ArgumentException(errorMessage, "completeUri");
            }

            this.attributes.Uri = new Uri(completeUri.GetLeftPart(UriPartial.Path));

            string snapshot;
            StorageCredentialsSharedAccessSignature sasCreds;
            ParseBlobAddressQuery(completeUri.Query, out snapshot, out sasCreds);

            if (!string.IsNullOrEmpty(snapshot))
            {
                this.SnapshotTime = this.ParseSnapshotTime(snapshot);
            }

            if (existingClient != null)
            {
                if (sasCreds != null && existingClient.Credentials != null && !sasCreds.Equals(existingClient.Credentials))
                {
                    string error = string.Format(CultureInfo.CurrentCulture, SR.MultipleCredentialsProvided);
                    throw new ArgumentException(error);
                }
            }
            else
            {
                StorageCredentials credentials = (StorageCredentials)sasCreds ?? StorageCredentialsAnonymous.Anonymous;
                this.ServiceClient = new CloudBlobClient(usePathStyleUris, new Uri(NavigationHelper.GetServiceClientBaseAddress(this.Uri.AbsoluteUri, usePathStyleUris)), credentials);
            }
        }
    }
}


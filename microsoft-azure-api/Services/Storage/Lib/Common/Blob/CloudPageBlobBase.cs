//-----------------------------------------------------------------------
// <copyright file="CloudPageBlobBase.cs" company="Microsoft">
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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// Represents a Windows Azure page blob.
    /// </summary>
    public sealed partial class CloudPageBlob : ICloudBlob
    {
        /// <summary>
        /// Default is 4 MB.
        /// </summary>
        private int streamWriteSizeInBytes = Constants.DefaultWriteBlockSizeBytes;

        /// <summary>
        /// Default is 4 MB.
        /// </summary>
        private int streamMinimumReadSizeInBytes = Constants.DefaultWriteBlockSizeBytes;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        public CloudPageBlob(Uri blobAbsoluteUri)
            : this(blobAbsoluteUri, null /* credentials */)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudPageBlob(Uri blobAbsoluteUri, StorageCredentials credentials)
            : this(blobAbsoluteUri, null /* snapshotTime */, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using an absolute URI to the blob.
        /// </summary>
        /// <param name="blobAbsoluteUri">The absolute URI to the blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudPageBlob(Uri blobAbsoluteUri, DateTimeOffset? snapshotTime, StorageCredentials credentials)
        {
            this.attributes = new BlobAttributes();
            this.SnapshotTime = snapshotTime;
            this.ParseQueryAndVerify(blobAbsoluteUri, credentials);
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class using the specified blob name and
        /// the parent container reference.
        /// If snapshotTime is not null, the blob instance represents a Snapshot.
        /// </summary>
        /// <param name="blobName">Name of the blob.</param>
        /// <param name="snapshotTime">Snapshot time in case the blob is a snapshot.</param>
        /// <param name="container">The reference to the parent container.</param>
        internal CloudPageBlob(string blobName, DateTimeOffset? snapshotTime, CloudBlobContainer container)
        {
            CommonUtils.AssertNotNullOrEmpty("blobName", blobName);
            CommonUtils.AssertNotNull("container", container);

            this.attributes = new BlobAttributes();
            this.Uri = NavigationHelper.AppendPathToUri(container.Uri, blobName);
            this.ServiceClient = container.ServiceClient;
            this.container = container;
            this.SnapshotTime = snapshotTime;
            this.Properties.BlobType = BlobType.PageBlob;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudPageBlob"/> class.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="serviceClient">The service client.</param>
        internal CloudPageBlob(BlobAttributes attributes, CloudBlobClient serviceClient)
        {
            this.attributes = attributes;
            this.ServiceClient = serviceClient;

            this.ParseQueryAndVerify(this.Uri, this.ServiceClient.Credentials);
            this.Properties.BlobType = BlobType.PageBlob;
        }

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
        /// Stores the blob's attributes.
        /// </summary>
        private readonly BlobAttributes attributes;

        /// <summary>
        /// Gets the <see cref="CloudBlobClient"/> object that represents the Blob service.
        /// </summary>
        /// <value>A client object that specifies the Blob service endpoint.</value>
        public CloudBlobClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets or sets the number of bytes to buffer when writing to a page blob stream.
        /// </summary>
        /// <value>The number of bytes to buffer, ranging from between 512 bytes and 4 MB inclusive.</value>
        public int StreamWriteSizeInBytes
        {
            get
            {
                return this.streamWriteSizeInBytes;
            }

            set
            {
                CommonUtils.AssertInBounds("StreamWriteSizeInBytes", value, Constants.PageSize, Constants.MaxBlockSize);
                this.streamWriteSizeInBytes = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum number of bytes to buffer when reading from a blob stream.
        /// </summary>
        /// <value>The minimum number of bytes to buffer, ranging from between 1 and 4 MB inclusive.</value>
        public int StreamMinimumReadSizeInBytes
        {
            get
            {
                return this.streamMinimumReadSizeInBytes;
            }

            set
            {
                CommonUtils.AssertInBounds("StreamMinimumReadSizeInBytes", value, 1 * Constants.MB, Constants.MaxBlockSize);
                this.streamMinimumReadSizeInBytes = value;
            }
        }

        /// <summary>
        /// Gets the blob's system properties.
        /// </summary>
        /// <value>The blob's properties.</value>
        public BlobProperties Properties
        {
            get
            {
                return this.attributes.Properties;
            }
        }

        /// <summary>
        /// Gets the user-defined metadata for the blob.
        /// </summary>
        /// <value>The blob's metadata, as a collection of name-value pairs.</value>
        public IDictionary<string, string> Metadata
        {
            get
            {
                return this.attributes.Metadata;
            }
        }

        /// <summary>
        /// Gets the blob's URI.
        /// </summary>
        /// <value>The absolute URI to the blob.</value>
        public Uri Uri
        {
            get
            {
                return this.attributes.Uri;
            }

            private set
            {
                this.attributes.Uri = value;
            }
        }

        /// <summary>
        /// Gets the date and time that the blob snapshot was taken, if this blob is a snapshot.
        /// </summary>
        /// <value>The blob's snapshot time if the blob is a snapshot; otherwise, <c>null</c>.</value>
        /// <remarks>
        /// If the blob is not a snapshot, the value of this property is <c>null</c>.
        /// </remarks>
        public DateTimeOffset? SnapshotTime
        {
            get
            {
                return this.attributes.SnapshotTime;
            }

            private set
            {
                this.attributes.SnapshotTime = value;
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

            private set
            {
                this.attributes.CopyState = value;
            }
        }

        /// <summary>
        /// Gets the type of the blob.
        /// </summary>
        /// <value>The type of the blob.</value>
        public BlobType BlobType
        {
            get
            {
                return Blob.BlobType.PageBlob;
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
                    this.container = this.ServiceClient.GetContainerReference(
                        NavigationHelper.GetContainerName(this.Uri, this.ServiceClient.UsePathStyleUris));
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
                    Uri parentUri = NavigationHelper.GetParentAddress(
                            this.Uri,
                            this.ServiceClient.DefaultDelimiter,
                            this.ServiceClient.UsePathStyleUris);

                    if (parentUri != null)
                    {
                        this.parent = new CloudBlobDirectory(
                            parentUri.AbsoluteUri,
                            this.ServiceClient);
                    }
                }

                return this.parent;
            }
        }

#if !COMMON
        /// <summary>
        /// Returns a shared access signature for the blob.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <returns>A shared access signature.</returns>
        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.GetSharedAccessSignature(policy, null /* groupPolicyIdentifier */);
        }

        /// <summary>
        /// Returns a shared access signature for the blob.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="groupPolicyIdentifier">A container-level access policy.</param>
        /// <returns>A shared access signature.</returns>
        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        {
            if (!this.ServiceClient.Credentials.IsSharedKey)
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
            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(policy, groupPolicyIdentifier, resourceName, this.ServiceClient.Credentials);
            string accountKeyName = this.ServiceClient.Credentials.KeyName;

            // Future resource type changes from "c" => "container"
            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(policy, groupPolicyIdentifier, "b", signature, accountKeyName);

            return builder.ToString();
        }
#endif

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

            // Replace \ with / for uri compatibility when running under .net 4.5. 
            string blobName = this.Name.Replace('\\', '/');

            string canonicalName = string.Format("/{0}/{1}/{2}", accountName, containerName, blobName);

            if (!ignoreSnapshotTime && this.SnapshotTime != null)
            {
                canonicalName += "?snapshot=" + BlobRequest.ConvertDateTimeToSnapshotString(this.SnapshotTime.Value);
            }

            return canonicalName;
        }

        /// <summary>
        /// Parse URI for SAS (Shared Access Signature) and snapshot information.
        /// </summary>
        /// <param name="address">The complete Uri.</param>
        /// <param name="credentials">The credentials to use.</param>
        private void ParseQueryAndVerify(Uri address, StorageCredentials credentials)
        {
            StorageCredentials parsedCredentials;
            DateTimeOffset? parsedSnapshot;
            this.Uri = NavigationHelper.ParseBlobQueryAndVerify(address, out parsedCredentials, out parsedSnapshot);

            if ((parsedCredentials != null) && (credentials != null) && !parsedCredentials.Equals(credentials))
            {
                string error = string.Format(CultureInfo.CurrentCulture, SR.MultipleCredentialsProvided);
                throw new ArgumentException(error);
            }

            if (parsedSnapshot.HasValue && this.SnapshotTime.HasValue && !parsedSnapshot.Value.Equals(this.SnapshotTime.Value))
            {
                string error = string.Format(CultureInfo.CurrentCulture, SR.MultipleSnapshotTimesProvided, parsedSnapshot, this.SnapshotTime);
                throw new ArgumentException(error);
            }

            if (parsedSnapshot.HasValue)
            {
                this.SnapshotTime = parsedSnapshot;
            }

            this.ServiceClient = new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(this.Uri, null /* usePathStyleUris */), credentials ?? parsedCredentials);
        }
    }
}

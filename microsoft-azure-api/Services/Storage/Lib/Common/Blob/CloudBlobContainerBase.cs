//-----------------------------------------------------------------------
// <copyright file="CloudBlobContainerBase.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    /// <summary>
    /// Represents a container in the Windows Azure Blob service.
    /// </summary>
    /// <remarks>Containers hold directories, which are encapsulated as <see cref="CloudBlobDirectory"/> objects, and directories hold block blobs and page blobs. Directories can also contain sub-directories.</remarks>
    public sealed partial class CloudBlobContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerAddress">The absolute URI to the container.</param>
        public CloudBlobContainer(Uri containerAddress)
            : this(containerAddress, null /* credentials */)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerAddress">The absolute URI to the container.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudBlobContainer(Uri containerAddress, StorageCredentials credentials)
        {
            this.ParseQueryAndVerify(containerAddress, credentials);
            this.Metadata = new Dictionary<string, string>();
            this.Properties = new BlobContainerProperties();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerName">The container name.</param>
        /// <param name="serviceClient">A client object that specifies the endpoint for the Blob service.</param>
        internal CloudBlobContainer(string containerName, CloudBlobClient serviceClient)
            : this(new BlobContainerProperties(), new Dictionary<string, string>(), containerName, serviceClient)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobContainer"/> class.
        /// </summary>
        /// <param name="containerName">The container name.</param>
        /// <param name="serviceClient">The client to be used.</param>
        internal CloudBlobContainer(BlobContainerProperties properties, IDictionary<string, string> metadata, string containerName, CloudBlobClient serviceClient)
        {
            this.Uri = NavigationHelper.AppendPathToUri(serviceClient.BaseUri, containerName);
            this.ServiceClient = serviceClient;
            this.Name = containerName;
            this.Metadata = metadata;
            this.Properties = properties;
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
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the name of the container.
        /// </summary>
        /// <value>The container's name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the container's metadata.
        /// </summary>
        /// <value>The container's metadata.</value>
        public IDictionary<string, string> Metadata { get; private set; }

        /// <summary>
        /// Gets the container's system properties.
        /// </summary>
        /// <value>The container's properties.</value>
        public BlobContainerProperties Properties { get; private set; }

        /// <summary>
        /// Parse URI for SAS (Shared Access Signature) information.
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

            this.ServiceClient = new CloudBlobClient(NavigationHelper.GetServiceClientBaseAddress(this.Uri, null /* usePathStyleUris */), credentials ?? parsedCredentials);
            this.Name = NavigationHelper.GetContainerNameFromContainerAddress(this.Uri, this.ServiceClient.UsePathStyleUris);
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

#if !COMMON
        /// <summary>
        /// Returns a shared access signature for the container.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <returns>A shared access signature.</returns>
        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.GetSharedAccessSignature(policy, null /* groupPolicyIdentifier */);
        }

        /// <summary>
        /// Returns a shared access signature for the container.
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

            string resourceName = this.GetSharedAccessCanonicalName();
            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(policy, groupPolicyIdentifier, resourceName, this.ServiceClient.Credentials);
            string accountKeyName = this.ServiceClient.Credentials.KeyName;

            // Future resource type changes from "c" => "container"
            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(policy, groupPolicyIdentifier, "c", signature, accountKeyName);

            return builder.ToString();
        }
#endif

        /// <summary>
        /// Gets a reference to a page blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A reference to a page blob.</returns>
        public CloudPageBlob GetPageBlobReference(string blobName)
        {
            return this.GetPageBlobReference(blobName, null /* snapshotTime */);
        }

        /// <summary>
        /// Returns a reference to a page blob in this virtual directory.
        /// </summary>
        /// <param name="blobName">The name of the page blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a page blob.</returns>
        public CloudPageBlob GetPageBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            CommonUtils.AssertNotNullOrEmpty("blobName", blobName);

            return new CloudPageBlob(blobName, snapshotTime, this);
        }

        /// <summary>
        /// Gets a reference to a block blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string blobName)
        {
            return this.GetBlockBlobReference(blobName, null /* snapshotTime */);
        }

        /// <summary>
        /// Gets a reference to a block blob in this container.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            CommonUtils.AssertNotNullOrEmpty("blobName", blobName);

            return new CloudBlockBlob(blobName, snapshotTime, this);
        }

        /// <summary>
        /// Gets a reference to a virtual blob directory beneath this container.
        /// </summary>
        /// <param name="relativeAddress">The name of the virtual blob directory.</param>
        /// <returns>A reference to a virtual blob directory.</returns>
        public CloudBlobDirectory GetDirectoryReference(string relativeAddress)
        {
            CommonUtils.AssertNotNullOrEmpty("relativeAddress", relativeAddress);

            Uri blobDirectoryUri = NavigationHelper.AppendPathToUri(this.Uri, relativeAddress);
            return new CloudBlobDirectory(blobDirectoryUri.AbsoluteUri, this.ServiceClient);
        }
    }
}

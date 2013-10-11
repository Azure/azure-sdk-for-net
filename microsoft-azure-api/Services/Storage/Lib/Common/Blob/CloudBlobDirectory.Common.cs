//-----------------------------------------------------------------------
// <copyright file="CloudBlobDirectory.Common.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;

    /// <summary>
    /// Represents a virtual directory of blobs on the client which emulates a hierarchical data store by using delimiter characters.
    /// </summary>
    /// <remarks>Containers, which are encapsulated as <see cref="CloudBlobContainer"/> objects, hold directories, and directories hold block blobs and page blobs. Directories can also contain sub-directories.</remarks>
    public sealed partial class CloudBlobDirectory : IListBlobItem
    {
        /// <summary>
        /// Stores the parent directory.
        /// </summary>
        private CloudBlobDirectory parent;

        /// <summary>
        /// Stores the prefix this directory represents.
        /// </summary>
        private string prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudBlobDirectory"/> class given an address and a client.
        /// </summary>
        /// <param name="absolutePath">The blob directory's address.</param>
        /// <param name="container">The container for the virtual directory.</param>
        internal CloudBlobDirectory(string absolutePath, CloudBlobContainer container)
        {
            CommonUtility.AssertNotNullOrEmpty("absolutePath", absolutePath);
            CommonUtility.AssertNotNull("container", container);

            this.ServiceClient = container.ServiceClient;
            this.Container = container;

            string delimiter = Uri.EscapeUriString(this.ServiceClient.DefaultDelimiter);
            if (!absolutePath.EndsWith(delimiter, StringComparison.Ordinal))
            {
                absolutePath = absolutePath + delimiter;
            }

            this.Uri = NavigationHelper.AppendPathToUri(this.ServiceClient.BaseUri, absolutePath);
        }

        /// <summary>
        /// Gets the service client for the virtual directory.
        /// </summary>
        /// <value>A client object that specifies the endpoint for the Windows Azure Blob service.</value>
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
        public CloudBlobContainer Container { get; private set; }

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
                    Uri parentUri = NavigationHelper.GetParentAddress(
                            this.Uri,
                            this.ServiceClient.DefaultDelimiter,
                            this.ServiceClient.UsePathStyleUris);

                    if (parentUri != null)
                    {
                        this.parent = new CloudBlobDirectory(
                            parentUri.AbsoluteUri,
                            this.Container);
                    }
                }

                return this.parent;
            }
        }

        /// <summary>
        /// Gets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix
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
        /// Gets a reference to a page blob in this virtual directory.
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
            CommonUtility.AssertNotNullOrEmpty("blobName", blobName);

            Uri blobUri = NavigationHelper.AppendPathToUri(this.Uri, blobName, this.ServiceClient.DefaultDelimiter);
            return new CloudPageBlob(blobUri, snapshotTime, this.ServiceClient.Credentials);
        }

        /// <summary>
        /// Gets a reference to a block blob in this virtual directory.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string blobName)
        {
            return this.GetBlockBlobReference(blobName, null /* snapshotTime */);
        }

        /// <summary>
        /// Gets a reference to a block blob in this virtual directory.
        /// </summary>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="snapshotTime">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <returns>A reference to a block blob.</returns>
        public CloudBlockBlob GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            CommonUtility.AssertNotNullOrEmpty("blobName", blobName);

            Uri blobUri = NavigationHelper.AppendPathToUri(this.Uri, blobName, this.ServiceClient.DefaultDelimiter);
            return new CloudBlockBlob(blobUri, snapshotTime, this.ServiceClient.Credentials);
        }

        /// <summary>
        /// Returns a virtual subdirectory within this virtual directory.
        /// </summary>
        /// <param name="itemName">The name of the virtual subdirectory.</param>
        /// <returns>A <see cref="CloudBlobDirectory"/> object representing the virtual subdirectory.</returns>
        public CloudBlobDirectory GetSubdirectoryReference(string itemName)
        {
            CommonUtility.AssertNotNull("itemName", itemName);
            Uri subdirectoryUri = NavigationHelper.AppendPathToUri(this.Uri, itemName, this.ServiceClient.DefaultDelimiter);
            return new CloudBlobDirectory(subdirectoryUri.AbsoluteUri, this.Container);
        }
       
        /// <summary>
        /// Initializes the prefix.
        /// </summary>
        private void InitializePrefix()
        {
            // Need to add the trailing slash or MakeRelativeUri will return the containerName again
            Uri parentUri = new Uri(this.Container.Uri + NavigationHelper.Slash);

            this.prefix = Uri.UnescapeDataString(parentUri.MakeRelativeUri(this.Uri).OriginalString);
        }
    }
}
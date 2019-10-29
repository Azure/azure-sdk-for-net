// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job.Models
{
    using System;
    using System.IO;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// Manages storage access details for job operations against HDInsight clusters.
    /// </summary>
    public class AzureStorageAccess : IStorageAccess
    {
        private string StorageAccountName { get; set; }

        private string StorageAccountKey { get; set; }

        private string DefaultStorageContainer { get; set; }

        private string storageAccountSuffix { get; set; }
        /// <summary>
        /// Initializes a new instance of the AzureStorageAccess class.
        /// </summary>
        /// <param name='storageAccountName'>
        /// Required. The storage account name.
        /// </param>
        /// <param name='storageAccountKey'>
        /// Required. The storage account key.
        /// </param>
        /// <param name='defaultStorageContainer'>
        /// Required. The default storage container name.
        /// </param>
        /// <param name='storageAccountSuffix'>
        /// Optional. The storage account URI suffix. For example, "core.chinacloudapi.cn".
        /// </param>

        public AzureStorageAccess(string storageAccountName, string storageAccountKey, string defaultStorageContainer, string storageAccountSuffix = null)
        {
            this.StorageAccountName = storageAccountName;
            this.StorageAccountKey = storageAccountKey;
            this.DefaultStorageContainer = defaultStorageContainer;
            this.storageAccountSuffix = storageAccountSuffix;
        }

        private CloudBlobClient GetStorageClient()
        {
            var accountName = StorageAccountName.Contains(".") ? StorageAccountName.Substring(0, StorageAccountName.IndexOf('.')) : StorageAccountName;
            var storageCredentials = new StorageCredentials(accountName, StorageAccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, storageAccountSuffix, true);           
            return storageAccount.CreateCloudBlobClient();
        }

        private ICloudBlob GetBlobReference(string defaultContainer, string blobReferencePath)
        {
            ICloudBlob blobReference;
            try
            {
                var client = GetStorageClient();
                var container = client.GetContainerReference(defaultContainer);
                blobReference = container.GetBlobReferenceFromServerAsync(blobReferencePath).GetAwaiter().GetResult();
            }
            catch (Exception blobNotFoundException)
            {
                throw new CloudException(blobNotFoundException.Message);
            }

            return blobReference;
        }

        /// <summary>
        /// Gets the file content from blob reference path.
        /// </summary>
        /// <param name='blobReferencePath'>
        /// Required. Blob reference path for which url to be generated.
        /// </param>
        /// <returns>
        /// Content of the file for the input blob reference path.
        /// </returns>
        public Stream GetFileContent(string blobReferencePath)
        {
            if (string.IsNullOrEmpty(blobReferencePath))
            {
                return null;
            }

            var blobReference = GetBlobReference(DefaultStorageContainer, blobReferencePath);

            var blobStream = new MemoryStream();

            try
            {
                blobReference.DownloadToStreamAsync(blobStream).Wait();
            }
            catch (Exception blobWebException)
            {
                throw new CloudException(blobWebException.Message);
            }

            blobStream.Seek(0, SeekOrigin.Begin);

            return blobStream;
        }
    }
}

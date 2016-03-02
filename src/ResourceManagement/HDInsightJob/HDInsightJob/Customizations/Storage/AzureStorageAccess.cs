// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Management.HDInsight.Job
{
    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    public class AzureStorageAccess : IStorageAccess
    {
        private string StorageAccountName { get; set; }

        private string StorageAccountKey { get; set; }

        private string DefaultStorageContainer { get; set; }

        public AzureStorageAccess(string storageAccountName, string storageAccountKey, string defaultStorageContainer)
        {
            this.StorageAccountName = storageAccountName;
            this.StorageAccountKey = storageAccountKey;
            this.DefaultStorageContainer = defaultStorageContainer;
        }

        private CloudBlobClient GetStorageClient()
        {
            var accountName = StorageAccountName.Contains(".") ? StorageAccountName.Substring(0, StorageAccountName.IndexOf('.')) : StorageAccountName;
            var storageCredentials = new StorageCredentials(accountName, StorageAccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            return storageAccount.CreateCloudBlobClient();
        }

        private ICloudBlob GetBlobReference(string defaultContainer, string blobReferencePath)
        {
            ICloudBlob blobReference;
            try
            {
                var client = GetStorageClient();
                var container = client.GetContainerReference(defaultContainer);
                blobReference = container.GetBlobReferenceFromServer(blobReferencePath);
            }
            catch (WebException blobNotFoundException)
            {
                throw new CloudException(blobNotFoundException.Message);
            }

            return blobReference;
        }

        /// <summary>
        /// Gets the storage access url for a blob reference path.
        /// </summary>
        /// <param name='blobReferencePath'>
        /// Required. Blob reference path for which url to be generated.
        /// </param>
        /// <returns>
        /// Uri object for the input blob reference path.
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
                blobReference.DownloadToStream(blobStream);
            }
            catch (WebException blobWebException)
            {
                throw new CloudException(blobWebException.Message);
            }

            blobStream.Seek(0, SeekOrigin.Begin);

            return blobStream;
        }

        /// <summary>
        /// Gets the content of input file as memory stream.
        /// </summary>
        /// <param name='file'>
        /// Required. File path which needs to be downloaded.
        /// </param>
        /// <returns>
        /// Memory stream which contains file content.
        /// </returns>
        public Uri GetFileUrl(string file)
        {
            Uri filePath = null;

            try
            {
                if (file.StartsWith(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)
                    || file.StartsWith(Constants.WabsProtocol, StringComparison.OrdinalIgnoreCase))
                {
                    filePath = new Uri(file);
                }
                else
                {
                    filePath =
                     new Uri(
                         string.Format(
                             CultureInfo.InvariantCulture,
                             "{0}{1}@{2}/{3}",
                             Constants.WabsProtocolSchemeName,
                             DefaultStorageContainer,
                             StorageAccountName,
                             file.TrimStart('/')));
                }
            }
            catch (System.UriFormatException uriException)
            {
                throw new CloudException(uriException.Message);
            }

            return filePath;
        }
    }
}

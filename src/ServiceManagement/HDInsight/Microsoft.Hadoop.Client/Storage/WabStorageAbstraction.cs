// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;

    internal class WabStorageAbstraction : IStorageAbstraction
    {
        private const string RootDirectoryPath = "/";

        private const string ProductionStorageAccountEndpointUriTemplate = "http://{0}.blob.core.windows.net/";

        private readonly WindowsAzureStorageAccountCredentials credentials;

        internal Uri StorageAccountUri
        {
            get { return new Uri(this.StorageAccountRoot); }

        }

        internal string StorageAccountRoot
        {
            get
            {
                var storageRoot = this.credentials.Name.Replace(Constants.WabsProtocolSchemeName, string.Empty);
                if (storageRoot.Contains("."))
                {
                    storageRoot = string.Format(CultureInfo.InvariantCulture, "http://{0}", storageRoot);
                }
                else
                {
                    storageRoot = string.Format(CultureInfo.InvariantCulture, ProductionStorageAccountEndpointUriTemplate, storageRoot);
                }

                return storageRoot;
            }
        }

        internal string StorageAccountName
        {
            get
            {
                var storageAccountName = this.credentials.Name.Replace(Constants.WabsProtocolSchemeName, string.Empty);
                if (storageAccountName.Contains("."))
                {
                    var storageUri = new Uri(string.Format(CultureInfo.InvariantCulture, "http://{0}", storageAccountName));
                    storageAccountName = storageUri.Host.Split('.').First();
                }

                return storageAccountName;
            }
        }

        public WabStorageAbstraction(WindowsAzureStorageAccountCredentials credentials)
        {
            credentials.ArgumentNotNull("credentials");
            this.credentials = credentials;
        }

        public async Task<bool> Exists(Uri path)
        {
            path.ArgumentNotNull("path");
            var httpPath = ConvertToHttpPath(path);
            this.AssertPathRootedToThisAccount(httpPath);
            var blobReference = await this.GetBlobReference(httpPath, false);
            return blobReference != null;
        }

        public void Delete(Uri path)
        {
            path.ArgumentNotNull("path");
            string localPath = path.LocalPath;
            var client = this.GetStorageClient();
            var container = client.GetContainerReference(this.credentials.ContainerName);
            localPath = localPath.TrimStart('/');
            foreach (CloudBlockBlob blob in container.ListBlobs(localPath, true, BlobListingDetails.None, null, null))
            {
                blob.Delete();
            }
        }

        public Task CreateContainerIfNotExists(string containerName)
        {
            containerName.ArgumentNotNullOrEmpty("containerName");
            var blobClient = this.GetStorageClient();

            var container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();
            return Task.FromResult(true);
        }

        public Task Write(Uri path, Stream stream)
        {
            var httpPath = ConvertToHttpPath(path);
            this.AssertPathRootedToThisAccount(httpPath);
            var client = this.GetStorageClient();
            var container = client.GetContainerReference(this.credentials.ContainerName);
            var blobReference = container.GetBlockBlobReference(httpPath.OriginalString);
            blobReference.UploadFromStream(stream);
            return Task.FromResult(true);
        }

        public async Task<Stream> Read(Uri path)
        {
            path.ArgumentNotNull("path");
            var httpPath = ConvertToHttpPath(path);
            this.AssertPathRootedToThisAccount(httpPath);
            var blobReference = await this.GetBlobReference(httpPath, true);

            var blobStream = await blobReference.OpenReadAsync();
            
            return blobStream;
        }

        public async Task<IEnumerable<Uri>> List(Uri path, bool recursive)
        {
            path.ArgumentNotNull("path");
            var httpPath = ConvertToHttpPath(path);
            this.AssertPathRootedToThisAccount(httpPath);
            var client = this.GetStorageClient();
            var directoryPath = GetRelativeHttpPath(path);
            var directoryContents = new List<Uri>();
            if (directoryPath == RootDirectoryPath)
            {
                var containers = client.ListContainers().ToList();
                directoryContents.AddRange(containers.Select(item => ConvertToAsvPath(item.Uri)));
            }
            else
            {
                var asyncResult = client.BeginListBlobsSegmented(directoryPath, null, null, null);
                var blobs = await Task.Factory.FromAsync(asyncResult, (result) => client.EndListBlobsSegmented(result));
                var blobDirectory = blobs.Results.FirstOrDefault(blob => blob is CloudBlobDirectory) as CloudBlobDirectory;
                if (blobDirectory != null)
                {
                    var blobItems = blobDirectory.ListBlobs(true).ToList();
                    directoryContents.AddRange(blobItems.Select(item => ConvertToAsvPath(item.Uri)));
                }
            }

            return directoryContents;
        }

        public async Task DownloadToFile(Uri path, string localFileName)
        {
            path.ArgumentNotNull("path");
            localFileName.ArgumentNotNullOrEmpty("localFileName");

            var httpPath = ConvertToHttpPath(path);
            this.AssertPathRootedToThisAccount(httpPath);

            var blobReference = await this.GetBlobReference(httpPath, true);

            // Read blob in chunks of up to 4MB
            long chunkSize = 4 * 1024 * 1024;

            if (blobReference.Properties.Length < chunkSize)
            {
                blobReference.DownloadToFile(localFileName, FileMode.OpenOrCreate);
            }
            else
            {
                byte[] buffer = new byte[chunkSize];
                using (var blobStream = blobReference.OpenRead())
                {
                    using (var fileStream = File.Create(localFileName))
                    {
                        int bytesRead;
                        while ((bytesRead = blobStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }

        private CloudBlobClient GetStorageClient()
        {
            var storageCredentials = new StorageCredentials(this.StorageAccountName, this.credentials.Key);
            return new CloudBlobClient(this.StorageAccountUri, storageCredentials);
        }

        private void AssertPathRootedToThisAccount(Uri path)
        {
            path.ArgumentNotNull("path");
            if (!string.Equals(this.StorageAccountUri.DnsSafeHost, path.DnsSafeHost, StringComparison.Ordinal))
            {
                throw new ArgumentException("Path is not rooted in the storage account.", "path");
            }
        }

        private async Task<ICloudBlob> GetBlobReference(Uri path, bool throwIfNotFound)
        {
            ICloudBlob blobReference = null;
            try
            {
                var client = this.GetStorageClient();
                var asyncResult = client.BeginGetBlobReferenceFromServer(path, null, null);
                blobReference = await Task.Factory.FromAsync(asyncResult, (result) => client.EndGetBlobReferenceFromServer(result));
            }
            catch (WebException blobNotFoundException)
            {
                if (throwIfNotFound)
                {
                    throw;
                }

                if (404 != (int)blobNotFoundException.Status)
                {
                    throw;
                }
            }

            return blobReference;
        }

        internal static Uri ConvertToHttpPath(Uri asvPath)
        {
            asvPath.ArgumentNotNull("path");
            if (!string.Equals(asvPath.Scheme, Constants.WabsProtocol, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("asvPath should have a uri scheme of asv", "asvPath");
            }

            string httpPath = string.Format(
                CultureInfo.InvariantCulture, "http://{0}/{1}{2}", asvPath.Host, asvPath.UserInfo, string.Join(string.Empty, asvPath.Segments));
            return new Uri(httpPath);
        }

        internal static string GetRelativeHttpPath(Uri path)
        {
            path.ArgumentNotNull("path");
            return path.UserInfo + "/" + string.Join(string.Empty, path.Segments).TrimStart('/');
        }

        internal static Uri ConvertToAsvPath(Uri httpPath)
        {
            httpPath.ArgumentNotNull("httpPath");

            if (!(string.Equals(httpPath.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) || string.Equals(httpPath.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("httpPath should have a uri scheme of http", "httpPath");
            }

            int segmentTakeCount = 1;
            string containerName = httpPath.Segments.First();
            if (containerName == RootDirectoryPath && httpPath.Segments.Length > segmentTakeCount)
            {
                containerName = httpPath.Segments.Skip(segmentTakeCount).FirstOrDefault();
                containerName = containerName.TrimEnd('/');
                segmentTakeCount++;
            }

            string asvPath = string.Format(
                CultureInfo.InvariantCulture, "{0}://{1}@{2}/{3}", Constants.WabsProtocol, containerName, httpPath.Host, string.Join(string.Empty, httpPath.Segments.Skip(segmentTakeCount)));
            return new Uri(asvPath);
        }
    }
}

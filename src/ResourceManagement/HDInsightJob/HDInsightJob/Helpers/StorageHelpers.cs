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
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace Microsoft.Azure.Management.HDInsight.Job
{
    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    internal partial class JobOperations : IServiceOperations<HDInsightJobManagementClient>, IJobOperations
    {
        private async Task<IEnumerable<Uri>> List(Uri path, bool recursive)
        {
            if (path == null)
            {
                throw new CloudException("The path cannot be null.");
            }
            var directoryPath = GetRelativeHttpPath(path);
            var client = GetStorageClient();
            var directoryContents = new List<Uri>();
            if (directoryPath == Constants.RootDirectoryPath)
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

        private CloudBlobClient GetStorageClient()
        {
            var storageCredentials = new StorageCredentials(StorageAccountName, StorageAccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            return storageAccount.CreateCloudBlobClient();
            //return new CloudBlobClient(this.StorageAccountUri, storageCredentials);
        }

        private static Uri ConvertToAsvPath(Uri httpPath)
        {
            if (!(string.Equals(httpPath.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) || string.Equals(httpPath.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
            {
                throw new CloudException(string.Format("The httpPath should have a uri scheme of http. Path entered: {0}", httpPath));
            }
            var segmentTakeCount = 1;
            var containerName = httpPath.Segments.First();
            if (containerName == Constants.RootDirectoryPath && httpPath.Segments.Length > segmentTakeCount)
            {
                containerName = httpPath.Segments.Skip(segmentTakeCount).FirstOrDefault();
                containerName = containerName.TrimEnd('/');
                segmentTakeCount++;
            }

            var asvPath = string.Format(
                CultureInfo.InvariantCulture, "{0}://{1}@{2}/{3}", Constants.WabsProtocol, containerName, httpPath.Host,
                string.Join(string.Empty, httpPath.Segments.Skip(segmentTakeCount)));
            return new Uri(asvPath);
        }

        private static string GetRelativeHttpPath(Uri path)
        {
            return path.UserInfo + "/" + string.Join(string.Empty, path.Segments).TrimStart('/');
        }

        private static Uri GetStatusDirectoryPath(string statusDirectory, string storageAccountName, string defaultContainer, string userAccount, string fileName)
        {
            Uri statusDirectoryPath;
            if (statusDirectory.StartsWith(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) || statusDirectory.StartsWith(Constants.WabsProtocol, StringComparison.OrdinalIgnoreCase) ||
                statusDirectory.StartsWith(Constants.WabsProtocol, StringComparison.OrdinalIgnoreCase))
            {
                statusDirectoryPath = new Uri(statusDirectory);
            }
            else if (statusDirectory.StartsWith("/", StringComparison.Ordinal))
            {
                statusDirectoryPath =
                 new Uri(
                     string.Format(
                         CultureInfo.InvariantCulture,
                         "{0}{1}@{2}/{3}/{4}",
                         Constants.WabsProtocolSchemeName,
                         defaultContainer,
                         storageAccountName,
                         statusDirectory.TrimStart('/'),
                         fileName));
            }
            else
            {
                statusDirectoryPath =
                   new Uri(
                       string.Format(
                           CultureInfo.InvariantCulture,
                           "{0}{1}@{2}/user/{3}/{4}/{5}",
                           Constants.WabsProtocolSchemeName,
                           defaultContainer,
                           storageAccountName,
                           userAccount,
                           statusDirectory.TrimStart('/'),
                           fileName));
            }

            return statusDirectoryPath;
        }

        public async Task<Stream> Read(Uri path)
        {
            var httpPath = ConvertToHttpPath(path);
            var blobReference = await GetBlobReference(httpPath);

            var blobStream = new MemoryStream();
            blobReference.DownloadToStream(blobStream);
            blobStream.Seek(0, SeekOrigin.Begin);

            return blobStream;
        }

        public Stream Read(string defaultContainer, string fileName, string username, string statusFolder)
        {
            var blobReference = GetBlob(defaultContainer, fileName, username, statusFolder);

            var blobStream = new MemoryStream();
            blobReference.DownloadToStream(blobStream);
            blobStream.Seek(0, SeekOrigin.Begin);

            return blobStream;
        }

        private ICloudBlob GetBlob(string defaultContainer, string fileName, string username, string statusFolder)
        {
            ICloudBlob blobReference;
            try
            {
                var client = GetStorageClient();
                var container = client.GetContainerReference(defaultContainer);
                blobReference = container.GetBlobReferenceFromServer(
                    string.Format("user/{0}/{1}/{2}", username, statusFolder, fileName));
            }
            catch (WebException blobNotFoundException)
            {
                throw new CloudException(blobNotFoundException.Message);
            }

            return blobReference;
        }

        internal static Uri ConvertToHttpPath(Uri asvPath)
        {
            if (!string.Equals(asvPath.Scheme, Constants.WabsProtocol, StringComparison.OrdinalIgnoreCase))
            {
                throw new CloudException(string.Format("The asvPath should have a uri scheme of asv. Path entered: {0}", asvPath));
            }

            var httpPath = string.Format(
                CultureInfo.InvariantCulture, "https://{0}/{1}{2}", asvPath.Host, asvPath.UserInfo, string.Join(string.Empty, asvPath.Segments));
            return new Uri(httpPath);
        }

        private async Task<ICloudBlob> GetBlobReference(Uri path)
        {
            ICloudBlob blobReference;
            try
            {
                var client = GetStorageClient();
                var asyncResult = client.BeginGetBlobReferenceFromServer(path, null, null);
                blobReference = await Task.Factory.FromAsync(asyncResult, (result) => client.EndGetBlobReferenceFromServer(result));
            }
            catch (WebException blobNotFoundException)
            {
                throw new CloudException(blobNotFoundException.Message);
            }

            return blobReference;
        }

        public async Task<Stream> GetJobResultFile(string jobId, string storageAccountName, string defaultContainer, string fileName)
        {
            var job = await this.GetJobAsync(jobId);
            var statusdir = GetStatusFolder(job);
            if (job == null || string.IsNullOrEmpty(statusdir))
            {
                return new MemoryStream();
            }
           
            return Read(defaultContainer, fileName, job.JobDetail.User, statusdir);
        }

        private static string GetStatusFolder(JobGetResponse job)
        {
            return job.JobDetail.Userargs.Statusdir == null ? null : job.JobDetail.Userargs.Statusdir.ToString();
        }
    }
}

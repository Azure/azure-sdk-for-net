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
        private CloudBlobClient GetStorageClient()
        {
            var accountName = StorageAccountName.Contains(".") ? StorageAccountName.Substring(0, StorageAccountName.IndexOf('.')) : StorageAccountName;
            var storageCredentials = new StorageCredentials(accountName, StorageAccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            return storageAccount.CreateCloudBlobClient();
            //return new CloudBlobClient(this.StorageAccountUri, storageCredentials);
        }

        private Stream Read(string defaultContainer, string fileName, string username, string statusFolder)
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

        private static string GetStatusFolder(JobGetResponse job)
        {
            return job.JobDetail.Userargs.Statusdir == null ? null : job.JobDetail.Userargs.Statusdir.ToString();
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
    }
}

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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Management.HDInsight.Job
{
    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    internal partial class JobOperations : IServiceOperations<HDInsightJobManagementClient>, IJobOperations
    {
        private string StorageAccountName { get; set; }
        private string StorageAccountKey { get; set; }
        private string DefaultStorageContainer { get; set; }

        internal string StorageAccountRoot
        {
            get
            {
                var storageRoot = StorageAccountName.Replace(Constants.WabsProtocolSchemeName, string.Empty);
                storageRoot = string.Format(CultureInfo.InvariantCulture,
                    storageRoot.Contains(".") ? "https://{0}" : Constants.ProductionStorageAccountEndpointUriTemplate,
                    storageRoot);

                return storageRoot;
            }
        }

        internal Uri StorageAccountUri
        {
            get { return new Uri(this.StorageAccountRoot); }

        }

        internal string StorageAccountConnectionString
        {
            get
            {
                var storageRoot = StorageAccountName.Replace(Constants.WabsProtocolSchemeName, string.Empty);
                if (storageRoot.Contains("."))
                {
                    storageRoot = storageRoot.Substring(0, storageRoot.IndexOf('.') + 1);
                }
                return string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", storageRoot,
                    StorageAccountKey);
            }
        }

        public async Task<Stream> GetJobOutputAsync(string jobId, string storageAccountName, string storageAccountKey, string defaultContainer, CancellationToken cancellationToken)
        {
            StorageAccountName = storageAccountName;
            StorageAccountKey = storageAccountKey;
            return await GetJobResultFile(jobId, storageAccountName, defaultContainer, "stdout");
        }

        public async Task<Stream> GetJobErrorLogsAsync(string jobId, string storageAccountName, string storageAccountKey, string defaultContainer, CancellationToken cancellationToken)
        {
            StorageAccountName = storageAccountName;
            StorageAccountKey = storageAccountKey;
            return await GetJobResultFile(jobId, storageAccountName, defaultContainer, "stderr");
        }
    }
}

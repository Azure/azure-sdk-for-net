// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.Utilities
{
    internal static class CloudBlobContainerUtils
    {
        internal static CloudBlobContainer GetContainerReference(Uri jobOutputContainerUri)
        {
            if (jobOutputContainerUri == null)
            {
                throw new ArgumentNullException(nameof(jobOutputContainerUri));
            }

            return new CloudBlobContainer(jobOutputContainerUri);
        }

        internal static CloudBlobContainer GetContainerReference(CloudStorageAccount storageAccount, string jobId)
        {
            if (storageAccount == null)
            {
                throw new ArgumentNullException(nameof(storageAccount));
            }

            Validate.IsNotNullOrEmpty(jobId, nameof(jobId));

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(jobId);
            return storageAccount.CreateCloudBlobClient().GetContainerReference(jobOutputContainerName);
        }
    }
}

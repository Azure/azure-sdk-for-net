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

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Batch.Conventions.Files.Utilities
{
    internal static class CloudBlobContainerUtils
    {
        internal static BlobContainerClient GetContainerReference(Uri jobOutputContainerUri)
        {
            if (jobOutputContainerUri == null)
            {
                throw new ArgumentNullException(nameof(jobOutputContainerUri));
            }

            return new BlobContainerClient(jobOutputContainerUri);
        }

        internal static BlobContainerClient GetContainerReference(BlobServiceClient blobServiceClient, string jobId)
        {
            if (blobServiceClient == null)
            {
                throw new ArgumentNullException(nameof(blobServiceClient));
            }

            Validate.IsNotNullOrEmpty(jobId, nameof(jobId));

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(jobId);
            return blobServiceClient.GetBlobContainerClient(jobOutputContainerName);
        }

        /*
         * Lists blobs from the specified container through flat listing
         */
        internal static IEnumerable<BlobItem> ListBlobs(this BlobContainerClient container, string prefix = null)
        {
            IEnumerable<Page<BlobItem>> resultSegment = container.GetBlobs(prefix: prefix).AsPages();

            foreach (Page<BlobItem> page in resultSegment)
            {
                foreach (BlobItem blob in page.Values)
                {
                    yield return blob;
                }

            }
        }

        /*
         * List blobs from the specified container by Hierachy
         **/
        internal static IEnumerable<BlobHierarchyItem> ListBlobsByHierachy(this BlobContainerClient container, string prefix = null, string delimiter = null)
        {
            IEnumerable<Page<BlobHierarchyItem>> resultSegment = container.GetBlobsByHierarchy(delimiter: delimiter, prefix: prefix).AsPages();

            foreach (Page<BlobHierarchyItem> page in resultSegment)
            {
                foreach (BlobHierarchyItem blobHeiracyItem in page.Values)
                {
                    yield return blobHeiracyItem;
                }
            }
        }
    }
}

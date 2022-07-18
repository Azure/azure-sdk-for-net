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
﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
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
        /*
         * No corresponding class for CloudStorageAccount in Azure.Storage.Blob SDK, remove method?
         * Substitute StorageAccount for BlobServiceClient
         */
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
         * Need to invoke different methods for flat blob listing and hierachical listing
         */
        internal static IEnumerable<IListBlobItem> ListBlobs(this CloudBlobContainer container, string prefix, bool useFlatBlobListing)
        {
            BlobContinuationToken continuationToken = null;
            do
            {
                BlobResultSegment segment = container
                    .ListBlobsSegmentedAsync(prefix, useFlatBlobListing, BlobListingDetails.None, null, continuationToken, null, null)
                    .GetAwaiter()
                    .GetResult();
                foreach (var result in segment.Results)
                {
                    yield return result;
                }
                continuationToken = segment.ContinuationToken;
            } while (continuationToken != null);

        }

        internal static IEnumerable<BlobItem> BlobsFlatListing(BlobContainerClient container, string prefix = null)
        {
            //string initialContinuationToken = null;
            IEnumerable<Page<BlobItem>> resultSegment = container.GetBlobs(prefix: prefix).AsPages();

            foreach (Page<BlobItem> page in resultSegment)
            {
                foreach (BlobItem blob in page.Values)
                {
                    Console.WriteLine("Processing blob: {0}", blob.Name);
                    //Console.WriteLine("ContinuationToken equal to null or empty? {0}", String.IsNullOrEmpty(page.ContinuationToken));
                    yield return blob;
                }

                //initialContinuationToken = page.ContinuationToken;
                //Console.WriteLine("initialContinuationToken equal to null? {0}", String.IsNullOrEmpty(initialContinuationToken));

            }
        }

        internal static IEnumerable<BlobHierarchyItem> ListBlobsByHierachy(BlobContainerClient container, string prefix = null, string delimiter = null)
        {
            //string initialContinuationToken = null;
            IEnumerable<Page<BlobHierarchyItem>> resultSegment = container.GetBlobsByHierarchy(delimiter: delimiter, prefix: prefix).AsPages();

            foreach (Page<BlobHierarchyItem> page in resultSegment)
            {
                foreach (BlobHierarchyItem blobHeiracyItem in page.Values)
                {
                    yield return blobHeiracyItem;
                }
                //initialContinuationToken = page.ContinuationToken;
                //Console.WriteLine("initialContinuationToken equal to null? {0}", String.IsNullOrEmpty(initialContinuationToken));
            }
        }
    }
}

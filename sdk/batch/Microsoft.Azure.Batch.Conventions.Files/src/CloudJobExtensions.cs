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

﻿using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files
{
    /// <summary>
    /// Provides methods for working with the outputs of a <see cref="CloudJob"/>.
    /// </summary>
    public static class CloudJobExtensions
    {
        private static readonly TimeSpan DefaultSasExpiry = TimeSpan.FromDays(7);

        /// <summary>
        /// Gets the <see cref="JobOutputStorage"/> for a specified <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="job">The job for which to get output storage.</param>
        /// <param name="blobClient">The blob service client linked to the Azure Batch storage account.</param>
        /// <returns>A JobOutputStorage for the specified job.</returns>
        public static JobOutputStorage OutputStorage(this CloudJob job, BlobServiceClient blobClient)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            if (blobClient == null)
            {
                throw new ArgumentNullException(nameof(blobClient));
            }

            return new JobOutputStorage(blobClient, job.Id);
        }

        /// <summary>
        /// Creates an Azure blob storage container for the outputs of a <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="job">The job for which to create the container.</param>
        /// <param name="blobClient">The blob service client linked to the Azure Batch storage account.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public static async Task PrepareOutputStorageAsync(this CloudJob job, BlobServiceClient blobClient, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            if (blobClient == null)
            {
                throw new ArgumentNullException(nameof(blobClient));
            }

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(job.Id);
            var jobOutputContainer = blobClient.GetBlobContainerClient(jobOutputContainerName);

            await jobOutputContainer.CreateIfNotExistsAsync(PublicAccessType.None, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the URL, including a Shared Access Signature (SAS) that permits writing, for the job's
        /// output storage container in Azure blob storage. This URL is suitable for passing to tasks
        /// so they can use the <see cref="JobOutputStorage.JobOutputStorage(Uri)"/> or
        /// <see cref="TaskOutputStorage.TaskOutputStorage(Uri, string)"/> constructors that take a <see cref="Uri"/>.
        /// </summary>
        /// <param name="job">The job for which to create the container.</param>
        /// <param name="blobClient">The blob service client linked to the Azure Batch storage account.</param>
        /// <returns>The URL, including SAS, of the job output container.</returns>
        /// <remarks>The SAS expires after 7 days. This default is chosen to match the maximum time that
        /// tasks can remain active.</remarks>
        public static string GetOutputStorageContainerUrl(this CloudJob job, BlobServiceClient blobClient)
        {
            return GetOutputStorageContainerUrl(job, blobClient, DefaultSasExpiry);
        }

        /// <summary>
        /// Gets the URL, including a Shared Access Signature (SAS) that permits writing, for the job's
        /// output storage container in Azure blob storage. This URL is suitable for passing to tasks
        /// so they can use the <see cref="JobOutputStorage.JobOutputStorage(Uri)"/> or
        /// <see cref="TaskOutputStorage.TaskOutputStorage(Uri, string)"/> constructors that take a <see cref="Uri"/>.
        /// </summary>
        /// <param name="job">The job for which to create the container.</param>
        /// <param name="blobClient">The blob service client linked to the Azure Batch storage account.</param>
        /// <param name="expiryTime">The duration for which the SAS is valid.  This should be long enough
        /// to allow all tasks of the job to be created and run to completion, including leeway for errors
        /// and retries.</param>
        /// <returns>The URL, including SAS, of the job output container.</returns>
        public static string GetOutputStorageContainerUrl(this CloudJob job, BlobServiceClient blobClient, TimeSpan expiryTime)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }
            if (blobClient == null)
            {
                throw new ArgumentNullException(nameof(blobClient));
            }

            if (!blobClient.CanGenerateAccountSasUri)
            {
                throw new Exception("Blob service client must be authorized with shared key credentials to create a service SAS URL");
            }

            if (expiryTime <= TimeSpan.Zero)
            {
                throw new ArgumentException("Shared access signature expiry time must be greater than zero", nameof(expiryTime));
            }

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(job.Id);
            var container = blobClient.GetBlobContainerClient(jobOutputContainerName);
            var containerUrl = GetSharedAccessSignature(container, expiryTime);

            return containerUrl;
        }

        /// <summary>
        /// Gets the name of the Azure blob storage container for the outputs of a <see cref="CloudJob"/>.
        /// </summary>
        /// <param name="job">The job for which to get the container name.</param>
        /// <returns>The name of the container in which to save the outputs of this job.</returns>
        public static string OutputStorageContainerName(this CloudJob job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(job.Id);

            return jobOutputContainerName;
        }

        /// <summary>
        /// Gets the Blob name prefix/folder where files of the given kind are stored
        /// </summary>
        /// <param name="job">The job to calculate the output storage destination for.</param>
        /// <param name="kind">The output kind.</param>
        /// <returns>The Blob name prefix/folder where files of the given kind are stored.</returns>
        public static string GetOutputStoragePath(this CloudJob job, JobOutputKind kind)
            => StoragePath.JobStoragePath.BlobNamePrefixImpl(kind);

        private static string GetSharedAccessSignature(BlobContainerClient containerClient, TimeSpan expiryTime)
        {
            BlobSasBuilder sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = containerClient.Name,
                Resource = "c"
            };

            sasBuilder.SetPermissions(BlobSasPermissions.Add | BlobSasPermissions.Create | BlobSasPermissions.List | BlobSasPermissions.Read | BlobSasPermissions.Write);
            sasBuilder.ExpiresOn = DateTime.UtcNow.Add(expiryTime);

            Uri sasUri = containerClient.GenerateSasUri(sasBuilder);

            return sasUri.AbsoluteUri;
        }

    }
}

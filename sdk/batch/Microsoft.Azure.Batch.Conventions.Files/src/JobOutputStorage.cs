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
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files
{
    /// <summary>
    /// Represents persistent storage for the outputs of an Azure Batch job.
    /// </summary>
    /// <remarks>
    /// Job outputs refer to output data logically associated with the entire job, rather than
    /// a particular task. For example, in a movie rendering job, if a task combined all the frames
    /// into a movie, that would logically be a job output. The purpose of categorising an
    /// output as a 'job' output is to save the client from having to know which task produced it.
    /// </remarks>
    public class JobOutputStorage
    {
        private readonly StoragePath _storagePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobOutputStorage"/> class from a URL representing
        /// the job output container.
        /// </summary>
        /// <param name="jobOutputContainerUri">The URL in Azure storage of the blob container to
        /// use for job outputs. This URL must contain a SAS (Shared Access Signature) granting
        /// access to the container, or the container must be public.</param>
        /// <remarks>The container must already exist; the JobOutputStorage class does not create
        /// it for you.</remarks>
        public JobOutputStorage(Uri jobOutputContainerUri)
            : this(CloudBlobContainerUtils.GetContainerReference(jobOutputContainerUri))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobOutputStorage"/> class from a storage account
        /// and job id.
        /// </summary>
        /// <param name="blobClient">The blob service client linked to the Azure Batch Storage Account.</param>
        /// <param name="jobId">The id of the Azure Batch job.</param>
        /// <remarks>The job output container must already exist; the JobOutputStorage class does not create
        /// it for you.</remarks>
        public JobOutputStorage(BlobServiceClient blobClient, string jobId)
            : this(CloudBlobContainerUtils.GetContainerReference(blobClient, jobId))
        {
        }

        private JobOutputStorage(BlobContainerClient jobOutputContainer)
        {
            if (jobOutputContainer == null)
            {
                throw new ArgumentNullException(nameof(jobOutputContainer));
            }

            _storagePath = new StoragePath.JobStoragePath(jobOutputContainer);
        }

        /// <summary>
        /// Saves the specified file to persistent storage.
        /// </summary>
        /// <param name="kind">A <see cref="JobOutputKind"/> representing the category under which to
        /// store this file, for example <see cref="JobOutputKind.JobOutput"/> or <see cref="JobOutputKind.JobPreview"/>.</param>
        /// <param name="relativePath">The path of the file to save, relative to the current directory.
        /// If the file is in a subdirectory of the current directory, the relative path will be preserved
        /// in blob storage.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <remarks>If the file is outside the current directory, traversals up the directory tree are removed.
        /// For example, a <paramref name="relativePath"/> of "..\ProcessEnv.cmd" would be treated as "ProcessEnv.cmd"
        /// for the purposes of creating a blob name.</remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="kind"/> or <paramref name="relativePath"/> argument is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="relativePath"/> argument is an absolute path, or is empty.</exception>
        public async Task SaveAsync(
            JobOutputKind kind,
            string relativePath,
            CancellationToken cancellationToken = default(CancellationToken)
        )
            => await SaveAsyncImpl(kind, new DirectoryInfo(Directory.GetCurrentDirectory()), relativePath, cancellationToken).ConfigureAwait(false);

        internal async Task SaveAsyncImpl(
            JobOutputKind kind,
            DirectoryInfo baseFolder,
            string relativePath,
            CancellationToken cancellationToken = default(CancellationToken)
        )
            => await _storagePath.SaveAsync(kind, baseFolder, relativePath, cancellationToken);

        /// <summary>
        /// Saves the specified file to persistent storage.
        /// </summary>
        /// <param name="kind">A <see cref="JobOutputKind"/> representing the category under which to
        /// store this file, for example <see cref="JobOutputKind.JobOutput"/> or <see cref="JobOutputKind.JobPreview"/>.</param>
        /// <param name="sourcePath">The path of the file to save.</param>
        /// <param name="destinationRelativePath">The blob name under which to save the file. This may include a
        /// relative component, such as "pointclouds/pointcloud_0001.txt".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="kind"/>, <paramref name="sourcePath"/>, or <paramref name="destinationRelativePath"/> argument is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="sourcePath"/> or <paramref name="destinationRelativePath"/> argument is empty.</exception>
        public async Task SaveAsync(
            JobOutputKind kind,
            string sourcePath,
            string destinationRelativePath,
            CancellationToken cancellationToken = default(CancellationToken)
        )
            => await _storagePath.SaveAsync(kind, sourcePath, destinationRelativePath, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Lists the job outputs of the specified kind.
        /// </summary>
        /// <param name="kind">A <see cref="JobOutputKind"/> representing the category of outputs to
        /// list, for example <see cref="JobOutputKind.JobOutput"/> or <see cref="JobOutputKind.JobPreview"/>.</param>
        /// <returns>A list of persisted job outputs of the specified kind.</returns>
        /// <remarks>The list is retrieved lazily from Azure blob storage when it is enumerated.</remarks>
        public IEnumerable<OutputFileReference> ListOutputs(JobOutputKind kind)
            => _storagePath.List(kind);

        /// <summary>
        /// Retrieves a job output from Azure blob storage by kind and path.
        /// </summary>
        /// <param name="kind">A <see cref="JobOutputKind"/> representing the category of the output to
        /// retrieve, for example <see cref="JobOutputKind.JobOutput"/> or <see cref="JobOutputKind.JobPreview"/>.</param>
        /// <param name="filePath">The path under which the output was persisted in blob storage.</param>
        /// <returns>A reference to the requested file in Azure blob storage.</returns>
        public OutputFileReference GetOutput(
            JobOutputKind kind,
            string filePath
        )
            => _storagePath.GetOutput(kind, filePath);

        /// <summary>
        /// Gets the Blob name prefix/folder where files of the given kind are stored
        /// </summary>
        /// <param name="kind">The output kind.</param>
        /// <returns>The Blob name prefix/folder where files of the given kind are stored.</returns>
        public string GetOutputStoragePath(JobOutputKind kind) => _storagePath.BlobNamePrefix(kind);
    }
}

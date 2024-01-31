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

using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using Azure.Storage.Blobs;
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
    /// Represents persistent storage for the outputs of an Azure Batch task.
    /// </summary>
    /// <remarks>
    /// Task outputs refer to output data logically associated with a specific task, rather than
    /// the job as a whole. For example, in a movie rendering job, if a task rendered a single frame,
    /// that frame would be a task output.  Logs and other diagnostic information such as intermediate
    /// files may also be persisted as task outputs (see <see cref="TaskOutputKind"/> for a way to
    /// categorise these so that clients can distinguish between the main output and auxiliary data).
    /// </remarks>
    public class TaskOutputStorage
    {
        private readonly StoragePath _storagePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobOutputStorage"/> class from a task id and
        /// a URL representing the job output container.
        /// </summary>
        /// <param name="jobOutputContainerUri">The URL in Azure storage of the blob container to
        /// use for outputs associated with this job. This URL must contain a SAS (Shared Access
        /// Signature) granting access to the container, or the container must be public.</param>
        /// <param name="taskId">The id of the Azure Batch task.</param>
        /// <remarks>The container must already exist; the TaskOutputStorage class does not create
        /// it for you.</remarks>
        public TaskOutputStorage(Uri jobOutputContainerUri, string taskId)
            : this(CloudBlobContainerUtils.GetContainerReference(jobOutputContainerUri), taskId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobOutputStorage"/> class from a storage account,
        /// job id, and task id.
        /// </summary>
        /// <param name="blobClient">The blob client linked to the Azure Batch storage account.</param>
        /// <param name="jobId">The id of the Azure Batch job containing the task.</param>
        /// <param name="taskId">The id of the Azure Batch task.</param>
        /// <remarks>The job output container must already exist; the TaskOutputStorage class does not create
        /// it for you.</remarks>
        public TaskOutputStorage(BlobServiceClient blobClient, string jobId, string taskId)
            : this(CloudBlobContainerUtils.GetContainerReference(blobClient, jobId), taskId)
        {
        }

        /*
         * No retry policy interfaces exist in new SDK - Consider passing ClientOptions.RetryOptions? or ClientOptions.AddPolicy to add custom policy to act on request for retries?
         * Seems that once you instantiate BlobContainerClient, you cannot modify the client options..?
         */
        private TaskOutputStorage(BlobContainerClient jobOutputContainer, string taskId)
        {
            if (jobOutputContainer == null)
            {
                throw new ArgumentNullException(nameof(jobOutputContainer));
            }

            Validate.IsNotNullOrEmpty(taskId, nameof(taskId));

            _storagePath = new StoragePath.TaskStoragePath(jobOutputContainer, taskId);
        }

        /// <summary>
        /// Saves the specified file to persistent storage.
        /// </summary>
        /// <param name="kind">A <see cref="TaskOutputKind"/> representing the category under which to
        /// store this file, for example <see cref="TaskOutputKind.TaskOutput"/> or <see cref="TaskOutputKind.TaskLog"/>.</param>
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
            TaskOutputKind kind,
            string relativePath,
            CancellationToken cancellationToken = default(CancellationToken)
        )
            => await SaveAsyncImpl(kind, new DirectoryInfo(Directory.GetCurrentDirectory()), relativePath, cancellationToken).ConfigureAwait(false);

        internal async Task SaveAsyncImpl(
            TaskOutputKind kind,
            DirectoryInfo baseFolder,
            string relativePath,
            CancellationToken cancellationToken = default(CancellationToken)
        )
            => await _storagePath.SaveAsync(kind, baseFolder, relativePath, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Saves the specified file to persistent storage.
        /// </summary>
        /// <param name="kind">A <see cref="TaskOutputKind"/> representing the category under which to
        /// store this file, for example <see cref="TaskOutputKind.TaskOutput"/> or <see cref="TaskOutputKind.TaskLog"/>.</param>
        /// <param name="sourcePath">The path of the file to save.</param>
        /// <param name="destinationRelativePath">The blob name under which to save the file. This may include a
        /// relative component, such as "pointclouds/pointcloud_0001.txt".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="kind"/>, <paramref name="sourcePath"/>, or <paramref name="destinationRelativePath"/> argument is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="sourcePath"/> or <paramref name="destinationRelativePath"/> argument is empty.</exception>
        public async Task SaveAsync(
            TaskOutputKind kind,
            string sourcePath,
            string destinationRelativePath,
            CancellationToken cancellationToken = default(CancellationToken)
        )
            => await _storagePath.SaveAsync(kind, sourcePath, destinationRelativePath, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Saves the specified text to persistent storage, without requiring you to create a local file.
        /// </summary>
        /// <param name="kind">A <see cref="TaskOutputKind"/> representing the category under which to
        /// store this data, for example <see cref="TaskOutputKind.TaskOutput"/> or <see cref="TaskOutputKind.TaskLog"/>.</param>
        /// <param name="text">The text to save.</param>
        /// <param name="destinationRelativePath">The blob name under which to save the text. This may include a
        /// relative component, such as "records/widget42.json".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="kind"/>, <paramref name="text"/>, or <paramref name="destinationRelativePath"/> argument is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="destinationRelativePath"/> argument is empty.</exception>
        public async Task SaveTextAsync(
            TaskOutputKind kind,
            string text,
            string destinationRelativePath,
            CancellationToken cancellationToken = default(CancellationToken)
        )
            => await _storagePath.SaveTextAsync(kind, text, destinationRelativePath, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Lists the task outputs of the specified kind.
        /// </summary>
        /// <param name="kind">A <see cref="TaskOutputKind"/> representing the category of outputs to
        /// list, for example <see cref="TaskOutputKind.TaskOutput"/> or <see cref="TaskOutputKind.TaskLog"/>.</param>
        /// <returns>A list of persisted task outputs of the specified kind.</returns>
        /// <remarks>The list is retrieved lazily from Azure blob storage when it is enumerated.</remarks>
        public IEnumerable<OutputFileReference> ListOutputs(TaskOutputKind kind)
            => _storagePath.List(kind);

        /// <summary>
        /// Retrieves a task output from Azure blob storage by kind and path.
        /// </summary>
        /// <param name="kind">A <see cref="TaskOutputKind"/> representing the category of the output to
        /// retrieve, for example <see cref="TaskOutputKind.TaskOutput"/> or <see cref="TaskOutputKind.TaskLog"/>.</param>
        /// <param name="filePath">The path under which the output was persisted in blob storage.</param>
        /// <returns>A reference to the requested file in Azure blob storage.</returns>
        public OutputFileReference GetOutput(
            TaskOutputKind kind,
            string filePath
        )
            => _storagePath.GetOutput(kind, filePath);

        /// <summary>
        /// Saves the specified file to persistent storage as a <see cref="TaskOutputKind.TaskLog"/>,
        /// and tracks subsequent appends to the file and appends them to the persistent copy too.
        /// </summary>
        /// <param name="relativePath">The path of the file to save, relative to the current directory.
        /// If the file is in a subdirectory of the current directory, the relative path will be preserved
        /// in blob storage.</param>
        /// <returns>An <see cref="ITrackedSaveOperation"/> which will save a file to blob storage and will periodically flush file
        /// appends to the blob until disposed.  When disposed, all remaining appends are flushed to
        /// blob storage, and further tracking of file appends is stopped.</returns>
        /// <remarks>
        /// <para>Tracking supports only appends. That is, while a file is being tracked, any data added
        /// at the end is appended to the persistent storage. Changes to data that has already been uploaded
        /// will not be reflected to the persistent store. This method is therefore intended for use only
        /// with files such as (non-rotating) log files where data is only added at the end of the file.
        /// If the entire contents of a file can change, use <see cref="SaveAsync(TaskOutputKind, string, CancellationToken)"/>
        /// and call it periodically or after each change.</para>
        /// <para>If the file is outside the current directory, traversals up the directory tree are removed.
        /// For example, a <paramref name="relativePath"/> of "..\ProcessEnv.cmd" would be treated as "ProcessEnv.cmd"
        /// for the purposes of creating a blob name.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="relativePath"/> argument is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="relativePath"/> argument is an absolute path, or is empty.</exception>
        public async Task<ITrackedSaveOperation> SaveTrackedAsync(string relativePath)
            => await _storagePath.SaveTrackedAsync(TaskOutputKind.TaskLog, relativePath, TrackedFile.DefaultFlushInterval).ConfigureAwait(false);

        /// <summary>
        /// Saves the specified file to persistent storage, and tracks subsequent appends to the file
        /// and appends them to the persistent copy too.
        /// </summary>
        /// <param name="kind">A <see cref="TaskOutputKind"/> representing the category under which to
        /// store this file, for example <see cref="TaskOutputKind.TaskOutput"/> or <see cref="TaskOutputKind.TaskLog"/>.</param>
        /// <param name="sourcePath">The path of the file to save.</param>
        /// <param name="destinationRelativePath">The blob name under which to save the file. This may include a
        /// relative component, such as "pointclouds/pointcloud_0001.txt".</param>
        /// <param name="flushInterval">The interval at which to flush appends to persistent storage.</param>
        /// <returns>An <see cref="ITrackedSaveOperation"/> which will save a file to blob storage and will periodically flush file
        /// appends to the blob until disposed.  When disposed, all remaining appends are flushed to
        /// blob storage, and further tracking of file appends is stopped.</returns>
        /// <remarks>
        /// <para>Tracking supports only appends. That is, while a file is being tracked, any data added
        /// at the end is appended to the persistent storage. Changes to data that has already been uploaded
        /// will not be reflected to the persistent store. This method is therefore intended for use only
        /// with files such as (non-rotating) log files where data is only added at the end of the file.
        /// If the entire contents of a file can change, use <see cref="SaveAsync(TaskOutputKind, string, string, CancellationToken)"/>
        /// and call it periodically or after each change.</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">The <paramref name="kind"/>, <paramref name="sourcePath"/>, or <paramref name="destinationRelativePath"/> argument is null.</exception>
        /// <exception cref="ArgumentException">The <paramref name="sourcePath"/> or <paramref name="destinationRelativePath"/> argument is empty.</exception>
        public async Task<ITrackedSaveOperation> SaveTrackedAsync(
            TaskOutputKind kind,
            string sourcePath,
            string destinationRelativePath,
            TimeSpan flushInterval
        )
            => await _storagePath.SaveTrackedAsync(kind, sourcePath, destinationRelativePath, flushInterval).ConfigureAwait(false);

        /// <summary>
        /// Gets the Blob name prefix/folder where files of the given kind are stored
        /// </summary>
        /// <param name="kind">The output kind.</param>
        /// <returns>The Blob name prefix/folder where files of the given kind are stored.</returns>
        public string GetOutputStoragePath(TaskOutputKind kind) => _storagePath.BlobNamePrefix(kind);
    }
}

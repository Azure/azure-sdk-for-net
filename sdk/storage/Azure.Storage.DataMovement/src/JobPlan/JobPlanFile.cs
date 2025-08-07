// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.JobPlan
{
    internal class JobPlanFile : IDisposable
    {
        /// <summary>
        /// Transfer Id representing the respective transfer.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The associated file on disk. When the last process has finished working
        /// with the file, the data is saved to the file on the disk.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// List of Job Part Plan Files associated with this job.
        /// </summary>
        public ConcurrentDictionary<int, JobPartPlanFile> JobParts { get; private set; }

        /// <summary>
        /// Lock for the memory mapped file to allow only one writer.
        /// </summary>
        public readonly SemaphoreSlim WriteLock;

        private JobPlanFile(string id, string filePath)
        {
            Id = id;
            FilePath = filePath;
            JobParts = new();
            WriteLock = new SemaphoreSlim(1);
        }

        private static string ToFullPath(string checkpointerPath, string transferId)
        {
            string fileName = $"{transferId}{DataMovementConstants.JobPlanFile.FileExtension}";
            return Path.Combine(checkpointerPath, fileName);
        }

        public static async Task<JobPlanFile> CreateJobPlanFileAsync(
            string checkpointerPath,
            string id,
            Stream headerStream,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(checkpointerPath, nameof(checkpointerPath));
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(headerStream, nameof(headerStream));

            string filePath = ToFullPath(checkpointerPath, id);

            JobPlanFile jobPlanFile = new(id, filePath);
            try
            {
                using (FileStream fileStream = File.Create(jobPlanFile.FilePath))
                {
                    await headerStream.CopyToAsync(
                        fileStream,
                        DataMovementConstants.DefaultStreamCopyBufferSize,
                        cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                // will handle if file has not been created yet
                File.Delete(jobPlanFile.FilePath);
                throw;
            }

            return jobPlanFile;
        }

        public static JobPlanFile LoadExistingJobPlanFile(string fullPath)
        {
            Argument.AssertNotNullOrEmpty(fullPath, nameof(fullPath));

            // File name is just the transfer id
            string transferId = Path.GetFileNameWithoutExtension(fullPath);
            // Validate transfer id by converting to Guid
            if (!Guid.TryParse(transferId, out _))
            {
                throw Errors.InvalidTransferIdFileName(fullPath);
            }

            return new JobPlanFile(transferId, fullPath);
        }

        public static JobPlanFile LoadExistingJobPlanFile(string checkpointerPath, string transferId)
        {
            return LoadExistingJobPlanFile(ToFullPath(checkpointerPath, transferId));
        }

        public void Dispose()
        {
            WriteLock.Dispose();
        }
    }
}

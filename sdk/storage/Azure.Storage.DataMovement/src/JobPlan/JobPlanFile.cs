// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

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
        public Dictionary<int, JobPartPlanFile> JobParts { get; private set; }

        /// <summary>
        /// Lock for the memory mapped file to allow only one writer.
        /// </summary>
        public readonly SemaphoreSlim WriteLock;

        private JobPlanFile(string id, string filePath)
        {
            Id = id;
            FilePath = filePath;
            JobParts = new Dictionary<int, JobPartPlanFile>();
            WriteLock = new SemaphoreSlim(1);
        }

        public static async Task<JobPlanFile> CreateJobPlanFileAsync(
            string checkpointerPath,
            string id,
            Stream headerStream)
        {
            Argument.AssertNotNullOrEmpty(checkpointerPath, nameof(checkpointerPath));
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(headerStream, nameof(headerStream));

            string fileName = $"{id}{DataMovementConstants.JobPlanFile.FileExtension}";
            string filePath = Path.Combine(checkpointerPath, fileName);

            JobPlanFile jobPlanFile = new(id, filePath);
            using (FileStream fileStream = File.Create(jobPlanFile.FilePath))
            {
                await headerStream.CopyToAsync(fileStream).ConfigureAwait(false);
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

        public void Dispose()
        {
            WriteLock.Dispose();
        }
    }
}

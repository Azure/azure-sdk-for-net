﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement.JobPlan
{
    internal class JobPartPlanFile : IDisposable
    {
        /// <summary>
        /// Save the associated file name within a struct. This will contain
        /// our transfer id, job part id, verison etc.
        /// </summary>
        public JobPartPlanFileName FileName { get; set; }

        /// <summary>
        /// The associated file on disk. When the last process has finished working
        /// with the file, the data is saved to the file on the disk.
        /// </summary>
        public string FilePath { get => FileName.ToString(); }

        /// <summary>
        /// Lock for the memory mapped file to allow only one writer.
        /// </summary>
        public readonly SemaphoreSlim WriteLock;

        private JobPartPlanFile()
        {
            WriteLock = new SemaphoreSlim(1);
        }

        public static async Task<JobPartPlanFile> CreateJobPartPlanFileAsync(
            string checkpointerPath,
            string id,
            int jobPart,
            Stream headerStream)
        {
            Argument.AssertNotNullOrEmpty(checkpointerPath, nameof(checkpointerPath));
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(jobPart, nameof(jobPart));
            Argument.AssertNotNull(headerStream, nameof(headerStream));

            JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath: checkpointerPath, id: id, jobPartNumber: jobPart);
            JobPartPlanFile result = new JobPartPlanFile()
            {
                FileName = fileName
            };
            using (FileStream fileStream = File.Create(result.FileName.ToString()))
            {
                await headerStream.CopyToAsync(fileStream).ConfigureAwait(false);
            }
            return result;
        }

        public static async Task<JobPartPlanFile> CreateJobPartPlanFileAsync(
            JobPartPlanFileName fileName,
            Stream headerStream)
        {
            JobPartPlanFile result = new JobPartPlanFile()
            {
                FileName = fileName
            };

            using (FileStream fileStream = File.Create(result.FileName.ToString()))
            {
                await headerStream.CopyToAsync(fileStream).ConfigureAwait(false);
            }
            return result;
        }

        public static JobPartPlanFile CreateExistingPartPlanFile(
            JobPartPlanFileName fileName)
        {
            return new JobPartPlanFile()
            {
                FileName = fileName
            };
        }

        public void Dispose()
        {
            WriteLock.Dispose();
        }
    }
}

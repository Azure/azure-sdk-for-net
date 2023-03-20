// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlanModels;

namespace Azure.Storage.DataMovement
{
    internal class JobPartPlanFile : IDisposable
    {
        /// <summary>
        /// Save the associated file name within a struct. This will contain
        /// our transfer id, job part id, verison etc.
        /// </summary>
        public JobPartPlanFileName FileName { get; set; }

        /// <summary>
        /// Used when opening the MemoryMappedFileReference
        /// </summary>
        public string MapName { get; internal set; }

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
            string mapName = string.Concat(id, jobPart);
            JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath: checkpointerPath, id: id, jobPartNumber: jobPart);
            JobPartPlanFile result = new JobPartPlanFile()
            {
                MapName = mapName,
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
            string mapName = string.Concat(fileName.Id, fileName.JobPartNumber);
            JobPartPlanFile result = new JobPartPlanFile()
            {
                MapName = mapName,
                FileName = fileName
            };

            using (FileStream fileStream = File.Create(result.FileName.ToString()))
            {
                await headerStream.CopyToAsync(fileStream).ConfigureAwait(false);
            }
            return result;
        }

        public void Dispose()
        {
            WriteLock.Dispose();
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlanModels;

namespace Azure.Storage.DataMovement
{
    internal class JobPartPlanFile
    {
        /// <summary>
        /// The actual reference to the memory mapped file.
        /// </summary>
        public MemoryMappedFile MemoryMappedFileReference { get; internal set; }

        /// <summary>
        /// Save the associated file name within a struct. This will contain
        /// our transfer id, job part id, verison etc.
        /// </summary>
        internal JobPartPlanFileName _jobPlanFileName { get; set; }

        /// <summary>
        /// The associated file on disk. When the last process has finished working
        /// with the file, the data is saved to the file on the disk.
        /// </summary>
        public string FilePath { get => _jobPlanFileName.ToString(); }

        /// <summary>
        /// Lock for the memory mapped file to allow only one writer.
        /// </summary>
        public readonly object writeLock = new object();

        private JobPartPlanFile()
        { }

        public static async Task<JobPartPlanFile> CreateJobPartPlanFileAsync(
            string checkpointerPath,
            string id,
            int jobPart,
            Stream headerStream)
        {
            long size = headerStream.Length;
            JobPartPlanFile result = new JobPartPlanFile();

            string mapName = string.Concat(id, jobPart);
            result._jobPlanFileName = new JobPartPlanFileName(checkpointerPath: checkpointerPath, id: id, jobPartNumber: jobPart);
            using (FileStream fileStream = File.Create(result._jobPlanFileName.ToString()))
            {
                await headerStream.CopyToAsync(fileStream).ConfigureAwait(false);
            }
            result.MemoryMappedFileReference = MemoryMappedFile.CreateFromFile(result._jobPlanFileName.ToString(), FileMode.Open, mapName, size);
            return result;
        }

        public static async Task<JobPartPlanFile> CreateJobPartPlanFileAsync(
            JobPartPlanFileName fileName,
            Stream headerStream)
        {
            long size = headerStream.Length;
            JobPartPlanFile result = new JobPartPlanFile();

            string mapName = string.Concat(fileName.Id, fileName.JobPartNumber);
            result._jobPlanFileName = fileName;
            using (FileStream fileStream = File.Create(result._jobPlanFileName.ToString()))
            {
                await headerStream.CopyToAsync(fileStream).ConfigureAwait(false);
            }
            result.MemoryMappedFileReference = MemoryMappedFile.CreateFromFile(result._jobPlanFileName.ToString(), FileMode.Open, mapName, size);
            return result;
        }
    }
}

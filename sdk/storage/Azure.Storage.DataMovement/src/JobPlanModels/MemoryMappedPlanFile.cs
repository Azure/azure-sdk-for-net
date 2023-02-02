// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    internal class MemoryMappedPlanFile
    {
        /// <summary>
        /// The actual reference to the memory mapped file
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
        /// Length of the file
        /// </summary>
        public int Length { get; internal set; }

        /// <summary>
        /// Lock for the memory mapped file to allow only one writer.
        /// </summary>
        public SemaphoreSlim Semaphore { get; internal set; }

        /// <summary>
        /// Constructor to create a new Memory Mapped file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobPart"></param>
        public MemoryMappedPlanFile(string id, int jobPart)
        {
            // Create new memory mapped job plan file
            // TODO: Change to the size of a job plan file.
            MemoryMappedFileReference = MemoryMappedFile.CreateNew(id, Constants.MB);
            Length = Constants.MB;
            Semaphore = new SemaphoreSlim(1);
            _jobPlanFileName = new JobPartPlanFileName(id: id, jobPartNumber: jobPart);
        }

        /// <summary>
        /// Constructor if the plan file already exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="existingFile"></param>
        public MemoryMappedPlanFile(string id, string existingFile)
        {
            existingFile.Contains(id);
            // TODO: verify job plan file
            _jobPlanFileName = new JobPartPlanFileName(existingFile);
            MemoryMappedFileReference = MemoryMappedFile.CreateFromFile(existingFile);
        }
    }
}

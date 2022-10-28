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
        public MemoryMappedPlanFile(string id)
        {
            // Create new memory mapped job plan file
            // TODO: Change to the size of a job plan file.
            MemoryMappedFile idMappedFile = MemoryMappedFile.CreateNew(id, Constants.MB);
            Length = Constants.MB;
            Semaphore = new SemaphoreSlim(1);
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
            MemoryMappedFile idMappedFile = MemoryMappedFile.CreateFromFile(existingFile);
        }
    }
}

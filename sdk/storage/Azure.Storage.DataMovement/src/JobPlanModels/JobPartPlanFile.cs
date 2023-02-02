// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        /// Length of the file.
        /// </summary>
        public int Length { get; internal set; }

        /// <summary>
        /// Lock for the memory mapped file to allow only one writer.
        /// </summary>
        public readonly object writeLock = new object();

        /// <summary>
        /// Constructor to create a new Memory Mapped file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobPart"></param>
        /// <param name="checkpointerPath">Path to where all checkpointer files are stored.</param>
        /// <param name="chunkCount"></param>
        public JobPartPlanFile(string checkpointerPath, string id, int jobPart, int chunkCount)
        {
            // To create pesistent memory mapped file, a file must be created first
            // to back the Memory Mapped File.
            JobPartPlanHeader structure = new JobPartPlanHeader();
            JobChunkPlanBody bodyStructure = new JobChunkPlanBody();

            // size of header + padding 8 bytes + size each chunk body * num of chunks
            int size = Marshal.SizeOf(structure) + DataMovementConstants.PlanFile.Padding + (Marshal.SizeOf(bodyStructure) * chunkCount);
            string mapName = String.Join(id, jobPart);
            _jobPlanFileName = new JobPartPlanFileName(checkpointerPath: checkpointerPath, id: id, jobPartNumber: jobPart);
            File.Create(_jobPlanFileName.ToString(), size);
            MemoryMappedFileReference = MemoryMappedFile.CreateFromFile(_jobPlanFileName.ToString(), FileMode.Open, mapName, size);
        }

        /// <summary>
        /// Constructor if the plan file already exists
        /// </summary>
        /// <param name="existingFile"></param>
        public JobPartPlanFile(JobPartPlanFileName existingFile)
        {
            string mapName = String.Join(existingFile.Id, existingFile.JobPartNumber);
            MemoryMappedFileReference = MemoryMappedFile.CreateFromFile(existingFile.ToString(), FileMode.Open, mapName);
            _jobPlanFileName = existingFile;
        }

        public async Task WriteHeaderAsync(Stream headerStream)
        {
            JobPartPlanHeader structure = new JobPartPlanHeader();
            using (MemoryMappedViewStream accessorStream =
                MemoryMappedFileReference.CreateViewStream(offset: 0, Marshal.SizeOf(structure)))
            {
                await headerStream.CopyToAsync(accessorStream).ConfigureAwait(false);
            }
        }

        public async Task WriteChunkBodyAsync(int chunkIndex, Stream headerStream)
        {
            JobChunkPlanBody structure = new JobChunkPlanBody();
            int offset = chunkIndex * Marshal.SizeOf(structure);
            using (MemoryMappedViewStream accessorStream =
                MemoryMappedFileReference.CreateViewStream(offset: offset, Marshal.SizeOf(structure)))
            {
                await headerStream.CopyToAsync(accessorStream).ConfigureAwait(false);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Storage.DataMovement.JobPlanModels;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal static partial class JobPlanExtensions
    {
        public static JobPartPlanHeader ToJobStruct(this Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            byte[] bytes = reader.ReadBytes(Unsafe.SizeOf<JobPartPlanHeader>());

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            JobPartPlanHeader header = (JobPartPlanHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(JobPartPlanHeader));
            handle.Free();

            return header;
        }

        public static StreamToUriJobPart ToJobPart(
            this StreamToUriTransferJob baseJob,
            Stream planFileStream,
            StorageResource sourceResource,
            StorageResource destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = planFileStream.ToJobStruct();

            // Apply credentials to the saved transfer job path
            StorageTransferStatus jobPartStatus = header.AtomicJobStatus;
            StreamToUriJobPart jobPart = new StreamToUriJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static ServiceToServiceJobPart ToJobPart(
            this ServiceToServiceTransferJob baseJob,
            Stream planFileStream,
            StorageResource sourceResource,
            StorageResource destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = planFileStream.ToJobStruct();

            // Apply credentials to the saved transfer job path
            StorageTransferStatus jobPartStatus = (StorageTransferStatus) header.AtomicJobStatus;
            ServiceToServiceJobPart jobPart = new ServiceToServiceJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static UriToStreamJobPart ToJobPart(
            this UriToStreamTransferJob baseJob,
            Stream planFileStream,
            StorageResource sourceResource,
            StorageResource destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = planFileStream.ToJobStruct();

            // Apply credentials to the saved transfer job path
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.AtomicJobStatus;
            UriToStreamJobPart jobPart = new UriToStreamJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static StreamToUriJobPart ToJobPart(
            this StreamToUriTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = planFileStream.ToJobStruct();

            // Apply credentials to the saved transfer job path
            string childSourcePath = header.SourcePath;
            string childDestinationPath = header.SourcePath;
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.AtomicJobStatus;
            StreamToUriJobPart jobPart = new StreamToUriJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource.GetChildStorageResource(childSourcePath.Substring(sourceResource.Path.Length)),
                destinationResource: destinationResource.GetChildStorageResource(childDestinationPath.Substring(destinationResource.Path.Length)));

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static ServiceToServiceJobPart ToJobPart(
            this ServiceToServiceTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = planFileStream.ToJobStruct();

            // Apply credentials to the saved transfer job path
            string childSourcePath = header.SourcePath;
            string childDestinationPath = header.SourcePath;
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.AtomicJobStatus;
            ServiceToServiceJobPart jobPart = new ServiceToServiceJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource.GetChildStorageResource(childSourcePath.Substring(sourceResource.Path.Length)),
                destinationResource: destinationResource.GetChildStorageResource(childDestinationPath.Substring(destinationResource.Path.Length)));

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static UriToStreamJobPart ToJobPart(
            this UriToStreamTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = planFileStream.ToJobStruct();

            // Apply credentials to the saved transfer job path
            string childSourcePath = header.SourcePath;
            string childDestinationPath = header.SourcePath;
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.AtomicJobStatus;
            UriToStreamJobPart jobPart = new UriToStreamJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource.GetChildStorageResource(childSourcePath.Substring(sourceResource.Path.Length)),
                destinationResource: destinationResource.GetChildStorageResource(childDestinationPath.Substring(destinationResource.Path.Length)));

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        /// <summary>
        /// Translate the initial job part header to a job plan format file
        /// </summary>
        internal static JobPartPlanHeader ToJobPartPlanHeader(this JobPartInternal jobPart, StorageTransferStatus jobStatus)
        {
            return new JobPartPlanHeader(
                version: DataMovementConstants.PlanFile.SchemaVersion,
                startTime: DateTimeOffset.UtcNow, // TODO: update to job start time
                transferId: jobPart._dataTransfer.Id,
                partNumber: (uint)jobPart.PartNumber,
                sourcePath: jobPart._sourceResource.Path,
                sourceExtraQuery: "", // TODO: convert options to string
                destinationPath: jobPart._destinationResource.Path,
                destinationExtraQuery: "", // TODO: convert options to string
                isFinalPart: false, // TODO: change but we might remove this param
                forceWrite: jobPart._createMode == StorageResourceCreateMode.Overwrite, // TODO: change to enum value
                forceIfReadOnly: false, // TODO: revisit for Azure Files
                autoDecompress: false, // TODO: revisit if we want to support this feature
                priority: 0, // TODO: add priority feature
                ttlAfterCompletion: DateTimeOffset.MinValue, // TODO: revisit for Azure Files
                fromTo: 0, // TODO: revisit when we add this feature
                folderPropertyOption: FolderPropertiesMode.None, // TODO: revisit for Azure Files
                numberChunks: 0, // TODO: revisit when added
                dstBlobData: default, // TODO: revisit when we add feature to cache this info
                dstLocalData: default, // TODO: revisit when we add feature to cache this info
                preserveSMBPermissions: false, // TODO: revisit for Azure Files
                preserveSMBInfo: false, // TODO: revisit for Azure Files
                s2sGetPropertiesInBackend: false, // TODO: revisit for Azure Files
                s2sSourceChangeValidation: false, // TODO: revisit for Azure Files
                destLengthValidation: false, // TODO: revisit when features is added
                s2sInvalidMetadataHandleOption: 0, // TODO: revisit when supported
                deleteSnapshotsOption: JobPartDeleteSnapshotsOption.None, // TODO: revisit when feature is added
                permanentDeleteOption: JobPartPermanentDeleteOption.None, // TODO: revisit when feature is added
                rehydratePriorityType: JobPartPlanRehydratePriorityType.None, // TODO: revisit when feature is added
                atomicJobStatus: jobStatus,
                atomicPartStatus: jobPart.JobPartStatus
            );
    }

        internal static JobPartPlanHeader GetJobPartPlanHeader(this JobPartPlanFileName fileName)
        {
            JobPartPlanHeader result;
            int bufferSize = Unsafe.SizeOf<JobPartPlanHeader>();
            byte[] buffer = new byte[bufferSize];

            using MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateFromFile(fileName.ToString());
            using (MemoryMappedViewStream stream = memoryMappedFile.CreateViewStream(0, bufferSize, MemoryMappedFileAccess.Read))
            {
                if (!stream.CanRead)
                {
                    throw Errors.CannotReadMmfStream(fileName.ToString());
                }
                stream.Read(buffer, 0, bufferSize);
                result = stream.ToJobStruct();
            }
            return result;
        }
    }
}

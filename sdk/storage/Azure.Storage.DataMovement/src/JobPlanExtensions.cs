// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.MemoryMappedFiles;
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
        public static Stream ToStream(this JobPartPlanHeader header)
        {
            // Convert the header to a struct
            int structSize = Marshal.SizeOf(typeof(JobPartPlanHeader));
            byte[] buffer = new byte[structSize];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(header, handle.AddrOfPinnedObject(), false);
            handle.Free();

            // Convert byte array to stream
            Stream result = new MemoryStream(buffer, 0, structSize);
            return result;
        }

        public static JobPartPlanHeader ToJobStruct(this Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(JobPartPlanHeader)));

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
            StorageTransferStatus jobPartStatus = (StorageTransferStatus) header.atomicJobStatus;
            StreamToUriJobPart jobPart = new StreamToUriJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNum),
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
            StorageTransferStatus jobPartStatus = (StorageTransferStatus) header.atomicJobStatus;
            ServiceToServiceJobPart jobPart = new ServiceToServiceJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNum),
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
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.atomicJobStatus;
            UriToStreamJobPart jobPart = new UriToStreamJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNum),
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
            string childSourcePath = Encoding.UTF8.GetString(header.SourceRoot);
            string childDestinationPath = Encoding.UTF8.GetString(header.SourceRoot);
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.atomicJobStatus;
            StreamToUriJobPart jobPart = new StreamToUriJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNum),
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
            string childSourcePath = Encoding.UTF8.GetString(header.SourceRoot);
            string childDestinationPath = Encoding.UTF8.GetString(header.SourceRoot);
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.atomicJobStatus;
            ServiceToServiceJobPart jobPart = new ServiceToServiceJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNum),
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
            string childSourcePath = Encoding.UTF8.GetString(header.SourceRoot);
            string childDestinationPath = Encoding.UTF8.GetString(header.SourceRoot);
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.atomicJobStatus;
            UriToStreamJobPart jobPart = new UriToStreamJobPart(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNum),
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
            byte[] sourceRoot = jobPart._sourceResource.UriToByteArray();
            byte[] sourceQueryParams = jobPart._sourceResource.UriQueryToByteArray();
            byte[] destinationRoot = jobPart._destinationResource.UriToByteArray();
            byte[] destinationQueryParams = jobPart._destinationResource.UriQueryToByteArray();
            return new JobPartPlanHeader()
            {
                Version = Encoding.Unicode.GetBytes(DataMovementConstants.PlanFile.SchemaVersion),
                StartTime = 0, // TODO: update to job start time
                TransferId = jobPart._dataTransfer.Id,
                PartNum = (uint)jobPart.PartNumber,
                SourceRootLength = (ushort)sourceRoot.Length,
                SourceRoot = sourceRoot,
                SourceExtraQueryLength = (ushort)sourceQueryParams.Length,
                SourceExtraQuery = sourceQueryParams,
                DestinationRootLength = (ushort)destinationRoot.Length,
                DestinationRoot = destinationRoot,
                DestExtraQueryLength = (ushort)destinationQueryParams.Length,
                DestExtraQuery = destinationQueryParams,
                IsFinalPart = false, // TODO: change but we might remove this param
                ForceWrite = jobPart._createMode == StorageResourceCreateMode.Overwrite, // TODO: change to enum value
                ForceIfReadOnly = false, // TODO: revisit for Azure Files
                AutoDecompress = false, // TODO: revisit if we want to support this feature
                Priority = 0, // TODO: add priority feature
                TTLAfterCompletion = 0, // TODO: revisit for Azure Files
                FromTo = 0, // TODO: revisit when we add this feature
                FolderPropertyOption = FolderPropertiesMode.None, // TODO: revisit for Azure Files
                NumTransfers = 0, // TODO: revisit when added
                DstBlobData = default, // TODO: revisit when we add feature to cache this info
                DstLocalData = default, // TODO: revisit when we add feature to cache this info
                PreserveSMBPermissions = 0, // TODO: revisit for Azure Files
                PreserveSMBInfo = false, // TODO: revisit for Azure Files
                S2SGetPropertiesInBackend = false, // TODO: revisit for Azure Files
                S2SSourceChangeValidation = false, // TODO: revisit for Azure Files
                DestLengthValidation = false, // TODO: revisit when features is added
                S2SInvalidMetadataHandleOption = 0, // TODO: revisit when supported
                atomicJobStatus = (uint)jobStatus,
                atomicPartStatus = (uint)jobPart.JobPartStatus,
                DeleteSnapshotsOption = JobPartDeleteSnapshotsOption.None, // TODO: revisit when feature is added
                PermanentDeleteOption = JobPartPermanentDeleteOption.None, // TODO: revisit when feature is added
                RehydratePriorityType = JobPartPlanRehydratePriorityType.None, // TODO: revisit when feature is added
            };
        }

        internal static JobPartPlanHeader GetJobPartPlanHeader(this JobPartPlanFileName fileName)
        {
            JobPartPlanHeader result = new JobPartPlanHeader();
            int bufferSize = Marshal.SizeOf(result);
            byte[] buffer = new byte[bufferSize];

            using MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateFromFile(fileName.ToString());
            using (MemoryMappedViewStream stream = memoryMappedFile.CreateViewStream(0, bufferSize, MemoryMappedFileAccess.Read))
            {
                if (stream.CanRead)
                {
                    stream.Read(buffer, 0, bufferSize);
                    result = stream.ToJobStruct();
                }
                else
                {
                    throw Errors.CannotReadMmfStream(fileName.ToString());
                }
            }
            return result;
        }
    }
}

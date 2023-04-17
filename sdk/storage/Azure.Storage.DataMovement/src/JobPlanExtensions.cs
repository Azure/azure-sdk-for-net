﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal static partial class JobPlanExtensions
    {
        public static async Task<StreamToUriJobPart> ToJobPartAsync(
            this StreamToUriTransferJob baseJob,
            Stream planFileStream,
            StorageResource sourceResource,
            StorageResource destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);

            // Apply credentials to the saved transfer job path
            StorageTransferStatus jobPartStatus = header.AtomicJobStatus;
            StreamToUriJobPart jobPart = await StreamToUriJobPart.CreateJobPartAsync(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                partPlanFileExists: true).ConfigureAwait(false);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static async Task<ServiceToServiceJobPart> ToJobPartAsync(
            this ServiceToServiceTransferJob baseJob,
            Stream planFileStream,
            StorageResource sourceResource,
            StorageResource destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);;

            // Apply credentials to the saved transfer job path
            StorageTransferStatus jobPartStatus = (StorageTransferStatus) header.AtomicJobStatus;
            ServiceToServiceJobPart jobPart = await ServiceToServiceJobPart.CreateJobPartAsync(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                partPlanFileExists: true).ConfigureAwait(false);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static async Task<UriToStreamJobPart> ToJobPartAsync(
            this UriToStreamTransferJob baseJob,
            Stream planFileStream,
            StorageResource sourceResource,
            StorageResource destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);;

            // Apply credentials to the saved transfer job path
            StorageTransferStatus jobPartStatus = (StorageTransferStatus)header.AtomicJobStatus;
            UriToStreamJobPart jobPart = await UriToStreamJobPart.CreateJobPartAsync(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                partPlanFileExists: true).ConfigureAwait(false);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static async Task<StreamToUriJobPart> ToJobPartAsync(
            this StreamToUriTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);;

            // Apply credentials to the saved transfer job path
            string childSourcePath = header.SourcePath;
            string childDestinationPath = header.SourcePath;
            StorageTransferStatus jobPartStatus = header.AtomicJobStatus;
            StreamToUriJobPart jobPart = await StreamToUriJobPart.CreateJobPartAsync(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource.GetChildStorageResource(childSourcePath.Substring(sourceResource.Path.Length)),
                destinationResource: destinationResource.GetChildStorageResource(childDestinationPath.Substring(destinationResource.Path.Length)),
                partPlanFileExists: true).ConfigureAwait(false);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static async Task<ServiceToServiceJobPart> ToJobPartAsync(
            this ServiceToServiceTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);;

            // Apply credentials to the saved transfer job path
            string childSourcePath = header.SourcePath;
            string childDestinationPath = header.SourcePath;
            StorageTransferStatus jobPartStatus = header.AtomicJobStatus;
            ServiceToServiceJobPart jobPart = await ServiceToServiceJobPart.CreateJobPartAsync(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource.GetChildStorageResource(childSourcePath.Substring(sourceResource.Path.Length)),
                destinationResource: destinationResource.GetChildStorageResource(childDestinationPath.Substring(destinationResource.Path.Length)),
                partPlanFileExists: true).ConfigureAwait(false);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static async Task<UriToStreamJobPart> ToJobPartAsync(
            this UriToStreamTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);;

            // Apply credentials to the saved transfer job path
            string childSourcePath = header.SourcePath;
            string childDestinationPath = header.SourcePath;
            StorageTransferStatus jobPartStatus = header.AtomicJobStatus;
            UriToStreamJobPart jobPart = await UriToStreamJobPart.CreateJobPartAsync(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                jobPartStatus: jobPartStatus,
                sourceResource: sourceResource.GetChildStorageResource(childSourcePath.Substring(sourceResource.Path.Length)),
                destinationResource: destinationResource.GetChildStorageResource(childDestinationPath.Substring(destinationResource.Path.Length)),
                partPlanFileExists: true).ConfigureAwait(false);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        /// <summary>
        /// Translate the initial job part header to a job plan format file
        /// </summary>
        internal static JobPartPlanHeader ToJobPartPlanHeader(this JobPartInternal jobPart, StorageTransferStatus jobStatus)
        {
            JobPartPlanDestinationBlob dstBlobData = new JobPartPlanDestinationBlob(
                blobType: JobPlanBlobType.Detect, // TODO: update when supported
                noGuessMimeType: false, // TODO: update when supported
                contentType: "", // TODO: update when supported
                contentEncoding: "", // TODO: update when supported
                contentLanguage: "", // TODO: update when supported
                contentDisposition: "", // TODO: update when supported
                cacheControl: "", // TODO: update when supported
                blockBlobTier: JobPartPlanBlockBlobTier.None,// TODO: update when supported
                pageBlobTier: JobPartPlanPageBlobTier.None,// TODO: update when supported
                putMd5: false,// TODO: update when supported
                metadata: "",// TODO: update when supported
                blobTags: "",// TODO: update when supported
                isSourceEncrypted: false,// TODO: update when supported
                cpkScopeInfo: "",// TODO: update when supported
                blockSize: jobPart._maximumTransferChunkSize);

            JobPartPlanDestinationLocal dstLocalData = new JobPartPlanDestinationLocal(
                preserveLastModifiedTime: false, // TODO: update when supported
                md5VerificationOption: 0); // TODO: update when supported

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
                jobPlanOperation: 0, // TODO: revisit when we add this feature
                folderPropertyMode: FolderPropertiesMode.None, // TODO: revisit for Azure Files
                numberChunks: 0, // TODO: revisit when added
                dstBlobData: dstBlobData, // TODO: revisit when we add feature to cache this info
                dstLocalData: dstLocalData, // TODO: revisit when we add feature to cache this info
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
                atomicPartStatus: jobPart.JobPartStatus);
        }

        internal static JobPartPlanHeader GetJobPartPlanHeader(this JobPartPlanFileName fileName)
        {
            JobPartPlanHeader result;
            int bufferSize = DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes;

            using MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateFromFile(fileName.ToString());
            using (MemoryMappedViewStream stream = memoryMappedFile.CreateViewStream(0, bufferSize, MemoryMappedFileAccess.Read))
            {
                if (!stream.CanRead)
                {
                    throw Errors.CannotReadMmfStream(fileName.ToString());
                }
                result = JobPartPlanHeader.Deserialize(stream);
            }
            return result;
        }
    }
}

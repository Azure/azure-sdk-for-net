// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal static class DataMovementExtensions
    {
        internal static StorageResourceItemProperties ToStorageResourceProperties(this FileInfo fileInfo)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            return new StorageResourceItemProperties(
                resourceLength: fileInfo.Length,
                eTag: default,
                lastModifiedTime: fileInfo.LastWriteTimeUtc,
                properties: properties);
        }

        public static StreamToUriJobPart ToJobPartAsync(
            this StreamToUriTransferJob baseJob,
            Stream planFileStream,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);

            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationPreference createPreference =
                baseJob._creationPreference != StorageResourceCreationPreference.Default ?
                baseJob._creationPreference : header.CreatePreference;

            StreamToUriJobPart jobPart = StreamToUriJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static ServiceToServiceJobPart ToJobPartAsync(
            this ServiceToServiceTransferJob baseJob,
            Stream planFileStream,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);

            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationPreference createPreference =
                baseJob._creationPreference != StorageResourceCreationPreference.Default ?
                baseJob._creationPreference : header.CreatePreference;

            ServiceToServiceJobPart jobPart = ServiceToServiceJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static UriToStreamJobPart ToJobPartAsync(
            this UriToStreamTransferJob baseJob,
            Stream planFileStream,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);

            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationPreference createPreference =
                baseJob._creationPreference != StorageResourceCreationPreference.Default ?
                baseJob._creationPreference : header.CreatePreference;

            UriToStreamJobPart jobPart = UriToStreamJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource,
                destinationResource: destinationResource,
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static StreamToUriJobPart ToJobPartAsync(
            this StreamToUriTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);

            string childSourcePath = header.SourcePath;
            string childSourceName = childSourcePath.Substring(sourceResource.Uri.AbsoluteUri.Length + 1);
            string childDestinationPath = header.DestinationPath;
            string childDestinationName = childDestinationPath.Substring(destinationResource.Uri.AbsoluteUri.Length + 1);
            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationPreference createPreference =
                baseJob._creationPreference != StorageResourceCreationPreference.Default ?
                baseJob._creationPreference : header.CreatePreference;

            StreamToUriJobPart jobPart = StreamToUriJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource.GetStorageResourceReference(childSourceName),
                destinationResource: destinationResource.GetStorageResourceReference(childDestinationName),
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static ServiceToServiceJobPart ToJobPartAsync(
            this ServiceToServiceTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);

            string childSourcePath = header.SourcePath;
            string childDestinationPath = header.DestinationPath;
            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationPreference createPreference =
                baseJob._creationPreference != StorageResourceCreationPreference.Default ?
                baseJob._creationPreference : header.CreatePreference;

            ServiceToServiceJobPart jobPart = ServiceToServiceJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource.GetStorageResourceReference(childSourcePath.Substring(sourceResource.Uri.AbsoluteUri.Length + 1)),
                destinationResource: destinationResource.GetStorageResourceReference(childDestinationPath.Substring(destinationResource.Uri.AbsoluteUri.Length + 1)),
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static UriToStreamJobPart ToJobPartAsync(
            this UriToStreamTransferJob baseJob,
            Stream planFileStream,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // Convert stream to job plan header
            JobPartPlanHeader header = JobPartPlanHeader.Deserialize(planFileStream);

            // Apply credentials to the saved transfer job path
            string childSourcePath = header.SourcePath;
            string childSourceName = childSourcePath.Substring(sourceResource.Uri.AbsoluteUri.Length + 1);
            string childDestinationPath = header.DestinationPath;
            string childDestinationName = childDestinationPath.Substring(destinationResource.Uri.AbsoluteUri.Length + 1);
            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationPreference createPreference =
                baseJob._creationPreference != StorageResourceCreationPreference.Default ?
                baseJob._creationPreference : header.CreatePreference;

            UriToStreamJobPart jobPart = UriToStreamJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource.GetStorageResourceReference(childSourceName),
                destinationResource: destinationResource.GetStorageResourceReference(childDestinationName),
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        /// <summary>
        /// Translate the initial job part header to a job plan format file
        /// </summary>
        internal static JobPartPlanHeader ToJobPartPlanHeader(this JobPartInternal jobPart)
        {
            string sourcePath = jobPart._sourceResource.Uri.ToSanitizedString();
            string destinationPath = jobPart._destinationResource.Uri.ToSanitizedString();

            return new JobPartPlanHeader(
                version: DataMovementConstants.JobPartPlanFile.SchemaVersion,
                transferId: jobPart._dataTransfer.Id,
                partNumber: jobPart.PartNumber,
                createTime: DateTimeOffset.UtcNow,
                sourceTypeId: jobPart._sourceResource.ResourceId,
                destinationTypeId: jobPart._destinationResource.ResourceId,
                sourcePath: sourcePath,
                destinationPath: destinationPath,
                createPreference: jobPart._createMode,
                initialTransferSize: jobPart._initialTransferSize,
                chunkSize: jobPart._transferChunkSize,
                priority: 0, // TODO: add priority feature
                jobPartStatus: jobPart.JobPartStatus);
        }

        /// <summary>
        /// Verifies the contents of the Job Part Plan Header with the
        /// information passed to resume the transfer.
        /// </summary>
        /// <param name="jobPart">The job part containing the resume information.</param>
        /// <param name="header">The header which holds the state of the job when it was stopped/paused.</param>
        internal static void VerifyJobPartPlanHeader(this JobPartInternal jobPart, JobPartPlanHeader header)
        {
            // Check transfer id
            if (!header.TransferId.Equals(jobPart._dataTransfer.Id))
            {
                throw Errors.MismatchTransferId(jobPart._dataTransfer.Id, header.TransferId);
            }

            // Check source path
            string passedSourcePath = jobPart._sourceResource.Uri.ToSanitizedString();

            // We only check if it starts with the path because if we're passed a container
            // then we only need to check if the prefix matches
            if (!header.SourcePath.StartsWith(passedSourcePath))
            {
                throw Errors.MismatchResumeTransferArguments(nameof(header.SourcePath), header.SourcePath, passedSourcePath);
            }

            // Check destination path
            string passedDestinationPath = jobPart._destinationResource.Uri.ToSanitizedString();

            // We only check if it starts with the path because if we're passed a container
            // then we only need to check if the prefix matches
            if (!header.DestinationPath.StartsWith(passedDestinationPath))
            {
                throw Errors.MismatchResumeTransferArguments(nameof(header.DestinationPath), header.DestinationPath, passedDestinationPath);
            }
        }
    }
}

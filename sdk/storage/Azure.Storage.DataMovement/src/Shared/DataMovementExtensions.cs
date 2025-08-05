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

            return new StorageResourceItemProperties()
            {
                ResourceLength = fileInfo.Length,
                LastModifiedTime = fileInfo.LastWriteTimeUtc,
                RawProperties = properties
            };
        }

        public static StreamToUriJobPart ToStreamToUriJobPartAsync(
            this TransferJobInternal baseJob,
            JobPartPlanHeader header,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            (string childSourceName, string childDestinationName) = GetChildResourceNames(header, sourceResource, destinationResource);

            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationMode createPreference =
                baseJob._creationPreference != StorageResourceCreationMode.Default ?
                baseJob._creationPreference : header.CreatePreference;

            StreamToUriJobPart jobPart = StreamToUriJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource.GetStorageResourceReference(childSourceName, header.SourceTypeId),
                destinationResource: destinationResource.GetStorageResourceReference(childDestinationName, header.DestinationTypeId),
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static ServiceToServiceJobPart ToServiceToServiceJobPartAsync(
            this TransferJobInternal baseJob,
            JobPartPlanHeader header,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            (string childSourceName, string childDestinationName) = GetChildResourceNames(header, sourceResource, destinationResource);

            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationMode createPreference =
                baseJob._creationPreference != StorageResourceCreationMode.Default ?
                baseJob._creationPreference : header.CreatePreference;

            ServiceToServiceJobPart jobPart = ServiceToServiceJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource.GetStorageResourceReference(childSourceName, header.SourceTypeId),
                destinationResource: destinationResource.GetStorageResourceReference(childDestinationName, header.DestinationTypeId),
                jobPartStatus: header.JobPartStatus,
                initialTransferSize: initialTransferSize,
                transferChunkSize: transferChunkSize,
                createPreference: createPreference);

            jobPart.VerifyJobPartPlanHeader(header);

            // TODO: When enabling resume chunked upload Add each transfer to the CommitChunkHandler
            return jobPart;
        }

        public static UriToStreamJobPart ToUriToStreamJobPartAsync(
            this TransferJobInternal baseJob,
            JobPartPlanHeader header,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            (string childSourceName, string childDestinationName) = GetChildResourceNames(header, sourceResource, destinationResource);

            // Override header values if options were specified by user.
            long initialTransferSize = baseJob._initialTransferSize ?? header.InitialTransferSize;
            long transferChunkSize = baseJob._maximumTransferChunkSize ?? header.ChunkSize;
            StorageResourceCreationMode createPreference =
                baseJob._creationPreference != StorageResourceCreationMode.Default ?
                baseJob._creationPreference : header.CreatePreference;

            UriToStreamJobPart jobPart = UriToStreamJobPart.CreateJobPartFromCheckpoint(
                job: baseJob,
                partNumber: Convert.ToInt32(header.PartNumber),
                sourceResource: sourceResource.GetStorageResourceReference(childSourceName, header.SourceTypeId),
                destinationResource: destinationResource.GetStorageResourceReference(childDestinationName, header.DestinationTypeId),
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
                transferId: jobPart._transferOperation.Id,
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
            if (!header.TransferId.Equals(jobPart._transferOperation.Id))
            {
                throw Errors.MismatchTransferId(jobPart._transferOperation.Id, header.TransferId);
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

        private static (string SourceName, string DestinationName) GetChildResourceNames(
            JobPartPlanHeader header,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource)
        {
            // If saved path equals the container Uri, it's a single item transfer, so the resource name
            // does not matter. Just set it to the path.
            string childSourceName = header.SourcePath == sourceResource.Uri.AbsoluteUri.ToString() ?
                header.SourcePath :
                header.SourcePath.Substring(sourceResource.Uri.AbsoluteUri.Length + 1);
            // Decode the resource name as it was pulled from encoded Uri and will be re-encoded.
            childSourceName = Uri.UnescapeDataString(childSourceName);

            string childDestinationName = header.DestinationPath == destinationResource.Uri.AbsoluteUri.ToString() ?
                header.DestinationPath :
                header.DestinationPath.Substring(destinationResource.Uri.AbsoluteUri.Length + 1);
            childDestinationName = Uri.UnescapeDataString(childDestinationName);
            return (childSourceName, childDestinationName);
        }
    }
}

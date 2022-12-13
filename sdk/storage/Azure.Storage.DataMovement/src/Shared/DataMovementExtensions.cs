// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Text;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal static class DataMovementExtensions
    {
        public static byte[] UriToByteArray(this StorageResource storageResource)
        {
            // Create Source Root
            byte[] byteArray;
            if (storageResource.CanProduceUri == ProduceUriType.ProducesUri)
            {
                Uri sourceUri = storageResource.Uri;
                byteArray = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}{1}{2}",
                    sourceUri.Authority,
                    Uri.SchemeDelimiter,
                    sourceUri.AbsolutePath).ToByteArray();
            }
            else
            {
                byteArray = storageResource.Path.ToByteArray();
            }
            return byteArray;
        }

        public static byte[] UriQueryToByteArray(this StorageResource storageResource)
        {
            // Create Source Root
            if (storageResource.CanProduceUri == ProduceUriType.ProducesUri)
            {
                Uri sourceUri = storageResource.Uri;
                return sourceUri.Query.ToByteArray();
            }
            return default;
        }

        public static byte[] ToByteArray(this string query)
        {
            // Convert query to byte array.
            return Encoding.Unicode.GetBytes(query);
        }

        internal static StorageResourceProperties ToStorageResourceProperties(this FileInfo fileInfo)
        {
            return new StorageResourceProperties(
                lastModified: fileInfo.LastWriteTimeUtc,
                createdOn: fileInfo.CreationTimeUtc,
                contentLength: fileInfo.Length,
                lastAccessed: fileInfo.LastAccessTimeUtc,
                resourceType: StorageResourceType.LocalFile);
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
                SourceExtraQueryLength = (ushort) sourceQueryParams.Length,
                SourceExtraQuery = sourceQueryParams,
                DestinationRootLength = (ushort) destinationRoot.Length,
                DestinationRoot = destinationRoot,
                DestExtraQueryLength= (ushort) destinationQueryParams.Length,
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
                atomicJobStatus = (uint) jobStatus,
                atomicPartStatus = (uint) jobPart.JobPartStatus,
                DeleteSnapshotsOption = JobPartDeleteSnapshotsOption.None, // TODO: revisit when feature is added
                PermanentDeleteOption = JobPartPermanentDeleteOption.None, // TODO: revisit when feature is added
                RehydratePriorityType = JobPartPlanRehydratePriorityType.None, // TODO: revisit when feature is added
            };
        }
    }
}

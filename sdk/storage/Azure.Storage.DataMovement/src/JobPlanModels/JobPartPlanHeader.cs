// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.JobPlanModels
{
    /// <summary>
    /// Stores the Job Part Header information to resume from.
    ///
    /// This matching the JobPartPlanHeader of azcopy
    /// </summary>
    internal class JobPartPlanHeader
    {
        /// <summary>
        /// The version of data schema format of header
        /// This will seem weird because we will have a schema for how we store the data
        /// when the schema changes this version will increment
        /// Index: 0
        ///
        /// Set to a size of 3
        /// TODO: Consider changing to an int when GA comes.
        /// TODO: In public preview we should
        /// leave the version as "b1", instead of complete ints.
        /// </summary>
        public string Version;

        /// <summary>
        /// The start time of the job part.
        /// Index: 4
        /// </summary>
        public DateTimeOffset StartTime;

        /// <summary>
        /// The Transfer/Job Id
        /// Index: 12
        ///
        /// Size of a GUID.
        /// </summary>
        public string TransferId;

        /// <summary>
        /// Job Part's part number (0+)
        /// Index: 84
        ///
        /// We don't expect there to be more than 50,000 job parts
        /// So reaching int.MAX is extremely unlikely
        /// </summary>
        public long PartNumber;

        /// <summary>
        /// The length of the source root path
        /// Index: 92
        /// </summary>
        public long SourcePathLength;

        /// <summary>
        /// The source path
        /// Index: 100
        ///
        /// Size of byte[] in azcopy is 1000 bytes.
        /// TODO: consider a different number, the max name of a blob cannot exceed 254
        /// however the max length of a path in linux is 4096.
        /// </summary>
        public string SourcePath;

        /// <summary>
        /// The length of the source path query
        /// Index: 8282
        /// </summary>
        public long SourceExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the source
        /// Index: 8290
        ///
        /// Size of byte array in azcopy is 1000 bytes.
        /// </summary>
        public string SourceExtraQuery;

        /// <summary>
        /// The length of the destination root path
        /// Index: 10,290
        /// </summary>
        public long DestinationPathLength;

        /// <summary>
        /// The destination path
        /// Index: 10,298
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        public string DestinationPath;

        /// <summary>
        /// The length of the destination path query
        /// Index: 18,480
        /// </summary>
        public long DestinationExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the dest
        /// Index: 18,488
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        public string DestinationExtraQuery;

        /// <summary>
        /// True if this is the Job's last part; else false
        /// Index: 20,488
        /// </summary>
        public bool IsFinalPart;

        /// <summary>
        /// True if the existing blobs needs to be overwritten.
        /// Index: 20,489
        /// </summary>
        public bool ForceWrite;

        /// <summary>
        /// Supplements ForceWrite with an additional setting for Azure Files. If true, the read-only attribute will be cleared before we overwrite
        /// Index: 20,490
        /// </summary>
        public bool ForceIfReadOnly;

        /// <summary>
        /// if true, source data with encodings that represent compression are automatically decompressed when downloading
        /// Index: 20,491
        /// </summary>
        public bool AutoDecompress;

        /// <summary>
        /// The Job Part's priority
        /// Index: 20,492
        /// </summary>
        public byte Priority;

        /// <summary>
        /// Time to live after completion is used to persists the file on disk of specified time after the completion of JobPartOrder
        ///
        /// Index: 20,493
        /// </summary>
        public DateTimeOffset TTLAfterCompletion;

        /// <summary>
        /// The location of the transfer's source and destination
        ///
        /// Index: 20,501
        /// </summary>
        public JobPlanFromTo FromTo;

        /// <summary>
        /// option specifying how folders will be handled
        ///
        /// Index: 20,502
        /// </summary>
        public FolderPropertiesMode FolderPropertyOption;

        /// <summary>
        /// The number of transfers in the Job part
        ///
        /// Index: 20,503
        /// </summary>
        public long NumberChunks;

        /// <summary>
        /// Additional data for blob destinations
        /// Holds the additional information about the blob
        ///
        /// Index: 20,511
        /// </summary>
        public JobPartPlanDestinationBlob DstBlobData;

        /// <summary>
        /// Additional data for local destinations
        /// </summary>
        public JobPartPlanDestinationLocal DstLocalData;

        /// <summary>
        /// If applicable the SMB information
        /// </summary>
        public bool PreserveSMBPermissions;

        /// <summary>
        /// Whether to preserve SMB info
        /// </summary>
        public bool PreserveSMBInfo;

        /// <summary>
        /// S2SGetPropertiesInBackend represents whether to enable get S3 objects' or Azure files' properties during s2s copy in backend.
        /// </summary>
        public bool S2SGetPropertiesInBackend;

        /// <summary>
        /// S2SSourceChangeValidation represents whether user wants to check if source has changed after enumerating.
        /// </summary>
        public bool S2SSourceChangeValidation;

        /// <summary>
        /// DestLengthValidation represents whether the user wants to check if the destination has a different content-length
        /// </summary>
        public bool DestLengthValidation;

        /// <summary>
        /// S2SInvalidMetadataHandleOption represents how user wants to handle invalid metadata.
        ///
        /// TODO: update to a struc tto handle the S2S Invalid metadata handle option
        /// </summary>
        public byte S2SInvalidMetadataHandleOption;

        /// <summary>
        /// For delete operation specify what to do with snapshots
        /// </summary>
        public JobPartDeleteSnapshotsOption DeleteSnapshotsOption;

        /// <summary>
        /// Permanent Delete Option
        /// </summary>
        public JobPartPermanentDeleteOption PermanentDeleteOption;

        /// <summary>
        /// Rehydrate Priority type
        /// </summary>
        public JobPartPlanRehydratePriorityType RehydratePriorityType;

        // Any fields below this comment are NOT constants; they may change over as the job part is processed.
        // Care must be taken to read/write to these fields in a thread-safe way!

        // jobStatus_doNotUse represents the current status of JobPartPlan
        // jobStatus_doNotUse is a private member whose value can be accessed by Status and SetJobStatus
        // jobStatus_doNotUse should not be directly accessed anywhere except by the Status and SetJobStatus
        public StorageTransferStatus AtomicJobStatus;

        public StorageTransferStatus AtomicPartStatus;

        private JobPartPlanHeader()
        {
        }

        internal JobPartPlanHeader(
            string version,
            DateTimeOffset startTime,
            string transferId,
            long partNumber,
            string sourcePath,
            string sourceExtraQuery,
            string destinationPath,
            string destinationExtraQuery,
            bool isFinalPart,
            bool forceWrite,
            bool forceIfReadOnly,
            bool autoDecompress,
            byte priority,
            DateTimeOffset ttlAfterCompletion,
            JobPlanFromTo fromTo,
            FolderPropertiesMode folderPropertyOption,
            long numberChunks,
            JobPartPlanDestinationBlob dstBlobData,
            JobPartPlanDestinationLocal dstLocalData,
            bool preserveSMBPermissions,
            bool preserveSMBInfo,
            bool s2sGetPropertiesInBackend,
            bool s2sSourceChangeValidation,
            bool destLengthValidation,
            byte s2sInvalidMetadataHandleOption,
            JobPartDeleteSnapshotsOption deleteSnapshotsOption,
            JobPartPermanentDeleteOption permanentDeleteOption,
            JobPartPlanRehydratePriorityType rehydratePriorityType,
            StorageTransferStatus atomicJobStatus,
            StorageTransferStatus atomicPartStatus)
        {
            // Version String size verification
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(startTime, nameof(startTime));
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNullOrEmpty(sourcePath, nameof(sourcePath));
            Argument.AssertNotNullOrWhiteSpace(destinationPath, nameof(destinationPath));
            Argument.AssertNotNull(ttlAfterCompletion, nameof(ttlAfterCompletion));
            if (version.Length == DataMovementConstants.PlanFile.VersionStrMaxSize)
            {
                Version = version;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(Version),
                    expectedSize: DataMovementConstants.PlanFile.VersionStrMaxSize,
                    actualSize: version.Length);
            }
            StartTime = startTime;
            // TransferId String size verification
            if (transferId.Length == DataMovementConstants.PlanFile.TransferIdStrMaxSize)
            {
                TransferId = transferId;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(TransferId),
                    expectedSize: DataMovementConstants.PlanFile.TransferIdStrMaxSize,
                    actualSize: transferId.Length);
            }
            PartNumber = partNumber;
            SourcePath = sourcePath;
            // TransferId String size verification
            if (sourcePath.Length <= DataMovementConstants.PlanFile.PathStrMaxSize)
            {
                SourcePath = sourcePath;
                SourcePathLength = sourcePath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(SourcePath),
                    expectedSize: DataMovementConstants.PlanFile.PathStrMaxSize,
                    actualSize: sourcePath.Length);
            }
            // SourcePath
            if (sourceExtraQuery.Length <= DataMovementConstants.PlanFile.ExtraQueryMaxSize)
            {
                SourceExtraQuery = sourceExtraQuery;
                SourceExtraQueryLength = sourceExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(SourceExtraQuery),
                    expectedSize: DataMovementConstants.PlanFile.ExtraQueryMaxSize,
                    actualSize: sourceExtraQuery.Length);
            }
            // DestinationPath
            if (destinationPath.Length <= DataMovementConstants.PlanFile.PathStrMaxSize)
            {
                DestinationPath = destinationPath;
                DestinationPathLength = destinationPath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(DestinationPath),
                    expectedSize: DataMovementConstants.PlanFile.PathStrMaxSize,
                    actualSize: destinationPath.Length);
            }
            if (destinationExtraQuery.Length <= DataMovementConstants.PlanFile.ExtraQueryMaxSize)
            {
                DestinationExtraQuery = destinationExtraQuery;
                DestinationExtraQueryLength = destinationExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(DestinationExtraQuery),
                    expectedSize: DataMovementConstants.PlanFile.ExtraQueryMaxSize,
                    actualSize: destinationExtraQuery.Length);
            }
            IsFinalPart = isFinalPart;
            ForceWrite = forceWrite;
            ForceIfReadOnly = forceIfReadOnly;
            AutoDecompress = autoDecompress;
            Priority = priority;
            TTLAfterCompletion = ttlAfterCompletion;
            FromTo = fromTo;
            FolderPropertyOption = folderPropertyOption;
            NumberChunks = numberChunks;
            DstBlobData = dstBlobData;
            DstLocalData = dstLocalData;
            PreserveSMBPermissions = preserveSMBPermissions;
            PreserveSMBInfo = preserveSMBInfo;
            S2SGetPropertiesInBackend = s2sGetPropertiesInBackend;
            S2SSourceChangeValidation = s2sSourceChangeValidation;
            DestLengthValidation = destLengthValidation;
            S2SInvalidMetadataHandleOption = s2sInvalidMetadataHandleOption;
            DeleteSnapshotsOption = deleteSnapshotsOption;
            PermanentDeleteOption = permanentDeleteOption;
            RehydratePriorityType = rehydratePriorityType;
            AtomicJobStatus = atomicJobStatus;
            AtomicPartStatus = atomicPartStatus;
        }

        /// <summary>
        /// Serializes the <see cref="JobPartPlanHeader"/> to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to which the serialized <see cref="JobPartPlanHeader"/> will be written.</param>
        public void Serialize(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            using (var writer = new BinaryWriter(stream))
            {
                // Version
                writer.Write(
                    buffer: Version.ToByteArray(DataMovementConstants.PlanFile.VersionMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.VersionIndex,
                    count: DataMovementConstants.PlanFile.VersionMaxSizeInBytes);

                // StartTime
                writer.Write(
                    buffer: StartTime.Ticks.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.StartTimeIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                // TransferId
                writer.Write(
                    buffer: TransferId.ToByteArray(DataMovementConstants.PlanFile.TransferIdMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.TransferIdIndex,
                    count: DataMovementConstants.PlanFile.TransferIdMaxSizeInBytes);

                // PartNumber
                writer.Write(
                    buffer: PartNumber.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.PartNumberIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                // SourcePathLength
                writer.Write(
                    buffer: SourcePathLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.SourcePathLengthIndex,
                    count: DataMovementConstants.PlanFile.PathStrMaxSizeInBytes);

                // SourcePath
                writer.Write(
                    buffer: SourcePath.ToByteArray(DataMovementConstants.PlanFile.PathStrMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.SourcePathIndex,
                    count: DataMovementConstants.PlanFile.PathStrMaxSizeInBytes);

                // SourceExtraQueryLength
                writer.Write(
                    buffer: SourceExtraQueryLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.SourceExtraQueryLengthIndex,
                    count: DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes);

                // SourceExtraQuery
                writer.Write(
                    buffer: SourceExtraQuery.ToByteArray(DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.SourceExtraQueryIndex,
                    count: DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes);

                // DestinationPathLength
                writer.Write(
                    buffer: DestinationPathLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DestinationPathLengthIndex,
                    count: DataMovementConstants.PlanFile.PathStrMaxSizeInBytes);

                // DestinationPath
                writer.Write(
                    buffer: DestinationPath.ToByteArray(DataMovementConstants.PlanFile.PathStrMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DestinationPathIndex,
                    count: DataMovementConstants.PlanFile.PathStrMaxSizeInBytes);

                // DestinationExtraQueryLength
                writer.Write(
                    buffer: DestinationExtraQueryLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DestinationExtraQueryLengthIndex,
                    count: DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes);

                // DestinationExtraQuery
                writer.Write(
                    buffer: DestinationExtraQuery.ToByteArray(DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DestinationExtraQueryIndex,
                    count: DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes);

                // IsFinalPart
                writer.Write(
                    buffer: new byte[] { Convert.ToByte(IsFinalPart) },
                    index: DataMovementConstants.PlanFile.IsFinalPartIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                // ForceWrite
                writer.Write(
                    buffer: new byte[] { Convert.ToByte(ForceWrite) },
                    index: DataMovementConstants.PlanFile.ForceWriteIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                // ForceIfReadOnly
                writer.Write(
                    buffer: new byte[] { Convert.ToByte(ForceIfReadOnly) },
                    index: DataMovementConstants.PlanFile.ForceIfReadOnlyIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                // AutoDecompress
                writer.Write(
                    buffer: new byte[] { Convert.ToByte(AutoDecompress) },
                    index: DataMovementConstants.PlanFile.AutoDecompressIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                // Priority
                writer.Write(
                    buffer: new byte[] { Priority },
                    index: DataMovementConstants.PlanFile.PriorityIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                // TTLAfterCompletion
                writer.Write(
                    buffer: TTLAfterCompletion.Ticks.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.TTLAfterCompletionIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                // FromTo
                writer.Write(
                    buffer: new byte[] { (byte)FromTo },
                    index: DataMovementConstants.PlanFile.FromToIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                // FolderPropertyOption
                writer.Write(
                    buffer: new byte[] { (byte)FolderPropertyOption },
                    index: DataMovementConstants.PlanFile.FolderPropertyOptionIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                // NumberChunks
                writer.Write(
                    buffer: NumberChunks.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.NumberChunksIndex,
                    count: DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes);

                // DstBlobData.BlobType
                writer.Write(
                    buffer: new byte[] { (byte)DstBlobData.BlobType },
                    index: DataMovementConstants.PlanFile.DstBlobTypeIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { Convert.ToByte(DstBlobData.NoGuessMimeType) },
                    index: DataMovementConstants.PlanFile.DstBlobNoGuessMimeTypeIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: DstBlobData.ContentTypeLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentTypeLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.ContentType.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentTypeIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.ContentEncodingLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentEncodingLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.ContentEncoding.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentEncodingIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.ContentLanguageLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentLanguageLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.ContentLanguage.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentLanguageIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.ContentDispositionLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentDispositionLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.ContentDisposition.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobContentDispositionIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.CacheControlLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobCacheControlLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.CacheControl.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobCacheControlIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: new byte[] { (byte)DstBlobData.BlockBlobTier },
                    index: DataMovementConstants.PlanFile.DstBlobBlockBlobTierIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { (byte)DstBlobData.PageBlobTier },
                    index: DataMovementConstants.PlanFile.DstBlobPageBlobTierIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { Convert.ToByte(DstBlobData.PutMd5) },
                    index: DataMovementConstants.PlanFile.DstBlobPutMd5Index,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: DstBlobData.MetadataLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobMetadataLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.Metadata.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobMetadataIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.BlobTagsLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobTagsLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.BlobTags.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobTagsIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.CpkInfoLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobCpkInfoLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.CpkInfo.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobCpkInfoIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.CpkScopeInfoLength.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobCpkScopeInfoLengthIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.CpkScopeInfo.ToByteArray(DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobCpkScopeInfoIndex,
                    count: DataMovementConstants.PlanFile.HeaderValueMaxSizeInBytes);

                writer.Write(
                    buffer: DstBlobData.BlockSize.ToByteArray(DataMovementConstants.PlanFile.LongSizeInBytes),
                    index: DataMovementConstants.PlanFile.DstBlobBlockSizeIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: new byte[] { Convert.ToByte(DstLocalData.PreserveLastModifiedTime) },
                    index: DataMovementConstants.PlanFile.DstLocalPreserveLastModifiedTimeIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { DstLocalData.MD5VerificationOption },
                    index: DataMovementConstants.PlanFile.DstLocalMD5VerificationOptionIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { Convert.ToByte(PreserveSMBPermissions) },
                    index: DataMovementConstants.PlanFile.PreserveSMBPermissionsIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { Convert.ToByte(PreserveSMBInfo) },
                    index: DataMovementConstants.PlanFile.PreserveSMBInfoIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { Convert.ToByte(S2SGetPropertiesInBackend) },
                    index: DataMovementConstants.PlanFile.S2SGetPropertiesInBackendIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { S2SInvalidMetadataHandleOption },
                    index: DataMovementConstants.PlanFile.S2SInvalidMetadataHandleOptionIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { Convert.ToByte(DestLengthValidation) },
                    index: DataMovementConstants.PlanFile.DestLengthValidationIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { (byte)DeleteSnapshotsOption },
                    index: DataMovementConstants.PlanFile.DeleteSnapshotsOptionIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { (byte)PermanentDeleteOption },
                    index: DataMovementConstants.PlanFile.PermanentDeleteOptionIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { (byte)RehydratePriorityType },
                    index: DataMovementConstants.PlanFile.RehydratePriorityTypeIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { (byte)AtomicJobStatus },
                    index: DataMovementConstants.PlanFile.AtomicJobStatusIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Write(
                    buffer: new byte[] { (byte)AtomicPartStatus },
                    index: DataMovementConstants.PlanFile.AtomicPartStatusIndex,
                    count: DataMovementConstants.PlanFile.OneByte);

                writer.Flush();
            }
        }

        public static JobPartPlanHeader Deserialize(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var header = new JobPartPlanHeader();
            using (var reader = new BinaryReader(stream))
            {
                reader.BaseStream.Position = 0;

                // Version
                byte[] versionBuffer = new byte[DataMovementConstants.PlanFile.VersionMaxSizeInBytes];
                versionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.VersionMaxSizeInBytes);
                header.Version = versionBuffer.ByteArrayToString();

                // Start Time
                byte[] startTimeBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
                startTimeBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
                header.StartTime = new DateTimeOffset(startTimeBuffer.ByteArrayToLong(), new TimeSpan(1,0,0));

                // Transfer Id
                byte[] transferIdBuffer = new byte[DataMovementConstants.PlanFile.TransferIdMaxSizeInBytes];
                transferIdBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.TransferIdMaxSizeInBytes);
                header.TransferId = transferIdBuffer.ByteArrayToString();

                // Job Part Number
                byte[] partNumberBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
                partNumberBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
                header.PartNumber = partNumberBuffer.ByteArrayToLong();

                // SourcePathLength
                byte[] sourcePathLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
                sourcePathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
                header.SourcePathLength = sourcePathLengthBuffer.ByteArrayToLong();

                // SourcePath
                byte[] sourcePathBuffer = new byte[DataMovementConstants.PlanFile.PathStrMaxSizeInBytes];
                sourcePathBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.PathStrMaxSizeInBytes);
                header.SourcePath = sourcePathBuffer.ByteArrayToString();

                // SourceExtraQueryLength
                byte[] sourceExtraQueryLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
                sourceExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
                header.SourceExtraQueryLength = sourceExtraQueryLengthBuffer.ByteArrayToLong();

                // SourceExtraQuery
                byte[] sourceExtraQueryBuffer = new byte[DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes];
                sourceExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes);
                header.SourceExtraQuery = sourceExtraQueryBuffer.ByteArrayToString();

                // DestinationPathLength
                byte[] destinationPathLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
                destinationPathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
                header.DestinationPathLength = destinationPathLengthBuffer.ByteArrayToLong();

                // DestinationPath
                byte[] destinationPathBuffer = new byte[DataMovementConstants.PlanFile.PathStrMaxSizeInBytes];
                destinationPathBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.PathStrMaxSizeInBytes);
                header.DestinationPath = destinationPathBuffer.ByteArrayToString();

                // DestinationExtraQueryLength
                byte[] destinationExtraQueryLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
                destinationExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
                header.DestinationExtraQueryLength = destinationExtraQueryLengthBuffer.ByteArrayToLong();

                // DestinationExtraQuery
                byte[] destinationExtraQueryBuffer = new byte[DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes];
                destinationExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.ExtraQueryMaxSizeInBytes);
                header.DestinationExtraQuery = destinationExtraQueryBuffer.ByteArrayToString();

                // IsFinalPart
                byte isFinalPartByte = reader.ReadByte();
                header.IsFinalPart = Convert.ToBoolean(isFinalPartByte);

                // ForceWrite
                byte forceWriteByte = reader.ReadByte();
                header.ForceWrite = Convert.ToBoolean(forceWriteByte);

                // ForceIfReadOnly
                byte ForceIfReadOnlyByte = reader.ReadByte();
                header.ForceIfReadOnly = Convert.ToBoolean(ForceIfReadOnlyByte);

                // AutoDecompress
                byte autoDecompressByte = reader.ReadByte();
                header.AutoDecompress = Convert.ToBoolean(autoDecompressByte);

                // Priority
                header.Priority = reader.ReadByte();

                // TTLAfterCompletion
                byte[] ttlAfterCompletionBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
                ttlAfterCompletionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
                header.TTLAfterCompletion = new DateTimeOffset(ttlAfterCompletionBuffer.ByteArrayToLong(), new TimeSpan(1, 0, 0));

                // FromTo
                byte fromToByte = reader.ReadByte();
                header.FromTo = (JobPlanFromTo) fromToByte;

                // TODO: the rest down from FromTo
            }

            return header;
        }
    }
}

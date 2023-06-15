// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models.JobPlan
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
        ///
        /// TODO: Consider changing to an int when GA comes.
        /// TODO: In public preview we should
        /// leave the version as "b1", instead of complete ints.
        /// </summary>
        public string Version;

        /// <summary>
        /// The start time of the job part.
        /// </summary>
        public DateTimeOffset StartTime;

        /// <summary>
        /// The Transfer/Job Id
        ///
        /// Size of a GUID.
        /// </summary>
        public string TransferId;

        /// <summary>
        /// Job Part's part number (0+)
        /// </summary>
        public long PartNumber;

        /// <summary>
        /// The length of the source root path
        /// </summary>
        public ushort SourcePathLength;

        /// <summary>
        /// The source path
        /// </summary>
        public string SourcePath;

        /// <summary>
        /// The length of the source path query
        /// </summary>
        public ushort SourceExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the source
        ///
        /// Size of byte array in azcopy is 1000 bytes.
        /// </summary>
        public string SourceExtraQuery;

        /// <summary>
        /// The length of the destination root path
        /// </summary>
        public ushort DestinationPathLength;

        /// <summary>
        /// The destination path
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        public string DestinationPath;

        /// <summary>
        /// The length of the destination path query
        /// </summary>
        public ushort DestinationExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the dest
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        public string DestinationExtraQuery;

        /// <summary>
        /// True if this is the Job's last part; else false
        /// </summary>
        public bool IsFinalPart;

        /// <summary>
        /// True if the existing blobs needs to be overwritten.
        /// </summary>
        public bool ForceWrite;

        /// <summary>
        /// Supplements ForceWrite with an additional setting for Azure Files. If true, the read-only attribute will be cleared before we overwrite
        /// </summary>
        public bool ForceIfReadOnly;

        /// <summary>
        /// if true, source data with encodings that represent compression are automatically decompressed when downloading
        /// </summary>
        public bool AutoDecompress;

        /// <summary>
        /// The Job Part's priority
        /// </summary>
        public byte Priority;

        /// <summary>
        /// Time to live after completion is used to persists the file on disk of specified time after the completion of JobPartOrder
        /// </summary>
        public DateTimeOffset TTLAfterCompletion;

        /// <summary>
        /// The location of the transfer's source and destination
        /// </summary>
        public JobPlanOperation JobPlanOperation;

        /// <summary>
        /// option specifying how folders will be handled
        /// </summary>
        public FolderPropertiesMode FolderPropertyMode;

        /// <summary>
        /// The number of transfers in the Job part
        /// </summary>
        public long NumberChunks;

        /// <summary>
        /// Additional data for blob destinations
        /// Holds the additional information about the blob
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
            JobPlanOperation jobPlanOperation,
            FolderPropertiesMode folderPropertyMode,
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
            Argument.AssertNotNull(dstBlobData, nameof(dstBlobData));
            Argument.AssertNotNull(dstLocalData, nameof(dstLocalData));
            // Version
            if (version.Length == DataMovementConstants.PlanFile.VersionStrLength)
            {
                Version = version;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(Version),
                    expectedSize: DataMovementConstants.PlanFile.VersionStrLength,
                    actualSize: version.Length);
            }
            StartTime = startTime;
            // TransferId
            if (transferId.Length == DataMovementConstants.PlanFile.TransferIdStrLength)
            {
                TransferId = transferId;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(TransferId),
                    expectedSize: DataMovementConstants.PlanFile.TransferIdStrLength,
                    actualSize: transferId.Length);
            }
            PartNumber = partNumber;
            SourcePath = sourcePath;
            // SourcePath
            if (sourcePath.Length <= DataMovementConstants.PlanFile.PathStrMaxLength)
            {
                SourcePath = sourcePath;
                SourcePathLength = (ushort) sourcePath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(SourcePath),
                    expectedSize: DataMovementConstants.PlanFile.PathStrMaxLength,
                    actualSize: sourcePath.Length);
            }
            // SourceQuery
            if (sourceExtraQuery.Length <= DataMovementConstants.PlanFile.ExtraQueryMaxLength)
            {
                SourceExtraQuery = sourceExtraQuery;
                SourceExtraQueryLength = (ushort) sourceExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(SourceExtraQuery),
                    expectedSize: DataMovementConstants.PlanFile.ExtraQueryMaxLength,
                    actualSize: sourceExtraQuery.Length);
            }
            // DestinationPath
            if (destinationPath.Length <= DataMovementConstants.PlanFile.PathStrMaxLength)
            {
                DestinationPath = destinationPath;
                DestinationPathLength = (ushort) destinationPath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(DestinationPath),
                    expectedSize: DataMovementConstants.PlanFile.PathStrMaxLength,
                    actualSize: destinationPath.Length);
            }
            // DestinationQuery
            if (destinationExtraQuery.Length <= DataMovementConstants.PlanFile.ExtraQueryMaxLength)
            {
                DestinationExtraQuery = destinationExtraQuery;
                DestinationExtraQueryLength = (ushort) destinationExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(DestinationExtraQuery),
                    expectedSize: DataMovementConstants.PlanFile.ExtraQueryMaxLength,
                    actualSize: destinationExtraQuery.Length);
            }
            IsFinalPart = isFinalPart;
            ForceWrite = forceWrite;
            ForceIfReadOnly = forceIfReadOnly;
            AutoDecompress = autoDecompress;
            Priority = priority;
            TTLAfterCompletion = ttlAfterCompletion;
            JobPlanOperation = jobPlanOperation;
            FolderPropertyMode = folderPropertyMode;
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

            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            WriteString(writer, Version, DataMovementConstants.PlanFile.VersionStrNumBytes);

            // StartTime
            writer.Write(StartTime.Ticks);

            // TransferId
            WriteString(writer, TransferId, DataMovementConstants.PlanFile.TransferIdStrNumBytes);

            // PartNumber
            writer.Write(PartNumber);

            // SourcePathLength
            writer.Write(SourcePathLength);

            // SourcePath
            WriteString(writer, SourcePath, DataMovementConstants.PlanFile.PathStrNumBytes);

            // SourceExtraQueryLength
            writer.Write(SourceExtraQueryLength);

            // SourceExtraQuery
            WriteString(writer, SourceExtraQuery, DataMovementConstants.PlanFile.ExtraQueryNumBytes);

            // DestinationPathLength
            writer.Write(DestinationPathLength);

            // DestinationPath
            WriteString(writer, DestinationPath, DataMovementConstants.PlanFile.PathStrNumBytes);

            // DestinationExtraQueryLength
            writer.Write(DestinationExtraQueryLength);

            // DestinationExtraQuery
            WriteString(writer, DestinationExtraQuery, DataMovementConstants.PlanFile.ExtraQueryNumBytes);

            // IsFinalPart
            writer.Write(Convert.ToByte(IsFinalPart));

            // ForceWrite
            writer.Write(Convert.ToByte(ForceWrite));

            // ForceIfReadOnly
            writer.Write(Convert.ToByte(ForceIfReadOnly));

            // AutoDecompress
            writer.Write(Convert.ToByte(AutoDecompress));

            // Priority
            writer.Write(Priority);

            // TTLAfterCompletion
            writer.Write(TTLAfterCompletion.Ticks);

            // FromTo
            writer.Write((byte)JobPlanOperation);

            // FolderPropertyOption
            writer.Write((byte)FolderPropertyMode);

            // NumberChunks
            writer.Write(NumberChunks);

            // DstBlobData.BlobType
            writer.Write((byte)DstBlobData.BlobType);

            // DstBlobData.NoGuessMimeType
            writer.Write(Convert.ToByte(DstBlobData.NoGuessMimeType));

            // DstBlobData.ContentTypeLength
            writer.Write(DstBlobData.ContentTypeLength);

            // DstBlobData.ContentType
            WriteString(writer, DstBlobData.ContentType, DataMovementConstants.PlanFile.HeaderValueNumBytes);

            // DstBlobData.ContentEncodingLength
            writer.Write(DstBlobData.ContentEncodingLength);

            // DstBlobData.ContentEncoding
            WriteString(writer, DstBlobData.ContentEncoding, DataMovementConstants.PlanFile.HeaderValueNumBytes);

            // DstBlobData.ContentLanguageLength
            writer.Write(DstBlobData.ContentLanguageLength);

            // DstBlobData.ContentLanguage
            WriteString(writer, DstBlobData.ContentLanguage, DataMovementConstants.PlanFile.HeaderValueNumBytes);

            // DstBlobData.ContentDispositionLength
            writer.Write(DstBlobData.ContentDispositionLength);

            // DstBlobData.ContentDisposition
            WriteString(writer, DstBlobData.ContentDisposition, DataMovementConstants.PlanFile.HeaderValueNumBytes);

            // DstBlobData.CacheControlLength
            writer.Write(DstBlobData.CacheControlLength);

            // DstBlobData.CacheControl
            WriteString(writer, DstBlobData.CacheControl, DataMovementConstants.PlanFile.HeaderValueNumBytes);

            // DstBlobData.BlockBlobTier
            writer.Write((byte)DstBlobData.BlockBlobTier);

            // DstBlobData.PageBlobTier
            writer.Write((byte)DstBlobData.PageBlobTier);

            // DstBlobData.PutMd5
            writer.Write(Convert.ToByte(DstBlobData.PutMd5));

            // DstBlobData.MetadataLength
            writer.Write(DstBlobData.MetadataLength);

            // DstBlobData.Metadata
            WriteString(writer, DstBlobData.Metadata, DataMovementConstants.PlanFile.MetadataStrNumBytes);

            // DstBlobData.BlobTagsLength
            writer.Write(DstBlobData.BlobTagsLength);

            // DstBlobData.BlobTags
            WriteString(writer, DstBlobData.BlobTags, DataMovementConstants.PlanFile.BlobTagsStrNumBytes);

            // DstBlobData.IsSourceEncrypted
            writer.Write(DstBlobData.IsSourceEncrypted);

            // DstBlobData.CpkScopeInfoLength
            writer.Write(DstBlobData.CpkScopeInfoLength);

            // DstBlobData.CpkScopeInfo
            WriteString(writer, DstBlobData.CpkScopeInfo, DataMovementConstants.PlanFile.HeaderValueNumBytes);

            // DstBlobData.BlockSize
            writer.Write(DstBlobData.BlockSize);

            // DstLocalData.PreserveLastModifiedTime
            writer.Write(Convert.ToByte(DstLocalData.PreserveLastModifiedTime));

            // DstLocalData.MD5VerificationOption
            writer.Write(DstLocalData.ChecksumVerificationOption);

            // PreserveSMBPermissions
            writer.Write(Convert.ToByte(PreserveSMBPermissions));

            // PreserveSMBInfo
            writer.Write(Convert.ToByte(PreserveSMBInfo));

            // S2SGetPropertiesInBackend
            writer.Write(Convert.ToByte(S2SGetPropertiesInBackend));

            // S2SSourceChangeValidationBuffer
            writer.Write(Convert.ToByte(S2SSourceChangeValidation));

            // DestLengthValidation
            writer.Write(Convert.ToByte(DestLengthValidation));

            // S2SInvalidMetadataHandleOption
            writer.Write(S2SInvalidMetadataHandleOption);

            // DeleteSnapshotsOption
            writer.Write((byte)DeleteSnapshotsOption);

            // PermanentDeleteOption
            writer.Write((byte)PermanentDeleteOption);

            // RehydratePriorityType
            writer.Write((byte)RehydratePriorityType);

            // AtomicJobStatus
            writer.Write((byte)AtomicJobStatus);

            // AtomicPartStatus
            writer.Write((byte)AtomicPartStatus);
        }

        public static JobPartPlanHeader Deserialize(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            BinaryReader reader = new BinaryReader(stream);
            reader.BaseStream.Position = 0;

            // Version
            byte[] versionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.VersionStrNumBytes);
            string version = versionBuffer.ToString(DataMovementConstants.PlanFile.VersionStrLength);

            // Start Time
            byte[] startTimeBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            DateTimeOffset startTime = new DateTimeOffset(startTimeBuffer.ToLong(), new TimeSpan(0, 0, 0));

            // Transfer Id
            byte[] transferIdBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.TransferIdStrNumBytes);
            string transferId = transferIdBuffer.ToString(DataMovementConstants.PlanFile.TransferIdStrLength);

            // Job Part Number
            byte[] partNumberBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long partNumber = partNumberBuffer.ToLong();

            // SourcePathLength
            byte[] sourcePathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort sourcePathLength = sourcePathLengthBuffer.ToUShort();

            // SourcePath
            byte[] sourcePathBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.PathStrNumBytes);
            string sourcePath = sourcePathBuffer.ToString(sourcePathLength);

            // SourceExtraQueryLength
            byte[] sourceExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort sourceExtraQueryLength = sourceExtraQueryLengthBuffer.ToUShort();

            // SourceExtraQuery
            byte[] sourceExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.ExtraQueryNumBytes);
            string sourceExtraQuery = sourceExtraQueryBuffer.ToString(sourceExtraQueryLength);

            // DestinationPathLength
            byte[] destinationPathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort destinationPathLength = destinationPathLengthBuffer.ToUShort();

            // DestinationPath
            byte[] destinationPathBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.PathStrNumBytes);
            string destinationPath = destinationPathBuffer.ToString(destinationPathLength);

            // DestinationExtraQueryLength
            byte[] destinationExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort destinationExtraQueryLength = destinationExtraQueryLengthBuffer.ToUShort();

            // DestinationExtraQuery
            byte[] destinationExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.ExtraQueryNumBytes);
            string destinationExtraQuery = destinationExtraQueryBuffer.ToString(destinationExtraQueryLength);

            // IsFinalPart
            byte isFinalPartByte = reader.ReadByte();
            bool isFinalPart = Convert.ToBoolean(isFinalPartByte);

            // ForceWrite
            byte forceWriteByte = reader.ReadByte();
            bool forceWrite = Convert.ToBoolean(forceWriteByte);

            // ForceIfReadOnly
            byte forceIfReadOnlyByte = reader.ReadByte();
            bool forceIfReadOnly = Convert.ToBoolean(forceIfReadOnlyByte);

            // AutoDecompress
            byte autoDecompressByte = reader.ReadByte();
            bool autoDecompress = Convert.ToBoolean(autoDecompressByte);

            // Priority
            byte priority = reader.ReadByte();

            // TTLAfterCompletion
            byte[] ttlAfterCompletionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            DateTimeOffset ttlAfterCompletion = new DateTimeOffset(ttlAfterCompletionBuffer.ToLong(), new TimeSpan(0, 0, 0));

            // JobPlanOperation
            byte fromToByte = reader.ReadByte();
            JobPlanOperation fromTo = (JobPlanOperation)fromToByte;

            // FolderPropertyOption
            byte folderPropertyOptionByte = reader.ReadByte();
            FolderPropertiesMode folderPropertyMode = (FolderPropertiesMode)folderPropertyOptionByte;

            // NumberChunks
            byte[] numberChunksBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long numberChunks = numberChunksBuffer.ToLong();

            // DstBlobData.BlobType
            byte blobTypeByte = reader.ReadByte();
            JobPlanBlobType blobType = (JobPlanBlobType)blobTypeByte;

            // DstBlobData.NoGuessMimeType
            byte noGuessMimeTypeByte = reader.ReadByte();
            bool noGuessMimeType = Convert.ToBoolean(noGuessMimeTypeByte);

            // DstBlobData.ContentTypeLength
            byte[] contentTypeLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort contentTypeLength = contentTypeLengthBuffer.ToUShort();

            // DstBlobData.ContentType
            byte[] contentTypeBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueNumBytes);
            string contentType = contentTypeBuffer.ToString(contentTypeLength);

            // DstBlobData.ContentEncodingLength
            byte[] contentEncodingLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort contentEncodingLength = contentEncodingLengthBuffer.ToUShort();

            // DstBlobData.ContentEncoding
            byte[] contentEncodingBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueNumBytes);
            string contentEncoding = contentEncodingBuffer.ToString(contentEncodingLength);

            // DstBlobData.ContentLanguageLength
            byte[] contentLanguageLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort contentLanguageLength = contentLanguageLengthBuffer.ToUShort();

            // DstBlobData.ContentLanguage
            byte[] contentLanguageBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueNumBytes);
            string contentLanguage = contentLanguageBuffer.ToString(contentLanguageLength);

            // DstBlobData.ContentDispositionLength
            byte[] contentDispositionLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort contentDispositionLength = contentDispositionLengthBuffer.ToUShort();

            // DstBlobData.ContentDisposition
            byte[] contentDispositionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueNumBytes);
            string contentDisposition = contentDispositionBuffer.ToString(contentDispositionLength);

            // DstBlobData.CacheControlLength
            byte[] cacheControlLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort cacheControlLength = cacheControlLengthBuffer.ToUShort();

            // DstBlobData.CacheControl
            byte[] cacheControlBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueNumBytes);
            string cacheControl = cacheControlBuffer.ToString(cacheControlLength);

            // DstBlobData.BlockBlobTier
            byte blockBlobTierByte = reader.ReadByte();
            JobPartPlanBlockBlobTier blockBlobTier = (JobPartPlanBlockBlobTier)blockBlobTierByte;

            // DstBlobData.PageBlobTier
            byte pageBlobTierByte = reader.ReadByte();
            JobPartPlanPageBlobTier pageBlobTier = (JobPartPlanPageBlobTier)pageBlobTierByte;

            // DstBlobData.PutMd5
            byte putMd5Byte = reader.ReadByte();
            bool putMd5 = Convert.ToBoolean(putMd5Byte);

            // DstBlobData.MetadataLength
            byte[] metadataLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort metadataLength = metadataLengthBuffer.ToUShort();

            // DstBlobData.Metadata
            byte[] metadataBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.MetadataStrNumBytes);
            string metadata = metadataBuffer.ToString(metadataLength);

            // DstBlobData.BlobTagsLength
            byte[] blobTagsLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long blobTagsLength = blobTagsLengthBuffer.ToLong();

            // DstBlobData.BlobTags
            byte[] blobTagsBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.BlobTagsStrNumBytes);
            string blobTags = blobTagsBuffer.ToString(blobTagsLength);

            // DstBlobData.IsSourceEncrypted
            bool isSourceEncrypted = Convert.ToBoolean(reader.ReadByte());

            // DstBlobData.CpkScopeInfoLength
            byte[] cpkScopeInfoLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
            ushort cpkScopeInfoLength = cpkScopeInfoLengthBuffer.ToUShort();

            // DstBlobData.CpkScopeInfo
            byte[] cpkScopeInfoBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueNumBytes);
            string cpkScopeInfo = cpkScopeInfoBuffer.ToString(cpkScopeInfoLength);

            // DstBlobData.BlockSize
            byte[] blockSizeLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long blockSize = blockSizeLengthBuffer.ToLong();

            // DstLocalData.PreserveLastModifiedTime
            bool preserveLastModifiedTime = Convert.ToBoolean(reader.ReadByte());

            // DstBlobData.MD5VerificationOption
            byte checksumVerificationOption = reader.ReadByte();

            // preserveSMBPermissions
            bool preserveSMBPermissions = Convert.ToBoolean(reader.ReadByte());

            // PreserveSMBInfo
            bool preserveSMBInfo = Convert.ToBoolean(reader.ReadByte());

            // S2SGetPropertiesInBackend
            bool s2sGetPropertiesInBackend = Convert.ToBoolean(reader.ReadByte());

            // S2SSourceChangeValidation
            bool s2sSourceChangeValidation = Convert.ToBoolean(reader.ReadByte());

            // DestLengthValidation
            bool destLengthValidation = Convert.ToBoolean(reader.ReadByte());

            // S2SInvalidMetadataHandleOption
            byte s2sInvalidMetadataHandleOption = reader.ReadByte();

            // DeleteSnapshotsOption
            byte deleteSnapshotsOptionByte = reader.ReadByte();
            JobPartDeleteSnapshotsOption deleteSnapshotsOption = (JobPartDeleteSnapshotsOption)deleteSnapshotsOptionByte;

            // PermanentDeleteOption
            byte permanentDeleteOptionByte = reader.ReadByte();
            JobPartPermanentDeleteOption permanentDeleteOption = (JobPartPermanentDeleteOption)permanentDeleteOptionByte;

            // RehydratePriorityType
            byte rehydratePriorityTypeByte = reader.ReadByte();
            JobPartPlanRehydratePriorityType rehydratePriorityType = (JobPartPlanRehydratePriorityType)rehydratePriorityTypeByte;

            // AtomicJobStatus
            byte atomicJobStatusByte = reader.ReadByte();
            StorageTransferStatus atomicJobStatus = (StorageTransferStatus)atomicJobStatusByte;

            // AtomicPartStatus
            byte atomicPartStatusByte = reader.ReadByte();
            StorageTransferStatus atomicPartStatus = (StorageTransferStatus)atomicPartStatusByte;

            JobPartPlanDestinationBlob dstBlobData = new JobPartPlanDestinationBlob(
                blobType: blobType,
                noGuessMimeType: noGuessMimeType,
                contentType: contentType,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentDisposition: contentDisposition,
                cacheControl: cacheControl,
                blockBlobTier: blockBlobTier,
                pageBlobTier: pageBlobTier,
                putMd5: putMd5,
                metadata: metadata,
                blobTags: blobTags,
                isSourceEncrypted: isSourceEncrypted,
                cpkScopeInfo: cpkScopeInfo,
                blockSize: blockSize);

            JobPartPlanDestinationLocal dstLocalData = new JobPartPlanDestinationLocal(
                preserveLastModifiedTime: preserveLastModifiedTime,
                checksumVerificationOption: checksumVerificationOption);

            return new JobPartPlanHeader(
                version: version,
                startTime: startTime,
                transferId: transferId,
                partNumber: partNumber,
                sourcePath: sourcePath,
                sourceExtraQuery: sourceExtraQuery,
                destinationPath: destinationPath,
                destinationExtraQuery: destinationExtraQuery,
                isFinalPart: isFinalPart,
                forceWrite: forceWrite,
                forceIfReadOnly: forceIfReadOnly,
                autoDecompress: autoDecompress,
                priority: priority,
                ttlAfterCompletion: ttlAfterCompletion,
                jobPlanOperation: fromTo,
                folderPropertyMode: folderPropertyMode,
                numberChunks: numberChunks,
                dstBlobData: dstBlobData,
                dstLocalData: dstLocalData,
                preserveSMBPermissions: preserveSMBPermissions,
                preserveSMBInfo: preserveSMBInfo,
                s2sGetPropertiesInBackend: s2sGetPropertiesInBackend,
                s2sSourceChangeValidation: s2sSourceChangeValidation,
                destLengthValidation: destLengthValidation,
                s2sInvalidMetadataHandleOption: s2sInvalidMetadataHandleOption,
                deleteSnapshotsOption: deleteSnapshotsOption,
                permanentDeleteOption: permanentDeleteOption,
                rehydratePriorityType: rehydratePriorityType,
                atomicJobStatus: atomicJobStatus,
                atomicPartStatus: atomicPartStatus);
        }

        private static void WriteString(BinaryWriter writer, string value, int setSizeInBytes)
        {
            writer.Write(value.ToCharArray());

            int padding = setSizeInBytes - value.Length;
            if (padding > 0)
            {
                char[] paddingArray = new char[padding];
                writer.Write(paddingArray);
            }
        }
    }
}

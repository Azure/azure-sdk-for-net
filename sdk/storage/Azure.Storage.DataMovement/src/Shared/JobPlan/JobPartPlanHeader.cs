// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core;

namespace Azure.Storage.DataMovement.JobPlan
{
    /// <summary>
    /// Stores the Job Part Header information to resume from.
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
        /// The length of the source resource identifier
        /// </summary>
        public ushort SourceResourceIdLength;

        /// <summary>
        /// The identifier of the source resource
        /// </summary>
        public string SourceResourceId;

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
        /// </summary>
        public string SourceExtraQuery;

        /// <summary>
        /// The length of the destination resource identifier
        /// </summary>
        public ushort DestinationResourceIdLength;

        /// <summary>
        /// The identifier of the destination resource
        /// </summary>
        public string DestinationResourceId;

        /// <summary>
        /// The length of the destination root path
        /// </summary>
        public ushort DestinationPathLength;

        /// <summary>
        /// The destination path
        /// </summary>
        public string DestinationPath;

        /// <summary>
        /// The length of the destination path query
        /// </summary>
        public ushort DestinationExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the dest
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
        public DataTransferStatus AtomicJobStatus;

        public DataTransferStatus AtomicPartStatus;

        internal JobPartPlanHeader(
            string version,
            DateTimeOffset startTime,
            string transferId,
            long partNumber,
            string sourceResourceId,
            string sourcePath,
            string sourceExtraQuery,
            string destinationResourceId,
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
            DataTransferStatus atomicJobStatus,
            DataTransferStatus atomicPartStatus)
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
            if (version.Length == DataMovementConstants.JobPartPlanFile.VersionStrLength)
            {
                Version = version;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(Version),
                    expectedSize: DataMovementConstants.JobPartPlanFile.VersionStrLength,
                    actualSize: version.Length);
            }
            StartTime = startTime;
            // TransferId
            if (transferId.Length == DataMovementConstants.JobPartPlanFile.TransferIdStrLength)
            {
                TransferId = transferId;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(TransferId),
                    expectedSize: DataMovementConstants.JobPartPlanFile.TransferIdStrLength,
                    actualSize: transferId.Length);
            }
            PartNumber = partNumber;
            // Source resource type
            if (sourceResourceId.Length <= DataMovementConstants.JobPartPlanFile.ResourceIdMaxStrLength)
            {
                SourceResourceId = sourceResourceId;
                SourceResourceIdLength = (ushort) sourceResourceId.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(sourceResourceId),
                    expectedSize: DataMovementConstants.JobPartPlanFile.ResourceIdMaxStrLength,
                    actualSize: sourceResourceId.Length);
            }
            // SourcePath
            if (sourcePath.Length <= DataMovementConstants.JobPartPlanFile.PathStrMaxLength)
            {
                SourcePath = sourcePath;
                SourcePathLength = (ushort) sourcePath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(SourcePath),
                    expectedSize: DataMovementConstants.JobPartPlanFile.PathStrMaxLength,
                    actualSize: sourcePath.Length);
            }
            // SourceQuery
            if (sourceExtraQuery.Length <= DataMovementConstants.JobPartPlanFile.ExtraQueryMaxLength)
            {
                SourceExtraQuery = sourceExtraQuery;
                SourceExtraQueryLength = (ushort) sourceExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(SourceExtraQuery),
                    expectedSize: DataMovementConstants.JobPartPlanFile.ExtraQueryMaxLength,
                    actualSize: sourceExtraQuery.Length);
            }
            // Destination resource type
            if (destinationResourceId.Length <= DataMovementConstants.JobPartPlanFile.ResourceIdMaxStrLength)
            {
                DestinationResourceId = destinationResourceId;
                DestinationResourceIdLength = (ushort)destinationResourceId.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(destinationResourceId),
                    expectedSize: DataMovementConstants.JobPartPlanFile.ResourceIdMaxStrLength,
                    actualSize: destinationResourceId.Length);
            }
            // DestinationPath
            if (destinationPath.Length <= DataMovementConstants.JobPartPlanFile.PathStrMaxLength)
            {
                DestinationPath = destinationPath;
                DestinationPathLength = (ushort) destinationPath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(DestinationPath),
                    expectedSize: DataMovementConstants.JobPartPlanFile.PathStrMaxLength,
                    actualSize: destinationPath.Length);
            }
            // DestinationQuery
            if (destinationExtraQuery.Length <= DataMovementConstants.JobPartPlanFile.ExtraQueryMaxLength)
            {
                DestinationExtraQuery = destinationExtraQuery;
                DestinationExtraQueryLength = (ushort) destinationExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileElement(
                    elementName: nameof(DestinationExtraQuery),
                    expectedSize: DataMovementConstants.JobPartPlanFile.ExtraQueryMaxLength,
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
            WriteString(writer, Version, DataMovementConstants.JobPartPlanFile.VersionStrNumBytes);

            // StartTime
            writer.Write(StartTime.Ticks);

            // TransferId
            WriteString(writer, TransferId, DataMovementConstants.JobPartPlanFile.TransferIdStrNumBytes);

            // PartNumber
            writer.Write(PartNumber);

            // SourceResourceIdLength
            writer.Write(SourceResourceIdLength);

            // SourceResourceId
            WriteString(writer, SourceResourceId, DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes);

            // SourcePathLength
            writer.Write(SourcePathLength);

            // SourcePath
            WriteString(writer, SourcePath, DataMovementConstants.JobPartPlanFile.PathStrNumBytes);

            // SourceExtraQueryLength
            writer.Write(SourceExtraQueryLength);

            // SourceExtraQuery
            WriteString(writer, SourceExtraQuery, DataMovementConstants.JobPartPlanFile.ExtraQueryNumBytes);

            // DestinationResourceIdLength
            writer.Write(DestinationResourceIdLength);

            // DestinationResourceId
            WriteString(writer, DestinationResourceId, DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes);

            // DestinationPathLength
            writer.Write(DestinationPathLength);

            // DestinationPath
            WriteString(writer, DestinationPath, DataMovementConstants.JobPartPlanFile.PathStrNumBytes);

            // DestinationExtraQueryLength
            writer.Write(DestinationExtraQueryLength);

            // DestinationExtraQuery
            WriteString(writer, DestinationExtraQuery, DataMovementConstants.JobPartPlanFile.ExtraQueryNumBytes);

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
            WriteString(writer, DstBlobData.ContentType, DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);

            // DstBlobData.ContentEncodingLength
            writer.Write(DstBlobData.ContentEncodingLength);

            // DstBlobData.ContentEncoding
            WriteString(writer, DstBlobData.ContentEncoding, DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);

            // DstBlobData.ContentLanguageLength
            writer.Write(DstBlobData.ContentLanguageLength);

            // DstBlobData.ContentLanguage
            WriteString(writer, DstBlobData.ContentLanguage, DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);

            // DstBlobData.ContentDispositionLength
            writer.Write(DstBlobData.ContentDispositionLength);

            // DstBlobData.ContentDisposition
            WriteString(writer, DstBlobData.ContentDisposition, DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);

            // DstBlobData.CacheControlLength
            writer.Write(DstBlobData.CacheControlLength);

            // DstBlobData.CacheControl
            WriteString(writer, DstBlobData.CacheControl, DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);

            // DstBlobData.BlockBlobTier
            writer.Write((byte)DstBlobData.BlockBlobTier);

            // DstBlobData.PageBlobTier
            writer.Write((byte)DstBlobData.PageBlobTier);

            // DstBlobData.PutMd5
            writer.Write(Convert.ToByte(DstBlobData.PutMd5));

            // DstBlobData.MetadataLength
            writer.Write(DstBlobData.MetadataLength);

            // DstBlobData.Metadata
            WriteString(writer, DstBlobData.Metadata, DataMovementConstants.JobPartPlanFile.MetadataStrNumBytes);

            // DstBlobData.BlobTagsLength
            writer.Write(DstBlobData.BlobTagsLength);

            // DstBlobData.BlobTags
            WriteString(writer, DstBlobData.BlobTags, DataMovementConstants.JobPartPlanFile.BlobTagsStrNumBytes);

            // DstBlobData.IsSourceEncrypted
            writer.Write(DstBlobData.IsSourceEncrypted);

            // DstBlobData.CpkScopeInfoLength
            writer.Write(DstBlobData.CpkScopeInfoLength);

            // DstBlobData.CpkScopeInfo
            WriteString(writer, DstBlobData.CpkScopeInfo, DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);

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
            byte[] versionBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.VersionStrNumBytes);
            string version = versionBuffer.ToString(DataMovementConstants.JobPartPlanFile.VersionStrLength);

            // Assert the schema version before continuing
            CheckSchemaVersion(version);

            // Start Time
            byte[] startTimeBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
            DateTimeOffset startTime = new DateTimeOffset(startTimeBuffer.ToLong(), new TimeSpan(0, 0, 0));

            // Transfer Id
            byte[] transferIdBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.TransferIdStrNumBytes);
            string transferId = transferIdBuffer.ToString(DataMovementConstants.JobPartPlanFile.TransferIdStrLength);

            // Job Part Number
            byte[] partNumberBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
            long partNumber = partNumberBuffer.ToLong();

            // SourceResourceIdLength
            byte[] sourceResourceIdLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort sourceResourceIdLength = sourceResourceIdLengthBuffer.ToUShort();

            // SourceResourceId
            byte[] sourceResourceIdBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes);
            string sourceResourceId = sourceResourceIdBuffer.ToString(sourceResourceIdLength);

            // SourcePathLength
            byte[] sourcePathLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort sourcePathLength = sourcePathLengthBuffer.ToUShort();

            // SourcePath
            byte[] sourcePathBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.PathStrNumBytes);
            string sourcePath = sourcePathBuffer.ToString(sourcePathLength);

            // SourceExtraQueryLength
            byte[] sourceExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort sourceExtraQueryLength = sourceExtraQueryLengthBuffer.ToUShort();

            // SourceExtraQuery
            byte[] sourceExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.ExtraQueryNumBytes);
            string sourceExtraQuery = sourceExtraQueryBuffer.ToString(sourceExtraQueryLength);

            // DestinationResourceIdLength
            byte[] destinationResourceIdLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort destinationResourceIdLength = destinationResourceIdLengthBuffer.ToUShort();

            // DestinationResourceId
            byte[] destinationResourceIdBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes);
            string destinationResourceId = destinationResourceIdBuffer.ToString(destinationResourceIdLength);

            // DestinationPathLength
            byte[] destinationPathLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort destinationPathLength = destinationPathLengthBuffer.ToUShort();

            // DestinationPath
            byte[] destinationPathBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.PathStrNumBytes);
            string destinationPath = destinationPathBuffer.ToString(destinationPathLength);

            // DestinationExtraQueryLength
            byte[] destinationExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort destinationExtraQueryLength = destinationExtraQueryLengthBuffer.ToUShort();

            // DestinationExtraQuery
            byte[] destinationExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.ExtraQueryNumBytes);
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
            byte[] ttlAfterCompletionBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
            DateTimeOffset ttlAfterCompletion = new DateTimeOffset(ttlAfterCompletionBuffer.ToLong(), new TimeSpan(0, 0, 0));

            // JobPlanOperation
            byte fromToByte = reader.ReadByte();
            JobPlanOperation fromTo = (JobPlanOperation)fromToByte;

            // FolderPropertyOption
            byte folderPropertyOptionByte = reader.ReadByte();
            FolderPropertiesMode folderPropertyMode = (FolderPropertiesMode)folderPropertyOptionByte;

            // NumberChunks
            byte[] numberChunksBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
            long numberChunks = numberChunksBuffer.ToLong();

            // DstBlobData.BlobType
            byte blobTypeByte = reader.ReadByte();
            JobPlanBlobType blobType = (JobPlanBlobType)blobTypeByte;

            // DstBlobData.NoGuessMimeType
            byte noGuessMimeTypeByte = reader.ReadByte();
            bool noGuessMimeType = Convert.ToBoolean(noGuessMimeTypeByte);

            // DstBlobData.ContentTypeLength
            byte[] contentTypeLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort contentTypeLength = contentTypeLengthBuffer.ToUShort();

            // DstBlobData.ContentType
            byte[] contentTypeBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);
            string contentType = contentTypeBuffer.ToString(contentTypeLength);

            // DstBlobData.ContentEncodingLength
            byte[] contentEncodingLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort contentEncodingLength = contentEncodingLengthBuffer.ToUShort();

            // DstBlobData.ContentEncoding
            byte[] contentEncodingBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);
            string contentEncoding = contentEncodingBuffer.ToString(contentEncodingLength);

            // DstBlobData.ContentLanguageLength
            byte[] contentLanguageLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort contentLanguageLength = contentLanguageLengthBuffer.ToUShort();

            // DstBlobData.ContentLanguage
            byte[] contentLanguageBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);
            string contentLanguage = contentLanguageBuffer.ToString(contentLanguageLength);

            // DstBlobData.ContentDispositionLength
            byte[] contentDispositionLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort contentDispositionLength = contentDispositionLengthBuffer.ToUShort();

            // DstBlobData.ContentDisposition
            byte[] contentDispositionBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);
            string contentDisposition = contentDispositionBuffer.ToString(contentDispositionLength);

            // DstBlobData.CacheControlLength
            byte[] cacheControlLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort cacheControlLength = cacheControlLengthBuffer.ToUShort();

            // DstBlobData.CacheControl
            byte[] cacheControlBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);
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
            byte[] metadataLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort metadataLength = metadataLengthBuffer.ToUShort();

            // DstBlobData.Metadata
            byte[] metadataBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.MetadataStrNumBytes);
            string metadata = metadataBuffer.ToString(metadataLength);

            // DstBlobData.BlobTagsLength
            byte[] blobTagsLengthBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
            long blobTagsLength = blobTagsLengthBuffer.ToLong();

            // DstBlobData.BlobTags
            byte[] blobTagsBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.BlobTagsStrNumBytes);
            string blobTags = blobTagsBuffer.ToString(blobTagsLength);

            // DstBlobData.IsSourceEncrypted
            bool isSourceEncrypted = Convert.ToBoolean(reader.ReadByte());

            // DstBlobData.CpkScopeInfoLength
            byte[] cpkScopeInfoLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
            ushort cpkScopeInfoLength = cpkScopeInfoLengthBuffer.ToUShort();

            // DstBlobData.CpkScopeInfo
            byte[] cpkScopeInfoBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes);
            string cpkScopeInfo = cpkScopeInfoBuffer.ToString(cpkScopeInfoLength);

            // DstBlobData.BlockSize
            byte[] blockSizeLengthBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
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
            DataTransferStatus atomicJobStatus = (DataTransferStatus)atomicJobStatusByte;

            // AtomicPartStatus
            byte atomicPartStatusByte = reader.ReadByte();
            DataTransferStatus atomicPartStatus = (DataTransferStatus)atomicPartStatusByte;

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
                sourceResourceId: sourceResourceId,
                sourcePath: sourcePath,
                sourceExtraQuery: sourceExtraQuery,
                destinationResourceId: destinationResourceId,
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

        private static void CheckSchemaVersion(string version)
        {
            if (version != DataMovementConstants.JobPartPlanFile.SchemaVersion)
            {
                throw Errors.UnsupportedSchemaVersionHeader(version);
            }
        }
    }
}

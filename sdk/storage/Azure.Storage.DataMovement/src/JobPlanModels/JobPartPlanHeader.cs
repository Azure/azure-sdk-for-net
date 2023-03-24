// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core;

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
        public FolderPropertiesMode FolderPropertyMode;

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
            WriteString(writer, Version, DataMovementConstants.PlanFile.VersionStrMaxSize);

            // StartTime
            writer.Write(StartTime.Ticks);

            // TransferId
            WriteString(writer, TransferId, DataMovementConstants.PlanFile.TransferIdStrMaxSize);

            // PartNumber
            writer.Write(PartNumber);

            // SourcePathLength
            writer.Write(SourcePathLength);

            // SourcePath
            WriteString(writer, SourcePath, DataMovementConstants.PlanFile.PathStrMaxSize);

            // SourceExtraQueryLength
            writer.Write(SourceExtraQueryLength);

            // SourceExtraQuery
            WriteString(writer, SourceExtraQuery, DataMovementConstants.PlanFile.ExtraQueryMaxSize);

            // DestinationPathLength
            writer.Write(DestinationPathLength);

            // DestinationPath
            WriteString(writer, DestinationPath, DataMovementConstants.PlanFile.PathStrMaxSize);

            // DestinationExtraQueryLength
            writer.Write(DestinationExtraQueryLength);

            // DestinationExtraQuery
            WriteString(writer, DestinationExtraQuery, DataMovementConstants.PlanFile.ExtraQueryMaxSize);

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
            writer.Write((byte)FromTo);

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
            WriteString(writer, DstBlobData.ContentType, DataMovementConstants.PlanFile.HeaderValueMaxSize);

            // DstBlobData.ContentEncodingLength
            writer.Write(DstBlobData.ContentEncodingLength);

            // DstBlobData.ContentEncoding
            WriteString(writer, DstBlobData.ContentEncoding, DataMovementConstants.PlanFile.HeaderValueMaxSize);

            // DstBlobData.ContentLanguageLength
            writer.Write(DstBlobData.ContentLanguageLength);

            // DstBlobData.ContentLanguage
            WriteString(writer, DstBlobData.ContentLanguage, DataMovementConstants.PlanFile.HeaderValueMaxSize);

            // DstBlobData.ContentDispositionLength
            writer.Write(DstBlobData.ContentDispositionLength);

            // DstBlobData.ContentDisposition
            WriteString(writer, DstBlobData.ContentDisposition, DataMovementConstants.PlanFile.HeaderValueMaxSize);

            // DstBlobData.CacheControlLength
            writer.Write(DstBlobData.CacheControlLength);

            // DstBlobData.CacheControl
            WriteString(writer, DstBlobData.CacheControl, DataMovementConstants.PlanFile.HeaderValueMaxSize);

            // DstBlobData.BlockBlobTier
            writer.Write((byte)DstBlobData.BlockBlobTier);

            // DstBlobData.PageBlobTier
            writer.Write((byte)DstBlobData.PageBlobTier);

            // DstBlobData.PutMd5
            writer.Write(Convert.ToByte(DstBlobData.PutMd5));

            // DstBlobData.MetadataLength
            writer.Write(DstBlobData.MetadataLength);

            // DstBlobData.Metadata
            WriteString(writer, DstBlobData.Metadata, DataMovementConstants.PlanFile.MetadataStrMaxSize);

            // DstBlobData.BlobTagsLength
            writer.Write(DstBlobData.BlobTagsLength);

            // DstBlobData.BlobTags
            WriteString(writer, DstBlobData.BlobTags, DataMovementConstants.PlanFile.BlobTagsStrMaxSize);

            // DstBlobData.CpkInfoLength
            writer.Write(DstBlobData.CpkInfoLength);

            // DstBlobData.CpkInfo
            WriteString(writer, DstBlobData.CpkInfo, DataMovementConstants.PlanFile.HeaderValueMaxSize);

            // DstBlobData.IsSourceEncrypted
            writer.Write(DstBlobData.IsSourceEncrypted);

            // DstBlobData.CpkScopeInfoLength
            writer.Write(DstBlobData.CpkScopeInfoLength);

            // DstBlobData.CpkScopeInfo
            WriteString(writer, DstBlobData.CpkScopeInfo, DataMovementConstants.PlanFile.HeaderValueMaxSize);

            // DstBlobData.BlockSize
            writer.Write(DstBlobData.BlockSize);

            // DstLocalData.PreserveLastModifiedTime
            writer.Write(Convert.ToByte(DstLocalData.PreserveLastModifiedTime));

            // DstLocalData.MD5VerificationOption
            writer.Write(DstLocalData.MD5VerificationOption);

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
            byte[] versionBuffer = new byte[DataMovementConstants.PlanFile.VersionStrMaxSize];
            versionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.VersionStrMaxSize);
            string version = versionBuffer.ByteArrayToString(DataMovementConstants.PlanFile.VersionStrMaxSize);

            // Start Time
            byte[] startTimeBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            startTimeBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            DateTimeOffset startTime = new DateTimeOffset(startTimeBuffer.ByteArrayToLong(), new TimeSpan(0, 0, 0));

            // Transfer Id
            byte[] transferIdBuffer = new byte[DataMovementConstants.PlanFile.TransferIdStrMaxSize];
            transferIdBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.TransferIdStrMaxSize);
            string transferId = transferIdBuffer.ByteArrayToString(DataMovementConstants.PlanFile.TransferIdStrMaxSize);

            // Job Part Number
            byte[] partNumberBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            partNumberBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long partNumber = partNumberBuffer.ByteArrayToLong();

            // SourcePathLength
            byte[] sourcePathLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            sourcePathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long sourcePathLength = sourcePathLengthBuffer.ByteArrayToLong();

            // SourcePath
            byte[] sourcePathBuffer = new byte[DataMovementConstants.PlanFile.PathStrMaxSize];
            sourcePathBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.PathStrMaxSize);
            string sourcePath = sourcePathBuffer.ByteArrayToString(sourcePathLength);

            // SourceExtraQueryLength
            byte[] sourceExtraQueryLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            sourceExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long sourceExtraQueryLength = sourceExtraQueryLengthBuffer.ByteArrayToLong();

            // SourceExtraQuery
            byte[] sourceExtraQueryBuffer = new byte[DataMovementConstants.PlanFile.ExtraQueryMaxSize];
            sourceExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.ExtraQueryMaxSize);
            string sourceExtraQuery = sourceExtraQueryBuffer.ByteArrayToString(sourceExtraQueryLength);

            // DestinationPathLength
            byte[] destinationPathLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            destinationPathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long destinationPathLength = destinationPathLengthBuffer.ByteArrayToLong();

            // DestinationPath
            byte[] destinationPathBuffer = new byte[DataMovementConstants.PlanFile.PathStrMaxSize];
            destinationPathBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.PathStrMaxSize);
            string destinationPath = destinationPathBuffer.ByteArrayToString(destinationPathLength);

            // DestinationExtraQueryLength
            byte[] destinationExtraQueryLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            destinationExtraQueryLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long destinationExtraQueryLength = destinationExtraQueryLengthBuffer.ByteArrayToLong();

            // DestinationExtraQuery
            byte[] destinationExtraQueryBuffer = new byte[DataMovementConstants.PlanFile.ExtraQueryMaxSize];
            destinationExtraQueryBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.ExtraQueryMaxSize);
            string destinationExtraQuery = destinationExtraQueryBuffer.ByteArrayToString(destinationExtraQueryLength);

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
            byte[] ttlAfterCompletionBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            ttlAfterCompletionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            DateTimeOffset ttlAfterCompletion = new DateTimeOffset(ttlAfterCompletionBuffer.ByteArrayToLong(), new TimeSpan(0, 0, 0));

            // FromTo
            byte fromToByte = reader.ReadByte();
            JobPlanFromTo fromTo = (JobPlanFromTo)fromToByte;

            // FolderPropertyOption
            byte folderPropertyOptionByte = reader.ReadByte();
            FolderPropertiesMode folderPropertyMode = (FolderPropertiesMode)folderPropertyOptionByte;

            // NumberChunks
            byte[] numberChunksBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            numberChunksBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long numberChunks = numberChunksBuffer.ByteArrayToLong();

            // DstBlobData.BlobType
            byte blobTypeByte = reader.ReadByte();
            JobPlanBlobType blobType = (JobPlanBlobType)blobTypeByte;

            // DstBlobData.NoGuessMimeType
            byte noGuessMimeTypeByte = reader.ReadByte();
            bool noGuessMimeType = Convert.ToBoolean(noGuessMimeTypeByte);

            // DstBlobData.ContentTypeLength
            byte[] contentTypeLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            contentTypeLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long contentTypeLength = contentTypeLengthBuffer.ByteArrayToLong();

            // DstBlobData.ContentType
            byte[] contentTypeBuffer = new byte[DataMovementConstants.PlanFile.HeaderValueMaxSize];
            contentTypeBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueMaxSize);
            string contentType = contentTypeBuffer.ByteArrayToString(contentTypeLength);

            // DstBlobData.ContentEncodingLength
            byte[] contentEncodingLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            contentEncodingLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long contentEncodingLength = contentEncodingLengthBuffer.ByteArrayToLong();

            // DstBlobData.ContentEncoding
            byte[] contentEncodingBuffer = new byte[DataMovementConstants.PlanFile.HeaderValueMaxSize];
            contentEncodingBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueMaxSize);
            string contentEncoding = contentEncodingBuffer.ByteArrayToString(contentEncodingLength);

            // DstBlobData.ContentLanguageLength
            byte[] contentLanguageLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            contentLanguageLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long contentLanguageLength = contentLanguageLengthBuffer.ByteArrayToLong();

            // DstBlobData.ContentLanguage
            byte[] contentLanguageBuffer = new byte[DataMovementConstants.PlanFile.HeaderValueMaxSize];
            contentLanguageBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueMaxSize);
            string contentLanguage = contentLanguageBuffer.ByteArrayToString(contentLanguageLength);

            // DstBlobData.ContentDispositionLength
            byte[] contentDispositionLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            contentDispositionLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long contentDispositionLength = contentDispositionLengthBuffer.ByteArrayToLong();

            // DstBlobData.ContentDisposition
            byte[] contentDispositionBuffer = new byte[DataMovementConstants.PlanFile.HeaderValueMaxSize];
            contentDispositionBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueMaxSize);
            string contentDisposition = contentDispositionBuffer.ByteArrayToString(contentDispositionLength);

            // DstBlobData.CacheControlLength
            byte[] cacheControlLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            cacheControlLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long cacheControlLength = cacheControlLengthBuffer.ByteArrayToLong();

            // DstBlobData.CacheControl
            byte[] cacheControlBuffer = new byte[DataMovementConstants.PlanFile.HeaderValueMaxSize];
            cacheControlBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueMaxSize);
            string cacheControl = cacheControlBuffer.ByteArrayToString(cacheControlLength);

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
            byte[] metadataLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            metadataLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long metadataLength = metadataLengthBuffer.ByteArrayToLong();

            // DstBlobData.Metadata
            byte[] metadataBuffer = new byte[DataMovementConstants.PlanFile.MetadataStrMaxSize];
            metadataBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.MetadataStrMaxSize);
            string metadata = metadataBuffer.ByteArrayToString(metadataLength);

            // DstBlobData.BlobTagsLength
            byte[] blobTagsLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            blobTagsLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long blobTagsLength = blobTagsLengthBuffer.ByteArrayToLong();

            // DstBlobData.BlobTags
            byte[] blobTagsBuffer = new byte[DataMovementConstants.PlanFile.BlobTagsStrMaxSize];
            blobTagsBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.BlobTagsStrMaxSize);
            string blobTags = blobTagsBuffer.ByteArrayToString(blobTagsLength);

            // DstBlobData.CpkInfoLength
            byte[] cpkInfoLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            cpkInfoLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long cpkInfoLength = cpkInfoLengthBuffer.ByteArrayToLong();

            // DstBlobData.CpkInfo
            byte[] cpkInfoBuffer = new byte[DataMovementConstants.PlanFile.HeaderValueMaxSize];
            cpkInfoBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueMaxSize);
            string cpkInfo = cpkInfoBuffer.ByteArrayToString(cpkInfoLength);

            // DstBlobData.IsSourceEncrypted
            bool isSourceEncrypted = Convert.ToBoolean(reader.ReadByte());

            // DstBlobData.CpkScopeInfoLength
            byte[] cpkScopeInfoLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            cpkScopeInfoLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long cpkScopeInfoLength = cpkScopeInfoLengthBuffer.ByteArrayToLong();

            // DstBlobData.CpkScopeInfo
            byte[] cpkScopeInfoBuffer = new byte[DataMovementConstants.PlanFile.HeaderValueMaxSize];
            cpkScopeInfoBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.HeaderValueMaxSize);
            string cpkScopeInfo = cpkScopeInfoBuffer.ByteArrayToString(cpkScopeInfoLength);

            // DstBlobData.BlockSize
            byte[] blockSizeLengthBuffer = new byte[DataMovementConstants.PlanFile.LongSizeInBytes];
            blockSizeLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.LongSizeInBytes);
            long blockSize = blockSizeLengthBuffer.ByteArrayToLong();

            // DstLocalData.PreserveLastModifiedTime
            bool preserveLastModifiedTime = Convert.ToBoolean(reader.ReadByte());

            // DstBlobData.MD5VerificationOption
            byte md5VerificationOption = reader.ReadByte();

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
                cpkInfo: cpkInfo,
                isSourceEncrypted: isSourceEncrypted,
                cpkScopeInfo: cpkScopeInfo,
                blockSize: blockSize);

            JobPartPlanDestinationLocal dstLocalData = new JobPartPlanDestinationLocal(
                preserveLastModifiedTime: preserveLastModifiedTime,
                md5VerificationOption: md5VerificationOption);

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
                fromTo: fromTo,
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

            int padding =  setSizeInBytes - value.Length;
            if (padding > 0)
            {
                char[] paddingArray = new char[padding];
                writer.Write(paddingArray);
            }
        }
    }
}

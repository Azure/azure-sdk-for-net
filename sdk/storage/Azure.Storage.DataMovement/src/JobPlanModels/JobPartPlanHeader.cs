// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            long ttlAfterCompletion,
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
            if (Version.Length == DataMovementConstants.PlanFile.VersionStrMaxSize)
            {
                Version = version;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(Version),
                    expectedSize: DataMovementConstants.PlanFile.VersionStrMaxSize,
                    actualSize: Version.Length);
            }
            StartTime = startTime;
            // TransferId String size verification
            if (TransferId.Length == DataMovementConstants.PlanFile.TransferIdStrMaxSize)
            {
                TransferId = transferId;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(TransferId),
                    expectedSize: DataMovementConstants.PlanFile.TransferIdStrMaxSize,
                    actualSize: TransferId.Length);
            }
            PartNumber = partNumber;
            SourcePath = sourcePath;
            // TransferId String size verification
            if (SourcePath.Length < DataMovementConstants.PlanFile.PathStrMaxSize)
            {
                SourcePath = sourcePath;
                SourcePathLength = sourcePath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(SourcePath),
                    expectedSize: DataMovementConstants.PlanFile.PathStrMaxSize,
                    actualSize: SourcePath.Length);
            }
            // SourcePath
            if (SourceExtraQuery.Length == DataMovementConstants.PlanFile.ExtraQueryMaxSize)
            {
                SourceExtraQuery = sourceExtraQuery;
                SourceExtraQueryLength = sourceExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(SourceExtraQuery),
                    expectedSize: DataMovementConstants.PlanFile.ExtraQueryMaxSize,
                    actualSize: SourceExtraQuery.Length);
            }
            // DestinationPath
            if (DestinationPath.Length == DataMovementConstants.PlanFile.PathStrMaxSize)
            {
                DestinationPath = destinationPath;
                DestinationPathLength = destinationPath.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(DestinationPath),
                    expectedSize: DataMovementConstants.PlanFile.PathStrMaxSize,
                    actualSize: DestinationPath.Length);
            }
            if (DestinationExtraQuery.Length == DataMovementConstants.PlanFile.ExtraQueryMaxSize)
            {
                DestinationExtraQuery = destinationExtraQuery;
                DestinationExtraQueryLength = destinationExtraQuery.Length;
            }
            else
            {
                throw Errors.InvalidPlanFileJson(
                    elementName: nameof(DestinationExtraQuery),
                    expectedSize: DataMovementConstants.PlanFile.ExtraQueryMaxSize,
                    actualSize: DestinationExtraQuery.Length);
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
                    buffer: Version.ToByteArray(),
                    index: DataMovementConstants.PlanFile.VersionIndex,
                    count: DataMovementConstants.PlanFile.VersionMaxSizeInBytes);

                // StartTime
                writer.Write(
                    buffer: StartTime.Ticks.ToByteArray(),
                    index: DataMovementConstants.PlanFile.StartTimeIndex,
                    count: DataMovementConstants.PlanFile.LongSizeInBytes);

                writer.Write(
                    buffer: TransferId.ToByteArray(),
                    index: DataMovementConstants.PlanFile.TransferIdIndex,
                    count: DataMovementConstants.PlanFile.TransferIdMaxSizeInBytes);

                writer.Write(PartNumber);

                writer.Write(SourcePath);

                writer.Write(SourceExtraQuery);

                writer.Write(DestinationPath);

                writer.Write(DestinationExtraQuery);

                writer.Write(IsFinalPart);

                writer.Write(ForceWrite);

                writer.Write(ForceIfReadOnly);

                writer.Write(AutoDecompress);

                writer.Write(Priority);

                writer.Write(TTLAfterCompletion);

                writer.Write(FromTo);

                writer.Write(FolderPropertyOption);

                writer.Write(NumberChunks);

                writer.Write(DstBlobData);

                writer.Write(DstLocalData);

                writer.Write(PreserveSMBPermissions);

                writer.Write(PreserveSMBInfo);

                writer.Write(S2SGetPropertiesInBackend);

                writer.Write(S2SInvalidMetadataHandleOption);

                writer.Write(DestLengthValidation);

                writer.Write(DeleteSnapshotsOption);

                writer.Write(PermanentDeleteOption);

                writer.Write(RehydratePriorityType);

                writer.Write(AtomicJobStatus);

                writer.Write(AtomicPartStatus);
                */

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

            /*
            using writerDocument doc = async ? await writerDocument.ParseAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false) : writerDocument.Parse(stream);

            foreach (writerProperty prop in doc.RootElement.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case currentVersion:
                        header.Version = prop.Value.GetString();
                        break;
                    case startTimeName:
                        if (prop.Value.TryGetInt64(out long value))
                        {
                            header.StartTime = value;
                        }
                        else
                        {
                            throw Errors.InvalidPlanFilewriter(nameof(StartTime));
                        }
                        break;
                    case transferIdName:
                        header.TransferId = BuildAccountIdFromString(prop.Value.GetString());
                        break;
                    case partNumberName:
                        if (prop.Value.TryGetInt64(out long value))
                        {
                            header.PartNumber = value;
                        }
                        else
                        {
                            throw Errors.InvalidPlanFilewriter(nameof(PartNumber));
                        }
                        break;
                    case ClientIdPropertyName:
                        header.ClientId = prop.Value.GetString();
                        break;
                    case VersionPropertyName:
                        header.Version = prop.Value.GetString();
                        if (header.Version != CurrentVersion)
                        {
                            throw new InvalidOperationException($"Attempted to deserialize an {nameof(AuthenticationRecord)} with a version that is not the current version. Expected: '{CurrentVersion}', Actual: '{header.Version}'");
                        }
                        break;
                }
            }
            */

            return header;
        }
    }
}

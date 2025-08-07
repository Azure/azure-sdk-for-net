// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.JobPlan
{
    internal class JobPartPlanHeader
    {
        /// <summary>
        /// The schema version.
        /// </summary>
        public int Version;

        /// <summary>
        /// The Transfer/Job Id.
        /// </summary>
        public string TransferId;

        /// <summary>
        /// Job Part's part number (0+).
        /// </summary>
        public long PartNumber;

        /// <summary>
        /// The creation time of the job part.
        /// </summary>
        public DateTimeOffset CreateTime;

        /// <summary>
        /// A string identifier for the source resource.
        /// </summary>
        public string SourceTypeId;

        /// <summary>
        /// A string identifier for the destination resource.
        /// </summary>
        public string DestinationTypeId;

        /// <summary>
        /// The source path.
        /// </summary>
        public string SourcePath;

        /// <summary>
        /// The destination path.
        /// </summary>
        public string DestinationPath;

        /// <summary>
        /// The resource creation preference.
        /// </summary>
        public StorageResourceCreationMode CreatePreference;

        /// <summary>
        /// Ths initial transfer size for the transfer.
        /// </summary>
        public long InitialTransferSize;

        /// <summary>
        /// The chunk size to use for the transfer.
        /// </summary>
        public long ChunkSize;

        /// <summary>
        /// The job part priority (future use).
        /// </summary>
        public byte Priority;

        /// <summary>
        /// The current status of the job part.
        /// </summary>
        public TransferStatus JobPartStatus;

        public JobPartPlanHeader(
            int version,
            string transferId,
            long partNumber,
            DateTimeOffset createTime,
            string sourceTypeId,
            string destinationTypeId,
            string sourcePath,
            string destinationPath,
            StorageResourceCreationMode createPreference,
            long initialTransferSize,
            long chunkSize,
            byte priority,
            TransferStatus jobPartStatus)
        {
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNull(createTime, nameof(createTime));
            Argument.AssertNotNullOrEmpty(sourceTypeId, nameof(sourceTypeId));
            Argument.AssertNotNullOrWhiteSpace(destinationTypeId, nameof(destinationTypeId));
            Argument.AssertNotNullOrEmpty(sourcePath, nameof(sourcePath));
            Argument.AssertNotNullOrWhiteSpace(destinationPath, nameof(destinationPath));
            Argument.AssertNotNull(jobPartStatus, nameof(jobPartStatus));

            if (!Guid.TryParse(transferId, out Guid _))
            {
                throw Errors.InvalidPartHeaderElement(nameof(transferId), transferId);
            }
            if (sourceTypeId.Length > DataMovementConstants.JobPartPlanFile.TypeIdMaxStrLength)
            {
                throw Errors.InvalidPartHeaderElementLength(
                    elementName: nameof(sourceTypeId),
                    expectedSize: DataMovementConstants.JobPartPlanFile.TypeIdMaxStrLength,
                    actualSize: sourceTypeId.Length);
            }
            if (destinationTypeId.Length > DataMovementConstants.JobPartPlanFile.TypeIdMaxStrLength)
            {
                throw Errors.InvalidPartHeaderElementLength(
                    elementName: nameof(destinationTypeId),
                    expectedSize: DataMovementConstants.JobPartPlanFile.TypeIdMaxStrLength,
                    actualSize: destinationTypeId.Length);
            }

            Version = version;
            TransferId = transferId;
            PartNumber = partNumber;
            CreateTime = createTime;
            SourceTypeId = sourceTypeId;
            DestinationTypeId = destinationTypeId;
            SourcePath = sourcePath;
            DestinationPath = destinationPath;
            CreatePreference = createPreference;
            InitialTransferSize = initialTransferSize;
            ChunkSize = chunkSize;
            Priority = priority;
            JobPartStatus = jobPartStatus;
        }

        public void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            BinaryWriter writer = new BinaryWriter(stream);
            int currentVariableLengthIndex = DataMovementConstants.JobPartPlanFile.VariableLengthStartIndex;

            // Version
            writer.Write(Version);

            // TransferId (write as bytes)
            Guid transferId = Guid.Parse(TransferId);
            writer.Write(transferId.ToByteArray());

            // PartNumber
            writer.Write(PartNumber);

            // CreateTime
            writer.Write(CreateTime.Ticks);

            // SourceTypeId
            writer.WritePaddedString(SourceTypeId, DataMovementConstants.JobPartPlanFile.TypeIdNumBytes);

            // DestinationTypeId
            writer.WritePaddedString(DestinationTypeId, DataMovementConstants.JobPartPlanFile.TypeIdNumBytes);

            // SourcePath offset/length
            byte[] sourcePathBytes = Encoding.UTF8.GetBytes(SourcePath);
            writer.WriteVariableLengthFieldInfo(sourcePathBytes.Length, ref currentVariableLengthIndex);

            // DestinationPath offset/length
            byte[] destinationPathBytes = Encoding.UTF8.GetBytes(DestinationPath);
            writer.WriteVariableLengthFieldInfo(destinationPathBytes.Length, ref currentVariableLengthIndex);

            // CreatePreference
            writer.Write((byte)CreatePreference);

            // InitialTransferSize
            writer.Write(InitialTransferSize);

            // ChunkSize
            writer.Write(ChunkSize);

            // Priority
            writer.Write(Priority);

            // JobPartStatus
            writer.Write((int)JobPartStatus.ToJobPlanStatus());

            // SourcePath
            writer.Write(sourcePathBytes);

            // DestinationPath
            writer.Write(destinationPathBytes);
        }

        public static JobPartPlanHeader Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            BinaryReader reader = new BinaryReader(stream);
            reader.BaseStream.Position = 0;

            // Version
            int version = reader.ReadInt32();
            if (version != DataMovementConstants.JobPartPlanFile.SchemaVersion)
            {
                throw Errors.UnsupportedJobPartSchemaVersionHeader(version);
            }

            // TransferId
            byte[] transferIdBuffer = reader.ReadBytes(DataMovementConstants.GuidSizeInBytes);
            string transferId = new Guid(transferIdBuffer).ToString();

            // PartNumber
            byte[] partNumberBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
            long partNumber = partNumberBuffer.ToLong();

            // CreateTime
            long createTimeTicks = reader.ReadInt64();
            DateTimeOffset createTime = new DateTimeOffset(createTimeTicks, new TimeSpan(0, 0, 0));

            // SourceTypeId
            string sourceTypeId = reader.ReadPaddedString(DataMovementConstants.JobPartPlanFile.TypeIdNumBytes);

            // DestinationTypeId
            string destinationTypeId = reader.ReadPaddedString(DataMovementConstants.JobPartPlanFile.TypeIdNumBytes);

            // SourcePath offset/length
            int sourcePathOffset = reader.ReadInt32();
            int sourcePathLength = reader.ReadInt32();

            // DestinationPath offset/length
            int destinationPathOffset = reader.ReadInt32();
            int destinationPathLength = reader.ReadInt32();

            // CreatePreference
            StorageResourceCreationMode createPreference = (StorageResourceCreationMode)reader.ReadByte();

            // InitialTransferSize
            long initialTransferSize = reader.ReadInt64();

            // ChunkSize
            long chunkSize = reader.ReadInt64();

            // Priority
            byte priority = reader.ReadByte();

            // JobPartStatus
            JobPlanStatus jobPlanStatus = (JobPlanStatus)reader.ReadInt32();
            TransferStatus jobPartStatus = jobPlanStatus.ToTransferStatus();

            // SourcePath
            string sourcePath = null;
            if (sourcePathOffset > 0)
            {
                reader.BaseStream.Position = sourcePathOffset;
                byte[] parentSourcePathBytes = reader.ReadBytes(sourcePathLength);
                sourcePath = parentSourcePathBytes.ToString(sourcePathLength);
            }

            // DestinationPath
            string destinationPath = null;
            if (destinationPathOffset > 0)
            {
                reader.BaseStream.Position = destinationPathOffset;
                byte[] parentSourcePathBytes = reader.ReadBytes(destinationPathLength);
                destinationPath = parentSourcePathBytes.ToString(destinationPathLength);
            }

            return new JobPartPlanHeader(
                version,
                transferId,
                partNumber,
                createTime,
                sourceTypeId,
                destinationTypeId,
                sourcePath,
                destinationPath,
                createPreference,
                initialTransferSize,
                chunkSize,
                priority,
                jobPartStatus);
        }

        /// <summary>
        /// Internal equals for testing.
        /// </summary>
        internal bool Equals(JobPartPlanHeader other)
        {
            if (other is null)
            {
                return false;
            }

            return
                (Version == other.Version) &&
                (TransferId == other.TransferId) &&
                (PartNumber == other.PartNumber) &&
                (CreateTime == other.CreateTime) &&
                (SourceTypeId == other.SourceTypeId) &&
                (DestinationTypeId == other.DestinationTypeId) &&
                (SourcePath == other.SourcePath) &&
                (DestinationPath == other.DestinationPath) &&
                (CreatePreference == other.CreatePreference) &&
                (InitialTransferSize == other.InitialTransferSize) &&
                (ChunkSize == other.ChunkSize) &&
                (Priority == other.Priority) &&
                (JobPartStatus == other.JobPartStatus);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.JobPlan
{
    internal class JobPlanHeader
    {
        /// <summary>
        /// Version for the job plan schema.
        /// </summary>
        public string Version;

        /// <summary>
        /// The transfer id.
        /// </summary>
        public string TransferId;

        /// <summary>
        /// The time the job was created.
        /// </summary>
        public DateTimeOffset CreateTime;

        /// <summary>
        /// The type of operation this job is performing.
        /// </summary>
        public JobPlanOperation OperationType;

        /// <summary>
        /// A string ID of the source resource provider to use for rehydration.
        /// </summary>
        public string SourceProviderId;

        /// <summary>
        /// A string ID of the destination resource provider to use for rehydration.
        /// </summary>
        public string DestinationProviderId;

        /// <summary>
        /// Whether the transfer is of a container or not.
        /// </summary>
        public bool IsContainer;

        /// <summary>
        /// Whether or not the enumeration of the parent container has completed.
        /// </summary>
        public bool EnumerationComplete;

        /// <summary>
        /// The current status of the transfer job.
        /// </summary>
        public DataTransferStatus JobStatus;

        /// <summary>
        /// The parent path for the source of the transfer.
        /// </summary>
        public string ParentSourcePath;

        /// <summary>
        /// The parent path for the destination of the transfer.
        /// </summary>
        public string ParentDestinationPath;

        /// <summary>
        /// Additional checkpoint data specific to the source resource.
        /// Only populated when using <see cref="Deserialize(Stream)"/>.
        /// </summary>
        public byte[] SourceCheckpointData;

        /// <summary>
        /// Additional checkpoint data specific to the destination resource.
        /// Only populated when using <see cref="Deserialize(Stream)"/>.
        /// </summary>
        public byte[] DestinationCheckpointData;

        private StorageResourceCheckpointData _sourceCheckpointData;
        private StorageResourceCheckpointData _destinationCheckpointData;

        public JobPlanHeader(
            string version,
            string transferId,
            DateTimeOffset createTime,
            JobPlanOperation operationType,
            string sourceProviderId,
            string destinationProviderId,
            bool isContainer,
            bool enumerationComplete,
            DataTransferStatus jobStatus,
            string parentSourcePath,
            string parentDestinationPath,
            StorageResourceCheckpointData sourceCheckpointData,
            StorageResourceCheckpointData destinationCheckpointData)
        {
            Argument.AssertNotNull(version, nameof(version));
            Argument.AssertNotNullOrEmpty(transferId, nameof(transferId));
            Argument.AssertNotNullOrEmpty(sourceProviderId, nameof(sourceProviderId));
            Argument.AssertNotNullOrEmpty(destinationProviderId, nameof(destinationProviderId));
            Argument.AssertNotNull(jobStatus, nameof(jobStatus));
            Argument.AssertNotNull(createTime, nameof(createTime));
            Argument.AssertNotNullOrEmpty(parentSourcePath, nameof(parentSourcePath));
            Argument.AssertNotNullOrEmpty(parentDestinationPath, nameof(parentDestinationPath));
            Argument.AssertNotNull(sourceCheckpointData, nameof(sourceCheckpointData));
            Argument.AssertNotNull(destinationCheckpointData, nameof(destinationCheckpointData));

            if (sourceProviderId.Length > DataMovementConstants.JobPlanFile.ProviderIdMaxLength)
            {
                throw new ArgumentException("The provided sourceProviderId is too long.");
            }
            if (destinationProviderId.Length > DataMovementConstants.JobPlanFile.ProviderIdMaxLength)
            {
                throw new ArgumentException("The provided destinationProviderId is too long.");
            }

            Version = version;
            TransferId = transferId;
            CreateTime = createTime;
            OperationType = operationType;
            SourceProviderId = sourceProviderId;
            DestinationProviderId = destinationProviderId;
            IsContainer = isContainer;
            EnumerationComplete = enumerationComplete;
            JobStatus = jobStatus;
            ParentSourcePath = parentSourcePath;
            ParentDestinationPath = parentDestinationPath;

            _sourceCheckpointData = sourceCheckpointData;
            _destinationCheckpointData = destinationCheckpointData;
        }

        private JobPlanHeader(
            string version,
            string transferId,
            DateTimeOffset createTime,
            JobPlanOperation operationType,
            string sourceProviderId,
            string destinationProviderId,
            bool isContainer,
            bool enumerationComplete,
            DataTransferStatus jobStatus,
            string parentSourcePath,
            string parentDestinationPath,
            byte[] sourceCheckpointData,
            byte[] destinationCheckpointData)
        {
            Version = version;
            TransferId = transferId;
            CreateTime = createTime;
            OperationType = operationType;
            SourceProviderId = sourceProviderId;
            DestinationProviderId = destinationProviderId;
            IsContainer = isContainer;
            EnumerationComplete = enumerationComplete;
            JobStatus = jobStatus;
            ParentSourcePath = parentSourcePath;
            ParentDestinationPath = parentDestinationPath;
            SourceCheckpointData = sourceCheckpointData;
            DestinationCheckpointData = destinationCheckpointData;
        }

        public void Serialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            int currentVariableLengthIndex = DataMovementConstants.JobPlanFile.VariableLengthStartIndex;
            BinaryWriter writer = new BinaryWriter(stream);

            // Version
            writer.WritePaddedString(Version, DataMovementConstants.JobPlanFile.VersionStrNumBytes);

            // TransferId (write as bytes)
            Guid transferId = Guid.Parse(TransferId);
            writer.Write(transferId.ToByteArray());

            // CreateTime
            writer.Write(CreateTime.Ticks);

            // OperationType
            writer.Write((byte)OperationType);

            // SourceProviderId
            writer.WritePaddedString(SourceProviderId, DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // DestinationProviderId
            writer.WritePaddedString(DestinationProviderId, DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // IsContainer
            writer.Write(Convert.ToByte(IsContainer));

            // EnumerationComplete
            writer.Write(Convert.ToByte(EnumerationComplete));

            // JobStatus
            writer.Write((int)JobStatus.ToJobPlanStatus());

            // ParentSourcePath offset/length
            byte[] parentSourcePathBytes = Encoding.UTF8.GetBytes(ParentSourcePath);
            writer.WriteVariableLengthFieldInfo(parentSourcePathBytes.Length, ref currentVariableLengthIndex);

            // ParentDestinationPath offset/length
            byte[] parentDestinationPathBytes = Encoding.UTF8.GetBytes(ParentDestinationPath);
            writer.WriteVariableLengthFieldInfo(parentDestinationPathBytes.Length, ref currentVariableLengthIndex);

            // SourceCheckpointData offset/length
            writer.WriteVariableLengthFieldInfo(_sourceCheckpointData.Length, ref currentVariableLengthIndex);

            // DestinationCheckpointData offset/length
            writer.WriteVariableLengthFieldInfo(_destinationCheckpointData.Length, ref currentVariableLengthIndex);

            // ParentSourcePath
            writer.Write(parentSourcePathBytes);

            // ParentDestinationPath
            writer.Write(parentDestinationPathBytes);

            _sourceCheckpointData.Serialize(stream);
            _destinationCheckpointData.Serialize(stream);
        }

        public static JobPlanHeader Deserialize(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            BinaryReader reader = new BinaryReader(stream);
            reader.BaseStream.Position = 0;

            // Version
            byte[] versionBuffer = reader.ReadBytes(DataMovementConstants.JobPlanFile.VersionStrNumBytes);
            string version = versionBuffer.ToString(DataMovementConstants.JobPlanFile.VersionStrLength);

            // Assert the schema version before continuing
            CheckSchemaVersion(version);

            // TransferId
            byte[] transferIdBuffer = reader.ReadBytes(DataMovementConstants.GuidSizeInBytes);
            string transferId = new Guid(transferIdBuffer).ToString();

            // CreateTime
            long createTimeTicks = reader.ReadInt64();
            DateTimeOffset createTime = new DateTimeOffset(createTimeTicks, new TimeSpan(0, 0, 0));

            // OperationType
            byte operationTypeByte = reader.ReadByte();
            JobPlanOperation operationType = (JobPlanOperation)operationTypeByte;

            // SourceProviderId
            string sourceProviderId = reader.ReadPaddedString(DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // DestinationProviderId
            string destProviderId = reader.ReadPaddedString(DataMovementConstants.JobPlanFile.ProviderIdNumBytes);

            // IsContainer
            byte isContainerByte = reader.ReadByte();
            bool isContainer = Convert.ToBoolean(isContainerByte);

            // EnumerationComplete
            byte enumerationCompleteByte = reader.ReadByte();
            bool enumerationComplete = Convert.ToBoolean(enumerationCompleteByte);

            // JobStatus
            JobPlanStatus jobPlanStatus = (JobPlanStatus)reader.ReadInt32();

            // ParentSourcePath offset/length
            int parentSourcePathOffset = reader.ReadInt32();
            int parentSourcePathLength = reader.ReadInt32();

            // ParentDestinationPath offset/length
            int parentDestinationPathOffset = reader.ReadInt32();
            int parentDestinationPathLength = reader.ReadInt32();

            // SourceCheckpointData offset/length
            int sourceCheckpointDataOffset = reader.ReadInt32();
            int sourceCheckpointDataLength = reader.ReadInt32();

            // DestinationCheckpointData offset/length
            int destinationCheckpointDataOffset = reader.ReadInt32();
            int destinationCheckpointDataLength = reader.ReadInt32();

            // ParentSourcePath
            string parentSourcePath = null;
            if (parentSourcePathOffset > 0)
            {
                reader.BaseStream.Position = parentSourcePathOffset;
                byte[] parentSourcePathBytes = reader.ReadBytes(parentSourcePathLength);
                parentSourcePath = parentSourcePathBytes.ToString(parentSourcePathLength);
            }

            // ParentDestinationPath
            string parentDestinationPath = null;
            if (parentDestinationPathOffset > 0)
            {
                reader.BaseStream.Position = parentDestinationPathOffset;
                byte[] parentDestinationPathBytes = reader.ReadBytes(parentDestinationPathLength);
                parentDestinationPath = parentDestinationPathBytes.ToString(parentDestinationPathLength);
            }

            // SourceCheckpointData
            byte[] sourceCheckpointData = Array.Empty<byte>();
            if (sourceCheckpointDataOffset > 0)
            {
                reader.BaseStream.Position = sourceCheckpointDataOffset;
                sourceCheckpointData = reader.ReadBytes(sourceCheckpointDataLength);
            }

            // DestinationCheckpointData
            byte[] destinationCheckpointData = Array.Empty<byte>();
            if (destinationCheckpointDataOffset > 0)
            {
                reader.BaseStream.Position = destinationCheckpointDataOffset;
                destinationCheckpointData = reader.ReadBytes(destinationCheckpointDataLength);
            }

            return new JobPlanHeader(
                version,
                transferId,
                createTime,
                operationType,
                sourceProviderId,
                destProviderId,
                isContainer,
                enumerationComplete,
                jobPlanStatus.ToDataTransferStatus(),
                parentSourcePath,
                parentDestinationPath,
                sourceCheckpointData,
                destinationCheckpointData);
        }

        private static void CheckSchemaVersion(string version)
        {
            if (version != DataMovementConstants.JobPlanFile.SchemaVersion)
            {
                throw Errors.UnsupportedJobSchemaVersionHeader(version);
            }
        }
    }
}

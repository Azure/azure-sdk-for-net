// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal static partial class JobPlanExtensions
    {
        public static string ToString(this byte[] bytes, long length)
        {
            return Encoding.UTF8.GetString(bytes, 0, (int)length);
        }

        public static long ToLong(this byte[] bytes)
        {
            return BitConverter.ToInt64(bytes, 0);
        }

        public static ushort ToUShort(this byte[] bytes)
        {
            return BitConverter.ToUInt16(bytes, 0);
        }

        internal static JobPartPlanHeader GetJobPartPlanHeader(this JobPartPlanFileName fileName)
        {
            JobPartPlanHeader result;
            int bufferSize = DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes;

            using MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateFromFile(fileName.ToString());
            using (MemoryMappedViewStream stream = memoryMappedFile.CreateViewStream(0, bufferSize, MemoryMappedFileAccess.Read))
            {
                if (!stream.CanRead)
                {
                    throw Errors.CannotReadMmfStream(fileName.ToString());
                }
                result = JobPartPlanHeader.Deserialize(stream);
            }
            return result;
        }

        internal static async Task<(string Source, string Destination)> GetResourceIdsAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            int startIndex = DataMovementConstants.JobPartPlanFile.SourceResourceIdLengthIndex;
            int readLength = DataMovementConstants.JobPartPlanFile.DestinationPathLengthIndex - startIndex;

            string sourceResourceId;
            string destinationResourceId;
            using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                length: readLength,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Source Length
                byte[] sourceLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
                ushort sourceLength = sourceLengthBuffer.ToUShort();

                // Read Source
                byte[] sourceBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes);
                sourceResourceId = sourceBuffer.ToString(sourceLength);

                // Set the stream position to the start of the destination resource id
                reader.BaseStream.Position = DataMovementConstants.JobPartPlanFile.DestinationResourceIdLengthIndex - startIndex;

                // Read Destination Length
                byte[] destLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
                ushort destLength = destLengthBuffer.ToUShort();

                // Read Destination
                byte[] destBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes);
                destinationResourceId = destBuffer.ToString(destLength);
            }

            return (sourceResourceId, destinationResourceId);
        }

        internal static IDictionary<string, string> ToDictionary(this string str, string elementName)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] splitSemiColon = str.Split(';');
            foreach (string value in splitSemiColon)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] splitEqual = value.Split('=');
                    if (splitEqual.Length != 2)
                    {
                        throw Errors.InvalidStringToDictionary(elementName, str);
                    }
                    dictionary.Add(splitEqual[0], splitEqual[1]);
                }
            }
            return dictionary;
        }

        internal static string DictionaryToString(this IDictionary<string, string> dict)
        {
            string concatStr = "";
            foreach (KeyValuePair<string, string> kv in dict)
            {
                // e.g. store like "header=value;"
                concatStr = string.Concat(concatStr, $"{kv.Key}={kv.Value};");
            }
            return concatStr;
        }

        internal static async Task<string> GetHeaderUShortValue(
            this TransferCheckpointer checkpointer,
            string transferId,
            int startIndex,
            int streamReadLength,
            int valueLength,
            CancellationToken cancellationToken)
        {
            string value;
            using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                length: streamReadLength,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Path Length
                byte[] pathLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
                ushort pathLength = pathLengthBuffer.ToUShort();

                // Read Path
                byte[] pathBuffer = reader.ReadBytes(valueLength);
                value = pathBuffer.ToString(pathLength);
            }
            return value;
        }

        internal static async Task<string> GetHeaderLongValue(
            this TransferCheckpointer checkpointer,
            string transferId,
            int startIndex,
            int streamReadLength,
            int valueLength,
            CancellationToken cancellationToken)
        {
            string value;
            using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                length: streamReadLength,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Path Length
                byte[] pathLengthBuffer = reader.ReadBytes(DataMovementConstants.LongSizeInBytes);
                long pathLength = pathLengthBuffer.ToLong();

                // Read Path
                byte[] pathBuffer = reader.ReadBytes(valueLength);
                value = pathBuffer.ToString(pathLength);
            }
            return value;
        }

        internal static async Task<byte> GetByteValue(
            this TransferCheckpointer checkpointer,
            string transferId,
            int startIndex,
            CancellationToken cancellationToken)
        {
            byte value;
            using (Stream stream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                length: DataMovementConstants.OneByte,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Byte
                value = reader.ReadByte();
            }
            return value;
        }

        internal static JobPlanStatus ToJobPlanStatus(this DataTransferStatus transferStatus)
        {
            if (transferStatus == default)
            {
                return JobPlanStatus.None;
            }

            JobPlanStatus jobPlanStatus = (JobPlanStatus)Enum.Parse(typeof(JobPlanStatus), transferStatus.State.ToString());
            if (transferStatus.HasFailedItems)
            {
                jobPlanStatus |= JobPlanStatus.HasFailed;
            }
            if (transferStatus.HasSkippedItems)
            {
                jobPlanStatus |= JobPlanStatus.HasSkipped;
            }

            return jobPlanStatus;
        }

        internal static DataTransferStatus ToDataTransferStatus(this JobPlanStatus jobPlanStatus)
        {
            DataTransferState state;
            if (jobPlanStatus.HasFlag(JobPlanStatus.Queued))
            {
                state = DataTransferState.Queued;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.InProgress))
            {
                state = DataTransferState.InProgress;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Pausing))
            {
                state = DataTransferState.Pausing;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Stopping))
            {
                state = DataTransferState.Stopping;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Paused))
            {
                state = DataTransferState.Paused;
            }
            else if (jobPlanStatus.HasFlag(JobPlanStatus.Completed))
            {
                state = DataTransferState.Completed;
            }
            else
            {
                state = DataTransferState.None;
            }

            bool hasFailed = jobPlanStatus.HasFlag(JobPlanStatus.HasFailed);
            bool hasSkipped = jobPlanStatus.HasFlag(JobPlanStatus.HasSkipped);

            return new DataTransferStatusInternal(state, hasFailed, hasSkipped);
        }

        /// <summary>
        /// Writes the given length and offset and increments currentOffset accordingly.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="length">The length of the variable length field.</param>
        /// <param name="currentOffset">
        /// A reference to the current offset of the variable length fields
        /// that will be used to set the offset and then incremented.
        /// </param>
        internal static void WriteVariableLengthFieldInfo(
            BinaryWriter writer,
            int length,
            ref int currentOffset)
        {
            // Write the offset, -1 if size is 0
            if (length > 0)
            {
                writer.Write(currentOffset);
                currentOffset += length;
            }
            else
            {
                writer.Write(-1);
            }

            // Write the length
            writer.Write(length);
        }

        internal static string ToSanitizedString(this Uri uri)
        {
            UriBuilder builder = new(uri);

            // Remove any query parameters (including SAS)
            builder.Query = string.Empty;
            return builder.Uri.AbsoluteUri;
        }
    }
}

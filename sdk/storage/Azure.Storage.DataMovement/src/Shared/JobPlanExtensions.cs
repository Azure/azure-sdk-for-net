// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models.JobPlan;

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
            int bufferSize = DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes;

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

        /// <summary>
        /// Rehydrates from Checkpointer.
        /// </summary>
        /// <param name="checkpointer">
        /// The checkpointer where the transfer state was saved to.
        /// </param>
        /// <param name="transferId">
        /// Transfer Id where we want to rehydrate the resource from the job from.
        /// </param>
        /// /// <param name="isSource">
        /// Whether or not we are rehydrating the source or destination. True if the source, false if the destination.
        /// </param>
        /// <param name="cancellationToken">
        /// Whether or not to cancel the operation.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> to rehdyrate a <see cref="LocalFileStorageResource"/> from
        /// a stored checkpointed transfer state.
        /// </returns>
        internal static async Task<string> GetResourcePathAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken)
        {
            int startPathIndex = isSource ?
                DataMovementConstants.PlanFile.SourcePathLengthIndex :
                DataMovementConstants.PlanFile.DestinationPathLengthIndex;
            int readLength = isSource ?
                (DataMovementConstants.PlanFile.SourceExtraQueryLengthIndex - startPathIndex) :
                (DataMovementConstants.PlanFile.DestinationExtraQueryLengthIndex - startPathIndex);

            int partCount = await checkpointer.CurrentJobPartCountAsync(transferId).ConfigureAwait(false);
            string storedPath = default;
            for (int i = 0; i < partCount; i++)
            {
                using (Stream stream = await checkpointer.ReadableStreamAsync(
                    transferId: transferId,
                    partNumber: i,
                    offset: startPathIndex,
                    readSize: readLength,
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    BinaryReader reader = new BinaryReader(stream);

                    // Read Path Length
                    byte[] pathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
                    ushort pathLength = pathLengthBuffer.ToUShort();

                    // Read Path
                    byte[] pathBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.PathStrNumBytes);
                    string path = pathBuffer.ToString(pathLength);

                    if (string.IsNullOrEmpty(storedPath))
                    {
                        // If we currently don't have a path
                        storedPath = path;
                    }
                    else
                    {
                        // if there's already an existing path, let's compare the two paths
                        // and find the common parent path.
                        int length = Math.Min(storedPath.Length, path.Length);
                        int index = 0;

                        while (index < length && storedPath[index] == path[index])
                        {
                            index++;
                        }

                        storedPath = storedPath.Substring(0, index);
                    }
                }
            }
            return storedPath.TrimEnd('\\', '/');
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

        internal static async Task<string> GetHeaderValue(
            this TransferCheckpointer checkpointer,
            string transferId,
            int startIndex,
            int streamReadLength,
            int valueLength,
            CancellationToken cancellationToken)
        {
            string value;
            using (Stream stream = await checkpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                readSize: streamReadLength,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Path Length
                byte[] pathLengthBuffer = reader.ReadBytes(DataMovementConstants.PlanFile.UShortSizeInBytes);
                ushort pathLength = pathLengthBuffer.ToUShort();

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
            using (Stream stream = await checkpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                readSize: DataMovementConstants.PlanFile.OneByte,
                cancellationToken: cancellationToken).ConfigureAwait(false))
            {
                BinaryReader reader = new BinaryReader(stream);

                // Read Byte
                value = reader.ReadByte();
            }
            return value;
        }
    }
}

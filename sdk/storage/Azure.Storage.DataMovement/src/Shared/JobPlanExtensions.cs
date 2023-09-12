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

        internal static async Task<(string Source, string Destination)> GetResourcePathsAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            CancellationToken cancellationToken)
        {
            int startIndex = DataMovementConstants.JobPartPlanFile.SourcePathLengthIndex;
            int readLength = DataMovementConstants.JobPartPlanFile.DestinationExtraQueryLengthIndex - startIndex;

            int partCount = await checkpointer.CurrentJobPartCountAsync(transferId).ConfigureAwait(false);
            string storedSourcePath = default;
            string storedDestPath = default;
            for (int i = 0; i < partCount; i++)
            {
                using (Stream stream = await checkpointer.ReadableStreamAsync(
                    transferId: transferId,
                    partNumber: i,
                    offset: startIndex,
                    readSize: readLength,
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    BinaryReader reader = new BinaryReader(stream);

                    // Read Source Path Length
                    byte[] pathLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
                    ushort pathLength = pathLengthBuffer.ToUShort();

                    // Read Source Path
                    byte[] pathBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.PathStrNumBytes);
                    string sourcePath = pathBuffer.ToString(pathLength);

                    // Set the stream position to the start of the destination path
                    reader.BaseStream.Position = DataMovementConstants.JobPartPlanFile.DestinationPathLengthIndex - startIndex;

                    // Read Destination Path Length
                    pathLengthBuffer = reader.ReadBytes(DataMovementConstants.UShortSizeInBytes);
                    pathLength = pathLengthBuffer.ToUShort();

                    // Read Destination Path
                    pathBuffer = reader.ReadBytes(DataMovementConstants.JobPartPlanFile.PathStrNumBytes);
                    string destPath = pathBuffer.ToString(pathLength);

                    if (string.IsNullOrEmpty(storedSourcePath))
                    {
                        // If we currently don't have a path
                        storedSourcePath = sourcePath;
                        storedDestPath = destPath;
                    }
                    else
                    {
                        // If there's already an existing path, let's compare the two paths
                        // and find the common parent path.
                        storedSourcePath = GetLongestCommonString(storedSourcePath, sourcePath);
                        storedDestPath = GetLongestCommonString(storedDestPath, destPath);
                    }
                }
            }

            if (partCount == 1)
            {
                return (storedSourcePath, storedDestPath);
            }
            else
            {
                // The resulting stored paths are just longest common string, trim to last / to get a path
                return (TrimStringToPath(storedSourcePath), TrimStringToPath(storedDestPath));
            }
        }

        private static string GetLongestCommonString(string path1, string path2)
        {
            int length = Math.Min(path1.Length, path2.Length);
            int index = 0;

            while (index < length && path1[index] == path2[index])
            {
                index++;
            }

            return path1.Substring(0, index);
        }

        private static string TrimStringToPath(string path)
        {
            int lastSlash = path.Replace('\\', '/').LastIndexOf('/');
            return path.Substring(0, lastSlash);
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
            using (Stream stream = await checkpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                readSize: readLength,
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
            using (Stream stream = await checkpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                readSize: streamReadLength,
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
            using (Stream stream = await checkpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                readSize: streamReadLength,
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
            using (Stream stream = await checkpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: 0,
                offset: startIndex,
                readSize: DataMovementConstants.OneByte,
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices.ComTypes;
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
        internal static async Task<string> GetPathFromCheckpointer(
            this TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken)
        {
            int pathIndex = isSource ?
                DataMovementConstants.PlanFile.SourcePathIndex :
                DataMovementConstants.PlanFile.DestinationPathIndex;
            int pathLength = isSource ?
                (DataMovementConstants.PlanFile.SourcePathLengthIndex - DataMovementConstants.PlanFile.SourcePathIndex) :
                (DataMovementConstants.PlanFile.DestinationPathLengthIndex - DataMovementConstants.PlanFile.DestinationPathIndex);

            int partCount = await checkpointer.CurrentJobPartCountAsync(transferId).ConfigureAwait(false);
            string storedPath = default;
            for (int i = 0; i < partCount; i++)
            {
                using (Stream stream = await checkpointer.ReadableStreamAsync(
                    transferId: transferId,
                    partNumber: i,
                    offset: pathIndex,
                    readSize: pathLength,
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (string.IsNullOrEmpty(storedPath))
                    {
                        storedPath = stream.ToString();
                    }
                    else
                    {
                        string currentPath = stream.ToString();
                        int length = Math.Min(storedPath.Length, currentPath.Length);
                        int index = 0;

                        while (index < length && storedPath[index] == currentPath[index])
                        {
                            index++;
                        }

                        storedPath = storedPath.Substring(0, index);
                    }
                }
            }
            return storedPath;
        }
    }
}

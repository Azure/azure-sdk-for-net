// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
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
    }
}

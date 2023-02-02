// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal class JobPlanExtensions
    {
        public static void CheckInputWithHeader(
            StorageResource source,
            StorageResource destination,
            JobPartPlanHeader header)
        {
            string schemaVersion = Encoding.UTF8.GetString(header.Version);
            if (!DataMovementConstants.PlanFile.SchemaVersion.Equals(schemaVersion))
            {
                throw Errors.MismatchSchemaVersion(schemaVersion);
            }

            string sourcePathHeader = Encoding.UTF8.GetString(header.SourceRoot) + Encoding.UTF8.GetString(header.SourceExtraQuery);
            if (!sourcePathHeader.Equals(source.Path))
            {
                throw Errors.MismatchStorageResource(nameof(source), source.Path, sourcePathHeader);
            }
            string destinationPathHeader = Encoding.UTF8.GetString(header.DestinationRoot) + Encoding.UTF8.GetString(header.DestExtraQuery);
            if (!destinationPathHeader.Equals(destination.Path))
            {
                throw Errors.MismatchStorageResource(nameof(destination), destination.Path, destinationPathHeader);
            }
        }

        public static Stream StreamToJobPlanPartHeader(JobPartPlanHeader header)
        {
            // Convert the header to a struct
            int structSize = Marshal.SizeOf(typeof(JobPartPlanHeader));
            byte[] buffer = new byte[structSize];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(header, handle.AddrOfPinnedObject(), false);
            handle.Free();

            // Convert byte array to stream
            Stream result = new MemoryStream(buffer, 0, structSize);
            return result;
        }

        public static JobPartPlanHeader StreamToJobPlanPartHeader(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(JobPartPlanHeader)));

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            JobPartPlanHeader header = (JobPartPlanHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(JobPartPlanHeader));
            handle.Free();

            return header;
        }
    }
}

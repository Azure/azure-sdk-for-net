// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// This matching the JobPartPlanDstLocal of azcopy
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal class JobPartPlanDestinationLocal
    {
        private const string preserveLastModifiedTimeName = "preserveLastModifiedTime";
        private const string md5VerificationOptionName = "md5VerificationOption";

        private static readonly JsonEncodedText s_preserveLastModifiedTimeNameBytes = JsonEncodedText.Encode(preserveLastModifiedTimeName);
        private static readonly JsonEncodedText s_md5VerificationOptionNameBytes = JsonEncodedText.Encode(md5VerificationOptionName);

        // Once set, the following fields are constants; they should never be modified

        // Specifies whether the timestamp of destination file has to be set to the modified time of source file
        [MarshalAs(UnmanagedType.Bool)]
        public bool PreserveLastModifiedTime;

        // says how MD5 verification failures should be actioned
        // uint_8
        [MarshalAs(UnmanagedType.U1)]
        public byte MD5VerificationOption;
    }
}

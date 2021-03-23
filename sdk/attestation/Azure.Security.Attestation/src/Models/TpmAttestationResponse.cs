// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.Attestation.Models
{
    /// <summary>
    /// Represents a response for a TPM attestation call. See https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol  for more information.
    /// </summary>
    public partial class TpmAttestationResponse
    {
        /// <summary>
        /// Attestation Response data. See  https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol for more details
        /// </summary>
        public ReadOnlyMemory<byte> Data { get => Base64Url.Decode(InternalData); }

        [CodeGenMember("Data")]
        internal string InternalData { get; }
    }
}

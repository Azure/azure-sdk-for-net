// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a response for a TPM attestation call. See <seealso href="https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol"/>  for more information.
    /// </summary>
    [CodeGenModel("TpmAttestationResponse")]
    public partial class TpmAttestationResponse
    {
        /// <summary>
        /// Attestation Response data. See  <seealso href="https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol"/> for more details.
        /// </summary>
        public BinaryData Data { get => BinaryData.FromBytes(Base64Url.Decode(InternalData)); }

        [CodeGenMember("Data")]
        internal string InternalData { get; }
    }
}

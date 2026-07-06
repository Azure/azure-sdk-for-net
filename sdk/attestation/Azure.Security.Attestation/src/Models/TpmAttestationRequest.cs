// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents a request for a TPM attestation call. See <seealso href="https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol"/> for more information.
    /// </summary>
    [CodeGenType("TpmAttestationRequest")]
    public partial class TpmAttestationRequest
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TpmAttestationRequest"/>.
        /// </summary>
        public TpmAttestationRequest()
        {
        }

        /// <summary>
        /// Attestation Request data. See  <seealso href="https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol"/> for more details
        /// </summary>
        [CodeGenMember("Data")]
        public BinaryData Data { get; set; }
    }
}

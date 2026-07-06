// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Attestation policy stored on the MAA Service.
    /// </summary>
    [JsonConverter(typeof(StoredAttestationPolicyConverter))]
    [CodeGenType("StoredAttestationPolicy")]
    public partial class StoredAttestationPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoredAttestationPolicy"/> class.
        /// </summary>
        public StoredAttestationPolicy() : base()
        {
        }

        /// <summary>
        /// Gets or sets the attestation policy stored in the MAA.
        /// </summary>
        public string AttestationPolicy { get; set; }
    }
}

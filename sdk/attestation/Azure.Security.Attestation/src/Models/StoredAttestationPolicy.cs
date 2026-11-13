// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Attestation policy stored on the MAA Service.
    /// </summary>
    [JsonConverter(typeof(StoredAttestationPolicyConverter))]
    [CodeGenType("StoredAttestationPolicy")]
    [CodeGenSerialization(nameof(AttestationPolicy), SerializationValueHook = nameof(SerializeAttestationPolicy), DeserializationValueHook = nameof(DeserializeAttestationPolicy))]
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

        // The wire form is Base64Url (spec: bytes, base64url); the public property holds the decoded policy text.
        private void SerializeAttestationPolicy(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(Base64Url.EncodeString(AttestationPolicy));

        private static void DeserializeAttestationPolicy(JsonProperty property, ref string attestationPolicy)
            => attestationPolicy = property.Value.ValueKind == JsonValueKind.Null ? null : Base64Url.DecodeString(property.Value.GetString());
    }
}

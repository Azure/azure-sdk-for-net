// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Bridges <see cref="System.Text.Json"/> serialization to the generated
    /// <see cref="IJsonModel{T}"/> implementation.
    /// </summary>
    /// <remarks>
    /// <see cref="PolicyCertificateModification"/> is serialized into an attestation token body via
    /// <see cref="BinaryData.FromObjectAsJson{T}(T, JsonSerializerOptions)"/>, which uses
    /// <see cref="System.Text.Json"/>. The generated model implements <see cref="IJsonModel{T}"/> and exposes its
    /// only payload property as <c>internal</c>, neither of which <see cref="System.Text.Json"/> can see, so
    /// without this converter the type would silently serialize to an empty JSON object.
    /// </remarks>
    internal class PolicyCertificateModificationConverter : JsonConverter<PolicyCertificateModification>
    {
        /// <inheritdoc/>
        public override PolicyCertificateModification Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return PolicyCertificateModification.DeserializePolicyCertificateModification(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, PolicyCertificateModification value, JsonSerializerOptions options)
        {
            ((IJsonModel<PolicyCertificateModification>)value).Write(writer, ModelSerializationExtensions.WireOptions);
        }
    }
}

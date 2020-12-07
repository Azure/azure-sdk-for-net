// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    /// <inheritdoc/>
    internal class AttestationResultConverter : JsonConverter<AttestationResult>
    {
        internal AttestationResultConverter()
        {
        }

        /// <inheritdoc/>
        public override AttestationResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string serializedJson = Utilities.SerializeJsonObject(ref reader, options);

            if (typeToConvert != typeof(AttestationResult))
            {
                throw new InvalidOperationException();
            }

            using var document = JsonDocument.Parse(serializedJson);
            AttestationResult result = AttestationResult.DeserializeAttestationResult(document.RootElement);
            return result;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, AttestationResult value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

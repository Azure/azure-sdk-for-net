// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    internal sealed class PolicyCertificatesResultConverter : JsonConverter<PolicyCertificatesResult>
    {
        public override PolicyCertificatesResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string serializedReader = Utilities.SerializeJsonObject(ref reader, options);

            using var document = JsonDocument.Parse(serializedReader);
            return PolicyCertificatesResult.DeserializePolicyCertificatesResult(document.RootElement);
        }

        public override void Write(Utf8JsonWriter writer, PolicyCertificatesResult value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

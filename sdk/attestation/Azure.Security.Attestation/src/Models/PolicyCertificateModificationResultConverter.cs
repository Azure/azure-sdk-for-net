// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    internal class PolicyCertificateModificationResultConverter : JsonConverter<PolicyCertificatesModificationResult>
    {
        public override PolicyCertificatesModificationResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string serializedReader = Utilities.SerializeJsonObject(ref reader, options);

            using var document = JsonDocument.Parse(serializedReader);
            return PolicyCertificatesModificationResult.DeserializePolicyCertificatesModificationResult(document.RootElement);
        }

        public override void Write(Utf8JsonWriter writer, PolicyCertificatesModificationResult value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

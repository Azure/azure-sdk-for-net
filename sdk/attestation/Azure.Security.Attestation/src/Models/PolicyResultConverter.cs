// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    internal sealed class PolicyResultConverter : JsonConverter<PolicyResult>
    {
        public override PolicyResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string serializedReader = Utilities.SerializeJsonObject(ref reader, options);

            using var document = JsonDocument.Parse(serializedReader);
            return PolicyResult.DeserializePolicyResult(document.RootElement);
        }

        public override void Write(Utf8JsonWriter writer, PolicyResult value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

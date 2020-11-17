// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    internal class PolicyResultConverter : JsonConverter<PolicyResult>
    {
        public override PolicyResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, PolicyResult value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

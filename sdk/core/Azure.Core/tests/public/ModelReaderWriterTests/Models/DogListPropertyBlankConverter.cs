// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests.Models
{
    public class DogListPropertyBlankConverter : JsonConverter<DogListProperty>
    {
        public override DogListProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var model = JsonDocument.ParseValue(ref reader);
            return new DogListProperty();
        }

        public override void Write(Utf8JsonWriter writer, DogListProperty value, JsonSerializerOptions options)
        {
            return;
        }
    }
}

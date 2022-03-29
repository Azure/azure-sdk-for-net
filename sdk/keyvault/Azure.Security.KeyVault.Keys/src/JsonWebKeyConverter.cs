// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Converts a <see cref="JsonWebKey"/> to or from JSON.
    /// </summary>
    internal sealed class JsonWebKeyConverter : JsonConverter<JsonWebKey>
    {
        /// <inheritdoc/>
        public override JsonWebKey Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);

            JsonWebKey value = new();
            value.ReadProperties(doc.RootElement);

            return value;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, JsonWebKey value, JsonSerializerOptions options)
        {
            Argument.AssertNotNull(writer, nameof(writer));
            Argument.AssertNotNull(value, nameof(value));

            writer.WriteStartObject();
            value.WriteProperties(writer, withId: true);
            writer.WriteEndObject();
        }
    }
}

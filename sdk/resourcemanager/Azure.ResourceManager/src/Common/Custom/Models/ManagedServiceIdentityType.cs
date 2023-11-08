// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager.Models
{
    /// <summary> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </summary>
    [JsonConverter(typeof(ManagedServiceIdentityTypeConverter))]
    public readonly partial struct ManagedServiceIdentityType : IEquatable<ManagedServiceIdentityType>
    {
        internal partial class ManagedServiceIdentityTypeConverter : JsonConverter<ManagedServiceIdentityType>
        {
            public override void Write(Utf8JsonWriter writer, ManagedServiceIdentityType model, JsonSerializerOptions options)
            {
                writer.WriteStringValue(model.ToString());
            }
            public override ManagedServiceIdentityType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return new ManagedServiceIdentityType(document.RootElement.GetString());
            }
        }
    }
}

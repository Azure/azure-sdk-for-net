// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager.Models
{
    /// <summary> JsonConverter for managed service identity type v3. </summary>
    internal class ManagedServiceIdentityTypeV3Converter : JsonConverter<ManagedServiceIdentityType>
    {
        internal const string SystemAssignedUserAssignedV3Value = "SystemAssigned,UserAssigned";

        /// <summary> Serialize managed service identity type to v3 format. </summary>
        /// <param name="writer"> The writer. </param>
        /// <param name="model"> The ManagedServiceIdentityType model which is v4. </param>
        /// <param name="options"> The options for JsonSerializer. </param>
        public override void Write(Utf8JsonWriter writer, ManagedServiceIdentityType model, JsonSerializerOptions options)
        {
            if (model == ManagedServiceIdentityType.SystemAssignedUserAssigned)
            {
                writer.WriteStringValue(SystemAssignedUserAssignedV3Value);
            }
            else
            {
                writer.WriteStringValue(model.ToString());
            }
        }

        /// <summary> Deserialize managed service identity type from v3 format. </summary>
        /// <param name="reader"> The reader. </param>
        /// <param name="typeToConvert"> The type to convert </param>
        /// <param name="options"> The options for JsonSerializer. </param>
        public override ManagedServiceIdentityType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var typeValue = document.RootElement.GetString();
            if (typeValue.Equals(SystemAssignedUserAssignedV3Value, StringComparison.OrdinalIgnoreCase))
            {
                return ManagedServiceIdentityType.SystemAssignedUserAssigned;
            }
            return new ManagedServiceIdentityType(typeValue);
        }
    }
}

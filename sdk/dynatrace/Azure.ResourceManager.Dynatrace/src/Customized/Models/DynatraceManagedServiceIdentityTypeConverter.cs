// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace.Models
{
    /// <summary> JsonConverter for dynatrace managed service identity type. </summary>
    internal class DynatraceManagedServiceIdentityTypeConverter : JsonConverter<ManagedServiceIdentityType>
    {
        internal const string DynatraceSystemAssignedUserAssignedValue = "SystemAndUserAssigned";

        /// <summary> Serialize managed service identity type to dynatrace format. </summary>
        /// <param name="writer"> The writer. </param>
        /// <param name="model"> The ManagedServiceIdentityType model which is v4. </param>
        /// <param name="options"> The options for JsonSerializer. </param>
        public override void Write(Utf8JsonWriter writer, ManagedServiceIdentityType model, JsonSerializerOptions options)
        {
            writer.WritePropertyName("type");
            if (model == ManagedServiceIdentityType.SystemAssignedUserAssigned)
            {
                writer.WriteStringValue(DynatraceSystemAssignedUserAssignedValue);
            }
            else
            {
                writer.WriteStringValue(model.ToString());
            }
        }

        /// <summary> Deserialize managed service identity type from dynatrace format. </summary>
        /// <param name="reader"> The reader. </param>
        /// <param name="typeToConvert"> The type to convert </param>
        /// <param name="options"> The options for JsonSerializer. </param>
        public override ManagedServiceIdentityType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            foreach (var property in document.RootElement.EnumerateObject())
            {
                var typeValue = property.Value.GetString();
                if (typeValue.Equals(DynatraceSystemAssignedUserAssignedValue, StringComparison.OrdinalIgnoreCase))
                {
                    return ManagedServiceIdentityType.SystemAssignedUserAssigned;
                }
                return new ManagedServiceIdentityType(typeValue);
            }
            return null;
        }
    }
}

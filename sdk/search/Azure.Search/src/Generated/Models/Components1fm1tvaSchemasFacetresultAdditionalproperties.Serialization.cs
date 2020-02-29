// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Models
{
    public partial class Components1fm1tvaSchemasFacetresultAdditionalproperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        internal static Components1fm1tvaSchemasFacetresultAdditionalproperties DeserializeComponents1fm1tvaSchemasFacetresultAdditionalproperties(JsonElement element)
        {
            Components1fm1tvaSchemasFacetresultAdditionalproperties result = new Components1fm1tvaSchemasFacetresultAdditionalproperties();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SelfHelp.Models
{
    [CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
    public partial class SelfHelpSolutionMetadata : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(SolutionId))
            {
                writer.WritePropertyName("solutionId"u8);
                writer.WriteStringValue(SolutionId);
            }
            if (Optional.IsDefined(SolutionType))
            {
                writer.WritePropertyName("solutionType"u8);
                writer.WriteStringValue(SolutionType);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsCollectionDefined(RequiredParameterSets))
            {
                writer.WritePropertyName("requiredParameterSets"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredParameterSets)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStartArray();
                    foreach (var item0 in item)
                    {
                        writer.WriteStringValue(item0);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Solutions))
            {
                writer.WritePropertyName("solutions"u8);
                writer.WriteStartArray();
                foreach (var item in Solutions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static SelfHelpSolutionMetadata DeserializeSelfHelpSolutionMetadata(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<string> solutionId = default;
            Optional<string> solutionType = default;
            Optional<string> description = default;
            Optional<IList<IList<string>>> requiredParameterSets = default;
            Optional<IList<SolutionMetadataProperties>> solutions = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("solutionId"u8))
                        {
                            solutionId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("solutionType"u8))
                        {
                            solutionType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("description"u8))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("requiredParameterSets"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<IList<string>> array = new List<IList<string>>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    array.Add(null);
                                }
                                else
                                {
                                    List<string> array0 = new List<string>();
                                    foreach (var item0 in item.EnumerateArray())
                                    {
                                        array0.Add(item0.GetString());
                                    }
                                    array.Add(array0);
                                }
                            }
                            requiredParameterSets = array;
                            continue;
                        }
                        if (property0.NameEquals("solutions"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<SolutionMetadataProperties> array = new List<SolutionMetadataProperties>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(SolutionMetadataProperties.DeserializeSolutionMetadataProperties(item));
                            }
                            solutions = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new SelfHelpSolutionMetadata(id, name, type, systemData.Value, solutionId.Value, solutionType.Value, description.Value, Optional.ToList(requiredParameterSets),  Optional.ToList(solutions));
        }
    }
}

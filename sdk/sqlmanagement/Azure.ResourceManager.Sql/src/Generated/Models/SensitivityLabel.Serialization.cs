// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class SensitivityLabel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(LabelName))
            {
                writer.WritePropertyName("labelName");
                writer.WriteStringValue(LabelName);
            }
            if (Optional.IsDefined(LabelId))
            {
                writer.WritePropertyName("labelId");
                writer.WriteStringValue(LabelId);
            }
            if (Optional.IsDefined(InformationType))
            {
                writer.WritePropertyName("informationType");
                writer.WriteStringValue(InformationType);
            }
            if (Optional.IsDefined(InformationTypeId))
            {
                writer.WritePropertyName("informationTypeId");
                writer.WriteStringValue(InformationTypeId);
            }
            if (Optional.IsDefined(Rank))
            {
                writer.WritePropertyName("rank");
                writer.WriteStringValue(Rank.Value.ToSerialString());
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static SensitivityLabel DeserializeSensitivityLabel(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            Optional<string> labelName = default;
            Optional<string> labelId = default;
            Optional<string> informationType = default;
            Optional<string> informationTypeId = default;
            Optional<bool> isDisabled = default;
            Optional<SensitivityLabelRank> rank = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("labelName"))
                        {
                            labelName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("labelId"))
                        {
                            labelId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("informationType"))
                        {
                            informationType = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("informationTypeId"))
                        {
                            informationTypeId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("isDisabled"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            isDisabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("rank"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            rank = property0.Value.GetString().ToSensitivityLabelRank();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new SensitivityLabel(id.Value, name.Value, type.Value, labelName.Value, labelId.Value, informationType.Value, informationTypeId.Value, Optional.ToNullable(isDisabled), Optional.ToNullable(rank));
        }
    }
}

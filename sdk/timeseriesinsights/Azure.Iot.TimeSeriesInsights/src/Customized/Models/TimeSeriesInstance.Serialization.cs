// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Iot.TimeSeriesInsights
{
    public partial class TimeSeriesInstance : IUtf8JsonSerializable
    {
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("timeSeriesId");
            writer.WriteStartArray();
            foreach (var item in TimeSeriesId.ToArray())
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("typeId");
            writer.WriteStringValue(TypeId);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsCollectionDefined(HierarchyIds))
            {
                writer.WritePropertyName("hierarchyIds");
                writer.WriteStartArray();
                foreach (var item in HierarchyIds)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(InstanceFields))
            {
                writer.WritePropertyName("instanceFields");
                writer.WriteStartObject();
                foreach (var item in InstanceFields)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        internal static TimeSeriesInstance DeserializeTimeSeriesInstance(JsonElement element)
        {
            ITimeSeriesId timeSeriesId = default;
            string typeId = default;
            Optional<string> name = default;
            Optional<string> description = default;
            Optional<IList<string>> hierarchyIds = default;
            Optional<IDictionary<string, object>> instanceFields = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("timeSeriesId"))
                {
                    List<object> array = new List<object>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetObject());
                    }

                    switch (array.Count)
                    {
                        case 1:
                            timeSeriesId = new TimeSeriesId<object>(array[0]);
                            break;
                        case 2:
                            timeSeriesId = new TimeSeriesId<object, object>(array[0], array[1]);
                            break;
                        case 3:
                            timeSeriesId = new TimeSeriesId<object, object, object>(array[0], array[1], array[2]);
                            break;
                    }
                    continue;
                }
                if (property.NameEquals("typeId"))
                {
                    typeId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hierarchyIds"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    hierarchyIds = array;
                    continue;
                }
                if (property.NameEquals("instanceFields"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetObject());
                    }
                    instanceFields = dictionary;
                    continue;
                }
            }
            return new TimeSeriesInstance(timeSeriesId, typeId, name.Value, description.Value, Optional.ToList(hierarchyIds), Optional.ToDictionary(instanceFields));
        }
    }
}

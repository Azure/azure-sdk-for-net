// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// This class definition overrides serialization and deserialization implementation in
    /// order to turn Time Series Ids from a strongly typed object to an list of objects that
    /// the service can understand, and vice versa.
    /// </summary>
    public partial class TimeSeriesInstance : IUtf8JsonSerializable
    {
        // The use of fully qualified name for IUtf8JsonSerializable is a work around until this
        // issue is fixed: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("timeSeriesId");
            writer.WriteStartArray();
            foreach (object item in TimeSeriesId.ToArray())
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
                foreach (KeyValuePair<string, object> item in InstanceFields)
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
            TimeSeriesId timeSeriesId = default;
            string typeId = default;
            Optional<string> name = default;
            Optional<string> description = default;
            Optional<IList<string>> hierarchyIds = default;
            Optional<IDictionary<string, object>> instanceFields = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("timeSeriesId"))
                {
                    var array = new List<string>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }

                    timeSeriesId = array.Count switch
                    {
                        1 => new TimeSeriesId(array[0]),
                        2 => new TimeSeriesId(array[0], array[1]),
                        3 => new TimeSeriesId(array[0], array[1], array[2]),
                        _ => throw new Exception($"Invalid number of Time Series Insights Id properties."),
                    };
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
                    foreach (JsonElement item in property.Value.EnumerateArray())
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
                    foreach (JsonProperty property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetObject());
                    }
                    instanceFields = dictionary;
                    continue;
                }
            }

            return new TimeSeriesInstance(
                timeSeriesId,
                typeId,
                name.Value,
                description.Value,
                Optional.ToList(hierarchyIds),
                Optional.ToDictionary(instanceFields));
        }
    }
}

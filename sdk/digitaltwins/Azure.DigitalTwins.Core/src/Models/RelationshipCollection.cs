// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    internal class RelationshipCollection<T>
    {
        internal IReadOnlyList<T> Value { get; }

        internal string NextLink { get; }

        internal RelationshipCollection()
        {
            Value = new ChangeTrackingList<T>();
        }

        internal RelationshipCollection(IReadOnlyList<T> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        internal static RelationshipCollection<T> DeserializeRelationshipCollection(JsonElement element, ObjectSerializer objectSerializer)
        {
            Optional<IReadOnlyList<T>> value = default;
            Optional<string> nextLink = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<T> array = new List<T>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        MemoryStream streamedObject = StreamHelper.WriteToStream(item, objectSerializer, default);
                        T obj = (T)objectSerializer.Deserialize(streamedObject, typeof(T), default);
                        array.Add(obj);
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new RelationshipCollection<T>(Optional.ToList(value), nextLink.Value);
        }
    }
}

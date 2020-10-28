// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    internal partial class QueryResult<T>
    {
        internal IReadOnlyList<T> Value { get; }

        internal string ContinuationToken { get; }

        internal QueryResult()
        {
            Value = new ChangeTrackingList<T>();
        }

        internal QueryResult(IReadOnlyList<T> value, string continuationToken)
        {
            Value = value;
            ContinuationToken = continuationToken;
        }

        internal static QueryResult<T> DeserializeQueryResult(JsonElement element, ObjectSerializer objectSerializer)
        {
            IReadOnlyList<T> items = default;
            string continuationToken = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<T> array = new List<T>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        MemoryStream streamedObject = StreamHelper.WriteToStream(item, objectSerializer, default);
                        T obj = (T)objectSerializer.Deserialize(streamedObject, typeof(T), default);
                        array.Add(obj);
                    }
                    items = array;
                    continue;
                }
                if (property.NameEquals("continuationToken"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    continuationToken = property.Value.GetString();
                    continue;
                }
            }
            return new QueryResult<T>(items, continuationToken);
        }
    }
}

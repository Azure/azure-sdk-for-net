// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    internal partial class QueryResult
    {
        // This class declaration makes the generated class of the same name internal instead of public; do not remove.
        // It also overrides deserialization implementation in order to treat the **object** type definition for "items" as json strings.

        internal static QueryResult DeserializeQueryResult(JsonElement element)
        {
            IReadOnlyList<string> items = default;
            string continuationToken = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        // manual change: get json text
                        array.Add(item.GetRawText());
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
            return new QueryResult(items, continuationToken);
        }
    }
}

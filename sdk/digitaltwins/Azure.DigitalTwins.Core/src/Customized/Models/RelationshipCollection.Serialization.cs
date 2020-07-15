// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.DigitalTwins.Core
{
    internal partial class RelationshipCollection
    {
        // This class declaration makes the generated class of the same name internal instead of public; do not remove.
        // It also overrides deserialization implementation in order to treat the **object** type definition for "value" as a list of json strings.

        internal static RelationshipCollection DeserializeRelationshipCollection(JsonElement element)
        {
            IReadOnlyList<string> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
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
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new RelationshipCollection(value, nextLink);
        }
    }
}

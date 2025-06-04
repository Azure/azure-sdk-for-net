// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ClientModel.Tests.Collections;

// public as a convience for tests.
public class ValueItemPage
{
    public ValueItemPage(IEnumerable<ValueItem> values, bool hasMore)
    {
        Values = values.ToList().AsReadOnly();
        HasMore = hasMore;
    }

    public IReadOnlyList<ValueItem> Values { get; }

    public bool HasMore { get; }

    public BinaryData ToJson()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("{");
        sb.AppendLine("\"data\":");
        sb.AppendLine("[");

        int count = 0;
        foreach (ValueItem value in Values)
        {
            sb.AppendLine(value.ToJson());

            if (++count != Values.Count)
            {
                sb.AppendLine(",");
            }
        }
        sb.AppendLine("],");
        sb.AppendLine($"\"has_more\": {HasMore.ToString().ToLower()}");
        sb.AppendLine("}");

        return BinaryData.FromString(sb.ToString());
    }

    public static ValueItemPage FromJson(BinaryData json)
    {
        List<ValueItem> items = new();

        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement data = doc.RootElement.GetProperty("data");
        foreach (JsonElement item in data.EnumerateArray())
        {
            items.Add(ValueItem.FromJson(item));
        }
        JsonElement more = doc.RootElement.GetProperty("has_more");
        bool hasMore = more.GetBoolean();

        return new ValueItemPage(items, hasMore);
    }
}

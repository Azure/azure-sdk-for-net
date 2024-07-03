// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ClientModel.Tests.Paging;

// In a real client, this type would be generated but would be made internal.
// It corresponds to the REST API definition of the response that comes back
// with a list of items in a page.
internal class ValueItemPage
{
    protected ValueItemPage(List<ValueItem> values)
    {
        Values = values;
    }

    public IReadOnlyList<ValueItem> Values { get; set; }

    public static ValueItemPage FromJson(BinaryData json)
    {
        List<ValueItem> items = new();

        using JsonDocument doc = JsonDocument.Parse(json);
        foreach (JsonElement element in doc.RootElement.EnumerateArray())
        {
            items.Add(ValueItem.FromJson(element));
        }

        return new ValueItemPage(items);
    }
}

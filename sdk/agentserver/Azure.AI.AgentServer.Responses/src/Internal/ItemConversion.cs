// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Internal utility for converting response items between input and output representations.
/// </summary>
internal static class ItemConversion
{
    internal static OutputItem? ToOutputItem(Item item, string? partitionKeyHint)
    {
        if (item.Id is null)
        {
            item.Id = IdGenerator.NewItemId(item, partitionKeyHint);
        }

        return item;
    }

    internal static IEnumerable<OutputItem> ToOutputItems(IEnumerable<Item> items, string? partitionKeyHint)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    internal static Item? ToItem(OutputItem outputItem)
    {
        return outputItem;
    }
}

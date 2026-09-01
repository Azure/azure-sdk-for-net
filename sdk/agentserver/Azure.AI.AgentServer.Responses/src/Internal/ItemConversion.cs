// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Internal utility for preparing <see cref="Item"/> instances from
/// <see cref="CreateResponse.InputItems"/> for storage and retrieval via the provider.
/// Each item receives a correctly prefixed ID via <see cref="IdGenerator.NewItemId"/>.
/// </summary>
/// <remarks>
/// Input items and output items are now the same type (<c>OpenAI.Responses.ResponseItem</c>),
/// so conversion no longer maps between two parallel hierarchies. What remains is assigning a
/// type-prefixed ID and stripping server-internal metadata on egress.
/// </remarks>
[System.Diagnostics.CodeAnalysis.Experimental("AAIP002")]
internal static class ItemConversion
{
    /// <summary>
    /// Prepares a single <see cref="Item"/> for storage by assigning it a type-specific ID.
    /// </summary>
    /// <param name="item">The input item to convert.</param>
    /// <param name="partitionKeyHint">
    /// An existing ID (typically the response ID) from which to propagate the partition key
    /// into the generated item ID for storage colocation.
    /// </param>
    /// <returns>The converted output item, or <c>null</c> if the item type is not convertible (e.g., <see cref="ItemReferenceParam"/>).</returns>
    internal static OutputItem? ToOutputItem(Item item, string? partitionKeyHint)
    {
        var id = IdGenerator.NewItemId(item, partitionKeyHint);
        if (id is null)
        {
            return null; // non-convertible type (e.g. ItemReferenceParam)
        }

        // Clone so that assigning the ID does not mutate the caller's instance.
        var converted = Clone(item);
        if (converted is null)
        {
            return null;
        }

        converted.Id = id;
        return converted;
    }

    /// <summary>
    /// Prepares a sequence of <see cref="Item"/> instances for storage, skipping
    /// any that are not convertible.
    /// </summary>
    /// <param name="items">The input items to convert.</param>
    /// <param name="partitionKeyHint">
    /// An existing ID (typically the response ID) from which to propagate the partition key.
    /// </param>
    /// <returns>The converted output items (references excluded).</returns>
    internal static IEnumerable<OutputItem> ToOutputItems(
        IEnumerable<Item> items,
        string? partitionKeyHint)
    {
        foreach (var item in items)
        {
            var output = ToOutputItem(item, partitionKeyHint);
            if (output is not null)
            {
                yield return output;
            }
        }
    }

    /// <summary>
    /// Returns the <see cref="Item"/> representation of an <see cref="OutputItem"/>,
    /// with server-internal metadata removed.
    /// </summary>
    /// <param name="outputItem">The output item to convert.</param>
    /// <returns>The corresponding input item, or <c>null</c> if conversion is not possible.</returns>
    internal static Item? ToItem(OutputItem outputItem) => StripInternalMetadata(outputItem);

    private static OutputItem? StripInternalMetadata(OutputItem outputItem)
    {
        try
        {
            var json = ModelReaderWriter.Write(outputItem, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
            var node = JsonNode.Parse(json.ToString());
            if (node is null)
            {
                return null;
            }

            InternalMetadataEgress.Strip(node);
            var stripped = BinaryData.FromString(node.ToJsonString());
            return ModelReaderWriter.Read<OutputItem>(stripped, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
        }
        catch (JsonException)
        {
            return null;
        }
        catch (FormatException)
        {
            return null;
        }
        catch (NotSupportedException)
        {
            return null;
        }
    }

    private static OutputItem? Clone(Item item)
    {
        try
        {
            var json = ModelReaderWriter.Write(item, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
            return ModelReaderWriter.Read<OutputItem>(json, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
        }
        catch (JsonException)
        {
            return null;
        }
        catch (FormatException)
        {
            return null;
        }
        catch (NotSupportedException)
        {
            return null;
        }
    }
}

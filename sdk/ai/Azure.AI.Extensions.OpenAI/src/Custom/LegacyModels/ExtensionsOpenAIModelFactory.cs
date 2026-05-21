// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Collections.Generic;

namespace Azure.AI.Extensions.OpenAI;

// The factory for legacy models.
public partial class ExtensionsOpenAIModelFactory
{
    /// <summary> The MemorySearchToolCallResponseItem. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="status">
    /// The status of the memory search tool call. One of `in_progress`,
    /// `searching`, `completed`, `incomplete` or `failed`,
    /// </param>
    /// <param name="results"> The results returned from the memory search. </param>
    /// <returns> A new <see cref="OpenAI.MemorySearchToolCallResponseItem"/> instance for mocking. </returns>
    public static MemorySearchToolCallResponseItem MemorySearchToolCallResponseItem(string id = default, AgentReference agentReference = default, string responseId = default, MemorySearchToolCallStatus status = default, IEnumerable<MemoryToolSearchItem> results = default)
    {
        results ??= new ChangeTrackingList<MemoryToolSearchItem>();

        return new MemorySearchToolCallResponseItem(
            AgentResponseItemKind.MemorySearchCall,
            id,
            agentReference,
            responseId,
            additionalBinaryDataProperties: null,
            status,
            results.ToList());
    }

    /// <summary> A retrieved memory item from memory search. </summary>
    /// <param name="memoryItem"> Retrieved memory item. </param>
    /// <returns> A new <see cref="OpenAI.MemoryToolSearchItem"/> instance for mocking. </returns>
    public static MemoryToolSearchItem MemoryToolSearchItem(MemoryOutputItem memoryItem = default)
    {
        return new MemoryToolSearchItem(memoryItem, additionalBinaryDataProperties: null);
    }
}

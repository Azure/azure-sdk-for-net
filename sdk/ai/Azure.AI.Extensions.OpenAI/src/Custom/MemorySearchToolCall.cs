// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class MemorySearchToolCall
{
    /// <summary> Initializes a new instance of <see cref="MemorySearchToolCall"/>. </summary>
    /// <param name="status"> The status of the tool call. </param>
    internal MemorySearchToolCall(ToolCallStatus status) : base(ResponseItemKind.MemorySearchCall)
    {
        Status = status;
        Memories = new ChangeTrackingList<MemoryOutputItem>();
    }

    /// <summary> Initializes a new instance of <see cref="MemorySearchToolCall"/>. </summary>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="status"> The status of the tool call. </param>
    /// <param name="memories"> The results returned from the memory search. </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal MemorySearchToolCall(string id, AgentReference agentReference, string responseId, ToolCallStatus status, IList<MemoryOutputItem> memories, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.MemorySearchCall)
    {
        Status = status;
        Memories = memories;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    /// <summary> Initializes a new instance of <see cref="MemorySearchToolCall"/> for deserialization. </summary>
    internal MemorySearchToolCall(): base(ResponseItemKind.MemorySearchCall)
    {
    }
}
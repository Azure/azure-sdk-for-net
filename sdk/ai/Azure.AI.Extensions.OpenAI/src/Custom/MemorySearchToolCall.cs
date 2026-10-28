// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenSuppress("Patch")]
public partial class MemorySearchToolCall
{
    /// <summary> Initializes a new instance of <see cref="MemorySearchToolCall"/> for deserialization. </summary>
    internal MemorySearchToolCall() : base(ResponseItemKind.MemorySearchCall)
    {
    }

    // Custom: the generated constructor passed (id, agentReference, responseId) to the
    // OpenAI ResponseItem base type, which only exposes a constructor taking the kind, causing
    // CS1729. Relocated here from the generated model and changed to call base(@type) only.
    /// <summary> Initializes a new instance of <see cref="MemorySearchToolCall"/>. </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <param name="agentReference"> The agent that created the item. </param>
    /// <param name="responseId"> The response on which the item is created. </param>
    /// <param name="status"> The status of the tool call. </param>
    /// <param name="memories"> The results returned from the memory search. </param>
    /// <param name="patch"></param>
    internal MemorySearchToolCall(ResponseItemKind @type, string id, AgentReference agentReference, string responseId, ToolCallStatus status, IList<MemoryOutputItem> memories, in JsonPatch patch) : base(@type)
    {
        _patch = patch;
        this.ApplyAgentAttribution(agentReference, responseId, null);
        Id = id;
        Status = status;
        Memories = memories;
    }
}

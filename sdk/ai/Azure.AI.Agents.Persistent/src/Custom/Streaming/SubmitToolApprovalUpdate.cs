// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent
{
    /// <summary> Represents a streaming update indicating that an MCP tool call requires user approval before execution. </summary>
    public class SubmitToolApprovalUpdate : RunUpdate
    {
        private readonly RequiredMcpToolCall _mcpToolCall;
        /// <summary> Initializes a new instance of the <see cref="SubmitToolApprovalUpdate"/> class. </summary>
        /// <param name="run"> The thread run associated with this update. </param>
        /// <param name="mcpToolCall"> The MCP tool call that requires approval. </param>
        public SubmitToolApprovalUpdate(ThreadRun run, RequiredMcpToolCall mcpToolCall) : base(run, StreamingUpdateReason.RunRequiresAction)
        {
            _mcpToolCall = mcpToolCall;
        }

        /// <summary> Gets the identifier of the tool call that requires approval. </summary>
        public string ToolCallId => _mcpToolCall.Id;

        /// <summary> Gets the arguments for the MCP tool call. </summary>
        public string Arguments => _mcpToolCall.Arguments;

        /// <summary> Gets the name of the MCP tool. </summary>
        public string Name => _mcpToolCall.Name;

        /// <summary> Gets the server label identifying the MCP server. </summary>
        public string ServerLabel => _mcpToolCall.ServerLabel;

        internal static IEnumerable<SubmitToolApprovalUpdate> DeserializeSubmitToolApprovalUpdates(JsonElement element)
        {
            ThreadRun run = ThreadRun.DeserializeThreadRun(element, new ModelReaderWriterOptions("W"));
            List<SubmitToolApprovalUpdate> updates = [];
            if (run.RequiredAction is SubmitToolApprovalAction submitAction)
            {
                foreach (RequiredToolCall toolCall in submitAction.SubmitToolApproval.ToolCalls)
                {
                    if (toolCall is RequiredMcpToolCall mcpToolCall)
                    {
                        updates.Add(new(run, mcpToolCall));
                    }
                }
            }
            return updates;
        }
    }
}

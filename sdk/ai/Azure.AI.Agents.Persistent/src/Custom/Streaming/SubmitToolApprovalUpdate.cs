// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent
{
    public class SubmitToolApprovalUpdate : RunUpdate
    {
        private readonly RequiredMcpToolCall _mcpToolCall;
        public SubmitToolApprovalUpdate(ThreadRun run, RequiredMcpToolCall mcpToolCall) : base(run, StreamingUpdateReason.RunRequiresAction)
        {
            _mcpToolCall = mcpToolCall;
        }

        public string ToolCallId => _mcpToolCall.Id;

        public string Arguments => _mcpToolCall.Arguments;

        public string Name => _mcpToolCall.Name;

        public string ServerLabel => _mcpToolCall.ServerLabel;

        internal static IEnumerable<SubmitToolApprovalUpdate> DeserializeSubmitToolApprovalUpdates(JsonElement element)
        {
            ThreadRun run = ThreadRun.DeserializeThreadRun(element);
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

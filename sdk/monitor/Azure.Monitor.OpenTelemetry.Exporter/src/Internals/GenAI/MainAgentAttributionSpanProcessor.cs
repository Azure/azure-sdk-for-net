// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;

using static Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI.MainAgentAttributeConstants;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI
{
    /// <summary>
    /// A span processor that propagates main-agent context so that all emitted
    /// telemetry is attributed to the user-facing agent rather than to internal
    /// implementation agents in a GenAI multi-agent system.
    /// </summary>
    internal sealed class MainAgentAttributionSpanProcessor : BaseProcessor<Activity>
    {
        // Ordered pairs: (target, primary, fallback)
        private static readonly (string Target, string Primary, string Fallback)[] s_attributeMappings = new[]
        {
            (MainAgentName, MainAgentName, GenAiAgentName),
            (MainAgentId, MainAgentId, GenAiAgentId),
            (MainAgentVersion, MainAgentVersion, GenAiAgentVersion),
            (MainAgentConversationId, MainAgentConversationId, GenAiConversationId),
        };

        // Ordered pairs for OnEnd self-copy: (target, source)
        private static readonly (string Target, string Source)[] s_selfCopyMappings = new[]
        {
            (MainAgentName, GenAiAgentName),
            (MainAgentId, GenAiAgentId),
            (MainAgentVersion, GenAiAgentVersion),
            (MainAgentConversationId, GenAiConversationId),
        };

        public override void OnStart(Activity activity)
        {
            var parent = activity.Parent;
            if (parent == null)
            {
                return;
            }

            // Quick check: skip if parent has no GenAI attributes at all.
            // Checking Name and AgentName suffices because any conforming GenAI
            // span will always carry at least the agent name attribute.
            if (parent.GetTagItem(MainAgentName) == null &&
                parent.GetTagItem(GenAiAgentName) == null)
            {
                return;
            }

            foreach (var (target, primary, fallback) in s_attributeMappings)
            {
                // Don't overwrite attributes already set on the child span
                // (e.g., a nested agent that set its own main_agent context).
                if (activity.GetTagItem(target) != null)
                {
                    continue;
                }

                var value = parent.GetTagItem(primary);
                if (value != null)
                {
                    activity.SetTag(target, value);
                }
                else
                {
                    value = parent.GetTagItem(fallback);
                    if (value != null)
                    {
                        activity.SetTag(target, value);
                    }
                }
            }
        }

        public override void OnEnd(Activity activity)
        {
            var operationName = activity.GetTagItem(GenAiOperationName) as string;
            if (operationName != InvokeAgentOperationName)
            {
                return;
            }

            foreach (var (target, source) in s_selfCopyMappings)
            {
                // Only copy if this specific attribute is not already set,
                // allowing partial attribution from parent propagation.
                if (activity.GetTagItem(target) != null)
                {
                    continue;
                }

                var value = activity.GetTagItem(source);
                if (value != null)
                {
                    activity.SetTag(target, value);
                }
            }
        }
    }
}

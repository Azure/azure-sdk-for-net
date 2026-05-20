// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI
{
    internal static class MainAgentAttributeConstants
    {
        // Target attributes (microsoft.gen_ai.main_agent.*)
        internal const string MainAgentName = "microsoft.gen_ai.main_agent.name";
        internal const string MainAgentId = "microsoft.gen_ai.main_agent.id";
        internal const string MainAgentVersion = "microsoft.gen_ai.main_agent.version";
        internal const string MainAgentConversationId = "microsoft.gen_ai.main_agent.conversation_id";

        // Source / fallback attributes (gen_ai.agent.* / gen_ai.conversation.*)
        internal const string GenAiAgentName = "gen_ai.agent.name";
        internal const string GenAiAgentId = "gen_ai.agent.id";
        internal const string GenAiAgentVersion = "gen_ai.agent.version";
        internal const string GenAiConversationId = "gen_ai.conversation.id";

        // Operation name
        internal const string GenAiOperationName = "gen_ai.operation.name";
        internal const string InvokeAgentOperationName = "invoke_agent";
    }
}

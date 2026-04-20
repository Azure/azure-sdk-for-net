// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive.Telemetry
{
    internal static class VoiceLiveTelemetryAttributeKeys
    {
        // --- GenAI Semantic Convention attributes (v1.34.0) ---
        public const string GenAiOperationName = "gen_ai.operation.name";
        public const string GenAiSystem = "gen_ai.system";
        public const string GenAiSystemValue = "az.ai.voicelive";
        public const string GenAiRequestModel = "gen_ai.request.model";
        public const string GenAiUsageInputTokens = "gen_ai.usage.input_tokens";
        public const string GenAiUsageOutputTokens = "gen_ai.usage.output_tokens";
        public const string GenAiEventContent = "gen_ai.event.content";
        public const string GenAiResponseId = "gen_ai.response.id";
        public const string GenAiResponseModel = "gen_ai.response.model";
        public const string GenAiResponseFinishReasons = "gen_ai.response.finish_reasons";
        public const string GenAiRequestTemperature = "gen_ai.request.temperature";
        public const string GenAiRequestMaxOutputTokens = "gen_ai.request.max_output_tokens";
        public const string GenAiSystemMessage = "gen_ai.system_instructions";

        // --- Agent attributes ---
        public const string GenAiAgentName = "gen_ai.agent.name";
        public const string GenAiAgentId = "gen_ai.agent.id";
        public const string GenAiAgentThreadId = "gen_ai.agent.thread_id";
        public const string GenAiAgentVersion = "gen_ai.agent.version";
        public const string GenAiAgentProjectName = "gen_ai.agent.project_name";
        public const string GenAiRequestTools = "gen_ai.request.tools";

        // --- Conversation attributes ---
        public const string GenAiConversationId = "gen_ai.conversation.id";

        // --- Server attributes ---
        public const string ServerAddress = "server.address";
        public const string ServerPort = "server.port";

        // --- Azure namespace ---
        public const string AzNamespace = "az.namespace";
        public const string AzNamespaceValue = "Microsoft.CognitiveServices";
        public const string GenAiProviderName = "gen_ai.provider.name";
        public const string GenAiProviderValue = "microsoft.foundry";

        // --- VoiceLive-specific attributes ---
        public const string GenAiVoiceSessionId = "gen_ai.voice.session_id";
        public const string GenAiVoiceCallId = "gen_ai.voice.call_id";
        public const string GenAiVoiceItemId = "gen_ai.voice.item_id";
        public const string GenAiVoicePreviousItemId = "gen_ai.voice.previous_item_id";
        public const string GenAiVoiceOutputIndex = "gen_ai.voice.output_index";
        public const string GenAiVoiceInputSampleRate = "gen_ai.voice.input_sample_rate";
        public const string GenAiVoiceOutputSampleRate = "gen_ai.voice.output_sample_rate";
        public const string GenAiVoiceInputAudioFormat = "gen_ai.voice.input_audio_format";
        public const string GenAiVoiceOutputAudioFormat = "gen_ai.voice.output_audio_format";

        // --- Session-level telemetry counters ---
        public const string GenAiVoiceTurnCount = "gen_ai.voice.turn_count";
        public const string GenAiVoiceInterruptionCount = "gen_ai.voice.interruption_count";
        public const string GenAiVoiceAudioBytesSent = "gen_ai.voice.audio_bytes_sent";
        public const string GenAiVoiceAudioBytesReceived = "gen_ai.voice.audio_bytes_received";

        // --- MCP-specific attributes ---
        public const string GenAiVoiceMcpServerLabel = "gen_ai.voice.mcp.server_label";
        public const string GenAiVoiceMcpToolName = "gen_ai.voice.mcp.tool_name";
        public const string GenAiVoiceMcpApprovalRequestId = "gen_ai.voice.mcp.approval_request_id";
        public const string GenAiVoiceMcpApprove = "gen_ai.voice.mcp.approve";
        public const string GenAiVoiceMcpCallCount = "gen_ai.voice.mcp.call_count";
        public const string GenAiVoiceMcpListToolsCount = "gen_ai.voice.mcp.list_tools_count";

        // --- Per-message attributes ---
        public const string GenAiVoiceMessageSize = "gen_ai.voice.message_size";
        public const string GenAiVoiceEventType = "gen_ai.voice.event_type";
        public const string GenAiVoiceFirstTokenLatencyMs = "gen_ai.voice.first_token_latency_ms";

        // --- Error attributes ---
        public const string ErrorType = "error.type";
        public const string ErrorMessage = "error.message";

        // --- Event names ---
        public const string SystemInstructionEventName = "gen_ai.system.instructions";

        // --- Operation names ---
        public const string OperationNameConnect = "connect";
        public const string OperationNameSend = "send";
        public const string OperationNameRecv = "recv";
        public const string OperationNameClose = "close";
    }
}

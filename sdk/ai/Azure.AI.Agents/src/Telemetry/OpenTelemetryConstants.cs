// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents.Telemetry
{
    internal class OpenTelemetryConstants
    {
        // follow OpenTelemetry GenAI semantic conventions:
        // https://github.com/open-telemetry/semantic-conventions/tree/v1.27.0/docs/gen-ai

        public const string ErrorTypeKey = "error.type";
        public const string ErrorMessageKey = "error.message";

        public const string AzNamespaceKey = "az.namespace";
        public const string ServerAddressKey = "server.address";
        public const string ServerPortKey = "server.port";

        public const string GenAiClientOperationDurationMetricName = "gen_ai.client.operation.duration";
        public const string GenAiClientTokenUsageMetricName = "gen_ai.client.token.usage";

        public const string GenAiOperationNameKey = "gen_ai.operation.name";

        public const string GenAiRequestMaxTokensKey = "gen_ai.request.max_tokens";
        public const string GenAiRequestModelKey = "gen_ai.request.model";
        public const string GenAiAgentNameKey = "gen_ai.agent.name";
        public const string GenAiRequestTemperatureKey = "gen_ai.request.temperature";
        public const string GenAiRequestTopPKey = "gen_ai.request.top_p";

        public const string GenAiResponseModelKey = "gen_ai.response.model";
        public const string GenAiResponseVersionKey = "gen_ai.agent.version";

        public const string GenAiSystemKey = "gen_ai.system";
        public const string GenAiSystemValue = "az.ai.agents";
        public const string GenAiProviderKey = "gen_ai.provider";
        public const string GenAiProviderValue = "azure.ai.agents";

        public const string GenAiTokenTypeKey = "gen_ai.token.type";

        public const string GenAiUsageInputTokensKey = "gen_ai.usage.input_tokens";
        public const string GenAiUsageOutputTokensKey = "gen_ai.usage.output_tokens";
        public const string GenAiAgentIdKey = "gen_ai.agent.id";
        public const string GenAiThreadIdKey = "gen_ai.thread.id";
        public const string GenAiMessageIdKey = "gen_ai.message.id";
        public const string GenAiMessageStatusKey = "gen_ai.message.status";
        public const string GenAiRunIdKey = "gen_ai.thread.run.id";
        public const string GenAiRunStatusKey = "gen_ai.thread.run.status";
        public const string GenAiRunStepStatusKey = "gen_ai.run_step.status";
        public const string GenAiRunStepStartTimestampKey = "gen_ai.run_step.start.timestamp";
        public const string GenAiRunStepEndTimestampKey = "gen_ai.run_step.end.timestamp";

        public const string GenAiEventContent = "gen_ai.event.content";
        public const string GenAiChoice = "gen_ai.choice";

        public const string AzureRpNamespaceValue = "Microsoft.CognitiveServices";

        public const string OperationNameValueCreateAgent = "create_agent";
        public const string OperationNameValueCreateThread = "create_thread";
        public const string OperationNameValueCreateMessage = "create_message";
        public const string OperationNameValueStartThreadRun = "start_thread_run";
        public const string OperationNameValueGetThreadRun = "get_thread_run";
        public const string OperationNameValueExecuteTool = "execute_tool";
        public const string OperationNameValueListMessage = "list_messages";
        public const string OperationNameValueListRunSteps = "list_run_steps";
        public const string OperationNameValueSubmitToolOutputs = "submit_tool_outputs";
        public const string OperationNameValueProcessThreadRun = "process_thread_run";

        public const string EventNameSystemMessage = "gen_ai.system.message";
        public const string EventNameUserMessage = "gen_ai.user.message";
        public const string EventNameAssistantMessage = "gen_ai.assistant.message";

        public const string ClientName = "Azure.AI.Agents.AgentsClient";
        public const string EnableOpenTelemetrySwitch = "Azure.Experimental.EnableActivitySource";
        public const string TraceContentsSwitch = "Azure.Experimental.TraceGenAIMessageContent";
        public const string TraceContentsEnvironmentVariable = "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT";
        public const string EnableOpenTelemetryEnvironmentVariable = "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE";

        public const string GenAiRequestReasoningEffort = "gen_ai.request.reasoning.effort";
        public const string GenAiRequestReasoningSummary = "gen_ai.request.reasoning.summary";
        public const string GenAiRequestStructuredInputs = "gen_ai.request.structured_inputs";
        public const string GenAiAgentVersion = "gen_ai.agent.version";
    }
}

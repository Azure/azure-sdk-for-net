// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Centralises all distributed tracing tag keys, baggage keys, log scope keys,
/// and well-known values used by the Responses SDK.
/// <para>
/// These constants ensure parity with the Core package
/// (<c>HostedAgentTelemetry</c>) and follow the
/// <see href="https://opentelemetry.io/docs/specs/semconv/gen-ai/">OTel GenAI
/// semantic conventions</see> where applicable.
/// </para>
/// </summary>
public static class ResponsesTracingConstants
{
    // ── Well-Known Values ────────────────────────────────────────────────

    /// <summary>
    /// The <c>service.name</c> tag value:
    /// <c>"azure.ai.agentserver"</c>. Matches Core for parity.
    /// </summary>
    public const string ServiceName = "azure.ai.agentserver";

    /// <summary>
    /// The <c>gen_ai.provider.name</c> tag value:
    /// <c>"AzureAI Hosted Agents"</c>. Matches Core for parity.
    /// </summary>
    public const string ProviderName = "AzureAI Hosted Agents";

    /// <summary>
    /// The <c>gen_ai.operation.name</c> tag value:
    /// <c>"invoke_agent"</c>.
    /// </summary>
    public const string OperationName = "invoke_agent";

    // ── Span Tag Keys ────────────────────────────────────────────────────

    /// <summary>Tag keys for span attributes set on every <c>POST /responses</c> activity.</summary>
    public static class Tags
    {
        // --- Core-parity tags (must match HostedAgentTelemetry) ---

        /// <summary><c>service.name</c></summary>
        public const string ServiceName = "service.name";

        /// <summary><c>gen_ai.provider.name</c></summary>
        public const string ProviderName = "gen_ai.provider.name";

        /// <summary><c>gen_ai.response.id</c></summary>
        public const string ResponseId = "gen_ai.response.id";

        /// <summary><c>gen_ai.agent.id</c> — always set; <c>""</c> when agent is null.</summary>
        public const string AgentId = "gen_ai.agent.id";

        // --- Namespaced parity tags (azure.ai.agentserver.responses.*) ---

        /// <summary><c>azure.ai.agentserver.responses.response_id</c></summary>
        public const string NamespacedResponseId = "azure.ai.agentserver.responses.response_id";

        /// <summary><c>azure.ai.agentserver.responses.conversation_id</c></summary>
        public const string NamespacedConversationId = "azure.ai.agentserver.responses.conversation_id";

        /// <summary><c>azure.ai.agentserver.responses.streaming</c></summary>
        public const string NamespacedStreaming = "azure.ai.agentserver.responses.streaming";

        /// <summary><c>microsoft.foundry.project.id</c> — Foundry project ARM resource ID.</summary>
        public const string FoundryProjectId = "microsoft.foundry.project.id";

        // --- Namespaced error tags ---

        /// <summary><c>azure.ai.agentserver.responses.error.code</c></summary>
        public const string ErrorCode = "azure.ai.agentserver.responses.error.code";

        /// <summary><c>azure.ai.agentserver.responses.error.message</c></summary>
        public const string ErrorMessage = "azure.ai.agentserver.responses.error.message";

        // --- OTel semantic convention attributes ---

        /// <summary>
        /// <c>error.type</c> — OTel semantic convention attribute for the error type.
        /// <see href="https://opentelemetry.io/docs/specs/semconv/registry/attributes/error/#error-type"/>
        /// </summary>
        public const string OTelErrorType = "error.type";

        /// <summary>
        /// <c>otel.status_description</c> — OTel semantic convention attribute for the status description.
        /// <see href="https://opentelemetry.io/docs/specs/semconv/registry/attributes/otel/#otel-status-description"/>
        /// </summary>
        public const string OTelStatusDescription = "otel.status_description";

        // --- GenAI semantic convention tags (Responses-specific additions) ---

        /// <summary><c>gen_ai.operation.name</c></summary>
        public const string OperationName = "gen_ai.operation.name";

        /// <summary><c>gen_ai.request.model</c></summary>
        public const string RequestModel = "gen_ai.request.model";

        /// <summary><c>gen_ai.conversation.id</c></summary>
        public const string ConversationId = "gen_ai.conversation.id";

        /// <summary><c>gen_ai.agent.name</c></summary>
        public const string AgentName = "gen_ai.agent.name";

        /// <summary><c>gen_ai.agent.version</c></summary>
        public const string AgentVersion = "gen_ai.agent.version";
    }

    // ── Baggage Keys ─────────────────────────────────────────────────────

    /// <summary>Baggage keys set on every <c>POST /responses</c> activity. Protocol-agnostic keys for Core parity.</summary>
    public static class Baggage
    {
        /// <summary><c>azure.ai.agentserver.response_id</c></summary>
        public const string ResponseId = "azure.ai.agentserver.response_id";

        /// <summary><c>azure.ai.agentserver.conversation_id</c></summary>
        public const string ConversationId = "azure.ai.agentserver.conversation_id";

        /// <summary><c>azure.ai.agentserver.streaming</c> — PascalCase booleans (<c>"True"</c>/<c>"False"</c>).</summary>
        public const string Streaming = "azure.ai.agentserver.streaming";

        /// <summary><c>azure.ai.agentserver.x-request-id</c> — set only when <c>X-Request-Id</c> header is present.</summary>
        public const string RequestId = "azure.ai.agentserver.x-request-id";
    }

    // ── Log Scope Keys ───────────────────────────────────────────────────

    /// <summary>Keys used with <see cref="Microsoft.Extensions.Logging.LoggerExtensions.BeginScope"/> for structured log enrichment.</summary>
    public static class LogScope
    {
        /// <summary><c>ResponseId</c></summary>
        public const string ResponseId = "ResponseId";

        /// <summary><c>ConversationId</c></summary>
        public const string ConversationId = "ConversationId";

        /// <summary><c>Streaming</c></summary>
        public const string Streaming = "Streaming";
    }
}

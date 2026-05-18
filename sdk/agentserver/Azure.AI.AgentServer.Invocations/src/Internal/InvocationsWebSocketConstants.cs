// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Constants for the <c>invocations_ws</c> (WebSocket) protocol — route,
/// RFC 6455 close codes, and OpenTelemetry span attribute keys.
/// </summary>
/// <remarks>
/// Mirrors the Python <c>InvocationsWSConstants</c> class so the wire
/// contract (route path, close codes, span attribute names) is identical
/// across language SDKs.
/// </remarks>
internal static class InvocationsWebSocketConstants
{
    /// <summary>The WebSocket endpoint path: <c>/invocations_ws</c>.</summary>
    public const string RoutePath = "/invocations_ws";

    /// <summary>RFC 6455 close code 1000 — handler returned cleanly.</summary>
    public const int CloseNormal = 1000;

    /// <summary>RFC 6455 close code 1011 — handler raised an unhandled exception.</summary>
    public const int CloseInternalError = 1011;

    /// <summary>OTel span attribute carrying the per-connection session ID.</summary>
    public const string AttrSpanSessionId = "azure.ai.agentserver.invocations_ws.session_id";

    /// <summary>OTel span attribute carrying the final RFC 6455 close code.</summary>
    public const string AttrSpanCloseCode = "azure.ai.agentserver.invocations_ws.close_code";

    /// <summary>OTel span attribute carrying the connection duration in milliseconds.</summary>
    public const string AttrSpanDurationMs = "azure.ai.agentserver.invocations_ws.duration_ms";

    /// <summary>OTel span attribute carrying a short error tag.</summary>
    public const string AttrSpanErrorCode = "azure.ai.agentserver.invocations_ws.error.code";

    /// <summary>OTel span attribute carrying a human-readable error message.</summary>
    public const string AttrSpanErrorMessage = "azure.ai.agentserver.invocations_ws.error.message";

    /// <summary>Short error tag for the "handler accept failed" path.</summary>
    public const string ErrorCodeAcceptFailed = "accept_failed";

    /// <summary>Short error tag for the "handler raised exception" path.</summary>
    public const string ErrorCodeInternalError = "internal_error";
}

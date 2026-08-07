// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Constants for the <c>invocations_ws</c> (WebSocket) protocol — route,
/// RFC 6455 close codes, and structured-log <c>extra</c> field keys.
/// </summary>
/// <remarks>
/// The route path, close codes, and structured-log field names are part of
/// the cross-language <c>invocations_ws</c> wire contract; keep them in
/// lock-step with the same set surfaced by other SDKs implementing the
/// protocol. The <c>AttrSpan*</c> field names read as OTel-style attribute
/// keys and are shared by the connection Activity and structured close-event
/// log record.
/// </remarks>
internal static class InvocationsWebSocketConstants
{
    /// <summary>The WebSocket endpoint path: <c>/invocations_ws</c>.</summary>
    public const string RoutePath = "/invocations_ws";

    /// <summary>RFC 6455 close code 1000 — handler returned cleanly.</summary>
    public const int CloseNormal = 1000;

    /// <summary>RFC 6455 close code 1011 — handler raised an unhandled exception.</summary>
    public const int CloseInternalError = 1011;

    /// <summary>Maximum total time for connection teardown after a terminal begins.</summary>
    public const double CleanupTimeoutSeconds = 5.0;

    // ----------------------------------------------------------------
    // Connection Activity and structured close-log attribute keys.
    // ----------------------------------------------------------------

    /// <summary>Structured-log field key carrying the per-connection session ID.</summary>
    public const string AttrSpanSessionId = "azure.ai.agentserver.invocations_ws.session_id";

    /// <summary>Structured-log field key carrying the final RFC 6455 close code.</summary>
    public const string AttrSpanCloseCode = "azure.ai.agentserver.invocations_ws.close_code";

    /// <summary>Structured-log field key carrying the connection duration in milliseconds.</summary>
    public const string AttrSpanDurationMs = "azure.ai.agentserver.invocations_ws.duration_ms";

    /// <summary>Structured-log field key carrying a short error tag.</summary>
    public const string AttrSpanErrorCode = "azure.ai.agentserver.invocations_ws.error.code";

    /// <summary>Short error tag for the "handler accept failed" path.</summary>
    public const string ErrorCodeAcceptFailed = "accept_failed";

    /// <summary>Short error tag for the "handler raised exception" path.</summary>
    public const string ErrorCodeInternalError = "internal_error";
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Defines the HTTP header names used across the AgentServer platform.
/// These headers form the wire contract between the Foundry platform,
/// agent containers, and downstream storage services.
/// </summary>
/// <remarks>
/// <para><b>Response headers</b> (set by the server on every response):</para>
/// <list type="bullet">
///   <item><see cref="RequestId"/> — request correlation ID.</item>
///   <item><see cref="ServerVersion"/> — server SDK identity.</item>
///   <item><see cref="SessionId"/> — resolved session ID (when applicable).</item>
/// </list>
/// <para><b>Error response headers</b> (set on 4xx/5xx responses):</para>
/// <list type="bullet">
///   <item><see cref="ErrorSource"/> — classifies error origin (<c>user</c>, <c>platform</c>, or <c>upstream</c>).</item>
///   <item><see cref="ErrorDetail"/> — internal diagnostic detail for platform telemetry.</item>
/// </list>
/// <para><b>Request headers</b> (set by the platform or client):</para>
/// <list type="bullet">
///   <item><see cref="RequestId"/> — client-provided correlation ID (echoed back on the response).</item>
///   <item><see cref="UserIsolationKey"/> / <see cref="ChatIsolationKey"/> — platform isolation keys.</item>
///   <item><see cref="ClientHeaderPrefix"/> — prefix for pass-through client headers.</item>
///   <item><see cref="TraceParent"/> — W3C Trace Context propagation header.</item>
///   <item><see cref="ClientRequestId"/> — Azure SDK client correlation header.</item>
/// </list>
/// </remarks>
public static class PlatformHeaders
{
    /// <summary>
    /// The <c>x-request-id</c> header — carries the request correlation ID.
    /// On responses, the server always sets this header (OTEL trace ID → incoming header → GUID).
    /// On requests, clients may set it to provide their own correlation ID.
    /// </summary>
    public const string RequestId = "x-request-id";

    /// <summary>
    /// The <c>x-platform-server</c> header — identifies the server SDK stack
    /// (hosting version, protocol versions, language, and runtime).
    /// Set on every response by <c>ServerVersionMiddleware</c>.
    /// </summary>
    public const string ServerVersion = "x-platform-server";

    /// <summary>
    /// The <c>x-agent-session-id</c> header — the resolved session ID for the request.
    /// Set on responses by protocol-specific session resolution logic.
    /// </summary>
    public const string SessionId = "x-agent-session-id";

    /// <summary>
    /// The <c>x-agent-user-isolation-key</c> header — the platform-injected
    /// partition key for user-private state.
    /// </summary>
    public const string UserIsolationKey = "x-agent-user-isolation-key";

    /// <summary>
    /// The <c>x-agent-chat-isolation-key</c> header — the platform-injected
    /// partition key for conversation-scoped state.
    /// </summary>
    public const string ChatIsolationKey = "x-agent-chat-isolation-key";

    /// <summary>
    /// The prefix <c>x-client-</c> for pass-through client headers.
    /// All request headers starting with this prefix are extracted and forwarded
    /// to the handler via the invocation context.
    /// </summary>
    public const string ClientHeaderPrefix = "x-client-";

    /// <summary>
    /// The <c>traceparent</c> header — W3C Trace Context propagation header.
    /// Used for distributed tracing correlation on outbound storage requests.
    /// </summary>
    public const string TraceParent = "traceparent";

    /// <summary>
    /// The <c>x-ms-client-request-id</c> header — Azure SDK client correlation header.
    /// Logged for diagnostic correlation with upstream Azure SDK callers.
    /// </summary>
    public const string ClientRequestId = "x-ms-client-request-id";

    /// <summary>
    /// The <c>x-platform-error-source</c> header — classifies every error response
    /// so the platform can route actionable errors to the right team.
    /// Present on all 4xx/5xx responses from protocol endpoints.
    /// Values: <c>user</c>, <c>platform</c>, <c>upstream</c>.
    /// </summary>
    public const string ErrorSource = "x-platform-error-source";

    /// <summary>
    /// The <c>x-platform-error-detail</c> header — internal diagnostic detail
    /// for platform telemetry. Not intended for end-user display.
    /// Present on error responses when additional diagnostic context is available.
    /// </summary>
    public const string ErrorDetail = "x-platform-error-detail";

    /// <summary>
    /// Error source value indicating the caller's input is invalid.
    /// The caller can fix the request and retry.
    /// </summary>
    public const string ErrorSourceUser = "user";

    /// <summary>
    /// Error source value indicating the error was caused by the SDK, library,
    /// or a platform dependency — not by the caller or the developer's handler.
    /// </summary>
    public const string ErrorSourcePlatform = "platform";

    /// <summary>
    /// Error source value indicating the developer's handler code or an external
    /// service it called failed or returned incorrect behaviour.
    /// </summary>
    public const string ErrorSourceUpstream = "upstream";

    /// <summary>
    /// Key used to store the resolved request ID in <see cref="Microsoft.AspNetCore.Http.HttpContext.Items"/>.
    /// Downstream filters and middleware can read this value to correlate the request ID
    /// without re-resolving it.
    /// </summary>
    public const string RequestIdItemKey = "AgentServer.RequestId";
}

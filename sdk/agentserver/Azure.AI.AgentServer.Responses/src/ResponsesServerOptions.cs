namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Configuration options for the Responses API server SDK.
/// </summary>
public class ResponsesServerOptions
{
    /// <summary>
    /// Gets or sets the interval at which SSE keep-alive comments are sent to prevent
    /// proxy/load-balancer timeouts during streaming. Default: disabled.
    /// Set to a positive <see cref="TimeSpan"/> to enable keep-alive.
    /// Can also be configured via the <c>SSE_KEEPALIVE_INTERVAL</c>
    /// environment variable (value in seconds). Programmatic configuration takes precedence.
    /// </summary>
    public TimeSpan SseKeepAliveInterval { get; set; } = Timeout.InfiniteTimeSpan;

    /// <summary>
    /// Gets or sets the default model to use when <c>model</c> is omitted from a
    /// <c>CreateResponse</c> request. When <c>null</c> and the request omits <c>model</c>,
    /// an empty string is used. Request-level <c>model</c> always takes precedence.
    /// </summary>
    public string? DefaultModel { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of conversation history items that
    /// <see cref="IResponseContext.GetHistoryAsync"/> fetches. Default: 100.
    /// Can also be configured via the <c>DEFAULT_FETCH_HISTORY_ITEM_COUNT</c>
    /// environment variable (integer value). Programmatic configuration takes precedence.
    /// </summary>
    public int DefaultFetchHistoryCount { get; set; } = DefaultFetchHistoryCountValue;

    /// <summary>
    /// Gets or sets an additional identity value to append to the <c>x-platform-server</c>
    /// response header. When set, the SDK appends the value using a <c>; </c> separator
    /// (e.g., <c>azure-ai-agentserver-responses/0.1.0-preview (dotnet/8.0); my-app/1.0</c>).
    /// Default: <c>null</c> (no additional identity).
    /// </summary>
    public string? AdditionalServerIdentity { get; set; }

    /// <summary>
    /// The default value for <see cref="DefaultFetchHistoryCount"/>.
    /// </summary>
    internal const int DefaultFetchHistoryCountValue = 100;
}

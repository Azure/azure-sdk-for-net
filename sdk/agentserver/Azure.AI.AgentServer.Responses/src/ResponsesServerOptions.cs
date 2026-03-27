// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Configuration options for the Responses API server SDK.
/// </summary>
public class ResponsesServerOptions
{
    /// <summary>
    /// Gets or sets the default model to use when <c>model</c> is omitted from a
    /// <c>CreateResponse</c> request. When <c>null</c> and the request omits <c>model</c>,
    /// an empty string is used. Request-level <c>model</c> always takes precedence.
    /// </summary>
    public string? DefaultModel { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of conversation history items that
    /// <see cref="ResponseContext.GetHistoryAsync"/> fetches. Default: 100.
    /// Can also be configured via the <c>DEFAULT_FETCH_HISTORY_ITEM_COUNT</c>
    /// environment variable (integer value). Programmatic configuration takes precedence.
    /// </summary>
    public int DefaultFetchHistoryCount { get; set; } = DefaultFetchHistoryCountValue;

    /// <summary>
    /// The default value for <see cref="DefaultFetchHistoryCount"/>.
    /// </summary>
    internal const int DefaultFetchHistoryCountValue = 100;
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Represents error details for streaming scenarios.
/// </summary>
internal class StreamingErrorInfo
{
    public string Error { get; set; } = string.Empty;
}

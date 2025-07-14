// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Configuration options for test recording sessions.
/// </summary>
public class TestRecordingOptions
{
    /// <summary>
    /// Gets the list of headers that will be sanitized in recordings.
    /// </summary>
    public List<string> SanitizedHeaders { get; set; } = new();

    /// <summary>
    /// Gets the list of query parameters that will be sanitized in recordings.
    /// </summary>
    public List<string> SanitizedQueryParameters { get; set; } = new();

    /// <summary>
    /// Gets the list of JSON paths that will be sanitized in request/response bodies.
    /// </summary>
    public List<string> JsonPathSanitizers { get; set; } = new();

    /// <summary>
    /// Gets the list of headers whose values can change between recording and playback
    /// without causing request matching to fail.
    /// </summary>
    public List<string> IgnoredHeaders { get; set; } = new()
    {
        "Date",
        "User-Agent",
        "Request-Id"
    };

    /// <summary>
    /// Gets the list of query parameters whose values can change between recording and playback
    /// without causing URI matching to fail.
    /// </summary>
    public List<string> IgnoredQueryParameters { get; set; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether to compare request and response bodies during playback.
    /// </summary>
    public bool CompareBodies { get; set; } = true;
}
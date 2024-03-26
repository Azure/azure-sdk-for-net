// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Options;

/// <summary>
/// TODO.
/// </summary>
public class ClientDiagnosticsOptions
{
    /// <summary>
    /// Creates a new instance of <see cref="ClientDiagnosticsOptions"/>.
    /// </summary>
    public ClientDiagnosticsOptions()
    {
        LoggedHeaderNames = new List<string>()
        {
            "x-client-request-id",
            "traceparent",
            "MS-CV",
            "Accept",
            "Cache-Control",
            "Connection",
            "Content-Length",
            "Content-Type",
            "Date",
            "ETag",
            "Expires",
            "If-Match",
            "If-Modified-Since",
            "If-None-Match",
            "If-Unmodified-Since",
            "Last-Modified",
            "Pragma",
            "Request-Id",
            "Retry-After",
            "Server",
            "Transfer-Encoding",
            "User-Agent",
            "WWW-Authenticate" // OAuth Challenge header.
        };
        LoggedQueryParameters = new List<string> { "api-version" };
    }

    /// <summary>
    /// Get or sets value indicating whether HTTP pipeline logging is enabled.
    /// </summary>
    public bool IsLoggingEnabled { get; set; } = true;

    /// <summary>
    /// Gets or sets value indicating if request or response content should be logged.
    /// </summary>
    public bool IsLoggingContentEnabled { get; set; }

    /// <summary>
    /// Gets or sets value indicating maximum size of content to log in bytes. Defaults to 4096.
    /// </summary>
    public int LoggedContentSizeLimit { get; set; } = 4 * 1024;

    /// <summary>
    /// Gets or sets value indicating the known header name for the client request ID to use with logging.
    /// If one is not provided, a request Id will not be logged.
    /// </summary>
    public string ClientRequestIdHeaderName { get; set; } = "x-client-request-id";

    /// <summary>
    /// Gets a list of header names that are not redacted during logging.
    /// </summary>
    public IList<string> LoggedHeaderNames { get; internal set; }

    /// <summary>
    /// Gets a list of query parameter names that are not redacted during logging.
    /// </summary>
    public IList<string> LoggedQueryParameters { get; internal set; } = new List<string> { "api-version" };
}

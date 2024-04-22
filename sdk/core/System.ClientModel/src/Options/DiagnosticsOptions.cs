// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Options;

/// <summary>
/// TODO
/// </summary>
public class DiagnosticsOptions
{
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
    /// Gets or sets a list of header names that are not redacted during logging.
    /// </summary>
    public IEnumerable<string>? LoggedHeaderNames { get; set; }

    /// <summary>
    /// Gets or sets a list of query parameter names that are not redacted during logging.
    /// </summary>
    public IEnumerable<string>? LoggedQueryParameters { get; set; }

    /// <summary>
    /// Gets or sets the name of the client assembly to include in logging.
    /// </summary>
    public string? LoggedClientAssemblyName { get; set; }

    /// <summary>
    /// Gets or sets the header name that contains the request Id to include in logging.
    /// </summary>
    public string? RequestIdHeaderName { get; set; }
}

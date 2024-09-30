// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class DiagnosticOptions
{
    public DiagnosticOptions()
    {
    }

    public IList<string> AllowedHeaderNames { get => throw new NotImplementedException(); }
    public IList<string> AllowedQueryParameters { get => throw new NotImplementedException(); }

    // Client-scope
    public bool? EnableLogging { get; set; }

    // Http request/response logging only
    public bool? EnableHttpLogging { get; set; }

    // Request and response content
    public bool? EnableHttpContentLogging { get; set; }

    public int? HttpContentSizeLimit { get; set; }

    public ILoggerFactory? LoggerFactory { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

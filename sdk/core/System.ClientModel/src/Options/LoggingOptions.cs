// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class LoggingOptions
{
    public LoggingOptions()
    {
        AllowedHeaderNames = new List<string>()
        {
            "Content-Length",
            "Content-Type"
        };

        AllowedQueryParameters = new List<string>()
        {
            "api-version"
        };
    }

    public IList<string> AllowedHeaderNames { get; }
    public IList<string> AllowedQueryParameters { get; }

    // Client-scope
    public bool? EnableLogging { get; set; }

    // Http request/response logging only
    // TODO: We can add it later.
    //public bool? EnableHttpLogging { get; set; }

    // Request and response content
    public bool? EnableHttpContentLogging { get; set; }

    public int? HttpContentSizeLimit { get; set; }

    public ILoggerFactory? LoggerFactory { get; set; }

    internal void Freeze()
    {
        // TODO: Make freezable
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

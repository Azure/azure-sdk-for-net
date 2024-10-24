// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ClientLoggingOptions
{
    private readonly List<string> _allowedQueryParameters;
    private readonly List<string> _allowedHeaderNames;

    private PipelineMessageSanitizer? _sanitizer;

    public ClientLoggingOptions()
    {
        _allowedQueryParameters = new List<string>();
        _allowedHeaderNames = new List<string>();
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public ILoggerFactory? LoggerFactory { get; set; }

    public IList<string> AllowedQueryParameters => _allowedQueryParameters;
    public IList<string> AllowedHeaderNames => _allowedHeaderNames;

    internal PipelineMessageSanitizer GetSanitizer()
    {
        //if (_frozen == false)
        //{
        //    throw new InvalidOperationException("Cannot create the pipeline message sanitizer until the ClientPipelineOptions instance has been frozen.");
        //}

        return _sanitizer ??= new(_allowedQueryParameters.ToArray(), _allowedHeaderNames.ToArray());
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

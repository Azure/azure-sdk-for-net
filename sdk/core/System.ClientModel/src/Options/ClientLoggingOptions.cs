// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ClientLoggingOptions
{
    // TODO: implement freezing
    private bool _frozen;

    private bool? _enableLogging;

    private ChangeTrackingStringList _allowedHeaderNames;
    private ChangeTrackingStringList _allowedQueryParameters;

    public ClientLoggingOptions()
    {
        _allowedHeaderNames = new ChangeTrackingStringList
        {
            "Content-Type",
            "Content-Length"
        };
        _allowedHeaderNames.StartTracking();

        _allowedQueryParameters = new ChangeTrackingStringList
        {
            "api-verstion"
        };
        _allowedQueryParameters.StartTracking();
    }

    public IList<string> AllowedHeaderNames
    {
        get => _allowedHeaderNames;
    }

    public IList<string> AllowedQueryParameters
    {
        get => _allowedQueryParameters;
    }

    // Client-scope logging
    public bool? EnableLogging
    {
        get => _enableLogging;
        set
        {
            AssertNotFrozen();

            _enableLogging = value;
        }
    }

    // Message request/response logging only
    public bool? EnableMessageLogging { get; set; }

    // Request and response content
    public bool? EnableMessageContentLogging { get; set; }

    public int? MessageContentSizeLimit { get; set; }

    public ILoggerFactory? LoggerFactory { get; set; }

    public virtual void Freeze() => _frozen = true;

    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a ClientObservabilityOptions instance after ClientPipeline has been created.");
        }
    }

    internal bool IsDefault()
    {
        return EnableLogging is null &&
            EnableMessageLogging is null &&
            EnableMessageContentLogging is null &&
            MessageContentSizeLimit is null &&
            LoggerFactory is null &&
            !_allowedHeaderNames.HasChanged &&
            !_allowedQueryParameters.HasChanged;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

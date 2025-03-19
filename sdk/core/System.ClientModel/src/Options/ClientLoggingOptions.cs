// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Primitives;

/// <summary>
/// Exposes client options for logging within a <see cref="ClientPipeline"/>.
/// </summary>
public class ClientLoggingOptions
{
    private bool _frozen;

    private bool? _enableLogging;
    private bool? _enableMessageLogging;
    private bool? _enableMessageContentLogging;
    private int? _messageContentSizeLimit;
    private ILoggerFactory? _loggerFactory;
    private PipelineMessageSanitizer? _sanitizer;
    private ChangeTrackingStringList? _allowedHeaderNames;
    private ChangeTrackingStringList? _allowedQueryParameters;

    // These values are similar to the default values in Azure.Core.DiagnosticsOptions and both
    // should be kept in sync. When updating, update the default values in both classes.
    private static readonly HashSet<string> s_defaultAllowedHeaderNames = ["traceparent",
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
                                                                          "Retry-After",
                                                                          "Server",
                                                                          "Transfer-Encoding",
                                                                          "User-Agent",
                                                                          "WWW-Authenticate" ];
    private static readonly HashSet<string> s_defaultAllowedQueryParameters = ["api-version"];
    private static readonly PipelineMessageSanitizer s_defaultSanitizer = new(s_defaultAllowedQueryParameters, s_defaultAllowedHeaderNames);

    internal const bool DefaultEnableLogging = true;
    internal const bool DefaultEnableMessageContentLogging = false;
    internal const int DefaultMessageContentSizeLimitBytes = 4 * 1024;
    internal const double RequestTooLongSeconds = 3.0; // sec

    /// <summary>
    /// Gets or sets the implementation of <see cref="ILoggerFactory"/> to use to
    /// create <see cref="ILogger"/> instances for logging.
    /// </summary>
    /// <remarks>If an ILoggerFactory is not provided, logs will be written to Event Source
    /// instead. If an ILoggerFactory is provided, logs will be written to ILogger only and not
    /// Event Source.</remarks>
    /// <value>Defaults to <see cref="NullLoggerFactory"/>.</value>
    public ILoggerFactory? LoggerFactory
    {
        get => _loggerFactory;
        set
        {
            AssertNotFrozen();

            _loggerFactory = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating if logging should be enabled in this client pipeline.
    /// </summary>
    /// <value>Defaults to <c>null</c>. If <c>null</c>, this value will be treated as <c>true</c>.</value>
    public bool? EnableLogging
    {
        get => _enableLogging;
        set
        {
            AssertNotFrozen();

            _enableLogging = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating if request and response uri and header information should be logged.
    /// </summary>
    /// <value>Defaults to <c>null</c>. If <c>null</c>, the value
    /// of <see cref="EnableLogging"/> will be used instead.</value>
    public bool? EnableMessageLogging
    {
        get => _enableMessageLogging;
        set
        {
            AssertNotFrozen();

            _enableMessageLogging = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating if request and response content should be logged.
    /// </summary>
    /// <value>Defaults to <c>null</c>. If <c>null</c>, this value will be treated as <c>false</c>.</value>
    public bool? EnableMessageContentLogging
    {
        get => _enableMessageContentLogging;
        set
        {
            AssertNotFrozen();

            _enableMessageContentLogging = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating maximum size of content to log in bytes.
    /// </summary>
    /// <value>Defaults to <c>null</c>. If <c>null</c>, this value will be treated as </value>
    public int? MessageContentSizeLimit
    {
        get => _messageContentSizeLimit;
        set
        {
            AssertNotFrozen();

            _messageContentSizeLimit = value;
        }
    }

    /// <summary>
    /// Gets or sets a list of header names that are not redacted during logging.
    /// </summary>
    /// <value>Defaults to a list of common header names that do not
    /// typically hold sensitive information.</value>
    public IList<string> AllowedHeaderNames
    {
        get
        {
            if (!_frozen)
            {
                if (_allowedHeaderNames is null)
                {
                    var changeList = new ChangeTrackingStringList(s_defaultAllowedHeaderNames);
                    _allowedHeaderNames = changeList;
                }
                return _allowedHeaderNames;
            }
            else
            {
                if (_allowedHeaderNames is null)
                {
                    // If this instance is frozen still allow read-only access to the defaults by
                    // creating a copy of the default allowed headers and freezing it. This
                    // avoids copying the default array and allocating the change tracking list unless necessary.
                    _allowedHeaderNames = new ChangeTrackingStringList(s_defaultAllowedHeaderNames);
                    _allowedHeaderNames.Freeze();
                }
                return _allowedHeaderNames;
            }
        }
    }

    /// <summary>
    /// Gets or sets a list of query parameter names that are not redacted during logging.
    /// </summary>
    /// <value>Defaults to a list of common query parameters that do not
    /// typically hold sensitive information.</value>
    public IList<string> AllowedQueryParameters
    {
        get
        {
            if (!_frozen)
            {
                if (_allowedQueryParameters is null)
                {
                    var changeList = new ChangeTrackingStringList(s_defaultAllowedQueryParameters);
                    _allowedQueryParameters = changeList;
                }
                return _allowedQueryParameters;
            }
            else
            {
                if (_allowedQueryParameters is null)
                {
                    // If this instance is frozen still allow read-only access to the defaults by
                    // creating a copy of the default allowed query parameters and freezing it. This
                    // avoids copying the default array and allocating the change tracking list unless necessary.
                    _allowedQueryParameters = new ChangeTrackingStringList(s_defaultAllowedQueryParameters);
                    _allowedQueryParameters.Freeze();
                }
                return _allowedQueryParameters;
            }
        }
    }

    /// <summary>
    /// Freeze this instance of <see cref="ClientLoggingOptions"/>.  After this method
    /// has been called, any attempt to set properties on the instance or call
    /// methods that would change its state will throw <see cref="InvalidOperationException"/>.
    /// </summary>
    public virtual void Freeze()
    {
        _frozen = true;
        if (_allowedHeaderNames is not null)
        {
            _allowedHeaderNames.Freeze();
        }
        if (_allowedQueryParameters is not null)
        {
            _allowedQueryParameters.Freeze();
        }
    }

    /// <summary>
    /// Assert that <see cref="Freeze"/> has not been called on this
    /// <see cref="ClientLoggingOptions"/> instance.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when an attempt is
    /// made to change the state of this <see cref="ClientLoggingOptions"/> instance
    /// after <see cref="Freeze"/> has been called.</exception>
    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a ClientLoggingOptions instance after the ClientPipeline is created.");
        }
    }

    internal void ValidateOptions()
    {
        if (EnableLogging == false
            && (EnableMessageLogging == true || EnableMessageContentLogging == true))
        {
            throw new InvalidOperationException("HTTP Message logging cannot be enabled when client-wide logging is disabled.");
        }
        if (EnableMessageLogging == false
            && EnableMessageContentLogging == true)
        {
            throw new InvalidOperationException("HTTP Message content logging cannot be enabled when HTTP message logging is disabled.");
        }
    }

    internal PipelineMessageSanitizer GetPipelineMessageSanitizer()
    {
        if (HeaderListIsDefault && QueryParameterListIsDefault)
        {
            return s_defaultSanitizer;
        }
        HashSet<string> headers = _allowedHeaderNames == null ? s_defaultAllowedHeaderNames : new HashSet<string>(_allowedHeaderNames, StringComparer.InvariantCultureIgnoreCase);
        HashSet<string> queryParams = _allowedQueryParameters == null ? s_defaultAllowedQueryParameters : new HashSet<string>(_allowedQueryParameters, StringComparer.InvariantCultureIgnoreCase);

        _sanitizer ??= new PipelineMessageSanitizer(queryParams, headers);

        return _sanitizer;
    }

    internal bool AddMessageLoggingPolicy => EnableMessageLogging ?? EnableLogging ?? DefaultEnableLogging;

    internal bool UseDefaultClientWideLogging => LoggerFactory == null
                                                 && EnableLogging == null;

    internal bool AddDefaultMessageLoggingPolicy => EnableLogging == null
                                                    && MessageContentSizeLimit == null
                                                    && EnableMessageLogging == null
                                                    && EnableMessageContentLogging == null
                                                    && LoggerFactory == null
                                                    && HeaderListIsDefault
                                                    && QueryParameterListIsDefault;

    private bool HeaderListIsDefault => _allowedHeaderNames == null || !_allowedHeaderNames.HasChanged;
    private bool QueryParameterListIsDefault => _allowedQueryParameters == null || !_allowedQueryParameters.HasChanged;
}

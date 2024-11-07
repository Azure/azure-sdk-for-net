// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    private bool? _allowedHeaderNamesHasChanged;
    private bool? _allowedQueryParametersHasChanged;
    private IList<string>? _allowedHeaderNames;
    private IList<string>? _allowedQueryParameters;

    internal const bool DefaultEnableLogging = true;
    internal const bool DefaultEnableMessageContentLogging = false;

    internal const double RequestTooLongSeconds = 3.0; // sec
    internal const int DefaultMessageContentSizeLimit = 4 * 1024;
    internal static string[] DefaultAllowedHeaderNames { get; } = new[] {
            "traceparent",
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
            "WWW-Authenticate" };

    internal static string[] DefaultAllowedQueryParameters { get; } = new[] { "api-version" };

    internal static PipelineMessageSanitizer DefaultSanitizer { get; } = new(DefaultAllowedHeaderNames, DefaultAllowedQueryParameters);

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
    /// Gets or sets value indicating if request and response content should be logged.
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
    public IList<string> AllowedHeaderNames // TODO
    {
        get
        {
            if (!_frozen)
            {
                return _allowedHeaderNames ??= new ChangeTrackingStringList(DefaultAllowedHeaderNames);
            }
            else
            {
                return _allowedHeaderNames ??= new ReadOnlyCollection<string>(DefaultAllowedHeaderNames);
            }
        }
    }

    /// <summary>
    /// Gets or sets a list of query parameter names that are not redacted during logging.
    /// </summary>
    /// <value>Defaults to a list of common query parameters that do not
    /// typically hold sensitive information.</value>
    public IList<string> AllowedQueryParameters // TODO
    {
        get
        {
            if (!_frozen)
            {
                return _allowedQueryParameters ??= new ChangeTrackingStringList(DefaultAllowedQueryParameters);
            }
            else
            {
                return _allowedQueryParameters ??= new ReadOnlyCollection<string>(DefaultAllowedQueryParameters);
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
            ChangeTrackingStringList? headersChangeTracking = _allowedHeaderNames as ChangeTrackingStringList;

            // Set the property to readonly before checking HasChanged
            _allowedHeaderNames = new ReadOnlyCollection<string>(_allowedHeaderNames);
            _allowedHeaderNamesHasChanged = headersChangeTracking?.HasChanged;
        }
        if (_allowedQueryParameters is not null)
        {
            ChangeTrackingStringList? queryParamsChangeTracking = _allowedQueryParameters as ChangeTrackingStringList;

            // Set the property to readonly before checking HasChanged
            _allowedQueryParameters = new ReadOnlyCollection<string>(_allowedQueryParameters);
            _allowedQueryParametersHasChanged = queryParamsChangeTracking?.HasChanged;
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
            throw new InvalidOperationException("Cannot change a MessageLoggingPolicyOptions instance after the ClientPipeline is created.");
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
        if (EnableLogging == false && LoggerFactory != null) // TODO
        {
            throw new InvalidOperationException("An ILoggerFactory cannot be set if client-wide logging is disabled.");
        }

        // TODO - throw if content size is set but content logging is false?

        // TODO - throw if allowed header names or allowed query parameters were changed?
    }

    internal PipelineMessageSanitizer GetPipelineMessageSanitizer()
    {
        string[] headers = _allowedHeaderNames == null ? DefaultAllowedHeaderNames : _allowedHeaderNames.ToArray();
        string[] queryParams = _allowedQueryParameters == null ? DefaultAllowedQueryParameters : _allowedQueryParameters.ToArray();

        _sanitizer ??= new PipelineMessageSanitizer(headers, queryParams);

        return _sanitizer;
    }

    internal bool ShouldAddMessageLoggingPolicy()
    {
        return EnableMessageLogging ?? EnableLogging ?? DefaultEnableLogging;
    }

    internal bool ShouldUseDefaultMessageLoggingPolicy()
    {
        return _enableLogging == null
            && _messageContentSizeLimit == null
            && _enableMessageLogging == null
            && _enableMessageContentLogging == null
            && _loggerFactory == null
            && _allowedHeaderNamesHasChanged != true // false or null
            && _allowedQueryParametersHasChanged != true; // false or null
    }

    internal bool ShouldUseDefaultPipelineTransport()
    {
        return LoggerFactory == null && (EnableLogging == null || EnableLogging == DefaultEnableLogging);
    }

    internal bool ShouldUseDefaultRetryPolicy() => ShouldUseDefaultPipelineTransport();
}

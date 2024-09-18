// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Primitives;

/// <summary>
/// Exposes client options related to logging.
/// </summary>
public class LoggingOptions
{
    private bool _frozen;

    private const int DefaultLoggedContentSizeLimit = 4 * 1024;
    private const bool DefaultIsLoggingContentEnabled = false;
    private const bool DefaultCombineLogs = true;

    private static readonly string[] s_defaultAllowedHeaderNames =
        new[] {
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
    private static readonly string[] s_defaultAllowedQueryParameters = new[] { "api-version" };

    private int _loggedContentSizeLimit = DefaultLoggedContentSizeLimit;
    private bool _isLoggingContentEnabled = DefaultIsLoggingContentEnabled;
    private IList<string> _allowedHeaderNames = new List<string>(s_defaultAllowedHeaderNames);
    private IList<string> _allowedQueryParameters = new List<string>(s_defaultAllowedQueryParameters);
    private ILoggerFactory _loggerFactory = NullLoggerFactory.Instance;

    /// <summary>
    /// Gets or sets the implementation of <see cref="ILoggerFactory"/> to use to
    /// create <see cref="ILogger"/> instances for logging.
    /// </summary>
    /// <remarks>If an ILoggerFactory is not provided, logs will be written to Event Source
    /// instead. If an ILoggerFactory is provided, logs will be written to ILogger only and not
    /// Event Source.</remarks>
    /// <value>Defaults to <see cref="NullLoggerFactory"/>.</value>
    public ILoggerFactory LoggerFactory
    {
        get => _loggerFactory;
        set
        {
            AssertNotFrozen();

            _loggerFactory = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating if any logs should be written from this library.
    /// </summary>
    /// <value>Defaults to <c>false</c>.</value>
    public bool IsClientLoggingEnabled
    {
        get => _isLoggingContentEnabled;
        set
        {
            AssertNotFrozen();

            _isLoggingContentEnabled = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating if HTTP requests and responses
    /// should be logged.
    /// </summary>
    /// <value>Defaults to <c>false</c>.</value>
    public bool IsHttpMessageLoggingEnabled
    {
        get => _isLoggingContentEnabled;
        set
        {
            AssertNotFrozen();

            _isLoggingContentEnabled = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating if request and response content should be logged.
    /// </summary>
    /// <value>Defaults to <c>false</c>.</value>
    public bool IsHttpMessageBodyLoggingEnabled
    {
        get => _isLoggingContentEnabled;
        set
        {
            AssertNotFrozen();

            _isLoggingContentEnabled = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating maximum size of body size to log in bytes.
    /// </summary>
    /// <value>Defaults to <c>4096</c></value>
    public int HttpMessageBodyLogLimit
    {
        get => _loggedContentSizeLimit;
        set
        {
            AssertNotFrozen();

            _loggedContentSizeLimit = value;
        }
    }

    /// <summary>
    /// Gets or sets a list of header names that are not redacted during logging.
    /// </summary>
    /// <value>Defaults to a list of common header names that do not
    /// typically hold sensitive information.</value>
    public IList<string> AllowedHeaderNames
    {
        get => _allowedHeaderNames;
    }

    /// <summary>
    /// Gets or sets a list of query parameter names that are not redacted during logging.
    /// </summary>
    /// <value>Defaults to a list of common query parameters that do not
    /// typically hold sensitive information.</value>
    public IList<string> AllowedQueryParameters
    {
        get => _allowedQueryParameters;
    }

    /// <summary>
    /// Freeze this instance of <see cref="LoggingOptions"/>.  After this method
    /// has been called, any attempt to set properties on the instance or call
    /// methods that would change its state will throw <see cref="InvalidOperationException"/>.
    /// </summary>
    public virtual void Freeze()
    {
        _frozen = true;
        _allowedHeaderNames = new ReadOnlyCollection<string>(_allowedHeaderNames);
        _allowedQueryParameters = new ReadOnlyCollection<string>(_allowedQueryParameters);
    }

    /// <summary>
    /// Assert that <see cref="Freeze"/> has not been called on this
    /// <see cref="LoggingOptions"/> instance.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when an attempt is
    /// made to change the state of this <see cref="LoggingOptions"/> instance
    /// after <see cref="Freeze"/> has been called.</exception>
    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a LoggingOptions instance after the ClientPipeline is created.");
        }
    }
}

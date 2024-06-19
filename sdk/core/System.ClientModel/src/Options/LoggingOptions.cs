// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Primitives;

/// <summary>
/// TODO
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
    private bool _combineLogs = DefaultCombineLogs;
    private ILoggerFactory _loggerFactory = NullLoggerFactory.Instance;

    /// <summary>
    /// TODO.
    /// </summary>
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
    /// Gets or sets value indicating if request or response content should be logged.
    /// </summary>
    public bool IsLoggingContentEnabled
    {
        get => _isLoggingContentEnabled;
        set
        {
            AssertNotFrozen();

            _isLoggingContentEnabled = value;
        }
    }

    /// <summary>
    /// Gets or sets value indicating maximum size of content to log in bytes. Defaults to 4096.
    /// </summary>
    public int LoggedContentSizeLimit
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
    public IList<string> AllowedHeaderNames
    {
        get => _allowedHeaderNames;
    }

    /// <summary>
    /// Gets or sets a list of query parameter names that are not redacted during logging.
    /// </summary>
    public IList<string> AllowedQueryParameters
    {
        get => _allowedQueryParameters;
    }

    /// <summary>
    /// Gets or sets the header name that contains the request Id to include in logging.
    /// </summary>
    public bool CombineLogs
    {
        get => _combineLogs;
        set
        {
            AssertNotFrozen();

            _combineLogs = value;
        }
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

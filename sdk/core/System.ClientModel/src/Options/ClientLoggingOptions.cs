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
    private ChangeTrackingStringList? _allowedHeaderNamesTrackingList;
    private ChangeTrackingStringList? _allowedQueryParametersTrackingList;
    private IList<string> _allowedHeaderNames = new ChangeTrackingStringList(ClientPipelineOptions.DefaultAllowedHeaderNames);
    private IList<string> _allowedQueryParameters = new ChangeTrackingStringList(ClientPipelineOptions.DefaultAllowedQueryParameters);

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
    /// Gets or sets value indicating if request and response content should be logged.
    /// </summary>
    /// <value>Defaults to <c>false</c>.</value>
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
    /// <value>Defaults to the value of <see cref="EnableLogging"/>.</value>
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
    /// <value>Defaults to <c>false</c>.</value>
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
    /// Freeze this instance of <see cref="ClientLoggingOptions"/>.  After this method
    /// has been called, any attempt to set properties on the instance or call
    /// methods that would change its state will throw <see cref="InvalidOperationException"/>.
    /// </summary>
    public virtual void Freeze()
    {
        _frozen = true;
        _allowedHeaderNamesTrackingList = (ChangeTrackingStringList)_allowedHeaderNames;
        _allowedQueryParametersTrackingList = (ChangeTrackingStringList)_allowedQueryParameters;
        _allowedHeaderNames = new ReadOnlyCollection<string>(_allowedHeaderNames);
        _allowedQueryParameters = new ReadOnlyCollection<string>(_allowedQueryParameters);
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

    internal PipelineMessageSanitizer GetPipelineMessageSanitizer()
    {
        if (_frozen == false)
        {
            throw new InvalidOperationException("Cannot create the pipeline message sanitizer until the ClientPipelineOptions instance has been frozen.");
        }

        _sanitizer ??= new PipelineMessageSanitizer(AllowedQueryParameters.ToArray(), AllowedHeaderNames.ToArray());

        return _sanitizer;
    }

    internal bool UseDefaultLogging()
    {
        if (_frozen == false)
        {
            throw new InvalidOperationException("Cannot determine if the default policy should be used until the ClientPipelineOptions instance has been frozen.");
        }

        return _enableLogging == null
            && _messageContentSizeLimit == null
            && _enableMessageLogging == null
            && _enableMessageContentLogging == null
            && _loggerFactory == null
            && _allowedHeaderNamesTrackingList?.HasChanged == false
            && _allowedQueryParametersTrackingList?.HasChanged == false;
    }
}

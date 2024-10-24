// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

/// <summary>
/// Options that control the creation of a <see cref="ClientPipeline"/> used
/// by a service client to send and receive HTTP messages.
/// Service clients must create a client-specific subtype of this class
/// to pass to their constructors to allow for service-specific options
/// with a client-wide scope.
/// </summary>
public class ClientPipelineOptions
{
    private static readonly ClientPipelineOptions _defaultOptions = new();
    internal static ClientPipelineOptions Default => _defaultOptions;

    private bool _frozen;

    private PipelinePolicy? _retryPolicy;
    private PipelinePolicy? _loggingPolicy;
    private PipelineTransport? _transport;
    private TimeSpan? _timeout;
    private int? _messageContentSizeLimit;
    private bool? _enableMessageContentLogging;
    private bool? _enableLogging;
    private bool? _enableMessageLogging;
    private TrackingList<string>? _allowedHeaderNamesTrackingList;
    private TrackingList<string>? _allowedQueryParametersTrackingList;
    private IList<string> _allowedHeaderNames = new TrackingList<string>(s_defaultAllowedHeaderNames);
    private IList<string> _allowedQueryParameters = new TrackingList<string>(s_defaultAllowedQueryParameters);
    private ILoggerFactory? _loggerFactory;
    private PipelineMessageSanitizer? _sanitizer;

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

    #region Pipeline creation: Overrides of default pipeline policies

    /// <summary>
    /// Gets or sets the <see cref="PipelinePolicy"/> to be used by the
    /// <see cref="ClientPipeline"/> for handling retry logic.
    /// </summary>
    /// <remarks>
    /// In most cases, this property will be set to an instance of
    /// <see cref="ClientRetryPolicy"/>.
    /// </remarks>
    public PipelinePolicy? RetryPolicy
    {
        get => _retryPolicy;
        set
        {
            AssertNotFrozen();

            _retryPolicy = value;
        }
    }

    /// <summary>
    /// Gets or sets the <see cref="PipelinePolicy"/> to be used by the
    /// <see cref="ClientPipeline"/> for logging.
    /// </summary>
    /// <remarks>
    /// In most cases, this property will be set to an instance of
    /// <see cref="MessageLoggingPolicy"/>.
    /// </remarks>
    public PipelinePolicy? MessageLoggingPolicy
    {
        get => _loggingPolicy;
        set
        {
            AssertNotFrozen();

            _loggingPolicy = value;
        }
    }

    /// <summary>
    /// Gets or sets the <see cref="PipelineTransport"/> to be used by the
    /// <see cref="ClientPipeline"/> for sending and receiving HTTP messages.
    /// </summary>
    /// <remarks>
    /// In most cases, this property will be set to an instance of
    /// <see cref="HttpClientPipelineTransport"/>.
    /// </remarks>
    public PipelineTransport? Transport
    {
        get => _transport;
        set
        {
            AssertNotFrozen();

            _transport = value;
        }
    }

    #endregion

    #region Pipeline creation: Policy settings

    /// <summary>
    /// The timeout applied to an individual network operation.
    /// </summary>
    public TimeSpan? NetworkTimeout
    {
        get => _timeout;
        set
        {
            AssertNotFrozen();

            _timeout = value;
        }
    }

    /// <summary>
    /// Gets or sets the implementation of <see cref="ILoggerFactory"/> to use to
    /// create <see cref="ILogger"/> instances for logging.
    /// </summary>
    /// <remarks>If an ILoggerFactory is not provided, logs will be written to Event Source
    /// instead. If an ILoggerFactory is provided, logs will be written to ILogger only and not
    /// Event Source.</remarks>
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
    /// Gets or sets value indicating if request and response content should be logged.
    /// </summary>
    /// <value>Defaults to <c>false</c>.</value>
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

    #endregion

    #region Defaults

    internal PipelineMessageSanitizer GetPipelineMessageSanitizer()
    {
        if (_frozen == false)
        {
            throw new InvalidOperationException("Cannot create the pipeline message sanitizer until the ClientPipelineOptions instance has been frozen.");
        }

        _sanitizer ??= new PipelineMessageSanitizer(((List<string>)_allowedQueryParameters).ToArray(), ((List<string>)_allowedHeaderNames).ToArray());

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

    #endregion

    #region Pipeline creation: User-specified policies

    internal PipelinePolicy[]? PerCallPolicies { get; set; }

    internal PipelinePolicy[]? PerTryPolicies { get; set; }

    internal PipelinePolicy[]? BeforeTransportPolicies { get; set; }

    /// <summary>
    /// Adds the provided <see cref="PipelinePolicy"/> to the default
    /// <see cref="ClientPipeline"/>.
    /// </summary>
    /// <param name="policy">The <see cref="PipelinePolicy"/> to add to the
    /// pipeline.</param>
    /// <param name="position">The position of the policy in the pipeline.</param>
    /// <exception cref="ArgumentException">Thrown when the provided policy
    /// is <c>null</c>.</exception>
    /// <remarks>
    /// For a policy to run once per invocation of
    /// <see cref="ClientPipeline.Send(PipelineMessage)"/>, use
    /// <see cref="PipelinePosition.PerCall"/>, which will insert the policy
    /// before the pipeline's <see cref="RetryPolicy"/>. For a policy to run
    /// once per retry attempt, use <see cref="PipelinePosition.PerTry"/>, which
    /// will insert the policy after the pipeline's <see cref="RetryPolicy"/>.
    /// To ensure that a policy runs after all other policies in the pipeline
    /// have viewed the <see cref="PipelineMessage.Request"/> and before all
    /// other policies view the <see cref="PipelineMessage.Response"/>, use
    /// <see cref="PipelinePosition.BeforeTransport"/>. Changes made to
    /// <see cref="PipelineMessage.Request"/> by a before-transport policy will
    /// not be visible to any logging policies that come before it in the
    /// pipeline.
    /// </remarks>
    public void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        Argument.AssertNotNull(policy, nameof(policy));
        AssertNotFrozen();

        switch (position)
        {
            case PipelinePosition.PerCall:
                PerCallPolicies = AddPolicy(policy, PerCallPolicies);
                break;
            case PipelinePosition.PerTry:
                PerTryPolicies = AddPolicy(policy, PerTryPolicies);
                break;
            case PipelinePosition.BeforeTransport:
                BeforeTransportPolicies = AddPolicy(policy, BeforeTransportPolicies);
                break;
            default:
                throw new ArgumentException($"Unexpected value for position: '{position}'.");
        }
    }

    internal static PipelinePolicy[] AddPolicy(PipelinePolicy policy, PipelinePolicy[]? policies)
    {
        if (policies is null)
        {
            policies = new PipelinePolicy[1];
        }
        else
        {
            PipelinePolicy[] policiesProperty = new PipelinePolicy[policies.Length + 1];
            policies.CopyTo(policiesProperty.AsSpan());
            policies = policiesProperty;
        }

        policies[policies.Length - 1] = policy;
        return policies;
    }

    #endregion

    /// <summary>
    /// Freeze this instance of <see cref="ClientPipelineOptions"/>.  After
    /// this method has been called, any attempt to set properties on the
    /// instance or call methods that would change its state will throw
    /// <see cref="InvalidOperationException"/>.
    /// </summary>
    public virtual void Freeze()
    {
        _frozen = true;
        _allowedHeaderNamesTrackingList = (TrackingList<string>)_allowedHeaderNames;
        _allowedQueryParametersTrackingList = (TrackingList<string>)_allowedQueryParameters;
        _allowedHeaderNames = new ReadOnlyCollection<string>(_allowedHeaderNames);
        _allowedQueryParameters = new ReadOnlyCollection<string>(_allowedQueryParameters);
    }

    /// <summary>
    /// Assert that <see cref="Freeze"/> has not been called on this
    /// <see cref="ClientPipelineOptions"/> instance.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when an attempt is
    /// made to change the state of this <see cref="ClientPipelineOptions"/>
    /// instance after <see cref="Freeze"/> has been called.</exception>
    protected void AssertNotFrozen()
    {
        if (_frozen)
        {
            throw new InvalidOperationException("Cannot change a ClientPipelineOptions instance after it has been used to create a ClientPipeline.");
        }
    }
}

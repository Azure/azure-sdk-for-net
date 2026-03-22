// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// A lightweight wrapper around <see cref="Activity"/> that provides a consistent
/// pattern for creating, starting, and completing diagnostic scopes in client libraries.
/// </summary>
/// <remarks>
/// This struct is intended to be used by client library authors only.
/// Applications should use the System.Diagnostics package directly for custom tracing.
/// </remarks>
public readonly struct DiagnosticScope : IDisposable
{
    private readonly ActivityAdapter? _adapter;

    internal DiagnosticScope(ActivitySource activitySource, string name, ActivityKind kind, bool suppressNested)
    {
        _adapter = new ActivityAdapter(activitySource, name, kind, suppressNested);
    }

    /// <summary>
    /// Gets a value indicating whether this scope is enabled and will record tracing data.
    /// </summary>
    public bool IsEnabled => _adapter != null;

    /// <summary>
    /// Starts the scope by starting the underlying <see cref="Activity"/>.
    /// Must be called after adding any links, trace context, or pre-start attributes.
    /// </summary>
    public void Start()
    {
        _adapter?.Start();
    }

    /// <summary>
    /// Adds a tag to the underlying activity.
    /// </summary>
    /// <param name="name">The tag name.</param>
    /// <param name="value">The tag value.</param>
    public void AddAttribute(string name, string? value)
    {
        if (value != null)
        {
            _adapter?.AddTag(name, value);
        }
    }

    /// <summary>
    /// Adds a typed tag to the underlying activity using a custom formatter.
    /// </summary>
    /// <typeparam name="T">The type of the tag value.</typeparam>
    /// <param name="name">The tag name.</param>
    /// <param name="value">The tag value.</param>
    /// <param name="format">A function to format the value as a string.</param>
    public void AddAttribute<T>(string name, T value, Func<T, string> format)
    {
        if (_adapter != null && value != null)
        {
            _adapter.AddTag(name, format(value));
        }
    }

    /// <summary>
    /// Adds an integer tag to the underlying activity.
    /// </summary>
    /// <param name="name">The tag name.</param>
    /// <param name="value">The tag value.</param>
    public void AddIntegerAttribute(string name, int value)
    {
        _adapter?.AddTag(name, value);
    }

    /// <summary>
    /// Adds a long tag to the underlying activity.
    /// </summary>
    /// <param name="name">The tag name.</param>
    /// <param name="value">The tag value.</param>
    public void AddLongAttribute(string name, long value)
    {
        _adapter?.AddTag(name, value);
    }

    /// <summary>
    /// Adds a distributed tracing link to the scope. Must be called before <see cref="Start"/>.
    /// </summary>
    /// <param name="traceparent">The W3C traceparent header value for the link.</param>
    /// <param name="tracestate">The W3C tracestate header value for the link.</param>
    /// <param name="attributes">Optional attributes to associate with the link.</param>
    public void AddLink(string traceparent, string? tracestate, IDictionary<string, object?>? attributes = null)
    {
        _adapter?.AddLink(traceparent, tracestate, attributes);
    }

    /// <summary>
    /// Sets the W3C trace context for this scope. Must be called before <see cref="Start"/>.
    /// </summary>
    /// <param name="traceparent">The W3C traceparent header value.</param>
    /// <param name="tracestate">The W3C tracestate header value.</param>
    public void SetTraceContext(string traceparent, string? tracestate = default)
    {
        _adapter?.SetTraceContext(traceparent, tracestate);
    }

    /// <summary>
    /// Sets the display name of the underlying activity.
    /// </summary>
    /// <param name="displayName">The display name to set.</param>
    public void SetDisplayName(string displayName)
    {
        _adapter?.SetDisplayName(displayName);
    }

    /// <summary>
    /// Sets the start time of the underlying activity.
    /// </summary>
    /// <param name="dateTime">The start time to set.</param>
    public void SetStartTime(DateTime dateTime)
    {
        _adapter?.SetStartTime(dateTime);
    }

    /// <summary>
    /// Marks the scope as failed with the specified exception.
    /// </summary>
    /// <param name="exception">The exception that caused the failure.</param>
    public void Failed(Exception exception)
    {
        _adapter?.MarkFailed(exception);
    }

    /// <summary>
    /// Marks the scope as failed with a low-cardinality error code.
    /// </summary>
    /// <param name="errorCode">The error code to associate with the failure.</param>
    public void Failed(string errorCode)
    {
        _adapter?.MarkFailed(errorCode);
    }

    /// <summary>
    /// Disposes the scope and stops the underlying activity.
    /// </summary>
    public void Dispose()
    {
        _adapter?.Dispose();
    }

    private sealed class ActivityAdapter : IDisposable
    {
        private const string ScmScopeLabel = "scm.sdk.scope";
        private static readonly object ScmScopeValue = bool.TrueString;

        private readonly ActivitySource _activitySource;
        private readonly string _name;
        private readonly ActivityKind _kind;
        private readonly bool _suppressNested;

        private Activity? _activity;
        private ActivityTagsCollection? _tagCollection;
        private List<ActivityLink>? _links;
        private string? _traceparent;
        private string? _tracestate;
        private string? _displayName;
        private DateTimeOffset _startTime;

        public ActivityAdapter(ActivitySource activitySource, string name, ActivityKind kind, bool suppressNested)
        {
            _activitySource = activitySource;
            _name = name;
            _kind = kind;
            _suppressNested = suppressNested;
        }

        public void AddTag(string name, object value)
        {
            if (_activity == null)
            {
                _tagCollection ??= new ActivityTagsCollection();
                _tagCollection[name] = value;
            }
            else
            {
                _activity.SetTag(name, value);
            }
        }

        public void AddLink(string traceparent, string? tracestate, IDictionary<string, object?>? attributes)
        {
            ActivityContext.TryParse(traceparent, tracestate, out var context);
            var link = new ActivityLink(context, attributes == null ? null : new ActivityTagsCollection(attributes));
            _links ??= new List<ActivityLink>();
            _links.Add(link);
        }

        public void SetTraceContext(string traceparent, string? tracestate)
        {
            if (_activity != null)
            {
                throw new InvalidOperationException("Trace context cannot be set after the activity is started.");
            }
            _traceparent = traceparent;
            _tracestate = tracestate;
        }

        public void SetDisplayName(string displayName)
        {
            _displayName = displayName;
            if (_activity != null)
            {
                _activity.DisplayName = displayName;
            }
        }

        public void SetStartTime(DateTime startTime)
        {
            _startTime = startTime;
            _activity?.SetStartTime(startTime);
        }

        public void Start()
        {
            ActivityContext.TryParse(_traceparent, _tracestate, out ActivityContext context);
            _activity = _activitySource.StartActivity(_name, _kind, context, _tagCollection, _links, _startTime);

            if (_activity != null && _suppressNested)
            {
                _activity.SetCustomProperty(ScmScopeLabel, ScmScopeValue);
            }

            if (_activity != null && _displayName != null)
            {
                _activity.DisplayName = _displayName;
            }
        }

        public void MarkFailed(Exception exception)
        {
            if (_activity == null)
            {
                return;
            }

            // See: https://opentelemetry.io/docs/specs/semconv/general/recording-errors/
            _activity.SetStatus(ActivityStatusCode.Error, exception.Message);

            string? errorCode = null;
            if (exception is ClientResultException clientResultException)
            {
                errorCode = clientResultException.Status.ToString();
            }
            errorCode ??= exception.GetType().FullName;
            errorCode ??= "_OTHER";

            _activity.SetTag("error.type", errorCode);
        }

        public void MarkFailed(string errorCode)
        {
            if (_activity == null)
            {
                return;
            }

            errorCode ??= "_OTHER";
            _activity.SetStatus(ActivityStatusCode.Error);
            _activity.SetTag("error.type", errorCode);
        }

        public void Dispose()
        {
            _activity?.Dispose();
            _activity = null;
        }
    }
}

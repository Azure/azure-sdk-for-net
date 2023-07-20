// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Core.Pipeline
{
    internal readonly struct DiagnosticScope : IDisposable
    {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
        private const string AzureSdkScopeLabel = "az.sdk.scope";
        internal const string OpenTelemetrySchemaAttribute = "az.schema_url";
        internal const string OpenTelemetrySchemaVersion = "https://opentelemetry.io/schemas/1.17.0";
        private static readonly object AzureSdkScopeValue = bool.TrueString;

        private readonly ActivityAdapter? _activityAdapter;
        private readonly bool _suppressNestedClientActivities;

        internal DiagnosticScope(string scopeName, DiagnosticListener source, object? diagnosticSourceArgs, ActivitySource? activitySource, System.Diagnostics.ActivityKind kind, bool suppressNestedClientActivities)
        {
            // ActivityKind.Internal and Client both can represent public API calls depending on the SDK
            _suppressNestedClientActivities = (kind == ActivityKind.Client || kind == System.Diagnostics.ActivityKind.Internal) ? suppressNestedClientActivities : false;

            // outer scope presence is enough to suppress any inner scope, regardless of inner scope configuation.
            bool hasListeners;
            hasListeners = activitySource?.HasListeners() ?? false;
            IsEnabled = source.IsEnabled() || hasListeners;

            if (_suppressNestedClientActivities)
            {
                IsEnabled &= !AzureSdkScopeValue.Equals(Activity.Current?.GetCustomProperty(AzureSdkScopeLabel));
            }

            _activityAdapter = IsEnabled ? new ActivityAdapter(
                                                    activitySource: activitySource,
                                                    diagnosticSource: source,
                                                    activityName: scopeName,
                                                    kind: kind,
                                                    diagnosticSourceArgs: diagnosticSourceArgs) : null;
        }
#endif

        public bool IsEnabled { get; }

        public void AddAttribute(string name, string value)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            _activityAdapter?.AddTag(name, value);
#endif
        }

        public void AddIntegerAttribute(string name, int value)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            _activityAdapter?.AddTag(name, value);
#endif
        }

        public void AddAttribute<T>(string name,
#if AZURE_NULLABLE
            [AllowNull]
#endif
            T value)
        {
            AddAttribute(name, value, static v => Convert.ToString(v, CultureInfo.InvariantCulture) ?? string.Empty);
        }

        public void AddAttribute<T>(string name, T value, Func<T, string> format)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            if (_activityAdapter != null)
            {
                var formattedValue = format(value);
                _activityAdapter.AddTag(name, formattedValue);
            }
#endif
        }

        /// <summary>
        /// Adds a link to the scope. This must be called before <see cref="Start"/> has been called for the DiagnosticScope.
        /// </summary>
        /// <param name="traceparent">The traceparent for the link.</param>
        /// <param name="tracestate">The tracestate for the link.</param>
        /// <param name="attributes">Optional attributes to associate with the link.</param>
        public void AddLink(string traceparent, string? tracestate, IDictionary<string, string>? attributes = null)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            _activityAdapter?.AddLink(traceparent, tracestate, attributes);
#endif
        }

        public void Start()
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            Activity? started = _activityAdapter?.Start();
            started?.SetCustomProperty(AzureSdkScopeLabel, AzureSdkScopeValue);
#endif
        }

        public void SetDisplayName(string displayName)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            _activityAdapter?.SetDisplayName(displayName);
#endif
        }

        public void SetStartTime(DateTime dateTime)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            _activityAdapter?.SetStartTime(dateTime);
#endif
        }

        /// <summary>
        /// Sets the trace context for the current scope.
        /// </summary>
        /// <param name="traceparent">The trace parent to set for the current scope.</param>
        /// <param name="tracestate">The trace state to set for the current scope.</param>
        public void SetTraceContext(string traceparent, string? tracestate = default)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            _activityAdapter?.SetTraceContext(traceparent, tracestate);
#endif
        }

        public void Dispose()
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            // Reverse the Start order
            _activityAdapter?.Dispose();
#endif
        }

        /// <summary>
        /// Marks the scope as failed.
        /// </summary>
        /// <param name="exception">The exception to associate with the failed scope.</param>
        public void Failed(Exception? exception = default)
        {
#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
            _activityAdapter?.MarkFailed(exception);
#endif
        }

        private class DiagnosticActivity : Activity
        {
#pragma warning disable 109 // extra new modifier
            public new IEnumerable<Activity> Links { get; set; } = Array.Empty<Activity>();
#pragma warning restore 109

            public DiagnosticActivity(string operationName) : base(operationName)
            {
            }
        }

#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
        private class ActivityAdapter : IDisposable
        {
            private readonly ActivitySource? _activitySource;
            private readonly DiagnosticSource _diagnosticSource;
            private readonly string _activityName;
            private readonly System.Diagnostics.ActivityKind _kind;
            private readonly object? _diagnosticSourceArgs;

            private Activity? _currentActivity;
            private Activity? _sampleOutActivity;

            private ActivityTagsCollection? _tagCollection;
            private DateTimeOffset _startTime;
            private List<Activity>? _links;
            private string? _traceparent;
            private string? _tracestate;
            private string? _displayName;

            public ActivityAdapter(ActivitySource? activitySource, DiagnosticSource diagnosticSource, string activityName, System.Diagnostics.ActivityKind kind, object? diagnosticSourceArgs)
            {
                _activitySource = activitySource;
                _diagnosticSource = diagnosticSource;
                _activityName = activityName;
                _kind = kind;
                _diagnosticSourceArgs = diagnosticSourceArgs;
            }

            public void AddTag(string name, object value)
            {
                if (_currentActivity == null)
                {
                    // Activity is not started yet, add the value to the collection
                    // that is going to be passed to StartActivity
                    _tagCollection ??= new ActivityTagsCollection();
                    _tagCollection.Add(name, value!);
                }
                else
                {
                    _currentActivity?.AddTag(name, value);
                }
            }

            private List<ActivityLink>? GetActivitySourceLinkCollection()
            {
                if (_links == null)
                {
                    return null;
                }

                var linkCollection = new List<ActivityLink>();

                foreach (var activity in _links)
                {
                    ActivityTagsCollection linkTagsCollection = new();
                    foreach (var tag in activity.Tags)
                    {
                        linkTagsCollection.Add(tag.Key, tag.Value!);
                    }

                    var contextWasParsed = ActivityContext.TryParse(activity.ParentId!, activity.TraceStateString, out var context);
                    if (contextWasParsed)
                    {
                        var link = new ActivityLink(context, linkTagsCollection);
                        linkCollection.Add(link);
                    }
            }

                return linkCollection;
            }

            public void AddLink(string traceparent, string? tracestate, IDictionary<string, string>? attributes)
            {
                var linkedActivity = new Activity("LinkedActivity");
                linkedActivity.SetParentId(traceparent);
                linkedActivity.SetIdFormat(ActivityIdFormat.W3C);
                linkedActivity.TraceStateString = tracestate;

                if (attributes != null)
                {
                    foreach (var kvp in attributes)
                    {
                        linkedActivity.AddTag(kvp.Key, kvp.Value);
                    }
                }

                _links ??= new List<Activity>();
                _links.Add(linkedActivity);
            }

            public Activity? Start()
            {
                _currentActivity = StartActivitySourceActivity();
                if (_currentActivity != null)
                {
                    if (!_currentActivity.IsAllDataRequested)
                    {
                        _sampleOutActivity = _currentActivity;
                        _currentActivity = null;

                        return null;
                    }

                    _currentActivity.AddTag(OpenTelemetrySchemaAttribute, OpenTelemetrySchemaVersion);
                }
                else
                {
                    if (!_diagnosticSource.IsEnabled(_activityName, _diagnosticSourceArgs))
                    {
                        return null;
                    }

                    switch (_kind)
                    {
                        case ActivityKind.Internal:
                            AddTag("kind", "internal");
                            break;
                        case ActivityKind.Server:
                            AddTag("kind", "server");
                            break;
                        case ActivityKind.Client:
                            AddTag("kind", "client");
                            break;
                        case ActivityKind.Producer:
                            AddTag("kind", "producer");
                            break;
                        case ActivityKind.Consumer:
                            AddTag("kind", "consumer");
                            break;
                    }

                    _currentActivity = new DiagnosticActivity(_activityName)
                    {
                        Links = (IEnumerable<Activity>?)_links ?? Array.Empty<Activity>(),
                    };
                    _currentActivity.SetIdFormat(ActivityIdFormat.W3C);

                    if (_startTime != default)
                    {
                        _currentActivity.SetStartTime(_startTime.UtcDateTime);
                    }

                    if (_tagCollection != null)
                    {
                        foreach (var tag in _tagCollection)
                        {
                            _currentActivity.AddTag(tag.Key, tag.Value);
                        }
                    }

                    if (_traceparent != null)
                    {
                        _currentActivity.SetParentId(_traceparent);
                    }

                    if (_tracestate != null)
                    {
                        _currentActivity.TraceStateString = _tracestate;
                    }

                    _currentActivity.Start();
                }

                _diagnosticSource.Write(_activityName + ".Start", _diagnosticSourceArgs ?? _currentActivity);

                if (_displayName != null)
                {
                    _currentActivity.DisplayName = _displayName;
                }

                return _currentActivity;
            }

            public void SetDisplayName(string displayName)
            {
                _displayName = displayName;
                if (_currentActivity != null)
                {
                    _currentActivity.DisplayName = _displayName;
                }
            }

            private Activity? StartActivitySourceActivity()
            {
                if (_activitySource == null)
                {
                    return null;
                }
                ActivityContext context;
                if (_traceparent != null)
                {
                    context = ActivityContext.Parse(_traceparent, _tracestate);
                }
                else
                {
                    context = new ActivityContext();
                }
                var activity = _activitySource.StartActivity(_activityName, _kind, context, _tagCollection, GetActivitySourceLinkCollection()!, _startTime);
                return activity;
            }

            public void SetStartTime(DateTime startTime)
            {
                _startTime = startTime;
                _currentActivity?.SetStartTime(startTime);
            }

            public void MarkFailed(Exception? exception)
            {
                if (exception != null)
                {
                    _diagnosticSource?.Write(_activityName + ".Exception", exception);
                }

#if NET6_0_OR_GREATER
                _currentActivity?.SetStatus(ActivityStatusCode.Error, exception?.ToString());
#endif
            }

            public void SetTraceContext(string traceparent, string? tracestate)
            {
                if (_currentActivity != null)
                {
                    throw new InvalidOperationException("Traceparent can not be set after the activity is started.");
                }
                _traceparent = traceparent;
                _tracestate = tracestate;
            }

            public void Dispose()
            {
                var activity = _currentActivity ?? _sampleOutActivity;
                if (activity == null)
                {
                    return;
                }

                if (activity.Duration == TimeSpan.Zero)
                    activity.SetEndTime(DateTime.UtcNow);

                _diagnosticSource.Write(_activityName + ".Stop", _diagnosticSourceArgs);
                activity.Dispose();
            }
        }
#endif
    }

#if NETCOREAPP2_1 // Tracing is disabled in netcoreapp2.1
#else
#pragma warning disable SA1507 // File can not contain multiple types
    /// <summary>
    /// Until Activity Source is no longer considered experimental.
    /// </summary>
    internal static class ActivityExtensions
    {
        public static bool SupportsActivitySource { get; private set; }

        public static void ResetFeatureSwitch()
        {
            SupportsActivitySource = AppContextSwitchHelper.GetConfigValue(
                "Azure.Experimental.EnableActivitySource",
                "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE");
        }
    }
#endif
}

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
        private const string AzureSdkScopeLabel = "az.sdk.scope";
        internal const string OpenTelemetrySchemaAttribute = "az.schema_url";
        internal const string OpenTelemetrySchemaVersion = "https://opentelemetry.io/schemas/1.17.0";
        private static readonly object AzureSdkScopeValue = bool.TrueString;

        private readonly ActivityAdapter? _activityAdapter;
        private readonly bool _suppressNestedClientActivities;

        internal DiagnosticScope(string scopeName, DiagnosticListener source, object? diagnosticSourceArgs, ActivitySource activitySource, System.Diagnostics.ActivityKind kind, bool suppressNestedClientActivities)
        {
            // ActivityKind.Internal and Client both can represent public API calls depending on the SDK
            _suppressNestedClientActivities = (kind == System.Diagnostics.ActivityKind.Client || kind == System.Diagnostics.ActivityKind.Internal) ? suppressNestedClientActivities : false;

            // outer scope presence is enough to suppress any inner scope, regardless of inner scope configuation.
            IsEnabled = source.IsEnabled() || activitySource.HasListeners();

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

        public bool IsEnabled { get; }

        public void AddAttribute(string name, string value)
        {
            _activityAdapter?.AddTag(name, value);
        }

        public void AddIntegerAttribute(string name, int value)
        {
            _activityAdapter?.AddTag(name, value);
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
            if (_activityAdapter != null)
            {
                var formattedValue = format(value);
                _activityAdapter.AddTag(name, formattedValue);
            }
        }

        /// <summary>
        /// Adds a link to the scope. This must be called before <see cref="Start"/> has been called for the DiagnosticScope.
        /// </summary>
        /// <param name="traceparent">The traceparent for the link.</param>
        /// <param name="tracestate">The tracestate for the link.</param>
        /// <param name="attributes">Optional attributes to associate with the link.</param>
        public void AddLink(string traceparent, string? tracestate, IDictionary<string, string>? attributes = null)
        {
            _activityAdapter?.AddLink(traceparent, tracestate, attributes);
        }

        public void Start()
        {
            Activity? started = _activityAdapter?.Start();
            started?.SetCustomProperty(AzureSdkScopeLabel, AzureSdkScopeValue);
        }

        public void SetDisplayName(string displayName)
        {
            _activityAdapter?.SetDisplayName(displayName);
        }

        public void SetStartTime(DateTime dateTime)
        {
            _activityAdapter?.SetStartTime(dateTime);
        }

        /// <summary>
        /// Sets the trace context for the current scope.
        /// </summary>
        /// <param name="traceparent">The trace parent to set for the current scope.</param>
        /// <param name="tracestate">The trace state to set for the current scope.</param>
        public void SetTraceContext(string traceparent, string? tracestate = default)
        {
            _activityAdapter?.SetTraceContext(traceparent, tracestate);
        }

        public void Dispose()
        {
            // Reverse the Start order
            _activityAdapter?.Dispose();
        }

        /// <summary>
        /// Marks the scope as failed.
        /// </summary>
        /// <param name="exception">The exception to associate with the failed scope.</param>
        public void Failed(Exception? exception = default)
        {
            _activityAdapter?.MarkFailed(exception);
        }

        /// <summary>
        /// Kind describes the relationship between the Activity, its parents, and its children in a Trace.
        /// </summary>
        public enum ActivityKind
        {
            /// <summary>
            /// Default value.
            /// Indicates that the Activity represents an internal operation within an application, as opposed to an operations with remote parents or children.
            /// </summary>
            Internal = 0,

            /// <summary>
            /// Server activity represents request incoming from external component.
            /// </summary>
            Server = 1,

            /// <summary>
            /// Client activity represents outgoing request to the external component.
            /// </summary>
            Client = 2,

            /// <summary>
            /// Producer activity represents output provided to external components.
            /// </summary>
            Producer = 3,

            /// <summary>
            /// Consumer activity represents output received from an external component.
            /// </summary>
            Consumer = 4,
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

        private class ActivityAdapter : IDisposable
        {
            private readonly ActivitySource _activitySource;
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

            public ActivityAdapter(ActivitySource activitySource, DiagnosticSource diagnosticSource, string activityName, System.Diagnostics.ActivityKind kind, object? diagnosticSourceArgs)
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
                    ActivityTagsCollection linkTagsCollection =  new();
                    foreach (var tag in activity.Tags)
                    {
                        linkTagsCollection.Add(tag.Key, tag.Value!);
                    }

                    var context = ActivityContext.Parse(activity.ParentId!, activity.TraceStateString);
                    var link = new ActivityLink(context, linkTagsCollection);
                    linkCollection.Add(link);
                }

                return linkCollection;
            }

            public void AddLink(string traceparent, string? tracestate, IDictionary<string, string>? attributes)
            {
                var linkedActivity = new Activity("LinkedActivity");
                linkedActivity.SetIdFormat(ActivityIdFormat.W3C);
                linkedActivity.SetParentId(traceparent);
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
                        case System.Diagnostics.ActivityKind.Internal:
                            AddTag("kind", "internal");
                            break;
                        case System.Diagnostics.ActivityKind.Server:
                            AddTag("kind", "server");
                            break;
                        case System.Diagnostics.ActivityKind.Client:
                            AddTag("kind", "client");
                            break;
                        case System.Diagnostics.ActivityKind.Producer:
                            AddTag("kind", "producer");
                            break;
                        case System.Diagnostics.ActivityKind.Consumer:
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
                            _currentActivity.AddTag(tag.Key, tag.Value!);
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
                    _currentActivity.DisplayName = displayName;
                }
            }

            private Activity? StartActivitySourceActivity()
            {
                var context = ActivityContext.Parse(_traceparent!, _tracestate);
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

                if (activity is IDisposable disposable)
                {
                    disposable.Dispose();
                    activity.Stop();
                }
            }
        }
    }

#pragma warning disable SA1507 // File can not contain multiple types
    /// <summary>
    /// Until Activity Source is no longer considered experimental.
    /// </summary>
    internal static class ActivityExtensions
    {
        private static bool SupportsActivitySourceSwitch;

        public static bool SupportsActivitySource()
        {
            return SupportsActivitySourceSwitch;
        }

        public static void ResetFeatureSwitch()
        {
            SupportsActivitySourceSwitch = AppContextSwitchHelper.GetConfigValue(
                "Azure.Experimental.EnableActivitySource",
                "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE");
        }
    }
}

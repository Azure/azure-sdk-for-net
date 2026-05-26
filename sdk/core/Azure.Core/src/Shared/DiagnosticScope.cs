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
using System.Net.Http;
using System.Reflection;

namespace Azure.Core.Pipeline
{
    internal readonly struct DiagnosticScope : IDisposable
    {
        private const string AzureSdkScopeLabel = "az.sdk.scope";
        internal const string OpenTelemetrySchemaAttribute = "az.schema_url";

        // we follow OpenTelemtery Semantic Conventions 1.23.0
        // https://github.com/open-telemetry/semantic-conventions/blob/v1.23.0
        internal const string OpenTelemetrySchemaVersion = "https://opentelemetry.io/schemas/1.23.0";
        private static readonly object AzureSdkScopeValue = bool.TrueString;
        private readonly ActivityAdapter? _activityAdapter;
        private readonly bool _suppressNestedClientActivities;

        [RequiresUnreferencedCode("The diagnosticSourceArgs are used in a call to DiagnosticSource.Write, all necessary properties need to be preserved on the type being passed in using DynamicDependency attributes.")]
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

        public bool IsEnabled { get; }

        public void AddAttribute(string name, string? value)
        {
            if (value != null)
            {
                _activityAdapter?.AddTag(name, value);
            }
        }

        public void AddIntegerAttribute(string name, int value)
        {
            _activityAdapter?.AddTag(name, value);
        }

        public void AddLongAttribute(string name, long value)
        {
            _activityAdapter?.AddTag(name, value);
        }

        public void AddAttribute<T>(string name, T value, Func<T, string> format)
        {
            if (_activityAdapter != null && value != null)
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
        public void AddLink(string traceparent, string? tracestate, IDictionary<string, object?>? attributes = null)
        {
            _activityAdapter?.AddLink(traceparent, tracestate, attributes);
        }

        public void Start()
        {
            Activity? started = _activityAdapter?.Start();
            if (_suppressNestedClientActivities)
            {
                started?.SetCustomProperty(AzureSdkScopeLabel, AzureSdkScopeValue);
            }
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
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "The Exception being passed into this method has public properties preserved on the inner method MarkFailed." +
            "The public property System.Exception.TargetSite.get is not compatible with trimming and produces a warning when preserving all public properties. Since we do not use this property, and" +
            "neither does Application Insights, we can suppress the warning coming from the inner method.")]
        public void Failed(Exception exception)
        {
            if (exception is RequestFailedException requestFailedException)
            {
                // TODO (limolkova) when we start targeting .NET 8 we should put
                // requestFailedException.InnerException.HttpRequestError into error.type

                string? errorCode = string.IsNullOrEmpty(requestFailedException.ErrorCode) ? null : requestFailedException.ErrorCode;
                _activityAdapter?.MarkFailed(exception, errorCode);
            }
            else
            {
                _activityAdapter?.MarkFailed(exception, null);
            }
        }

        /// <summary>
        /// Marks the scope as failed with low-cardinality error.type attribute.
        /// </summary>
        /// <param name="errorCode">Error code to associate with the failed scope.</param>
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "The public property System.Exception.TargetSite.get is not compatible with trimming and produces a warning when " +
            "preserving all public properties. Since we do not use this property, and neither does Application Insights, we can suppress the warning coming from the inner method.")]
        public void Failed(string errorCode)
        {
            _activityAdapter?.MarkFailed((Exception?)null, errorCode);
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
            private readonly ActivitySource? _activitySource;
            private readonly DiagnosticSource _diagnosticSource;
            private readonly string _activityName;
            private readonly System.Diagnostics.ActivityKind _kind;
            private readonly object? _diagnosticSourceArgs;

            private Activity? _currentActivity;
            private Activity? _sampleOutActivity;

            private ActivityTagsCollection? _tagCollection;
            private DateTimeOffset _startTime;
            private List<ActivityLink>? _links;
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
                if (_sampleOutActivity == null)
                {
                    if (_currentActivity == null)
                    {
                        // Activity is not started yet, add the value to the collection
                        // that is going to be passed to StartActivity
                        _tagCollection ??= new ActivityTagsCollection();
                        _tagCollection[name] = value!;
                    }
                    else
                    {
                        AddObjectTag(name, value);
                    }
                }
            }

            private IReadOnlyList<Activity> GetDiagnosticSourceLinkCollection()
            {
                if (_links == null)
                {
                    return Array.Empty<Activity>();
                }

                var linkCollection = new List<Activity>();

                foreach (var link in _links)
                {
                    var activity = new Activity("LinkedActivity");
                    activity.SetIdFormat(ActivityIdFormat.W3C);
                    if (link.Context != default)
                    {
                        activity.SetParentId(ActivityContextToTraceParent(link.Context));
                        activity.TraceStateString = link.Context.TraceState;
                    }

                    if (link.Tags != null)
                    {
                        foreach (var tag in link.Tags)
                        {
                            if (tag.Value != null)
                            {
                                // old code path, only string attributes are supported
                                activity.AddTag(tag.Key, tag.Value.ToString());
                            }
                        }
                    }
                    linkCollection.Add(activity);
                }

                return linkCollection;
            }

            private static string ActivityContextToTraceParent(ActivityContext context)
            {
                string flags = (context.TraceFlags == ActivityTraceFlags.None) ? "00" : "01";
                return "00-" + context.TraceId + "-" + context.SpanId + "-" + flags;
            }

            public void AddLink(string traceparent, string? tracestate, IDictionary<string, object?>? attributes)
            {
                // if context is invalid, we should still add a link since it contains attributes
                // so we let ActivityLink deal with the default context.
                // This is otel spec requirement and default context is allowed on links.
                ActivityContext.TryParse(traceparent, tracestate, out var context);
                var linkedActivity = new ActivityLink(context, attributes == null ? null : new ActivityTagsCollection(attributes));
                _links ??= new List<ActivityLink>();
                _links.Add(linkedActivity);
            }

            [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods, typeof(Activity))]
            [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods, typeof(DiagnosticActivity))]
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

                    _currentActivity.SetTag(OpenTelemetrySchemaAttribute, OpenTelemetrySchemaVersion);
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
                        Links = GetDiagnosticSourceLinkCollection(),
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
                            AddObjectTag(tag.Key, tag.Value!);
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

                WriteStartEvent();

                if (_displayName != null)
                {
                    _currentActivity.DisplayName = _displayName;
                }

                return _currentActivity;
            }

            [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "The values being passed into Write have the commonly used properties being preserved with DynamicDependency on the ActivityAdapter.Start() method, or the responsibility is on the user of this struct since the struct constructor is marked with RequiresUnreferencedCode.")]
            private void WriteStartEvent()
            {
                _diagnosticSource.Write(_activityName + ".Start", _diagnosticSourceArgs ?? _currentActivity);
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
                // TODO(limolkova) set isRemote to true once we switch to DiagnosticSource 7.0
                ActivityContext.TryParse(_traceparent, _tracestate, out ActivityContext context);
                return _activitySource.StartActivity(_activityName, _kind, context, _tagCollection, _links, _startTime);
            }

            public void SetStartTime(DateTime startTime)
            {
                _startTime = startTime;
                _currentActivity?.SetStartTime(startTime);
            }

            [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "The Exception being passed into this method has the commonly used properties being preserved with DynamicallyAccessedMemberTypes.")]
            public void MarkFailed<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T? exception, string? errorCode)
            {
                if (exception != null)
                {
                    _diagnosticSource?.Write(_activityName + ".Exception", exception);
                }

                if (errorCode == null && exception != null)
                {
                    errorCode = exception.GetType().FullName;
                }

                errorCode ??= "_OTHER";

                // SetStatus is only defined in NET 6 or greater
                _currentActivity?.SetTag("error.type", errorCode);
                _currentActivity?.SetStatus(ActivityStatusCode.Error, exception?.ToString());
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

            private void AddObjectTag(string name, object value)
            {
                if (_activitySource?.HasListeners() == true)
                {
                    _currentActivity?.SetTag(name, value);
                }
                else
                {
                    _currentActivity?.AddTag(name, value.ToString());
                }
            }

            [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The class constructor is marked with RequiresUnreferencedCode.")]
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

                _currentActivity = null;
                _sampleOutActivity = null;
            }
        }
    }

#pragma warning disable SA1507 // File can not contain multiple types
    /// <summary>
    /// Until Activity Source is no longer considered experimental.
    /// </summary>
    internal static class ActivityExtensions
    {
        static ActivityExtensions()
        {
            ResetFeatureSwitch();
        }

        public static bool SupportsActivitySource { get; private set; }

        public static void ResetFeatureSwitch()
        {
            SupportsActivitySource = AppContextSwitchHelper.GetConfigValue(
                "Azure.Experimental.EnableActivitySource",
                "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE");
        }
    }
}

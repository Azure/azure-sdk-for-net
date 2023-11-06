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
        internal const string OpenTelemetrySchemaVersion = "https://opentelemetry.io/schemas/1.23.0";
        private static readonly object AzureSdkScopeValue = bool.TrueString;

        private readonly ActivityAdapter? _activityAdapter;
        private readonly bool _suppressNestedClientActivities;

        [RequiresUnreferencedCode("The diagnosticSourceArgs are used in a call to DiagnosticSource.Write, all necessary properties need to be preserved on the type being passed in using DynamicDependency attributes.")]
#if NETCOREAPP2_1
        internal DiagnosticScope(string scopeName, DiagnosticListener source, object? diagnosticSourceArgs, object? activitySource, ActivityKind kind, bool suppressNestedClientActivities)
#else
        internal DiagnosticScope(string scopeName, DiagnosticListener source, object? diagnosticSourceArgs, ActivitySource? activitySource, System.Diagnostics.ActivityKind kind, bool suppressNestedClientActivities)
#endif
        {
            // ActivityKind.Internal and Client both can represent public API calls depending on the SDK
#if NETCOREAPP2_1
            _suppressNestedClientActivities = (kind == ActivityKind.Client || kind == ActivityKind.Internal) ? suppressNestedClientActivities : false;
#else
            _suppressNestedClientActivities = (kind == ActivityKind.Client || kind == System.Diagnostics.ActivityKind.Internal) ? suppressNestedClientActivities : false;
#endif

            // outer scope presence is enough to suppress any inner scope, regardless of inner scope configuation.
            bool hasListeners;
#if NETCOREAPP2_1
            hasListeners = ActivityExtensions.ActivitySourceHasListeners(activitySource);
#else
            hasListeners = activitySource?.HasListeners() ?? false;
#endif
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
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "The Exception being passed into this method has public properties preserved on the inner method MarkFailed." +
            "The public property System.Exception.TargetSite.get is not compatible with trimming and produces a warning when preserving all public properties. Since we do not use this property, and" +
            "neither does Application Insights, we can suppress the warning coming from the inner method.")]
        public void Failed(Exception exception)
        {
            if (exception is RequestFailedException requestFailedException)
            {
                // TODO (limolkova) when we start targeting .NET 8 we should put
                // requestFailedException.InnerException.HttpRequestError into error.type

                _activityAdapter?.MarkFailed(exception, requestFailedException.ErrorCode);
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
        public void Failed(string errorCode)
        {
            _activityAdapter?.MarkFailed((Exception?)null, errorCode);
        }

#if NETCOREAPP2_1
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
#endif

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
#if NETCOREAPP2_1
            private readonly object? _activitySource;
#else
            private readonly ActivitySource? _activitySource;
#endif
            private readonly DiagnosticSource _diagnosticSource;
            private readonly string _activityName;
#if NETCOREAPP2_1
            private readonly ActivityKind _kind;
#else
            private readonly System.Diagnostics.ActivityKind _kind;
#endif
            private readonly object? _diagnosticSourceArgs;

            private Activity? _currentActivity;
            private Activity? _sampleOutActivity;

#if NETCOREAPP2_1
            private ICollection<KeyValuePair<string,object>>? _tagCollection;
#else
            private ActivityTagsCollection? _tagCollection;
#endif
            private DateTimeOffset _startTime;
            private List<Activity>? _links;
            private string? _traceparent;
            private string? _tracestate;
            private string? _displayName;

#if NETCOREAPP2_1
            public ActivityAdapter(object? activitySource, DiagnosticSource diagnosticSource, string activityName, ActivityKind kind, object? diagnosticSourceArgs)
#else
            public ActivityAdapter(ActivitySource? activitySource, DiagnosticSource diagnosticSource, string activityName, System.Diagnostics.ActivityKind kind, object? diagnosticSourceArgs)
#endif
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
#if NETCOREAPP2_1
                    _tagCollection ??= ActivityExtensions.CreateTagsCollection() ?? new List<KeyValuePair<string, object>>();
                    _tagCollection?.Add(new KeyValuePair<string, object>(name, value!));
#else
                    _tagCollection ??= new ActivityTagsCollection();
                    _tagCollection.Add(name, value!);
#endif
                }
                else
                {
#if NETCOREAPP2_1
                    _currentActivity?.AddObjectTag(name, value);
#else
                    _currentActivity?.AddTag(name, value);
#endif
                }
            }

#if NETCOREAPP2_1
            private IList? GetActivitySourceLinkCollection()
#else
            private List<ActivityLink>? GetActivitySourceLinkCollection()
#endif
            {
                if (_links == null)
                {
                    return null;
                }

#if NETCOREAPP2_1
                var linkCollection = ActivityExtensions.CreateLinkCollection();
                if (linkCollection == null)
                {
                    return null;
                }
#else
                var linkCollection = new List<ActivityLink>();
#endif

                foreach (var activity in _links)
                {
#if NETCOREAPP2_1
                    ICollection<KeyValuePair<string,object>>? linkTagsCollection =  ActivityExtensions.CreateTagsCollection();
                    if (linkTagsCollection != null)
                    {
                        foreach (var tag in activity.Tags)
                        {
                            linkTagsCollection.Add(new KeyValuePair<string, object>(tag.Key, tag.Value!));
                        }
                    }

                    var link = ActivityExtensions.CreateActivityLink(activity.ParentId!, activity.GetTraceState(), linkTagsCollection);
                    if (link != null)
                    {
                        linkCollection.Add(link);
                    }
#else
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
#endif
            }

                return linkCollection;
            }

            public void AddLink(string traceparent, string? tracestate, IDictionary<string, string>? attributes)
            {
                var linkedActivity = new Activity("LinkedActivity");
                linkedActivity.SetParentId(traceparent);
#if NETCOREAPP2_1
                linkedActivity.SetW3CFormat();
                linkedActivity.SetTraceState(tracestate);
#else
                linkedActivity.SetIdFormat(ActivityIdFormat.W3C);
                linkedActivity.TraceStateString = tracestate;
#endif

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

            [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods, typeof(Activity))]
            [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods, typeof(DiagnosticActivity))]
            public Activity? Start()
            {
                _currentActivity = StartActivitySourceActivity();
                if (_currentActivity != null)
                {
#if NETCOREAPP2_1
                    if (!_currentActivity.GetIsAllDataRequested())
#else
                    if (!_currentActivity.IsAllDataRequested)
#endif
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
#if NETCOREAPP2_1
                    _currentActivity.SetW3CFormat();
#else
                    _currentActivity.SetIdFormat(ActivityIdFormat.W3C);
#endif

                    if (_startTime != default)
                    {
                        _currentActivity.SetStartTime(_startTime.UtcDateTime);
                    }

                    if (_tagCollection != null)
                    {
                        foreach (var tag in _tagCollection)
                        {
#if NETCOREAPP2_1
                            _currentActivity.AddObjectTag(tag.Key, tag.Value);
#else
                            _currentActivity.AddTag(tag.Key, tag.Value);
#endif
                        }
                    }

                    if (_traceparent != null)
                    {
                        _currentActivity.SetParentId(_traceparent);
                    }

                    if (_tracestate != null)
                    {
#if NETCOREAPP2_1
                        _currentActivity.SetTraceState(_tracestate);
#else
                        _currentActivity.TraceStateString = _tracestate;
#endif
                    }

                    _currentActivity.Start();
                }

                WriteStartEvent();

                if (_displayName != null)
                {
#if NETCOREAPP2_1
                    _currentActivity?.SetDisplayName(_displayName);
#else
                    _currentActivity.DisplayName = _displayName;
#endif
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
#if NETCOREAPP2_1
                    _currentActivity.SetDisplayName(_displayName);
#else
                    _currentActivity.DisplayName = _displayName;
#endif
                }
            }

            private Activity? StartActivitySourceActivity()
            {
#if NETCOREAPP2_1
                return ActivityExtensions.ActivitySourceStartActivity(
                    _activitySource,
                    _activityName,
                    (int)_kind,
                    startTime: _startTime,
                    tags: _tagCollection,
                    links: GetActivitySourceLinkCollection(),
                    traceparent: _traceparent,
                    tracestate: _tracestate);
#else
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
#endif
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

#if NETCOREAPP2_1
                if (ActivityExtensions.SupportsActivitySource())
                {
                    _currentActivity?.SetErrorStatus(exception?.ToString());
                }
#endif
#if NET6_0_OR_GREATER // SetStatus is only defined in NET 6 or greater
                if (errorCode == null && exception != null)
                {
                    errorCode = exception.GetType().FullName;
                }

                _currentActivity?.AddTag("error.type", errorCode ?? "_OTHER");
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

#if NETCOREAPP2_1
                if (!activity.TryDispose())
                {
                    activity.Stop();
                }
#else
                activity.Dispose();
#endif
            }
        }
    }

#if NETCOREAPP2_1
#pragma warning disable SA1507 // File can not contain multiple types
    /// <summary>
    /// Until we can reference the 5.0 of System.Diagnostics.DiagnosticSource
    /// </summary>
    internal static class ActivityExtensions
    {
        static ActivityExtensions()
        {
            ResetFeatureSwitch();
        }

        private static bool SupportsActivitySourceSwitch;

        private static readonly Type? ActivitySourceType = Type.GetType("System.Diagnostics.ActivitySource, System.Diagnostics.DiagnosticSource");
        private static readonly Type? ActivityKindType = Type.GetType("System.Diagnostics.ActivityKind, System.Diagnostics.DiagnosticSource");
        private static readonly Type? ActivityTagsCollectionType = Type.GetType("System.Diagnostics.ActivityTagsCollection, System.Diagnostics.DiagnosticSource");
        private static readonly Type? ActivityLinkType = Type.GetType("System.Diagnostics.ActivityLink, System.Diagnostics.DiagnosticSource");
        private static readonly Type? ActivityContextType = Type.GetType("System.Diagnostics.ActivityContext, System.Diagnostics.DiagnosticSource");
        private static readonly Type? ActivityStatusCodeType = Type.GetType("System.Diagnostics.ActivityStatusCode, System.Diagnostics.DiagnosticSource");

        private static Action<Activity, int>? SetIdFormatMethod;
        private static Func<Activity, string?>? GetTraceStateStringMethod;
        private static Action<Activity, string?>? SetTraceStateStringMethod;
        private static Action<Activity, int, string?>? SetErrorStatusMethod;
        private static Func<Activity, int>? GetIdFormatMethod;
        private static Func<Activity, bool>? GetAllDataRequestedMethod;
        private static Action<Activity, string, object?>? ActivityAddTagMethod;
        private static Func<object, string, int, object?, ICollection<KeyValuePair<string, object>>?, IList?, DateTimeOffset, Activity?>? ActivitySourceStartActivityMethod;
        private static Func<object, bool>? ActivitySourceHasListenersMethod;
        private static Func<string, string?, ICollection<KeyValuePair<string, object>>?, object?>? CreateActivityLinkMethod;
        private static Func<ICollection<KeyValuePair<string,object>>?>? CreateTagsCollectionMethod;
        private static Func<Activity, string, object?>? GetCustomPropertyMethod;
        private static Action<Activity, string, object>? SetCustomPropertyMethod;
        private static readonly ParameterExpression ActivityParameter = Expression.Parameter(typeof(Activity));
        private static MethodInfo? ParseActivityContextMethod;
        private static Action<Activity, string>? SetDisplayNameMethod;

        public static object? GetCustomProperty(this Activity activity, string propertyName)
        {
            if (GetCustomPropertyMethod == null)
            {
                var method = typeof(Activity).GetMethod("GetCustomProperty");
                if (method == null)
                {
                    GetCustomPropertyMethod = (_, _) => null;
                }
                else
                {
                    var nameParameter = Expression.Parameter(typeof(string));

                    GetCustomPropertyMethod = Expression.Lambda<Func<Activity, string, object>>(
                        Expression.Convert(Expression.Call(ActivityParameter, method, nameParameter), typeof(object)),
                        ActivityParameter, nameParameter).Compile();
                }
            }

            return GetCustomPropertyMethod(activity, propertyName);
        }

        public static void SetCustomProperty(this Activity activity, string propertyName, object propertyValue)
        {
            if (SetCustomPropertyMethod == null)
            {
                var method = typeof(Activity).GetMethod("SetCustomProperty");
                if (method == null)
                {
                    SetCustomPropertyMethod = (_, _, _) => { };
                }
                else
                {
                    var nameParameter = Expression.Parameter(typeof(string));
                    var valueParameter = Expression.Parameter(typeof(object));

                    SetCustomPropertyMethod = Expression.Lambda<Action<Activity, string, object>>(
                        Expression.Call(ActivityParameter, method, nameParameter, valueParameter),
                        ActivityParameter, nameParameter, valueParameter).Compile();
                }
            }

            SetCustomPropertyMethod(activity, propertyName, propertyValue);
        }

        public static void SetW3CFormat(this Activity activity)
        {
            if (SetIdFormatMethod == null)
            {
                var method = typeof(Activity).GetMethod("SetIdFormat");
                if (method == null)
                {
                    SetIdFormatMethod = (_, _) => { };
                }
                else
                {
                    var idParameter = Expression.Parameter(typeof(int));
                    var convertedId = Expression.Convert(idParameter, method.GetParameters()[0].ParameterType);

                    SetIdFormatMethod = Expression.Lambda<Action<Activity, int>>(
                        Expression.Call(ActivityParameter, method, convertedId),
                        ActivityParameter, idParameter).Compile();
                }
            }

            SetIdFormatMethod(activity, 2 /* ActivityIdFormat.W3C */);
        }

        public static bool IsW3CFormat(this Activity activity)
        {
            if (GetIdFormatMethod == null)
            {
                var method = typeof(Activity).GetProperty("IdFormat")?.GetMethod;
                if (method == null)
                {
                    GetIdFormatMethod = _ => -1;
                }
                else
                {
                    GetIdFormatMethod = Expression.Lambda<Func<Activity, int>>(
                        Expression.Convert(Expression.Call(ActivityParameter, method), typeof(int)),
                        ActivityParameter).Compile();
                }
            }


            int result = GetIdFormatMethod(activity);

            return result == 2 /* ActivityIdFormat.W3C */;
        }

        public static string? GetTraceState(this Activity activity)
        {
            if (GetTraceStateStringMethod == null)
            {
                var method = typeof(Activity).GetProperty("TraceStateString")?.GetMethod;
                if (method == null)
                {
                    GetTraceStateStringMethod = _ => null;
                }
                else
                {
                    GetTraceStateStringMethod = Expression.Lambda<Func<Activity, string?>>(
                        Expression.Call(ActivityParameter, method),
                        ActivityParameter).Compile();
                }
            }

            return GetTraceStateStringMethod(activity);
        }

        public static bool GetIsAllDataRequested(this Activity activity)
        {
            if (GetAllDataRequestedMethod == null)
            {
                var method = typeof(Activity).GetProperty("IsAllDataRequested")?.GetMethod;
                if (method == null)
                {
                    GetAllDataRequestedMethod = _ => true;
                }
                else
                {
                    GetAllDataRequestedMethod = Expression.Lambda<Func<Activity, bool>>(
                        Expression.Call(ActivityParameter, method),
                        ActivityParameter).Compile();
                }
            }
            return GetAllDataRequestedMethod(activity);
        }

        public static void SetDisplayName(this Activity activity, string displayName)
        {
            if (displayName != null)
            {
                if (SetDisplayNameMethod == null)
                {
                    var method = typeof(Activity).GetProperty("DisplayName")?.SetMethod;
                    if (method == null)
                    {
                        SetDisplayNameMethod = (_, _) => { };
                    }
                    else
                    {
                        var displayNameParameter = Expression.Parameter(typeof(string));
                        var convertedParameter = Expression.Convert(displayNameParameter, method.GetParameters()[0].ParameterType);
                        SetDisplayNameMethod = Expression.Lambda<Action<Activity, string>>(
                            Expression.Call(ActivityParameter, method, convertedParameter),
                            ActivityParameter, displayNameParameter).Compile();
                    }
                }
                SetDisplayNameMethod(activity, displayName);
            }
        }

        public static void SetTraceState(this Activity activity, string? tracestate)
        {
            if (SetTraceStateStringMethod == null)
            {
                var method = typeof(Activity).GetProperty("TraceStateString")?.SetMethod;
                if (method == null)
                {
                    SetTraceStateStringMethod = (_, _) => { };
                }
                else
                {
                    var tracestateParameter = Expression.Parameter(typeof(string));
                    var convertedParameter = Expression.Convert(tracestateParameter, method.GetParameters()[0].ParameterType);
                    SetTraceStateStringMethod = Expression.Lambda<Action<Activity, string?>>(
                        Expression.Call(ActivityParameter, method, convertedParameter),
                        ActivityParameter, tracestateParameter).Compile();
                }
            }

            SetTraceStateStringMethod(activity, tracestate);
        }

        public static void SetErrorStatus(this Activity activity, string? errorDescription)
        {
            if (SetErrorStatusMethod == null)
            {
                if (ActivityStatusCodeType == null)
                {
                    SetErrorStatusMethod = (_, _, _) => { };
                }
                else
                {
                    var method = typeof(Activity).GetMethod("SetStatus", BindingFlags.Instance | BindingFlags.Public, null, new Type[]
                    {
                        ActivityStatusCodeType,
                        typeof(string)
                    }, null);
                    if (method == null)
                    {
                        SetErrorStatusMethod = (_, _, _) => { };
                    }
                    else
                    {
                        var methodParameters = method.GetParameters();

                        var statusParameter = Expression.Parameter(typeof(int));
                        var descriptionParameter = Expression.Parameter(typeof(string));
                        SetErrorStatusMethod = Expression.Lambda<Action<Activity, int, string?>>(
                            Expression.Call(ActivityParameter, method, Expression.Convert(statusParameter, methodParameters[0].ParameterType), descriptionParameter),
                            ActivityParameter, statusParameter, descriptionParameter).Compile();
                    }
                }
            }
            SetErrorStatusMethod(activity, 2 /* Error */, errorDescription);
        }

        public static void AddObjectTag(this Activity activity, string name, object value)
        {
            if (ActivityAddTagMethod == null)
            {
                var method = typeof(Activity).GetMethod("AddTag", BindingFlags.Instance | BindingFlags.Public, null, new Type[]
                {
                    typeof(string),
                    typeof(object)
                }, null);

                if (method == null)
                {
                    // If the object overload is not available, fall back to the string overload. The assumption is that the object overload
                    // not being available means that we cannot be using activity source, so the string cast should never fail because we will always
                    // be passing a string value.
                    ActivityAddTagMethod = (activityParameter, nameParameter, valueParameter) => activityParameter.AddTag(
                        nameParameter,
                        // null check is required to keep nullable reference compilation happy
                        valueParameter == null ? null : (string)valueParameter);
                }
                else
                {
                    var nameParameter = Expression.Parameter(typeof(string));
                    var valueParameter = Expression.Parameter(typeof(object));

                    ActivityAddTagMethod = Expression.Lambda<Action<Activity, string, object?>>(
                        Expression.Call(ActivityParameter, method, nameParameter, valueParameter),
                        ActivityParameter, nameParameter, valueParameter).Compile();
                }
            }

            ActivityAddTagMethod(activity, name, value);
        }

        public static bool SupportsActivitySource()
        {
            return SupportsActivitySourceSwitch && ActivitySourceType != null;
        }

        public static ICollection<KeyValuePair<string,object>>? CreateTagsCollection()
        {
            if (CreateTagsCollectionMethod == null)
            {
                var ctor = ActivityTagsCollectionType?.GetConstructor(Array.Empty<Type>());
                if (ctor == null)
                {
                    CreateTagsCollectionMethod = () => null;
                }
                else
                {
                    CreateTagsCollectionMethod = Expression.Lambda<Func<ICollection<KeyValuePair<string,object>>?>>(
                        Expression.New(ctor)).Compile();
                }
            }

            return CreateTagsCollectionMethod();
        }

        public static object? CreateActivityLink(string traceparent, string? tracestate, ICollection<KeyValuePair<string,object>>? tags)
        {
            if (ActivityLinkType == null)
            {
                return null;
            }

            if (CreateActivityLinkMethod == null)
            {
                var parseMethod = ActivityContextType?.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);
                var ctor = ActivityLinkType?.GetConstructor(new[] { ActivityContextType!, ActivityTagsCollectionType! });

                if (parseMethod == null ||
                    ctor == null ||
                    ActivityTagsCollectionType == null ||
                    ActivityContextType == null)
                {
                    CreateActivityLinkMethod = (_, _, _) => null;
                }
                else
                {
                    var traceparentParameter = Expression.Parameter(typeof(string));
                    var tracestateParameter = Expression.Parameter(typeof(string));
                    var tagsParameter = Expression.Parameter(typeof(ICollection<KeyValuePair<string,object>>));

                    CreateActivityLinkMethod = Expression.Lambda<Func<string, string?, ICollection<KeyValuePair<string, object>>?, object?>>(
                        Expression.TryCatch(
                                Expression.Convert(Expression.New(ctor,
                                        Expression.Call(parseMethod, traceparentParameter, tracestateParameter),
                                Expression.Convert(tagsParameter, ActivityTagsCollectionType)), typeof(object)),
                        Expression.Catch(typeof(Exception), Expression.Default(typeof(object)))),
                             traceparentParameter, tracestateParameter, tagsParameter).Compile();
                }
            }

            return CreateActivityLinkMethod(traceparent, tracestate, tags);
        }

        public static bool ActivitySourceHasListeners(object? activitySource)
        {
            if (!SupportsActivitySource())
            {
                return false;
            }

            if (activitySource == null)
            {
                return false;
            }

            if (ActivitySourceHasListenersMethod == null)
            {
                var method = ActivitySourceType?.GetMethod("HasListeners", BindingFlags.Instance | BindingFlags.Public);
                if (method == null ||
                    ActivitySourceType == null)
                {
                    ActivitySourceHasListenersMethod = _ => false;
                }
                else
                {
                    var sourceParameter = Expression.Parameter(typeof(object));
                    ActivitySourceHasListenersMethod = Expression.Lambda<Func<object, bool>>(
                        Expression.Call(Expression.Convert(sourceParameter, ActivitySourceType), method),
                        sourceParameter).Compile();
                }
            }

            return ActivitySourceHasListenersMethod.Invoke(activitySource);
        }

        public static Activity? ActivitySourceStartActivity(
            object? activitySource,
            string activityName,
            int kind,
            DateTimeOffset startTime,
            ICollection<KeyValuePair<string, object>>? tags,
            IList? links,
            string? traceparent,
            string? tracestate)
        {
            if (activitySource == null)
            {
                return null;
            }

            object? activityContext = default;

            if (ActivitySourceStartActivityMethod == null)
            {
                if (ActivityLinkType == null ||
                    ActivitySourceType == null ||
                    ActivityContextType == null ||
                    ActivityKindType == null)
                {
                    ActivitySourceStartActivityMethod = (_, _, _, _, _, _, _) => null;
                }
                else
                {
                    var method = ActivitySourceType?.GetMethod("StartActivity", BindingFlags.Instance | BindingFlags.Public, null, new[]
                    {
                        typeof(string),
                        ActivityKindType,
                        ActivityContextType,
                        typeof(IEnumerable<KeyValuePair<string, object>>),
                        typeof(IEnumerable<>).MakeGenericType(ActivityLinkType),
                        typeof(DateTimeOffset)
                    }, null);

                    if (method == null)
                    {
                        ActivitySourceStartActivityMethod = (_, _, _, _, _, _, _) => null;
                    }
                    else
                    {
                        var sourceParameter = Expression.Parameter(typeof(object));
                        var nameParameter = Expression.Parameter(typeof(string));
                        var kindParameter = Expression.Parameter(typeof(int));
                        var contextParameter = Expression.Parameter(typeof(object));
                        var startTimeParameter = Expression.Parameter(typeof(DateTimeOffset));
                        var tagsParameter = Expression.Parameter(typeof(ICollection<KeyValuePair<string, object>>));
                        var linksParameter = Expression.Parameter(typeof(IList));
                        var methodParameter = method.GetParameters();
                        ParseActivityContextMethod = ActivityContextType.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);

                        ActivitySourceStartActivityMethod = Expression.Lambda<Func<object, string, int, object?, ICollection<KeyValuePair<string, object>>?, IList?, DateTimeOffset, Activity?>>(
                            Expression.Call(
                                Expression.Convert(sourceParameter, method.DeclaringType!),
                                method,
                                nameParameter,
                                Expression.Convert(kindParameter,  methodParameter[1].ParameterType),
                                Expression.Convert(contextParameter, methodParameter[2].ParameterType),
                                Expression.Convert(tagsParameter,  methodParameter[3].ParameterType),
                                Expression.Convert(linksParameter,  methodParameter[4].ParameterType),
                                Expression.Convert(startTimeParameter,  methodParameter[5].ParameterType)),
                            sourceParameter, nameParameter, kindParameter, contextParameter, tagsParameter, linksParameter, startTimeParameter).Compile();
                    }
                }
            }

            if (ActivityContextType != null && ParseActivityContextMethod != null)
            {
                if (traceparent != null)
                    activityContext = ParseActivityContextMethod.Invoke(null, new[] {traceparent, tracestate})!;
                else
                    // because ActivityContext is a struct, we need to create a default instance rather than allowing the argument to be null
                    activityContext = Activator.CreateInstance(ActivityContextType);
            }

            return ActivitySourceStartActivityMethod.Invoke(activitySource, activityName, kind, activityContext, tags, links, startTime);
        }

        public static object? CreateActivitySource(string name)
        {
            if (ActivitySourceType == null)
            {
                return null;
            }
            return Activator.CreateInstance(ActivitySourceType,
                name, // name
                null // version
            );
        }

        public static IList? CreateLinkCollection()
        {
            if (ActivityLinkType == null)
            {
                return null;
            }
            return Activator.CreateInstance(typeof(List<>).MakeGenericType(ActivityLinkType)) as IList;
        }

        public static bool TryDispose(this Activity activity)
        {
            if (activity is IDisposable disposable)
            {
                disposable.Dispose();
                return true;
            }

            return false;
        }

        public static void ResetFeatureSwitch()
        {
            SupportsActivitySourceSwitch = AppContextSwitchHelper.GetConfigValue(
                "Azure.Experimental.EnableActivitySource",
                "AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE");
        }
    }
#else
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
#endif
}

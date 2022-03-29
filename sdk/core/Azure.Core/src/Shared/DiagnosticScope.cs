﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Concurrent;
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
        private static readonly ConcurrentDictionary<string, object?> ActivitySources = new();

        private readonly ActivityAdapter? _activityAdapter;

        internal DiagnosticScope(string ns, string scopeName, DiagnosticListener source, ActivityKind kind)
        {
            var activitySource = GetActivitySource(ns, scopeName);

            IsEnabled = source.IsEnabled() || ActivityExtensions.ActivitySourceHasListeners(activitySource);

            _activityAdapter = IsEnabled ? new ActivityAdapter(activitySource, source, scopeName, kind, null) : null;
        }

        internal DiagnosticScope(string scopeName, DiagnosticListener source, object? diagnosticSourceArgs, object? activitySource, ActivityKind kind)
        {
            IsEnabled = source.IsEnabled() || ActivityExtensions.ActivitySourceHasListeners(activitySource);

            _activityAdapter = IsEnabled ? new ActivityAdapter(activitySource, source, scopeName, kind, diagnosticSourceArgs) : null;
        }

        public bool IsEnabled { get; }

        /// <summary>
        /// This method combines client namespace and operation name into an ActivitySource name and creates the activity source.
        /// For example:
        ///     ns: Azure.Storage.Blobs
        ///     name: BlobClient.DownloadTo
        ///     result Azure.Storage.Blobs.BlobClient
        /// </summary>
        private static object? GetActivitySource(string ns, string name)
        {
            if (!ActivityExtensions.SupportsActivitySource())
            {
                return null;
            }

            int indexOfDot = name.IndexOf(".", StringComparison.OrdinalIgnoreCase);
            if (indexOfDot == -1)
            {
                return null;
            }

            string clientName = ns + "." + name.Substring(0, indexOfDot);

            return ActivitySources.GetOrAdd(clientName, static n => ActivityExtensions.CreateActivitySource(n));
        }

        public void AddAttribute(string name, string value)
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

        public void AddLink(string traceparent, string tracestate, IDictionary<string, string>? attributes = null)
        {
            _activityAdapter?.AddLink(traceparent, tracestate, attributes);
        }

        public void Start()
        {
            _activityAdapter?.Start();
        }

        public void SetStartTime(DateTime dateTime)
        {
            _activityAdapter?.SetStartTime(dateTime);
        }

        public void Dispose()
        {
            // Reverse the Start order
            _activityAdapter?.Dispose();
        }

        public void Failed(Exception e)
        {
            _activityAdapter?.MarkFailed(e);
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
            private readonly object? _activitySource;
            private readonly DiagnosticSource _diagnosticSource;
            private readonly string _activityName;
            private readonly ActivityKind _kind;
            private readonly object? _diagnosticSourceArgs;

            private Activity? _currentActivity;
            private ICollection<KeyValuePair<string,object>>? _tagCollection;
            private DateTimeOffset _startTime;
            private List<Activity>? _links;

            public ActivityAdapter(object? activitySource, DiagnosticSource diagnosticSource, string activityName, ActivityKind kind, object? diagnosticSourceArgs)
            {
                _activitySource = activitySource;
                _diagnosticSource = diagnosticSource;
                _activityName = activityName;
                _kind = kind;
                _diagnosticSourceArgs = diagnosticSourceArgs;

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
            }

            public void AddTag(string name, string value)
            {
                if (_currentActivity == null)
                {
                    // Activity is not started yet, add the value to the collection
                    // that is going to be passed to StartActivity
                    _tagCollection ??= ActivityExtensions.CreateTagsCollection() ?? new List<KeyValuePair<string, object>>();
                    _tagCollection?.Add(new KeyValuePair<string, object>(name, value!));
                }
                else
                {
                    _currentActivity?.AddTag(name, value!);
                }
            }

            private IList? GetActivitySourceLinkCollection()
            {
                if (_links == null)
                {
                    return null;
                }

                var linkCollection = ActivityExtensions.CreateLinkCollection();
                if (linkCollection == null)
                {
                    return null;
                }

                foreach (var activity in _links)
                {
                    ICollection<KeyValuePair<string,object>>? linkTagsCollection =  ActivityExtensions.CreateTagsCollection();
                    if (linkTagsCollection != null)
                    {
                        foreach (var tag in activity.Tags)
                        {
                            linkTagsCollection.Add(new KeyValuePair<string, object>(tag.Key, tag.Value!));
                        }
                    }

                    var link = ActivityExtensions.CreateActivityLink(activity.ParentId!, activity.TraceStateString, linkTagsCollection);
                    if (link != null)
                    {
                        linkCollection.Add(link);
                    }
                }

                return linkCollection;
            }

            public void AddLink(string traceparent, string tracestate, IDictionary<string, string>? attributes)
            {
                var linkedActivity = new Activity("LinkedActivity");
                linkedActivity.SetW3CFormat();
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

            public void Start()
            {
                _currentActivity = StartActivitySourceActivity();

                if (_currentActivity == null)
                {
                    if (!_diagnosticSource.IsEnabled(_activityName, _diagnosticSourceArgs))
                    {
                        return;
                    }

                    _currentActivity = new DiagnosticActivity(_activityName)
                    {
                        Links = (IEnumerable<Activity>?)_links ?? Array.Empty<Activity>(),
                    };
                    _currentActivity.SetW3CFormat();

                    if (_startTime != default)
                    {
                        _currentActivity.SetStartTime(_startTime.DateTime);
                    }

                    if (_tagCollection != null)
                    {
                        foreach (var tag in _tagCollection)
                        {
                            _currentActivity.AddTag(tag.Key, (string)tag.Value);
                        }
                    }

                    _currentActivity.Start();
                }

                _diagnosticSource.Write(_activityName + ".Start", _diagnosticSourceArgs ?? _currentActivity);
            }

            private Activity? StartActivitySourceActivity()
            {
                return ActivityExtensions.ActivitySourceStartActivity(
                    _activitySource,
                    _activityName,
                    (int)_kind,
                    startTime: _startTime,
                    tags: _tagCollection,
                    links: GetActivitySourceLinkCollection());
            }

            public void SetStartTime(DateTime startTime)
            {
                _startTime = startTime;
                _currentActivity?.SetStartTime(startTime);
            }

            public void MarkFailed(Exception exception)
            {
                _diagnosticSource?.Write(_activityName + ".Exception", exception);
            }

            public void Dispose()
            {
                if (_currentActivity == null)
                {
                    return;
                }

                if (_currentActivity.Duration == TimeSpan.Zero)
                    _currentActivity.SetEndTime(DateTime.UtcNow);

                _diagnosticSource.Write(_activityName + ".Stop", _diagnosticSourceArgs);

                if (!_currentActivity.TryDispose())
                {
                    _currentActivity.Stop();
                }
            }
        }
    }

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

        private static Action<Activity, int>? SetIdFormatMethod;
        private static Func<Activity, string?>? GetTraceStateStringMethod;
        private static Func<Activity, int>? GetIdFormatMethod;
        private static Action<Activity, string, object?>? ActivityAddTagMethod;
        private static Func<object, string, int, ICollection<KeyValuePair<string, object>>?, IList?, DateTimeOffset, Activity?>? ActivitySourceStartActivityMethod;
        private static Func<object, bool>? ActivitySourceHasListenersMethod;
        private static Func<string, string?, ICollection<KeyValuePair<string, object>>?, object?>? CreateActivityLinkMethod;
        private static Func<ICollection<KeyValuePair<string,object>>?>? CreateTagsCollectionMethod;

        private static readonly ParameterExpression ActivityParameter = Expression.Parameter(typeof(Activity));

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
                    ActivityAddTagMethod = (_, _, _) => { };
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

        public static Activity? ActivitySourceStartActivity(object? activitySource, string activityName, int kind, DateTimeOffset startTime, ICollection<KeyValuePair<string, object>>? tags, IList? links)
        {
            if (activitySource == null)
            {
                return null;
            }

            if (ActivitySourceStartActivityMethod == null)
            {
                if (ActivityLinkType == null ||
                    ActivitySourceType == null ||
                    ActivityContextType == null ||
                    ActivityKindType == null)
                {
                    ActivitySourceStartActivityMethod = (_, _, _, _, _, _) => null;
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
                        ActivitySourceStartActivityMethod = (_, _, _, _, _, _) => null;
                    }
                    else
                    {
                        var sourceParameter = Expression.Parameter(typeof(object));
                        var nameParameter = Expression.Parameter(typeof(string));
                        var kindParameter = Expression.Parameter(typeof(int));
                        var startTimeParameter = Expression.Parameter(typeof(DateTimeOffset));
                        var tagsParameter = Expression.Parameter(typeof(ICollection<KeyValuePair<string, object>>));
                        var linksParameter = Expression.Parameter(typeof(IList));
                        var methodParameter = method.GetParameters();
                        ActivitySourceStartActivityMethod = Expression.Lambda<Func<object, string, int, ICollection<KeyValuePair<string, object>>?, IList?, DateTimeOffset, Activity?>>(
                            Expression.Call(
                                Expression.Convert(sourceParameter, method.DeclaringType!),
                                method,
                                nameParameter,
                                Expression.Convert(kindParameter,  methodParameter[1].ParameterType),
                                Expression.Default(ActivityContextType),
                                Expression.Convert(tagsParameter,  methodParameter[3].ParameterType),
                                Expression.Convert(linksParameter,  methodParameter[4].ParameterType),
                                Expression.Convert(startTimeParameter,  methodParameter[5].ParameterType)),
                            sourceParameter, nameParameter, kindParameter, tagsParameter, linksParameter,  startTimeParameter).Compile();
                    }
                }
            }

            return ActivitySourceStartActivityMethod.Invoke(activitySource, activityName, kind, tags, links, startTime);
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
}

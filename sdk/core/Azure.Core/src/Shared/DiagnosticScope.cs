// Copyright (c) Microsoft Corporation. All rights reserved.
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
#pragma warning disable CA1001 // Implement IDisposable
    internal readonly struct DiagnosticScope : IDisposable
#pragma warning restore CA1001 // Implement IDisposable
    {
        private static readonly ConcurrentDictionary<string, object?> ActivitySources = new ();

        private readonly ActivityAdapter? _activitySourceAdapter;

        internal DiagnosticScope(string ns, string scopeName, DiagnosticListener source, ActivityKind kind)
        {
            var activitySource = GetActivitySource(ns, scopeName);

            IsEnabled = source.IsEnabled() || ActivityExtensions.ActivitySourceHasListeners(activitySource);

            if (IsEnabled)
            {
                _activitySourceAdapter = new ActivityAdapter(activitySource, source, scopeName, kind, null);
            }
            else
            {
                _activitySourceAdapter = null;
            }
        }

        internal DiagnosticScope(string scopeName, DiagnosticListener source, object? diagnosticSourceArgs, object? activitySource, ActivityKind kind)
        {
            IsEnabled = source.IsEnabled() || ActivityExtensions.ActivitySourceHasListeners(activitySource);

            if (IsEnabled)
            {
                _activitySourceAdapter = new ActivityAdapter(activitySource, source, scopeName, kind, diagnosticSourceArgs);
            }
            else
            {
                _activitySourceAdapter = null;
            }
        }

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

        public bool IsEnabled { get; }

        public void AddAttribute(string name, string value)
        {
            _activitySourceAdapter?.AddTag(name, value);
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
            if (_activitySourceAdapter != null)
            {
                var formattedValue = format(value);
                _activitySourceAdapter.AddTag(name, formattedValue);
            }
        }

        public void AddLink(string id, IDictionary<string, string>? attributes = null)
        {
            _activitySourceAdapter?.AddLink(id, attributes);
        }

        public void Start()
        {
            _activitySourceAdapter?.Start();
        }

        public void SetStartTime(DateTime dateTime)
        {
            _activitySourceAdapter?.SetStartTime(dateTime);
        }

        public void Dispose()
        {
            // Reverse the Start order
            _activitySourceAdapter?.Dispose();
        }

        public void Failed(Exception e)
        {
            _activitySourceAdapter?.MarkFailed(e);
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
            private object? _diagnosticSourceArgs;
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
                    _currentActivity?.AddObjectTag(name, value!);
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

                    var link = ActivityExtensions.CreateActivityLink(activity.Id!, linkTagsCollection);
                    if (link != null)
                    {
                        linkCollection.Add(link);
                    }
                }

                return linkCollection;
            }

            public void AddLink(string id, IDictionary<string, string>? attributes)
            {
                var linkedActivity = new Activity("LinkedActivity");
                linkedActivity.SetW3CFormat();
                linkedActivity.SetParentId(id);

                if (attributes != null)
                {
                    foreach (var kvp in attributes)
                    {
                        linkedActivity.AddTag(kvp.Key, kvp.Value);
                    }
                }

                (_links ??= new List<Activity>()).Add(linkedActivity);
            }

            public void Start()
            {
                _currentActivity = StartActivitySourceActivity();

                if (_currentActivity == null)
                {
                    _currentActivity = new DiagnosticActivity(_activityName)
                    {
                        Links = (IEnumerable<Activity>?)_links ?? Array.Empty<Activity>(),
                    };
                    _currentActivity.SetW3CFormat();
                    _currentActivity.SetStartTime(_startTime.DateTime);
                }

                _diagnosticSourceArgs ??= _currentActivity;

                _diagnosticSource.Write(_activityName + ".Start", _diagnosticSourceArgs);
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
                if (_currentActivity != null)
                {
                    _diagnosticSource.Write(_activityName + ".Stop", _diagnosticSourceArgs);

                    if (!_currentActivity.TryDispose())
                    {
                        _currentActivity.Stop();
                    }
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
        private static readonly Type? s_activitySourceType = Type.GetType("System.Diagnostics.ActivitySource, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityKindType = Type.GetType("System.Diagnostics.ActivityKind, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityTagsCollectionType = Type.GetType("System.Diagnostics.ActivityTagsCollection, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityLinkType = Type.GetType("System.Diagnostics.ActivityLink, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityContextType = Type.GetType("System.Diagnostics.ActivityContext, System.Diagnostics.DiagnosticSource");

        private static Action<Activity, int>? s_setIdFormatMethod;
        private static Func<Activity, string?>? s_getTraceStateStringMethod;
        private static Func<Activity, int>? s_getIdFormatMethod;
        private static Action<Activity, string, object?>? s_activityAddTagMethod;
        private static Func<object, string, int, ICollection<KeyValuePair<string, object>>?, IList?, DateTimeOffset, Activity?>? s_activitySourceStartActivityMethod;
        private static Func<object, bool>? s_activitySourceHasListenersMethod;
        private static Func<string, ICollection<KeyValuePair<string, object>>?, object?>? s_createActivityLinkMethod;
        private static Func<ICollection<KeyValuePair<string,object>>?>? s_createTagsCollectionMethod;

        private static readonly ParameterExpression ActivityParameter = Expression.Parameter(typeof(Activity));

        public static void SetW3CFormat(this Activity activity)
        {
            if (s_setIdFormatMethod == null)
            {
                var method = typeof(Activity).GetMethod("SetIdFormat");
                if (method == null)
                {
                    s_setIdFormatMethod = (a, v) => { };
                }
                else
                {
                    var idParameter = Expression.Parameter(typeof(int));
                    var convertedId = Expression.Convert(idParameter, method.GetParameters()[0].ParameterType);

                    s_setIdFormatMethod = Expression.Lambda<Action<Activity, int>>(
                        Expression.Call(ActivityParameter, method, convertedId),
                        ActivityParameter, idParameter).Compile();
                }
            }

            s_setIdFormatMethod(activity, 2 /* ActivityIdFormat.W3C */);
        }

        public static bool IsW3CFormat(this Activity activity)
        {
            if (s_getIdFormatMethod == null)
            {
                var method = typeof(Activity).GetProperty("IdFormat")?.GetMethod;
                if (method == null)
                {
                    s_getIdFormatMethod = _ => -1;
                }
                else
                {
                    s_getIdFormatMethod = Expression.Lambda<Func<Activity, int>>(
                        Expression.Convert(Expression.Call(ActivityParameter, method), typeof(int)),
                        ActivityParameter).Compile();
                }
            }


            int result = s_getIdFormatMethod(activity);

            return result == 2 /* ActivityIdFormat.W3C */;
        }

        public static string? GetTraceState(this Activity activity)
        {
            if (s_getTraceStateStringMethod == null)
            {
                var method = typeof(Activity).GetProperty("TraceStateString")?.GetMethod;
                if (method == null)
                {
                    s_getTraceStateStringMethod = _ => null;
                }
                else
                {
                    s_getTraceStateStringMethod = Expression.Lambda<Func<Activity, string?>>(
                        Expression.Call(ActivityParameter, method),
                        ActivityParameter).Compile();
                }
            }

            return s_getTraceStateStringMethod(activity);
        }

        public static void AddObjectTag(this Activity activity, string name, object value)
        {
            if (s_activityAddTagMethod == null)
            {
                var method = typeof(Activity).GetMethod("AddTag", BindingFlags.Instance | BindingFlags.Public, null, new Type[]
                {
                    typeof(string),
                    typeof(object)
                }, null);

                if (method == null)
                {
                    s_activityAddTagMethod = (_, _, _) => { };
                }
                else
                {
                    var nameParameter = Expression.Parameter(typeof(string));
                    var valueParameter = Expression.Parameter(typeof(object));

                    s_activityAddTagMethod = Expression.Lambda<Action<Activity, string, object?>>(
                        Expression.Call(ActivityParameter, method, nameParameter, valueParameter),
                        ActivityParameter, nameParameter, valueParameter).Compile();
                }
            }

            s_activityAddTagMethod(activity, name, value);
        }

        public static bool SupportsActivitySource()
        {
            return s_activitySourceType != null;
        }


        public static ICollection<KeyValuePair<string,object>>? CreateTagsCollection()
        {
            if (s_createTagsCollectionMethod == null)
            {
                var ctor = s_activityTagsCollectionType?.GetConstructor(Array.Empty<Type>());
                if (ctor == null)
                {
                    s_createTagsCollectionMethod = () => null;
                }
                else
                {
                    s_createTagsCollectionMethod = Expression.Lambda<Func<ICollection<KeyValuePair<string,object>>?>>(
                        Expression.New(ctor)).Compile();
                }
            }

            return s_createTagsCollectionMethod();
        }

        public static object? CreateActivityLink(string id, ICollection<KeyValuePair<string,object>>? tags)
        {
            if (s_activityLinkType == null)
            {
                return null;
            }

            if (s_createActivityLinkMethod == null)
            {
                var parseMethod = s_activityContextType?.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);
                var ctor = s_activityLinkType?.GetConstructor(new[] { s_activityContextType!, s_activityTagsCollectionType! });

                if (parseMethod == null ||
                    ctor == null ||
                    s_activityTagsCollectionType == null ||
                    s_activityContextType == null)
                {
                    s_createActivityLinkMethod = (_, _) => null;
                }
                else
                {
                    var nameParameter = Expression.Parameter(typeof(string));
                    var tagsParameter = Expression.Parameter(typeof(ICollection<KeyValuePair<string,object>>));

                    s_createActivityLinkMethod = Expression.Lambda<Func<string, ICollection<KeyValuePair<string, object>>?, object?>>(
                        Expression.TryCatch(
                                Expression.Convert(Expression.New(ctor,
                                        Expression.Call(parseMethod, nameParameter, Expression.Default(typeof(string))),
                                Expression.Convert(tagsParameter, s_activityTagsCollectionType)), typeof(object)),
                        Expression.Catch(typeof(Exception), Expression.Default(typeof(object)))),
                             nameParameter, tagsParameter).Compile();
                }
            }

            return s_createActivityLinkMethod(id, tags);
        }

        public static bool ActivitySourceHasListeners(object? activitySource)
        {
            if (activitySource == null)
            {
                return false;
            }

            if (s_activitySourceHasListenersMethod == null)
            {
                var method = s_activitySourceType?.GetMethod("HasListeners", BindingFlags.Instance | BindingFlags.Public);
                if (method == null ||
                    s_activitySourceType == null)
                {
                    s_activitySourceHasListenersMethod = o => false;
                }
                else
                {
                    var sourceParameter = Expression.Parameter(typeof(object));
                    s_activitySourceHasListenersMethod = Expression.Lambda<Func<object, bool>>(
                        Expression.Call(Expression.Convert(sourceParameter, s_activitySourceType), method),
                        sourceParameter).Compile();
                }
            }

            return s_activitySourceHasListenersMethod.Invoke(activitySource);
        }

        public static Activity? ActivitySourceStartActivity(object? activitySource, string activityName, int kind, DateTimeOffset startTime, ICollection<KeyValuePair<string, object>>? tags, IList? links)
        {
            if (activitySource == null)
            {
                return null;
            }

            if (s_activitySourceStartActivityMethod == null)
            {
                if (s_activityLinkType == null ||
                    s_activitySourceType == null ||
                    s_activityContextType == null ||
                    s_activityKindType == null)
                {
                    s_activitySourceStartActivityMethod = (_, _, _, _, _, _) => null;
                }
                else
                {
                    var method = s_activitySourceType?.GetMethod("StartActivity", BindingFlags.Instance | BindingFlags.Public, null, new[]
                    {
                        typeof(string),
                        s_activityKindType,
                        s_activityContextType,
                        typeof(IEnumerable<KeyValuePair<string, object>>),
                        typeof(IEnumerable<>).MakeGenericType(s_activityLinkType),
                        typeof(DateTimeOffset)
                    }, null);

                    if (method == null)
                    {
                        s_activitySourceStartActivityMethod = (_, _, _, _, _, _) => null;
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
                        s_activitySourceStartActivityMethod = Expression.Lambda<Func<object, string, int, ICollection<KeyValuePair<string, object>>?, IList?, DateTimeOffset, Activity?>>(
                            Expression.Call(
                                Expression.Convert(sourceParameter, method.DeclaringType!),
                                method,
                                nameParameter,
                                Expression.Convert(kindParameter,  methodParameter[1].ParameterType),
                                Expression.Default(s_activityContextType),
                                Expression.Convert(tagsParameter,  methodParameter[3].ParameterType),
                                Expression.Convert(linksParameter,  methodParameter[4].ParameterType),
                                Expression.Convert(startTimeParameter,  methodParameter[5].ParameterType)),
                            sourceParameter, nameParameter, kindParameter, tagsParameter, linksParameter,  startTimeParameter).Compile();
                    }
                }
            }

            return s_activitySourceStartActivityMethod.Invoke(activitySource, activityName, kind, tags, links, startTime);
        }

        public static object? CreateActivitySource(string name)
        {
            if (s_activitySourceType == null)
            {
                return null;
            }
            return Activator.CreateInstance(s_activitySourceType,
                name, // name
                null // version
            );
        }

        public static IList? CreateLinkCollection()
        {
            if (s_activityLinkType == null)
            {
                return null;
            }
            return Activator.CreateInstance(typeof(List<>).MakeGenericType(s_activityLinkType)) as IList;
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
    }
}
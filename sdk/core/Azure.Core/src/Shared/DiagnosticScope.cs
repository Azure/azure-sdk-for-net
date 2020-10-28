﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Core.Pipeline
{
    internal readonly struct DiagnosticScope : IDisposable
    {
        private static readonly ConcurrentDictionary<string, object?> ActivitySources = new ConcurrentDictionary<string, object?>();

        private readonly DiagnosticActivity? _oldStyleActivity;

        private readonly DiagnosticListener _source;
        private readonly ActivitySourceAdapter? _activityAdapter;

        internal DiagnosticScope(string ns, string name, DiagnosticListener source)
        {
            _activityAdapter = null;
            _source = source;
            _oldStyleActivity = _source.IsEnabled(name) ? new DiagnosticActivity(name) : null;
            _oldStyleActivity?.SetW3CFormat();

            if (!ActivityExtensions.SupportsActivitySource())
            {
                return;
            }

            int indexOfDot = name.IndexOf(".", StringComparison.OrdinalIgnoreCase);
            if (indexOfDot == -1)
            {
                return;
            }

            string clientName = ns + "." + name.Substring(0, indexOfDot);
            string methodName = name.Substring(indexOfDot + 1);

            var currentSource = ActivitySources.GetOrAdd(clientName, n => ActivityExtensions.CreateActivitySource(n));
            if (currentSource != null)
            {
                _activityAdapter = new ActivitySourceAdapter(currentSource, methodName);
            }
        }

        public bool IsEnabled => _oldStyleActivity != null || _activityAdapter?.HasListeners() == true;

        public void AddAttribute(string name, string value)
        {
            _oldStyleActivity?.AddTag(name, value);
            _activityAdapter?.AddTag(name, value);
        }

        public void AddAttribute<T>(string name, T value)
        {
            if (_oldStyleActivity != null && value != null)
            {
                AddAttribute(name, value.ToString() ?? string.Empty);
            }

            _activityAdapter?.AddTag(name, value);
        }

        public void AddAttribute<T>(string name, T value, Func<T, string> format)
        {
            if (_oldStyleActivity != null || _activityAdapter != null)
            {
                var formattedValue = format(value);
                AddAttribute(name, formattedValue);
            }
        }

        public void AddLink(string id, IDictionary<string, string>? attributes = null)
        {
            if (_oldStyleActivity != null)
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

                _oldStyleActivity.AddLink(linkedActivity);
            }

            _activityAdapter?.AddLink(id, attributes);
        }

        public void Start()
        {
            if (_oldStyleActivity != null)
            {
                _source.StartActivity(_oldStyleActivity, _oldStyleActivity);
            }

            _activityAdapter?.Start();
        }

        public void SetStartTime(DateTime dateTime)
        {
            _oldStyleActivity?.SetStartTime(dateTime);
            _activityAdapter?.SetStartTime(dateTime);
        }

        public void Dispose()
        {
            if (_oldStyleActivity != null)
            {
                _source.StopActivity(_oldStyleActivity, null);
            }

            _activityAdapter?.Dispose();
        }

        public void Failed(Exception e)
        {
            if (_oldStyleActivity != null)
            {
                _source?.Write(_oldStyleActivity.OperationName + ".Exception", e);
            }

            _activityAdapter?.MarkFailed(e);
        }

        private class DiagnosticActivity : Activity
        {
            private List<Activity>? _links;

            public IEnumerable<Activity> Links => (IEnumerable<Activity>?) _links ?? Array.Empty<Activity>();

            public DiagnosticActivity(string operationName) : base(operationName)
            {
            }

            public void AddLink(Activity activity)
            {
                _links ??= new List<Activity>();
                _links.Add(activity);
            }
        }

        private class ActivitySourceAdapter
        {
            private readonly object _activitySource;
            private readonly string _activityName;
            private Activity? _currentActivity;
            private ICollection<KeyValuePair<string,object>>? _tagCollection;
            private DateTimeOffset _startTime;
            private IList? _linkCollection;

            public ActivitySourceAdapter(object activitySource, string activityName)
            {
                _activitySource = activitySource;
                _activityName = activityName;
            }

            public void AddTag<T>(string name, T value)
            {
                _tagCollection ??= ActivityExtensions.CreateTagsCollection();
                if (_tagCollection != null)
                {
                    _tagCollection.Add(new KeyValuePair<string, object>(name, value!));
                }
            }

            public void AddLink(string id, IDictionary<string, string>? attributes)
            {
                _linkCollection ??= ActivityExtensions.CreateLinkCollection();

                if (_linkCollection == null)
                {
                    return;
                }

                ICollection<KeyValuePair<string,object>>? linkTagsCollection = null;
                if (attributes != null)
                {
                    linkTagsCollection ??= ActivityExtensions.CreateTagsCollection();

                    if (linkTagsCollection != null)
                    {
                        foreach (var attribute in attributes)
                        {
                            linkTagsCollection.Add(new KeyValuePair<string, object>(attribute.Key, attribute.Value));
                        }
                    }
                }

                var link = ActivityExtensions.CreateActivityLink(id, linkTagsCollection);
                if (link != null)
                {
                    _linkCollection.Add(link);
                }
            }

            public bool HasListeners() => ActivityExtensions.ActivitySourceHasListeners(_activitySource);

            public void Start()
            {
                _currentActivity = ActivityExtensions.ActivitySourceStartActivity(
                    _activitySource,
                    _activityName,
                    ActivityExtensions.ActivityKindInternal,
                    startTime: _startTime,
                    tags: _tagCollection,
                    links: _linkCollection);
            }

            public void SetStartTime(DateTime startTime)
            {
                _startTime = startTime;
            }

            public void MarkFailed(Exception exception)
            {
                // See https://github.com/open-telemetry/opentelemetry-dotnet/blob/master/src/OpenTelemetry.Api/Trace/StatusCode.cs
                // and https://github.com/open-telemetry/opentelemetry-dotnet/blob/master/src/OpenTelemetry.Api/Trace/ActivityExtensions.cs#L45
                // Unset = 0,
                // Error = 1
                // Ok = 2
                _currentActivity?.AddObjectTag("otel.status_code", 1);
                _currentActivity?.AddTag("otel.status_description", exception.Message);
            }

            public void Dispose()
            {
                (_currentActivity as IDisposable)?.Dispose();
            }
        }
    }
    /// <summary>
    /// WORKAROUND. Some runtime environments like Azure.Functions downgrade System.Diagnostic.DiagnosticSource package version causing method not found exceptions in customer apps
    /// This type is a temporary workaround to avoid the issue.
    /// </summary>
    internal static class ActivityExtensions
    {
        private static readonly Type? s_activitySourceType = Type.GetType("System.Diagnostics.ActivitySource, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityKindType = Type.GetType("System.Diagnostics.ActivityKind, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityTagsCollectionType = Type.GetType("System.Diagnostics.ActivityTagsCollection, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityLinkType = Type.GetType("System.Diagnostics.ActivityLink, System.Diagnostics.DiagnosticSource");
        private static readonly Type? s_activityContextType = Type.GetType("System.Diagnostics.ActivityContext, System.Diagnostics.DiagnosticSource");

        private static readonly MethodInfo? s_activityContextParseMethod = s_activityContextType?.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);

        private static Action<Activity, int>? s_setIdFormatMethod;
        private static Func<Activity, string?>? s_getTraceStateStringMethod;
        private static Func<Activity, int>? s_getIdFormatMethod;
        private static Action<Activity, string, object?>? s_activityAddTagMethod;
        private static Func<object, string, int, ICollection<KeyValuePair<string, object>>?, IList?, DateTimeOffset, Activity?>? s_activitySourceStartActivityMethod;
        private static Func<object, bool>? s_activitySourceHasListenersMethod;

        private static readonly ParameterExpression ActivityParameter = Expression.Parameter(typeof(Activity));
        public const int ActivityKindInternal = 0;

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
                    s_activityAddTagMethod = (a, n, v) => { };
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

        public static ICollection<KeyValuePair<string,object>>? CreateTagsCollection()
        {
            if (s_activityTagsCollectionType == null)
            {
                return null;
            }

            return Activator.CreateInstance(s_activityTagsCollectionType) as ICollection<KeyValuePair<string,object>>;
        }

        public static object? CreateActivityLink(string id, ICollection<KeyValuePair<string,object>>? tags)
        {
            if (s_activityLinkType == null ||
                s_activityContextParseMethod == null)
            {
                return null;
            }

            Debug.Assert(tags == null || tags.GetType() == s_activityTagsCollectionType);

            var context = s_activityContextParseMethod.Invoke(null, new object?[] {id, null});
            return Activator.CreateInstance(s_activityLinkType, new object?[]
            {
                context, tags
            });
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
                var method = s_activitySourceType?.GetMethod("StartActivity", BindingFlags.Instance | BindingFlags.Public, null, new[]
                {
                    typeof(string),
                    s_activityKindType,
                    s_activityContextType!,
                    typeof(IEnumerable<KeyValuePair<string, object>>),
                    typeof(IEnumerable<>).MakeGenericType(s_activityLinkType),
                    typeof(DateTimeOffset)
                }, null);

                if (method == null ||
                    s_activitySourceType == null ||
                    s_activityContextType == null ||
                    s_activityKindType == null
                    )
                {
                    s_activitySourceStartActivityMethod = (activitySource, activityName, kind, startTime, tags, links) => null;
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

            return s_activitySourceStartActivityMethod.Invoke(activitySource, activityName, kind, tags, links, startTime);
        }

        public static IList? CreateLinkCollection()
        {
            return Activator.CreateInstance(typeof(List<>).MakeGenericType(s_activityLinkType)) as IList;
        }
    }
}
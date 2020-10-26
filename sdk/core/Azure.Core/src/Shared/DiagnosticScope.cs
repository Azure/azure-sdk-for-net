// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Azure.Core.Pipeline
{
    internal readonly struct DiagnosticScope : IDisposable
    {
        private static readonly ConcurrentDictionary<string, ActivitySource> _activitySources = new ConcurrentDictionary<string, ActivitySource>();
        private readonly DiagnosticActivity? _oldStyleActivity;

        private readonly DiagnosticListener _source;
        private readonly ActivitySourceAdapter? _activityAdapter;

        internal DiagnosticScope(string ns, string name, DiagnosticListener source)
        {
            _activityAdapter = null;
            _source = source;
            _oldStyleActivity = _source.IsEnabled(name) ? new DiagnosticActivity(name) : null;
            _oldStyleActivity?.SetW3CFormat();

            int indexOfDot = name.IndexOf(".", StringComparison.OrdinalIgnoreCase);
            if (indexOfDot == -1)
            {
                return;
            }

            string clientName = ns + "." + name.Substring(0, indexOfDot);
            string methodName = name.Substring(indexOfDot + 1);

            var currentSource = _activitySources.GetOrAdd(clientName, n => new ActivitySource(n));
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

            _activityAdapter?.MarkFailed();
        }

        private class DiagnosticActivity : Activity
        {
            private List<Activity>? _links;

            public new IEnumerable<Activity> Links => (IEnumerable<Activity>?) _links ?? Array.Empty<Activity>();

            public DiagnosticActivity(string operationName) : base(operationName)
            {
            }

            public void AddLink(Activity activity)
            {
                _links ??= new List<Activity>();
                _links.Add(activity);
            }
        }

        internal class ActivitySourceAdapter
        {
            private readonly ActivitySource _activitySource;
            private readonly string _activityName;
            private Activity? _currentActivity;
            private ActivityTagsCollection? _tagCollection;
            private DateTimeOffset? _startTime;
            private List<ActivityLink>? _linkCollection;

            public ActivitySourceAdapter(ActivitySource activitySource, string activityName)
            {
                _activitySource = activitySource;
                _activityName = activityName;
            }

            public void AddTag<T>(string name, T value)
            {
                _tagCollection ??= new ActivityTagsCollection();
                _tagCollection.Add(name, value);
            }

            public void AddLink(string id, IDictionary<string, string>? attributes)
            {
                _linkCollection ??= new List<ActivityLink>();

                ActivityTagsCollection? linkTagsCollection = null;
                if (attributes != null)
                {
                    linkTagsCollection ??= new ActivityTagsCollection();
                }

                _linkCollection.Add(new ActivityLink(ActivityContext.Parse(id, null), linkTagsCollection));
            }

            public bool HasListeners() => _activitySource.HasListeners();

            public void Start()
            {
                if (_startTime.HasValue)
                {
                    _currentActivity = _activitySource.StartActivity(_activityName, ActivityKind.Internal, default(ActivityContext), startTime: _startTime.Value, tags: _tagCollection, links: _linkCollection);
                }
                else
                {
                    _currentActivity = _activitySource.StartActivity(_activityName, ActivityKind.Internal, default(ActivityContext), tags: _tagCollection, links: _linkCollection);
                }
            }

            public void SetStartTime(DateTime startTime)
            {
                _startTime = startTime;
            }

            public void MarkFailed()
            {
                // See https://github.com/open-telemetry/opentelemetry-dotnet/blob/master/src/OpenTelemetry.Api/Trace/StatusCode.cs
                // and https://github.com/open-telemetry/opentelemetry-dotnet/blob/master/src/OpenTelemetry.Api/Trace/ActivityExtensions.cs#L45
                // Unset = 0,
                // Error = 1
                // Ok = 2
                _currentActivity?.AddTag("otel.status_code", 1);
            }

            public void Dispose()
            {
                _currentActivity?.Dispose();
            }
        }
    }
    /// <summary>
    /// WORKAROUND. Some runtime environments like Azure.Functions downgrade System.Diagnostic.DiagnosticSource package version causing method not found exceptions in customer apps
    /// This type is a temporary workaround to avoid the issue.
    /// </summary>
    internal static class ActivityExtensions
    {
        private static readonly MethodInfo? s_setIdFormatMethod = typeof(Activity).GetMethod("SetIdFormat");
        private static readonly MethodInfo? s_getIdFormatMethod = typeof(Activity).GetProperty("IdFormat")?.GetMethod;
        private static readonly MethodInfo? s_getTraceStateStringMethod = typeof(Activity).GetProperty("TraceStateString")?.GetMethod;

        public static bool SetW3CFormat(this Activity activity)
        {
            if (s_setIdFormatMethod == null) return false;

            s_setIdFormatMethod.Invoke(activity, new object[] {2 /* ActivityIdFormat.W3C */});

            return true;
        }

        public static bool IsW3CFormat(this Activity activity)
        {
            if (s_getIdFormatMethod == null) return false;

            object? result = s_getIdFormatMethod.Invoke(activity, Array.Empty<object>());

            return result != null && (int) result == 2 /* ActivityIdFormat.W3C */;
        }

        public static bool TryGetTraceState(this Activity activity, out string? traceState)
        {
            traceState = null;

            if (s_getTraceStateStringMethod == null) return false;

            traceState = s_getTraceStateStringMethod.Invoke(activity, Array.Empty<object>()) as string;

            return true;
        }
    }
}
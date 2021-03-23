// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Azure.Core.Pipeline
{
    internal readonly struct DiagnosticScope : IDisposable
    {
        private readonly DiagnosticActivity? _activity;

        private readonly string _name;

        private readonly DiagnosticListener _source;

        internal DiagnosticScope(string name, DiagnosticListener source)
        {
            _name = name;
            _source = source;
            _activity = _source.IsEnabled(_name) ? new DiagnosticActivity(_name) : null;
            _activity?.SetW3CFormat();
        }

        public bool IsEnabled => _activity != null;

        public void AddAttribute(string name, string value)
        {
            _activity?.AddTag(name, value);
        }

        public void AddAttribute<T>(string name, T value)
        {
            if (_activity != null && value != null)
            {
                AddAttribute(name, value.ToString() ?? string.Empty);
            }
        }

        public void AddAttribute<T>(string name, T value, Func<T, string> format)
        {
            if (_activity != null)
            {
                AddAttribute(name, format(value));
            }
        }

        public void AddLink(string id, IDictionary<string, string>? attributes = null)
        {
            if (_activity != null)
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

                _activity.AddLink(linkedActivity);
            }
        }

        public void Start()
        {
            if (_activity != null)
            {
                _source.StartActivity(_activity, _activity);
            }
        }

        public void SetStartTime(DateTime dateTime) => _activity?.SetStartTime(dateTime);

        public void Dispose()
        {
            if (_activity == null)
            {
                return;
            }

            if (_source != null)
            {
                _source.StopActivity(_activity, null);
            }
            else
            {
                _activity?.Stop();
            }
        }

        public void Failed(Exception e)
        {
            if (_activity == null)
            {
                return;
            }

            _source?.Write(_activity.OperationName + ".Exception", e);
        }

        private class DiagnosticActivity : Activity
        {
            private List<Activity>? _links;

#pragma warning disable 109 // extra new modifier
            public new IEnumerable<Activity> Links => (IEnumerable<Activity>?)_links ?? Array.Empty<Activity>();
#pragma warning restore 109

            public DiagnosticActivity(string operationName) : base(operationName)
            {
            }

            public void AddLink(Activity activity)
            {
                _links ??= new List<Activity>();
                _links.Add(activity);
            }
        }
    }

    /// <summary>
    /// HACK HACK HACK. Some runtime environments like Azure.Functions downgrade System.Diagnostic.DiagnosticSource package version causing method not found exceptions in customer apps
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

            s_setIdFormatMethod.Invoke(activity, new object[]{ 2 /* ActivityIdFormat.W3C */});

            return true;
        }

        public static bool IsW3CFormat(this Activity activity)
        {
            if (s_getIdFormatMethod == null) return false;

            object? result = s_getIdFormatMethod.Invoke(activity, Array.Empty<object>());

            return result != null && (int)result == 2 /* ActivityIdFormat.W3C */;
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

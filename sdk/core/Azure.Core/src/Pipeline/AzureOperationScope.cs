// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Core.Pipeline
{
    public readonly struct DiagnosticScope: IDisposable
    {
        private readonly DiagnosticActivity? _activity;

        private readonly string _name;

        private readonly DiagnosticListener _source;

        internal DiagnosticScope(string name, DiagnosticListener source)
        {
            _name = name;
            _source = source;
            _activity = _source.IsEnabled() ? new DiagnosticActivity(_name) : null;
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
                AddAttribute(name, value.ToString());
            }
        }

        public void AddAttribute<T>(string name, T value, Func<T, string> format)
        {
            if (_activity != null)
            {
                AddAttribute(name, format(value));
            }
        }

        public void AddLink(string id)
        {
            if (_activity != null)
            {
                var linkedActivity = new Activity("LinkedActivity");
                linkedActivity.SetW3CFormat();
                linkedActivity.SetParentId(id);

                _activity.AddLink(linkedActivity);
            }
        }

        public void Start()
        {
            if (_activity != null && _source.IsEnabled(_name))
            {
                _source.StartActivity(_activity, _activity);
            }
        }

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

            public IEnumerable<Activity> Links => (IEnumerable<Activity>?)_links ?? Array.Empty<Activity>();

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
}

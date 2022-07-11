// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Diagnostics.Metrics;

#nullable enable
#pragma warning disable SA1402

namespace Azure.Core.Shared
{
    internal class DiagnosticMeter : IDisposable
    {
        private readonly MetricsOptions? _options;
        private readonly Meter? _meter;

        public DiagnosticMeter(string name, string? version, MetricsOptions? options = null)
        {
            _options = options;
            if (_options == null || _options.IsEnabled)
            {
                _meter = new Meter(name, version);
            }
        }

        public DiagnosticCounter<T> CreateCounter<T>(string name, string? unit = default, string? description = default) where T : struct
        {
            return new DiagnosticCounter<T>(_meter?.CreateCounter<T>(name, unit, description));
        }

        public DiagnosticHistogram<T> CreateHistogram<T>(string name, string? unit = default, string? description = default) where T : struct
        {
            return new DiagnosticHistogram<T>(_meter?.CreateHistogram<T>(name, unit, description));
        }

        public void Dispose()
        {
            _meter?.Dispose();
        }
    }

    internal class DiagnosticCounter<T> where T : struct
    {
        public bool IsEnabled { get; }
        private readonly Counter<T>? _counter;
        internal DiagnosticCounter(Counter<T>? counter)
        {
            _counter = counter;
            IsEnabled = _counter?.Enabled ?? false;
        }

        public void Add(T delta, DiagnosticAttributes attributes)
        {
            _counter?.Add(delta, attributes.Attributes);
        }
    }

    internal class DiagnosticHistogram<T> where T : struct
    {
        public bool IsEnabled { get; }
        private readonly Histogram<T>? _histogram;
        internal DiagnosticHistogram(Histogram<T>? histogram)
        {
            _histogram = histogram;
            IsEnabled = _histogram?.Enabled ?? false;
        }

        public void Record(T value, DiagnosticAttributes attributes)
        {
            _histogram?.Record(value, attributes.Attributes);
        }
    }

    /// <summary>
    /// Allows to pre-build and cache list of attributes:
    /// - limits set of supported tag value types
    /// - allows to remap attribute names if otel schema changes
    /// - caches attributes array - Add call happens at client creation time only, .Attributes on every metric report
    /// - in some cases can be shared between metrics and tracing (can pass them to scopes)
    /// </summary>
    internal class DiagnosticAttributes
    {
        private readonly List<KeyValuePair<string, object?>> _attributes = new List<KeyValuePair<string, object?>>();
        private KeyValuePair<string, object?>[]? _attributesArray;

        public DiagnosticAttributes Add(string key, string value)
        {
            _attributes.Add(new KeyValuePair<string, object?>(key, value));
            _attributesArray = null;
            return this;
        }

        public DiagnosticAttributes Add(string key, long value)
        {
            _attributes.Add(new KeyValuePair<string, object?>(key, value));
            _attributesArray = null;
            return this;
        }

        public DiagnosticAttributes Add(string key, double value)
        {
            _attributes.Add(new KeyValuePair<string, object?>(key, value));
            _attributesArray = null;
            return this;
        }

        // and would remain internal even if DiagnosticAttributes become public at some point
        internal KeyValuePair<string, object?>[] Attributes {
            get {
                _attributesArray ??= _attributes.ToArray();

                return _attributesArray;
            }
        }
    }
}

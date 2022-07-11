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

        public DiagnosticMeter(string name, string? version, MetricsOptions? options)
        {
            _meter = new Meter(name, version);
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

        public DiagnosticHistogram<T> CreateHistorgram<T>(string name, string? unit = default, string? description = default) where T : struct
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

        public void Add(T delta, DiagnosticTags tags)
        {
            _counter?.Add(delta, tags.AsSpan());
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

        public void Record(T value, DiagnosticTags tags)
        {
            _histogram?.Record(value, tags.AsSpan());
        }
    }

    /// <summary>
    /// Allows to pre-build and cache list of attributes:
    /// - limits set of supported tag value types
    /// - allows to remap attribute names if otel schema changes
    /// - caches tags array - Add call happens at client creation time only, AsSpan on every metric report
    /// </summary>
    internal class DiagnosticTags
    {
        private readonly List<KeyValuePair<string, object?>> _tags = new List<KeyValuePair<string, object?>>();
        private KeyValuePair<string, object?>[]? _tagsArray;

        public DiagnosticTags Add(string key, string value)
        {
            _tags.Add(new KeyValuePair<string, object?>(key, value));
            _tagsArray = null;
            return this;
        }

        public DiagnosticTags Add(string key, long value)
        {
            _tags.Add(new KeyValuePair<string, object?>(key, value));
            _tagsArray = null;
            return this;
        }

        public DiagnosticTags Add(string key, double value)
        {
            _tags.Add(new KeyValuePair<string, object?>(key, value));
            _tagsArray = null;
            return this;
        }

        internal ReadOnlySpan<KeyValuePair<string, object?>> AsSpan()
        {
            if (_tagsArray == null)
            {
                _tagsArray = _tags.ToArray();
            }

            return new ReadOnlySpan<KeyValuePair<string, object?>>(_tagsArray);
        }
    }
}

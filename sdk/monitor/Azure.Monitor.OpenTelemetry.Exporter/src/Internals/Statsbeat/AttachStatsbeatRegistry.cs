// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class AttachStatsbeatRegistry
    {
        internal const int Capacity = 2000;

        private const int NonEuRegion = 1;
        private const int EuRegion = 2;
        private readonly Dictionary<string, Entry> _entries = new(StringComparer.Ordinal);
        private readonly object _gate = new();
        private long _completedCollections;
        private int _count;
        private bool _closed;
        private int _enabledRegions = NonEuRegion | EuRegion;

        internal int Count => Volatile.Read(ref _count);

        internal void Observe(EndpointRouteBatch batch, long now)
        {
            while (true)
            {
                var enabledRegions = Volatile.Read(ref _enabledRegions);
                if (enabledRegions == 0)
                {
                    return;
                }

                var observations = batch.AttachObservations ??= new ObservationBuffer();
                observations.Prepare(batch, enabledRegions);
                lock (_gate)
                {
                    if (_closed)
                    {
                        return;
                    }
                    // Rebuild if configuration changed which region should win for a duplicate key.
                    if (enabledRegions != _enabledRegions)
                    {
                        continue;
                    }

                    foreach (var observation in observations.Items)
                    {
                        ObserveKey(observation.Key, now, observation.Value);
                    }
                    Volatile.Write(ref _count, _entries.Count);
                    return;
                }
            }
        }

        private void ObserveKey(string key, long now, bool isEu)
        {
            if (_entries.TryGetValue(key, out var entry))
            {
                if (now >= entry.LastSeen)
                {
                    entry.LastSeen = now;
                    entry.IsEu = isEu;
                }
            }
            else if (_entries.Count < Capacity)
            {
                _entries.Add(key, new Entry { LastSeen = now, IsEu = isEu });
            }
        }

        private static bool IsRegionEnabled(int enabledRegions, bool isEu)
            => (enabledRegions & (isEu ? EuRegion : NonEuRegion)) != 0;

        internal IReadOnlyDictionary<string, bool> Collect(long now, long intervalTicks)
        {
            var due = new Dictionary<string, bool>(StringComparer.Ordinal);
            lock (_gate)
            {
                var completedCollections = Interlocked.Read(ref _completedCollections);
                List<string>? expired = null;
                foreach (var pair in _entries)
                {
                    var entry = pair.Value;
                    var enabled = IsRegionEnabled(_enabledRegions, entry.IsEu);
                    var inactive = now - Math.Max(entry.LastSeen, entry.LastReported) >= intervalTicks;

                    // An idle SDK collection must finish before its slots can be reused.
                    // Removing an entry at the start of that collection would admit replacements
                    // before OTel reclaims the previous points, causing identity-losing overflow.
                    if ((!enabled || (inactive && entry.LastReported >= 0))
                        && (entry.LastReported < 0 || completedCollections >= entry.LastCollection + 2))
                    {
                        (expired ??= new List<string>()).Add(pair.Key);
                        continue;
                    }

                    if (!enabled || (inactive && entry.LastReported >= 0)
                        || (entry.LastReported >= 0 && now - entry.LastReported < intervalTicks))
                    {
                        continue;
                    }

                    entry.LastReported = now;
                    entry.LastCollection = completedCollections;
                    due.Add(pair.Key, entry.IsEu);
                }

                if (expired != null)
                {
                    foreach (var key in expired)
                    {
                        _entries.Remove(key);
                    }
                    Volatile.Write(ref _count, _entries.Count);
                }
            }

            return due;
        }

        internal void SetEnabledRegions(bool nonEuEnabled, bool euEnabled)
        {
            lock (_gate)
            {
                if (_closed)
                {
                    return;
                }
                Volatile.Write(ref _enabledRegions, (nonEuEnabled ? NonEuRegion : 0) | (euEnabled ? EuRegion : 0));
                if (!nonEuEnabled && !euEnabled)
                {
                    _entries.Clear();
                    Volatile.Write(ref _count, 0);
                }
            }
        }

        internal void CompleteCollection() => Interlocked.Increment(ref _completedCollections);

        internal void Close()
        {
            lock (_gate)
            {
                _closed = true;
                Volatile.Write(ref _enabledRegions, 0);
                _entries.Clear();
                Volatile.Write(ref _count, 0);
            }
        }

        internal sealed class ObservationBuffer
        {
            private readonly Dictionary<string, int> _indices = new(StringComparer.Ordinal);

            internal List<KeyValuePair<string, bool>> Items { get; } = new();

            internal void Prepare(EndpointRouteBatch batch, int enabledRegions)
            {
                Clear();
                for (int i = 0; i < batch.Count; i++)
                {
                    var group = batch[i];
                    var isEu = group.StatsbeatIsEu;
                    if (!IsRegionEnabled(enabledRegions, isEu))
                    {
                        continue;
                    }

                    string? previousKey = null;
                    foreach (var item in group.TelemetryItems)
                    {
                        var key = item.InstrumentationKey;
                        if (string.IsNullOrEmpty(key) || string.Equals(key, previousKey, StringComparison.Ordinal))
                        {
                            continue;
                        }
                        previousKey = key;

                        if (_indices.TryGetValue(key, out var index))
                        {
                            Items[index] = new(Items[index].Key, isEu);
                        }
                        else
                        {
                            // Keep first-admission order while the last enabled group supplies the region.
                            _indices.Add(key, Items.Count);
                            Items.Add(new(key, isEu));
                        }
                    }
                }
            }

            internal void Clear()
            {
                _indices.Clear();
                Items.Clear();
            }
        }

        private sealed class Entry
        {
            internal long LastSeen;
            internal long LastReported = -1;
            internal long LastCollection;
            internal bool IsEu;
        }
    }
}

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

        private readonly Dictionary<string, Entry> _entries = new(StringComparer.Ordinal);
        private readonly object _gate = new();
        private long _completedCollections;
        private int _count;
        private bool _closed;
        private bool _nonEuEnabled = true;
        private bool _euEnabled = true;

        internal int Count => Volatile.Read(ref _count);

        internal void Observe(EndpointRouteBatch batch, long now)
        {
            lock (_gate)
            {
                if (_closed)
                {
                    return;
                }
                for (int i = 0; i < batch.Count; i++)
                {
                    var group = batch[i];
                    var isEu = AzureMonitorStatsbeat.IsEuRegion(group.IngestionEndpoint);
                    if (!(isEu ? _euEnabled : _nonEuEnabled))
                    {
                        continue;
                    }

                    ObserveGroup(group, now, isEu);
                }
                Volatile.Write(ref _count, _entries.Count);
            }
        }

        private void ObserveGroup(EndpointRouteBatch.Group group, long now, bool isEu)
        {
            string? previousKey = null;
            foreach (var item in group.TelemetryItems)
            {
                var key = item.InstrumentationKey;
                if (string.IsNullOrEmpty(key) || ReferenceEquals(key, previousKey))
                {
                    continue;
                }
                previousKey = key;

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
        }

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
                    var enabled = entry.IsEu ? _euEnabled : _nonEuEnabled;
                    var inactive = now - Math.Max(entry.LastSeen, entry.LastReported) >= intervalTicks;

                    // An idle SDK collection must finish before its slots can be reused.
                    // Removing an entry at the start of that collection would admit replacements
                    // before OTel reclaims the previous points, causing identity-losing overflow.
                    if ((!enabled || (inactive && entry.LastReported != 0))
                        && (entry.LastReported == 0 || completedCollections >= entry.LastCollection + 2))
                    {
                        (expired ??= new List<string>()).Add(pair.Key);
                        continue;
                    }

                    if (!enabled || (inactive && entry.LastReported != 0)
                        || (entry.LastReported != 0 && now - entry.LastReported < intervalTicks))
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
                _nonEuEnabled = nonEuEnabled;
                _euEnabled = euEnabled;
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
                _entries.Clear();
                Volatile.Write(ref _count, 0);
            }
        }

        private sealed class Entry
        {
            internal long LastSeen;
            internal long LastReported;
            internal long LastCollection;
            internal bool IsEu;
        }
    }
}

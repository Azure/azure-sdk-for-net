// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class AttachStatsbeatRegistry
    {
        internal const int Capacity = 2000;

        private readonly Dictionary<string, Entry> _entries = new(StringComparer.Ordinal);
        private readonly object _gate = new();
        private long _completedCollections;

        internal int Count
        {
            get
            {
                lock (_gate)
                {
                    return _entries.Count;
                }
            }
        }

        internal void Observe(EndpointRouteBatch batch, long now, bool nonEuEnabled = true, bool euEnabled = true)
        {
            for (int i = 0; i < batch.Count; i++)
            {
                var group = batch[i];
                var isEu = AzureMonitorStatsbeat.IsEuRegion(group.IngestionEndpoint);
                if (!(isEu ? euEnabled : nonEuEnabled))
                {
                    continue;
                }
                lock (_gate)
                {
                    foreach (var item in group.TelemetryItems)
                    {
                        var key = item.InstrumentationKey;
                        if (string.IsNullOrEmpty(key))
                        {
                            continue;
                        }

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
            }
        }

        internal List<string> Collect(long now, long intervalTicks, bool nonEuEnabled, bool euEnabled)
        {
            var due = new List<string>();
            lock (_gate)
            {
                List<string>? expired = null;
                foreach (var pair in _entries)
                {
                    var entry = pair.Value;
                    var enabled = entry.IsEu ? euEnabled : nonEuEnabled;
                    var inactive = now - Math.Max(entry.LastSeen, entry.LastReported) >= intervalTicks;

                    // An idle SDK collection must finish before its slots can be reused.
                    // Removing an entry at the start of that collection would admit replacements
                    // before OTel reclaims the previous points, causing identity-losing overflow.
                    if ((!enabled || (inactive && entry.LastReported != 0))
                        && (entry.LastReported == 0 || _completedCollections >= entry.LastCollection + 2))
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
                    entry.LastCollection = _completedCollections;
                    entry.ReportIsEu = entry.IsEu;
                    due.Add(pair.Key);
                }

                if (expired != null)
                {
                    foreach (var key in expired)
                    {
                        _entries.Remove(key);
                    }
                }
            }

            return due;
        }

        internal bool TryGetReportRegion(string key, out bool isEu)
        {
            lock (_gate)
            {
                if (_entries.TryGetValue(key, out var entry) && entry.LastReported != 0)
                {
                    isEu = entry.ReportIsEu;
                    return true;
                }
            }

            isEu = false;
            return false;
        }

        internal void CompleteCollection()
        {
            lock (_gate)
            {
                _completedCollections++;
            }
        }

        internal void Clear()
        {
            lock (_gate)
            {
                _entries.Clear();
            }
        }

        private sealed class Entry
        {
            internal long LastSeen;
            internal long LastReported;
            internal long LastCollection;
            internal bool IsEu;
            internal bool ReportIsEu;
        }
    }
}

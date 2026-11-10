// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
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
        private RegistryState? _registry = new(NonEuRegion | EuRegion);
        private long _completedCollections;

        internal int Count
        {
            get
            {
                var registry = Volatile.Read(ref _registry);
                return registry == null ? 0 : Volatile.Read(ref registry.Count);
            }
        }

        internal void Observe(EndpointRouteBatch batch, long now)
        {
            var registry = Volatile.Read(ref _registry);
            if (registry == null)
            {
                return;
            }
            var enabledRegions = Volatile.Read(ref registry.EnabledRegions);
            if (enabledRegions == 0)
            {
                return;
            }
            if (now < 0 || now == long.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(now));
            }

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
                    if (string.IsNullOrEmpty(key) || ReferenceEquals(key, previousKey))
                    {
                        continue;
                    }
                    previousKey = key;
                    ObserveKey(registry, key, now, isEu);
                }
            }
        }

        private static void ObserveKey(RegistryState registry, string key, long now, bool isEu)
        {
            while (true)
            {
                if (registry.Entries.TryGetValue(key, out var entry))
                {
                    if (entry.TryObserve(now, isEu))
                    {
                        return;
                    }
                    RemoveRetiredEntry(registry, key, entry);
                }

                if (!IsRegionEnabled(Volatile.Read(ref registry.EnabledRegions), isEu) || !registry.TryReserve())
                {
                    return;
                }

                var added = false;
                try
                {
                    added = registry.Entries.TryAdd(key, new Entry(now, isEu));
                    if (added)
                    {
                        return;
                    }
                }
                finally
                {
                    if (!added)
                    {
                        Interlocked.Decrement(ref registry.Count);
                    }
                }
            }
        }

        private static bool IsRegionEnabled(int enabledRegions, bool isEu)
            => (enabledRegions & (isEu ? EuRegion : NonEuRegion)) != 0;

        internal IReadOnlyDictionary<string, bool> Collect(long now, long intervalTicks)
        {
            var due = new Dictionary<string, bool>(StringComparer.Ordinal);
            var registry = Volatile.Read(ref _registry);
            if (registry == null)
            {
                return due;
            }
            var enabledRegions = Volatile.Read(ref registry.EnabledRegions);
            if (enabledRegions == 0)
            {
                return due;
            }

            // The owner's single metric reader serializes reporting bookkeeping.
            var completedCollections = Interlocked.Read(ref _completedCollections);
            foreach (var pair in registry.Entries)
            {
                var entry = pair.Value;
                var state = entry.State;
                if (state == Entry.Retired)
                {
                    continue;
                }
                var isEu = state < 0;
                var enabled = IsRegionEnabled(enabledRegions, isEu);
                var inactive = now - Math.Max(state & long.MaxValue, entry.LastReported) >= intervalTicks;

                // An idle SDK collection must finish before its slots can be reused.
                // Removing an entry at the start of that collection would admit replacements
                // before OTel reclaims the previous points, causing identity-losing overflow.
                if ((!enabled || (inactive && entry.LastReported >= 0))
                    && (entry.LastReported < 0 || completedCollections >= entry.LastCollection + 2))
                {
                    // A refresh wins over expiry unless this exact observation can be retired.
                    if (entry.TryRetire(state))
                    {
                        RemoveRetiredEntry(registry, pair.Key, entry);
                    }
                    continue;
                }

                if (!enabled || (inactive && entry.LastReported >= 0)
                    || (entry.LastReported >= 0 && now - entry.LastReported < intervalTicks))
                {
                    continue;
                }

                entry.LastReported = now;
                entry.LastCollection = completedCollections;
                due.Add(pair.Key, isEu);
            }

            return due;
        }

        internal void SetEnabledRegions(bool nonEuEnabled, bool euEnabled)
        {
            var enabledRegions = (nonEuEnabled ? NonEuRegion : 0) | (euEnabled ? EuRegion : 0);
            var registry = Volatile.Read(ref _registry);
            if (enabledRegions != 0)
            {
                if (registry != null)
                {
                    Volatile.Write(ref registry.EnabledRegions, enabledRegions);
                }
                return;
            }

            while (registry != null && Volatile.Read(ref registry.EnabledRegions) != 0)
            {
                // In-flight admissions keep their old counter; they cannot repopulate a reset registry.
                var replacement = new RegistryState(0);
                var observed = Interlocked.CompareExchange(ref _registry, replacement, registry);
                if (ReferenceEquals(observed, registry))
                {
                    return;
                }
                registry = observed;
            }
        }

        internal void CompleteCollection() => Interlocked.Increment(ref _completedCollections);

        internal void Close() => Interlocked.Exchange(ref _registry, null);

        private static void RemoveRetiredEntry(RegistryState registry, string key, Entry entry)
        {
            if (((ICollection<KeyValuePair<string, Entry>>)registry.Entries).Remove(new(key, entry)))
            {
                Interlocked.Decrement(ref registry.Count);
            }
        }

        private sealed class RegistryState
        {
            internal readonly ConcurrentDictionary<string, Entry> Entries = new(StringComparer.Ordinal);
            internal int EnabledRegions;
            // Includes slots reserved by additions that have not published their entries yet.
            internal int Count;

            internal RegistryState(int enabledRegions)
            {
                EnabledRegions = enabledRegions;
            }

            internal bool TryReserve()
            {
                var count = Volatile.Read(ref Count);
                while (count < Capacity)
                {
                    var observed = Interlocked.CompareExchange(ref Count, count + 1, count);
                    if (observed == count)
                    {
                        return true;
                    }
                    count = observed;
                }
                return false;
            }
        }

        internal sealed class Entry
        {
            internal const long Retired = long.MaxValue;

            // The sign bit holds the region; the other bits hold the exact timestamp.
            // MaxValue is reserved so refresh and retirement can use the same atomic operation.
            private long _state;

            internal Entry(long now, bool isEu)
            {
                _state = now | (isEu ? long.MinValue : 0);
            }

            internal long State => Volatile.Read(ref _state);
            internal long LastReported = -1;
            internal long LastCollection;

            internal bool TryObserve(long now, bool isEu)
            {
                var updated = now | (isEu ? long.MinValue : 0);
                var previous = State;
                while (previous != Retired)
                {
                    if (now < (previous & long.MaxValue) || previous == updated)
                    {
                        return true;
                    }
                    var observed = Interlocked.CompareExchange(ref _state, updated, previous);
                    if (observed == previous)
                    {
                        return true;
                    }
                    previous = observed;
                }
                return false;
            }

            internal bool TryRetire(long expected)
                => expected != Retired && Interlocked.CompareExchange(ref _state, Retired, expected) == expected;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    /// <summary>
    /// Telemetry for one export, grouped by route (ingestion endpoint and AAD flag) so each group
    /// becomes a single POST. Groups, item lists, and per-customer counts are reused across exports.
    /// Only growth past a previous high-water mark allocates.
    /// </summary>
    internal sealed class EndpointRouteBatch
    {
        private const int DefaultCapacity = 4;

        private static long s_exportSequence;

        private Group?[] _groups = new Group?[DefaultCapacity];
        private int _count;

        internal int Count => _count;

        /// <summary>Stitches one export's routing decisions to the sends they produced.</summary>
        internal long Sequence { get; private set; }

        internal void BeginExport() => Sequence = Interlocked.Increment(ref s_exportSequence);

        internal Group this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return _groups[index]!;
            }
        }

        /// <remarks>
        /// Endpoints are normalized by <see cref="EndpointRouting"/> before they reach here, so an
        /// ordinal scan is exact. At the handful of regions a process talks to, scanning beats
        /// hashing and allocates nothing.
        /// <para/>
        /// The same endpoint with and without AAD is two groups: a request has one authentication mode.
        /// </remarks>
        internal Group GetOrAdd(string ingestionEndpoint, bool isAad = false)
        {
            for (int i = 0; i < _count; i++)
            {
                var candidate = _groups[i]!;
                if (candidate.IsAad == isAad && string.Equals(candidate.IngestionEndpoint, ingestionEndpoint, StringComparison.Ordinal))
                {
                    return candidate;
                }
            }

            if (_count == _groups.Length)
            {
                Array.Resize(ref _groups, _groups.Length * 2);
            }

            var group = _groups[_count] ??= new Group();
            group.Open(ingestionEndpoint, isAad);
            _count++;

            return group;
        }

        internal void Reset()
        {
            for (int i = 0; i < _count; i++)
            {
                _groups[i]!.Close();
            }

            _count = 0;
        }

        internal sealed class Group : INetworkSdkStatsBatch
        {
            private readonly List<TelemetryItem> _telemetryItems = new();
            private readonly Dictionary<string, int> _itemCountsByInstrumentationKey = new(StringComparer.Ordinal);
            private string? _statsbeatEndpoint;
            private bool _statsbeatIsEu;

            internal bool StatsbeatIsEu
            {
                get
                {
                    if (!string.Equals(_statsbeatEndpoint, IngestionEndpoint, StringComparison.Ordinal))
                    {
                        _statsbeatIsEu = AzureMonitorStatsbeat.IsEuRegion(IngestionEndpoint);
                        _statsbeatEndpoint = IngestionEndpoint;
                    }
                    return _statsbeatIsEu;
                }
            }

            internal string IngestionEndpoint { get; private set; } = string.Empty;

            /// <summary>Whether the destination authenticates ingestion with Microsoft Entra ID.</summary>
            internal bool IsAad { get; private set; }

            /// <summary>The route as named in self-diagnostics.</summary>
            internal string Description { get; private set; } = string.Empty;

            // Preserve wire order so a partial response's error index identifies its customer directly.
            internal IReadOnlyList<TelemetryItem> TelemetryItems => _telemetryItems;

            internal IReadOnlyDictionary<string, int> ItemCountsByInstrumentationKey => _itemCountsByInstrumentationKey;

            internal Dictionary<string, int>.KeyCollection InstrumentationKeys => _itemCountsByInstrumentationKey.Keys;

            int INetworkSdkStatsBatch.Count => _telemetryItems.Count;
            IEnumerable<string> INetworkSdkStatsBatch.InstrumentationKeys => InstrumentationKeys;
            IReadOnlyDictionary<string, int> INetworkSdkStatsBatch.ItemCountsByInstrumentationKey => ItemCountsByInstrumentationKey;
            string? INetworkSdkStatsBatch.GetInstrumentationKey(int index) => _telemetryItems[index].InstrumentationKey;

            internal void Add(TelemetryItem telemetryItem)
            {
                var key = telemetryItem.InstrumentationKey;
#if NET
                ref int count = ref CollectionsMarshal.GetValueRefOrAddDefault(_itemCountsByInstrumentationKey, key, out _);
                count++;
#else
                _itemCountsByInstrumentationKey.TryGetValue(key, out var count);
                _itemCountsByInstrumentationKey[key] = count + 1;
#endif
                _telemetryItems.Add(telemetryItem);
            }

            internal void Open(string ingestionEndpoint, bool isAad)
            {
                // Self-clearing rather than relying on Close: a group that opened holding a previous
                // export's items would POST one endpoint's telemetry to another endpoint.
                Clear();
                IngestionEndpoint = ingestionEndpoint;
                IsAad = isAad;
                Description = EndpointRouting.DescribeRoute(ingestionEndpoint, isAad);
            }

            internal void Close() => Clear();

            private void Clear()
            {
                IngestionEndpoint = string.Empty;
                IsAad = false;
                Description = string.Empty;
                _telemetryItems.Clear();
                _itemCountsByInstrumentationKey.Clear();
            }
        }
    }
}

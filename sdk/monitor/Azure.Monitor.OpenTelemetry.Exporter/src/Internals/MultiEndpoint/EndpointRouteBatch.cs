// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    /// <summary>
    /// Telemetry for one export, grouped by route (ingestion endpoint and AAD flag) so each group
    /// becomes a single POST. Groups, item lists, and their bookkeeping are reused across exports;
    /// only growth past a previous high-water mark allocates.
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

        internal sealed class Group
        {
            internal string IngestionEndpoint { get; private set; } = string.Empty;

            /// <summary>Whether the destination authenticates ingestion with Microsoft Entra ID.</summary>
            internal bool IsAad { get; private set; }

            /// <summary>The route as named in self-diagnostics.</summary>
            internal string Description { get; private set; } = string.Empty;

            internal List<TelemetryItem> TelemetryItems { get; } = new();

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
                TelemetryItems.Clear();
            }
        }
    }
}

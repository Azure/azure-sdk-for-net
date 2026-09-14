// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint
{
    /// <summary>
    /// Telemetry for one export, grouped by ingestion endpoint so each group becomes a single POST.
    /// Groups, item lists, and their bookkeeping are reused across exports; only growth past a
    /// previous high-water mark allocates.
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
        /// </remarks>
        internal Group GetOrAdd(string ingestionEndpoint, bool useAadAuth)
        {
            for (int i = 0; i < _count; i++)
            {
                var candidate = _groups[i]!;
                if (candidate.UseAadAuth == useAadAuth
                    && string.Equals(candidate.IngestionEndpoint, ingestionEndpoint, StringComparison.Ordinal))
                {
                    return candidate;
                }
            }

            if (_count == _groups.Length)
            {
                Array.Resize(ref _groups, _groups.Length * 2);
            }

            var group = _groups[_count] ??= new Group();
            group.Open(ingestionEndpoint, useAadAuth);
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

            /// <summary>
            /// Part of the group's identity, not a property of the endpoint: one endpoint serves
            /// components that require a token and components that still accept key-only auth, and
            /// the two cannot share a POST because the header applies to the whole request.
            /// </summary>
            internal bool UseAadAuth { get; private set; }

            internal List<TelemetryItem> TelemetryItems { get; } = new();

            internal void Open(string ingestionEndpoint, bool useAadAuth)
            {
                // Self-clearing rather than relying on Close: a group that opened holding a previous
                // export's items would POST one endpoint's telemetry to another endpoint.
                Clear();
                IngestionEndpoint = ingestionEndpoint;
                UseAadAuth = useAadAuth;
            }

            internal void Close() => Clear();

            private void Clear()
            {
                UseAadAuth = false;
                IngestionEndpoint = string.Empty;
                TelemetryItems.Clear();
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using OpenTelemetry.PersistentStorage.Abstractions;
using OpenTelemetry.PersistentStorage.FileSystem;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant
{
    /// <summary>
    /// The only handle on a partition's storage that <see cref="MultiTenantStorage"/> hands out.
    /// Reads pass straight through; writes go through the shared budget.
    /// </summary>
    /// <remarks>
    /// Callers such as <c>HttpPipelineHelper.ProcessTransmissionResult</c> take a
    /// <see cref="PersistentBlobProvider"/> and persist through it directly. Giving them the
    /// underlying <see cref="FileBlobProvider"/> left each partition enforcing only its own cap, so
    /// the process-wide budget was really that budget multiplied by the partition count. Wrapping
    /// makes the bypass impossible to reintroduce without changing a type.
    /// </remarks>
    internal sealed class BudgetedBlobProvider : PersistentBlobProvider
    {
        private readonly MultiTenantStorage _owner;
        private readonly FileBlobProvider _inner;

        internal BudgetedBlobProvider(MultiTenantStorage owner, FileBlobProvider inner)
        {
            _owner = owner;
            _inner = inner;
        }

        protected override IEnumerable<PersistentBlob> OnGetBlobs() => _inner.GetBlobs();

        protected override bool OnTryGetBlob(out PersistentBlob blob)
        {
            var found = _inner.TryGetBlob(out var inner);
            blob = inner!;

            return found;
        }

        protected override bool OnTryCreateBlob(byte[] buffer, out PersistentBlob blob)
            => TryCreate(buffer, leasePeriodMilliseconds: 0, out blob);

        protected override bool OnTryCreateBlob(byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob blob)
            => TryCreate(buffer, leasePeriodMilliseconds, out blob);

        private bool TryCreate(byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob blob)
        {
            var created = _owner.TryCreateBlobWithinBudget(_inner, buffer, leasePeriodMilliseconds, out var inner);
            blob = inner!;

            return created;
        }
    }
}

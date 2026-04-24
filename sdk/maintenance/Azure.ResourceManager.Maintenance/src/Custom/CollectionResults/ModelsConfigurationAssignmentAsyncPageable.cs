// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Maintenance
{
    // AsyncPageable<T> is invariant — the generated pageable extends
    // AsyncPageable<Root.MaintenanceConfigurationAssignmentData>, but the old v1.1.3 API
    // returns AsyncPageable<Models.MaintenanceConfigurationAssignmentData>.
    // This wrapper bridges that gap by iterating pages from the inner source and converting
    // each item via the implicit operator defined on Models.MaintenanceConfigurationAssignmentData.
    internal sealed class ModelsConfigurationAssignmentAsyncPageable : AsyncPageable<Models.MaintenanceConfigurationAssignmentData>
    {
        private readonly AsyncPageable<MaintenanceConfigurationAssignmentData> _inner;

        internal ModelsConfigurationAssignmentAsyncPageable(AsyncPageable<MaintenanceConfigurationAssignmentData> inner) => _inner = inner;

        public override async IAsyncEnumerable<Page<Models.MaintenanceConfigurationAssignmentData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            await foreach (Page<MaintenanceConfigurationAssignmentData> page in _inner.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
            {
                yield return Page<Models.MaintenanceConfigurationAssignmentData>.FromValues(
                    page.Values.Select(v => (Models.MaintenanceConfigurationAssignmentData)v).ToList(),
                    page.ContinuationToken,
                    page.GetRawResponse());
            }
        }
    }
}

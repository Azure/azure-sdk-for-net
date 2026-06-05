// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Maintenance.Models;

namespace Azure.ResourceManager.Maintenance
{
    // Pageable<T> is invariant — same reason as the async version.
    // See ModelsConfigurationAssignmentAsyncPageable for details.
    internal sealed class ModelsConfigurationAssignmentPageable : Pageable<Models.MaintenanceConfigurationAssignmentData>
    {
        private readonly Pageable<MaintenanceConfigurationAssignmentData> _inner;

        internal ModelsConfigurationAssignmentPageable(Pageable<MaintenanceConfigurationAssignmentData> inner) => _inner = inner;

        public override IEnumerable<Page<Models.MaintenanceConfigurationAssignmentData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            foreach (Page<MaintenanceConfigurationAssignmentData> page in _inner.AsPages(continuationToken, pageSizeHint))
            {
                yield return Page<Models.MaintenanceConfigurationAssignmentData>.FromValues(
                    page.Values.Select(v => (Models.MaintenanceConfigurationAssignmentData)v).ToList(),
                    page.ContinuationToken,
                    page.GetRawResponse());
            }
        }
    }
}

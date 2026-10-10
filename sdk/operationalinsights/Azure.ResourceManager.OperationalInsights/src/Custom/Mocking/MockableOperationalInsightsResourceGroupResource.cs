// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;

namespace Azure.ResourceManager.OperationalInsights.Mocking
{
    // Backward-compat justification: the GA SDK exposed deleted-workspace list operations as GetDeletedWorkspaces on the mockable resource group type.
    public partial class MockableOperationalInsightsResourceGroupResource
    {
        /// <summary> Gets recently deleted workspaces in a resource group, available for recovery. </summary>
        public virtual AsyncPageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspacesAsync(CancellationToken cancellationToken = default)
            => GetByResourceGroupAsync(cancellationToken);

        /// <summary> Gets recently deleted workspaces in a resource group, available for recovery. </summary>
        public virtual Pageable<OperationalInsightsWorkspaceResource> GetDeletedWorkspaces(CancellationToken cancellationToken = default)
            => GetByResourceGroup(cancellationToken);
    }
}

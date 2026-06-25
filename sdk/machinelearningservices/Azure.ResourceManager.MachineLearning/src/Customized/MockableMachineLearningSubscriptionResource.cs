// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning.Mocking
{
    // Customized: preserve GA mockable subscription overloads that accepted AzureLocation. The
    // generated operations use the TypeSpec path parameter shape (`string location`).
    public partial class MockableMachineLearningSubscriptionResource
    {
        /// <summary> Gets the currently assigned Workspace Quotas based on VMFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningResourceQuota> GetMachineLearningQuotasAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetMachineLearningQuotasAsync(location.ToString(), cancellationToken);

        /// <summary> Gets the currently assigned Workspace Quotas based on VMFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningResourceQuota> GetMachineLearningQuotas(AzureLocation location, CancellationToken cancellationToken)
            => GetMachineLearningQuotas(location.ToString(), cancellationToken);

        /// <summary> Gets the usages for the location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningUsage> GetMachineLearningUsagesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetMachineLearningUsagesAsync(location.ToString(), cancellationToken);

        /// <summary> Gets the usages for the location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningUsage> GetMachineLearningUsages(AzureLocation location, CancellationToken cancellationToken)
            => GetMachineLearningUsages(location.ToString(), cancellationToken);

        /// <summary> Returns supported VM Sizes in a location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningVmSize> GetMachineLearningVmSizesAsync(AzureLocation location, CancellationToken cancellationToken)
            => new MachineLearningVmSizesAsyncPageable(this, location.ToString(), cancellationToken);

        /// <summary> Returns supported VM Sizes in a location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningVmSize> GetMachineLearningVmSizes(AzureLocation location, CancellationToken cancellationToken)
        {
            Response<VirtualMachineSizeListResult> response = GetMachineLearningVmSizes(location.ToString(), cancellationToken);
            return Pageable<MachineLearningVmSize>.FromPages(new[]
            {
                Page<MachineLearningVmSize>.FromValues((IReadOnlyList<MachineLearningVmSize>)response.Value.Value, null, response.GetRawResponse())
            });
        }

        /// <summary> Gets all machine learning workspaces in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningWorkspaceResource> GetMachineLearningWorkspacesAsync(string resourceGroupName, CancellationToken cancellationToken)
            => GetMachineLearningWorkspacesAsync(resourceGroupName, default, default, cancellationToken);

        /// <summary> Gets all machine learning workspaces in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningWorkspaceResource> GetMachineLearningWorkspaces(string resourceGroupName, CancellationToken cancellationToken)
            => GetMachineLearningWorkspaces(resourceGroupName, default, default, cancellationToken);

        /// <summary> Update quota for each VM family in workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningWorkspaceQuotaUpdate> UpdateMachineLearningQuotasAsync(AzureLocation location, MachineLearningQuotaUpdateContent content, CancellationToken cancellationToken)
            => new MachineLearningQuotaUpdatesAsyncPageable(this, location.ToString(), content, cancellationToken);

        /// <summary> Update quota for each VM family in workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningWorkspaceQuotaUpdate> UpdateMachineLearningQuotas(AzureLocation location, MachineLearningQuotaUpdateContent content, CancellationToken cancellationToken)
        {
            Response<MachineLearningWorkspaceQuotaStatusResult> response = Update(location.ToString(), content, cancellationToken);
            return Pageable<MachineLearningWorkspaceQuotaUpdate>.FromPages(new[]
            {
                Page<MachineLearningWorkspaceQuotaUpdate>.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse())
            });
        }

        private sealed class MachineLearningVmSizesAsyncPageable : AsyncPageable<MachineLearningVmSize>
        {
            private readonly MockableMachineLearningSubscriptionResource _resource;
            private readonly string _location;

            public MachineLearningVmSizesAsyncPageable(MockableMachineLearningSubscriptionResource resource, string location, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _resource = resource;
                _location = location;
            }

            public override async IAsyncEnumerable<Page<MachineLearningVmSize>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<VirtualMachineSizeListResult> response = await _resource.GetMachineLearningVmSizesAsync(_location, CancellationToken).ConfigureAwait(false);
                yield return Page<MachineLearningVmSize>.FromValues((IReadOnlyList<MachineLearningVmSize>)response.Value.Value, null, response.GetRawResponse());
            }
        }

        private sealed class MachineLearningQuotaUpdatesAsyncPageable : AsyncPageable<MachineLearningWorkspaceQuotaUpdate>
        {
            private readonly MockableMachineLearningSubscriptionResource _resource;
            private readonly string _location;
            private readonly MachineLearningQuotaUpdateContent _content;

            public MachineLearningQuotaUpdatesAsyncPageable(MockableMachineLearningSubscriptionResource resource, string location, MachineLearningQuotaUpdateContent content, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _resource = resource;
                _location = location;
                _content = content;
            }

            public override async IAsyncEnumerable<Page<MachineLearningWorkspaceQuotaUpdate>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<MachineLearningWorkspaceQuotaStatusResult> response = await _resource.UpdateAsync(_location, _content, CancellationToken).ConfigureAwait(false);
                yield return Page<MachineLearningWorkspaceQuotaUpdate>.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
        }
    }
}

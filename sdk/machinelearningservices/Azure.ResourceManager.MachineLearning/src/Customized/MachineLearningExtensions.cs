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
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve legacy subscription extension overloads that accepted AzureLocation.
    [CodeGenSuppress("GetMachineLearningOutboundRuleBasicResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class MachineLearningExtensions
    {
        /// <summary> Gets the currently assigned Workspace Quotas based on VMFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MachineLearningResourceQuota> GetMachineLearningQuotasAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningQuotasAsync(location, cancellationToken);

        /// <summary> Gets the currently assigned Workspace Quotas based on VMFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MachineLearningResourceQuota> GetMachineLearningQuotas(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningQuotas(location, cancellationToken);

        /// <summary> Gets the usages for the location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MachineLearningUsage> GetMachineLearningUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningUsagesAsync(location, cancellationToken);

        /// <summary> Gets the usages for the location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MachineLearningUsage> GetMachineLearningUsages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningUsages(location, cancellationToken);

        /// <summary> Returns supported VM Sizes in a location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MachineLearningVmSize> GetMachineLearningVmSizesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningVmSizesAsync(location, cancellationToken);

        /// <summary> Returns supported VM Sizes in a location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MachineLearningVmSize> GetMachineLearningVmSizes(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningVmSizes(location, cancellationToken);

        /// <summary> Update quota for each VM family in workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MachineLearningWorkspaceQuotaUpdate> UpdateMachineLearningQuotasAsync(this SubscriptionResource subscriptionResource, AzureLocation location, MachineLearningQuotaUpdateContent content, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).UpdateMachineLearningQuotasAsync(location, content, cancellationToken);

        /// <summary> Update quota for each VM family in workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MachineLearningWorkspaceQuotaUpdate> UpdateMachineLearningQuotas(this SubscriptionResource subscriptionResource, AzureLocation location, MachineLearningQuotaUpdateContent content, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).UpdateMachineLearningQuotas(location, content, cancellationToken);

        /// <summary> Gets all machine learning workspaces in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MachineLearningWorkspaceResource> GetMachineLearningWorkspacesAsync(this SubscriptionResource subscriptionResource, string resourceGroupName, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningWorkspacesAsync(resourceGroupName, cancellationToken);

        /// <summary> Gets all machine learning workspaces in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MachineLearningWorkspaceResource> GetMachineLearningWorkspaces(this SubscriptionResource subscriptionResource, string resourceGroupName, CancellationToken cancellationToken)
            => GetMockableMachineLearningSubscriptionResource(subscriptionResource).GetMachineLearningWorkspaces(resourceGroupName, cancellationToken);

        // The service now has both workspace-level and managed-network outbound rule routes. TypeSpec resource hierarchy fixes preserve the
        // workspace-level resource type, but the generator only emits ArmClient extension methods for the active route selected from the
        // provider schema. A scoped decorator cannot add this extension-only convenience member, so keep the shipped GA method as a shim.
        /// <summary>
        /// Gets an object representing a <see cref="MachineLearningOutboundRuleBasicResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MachineLearningOutboundRuleBasicResource"/> object. </returns>
        public static MachineLearningOutboundRuleBasicResource GetMachineLearningOutboundRuleBasicResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMachineLearningArmClient(client).GetMachineLearningOutboundRuleBasicResource(id);
        }

        private sealed class MachineLearningVmSizesAsyncPageable : AsyncPageable<MachineLearningVmSize>
        {
            private readonly SubscriptionResource _subscriptionResource;
            private readonly string _location;

            public MachineLearningVmSizesAsyncPageable(SubscriptionResource subscriptionResource, string location, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _subscriptionResource = subscriptionResource;
                _location = location;
            }

            public override async IAsyncEnumerable<Page<MachineLearningVmSize>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<MachineLearningVmSize> page in GetMachineLearningVmSizesAsync(_subscriptionResource, _location, CancellationToken).AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    yield return page;
                }
            }
        }

        private sealed class MachineLearningQuotaUpdatesAsyncPageable : AsyncPageable<MachineLearningWorkspaceQuotaUpdate>
        {
            private readonly SubscriptionResource _subscriptionResource;
            private readonly string _location;
            private readonly MachineLearningQuotaUpdateContent _content;

            public MachineLearningQuotaUpdatesAsyncPageable(SubscriptionResource subscriptionResource, string location, MachineLearningQuotaUpdateContent content, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _subscriptionResource = subscriptionResource;
                _location = location;
                _content = content;
            }

            public override async IAsyncEnumerable<Page<MachineLearningWorkspaceQuotaUpdate>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<MachineLearningWorkspaceQuotaStatusResult> response = await UpdateAsync(_subscriptionResource, _location, _content, CancellationToken).ConfigureAwait(false);
                yield return Page<MachineLearningWorkspaceQuotaUpdate>.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
        }
    }
}

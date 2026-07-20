// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosResourceGroupResource
    {
        // The newly generated code uses scope-based methods on MockableChaosArmClient instead of these ResourceGroupResource methods.
        // Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}
        // The parentProviderNamespace, parentResourceType, and parentResourceName are now encoded in the ResourceIdentifier scope.

        private MockableChaosArmClient GetMockableChaosArmClient()
        {
            return Client.GetCachedClient(client0 => new MockableChaosArmClient(client0, ResourceIdentifier.Root));
        }

        private ResourceIdentifier BuildParentScope(string parentProviderNamespace, string parentResourceType, string parentResourceName)
        {
            return new ResourceIdentifier($"{Id}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}");
        }

        /// <summary>
        /// Get a Target resource that extends a tracked resource.
        /// <list type="bullet"><item><term>Request Path</term><description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ChaosTargetResource>> GetChaosTargetAsync(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, CancellationToken cancellationToken = default)
        {
            var scope = BuildParentScope(parentProviderNamespace, parentResourceType, parentResourceName);
            return await GetMockableChaosArmClient().GetChaosTargetAsync(scope, targetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a Target resource that extends a tracked resource.
        /// <list type="bullet"><item><term>Request Path</term><description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ChaosTargetResource> GetChaosTarget(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, CancellationToken cancellationToken = default)
        {
            var scope = BuildParentScope(parentProviderNamespace, parentResourceType, parentResourceName);
            return GetMockableChaosArmClient().GetChaosTarget(scope, targetName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of ChaosTargetResources.
        /// <list type="bullet"><item><term>Request Path</term><description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ChaosTargetCollection GetChaosTargets(string parentProviderNamespace, string parentResourceType, string parentResourceName)
        {
            var scope = BuildParentScope(parentProviderNamespace, parentResourceType, parentResourceName);
            return GetMockableChaosArmClient().GetChaosTargets(scope);
        }
    }
}

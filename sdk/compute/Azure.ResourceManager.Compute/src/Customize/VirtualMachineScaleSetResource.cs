// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A Class representing a VirtualMachineScaleSet along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualMachineScaleSetResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualMachineScaleSetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetVirtualMachineScaleSet method.
    /// </summary>
    public partial class VirtualMachineScaleSetResource : ArmResource
    {
        /// <summary>
        /// Manual platform update domain walk to update virtual machines in a service fabric virtual machine scale set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/forceRecoveryServiceFabricPlatformUpdateDomainWalk
        /// Operation Id: VirtualMachineScaleSets_ForceRecoveryServiceFabricPlatformUpdateDomainWalk
        /// </summary>
        /// <param name="platformUpdateDomain"> The platform update domain for which a manual recovery walk is requested. </param>
        /// <param name="zone"> The zone in which the manual recovery walk is requested for cross zone virtual machine scale set. </param>
        /// <param name="placementGroupId"> The placement group id for which the manual recovery walk is requested. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(int platformUpdateDomain, string zone = null, string placementGroupId = null, CancellationToken cancellationToken = default) =>
            await ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(new VirtualMachineScaleSetResourceForceRecoveryServiceFabricPlatformUpdateDomainWalkOptions(platformUpdateDomain)
            {
                Zone = zone,
                PlacementGroupId = placementGroupId
            }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Manual platform update domain walk to update virtual machines in a service fabric virtual machine scale set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/forceRecoveryServiceFabricPlatformUpdateDomainWalk
        /// Operation Id: VirtualMachineScaleSets_ForceRecoveryServiceFabricPlatformUpdateDomainWalk
        /// </summary>
        /// <param name="platformUpdateDomain"> The platform update domain for which a manual recovery walk is requested. </param>
        /// <param name="zone"> The zone in which the manual recovery walk is requested for cross zone virtual machine scale set. </param>
        /// <param name="placementGroupId"> The placement group id for which the manual recovery walk is requested. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalk(int platformUpdateDomain, string zone = null, string placementGroupId = null, CancellationToken cancellationToken = default) =>
            ForceRecoveryServiceFabricPlatformUpdateDomainWalk(new VirtualMachineScaleSetResourceForceRecoveryServiceFabricPlatformUpdateDomainWalkOptions(platformUpdateDomain)
            {
                Zone = zone,
                PlacementGroupId = placementGroupId
            }, cancellationToken);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.DefinitionShared
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition;

    /// <summary>
    /// The virtual machine scale set stages shared between managed and unmanaged based
    /// virtual machine scale set definitions.
    /// </summary>
    public interface IDefinitionShared  :
        IBlank,
        IWithGroup,
        IWithSku,
        IWithNetworkSubnet,
        IWithPrimaryInternetFacingLoadBalancer,
        IWithPrimaryInternalLoadBalancer,
        IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool,
        IWithInternalLoadBalancerBackendOrNatPool,
        IWithPrimaryInternetFacingLoadBalancerNatPool,
        IWithInternalInternalLoadBalancerNatPool,
        IWithOS,
        IWithCreate
    {
    }
}
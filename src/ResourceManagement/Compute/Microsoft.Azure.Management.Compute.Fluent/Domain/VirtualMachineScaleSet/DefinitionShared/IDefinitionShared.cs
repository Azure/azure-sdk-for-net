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
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IBlank,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithGroup,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithSku,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithNetworkSubnet,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancer,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternalLoadBalancer,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerBackendOrNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithInternalLoadBalancerBackendOrNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithPrimaryInternetFacingLoadBalancerNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithInternalInternalLoadBalancerNatPool,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithOS,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSet.Definition.IWithCreate
    {
    }
}
using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;

namespace Proto.Compute.Convenience
{
    /// <summary>
    /// A class representing a builder object to help create a virtual machine scale set.
    /// </summary>
    public abstract class VirtualMachineScaleSetModelBuilderBase : VirtualMachineScaleSetBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineModelBuilderBase"/> class.
        /// </summary>
        /// <param name="containerOperations"> The container to create the virtual machine in. </param>
        /// <param name="vm"> The data model representing the virtual machine to create. </param>
        protected VirtualMachineScaleSetModelBuilderBase(VirtualMachineScaleSetContainer containerOperations, VirtualMachineScaleSetData vm) 
            : base(containerOperations, vm)
        {
        }

        /// <summary>
        /// Tells the builder to use a windows image.
        /// </summary>
        /// <param name="adminUser"> The admin username for the virtual machine. </param>
        /// <param name="password"> The asmin password for the virtual machine. </param>
        /// <returns> An instance of <see cref="VirtualMachineScaleSetModelBuilderBase"/>. </returns>
        public abstract VirtualMachineScaleSetModelBuilderBase WithUseWindowsImage(string computerNamePrefix, string adminUser, string password);

        /// <summary>
        /// Tells the builder to use a linux image.
        /// </summary>
        /// <param name="adminUser"> The admin username for the virtual machine. </param>
        /// <param name="password"> The asmin password for the virtual machine. </param>
        /// <returns> An instance of <see cref="VirtualMachineModelBuilderBase"/>. </returns>
        public abstract VirtualMachineScaleSetModelBuilderBase WithUseLinuxImage(string computerNamePrefix, string adminUser, string password);

        /// <summary>
        /// Tells the builder to use a specific network interface.
        /// </summary>
        /// <param name="name">name of the network interface configuration</param>
        /// <param name="subNetResourceId"> The network interface identifier. </param>
        /// <param name="backendAddressPoolResourceIds"> The list of backend address pool resource id </param>
        /// <param name="inboundNatPoolResourceIds"> The list of inbound Nat pool resource id. </param>
        /// <returns> An instance of <see cref="VirtualMachineModelBuilderBase"/>. </returns>
        public abstract VirtualMachineScaleSetModelBuilderBase WithRequiredPrimaryNetworkInterface(
            string name, ResourceIdentifier subNetResourceId,
            ICollection<ResourceIdentifier> backendAddressPoolResourceIds,
            ICollection<ResourceIdentifier> inboundNatPoolResourceIds);

        /// <summary>
        /// Tells the builder to use a specific load balancer.
        /// </summary>
        /// <param name="asetResourceId"> The availability set identifier. </param>
        /// <returns> An instance of <see cref="VirtualMachineScaleSetModelBuilderBase"/>. </returns>
        public abstract VirtualMachineScaleSetModelBuilderBase WithRequiredLoadBalancer(ResourceIdentifier asetResourceId);
    }
}

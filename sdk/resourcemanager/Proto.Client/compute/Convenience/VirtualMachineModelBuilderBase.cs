using Azure.ResourceManager.Core;

namespace Proto.Compute.Convenience
{
    /// <summary>
    /// A class representing the base for a builder object to help create a virtual machine.
    /// </summary>
    public abstract class VirtualMachineModelBuilderBase : ArmBuilder<ResourceGroupResourceIdentifier, VirtualMachine, VirtualMachineData>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="VirtualMachineModelBuilderBase"/>.
        /// </summary>
        /// <param name="containerOperations"> The <see cref="VirtualMachineContainer"/> that the virtual machine will be built in. </param>
        /// <param name="vm"> The data model representing the virtual machine to create. </param>
        protected VirtualMachineModelBuilderBase(VirtualMachineContainer containerOperations, VirtualMachineData vm)
            : base(containerOperations, vm)
        {
        }

        /// <summary>
        /// Tells the builder to use a windows image.
        /// </summary>
        /// <param name="adminUser"> The admin username for the virtual machine. </param>
        /// <param name="password"> The asmin password for the virtual machine. </param>
        /// <returns> An instance of <see cref="VirtualMachineModelBuilderBase"/>. </returns>
        public abstract VirtualMachineModelBuilderBase UseWindowsImage(string adminUser, string password);

        /// <summary>
        /// Tells the builder to use a linux image.
        /// </summary>
        /// <param name="adminUser"> The admin username for the virtual machine. </param>
        /// <param name="password"> The asmin password for the virtual machine. </param>
        /// <returns> An instance of <see cref="VirtualMachineModelBuilderBase"/>. </returns>
        public abstract VirtualMachineModelBuilderBase UseLinuxImage(string adminUser, string password);

        /// <summary>
        /// Tells the builder to use a specific network interface.
        /// </summary>
        /// <param name="nicResourceId"> The network interface identifier. </param>
        /// <returns> An instance of <see cref="VirtualMachineModelBuilderBase"/>. </returns>
        public abstract VirtualMachineModelBuilderBase RequiredNetworkInterface(ResourceIdentifier nicResourceId);

        /// <summary>
        /// Tells the builder to use a specific availability set.
        /// </summary>
        /// <param name="asetResourceId"> The availability set identifier. </param>
        /// <returns> An instance of <see cref="VirtualMachineModelBuilderBase"/>. </returns>
        public abstract VirtualMachineModelBuilderBase RequiredAvalabilitySet(ResourceIdentifier asetResourceId);
    }
}

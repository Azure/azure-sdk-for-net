using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class to add extension methods to ResourceGroup.
    /// </summary>
    public static class ResourceGroupExtensions
    {
        #region VirtualMachines
        /// <summary>
        /// Gets an object representing the operations that can be performed over a specific VirtualMachine.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <param name="vmName"> The name of the VirtualMachine. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="VirtualMachine" />.</returns>
        public static VirtualMachineOperations GetVirtualMachineOperations(this ResourceGroupOperations resourceGroup, string vmName)
        {
            return new VirtualMachineOperations(resourceGroup, vmName);
        }

        /// <summary>
        /// Gets an object representing a VirtualMachineContainer along with the instance operations that can be performed on it.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="VirtualMachineContainer" /> object. </returns>
        public static VirtualMachineContainer GetVirtualMachineContainer(this ResourceGroupOperations resourceGroup)
        {
            return new VirtualMachineContainer(resourceGroup);
        }
        #endregion

        #region AvailabilitySets
        /// <summary>
        /// Gets an object representing the operations that can be performed over a specific AvailabilitySet.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <param name="availabilitySetName"> The name of the AvailibilitySet. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="AvailabilitySet" />. </returns>
        public static AvailabilitySetOperations GetAvailabilitySetOperations(this ResourceGroupOperations resourceGroup, string availabilitySetName)
        {
            return new AvailabilitySetOperations(resourceGroup, availabilitySetName);
        }

        /// <summary>
        /// Gets an object representing a AvailabilitySetContainer along with the instance operations that can be performed on it.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <returns> Returns an <see cref="AvailabilitySetContainer" /> object. </returns>
        public static AvailabilitySetContainer GetAvailabilitySetContainer(this ResourceGroupOperations resourceGroup)
        {
            return new AvailabilitySetContainer(resourceGroup);
        }
        #endregion
    }
}

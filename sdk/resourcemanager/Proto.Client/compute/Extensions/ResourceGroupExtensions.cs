using Azure.ResourceManager.Core;
using System;

namespace Proto.Compute
{
    /// <summary>
    /// A class to add extension methods to ResourceGroup.
    /// </summary>
    public static class ResourceGroupExtensions
    {
        /// <summary>
        /// Gets an object representing a VirtualMachineContainer along with the instance operations that can be performed on it.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="VirtualMachineContainer" /> object. </returns>
        public static VirtualMachineContainer GetVirtualMachines(this ResourceGroupOperations resourceGroup)
        {
            return new VirtualMachineContainer(resourceGroup);
        }

        /// <summary>
        /// Gets an object representing a AvailabilitySetContainer along with the instance operations that can be performed on it.
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroupOperations" /> instance the method will execute against. </param>
        /// <returns> Returns an <see cref="AvailabilitySetContainer" /> object. </returns>
        public static AvailabilitySetContainer GetAvailabilitySets(this ResourceGroupOperations resourceGroup)
        {
            return new AvailabilitySetContainer(resourceGroup);
        }
    }
}

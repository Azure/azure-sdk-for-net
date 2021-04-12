using Azure.ResourceManager.Core;
using System;

namespace Proto.Compute
{
    /// <summary>
    /// A class to add extension methods to an ArmClient.
    /// </summary>
    public static class ArmClientExtensions
    {

        /// <summary>
        /// Gets the AvailabilitySetOperations.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="AvailabilitySet" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for an AvailabilitySet. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static AvailabilitySetOperations GetAvailabilitySetOperations(this ArmClient client, ResourceGroupResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.ResourceType != AvailabilitySetOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.ResourceType)} provided is not for an AvailabilitySet.", nameof(resourceId.ResourceType));

            return new AvailabilitySetOperations(client.GetResourceGroupOperations(resourceId), resourceId.Name);
        }

        /// <summary>
        /// Gets the VirtualMachineOperations.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="VirtualMachine" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a VirtualMachine. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static VirtualMachineOperations GetVirtualMachineOperations(this ArmClient client, ResourceGroupResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.ResourceType != VirtualMachineOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.ResourceType)} provided is not for a VirtualMachine.", nameof(resourceId.ResourceType));

            return new VirtualMachineOperations(client.GetResourceGroupOperations(resourceId), resourceId.Name);
        }
    }
}

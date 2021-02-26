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
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="AvailabilitySet" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for an AvailabilitySet. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static AvailabilitySetOperations GetAvailabilitySetOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.Type != AvailabilitySetOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.Type)} provided is not for an AvailabilitySet.", nameof(resourceId.Type));

            return client.GetSubscriptionOperations(resourceId.Subscription).GetResourceGroupOperations(resourceId.ResourceGroup).GetAvailabilitySetOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the VirtualMachineOperations.
        /// </summary>
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="VirtualMachine" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a VirtualMachine. </exception>
        /// <exception cref="ArgumentNullException"> ResourceIdentifier cannot be null. </exception>
        public static VirtualMachineOperations GetVirtualMachineOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (resourceId.Type != VirtualMachineOperations.ResourceType)
                throw new ArgumentException($"{nameof(resourceId.Type)} provided is not for a VirtualMachine.", nameof(resourceId.Type));

            return client.GetSubscriptionOperations(resourceId.Subscription).GetResourceGroupOperations(resourceId.ResourceGroup).GetVirtualMachineOperations(resourceId.Name);
        }
    }
}

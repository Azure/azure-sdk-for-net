using Azure.ResourceManager.Core;
using System;
using System.Collections.Generic;
using System.Text;

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
        public static AvailabilitySetOperations GetAvailabilitySetOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId.Type != AvailabilitySetOperations.ResourceType)
            {
                throw new ArgumentException("ResourceIdentifier provided is not for an AvailabilitySet.");
            }
            return client.GetSubscriptionOperations(resourceId.Subscription).GetResourceGroupOperations(resourceId.ResourceGroup).GetAvailabilitySetOperations(resourceId.Name);
        }

        /// <summary>
        /// Gets the VirtualMachineOperations.
        /// </summary>
        /// <param name="client"> The <see cref="AzureResourceManagerClient" /> instance the method will execute against. </param>
        /// <param name="resourceId"> The ResourceIdentifier of the resource that is the target of operations. </param>
        /// <returns> Returns an object representing the operations that can be performed over a specific <see cref="VirtualMachine" />. </returns>
        /// <exception cref="ArgumentException"> ResourceIdentifier provided is not for a VirtualMachine. </exception>
        public static VirtualMachineOperations GetVirtualMachineOperations(this AzureResourceManagerClient client, ResourceIdentifier resourceId)
        {
            if (resourceId.Type != VirtualMachineOperations.ResourceType)
            {
                throw new ArgumentException("ResourceIdentifier provided is not for a VirtualMachine.");
            }
            return client.GetSubscriptionOperations(resourceId.Subscription).GetResourceGroupOperations(resourceId.ResourceGroup).GetVirtualMachineOperations(resourceId.Name);
        }
    }
}

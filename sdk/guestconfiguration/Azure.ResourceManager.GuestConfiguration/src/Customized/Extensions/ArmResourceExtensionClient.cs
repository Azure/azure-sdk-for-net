// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.GuestConfiguration
{
    /// <summary> A class to add extension methods to ArmResource. </summary>
    internal partial class ArmResourceExtensionClient : ArmResource
    {
        private static ResourceType _resourceGroup = new ResourceType("Microsoft.Resources/resourceGroups");
        private static ResourceType _guestConfigurationHcrpAssignmentCollection = new ResourceType("Microsoft.HybridCompute/machines");
        private static ResourceType _guestConfigurationVmAssignmentCollection = new ResourceType("Microsoft.Compute/virtualMachines");
        private static ResourceType _guestConfigurationVmssAssignmentCollection = new ResourceType("Microsoft.Compute/virtualMachineScaleSets");

        /// <summary> Initializes a new instance of the <see cref="ArmResourceExtensionClient"/> class for mocking. </summary>
        protected ArmResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ArmResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ArmResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of GuestConfigurationHcrpAssignmentResource in the ArmResource. </summary>
        /// <returns> An object representing collection of GuestConfigurationHcrpAssignmentResource and their operations over a GuestConfigurationHcrpAssignmentResource. </returns>
        public virtual GuestConfigurationHcrpAssignmentCollection GetGuestConfigurationHcrpAssignments()
        {
            if (Id.ResourceType != _guestConfigurationHcrpAssignmentCollection || Id.Parent.ResourceType != _resourceGroup)
                throw new ArgumentException($"Invalid resource identifier {Id} expected /subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}/providers/Microsoft.HybridCompute/machines/{{machineName}}");
            return GetCachedClient(Client => new GuestConfigurationHcrpAssignmentCollection(Client, Id.Parent, Id.Name));
        }

        /// <summary> Gets a collection of GuestConfigurationVmAssignmentResource in the ArmResource. </summary>
        /// <returns> An object representing collection of GuestConfigurationVmAssignmentResource and their operations over a GuestConfigurationVmAssignmentResource. </returns>
        public virtual GuestConfigurationVmAssignmentCollection GetGuestConfigurationVmAssignments()
        {
            if (Id.ResourceType != _guestConfigurationVmAssignmentCollection || Id.Parent.ResourceType != _resourceGroup)
                throw new ArgumentException($"Invalid resource identifier {Id} expected /subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}/providers/Microsoft.Compute/virtualMachines/{{vmName}}");
            return GetCachedClient(Client => new GuestConfigurationVmAssignmentCollection(Client, Id.Parent, Id.Name));
        }

        /// <summary> Gets a collection of GuestConfigurationVmssAssignmentResource in the ArmResource. </summary>
        /// <returns> An object representing collection of GuestConfigurationVmssAssignmentResource and their operations over a GuestConfigurationVmssAssignmentResource. </returns>
        public virtual GuestConfigurationVmssAssignmentCollection GetGuestConfigurationVmssAssignments()
        {
            if (Id.ResourceType != _guestConfigurationVmssAssignmentCollection || Id.Parent.ResourceType != _resourceGroup)
                throw new ArgumentException($"Invalid resource identifier {Id} expected /subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}/providers/Microsoft.Compute/virtualMachineScaleSets/{{vmssName}}");
            return GetCachedClient(Client => new GuestConfigurationVmssAssignmentCollection(Client, Id.Parent, Id.Name));
        }
    }
}

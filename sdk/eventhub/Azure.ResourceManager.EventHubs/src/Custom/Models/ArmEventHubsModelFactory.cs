// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventHubs.Models
{
    public static partial class ArmEventHubsModelFactory
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EventHubsNetworkSecurityPerimeterConfiguration"/>.
        /// This factory method is preserved for backward compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsNetworkSecurityPerimeterConfiguration EventHubsNetworkSecurityPerimeterConfiguration(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            EventHubsNetworkSecurityPerimeterConfigurationProvisioningState? provisioningState,
            IEnumerable<EventHubsProvisioningIssue> provisioningIssues,
            EventHubsNetworkSecurityPerimeter networkSecurityPerimeter,
            EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation resourceAssociation,
            EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile profile,
            bool? isBackingResource,
            IEnumerable<string> applicableFeatures,
            string parentAssociationName,
            ResourceIdentifier sourceResourceId,
            AzureLocation? location)
        {
            var data = EventHubsNetworkSecurityPerimeterConfigurationData(
                id, name, resourceType, systemData,
                provisioningState, provisioningIssues, networkSecurityPerimeter,
                resourceAssociation, profile, isBackingResource,
                applicableFeatures, parentAssociationName, sourceResourceId, location);
            return new EventHubsNetworkSecurityPerimeterConfiguration(data);
        }
    }
}

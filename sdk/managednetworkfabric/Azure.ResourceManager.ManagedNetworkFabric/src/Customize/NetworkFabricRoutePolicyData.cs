// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    /// <summary>
    /// A class representing the NetworkFabricRoutePolicy data model.
    /// The RoutePolicy resource definition.
    /// </summary>
    public partial class NetworkFabricRoutePolicyData : TrackedResourceData
    {
        /// <summary>
        /// This constructor is added for the backward compatibility
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="systemData"></param>
        /// <param name="tags"></param>
        /// <param name="location"></param>
        /// <param name="annotation"></param>
        /// <param name="statements"></param>
        /// <param name="networkFabricId"></param>
        /// <param name="addressFamilyType"></param>
        /// <param name="configurationState"></param>
        /// <param name="provisioningState"></param>
        /// <param name="administrativeState"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal NetworkFabricRoutePolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, IList<RoutePolicyStatementProperties> statements, ResourceIdentifier networkFabricId, AddressFamilyType? addressFamilyType, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState) : base(id, name, resourceType, systemData, tags, location)
        {
            Annotation = annotation;
            Statements = statements;
            NetworkFabricId = networkFabricId;
            AddressFamilyType = addressFamilyType;
            ConfigurationState = configurationState;
            ProvisioningState = provisioningState;
            AdministrativeState = administrativeState;
        }
    }
}

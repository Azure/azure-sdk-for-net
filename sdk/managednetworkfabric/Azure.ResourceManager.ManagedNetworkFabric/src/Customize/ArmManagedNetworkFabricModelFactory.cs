// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmManagedNetworkFabricModelFactory
    {
        /// <summary>
        /// This constructor is added for the backward compatibility.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="systemData"></param>
        /// <param name="tags"></param>
        /// <param name="location"></param>
        /// <param name="annotation"></param>
        /// <param name="configurationType"></param>
        /// <param name="aclsUri"></param>
        /// <param name="matchConfigurations"></param>
        /// <param name="dynamicMatchConfigurations"></param>
        /// <param name="lastSyncedOn"></param>
        /// <param name="configurationState"></param>
        /// <param name="provisioningState"></param>
        /// <param name="administrativeState"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricAccessControlListData NetworkFabricAccessControlListData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, NetworkFabricConfigurationType? configurationType, Uri aclsUri, IEnumerable<AccessControlListMatchConfiguration> matchConfigurations, IEnumerable<CommonDynamicMatchConfiguration> dynamicMatchConfigurations, DateTimeOffset? lastSyncedOn, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkFabricAccessControlListData(id, name, resourceType, systemData, tags, location, annotation, configurationType, aclsUri, null, matchConfigurations?.ToList(), dynamicMatchConfigurations?.ToList(), lastSyncedOn, configurationState, provisioningState, administrativeState);
        }

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
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricRoutePolicyData NetworkFabricRoutePolicyData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, IEnumerable<RoutePolicyStatementProperties> statements, ResourceIdentifier networkFabricId, AddressFamilyType? addressFamilyType, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkFabricRoutePolicyData(id, name, resourceType, systemData, tags, location, annotation, null, statements?.ToList(), networkFabricId, addressFamilyType, configurationState, provisioningState, administrativeState);
        }

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
        /// <param name="internetGatewayRuleId"></param>
        /// <param name="ipv4Address"></param>
        /// <param name="port"></param>
        /// <param name="typePropertiesType"></param>
        /// <param name="networkFabricControllerId"></param>
        /// <param name="provisioningState"></param>
        /// <returns></returns>
        public static NetworkFabricInternetGatewayData NetworkFabricInternetGatewayData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, ResourceIdentifier internetGatewayRuleId, IPAddress ipv4Address, int? port, InternetGatewayType typePropertiesType, ResourceIdentifier networkFabricControllerId, NetworkFabricProvisioningState? provisioningState)
        {
            return NetworkFabricInternetGatewayData(id, name, resourceType, systemData, tags, location, annotation, internetGatewayRuleId, ipv4Address, port, typePropertiesType, networkFabricControllerId, provisioningState);
        }
    }
}

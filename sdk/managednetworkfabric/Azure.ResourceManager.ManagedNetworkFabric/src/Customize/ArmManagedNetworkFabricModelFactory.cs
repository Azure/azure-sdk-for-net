// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmManagedNetworkFabricModelFactory
    {
        /// <summary>
        /// 
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
        public static NetworkFabricAccessControlListData NetworkFabricAccessControlListData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string annotation = null, NetworkFabricConfigurationType? configurationType = null, Uri aclsUri = null, IEnumerable<AccessControlListMatchConfiguration> matchConfigurations = null, IEnumerable<CommonDynamicMatchConfiguration> dynamicMatchConfigurations = null, DateTimeOffset? lastSyncedOn = null, NetworkFabricConfigurationState? configurationState = null, NetworkFabricProvisioningState? provisioningState = null, NetworkFabricAdministrativeState? administrativeState = null)
        {
            tags ??= new Dictionary<string, string>();
            matchConfigurations ??= new List<AccessControlListMatchConfiguration>();
            dynamicMatchConfigurations ??= new List<CommonDynamicMatchConfiguration>();

            return new NetworkFabricAccessControlListData(id, name, resourceType, systemData, tags, location, annotation, configurationType, aclsUri, matchConfigurations?.ToList(), dynamicMatchConfigurations?.ToList(), lastSyncedOn, configurationState, provisioningState, administrativeState);
        }

        /// <summary>
        /// 
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
        public static NetworkFabricRoutePolicyData NetworkFabricRoutePolicyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string annotation = null, IEnumerable<RoutePolicyStatementProperties> statements = null, ResourceIdentifier networkFabricId = null, AddressFamilyType? addressFamilyType = null, NetworkFabricConfigurationState? configurationState = null, NetworkFabricProvisioningState? provisioningState = null, NetworkFabricAdministrativeState? administrativeState = null)
        {
            tags ??= new Dictionary<string, string>();
            statements ??= new List<RoutePolicyStatementProperties>();

            return new NetworkFabricRoutePolicyData(id, name, resourceType, systemData, tags, location, annotation, statements?.ToList(), networkFabricId, addressFamilyType, configurationState, provisioningState, administrativeState);
        }
    }
}

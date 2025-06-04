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

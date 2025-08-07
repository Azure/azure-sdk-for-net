// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.HybridConnectivity.Models;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    [CodeGenSuppress("IngressGatewayAsset", typeof(string), typeof(string), typeof(string), typeof(string), typeof(long?), typeof(string), typeof(string), typeof(System.Guid?), typeof(System.Guid?))]
    public static partial class ArmHybridConnectivityModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.IngressGatewayAsset"/>. </summary>
        /// <param name="hostname"> The ingress hostname. </param>
        /// <param name="serverId"> The arc ingress gateway server app id. </param>
        /// <param name="tenantId"> The target resource home tenant id. </param>
        /// <param name="namespaceName"> The namespace name. </param>
        /// <param name="namespaceNameSuffix"> The suffix domain name of relay namespace. </param>
        /// <param name="hybridConnectionName"> Azure Relay hybrid connection name for the resource. </param>
        /// <param name="accessKey"> Access key for hybrid connection. </param>
        /// <param name="expiresOn"> The expiration of access key in unix time. </param>
        /// <param name="serviceConfigurationToken"> The token to access the enabled service. </param>
        /// <returns> A new <see cref="Models.IngressGatewayAsset"/> instance for mocking. </returns>
        public static IngressGatewayAsset IngressGatewayAsset(string hostname = null, Guid? serverId = null, Guid? tenantId = null, string namespaceName = null, string namespaceNameSuffix = null, string hybridConnectionName = null, string accessKey = null, long? expiresOn = null, string serviceConfigurationToken = null)
        {
            return new IngressGatewayAsset(
                namespaceName,
                namespaceNameSuffix,
                hybridConnectionName,
                accessKey,
                expiresOn,
                serviceConfigurationToken,
                hostname,
                serverId,
                tenantId,
                serializedAdditionalRawData: null);
        }
    }
}
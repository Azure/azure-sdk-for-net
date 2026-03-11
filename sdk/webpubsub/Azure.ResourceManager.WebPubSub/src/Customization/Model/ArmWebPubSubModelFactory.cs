// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.WebPubSub.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.WebPubSub.Models
{
    /// <summary> Model factory for backward-compat overloads. </summary>
    [CodeGenSuppress("WebPubSubData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(BillingInfoSku), typeof(ManagedServiceIdentity), typeof(WebPubSubProvisioningState?), typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(IEnumerable<WebPubSubPrivateEndpointConnectionData>), typeof(IEnumerable<WebPubSubSharedPrivateLinkData>), typeof(bool?), typeof(string), typeof(LiveTraceConfiguration), typeof(IEnumerable<ResourceLogCategory>), typeof(WebPubSubNetworkAcls), typeof(string), typeof(bool?), typeof(bool?))]
    public static partial class ArmWebPubSubModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="WebPubSub.WebPubSubData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebPubSubData WebPubSubData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            IDictionary<string, string> tags,
            AzureLocation location,
            BillingInfoSku sku,
            ManagedServiceIdentity identity,
            WebPubSubProvisioningState? provisioningState,
            string externalIP,
            string hostName,
            int? publicPort,
            int? serverPort,
            string version,
            IEnumerable<WebPubSubPrivateEndpointConnectionData> privateEndpointConnections,
            IEnumerable<WebPubSubSharedPrivateLinkData> sharedPrivateLinkResources,
            bool? isClientCertEnabled,
            string hostNamePrefix,
            LiveTraceConfiguration liveTraceConfiguration,
            IEnumerable<ResourceLogCategory> resourceLogCategories,
            WebPubSubNetworkAcls networkAcls,
            string publicNetworkAccess,
            bool? isLocalAuthDisabled,
            bool? isAadAuthDisabled)
        {
            // Delegate to the new overload, dropping the identity parameter
            // since the type changed from ManagedServiceIdentity to ManagedIdentity.
            return WebPubSubData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                provisioningState: provisioningState,
                externalIP: externalIP,
                hostName: hostName,
                publicPort: publicPort,
                serverPort: serverPort,
                version: version,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                hostNamePrefix: hostNamePrefix,
                liveTraceConfiguration: liveTraceConfiguration,
                networkAcls: networkAcls,
                publicNetworkAccess: publicNetworkAccess,
                isLocalAuthDisabled: isLocalAuthDisabled,
                isAadAuthDisabled: isAadAuthDisabled,
                resourceLogCategories: resourceLogCategories,
                sku: sku,
                isClientCertEnabled: isClientCertEnabled);
        }
    }
}

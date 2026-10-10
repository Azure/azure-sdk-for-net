// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotHub.Models
{
    // Customization justification:
    // The TypeSpec-generated model factory follows the new generated model shape. This overload preserves
    // the previous GA factory signature for IotHubProperties so tests and customer code that construct
    // model instances for mocking do not need to change when moving to the migrated package. The
    // implementation delegates to the generated overload so there is a single construction path and the
    // compatibility shim does not duplicate initialization logic.
    public static partial class ArmIotHubModelFactory
    {
        /// <summary> Initializes a new instance of IotHubProperties. </summary>
        public static IotHubProperties IotHubProperties(IEnumerable<SharedAccessSignatureAuthorizationRule> authorizationPolicies = default, bool? disableLocalAuth = default, bool? disableDeviceSas = default, bool? disableModuleSas = default, bool? restrictOutboundNetworkAccess = default, IEnumerable<string> allowedFqdns = default, IotHubPublicNetworkAccess? publicNetworkAccess = default, IEnumerable<IotHubIPFilterRule> ipFilterRules = default, IotHubNetworkRuleSetProperties networkRuleSets = default, string minTlsVersion = default, IEnumerable<IotHubPrivateEndpointConnectionData> privateEndpointConnections = default, string provisioningState = default, string state = default, string hostName = default, IDictionary<string, EventHubCompatibleEndpointProperties> eventHubEndpoints = default, IotHubRoutingProperties routing = default, IDictionary<string, IotHubStorageEndpointProperties> storageEndpoints = default, IDictionary<string, MessagingEndpointProperties> messagingEndpoints = default, bool? enableFileUploadNotifications = default, CloudToDeviceProperties cloudToDevice = default, string comments = default, IEnumerable<string> deviceStreamsStreamingEndpoints = default, IotHubCapability? features = default, IotHubEncryptionProperties encryption = default, IEnumerable<IotHubLocationDescription> locations = default, bool? enableDataResidency = default, IotHubRootCertificateProperties rootCertificate = default, IotHubIPVersion? ipVersion = default, IotHubDeviceRegistry deviceRegistry = default)
            => IotHubProperties(
                authorizationPolicies: authorizationPolicies,
                disableLocalAuth: disableLocalAuth,
                disableDeviceSas: disableDeviceSas,
                disableModuleSas: disableModuleSas,
                restrictOutboundNetworkAccess: restrictOutboundNetworkAccess,
                allowedFqdns: allowedFqdns,
                publicNetworkAccess: publicNetworkAccess,
                ipFilterRules: ipFilterRules,
                networkRuleSets: networkRuleSets,
                minTlsVersion: minTlsVersion,
                privateEndpointConnections: privateEndpointConnections,
                provisioningState: provisioningState,
                state: state,
                hostName: hostName,
                eventHubEndpoints: eventHubEndpoints,
                routing: routing,
                storageEndpoints: storageEndpoints,
                messagingEndpoints: messagingEndpoints,
                enableFileUploadNotifications: enableFileUploadNotifications,
                cloudToDevice: cloudToDevice,
                comments: comments,
                deviceStreamsStreamingEndpoints: deviceStreamsStreamingEndpoints,
                features: features,
                encryption: encryption,
                locations: locations,
                enableDataResidency: enableDataResidency,
                rootCertificate: rootCertificate,
                ipVersion: ipVersion,
                deviceRegistry: deviceRegistry);
    }
}

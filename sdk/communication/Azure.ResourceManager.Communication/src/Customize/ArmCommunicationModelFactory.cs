// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Communication.Models
{
    // Backward compat: the generator emits broken backward-compat factory overloads for
    // CommunicationServiceResourceData — the overloads pass positional args in the wrong order
    // (provisioningState at position 7 where identity is expected) and reference non-existent
    // named parameters (publicNetworkAccess, isLocalAuthDisabled). These two [CodeGenSuppress]
    // attributes remove the broken overloads, and the replacement methods below delegate to the
    // current overload with correct parameter ordering.
    [CodeGenSuppress("CommunicationServiceResourceData",
        typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData),
        typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ManagedServiceIdentity),
        typeof(CommunicationServicesProvisioningState?), typeof(string), typeof(string),
        typeof(ResourceIdentifier), typeof(string), typeof(Guid?), typeof(IEnumerable<string>))]
    [CodeGenSuppress("CommunicationServiceResourceData",
        typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData),
        typeof(IDictionary<string, string>), typeof(AzureLocation),
        typeof(CommunicationServicesProvisioningState?), typeof(string), typeof(string),
        typeof(ResourceIdentifier), typeof(string), typeof(Guid?), typeof(IEnumerable<string>))]
    public static partial class ArmCommunicationModelFactory
    {
        /// <summary> Initializes a new instance of CommunicationServiceResourceData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunicationServiceResourceData CommunicationServiceResourceData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            IDictionary<string, string> tags,
            AzureLocation location,
            ManagedServiceIdentity identity,
            CommunicationServicesProvisioningState? provisioningState,
            string hostName,
            string dataLocation,
            ResourceIdentifier notificationHubId,
            string version,
            Guid? immutableResourceId,
            IEnumerable<string> linkedDomains)
        {
            return CommunicationServiceResourceData(
                id, name, resourceType, systemData, tags, location,
                identity, provisioningState, hostName, dataLocation,
                notificationHubId, version, immutableResourceId, linkedDomains,
                publicNetworkAccess: default, isLocalAuthDisabled: default);
        }

        /// <summary> Initializes a new instance of CommunicationServiceResourceData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunicationServiceResourceData CommunicationServiceResourceData(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            IDictionary<string, string> tags,
            AzureLocation location,
            CommunicationServicesProvisioningState? provisioningState,
            string hostName,
            string dataLocation,
            ResourceIdentifier notificationHubId,
            string version,
            Guid? immutableResourceId,
            IEnumerable<string> linkedDomains)
        {
            return CommunicationServiceResourceData(
                id, name, resourceType, systemData, tags, location,
                identity: default, provisioningState, hostName, dataLocation,
                notificationHubId, version, immutableResourceId, linkedDomains,
                publicNetworkAccess: default, isLocalAuthDisabled: default);
        }
    }
}

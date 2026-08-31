// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class ModelFactoryTests
    {
        [Test]
        public void StoragePrivateEndpointConnectionData_GeneratedParameterlessOverloadIsUnambiguous()
        {
            StoragePrivateEndpointConnectionData data = ArmStorageModelFactory.StoragePrivateEndpointConnectionData();

            Assert.IsNotNull(data);
        }

        [Test]
        public void StoragePrivateEndpointConnectionData_LegacyStringOverloadSetsProperties()
        {
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group/providers/Microsoft.Storage/storageAccounts/account/privateEndpointConnections/connection");
            string privateEndpointId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group/providers/Microsoft.Network/privateEndpoints/endpoint";
            ResourceType resourceType = new ResourceType("Microsoft.Storage/storageAccounts/privateEndpointConnections");
            SystemData systemData = new SystemData();
            StoragePrivateLinkServiceConnectionState connectionState = ArmStorageModelFactory.StoragePrivateLinkServiceConnectionState();

            StoragePrivateEndpointConnectionData data = ArmStorageModelFactory.StoragePrivateEndpointConnectionData(
                id,
                "connection",
                resourceType,
                systemData,
                connectionState,
                StoragePrivateEndpointConnectionProvisioningState.Succeeded,
                privateEndpointId);

            Assert.AreEqual(id, data.Id);
            Assert.AreEqual("connection", data.Name);
            Assert.AreEqual(resourceType, data.ResourceType);
            Assert.AreSame(systemData, data.SystemData);
            Assert.AreEqual(new ResourceIdentifier(privateEndpointId), data.PrivateEndpointId);
            Assert.AreSame(connectionState, data.ConnectionState);
            Assert.AreEqual(StoragePrivateEndpointConnectionProvisioningState.Succeeded, data.ProvisioningState);
        }

        [Test]
        public void StoragePrivateEndpointConnectionData_ResourceIdentifierOverloadSetsProperties()
        {
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group/providers/Microsoft.Storage/storageAccounts/account/privateEndpointConnections/connection");
            ResourceIdentifier privateEndpointId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group/providers/Microsoft.Network/privateEndpoints/endpoint");
            ResourceType resourceType = new ResourceType("Microsoft.Storage/storageAccounts/privateEndpointConnections");
            StoragePrivateLinkServiceConnectionState connectionState = ArmStorageModelFactory.StoragePrivateLinkServiceConnectionState();

            StoragePrivateEndpointConnectionData data = ArmStorageModelFactory.StoragePrivateEndpointConnectionData(
                id,
                "connection",
                resourceType,
                null,
                connectionState,
                StoragePrivateEndpointConnectionProvisioningState.Succeeded,
                privateEndpointId);

            Assert.AreEqual(id, data.Id);
            Assert.AreEqual(privateEndpointId, data.PrivateEndpointId);
            Assert.AreSame(connectionState, data.ConnectionState);
            Assert.AreEqual(StoragePrivateEndpointConnectionProvisioningState.Succeeded, data.ProvisioningState);
        }
    }
}

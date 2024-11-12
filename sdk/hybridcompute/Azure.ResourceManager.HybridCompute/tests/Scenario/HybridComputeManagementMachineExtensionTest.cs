// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridCompute;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;
using System.Diagnostics;

namespace Azure.ResourceManager.HybridCompute.Tests.Scenario
{
    public class HybridComputeManagementMachineExtensionTest : HybridComputeManagementTestBase
    {
        public HybridComputeManagementMachineExtensionTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CanCreateMachineExtension()
        {
            HybridComputeMachineExtensionData resourceData = await createMachineExtension();
            Assert.AreEqual(extensionName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanUpdateMachineExtension()
        {
            HybridComputeMachineExtensionData resourceData = await createMachineExtension();
            Assert.AreEqual(extensionName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetMachineExtension()
        {
            HybridComputeMachineExtensionData resourceData = await getMachineExtension();
            Assert.AreEqual(extensionName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetMachineExtensionCollection()
        {
            HybridComputeMachineExtensionCollection resourceCollection = await getMachineExtensionCollection();
            string collectionId = "/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + machineName;
            Assert.AreEqual(collectionId, resourceCollection.Id.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanCreatePrivateLinkScope()
        {
            HybridComputePrivateLinkScopeData resourceData = await createPrivateLinkScope();
            Assert.AreEqual(scopeName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanUpdatePrivateLinkScope()
        {
            HybridComputePrivateLinkScopeData resourceData = await updatePrivateLinkScope();
            Assert.AreEqual(scopeName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetPrivateLinkScope()
        {
            HybridComputePrivateLinkScopeData resourceData = await getPrivateLinkScope();
            Assert.AreEqual(scopeName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetPrivateLinkScopeCollection()
        {
            HybridComputePrivateLinkScopeCollection resourceCollection = await getPrivateLinkScopeCollection();
            string collectionId = "/subscriptions/" + subscriptionId + "/resourcegroups/" + resourceGroupName;
            Assert.AreEqual(collectionId, resourceCollection.Id.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetPrivateLinkResource()
        {
            HybridComputePrivateLinkResourceData resourceData = await getPrivateLinkResource();
            Assert.AreEqual("hybridcompute", resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetPrivateLinkResourceCollection()
        {
            HybridComputePrivateLinkResourceCollection resourceCollection = await getPrivateLinkResourceCollection();
            string collectionId = "/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.HybridCompute/privateLinkScopes/" + scopeName;
            Assert.AreEqual(collectionId, resourceCollection.Id.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanUpdatePrivateEndpointConnection()
        {
            HybridComputePrivateEndpointConnectionData endpointData = await updatePrivateEndpointConnection();
            Assert.AreEqual(privateEndpointConnectionName, endpointData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetPrivateEndpointConnection()
        {
            HybridComputePrivateEndpointConnectionData endpointData = await getPrivateEndpointConnection();
            Assert.NotNull(endpointData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetPrivateEndpointConnectionCollection()
        {
            HybridComputePrivateEndpointConnectionCollection resourceCollection = await getPrivateEndpointConnectionCollection();
            string collectionId = "/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.HybridCompute/privateLinkScopes/" + scopeName;
            Assert.AreEqual(collectionId, resourceCollection.Id.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeletePrivateEndpointConnection(){
            await deletePrivateEndpointConnection();
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeletePrivateLinkScope(){
            await deletePrivateLinkScope();
        }

        [TestCase]
        [RecordedTest]
        public async Task CanDeleteMachineExtension(){
            await deleteMachineExtension();
        }
    }
}

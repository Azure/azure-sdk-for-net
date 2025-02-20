// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevCenter.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class NetworkConnectionOperationsTests : DevCenterManagementTestBase
    {
        public NetworkConnectionOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task NetworkConnectionResourceFull()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            DevCenterNetworkConnectionCollection resourceCollection = rg.GetDevCenterNetworkConnections();

            string networkConnectionName = "sdk-networkconn";

            // Create

            var networkConnectionData = new DevCenterNetworkConnectionData(TestEnvironment.Location)
            {
                DomainJoinType = DomainJoinType.AadJoin,
                SubnetId = new Core.ResourceIdentifier($"{rg.Id}/providers/Microsoft.Network/virtualNetworks/sdk-vnet1/subnets/default"),
            };
            DevCenterNetworkConnectionResource createdResource =
                (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkConnectionName, networkConnectionData)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List
            List<DevCenterNetworkConnectionResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<DevCenterNetworkConnectionResource> retrievedNetworkConnection = await resourceCollection.GetAsync(networkConnectionName);
            Assert.NotNull(retrievedNetworkConnection.Value);
            Assert.NotNull(retrievedNetworkConnection.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedNetworkConnection.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}

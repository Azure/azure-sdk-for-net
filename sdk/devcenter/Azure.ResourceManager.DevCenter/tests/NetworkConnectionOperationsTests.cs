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
        [PlaybackOnly("TODO")]
        public async Task NetworkConnectionResourceFull()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            ArmOperation<ResourceGroupResource> rgResponse = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ResourceGroup, new ResourceGroupData(TestEnvironment.Location)).ConfigureAwait(false);
            ResourceGroupResource rg = rgResponse.Value;

            NetworkConnectionCollection networkConnectionCollection = rg.GetNetworkConnections();

            string networkConnectionName = "sdk-networkconn";

            // Create

            var networkConnectionData = new NetworkConnectionData(TestEnvironment.Location)
            {
                DomainJoinType = DomainJoinType.AzureADJoin,
                SubnetId = $"{rg.Id}/providers/Microsoft.Network/virtualNetworks/sdk-vnet1/subnets/default",
            };
            ArmOperation<NetworkConnectionResource> createdNetworkConnectionResponse =
                await networkConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkConnectionName, networkConnectionData);
            NetworkConnectionResource devCenterResource = createdNetworkConnectionResponse.Value;

            Assert.NotNull(devCenterResource);
            Assert.NotNull(devCenterResource.Data);

            // List
            AsyncPageable<NetworkConnectionResource> devCenters = networkConnectionCollection.GetAllAsync();
            int count = 0;
            await foreach (NetworkConnectionResource v in devCenters)
            {
                if (v.Id == devCenterResource.Id)
                {
                    count++;
                    break;
                }
            }
            Assert.True(count == 1);

            // Get
            Response<NetworkConnectionResource> retrievedNetworkConnection = await networkConnectionCollection.GetAsync(networkConnectionName);
            Assert.NotNull(retrievedNetworkConnection.Value);
            Assert.NotNull(retrievedNetworkConnection.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedNetworkConnection.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}

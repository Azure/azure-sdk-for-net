// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests.TestCase
{
    public class CognitiveServicesPrivateEndpointConnectionCollectionTests : CognitiveServicesManagementTestBase
    {
        public CognitiveServicesPrivateEndpointConnectionCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<CognitiveServicesPrivateEndpointConnectionCollection> GetCognitiveServicesPrivateEndpointConnectionCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), input);
            var account =  lro.Value;
            return account.GetCognitiveServicesPrivateEndpointConnections();
        }

        [TestCase]
        [RecordedTest]
        public async Task CognitiveServicesPrivateEndpointConnectionCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = await GetCognitiveServicesPrivateEndpointConnectionCollectionAsync();
            var name = Recording.GenerateAssetName("CognitiveServicesPrivateEndpointConnection-");
            var input = ResourceDataHelper.GetBasicCognitiveServicesPrivateEndpointConnectionData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            CognitiveServicesPrivateEndpointConnectionResource connection1 = lro.Value;
            Assert.AreEqual(name, connection1.Data.Name);
            //2.Get
            CognitiveServicesPrivateEndpointConnectionResource connection2 = await container.GetAsync(name);
            ResourceDataHelper.AssertConnection(connection1.Data, connection2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var connection in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4Exists
            Assert.IsTrue(await container.ExistsAsync(name));
            Assert.IsFalse(await container.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}

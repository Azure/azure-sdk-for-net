// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class PEConnectionCollectionTests : CognitiveServicesManagementTestBase
    {
        public PEConnectionCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<CognitiveServicesPrivateEndpointConnectionCollection> GetCognitiveServicesPrivateEndpointConnectionCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), input);
            var account =  lro.Value;
            return account.GetCognitiveServicesPrivateEndpointConnections();
        }

        [TestCase]
        public async Task PEConnectionCollectionApiTests()
        {
            //1.GetAll
            var container = await GetCognitiveServicesPrivateEndpointConnectionCollectionAsync();
            var list = await container.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 0);
            //4Exists
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}

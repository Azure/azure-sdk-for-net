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
    public class DeploymentCollectionTests : CognitiveServicesManagementTestBase
    {
        public DeploymentCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<DeploymentCollection> GetDeploymentCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), input);
            var account = lro.Value;
            return account.GetDeployments();
        }

        [TestCase]
        [RecordedTest]
        public async Task DeploymentCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = await GetDeploymentCollectionAsync();
            var name = Recording.GenerateAssetName("Deployment-");
            var input = ResourceDataHelper.GetBasicDeploymentData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DeploymentResource deployment1 = lro.Value;
            Assert.AreEqual(name, deployment1.Data.Name);
            //2.Get
            DeploymentResource deployment2 = await container.GetAsync(name);
            ResourceDataHelper.AssertDeployment(deployment1.Data, deployment2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var deployment in container.GetAllAsync())
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

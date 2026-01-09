// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class DeploymentCollectionTests : CognitiveServicesManagementTestBase
    {
        public DeploymentCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<CognitiveServicesAccountDeploymentCollection> GetDeploymentCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var input = ResourceDataHelper.GetBasicAccountData(AzureLocation.EastUS);
            input.Kind = "OpenAI";
            input.Sku = new CognitiveServicesSku("S0");
            var account = (await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), input)).Value;
            return account.GetCognitiveServicesAccountDeployments();
        }

        [TestCase]
        public async Task DeploymentCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = await GetDeploymentCollectionAsync();
            var name = Recording.GenerateAssetName("Deployment-");
            var input = ResourceDataHelper.GetBasicDeploymentData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            CognitiveServicesAccountDeploymentResource deployment1 = lro.Value;
            Assert.That(deployment1.Data.Name, Is.EqualTo(name));
            //2.Get
            CognitiveServicesAccountDeploymentResource deployment2 = await container.GetAsync(name);
            ResourceDataHelper.AssertDeployment(deployment1.Data, deployment2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var deployment in container.GetAllAsync())
            {
                count++;
            }

            Assert.Multiple(async () =>
            {
                Assert.That(count, Is.GreaterThanOrEqualTo(1));
                //4Exists
                Assert.That((bool)await container.ExistsAsync(name), Is.True);
                Assert.That((bool)await container.ExistsAsync(name + "1"), Is.False);
            });

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}

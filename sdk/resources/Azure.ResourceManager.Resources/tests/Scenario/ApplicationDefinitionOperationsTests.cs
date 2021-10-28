// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class ApplicationDefinitionOperationsTests : ResourcesTestBase
    {
        public ApplicationDefinitionOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-C-");
            ApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ApplicationDefinition applicationDefinition = (await rg.GetApplicationDefinitions().CreateOrUpdateAsync(applicationDefinitionName, applicationDefinitionData)).Value;
            await applicationDefinition.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await applicationDefinition.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}

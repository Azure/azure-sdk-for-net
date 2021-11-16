// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class ApplicationOperationsTests : ResourcesTestBase
    {
        public ApplicationOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-D-");
            ApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ApplicationDefinition appDef = (await rg.GetApplicationDefinitions().CreateOrUpdateAsync(appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-D-");
            ApplicationData applicationData = CreateApplicationData(appDef.Id, subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-5-"), Recording.GenerateAssetName("s5"));
            Application application = (await rg.GetApplications().CreateOrUpdateAsync(appName, applicationData)).Value;
            await application.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await application.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}

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
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-C-");
            ApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ApplicationDefinition applicationDefinition = (await rg.GetApplicationDefinitions().CreateOrUpdateAsync(applicationDefinitionName, applicationDefinitionData)).Value;
            await applicationDefinition.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await applicationDefinition.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
        private static ApplicationDefinitionData CreateApplicationDefinitionData(string displayName) => new ApplicationDefinitionData(Location.WestUS2, ApplicationLockLevel.None)
        {
            DisplayName = displayName,
            Description = $"{displayName} description",
            PackageFileUri = "https://raw.githubusercontent.com/Azure/azure-managedapp-samples/master/Managed%20Application%20Sample%20Packages/201-managed-storage-account/managedstorage.zip"
        };
    }
}

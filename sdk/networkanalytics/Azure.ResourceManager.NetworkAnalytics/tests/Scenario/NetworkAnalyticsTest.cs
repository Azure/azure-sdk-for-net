// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkAnalytics.Tests.Utilities;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkAnalytics.Tests.Scenario
{
    public class NetworkAnalyticsTest : NetworkAnalyticsManagementTestBase
    {
        public NetworkAnalyticsTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task CanCreateGetDataProduct()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(DefaultSubscription, NetworkAnalyticsManagementUtilities.DefaultResourceGroupName, NetworkAnalyticsManagementUtilities.DefaultResourceLocation);
            string dataProductName = Recording.GenerateAssetName("sdkdp");

            // Create Data Product
            DataProductResource dataProduct = await CreateDataProductResource(rg, dataProductName);

            // Get Data Product
            Response<DataProductResource> getDataProductResponse = await dataProduct.GetAsync();
            DataProductResource dataProductFetched = getDataProductResponse.Value;
            Assert.IsNotNull(dataProductFetched);
            Assert.AreEqual(dataProduct.Data.Location, dataProductFetched.Data.Location);

            // Delete Data Product
            Console.Write("Deleting DP");
            await dataProduct.DeleteAsync(WaitUntil.Completed);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteDetectorTest : AppServiceTestBase
    {
        public SiteDetectorTest(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<SiteDetectorCollection> GetSiteDetectorCollectionCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var container = resourceGroup.GetWebSites();
            var name = Recording.GenerateAssetName("testSite");
            var input = ResourceDataHelper.GetBasicSiteData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var site = lro.Value;
            return site.GetSiteDetectors();
        }

        [TestCase]
        [RecordedTest]
        public async Task SiteDetectorList()
        {
            var collection = await GetSiteDetectorCollectionCollectionAsync();
            int count = 0;
            await foreach (var item in collection.GetAllAsync())
            {
                count++;
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class SiteSlotConfigWebContainerTests : AppServiceTestBase
    {
        public SiteSlotConfigWebContainerTests(bool isAsync)
           : base(isAsync, Azure.Core.TestFramework.RecordedTestMode.Record)
        {
        }

        /*private async Task<SiteSlotConfigWebContainer> GetSiteSlotConfigWebContainerAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            Site site = resourceGroup.GetSites();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
        }*/
    }
}

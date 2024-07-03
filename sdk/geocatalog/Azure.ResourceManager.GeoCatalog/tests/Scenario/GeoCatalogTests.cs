// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.GeoCatalog;
using Azure.ResourceManager.GeoCatalog.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class GeoCatalogTests : GeoCatalogManagementTestBase
    {
        public GeoCatalogTests(bool async) : base(async) { }

        [TestCase]
        [RecordedTest]
        public async Task CanCreateGeoCatalog()
        {
            // create resource group
            var location = AzureLocation.EastUS;
            var Subscription = await Client.GetDefaultSubscriptionAsync();
            var rg = await CreateResourceGroup(Subscription, "geoCatalogRg-", location);

            // create geoCatalog
            var geoCatalogData = new GeoCatalogData(location);
            string resourceName = Recording.GenerateAssetName("geoCatalog");

            var resource = await gc.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, geoCatalogData);
            Assert.AreEqual(resourceName, resource.Value.Data.Name);
        }
    }
}

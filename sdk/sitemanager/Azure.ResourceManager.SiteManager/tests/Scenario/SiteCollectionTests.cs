// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SiteManager.Tests
{
    [TestFixture]
    public class SiteCollectionTests : SiteManagerManagementTestBase
    {
        public SiteCollectionTests() : base(true)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSiteCRUDOperations()
        {
            var location = AzureLocation.EastUS;
            var resourceGroup = await CreateResourceGroup(DefaultSubscription, "sites-rg", location);
            var siteCollection = resourceGroup.GetEdgeSites();
            var siteName = Recording.GenerateAssetName("SeattleSite");

            // Create
            var site = await CreateSiteAsync(resourceGroup, siteName);
            var siteData = site.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "Seattle Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");

            // Get
            EdgeSiteResource siteResourceFromGet = await siteCollection.GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "Seattle Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");
            Assert.That(siteData.Properties.Labels, Does.ContainKey("city").WithValue("Seattle"));

            await foreach (EdgeSiteResource siteResourceFromCollection in siteCollection)
            {
                Assert.AreEqual(siteResourceFromCollection.Data.Name, siteName);
                Assert.AreEqual(siteResourceFromCollection.Data.Properties.DisplayName, "Seattle Site");
                Assert.AreEqual(siteResourceFromCollection.Data.Properties.SiteAddress.Country, "USA");
            }

            // Update
            var UpdatedSite = await UpdateSiteAsync(resourceGroup, siteName);
            var UpdatedSiteData = UpdatedSite.Data;
            Assert.AreEqual(UpdatedSiteData.Name, siteName);
            Assert.AreEqual(UpdatedSiteData.Properties.DisplayName, "New York Site");
            Assert.AreEqual(UpdatedSiteData.Properties.SiteAddress.Country, "USA");
            Assert.AreEqual(UpdatedSiteData.Properties.SiteAddress.City, "New York");

            // Get
            siteResourceFromGet = await siteCollection.GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "New York Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");
            Assert.That(UpdatedSiteData.Properties.Labels, Does.ContainKey("city").WithValue("New York"));

            // Delete
            var deleteSite = await siteResourceFromGet.DeleteAsync(WaitUntil.Completed);
            await deleteSite.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteSite.HasCompleted);
        }
    }
}

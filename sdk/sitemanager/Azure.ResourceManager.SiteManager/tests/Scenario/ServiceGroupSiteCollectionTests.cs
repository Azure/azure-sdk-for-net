// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.SiteManager.Tests
{
    [TestFixture]
    public class ServiceGroupSiteCollectionTests : SiteManagerManagementTestBase
    {
        public ServiceGroupSiteCollectionTests() : base(true)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSiteCRUDOperations()
        {
            var location = AzureLocation.EastUS;
            var siteName = Recording.GenerateAssetName("SeattleSite");

            // Create
            var site = await CreateServiceGroupSiteAsync(DefaultTenant, siteName, "BasavarajSG");
            var siteData = site.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "Seattle Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");

            // Get
            EdgeSiteResource siteResourceFromGet = await DefaultTenant.GetSitesByServiceGroupAsync("BasavarajSG", siteName);
            siteData = siteResourceFromGet.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "Seattle Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");
            Assert.That(siteData.Properties.Labels, Does.ContainKey("city").WithValue("Seattle"));

            // Update
            var UpdatedSite = await UpdateServiceGroupSiteAsync(DefaultTenant, siteName, "BasavarajSG");
            var UpdatedSiteData = UpdatedSite.Data;
            Assert.AreEqual(UpdatedSiteData.Name, siteName);
            Assert.AreEqual(UpdatedSiteData.Properties.DisplayName, "New York Site");
            Assert.AreEqual(UpdatedSiteData.Properties.SiteAddress.Country, "USA");
            Assert.AreEqual(UpdatedSiteData.Properties.SiteAddress.City, "New York");

            // Get
            siteResourceFromGet = await DefaultTenant.GetSitesByServiceGroupAsync("BasavarajSG", siteName);
            siteData = siteResourceFromGet.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "New York Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");
            Assert.That(UpdatedSiteData.Properties.Labels, Does.ContainKey("city").WithValue("New York"));

            // Delete
            var deleteSite = await DefaultTenant.DeleteSitesByServiceGroupAsync("BasavarajSG", siteName);
            Assert.AreEqual(deleteSite.Status, 200);
        }
    }
}

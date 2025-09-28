// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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
            var site = await CreateServiceGroupSiteAsync(Client, siteName, "BasavarajSG");
            var siteData = site.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "Seattle Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");

            // Get
            ServiceGroupEdgeSiteResource siteResourceFromGet = await Client.GetServiceGroupEdgeSites(CreateServiceGroupId("BasavarajSG")).GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "Seattle Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");
            Assert.That(siteData.Properties.Labels, Does.ContainKey("city").WithValue("Seattle"));

            // Update
            var UpdatedSite = await UpdateServiceGroupSiteAsync(Client, siteName, "BasavarajSG");
            var UpdatedSiteData = UpdatedSite.Data;
            Assert.AreEqual(UpdatedSiteData.Name, siteName);
            Assert.AreEqual(UpdatedSiteData.Properties.DisplayName, "New York Site");
            Assert.AreEqual(UpdatedSiteData.Properties.SiteAddress.Country, "USA");
            Assert.AreEqual(UpdatedSiteData.Properties.SiteAddress.City, "New York");

            // Get
            siteResourceFromGet = await Client.GetServiceGroupEdgeSites(CreateServiceGroupId("BasavarajSG")).GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.AreEqual(siteData.Name, siteName);
            Assert.AreEqual(siteData.Properties.DisplayName, "New York Site");
            Assert.AreEqual(siteData.Properties.SiteAddress.Country, "USA");
            Assert.That(UpdatedSiteData.Properties.Labels, Does.ContainKey("city").WithValue("New York"));

            // Delete
            await Client.GetServiceGroupEdgeSiteResource(ServiceGroupEdgeSiteResource.CreateResourceIdentifier("BasavarajSG", siteName)).DeleteAsync(WaitUntil.Completed);
        }
    }
}

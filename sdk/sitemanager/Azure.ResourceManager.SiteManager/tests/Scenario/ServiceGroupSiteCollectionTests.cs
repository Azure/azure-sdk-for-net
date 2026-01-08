// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SiteManager.Tests
{
    public class ServiceGroupSiteCollectionTests : SiteManagerManagementTestBase
    {
        public ServiceGroupSiteCollectionTests(bool async) : base(async)
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
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(siteData.Name));
                Assert.That(siteData.Properties.DisplayName, Is.EqualTo("Seattle Site"));
                Assert.That(siteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
            });

            // Get
            ServiceGroupEdgeSiteResource siteResourceFromGet = await Client.GetServiceGroupEdgeSites(CreateServiceGroupId("BasavarajSG")).GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(siteData.Name));
                Assert.That(siteData.Properties.DisplayName, Is.EqualTo("Seattle Site"));
                Assert.That(siteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
                Assert.That(siteData.Properties.Labels, Does.ContainKey("city").WithValue("Seattle"));
            });

            // Update
            var UpdatedSite = await UpdateServiceGroupSiteAsync(Client, siteName, "BasavarajSG");
            var UpdatedSiteData = UpdatedSite.Data;
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(UpdatedSiteData.Name));
                Assert.That(UpdatedSiteData.Properties.DisplayName, Is.EqualTo("New York Site"));
                Assert.That(UpdatedSiteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
                Assert.That(UpdatedSiteData.Properties.SiteAddress.City, Is.EqualTo("New York"));
            });

            // Get
            siteResourceFromGet = await Client.GetServiceGroupEdgeSites(CreateServiceGroupId("BasavarajSG")).GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(siteData.Name));
                Assert.That(siteData.Properties.DisplayName, Is.EqualTo("New York Site"));
                Assert.That(siteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
                Assert.That(UpdatedSiteData.Properties.Labels, Does.ContainKey("city").WithValue("New York"));
            });

            // Delete
            await Client.GetServiceGroupEdgeSiteResource(ServiceGroupEdgeSiteResource.CreateResourceIdentifier("BasavarajSG", siteName)).DeleteAsync(WaitUntil.Completed);
        }
    }
}

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
    public class SiteCollectionTests : SiteManagerManagementTestBase
    {
        public SiteCollectionTests(bool async) : base(async)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSiteCRUDOperations()
        {
            var location = AzureLocation.EastUS;
            var resourceGroup = await CreateResourceGroup(DefaultSubscription, "sites-rg", location);
            var siteCollection = resourceGroup.GetResourceGroupEdgeSites();
            var siteName = Recording.GenerateAssetName("SeattleSite");

            // Create
            var site = await CreateSiteAsync(resourceGroup, siteName);
            var siteData = site.Data;
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(siteData.Name));
                Assert.That(siteData.Properties.DisplayName, Is.EqualTo("Seattle Site"));
                Assert.That(siteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
            });

            // Get
            ResourceGroupEdgeSiteResource siteResourceFromGet = await siteCollection.GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(siteData.Name));
                Assert.That(siteData.Properties.DisplayName, Is.EqualTo("Seattle Site"));
                Assert.That(siteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
                Assert.That(siteData.Properties.Labels, Does.ContainKey("city").WithValue("Seattle"));
            });

            await foreach (var siteResourceFromCollection in siteCollection)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(siteName, Is.EqualTo(siteResourceFromCollection.Data.Name));
                    Assert.That(siteResourceFromCollection.Data.Properties.DisplayName, Is.EqualTo("Seattle Site"));
                    Assert.That(siteResourceFromCollection.Data.Properties.SiteAddress.Country, Is.EqualTo("USA"));
                });
            }

            // Update
            var UpdatedSite = await UpdateSiteAsync(resourceGroup, siteName);
            var UpdatedSiteData = UpdatedSite.Data;
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(UpdatedSiteData.Name));
                Assert.That(UpdatedSiteData.Properties.DisplayName, Is.EqualTo("New York Site"));
                Assert.That(UpdatedSiteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
                Assert.That(UpdatedSiteData.Properties.SiteAddress.City, Is.EqualTo("New York"));
            });

            // Get
            siteResourceFromGet = await siteCollection.GetAsync(siteName);
            siteData = siteResourceFromGet.Data;
            Assert.Multiple(() =>
            {
                Assert.That(siteName, Is.EqualTo(siteData.Name));
                Assert.That(siteData.Properties.DisplayName, Is.EqualTo("New York Site"));
                Assert.That(siteData.Properties.SiteAddress.Country, Is.EqualTo("USA"));
                Assert.That(UpdatedSiteData.Properties.Labels, Does.ContainKey("city").WithValue("New York"));
            });

            // Delete
            var deleteSite = await siteResourceFromGet.DeleteAsync(WaitUntil.Completed);
            await deleteSite.WaitForCompletionResponseAsync();
            Assert.That(deleteSite.HasCompleted, Is.True);
        }
    }
}

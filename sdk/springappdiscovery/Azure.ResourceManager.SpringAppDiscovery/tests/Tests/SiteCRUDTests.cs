// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SpringAppDiscovery.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SpringAppDiscovery.Tests.Tests
{
    [TestFixture]
    public class SiteCRUDTests : SpringAppDiscoveryManagementTestBase
    {
        public const string migrationProject = "springboot-sites-crud-migrationprj";
        public AzureLocation defaultResourceLocation = AzureLocation.SoutheastAsia;

        public ResourceType resourceType = new ResourceType("microsoft.offazurespringboot/springbootsites");

        public SpringbootsitesProperties siteProperties = new SpringbootsitesProperties();

        public SpringbootsitesModelExtendedLocation extendLocation = new SpringbootsitesModelExtendedLocation("CustomLocation", "/subscriptions/" + subId +"/resourceGroups/" +  rgName + "/providers/Microsoft.ExtendedLocation/customLocations/springboot");

        public SiteCRUDTests() : base(true)
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

        /// <summary>
        /// Test Site CRUD for spring discovery
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public async Task TestSitesCRUDAsyncOperations()
        {
            SpringbootsitesModelCollection siteColletion = await GetSpringbootsitesModelCollectionAsync(rgName);

            siteProperties.MasterSiteId="1234";
            siteProperties.MigrateProjectId="5678";

            SpringbootsitesModelData modelData = new SpringbootsitesModelData(null, siteName, resourceType, null, new Dictionary<string, string>(),
                defaultResourceLocation, siteProperties, extendLocation);

            //create a site
            var createSiteOperation = await siteColletion.CreateOrUpdateAsync(WaitUntil.Completed, siteName, modelData, CancellationToken.None);
            Assert.IsTrue(createSiteOperation.HasCompleted);
            Assert.IsTrue(createSiteOperation.HasValue);

            //judge a site exist or not
            Assert.IsTrue(await siteColletion.ExistsAsync(siteName));

            //get a site
            Response<SpringbootsitesModelResource> getSiteResponse = await siteColletion.GetAsync(siteName);
            SpringbootsitesModelResource siteResource = getSiteResponse.Value;
            NullableResponse<SpringbootsitesModelResource> getIfExistResponse = await siteColletion.GetIfExistsAsync(siteName);
            Assert.True(getIfExistResponse.HasValue);

            //get all sites
            AsyncPageable<SpringbootsitesModelResource> getSiteAllResponse = siteColletion.GetAllAsync(CancellationToken.None);
            int siteCount = 0;
            await foreach (var item in getSiteAllResponse) {
                siteCount++;
            }
            Assert.True(siteCount > 0);

            //delete a site
            var deletetServerOperationAgain = await siteResource.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(deletetServerOperationAgain.HasCompleted);
        }
    }
}

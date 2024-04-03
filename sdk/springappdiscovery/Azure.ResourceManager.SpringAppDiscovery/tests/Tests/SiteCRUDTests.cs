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

namespace Azure.ResourceManager.SpringAppDiscovery.Tests
{
    public class SiteCRUDTests : SpringAppDiscoveryManagementTestBase
    {
        public const string migrationProject = "springboot-sites-crud-migrationprj";
        public AzureLocation defaultResourceLocation = AzureLocation.SoutheastAsia;

        public ResourceType resourceType = new ResourceType("microsoft.offazurespringboot/springbootsites");

        public SpringBootSiteProperties siteProperties = new SpringBootSiteProperties();

        public SpringBootSiteModelExtendedLocation extendLocation = new SpringBootSiteModelExtendedLocation("CustomLocation", "/subscriptions/" + subId + "/resourceGroups/" + rgName + "/providers/Microsoft.ExtendedLocation/customLocations/springboot", null);

        public SiteCRUDTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test Site CRUD for spring discovery
        /// </summary>
        /// <returns></returns>
        [TestCase]
        [RecordedTest]
        public async Task TestSitesCRUDAsyncOperations()
        {
            SpringBootSiteCollection siteColletion = await GetSpringbootsitesModelCollectionAsync(rgName);

            siteProperties.MasterSiteId = "1234";
            siteProperties.MigrateProjectId = "5678";

            SpringBootSiteData modelData = new SpringBootSiteData(null, siteName, resourceType, null, new Dictionary<string, string>(),
                defaultResourceLocation, siteProperties, extendLocation, null);

            //create a site
            var createSiteOperation = await siteColletion.CreateOrUpdateAsync(WaitUntil.Completed, siteName, modelData, CancellationToken.None);
            Assert.IsTrue(createSiteOperation.HasCompleted);
            Assert.IsTrue(createSiteOperation.HasValue);

            //judge a site exist or not
            Assert.IsTrue(await siteColletion.ExistsAsync(siteName));

            //get a site
            Response<SpringBootSiteResource> getSiteResponse = await siteColletion.GetAsync(siteName);
            SpringBootSiteResource siteResource = getSiteResponse.Value;
            NullableResponse<SpringBootSiteResource> getIfExistResponse = await siteColletion.GetIfExistsAsync(siteName);
            Assert.True(getIfExistResponse.HasValue);

            //get all sites
            AsyncPageable<SpringBootSiteResource> getSiteAllResponse = siteColletion.GetAllAsync(CancellationToken.None);
            int siteCount = 0;
            await foreach (var item in getSiteAllResponse)
            {
                siteCount++;
            }
            Assert.True(siteCount > 0);

            //delete a site
            var deletetServerOperationAgain = await siteResource.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(deletetServerOperationAgain.HasCompleted);
        }
    }
}

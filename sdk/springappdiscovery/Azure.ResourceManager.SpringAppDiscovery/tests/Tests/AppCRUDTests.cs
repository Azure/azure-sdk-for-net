// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AppCRUDTests : SpringAppDiscoveryManagementTestBase
    {
        public const string rgName = "sdk-migration-test1";
        public const string siteName = "springboot-sites-crud-site-for-server";
        public const string migrationProject = "springboot-sites-crud-migrationprj";
        public AzureLocation defaultResourceLocation = AzureLocation.SoutheastAsia;

        public ResourceType resourceType = new ResourceType("microsoft.offazurespringboot/springbootsites");

        public SpringbootsitesProperties siteProperties = new SpringbootsitesProperties();

        public SpringbootsitesModelExtendedLocation extendLocation = new SpringbootsitesModelExtendedLocation("microsoft.extendedlocation/customlocations", "springboot");

        public const string serverName = "test-swagger-api-server";

        public const string serverIp = "10.150.221.94";

        public const string machineId = "test-swagger-marchine-id";

         public const string appName = "test-swagger-app-name";

        public AppCRUDTests() : base(true)
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
        /// Test Server CRUD for spring discovery
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public async Task TestSitesCRUDAsyncOperations()
        {
            SpringbootsitesModelResource siteModelResource = await GetSpringsiteModelResource(rgName, siteName);
            SpringbootappsModelCollection appsColletion = siteModelResource.GetSpringbootappsModels();
            bool result = await appsColletion.ExistsAsync(appName, CancellationToken.None);
            Assert.IsFalse(result);

            AsyncPageable<SpringbootappsModelResource> appListResponse = appsColletion.GetAllAsync();
            int appCount = 0;
            await foreach (var item in appListResponse) {
                appCount++;
            }
            Assert.True(appCount > 0);

            Response<SpringbootappsModelResource> appResponse = await appsColletion.GetAsync(appName);
            SpringbootappsModelResource appModelResource = appResponse.Value;
            Assert.IsNotNull(appModelResource);
            SpringbootappsModelData appModelData = appModelResource.Data;
            Assert.IsNotNull(appModelData);

            KeyValuePair<string, string> myKeyValuePair = new KeyValuePair<string, string>("appKey", "appValue");
            SpringbootappsModelPatch appPatch = new SpringbootappsModelPatch(){
                Tags = {myKeyValuePair,}
            };

            var updateOperataion = await appModelResource.UpdateAsync(WaitUntil.Completed, appPatch);
            await  updateOperataion.WaitForCompletionAsync();
            Assert.IsTrue(updateOperataion.HasCompleted);
            appResponse = await appsColletion.GetAsync(appName);
             appModelResource = appResponse.Value;
            Assert.IsNotNull(appModelResource);
            appModelData = appModelResource.Data;
            Assert.IsNotNull(appModelData);
            IDictionary<string, string> tags = appModelData.Tags;
            Assert.IsTrue(tags.Contains(myKeyValuePair));

            appResponse = await appModelResource.AddTagAsync("a", "b", CancellationToken.None);
            Assert.IsNotNull(appResponse);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        /// Test App CRUD for spring discovery
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public async Task TestAppsCRUDAsyncOperations()
        {
            //get a site
            SpringbootsitesModelResource siteModelResource = await GetSpringsiteModelResource(rgName, siteName);
            await siteModelResource.TriggerRefreshSiteAsync(WaitUntil.Completed);

            //judge a app exist or not
            SpringbootappsModelCollection appsColletion = siteModelResource.GetSpringbootappsModels();
            bool result = await appsColletion.ExistsAsync(appName, CancellationToken.None);
            Assert.IsTrue(result);

            //get all apps
            AsyncPageable<SpringbootappsModelResource> appListResponse = appsColletion.GetAllAsync();
            int appCount = 0;
            await foreach (var item in appListResponse) {
                appCount++;
            }
            Assert.True(appCount > 0);

            //get an app
            Response<SpringbootappsModelResource> appResponse = await appsColletion.GetAsync(appName);
            SpringbootappsModelResource appModelResource = appResponse.Value;
            Assert.IsNotNull(appModelResource);
            SpringbootappsModelData appModelData = appModelResource.Data;
            Assert.IsNotNull(appModelData);

            //patch an app
            KeyValuePair<string, string> myKeyValuePair = new KeyValuePair<string, string>("appKey", "appValue");
            SpringbootappsModelPatch appPatch = new SpringbootappsModelPatch(){
                Tags = {myKeyValuePair,}
            };

            var updateOperataion = await appModelResource.UpdateAsync(WaitUntil.Completed, appPatch);
            await  updateOperataion.WaitForCompletionAsync();
            Assert.IsTrue(updateOperataion.HasCompleted);
            Assert.IsTrue(await containsTag(appsColletion, appName, myKeyValuePair));
        }

        private async Task<bool> containsTag(SpringbootappsModelCollection appsColletion, string appName, KeyValuePair<string, string> myKeyValuePair) {
            Response<SpringbootappsModelResource> appResponse = await appsColletion.GetAsync(appName);
            SpringbootappsModelResource appModelResource = appResponse.Value;
            Assert.IsNotNull(appModelResource);
            SpringbootappsModelData appModelData = appModelResource.Data;
            Assert.IsNotNull(appModelData);
            IDictionary<string, string> tags = appModelData.Tags;
            return tags.Contains(myKeyValuePair);
        }
    }
}

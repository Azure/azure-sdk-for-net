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
    public class SummaryCRUDTests : SpringAppDiscoveryManagementTestBase
    {
        public SummaryCRUDTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test Summary CRUD for spring discovery
        /// </summary>
        /// <returns></returns>
        [TestCase]
        [RecordedTest]
        public async Task TestSummariesCRUDAsyncOperations()
        {
            SpringBootSiteCollection siteColletion = await GetSpringbootsitesModelCollectionAsync(rgName);

            //judge a site exist or not
            Assert.IsTrue(await siteColletion.ExistsAsync(siteName));

            //get a site
            Response<SpringBootSiteResource> getSiteResponse = await siteColletion.GetAsync(siteName);
            SpringBootSiteResource siteResource = getSiteResponse.Value;
            SpringBootSiteSummaryCollection summaryCollection = siteResource.GetSpringBootSiteSummaries();

            //get all summaries
            AsyncPageable<SpringBootSiteSummaryResource> getSummaryResponse = summaryCollection.GetAllAsync();
            int summaryCount = 0;
            await foreach (var item in getSummaryResponse)
            {
                summaryCount++;
            }
            Assert.True(summaryCount > 0);

            //get a summary
            Response<SpringBootSiteSummaryResource> getSummaryReponse = await summaryCollection.GetAsync("default", CancellationToken.None);
            Assert.IsNotNull(getSummaryReponse.Value);
        }
    }
}

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
    public class SummaryCRUDTests : SpringAppDiscoveryManagementTestBase
    {
        public SummaryCRUDTests() : base(true)
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
        /// Test Summary CRUD for spring discovery
        /// </summary>
        /// <returns></returns>
        [TestCase]
        public async Task TestSummariesCRUDAsyncOperations()
        {
            SpringbootsitesModelCollection siteColletion = await GetSpringbootsitesModelCollectionAsync(rgName);

            //judge a site exist or not
            Assert.IsTrue(await siteColletion.ExistsAsync(siteName));

            //get a site
            Response<SpringbootsitesModelResource> getSiteResponse = await siteColletion.GetAsync(siteName);
            SpringbootsitesModelResource siteResource = getSiteResponse.Value;
            SummaryCollection summaryCollection = siteResource.GetSummaries();

            //get all summaries
            AsyncPageable<SummaryResource> getSummaryResponse = summaryCollection.GetAllAsync();
            int summaryCount = 0;
            await foreach (var item in getSummaryResponse) {
                summaryCount++;
            }
            Assert.True(summaryCount > 0);

            //get a summary
            Response<SummaryResource> getSummaryReponse = await summaryCollection.GetAsync("default", CancellationToken.None);
            Assert.IsNotNull(getSummaryReponse.Value);
        }
    }
}

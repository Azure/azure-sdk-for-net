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
    public class ErrorSummaryCRUDTests : SpringAppDiscoveryManagementTestBase
    {
        public ErrorSummaryCRUDTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test ErrorSummary CRUD for spring discovery
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
            SpringBootSiteErrorSummaryCollection errorSummaryCollection = siteResource.GetSpringBootSiteErrorSummaries();

            //get all errorSummaries
            AsyncPageable<SpringBootSiteErrorSummaryResource> getErrorSummaryResponse = errorSummaryCollection.GetAllAsync();
            int errorSummaryCount = 0;
            await foreach (var item in getErrorSummaryResponse)
            {
                errorSummaryCount++;
            }
            Assert.True(errorSummaryCount > 0);

            //get an errorSummary
            Response<SpringBootSiteErrorSummaryResource> getErrorSummaryReponse = await errorSummaryCollection.GetAsync("default", CancellationToken.None);
            Assert.IsNotNull(getErrorSummaryReponse.Value);
        }
    }
}

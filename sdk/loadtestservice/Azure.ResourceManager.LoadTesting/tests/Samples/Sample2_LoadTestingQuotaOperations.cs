// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.LoadTesting.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.LoadTesting.Tests.Samples
{
    public class Sample2_LoadTestingQuotaOperations
    {
        private SubscriptionResource _subscription;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void getLoadTestingQuotaCollection()
        {
            #region Snippet:LoadTesting_GetQuotaCollection
            LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);
            // Use the quotaCollection for all the quota operations.
            #endregion Snippet:LoadTesting_GetQuotaCollection
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task getLoadTestingQuotaBucket()
        {
            #region Snippet:LoadTesting_GetQuotaBucket
            LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);

            // Get the quota values for a particular quota bucket
            Response<LoadTestingQuotaResource> quotaResponse = await QuotaCollection.GetAsync("maxConcurrentTestRuns");
            LoadTestingQuotaResource quotaBucket = quotaResponse.Value;
            #endregion Snippet:LoadTesting_GetQuotaBucket
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task getAllLoadTestingQuotaBuckets()
        {
            #region Snippet:LoadTesting_GetAllQuotaBuckets
            LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);

            // Get the quota values for a all quota buckets
            List<LoadTestingQuotaResource> quotaBuckets = await QuotaCollection.GetAllAsync().ToEnumerableAsync();
            #endregion Snippet:LoadTesting_GetAllQuotaBuckets
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task checkQuotaAvailability()
        {
            #region Snippet:LoadTesting_CheckQuotaAvailability
            LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);

            Response<LoadTestingQuotaResource> quotaResponse = await QuotaCollection.GetAsync("maxConcurrentTestRuns");
            LoadTestingQuotaResource quotaResource = quotaResponse.Value;

            LoadTestingQuotaBucketDimensions dimensions = new LoadTestingQuotaBucketDimensions("<subscription-id>", AzureLocation.WestUS2, null);
            LoadTestingQuotaBucketContent quotaAvailabilityPayload = new LoadTestingQuotaBucketContent(
                quotaResponse.Value.Data.Id,
                quotaResource.Data.Name,
                quotaResource.Data.ResourceType,
                null,
                quotaResource.Data.Usage,
                quotaResource.Data.Limit,
                50, // new quota value
                dimensions, null);

            Response<LoadTestingQuotaAvailabilityResult> checkAvailabilityResult = await quotaResponse.Value.CheckLoadTestingQuotaAvailabilityAsync(quotaAvailabilityPayload);
            // IsAvailable property indicates whether the requested quota is available.
            Console.WriteLine(checkAvailabilityResult.Value.IsAvailable);
            #endregion Snippet:LoadTesting_CheckQuotaAvailability
        }

        [SetUp]
        [Ignore("Only verifying that the sample builds")]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            this._subscription = await armClient.GetDefaultSubscriptionAsync();
        }
    }
}

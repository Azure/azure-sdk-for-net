// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Advisor.Tests
{
    public class SuppressionTests : AdvisorManagementTestBase
    {
        public SuppressionTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private const string TimeToLive = "01:00:00";

        [Test]
        public async Task SuppressionsTest()
        {
            // get recommendations, we should get a non-empty list
            var collection = Client.GetResourceRecommendationBases(DefaultSubscription.Id);
            var recs = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(recs.Count, 1);

            ResourceRecommendationBaseResource recommendation = null;

            // standard properties must all be populated
            foreach (var rec in recs)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(rec.Data.Id));
                Assert.IsFalse(string.IsNullOrWhiteSpace(rec.Data.Name));
                Assert.IsFalse(string.IsNullOrWhiteSpace(rec.Data.RecommendationTypeId));
                Assert.NotNull(rec.Data.Category);
                Assert.NotNull(rec.Data.Impact);
                Assert.NotNull(rec.Data.ShortDescription);
                Assert.IsFalse(string.IsNullOrWhiteSpace(rec.Data.ShortDescription.Problem));
                Assert.IsFalse(string.IsNullOrWhiteSpace(rec.Data.ShortDescription.Solution));
                if (!string.IsNullOrWhiteSpace(rec.Data.ImpactedValue))
                {
                    recommendation = rec;
                }
            }

            // at least one recommendation must have ImpactedValue
            Assert.NotNull(recommendation);

            // we should be able to fetch the recommendation by name
            var output = (await collection.GetAsync(recommendation.Data.Name)).Value;
            Assert.AreEqual(recommendation.Id, output.Id);
            Assert.AreEqual(recommendation.Data.Name, output.Data.Name);

            // we should be able to create a suppression with a specific TTL
            var suppressionCollection = recommendation.GetSuppressionContracts();
            var suppressionName = Recording.GenerateAssetName("NetSdkTest");
            var suppression = (await suppressionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                suppressionName,
                new SuppressionContractData() { Ttl = TimeToLive })).Value;
            Assert.AreEqual(TimeToLive, suppression.Data.Ttl);

            // we should be able to fetch the suppression by name
            var sup = (await suppressionCollection.GetAsync(suppressionName)).Value;
            Assert.AreEqual(sup.Data.Name, suppressionName);

            // we should be able to delete the suppression by name
            await sup.DeleteAsync(WaitUntil.Completed);
            var sups = (await suppressionCollection.ExistsAsync(suppressionName)).Value;
            Assert.IsFalse(sups);
        }
    }
}

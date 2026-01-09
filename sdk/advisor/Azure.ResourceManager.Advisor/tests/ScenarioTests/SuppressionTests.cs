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
            Assert.That(recs, Is.Not.Empty);

            ResourceRecommendationBaseResource recommendation = null;

            // standard properties must all be populated
            foreach (var rec in recs)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(string.IsNullOrWhiteSpace(rec.Data.Id), Is.False);
                    Assert.That(string.IsNullOrWhiteSpace(rec.Data.Name), Is.False);
                    Assert.That(string.IsNullOrWhiteSpace(rec.Data.RecommendationTypeId), Is.False);
                    Assert.That(rec.Data.Category, Is.Not.Null);
                    Assert.That(rec.Data.Impact, Is.Not.Null);
                    Assert.That(rec.Data.ShortDescription, Is.Not.Null);
                    Assert.That(string.IsNullOrWhiteSpace(rec.Data.ShortDescription.Problem), Is.False);
                    Assert.That(string.IsNullOrWhiteSpace(rec.Data.ShortDescription.Solution), Is.False);
                });
                if (!string.IsNullOrWhiteSpace(rec.Data.ImpactedValue))
                {
                    recommendation = rec;
                }
            }

            // at least one recommendation must have ImpactedValue
            Assert.That(recommendation, Is.Not.Null);

            // we should be able to fetch the recommendation by name
            var output = (await collection.GetAsync(recommendation.Data.Name)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(output.Id, Is.EqualTo(recommendation.Id));
                Assert.That(output.Data.Name, Is.EqualTo(recommendation.Data.Name));
            });

            // we should be able to create a suppression with a specific TTL
            var suppressionCollection = recommendation.GetSuppressionContracts();
            var suppressionName = Recording.GenerateAssetName("NetSdkTest");
            var suppression = (await suppressionCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                suppressionName,
                new SuppressionContractData() { Ttl = TimeToLive })).Value;
            Assert.That(suppression.Data.Ttl, Is.EqualTo(TimeToLive));

            // we should be able to fetch the suppression by name
            var sup = (await suppressionCollection.GetAsync(suppressionName)).Value;
            Assert.That(suppressionName, Is.EqualTo(sup.Data.Name));

            // we should be able to delete the suppression by name
            await sup.DeleteAsync(WaitUntil.Completed);
            var sups = (await suppressionCollection.ExistsAsync(suppressionName)).Value;
            Assert.That(sups, Is.False);
        }
    }
}

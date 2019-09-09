// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.Advisor;
using Microsoft.Azure.Management.Advisor.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Advisor.Tests.BasicTests
{
    public class SuppressionTests
    {
        const string SuppressionName = "NetSdkTest";
        const string TimeToLive = "00:01:00:00";

        [Fact]
        public void SuppressionsTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<AdvisorManagementClient>())
                {
                    // get recommendations, we should get a non-empty list
                    var recs = client.Recommendations.List();
                    Assert.NotEmpty(recs);

                    ResourceRecommendationBase recommendation = null;

                    // standard properties must all be populated
                    foreach (var rec in recs)
                    {
                        Assert.False(string.IsNullOrWhiteSpace(rec.Id));
                        Assert.False(string.IsNullOrWhiteSpace(rec.Name));
                        Assert.False(string.IsNullOrWhiteSpace(rec.Type));
                        Assert.False(string.IsNullOrWhiteSpace(rec.Category));
                        Assert.False(string.IsNullOrWhiteSpace(rec.Impact));
                        Assert.False(string.IsNullOrWhiteSpace(rec.Risk));
                        Assert.NotNull(rec.ShortDescription);
                        Assert.False(string.IsNullOrWhiteSpace(rec.ShortDescription.Problem));
                        Assert.False(string.IsNullOrWhiteSpace(rec.ShortDescription.Solution));
                        if (!string.IsNullOrWhiteSpace(rec.ImpactedValue))
                        {
                            recommendation = rec;
                        }
                    }

                    // at least one recommendation must have ImpactedValue
                    Assert.NotNull(recommendation);

                    // extract the URI for the tracked resource and the recommendation name
                    var resourceUri = recommendation.Id.Substring(0,
                        recommendation.Id.IndexOf("/providers/Microsoft.Advisor/recommendations",
                            StringComparison.Ordinal));
                    var recommendationName = recommendation.Name;

                    // we should be able to fetch the recommendation by name
                    var output = client.Recommendations.Get(resourceUri, recommendationName);
                    Assert.Equal(recommendation.Id, output.Id);
                    Assert.Equal(recommendation.Name, output.Name);

                    // we should be able to create a suppression with a specific TTL
                    var suppression = client.Suppressions.Create(resourceUri, recommendationName, SuppressionName,
                        new SuppressionContract(ttl: TimeToLive));
                    Assert.Equal(TimeToLive, suppression.Ttl);

                    // we should be able to fetch the suppression by name
                    var sup = client.Suppressions.Get(resourceUri, recommendationName, SuppressionName);
                    Assert.Equal(sup.Name, SuppressionName);
                    Assert.Equal(sup.Id, recommendation.Id + "/suppressions/" + SuppressionName);

                    // we should be able to delete the suppression by name
                    client.Suppressions.Delete(resourceUri, recommendationName, SuppressionName);
                    var sups = client.Suppressions.List();
                    foreach (var s in sups)
                    {
                        Assert.NotEqual(SuppressionName, s.Name);
                    }
                }
            }
        }
    }
}
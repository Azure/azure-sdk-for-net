// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Advisor;
using Microsoft.Azure.Management.Advisor.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Advisor.Tests.BasicTests
{
    public class SuppressionTests
    {
        [Fact]
        public void SuppressionsTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                using (var client = context.GetServiceClient<AdvisorManagementClient>())
                {
                    var recs = client.Recommendations.List();
                    Assert.NotEmpty(recs);

                    ResourceRecommendationBase recommendation = null;
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

                    Assert.NotNull(recommendation);
                    var resourceUri = recommendation.Id.Substring(0,
                        recommendation.Id.IndexOf("/providers/Microsoft.Advisor/recommendations",
                            StringComparison.Ordinal));

                    var recommendationName = recommendation.Name;
                    var suppressionName = "NetSdkTest";
                    var timeToLive = "00:01:00:00";

                    var output = client.Recommendations.Get(resourceUri, recommendationName);

                    Assert.Equal(recommendation.Id, output.Id);
                    Assert.Equal(recommendation.Name, output.Name);

                    var suppression = client.Suppressions.Create(resourceUri, recommendationName, suppressionName,
                        new SuppressionContract(ttl: timeToLive));

                    Assert.Equal(timeToLive, suppression.Ttl);

                    var sup = client.Suppressions.Get(resourceUri, recommendationName, suppressionName);

                    Assert.Equal(sup.Name, suppressionName);
                    Assert.Equal(sup.Id, recommendation.Id + "/suppressions/" + suppressionName);

                    client.Suppressions.Delete(resourceUri, recommendationName, suppressionName);

                    var sups = client.Suppressions.List();

                    foreach (var s in sups)
                    {
                        Assert.NotEqual(suppressionName, s.Name);
                    }
                }
            }
        }
    }
}

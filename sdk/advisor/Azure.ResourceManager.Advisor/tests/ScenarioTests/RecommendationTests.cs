// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Advisor.Tests
{
    public class RecommendationTests : AdvisorManagementTestBase
    {
        public RecommendationTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task GenerateRecommendationsTest()
        {
            var headers = await DefaultSubscription.GenerateRecommendationAsync();
            await DefaultSubscription.GetGenerateStatusRecommendationAsync(Guid.Parse(headers.Headers.RequestId));
        }
    }
}

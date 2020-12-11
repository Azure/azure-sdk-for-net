// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsClientTest : E2eTestBase
    {
        public TimeSeriesInsightsClientTest(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsClient_Construct()
        {
            TimeSeriesInsightsClient client = GetClient();
            Response<Models.ModelSettingsResponse> response = await client.GetAsync().ConfigureAwait(false);
            response.GetRawResponse().Status.Should().Be(200);
        }
    }
}

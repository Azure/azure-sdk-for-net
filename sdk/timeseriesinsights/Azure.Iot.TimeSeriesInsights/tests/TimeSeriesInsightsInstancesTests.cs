// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Iot.TimeSeriesInsights.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsInstancesTests : E2eTestBase
    {
        public TimeSeriesInsightsInstancesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsInstances_GetAllTimeSeriesInstances()
        {
            // arrange
            TimeSeriesInsightsClient client = GetClient();

            // act
            AsyncPageable<TimeSeriesInstance> timeSeriesInstances = client.GetTimeSeriesInstancesAsync();
            await foreach (TimeSeriesInstance instance in timeSeriesInstances)
            {
                Console.WriteLine($"Instance Id {string.Join(",", instance.TimeSeriesId)}");
            }
        }
    }
}

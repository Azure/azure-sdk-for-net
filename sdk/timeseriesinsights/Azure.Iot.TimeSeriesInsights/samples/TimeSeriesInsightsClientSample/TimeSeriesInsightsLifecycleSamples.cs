// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Iot.TimeSeriesInsights.Models;
using static Azure.Iot.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.Iot.TimeSeriesInsights.Samples
{
    internal class TimeSeriesInsightsLifecycleSamples
    {
        private readonly string tsiEndpointName;
        private readonly TimeSeriesInsightsClient client;

        public TimeSeriesInsightsLifecycleSamples(TimeSeriesInsightsClient tsiClient, string tsiEndpointName)
        {
            this.tsiEndpointName = tsiEndpointName;
            client = tsiClient;
        }

        /// <summary>
        /// This sample is a placeholder to demo the snippet generation.
        /// </summary>
        public async Task RunSamplesAsync()
        {
            try
            {
                var tsiId = new TimeSeriesId("17", "1", "1");
                var options = new QueryEventsRequestOptions
                {
                    MaximumNumberOfEvents = 20000,
                };
                AsyncPageable<QueryResultPage> pageable = client.QueryEventsAsync(
                    tsiId,
                    new DateTimeOffset(2020, 3, 8, 0, 0, 0, TimeSpan.Zero),
                    new DateTimeOffset(2022, 3, 10, 0, 0, 0, TimeSpan.Zero),
                    options);

                await foreach (var item in pageable)
                {
                    var ts = item.Timestamps;
                    var props = item.Properties;
                }


            }
            catch (Exception ex)
            {
                FatalError($"Failed to create models due to:\n{ex}");
            }
        }
    }
}

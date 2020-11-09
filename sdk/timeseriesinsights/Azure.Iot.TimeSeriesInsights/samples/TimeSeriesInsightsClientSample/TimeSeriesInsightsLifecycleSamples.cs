// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

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
        /// Describe the sample here.
        /// </summary>
        public Task RunSamplesAsync()
        {
            return Task.CompletedTask;
        }
    }
}

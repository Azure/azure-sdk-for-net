// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
                #region Snippet:TimeSeriesInsightsGetModelSettings
                
                // Get the model settings for the time series insights environment
                Response<Models.ModelSettingsResponse> response = await client.GetAsync().ConfigureAwait(false);
                Console.WriteLine($"Retrieved model {response.Value.ModelSettings.Name}.");
                
                #endregion Snippet:TimeSeriesInsightsGetModelSettings
            }
            catch (Exception ex)
            {
                FatalError($"Failed to create models due to:\n{ex}");
            }
        }
    }
}

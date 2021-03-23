// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using static Azure.IoT.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.IoT.TimeSeriesInsights.Samples
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
                Response<TimeSeriesModelSettings> currentSettings = await client.GetModelSettingsAsync();
                Console.WriteLine($"Retrieved model with default type id {currentSettings.Value.DefaultTypeId} " +
                    $"model name {currentSettings.Value.Name}.");

                foreach (TimeSeriesIdProperty tsiId in currentSettings.Value.TimeSeriesIdProperties)
                {
                    Console.WriteLine($"Time series Id name: '{tsiId.Name}', Type: '{tsiId.Type}'.");
                }

                #endregion Snippet:TimeSeriesInsightsGetModelSettings

                #region Snippet:TimeSeriesInsightsUpdateModelSettingsModelName

                string name = "sampleModel";
                Response<TimeSeriesModelSettings> updatedSettings = await client.UpdateModelSettingsNameAsync(name);
                Console.WriteLine($"Updated model name to {updatedSettings.Value.Name} ");

                #endregion Snippet:TimeSeriesInsightsUpdateModelSettingsModelName

            }
            catch (Exception ex)
            {
                FatalError($"Failed to create models due to:\n{ex}");
            }
        }
    }
}

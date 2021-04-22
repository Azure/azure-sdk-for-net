// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Azure.IoT.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    internal class ModelSettingsSamples
    {
        /// <summary>
        /// This sample demonstrates getting Time Series model settings, updating a model and changing the default type Id for a model.
        /// </summary>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client)
        {
            PrintHeader("TIME SERIES INSIGHTS MODEL SETTINGS SAMPLE");

            #region Snippet:TimeSeriesInsightsSampleGetModelSettings
            Response<TimeSeriesModelSettings> getModelSettingsResponse = await client.ModelSettings.GetAsync();
            Console.WriteLine($"Retrieved Time Series Insights model settings:\n{JsonSerializer.Serialize(getModelSettingsResponse.Value)}");
            #endregion

            // Store the default type Id so it can be used during clean up
            string defaultTypeId = getModelSettingsResponse.Value.DefaultTypeId;

            #region Snippet:TimeSeriesInsightsSampleUpdateModelSettingsName
            Response<TimeSeriesModelSettings> updateModelSettingsNameResponse = await client.ModelSettings.UpdateNameAsync("NewModelSettingsName");
            Console.WriteLine($"Updated Time Series Insights model settings name:\n" +
                $"{JsonSerializer.Serialize(updateModelSettingsNameResponse.Value)}");
            #endregion

            // Create a Time Series type
            var aggregateVariable = new AggregateVariable(new TimeSeriesExpression("count()"));
            var variables = new Dictionary<string, TimeSeriesVariable>
            {
                { "aggregateVariableName", aggregateVariable },
            };
            var type = new TimeSeriesType("tsiTypeName", variables);
            var timeSeriesTypes = new List<TimeSeriesType> { type };

            Response<TimeSeriesTypeOperationResult[]> createTsiTypeResponse = await client.Types.CreateOrReplaceAsync(timeSeriesTypes);

            // Ensure no error was reported as part of the response
            if (createTsiTypeResponse.Value[0].Error != null)
            {
                Console.WriteLine("Failed to create a Time Series Type.");
            }

            // Store the Time Series type id to use it for updating default type in model settings
            string tsiTypeId = createTsiTypeResponse.Value[0].TimeSeriesType.Id;

            #region Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType
            Response<TimeSeriesModelSettings> updateDefaultTypeIdResponse = await client.ModelSettings.UpdateDefaultTypeIdAsync(tsiTypeId);
            Console.WriteLine($"Updated Time Series Insights model settings default type Id:\n" +
                $"{JsonSerializer.Serialize(updateDefaultTypeIdResponse.Value)}");
            #endregion

            // Clean up
            try
            {
                // Revert back to the original default type Id
                await client.ModelSettings.UpdateDefaultTypeIdAsync(defaultTypeId);

                // Delete the type created
                await client.Types.DeleteByIdAsync(new List<string> { tsiTypeId });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed at one of the clean up steps: {ex.Message}");
            }
        }
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// This sample demonstrates getting Time Series model settings, updating model settings and changing the default type Id for a model.
        /// </summary>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client)
        {
            PrintHeader("TIME SERIES INSIGHTS MODEL SETTINGS SAMPLE");

            #region Snippet:TimeSeriesInsightsSampleGetModelSettings
            Response<TimeSeriesModelSettings> getModelSettingsResponse = await client.ModelSettings.GetAsync();
            Console.WriteLine($"Retrieved Time Series Insights model settings:\n{JsonSerializer.Serialize(getModelSettingsResponse.Value)}");
            #endregion Snippet:TimeSeriesInsightsSampleGetModelSettings

            // Store the default type Id so it can be used during clean up
            string defaultTypeId = getModelSettingsResponse.Value.DefaultTypeId;

            #region Snippet:TimeSeriesInsightsSampleUpdateModelSettingsName
            Response<TimeSeriesModelSettings> updateModelSettingsNameResponse = await client.ModelSettings.UpdateNameAsync("NewModelSettingsName");
            Console.WriteLine($"Updated Time Series Insights model settings name:\n" +
                $"{JsonSerializer.Serialize(updateModelSettingsNameResponse.Value)}");
            #endregion Snippet:TimeSeriesInsightsSampleUpdateModelSettingsName

            // For every Time Series Insights environment, there is a default type that any newly created Time Series instance will be associated with.
            // You can change the default type for a TSI environment by creating a new type and calling the API to update the default type Id.

            // Create a Time Series type.
            var aggregateVariable = new AggregateVariable(new TimeSeriesExpression("count()"));
            var variables = new Dictionary<string, TimeSeriesVariable>
            {
                { "aggregateVariableName", aggregateVariable },
            };
            var type = new TimeSeriesType("tsiTypeName", variables);
            var timeSeriesTypes = new List<TimeSeriesType> { type };
            string tsiTypeId = null;
            Response<TimeSeriesTypeOperationResult[]> createTsiTypeResponse = await client.Types.CreateOrReplaceAsync(timeSeriesTypes);

            // Ensure no error was reported as part of the response
            if (createTsiTypeResponse.Value[0].Error == null)
            {
                // Store the Time Series type id to use it for updating default type in model settings
                tsiTypeId = createTsiTypeResponse.Value[0].TimeSeriesType.Id;

                #region Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType
                Response<TimeSeriesModelSettings> updateDefaultTypeIdResponse = await client.ModelSettings.UpdateDefaultTypeIdAsync(tsiTypeId);
                Console.WriteLine($"Updated Time Series Insights model settings default type Id:\n" +
                    $"{JsonSerializer.Serialize(updateDefaultTypeIdResponse.Value)}");
                #endregion Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType
            }
            // Clean up
            try
            {
                // Revert back to the original default type Id
                await client.ModelSettings.UpdateDefaultTypeIdAsync(defaultTypeId);

                // Delete the type created
                if (tsiTypeId != null)
                {
                    await client.Types.DeleteByIdAsync(new List<string> { tsiTypeId });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed at one of the clean up steps: {ex.Message}");
            }
        }
    }
}

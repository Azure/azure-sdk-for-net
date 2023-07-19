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
        /// This sample demonstrates getting Time Series model settings, updating model settings and changing the default type Id for a model.
        /// </summary>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client)
        {
            PrintHeader("TIME SERIES INSIGHTS MODEL SETTINGS SAMPLE");

            #region Snippet:TimeSeriesInsightsSampleGetModelSettings
            TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
            TimeSeriesInsightsTypes typesClient = client.GetTypesClient();
            Response<TimeSeriesModelSettings> getModelSettingsResponse = await modelSettingsClient.GetAsync();
            Console.WriteLine($"Retrieved Time Series Insights model settings \nname : '{getModelSettingsResponse.Value.Name}', " +
                $"default type Id: {getModelSettingsResponse.Value.DefaultTypeId}'");
            IReadOnlyList<TimeSeriesIdProperty> timeSeriesIdProperties = getModelSettingsResponse.Value.TimeSeriesIdProperties;
            foreach (TimeSeriesIdProperty property in timeSeriesIdProperties)
            {
                Console.WriteLine($"Time Series Id property name : '{property.Name}', type : '{property.PropertyType}'.");
            }
            #endregion Snippet:TimeSeriesInsightsSampleGetModelSettings

            // Store the default type Id so it can be used during clean up
            string defaultTypeId = getModelSettingsResponse.Value.DefaultTypeId;

            #region Snippet:TimeSeriesInsightsSampleUpdateModelSettingsName
            Response<TimeSeriesModelSettings> updateModelSettingsNameResponse = await modelSettingsClient.UpdateNameAsync("NewModelSettingsName");
            Console.WriteLine($"Updated Time Series Insights model settings name: " +
                $"{updateModelSettingsNameResponse.Value.Name}");
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
            Response<TimeSeriesTypeOperationResult[]> createTsiTypeResponse = await typesClient
                .CreateOrReplaceAsync(timeSeriesTypes);

            // Ensure no error was reported as part of the response
            if (createTsiTypeResponse.Value[0].Error == null)
            {
                // Store the Time Series type id to use it for updating default type in model settings
                tsiTypeId = createTsiTypeResponse.Value[0].TimeSeriesType.Id;

                #region Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType
                Response<TimeSeriesModelSettings> updateDefaultTypeIdResponse = await modelSettingsClient
                    .UpdateDefaultTypeIdAsync(tsiTypeId);
                Console.WriteLine($"Updated Time Series Insights model settings default type Id: " +
                    $"{updateDefaultTypeIdResponse.Value.Name}");
                #endregion Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType
            }
            // Clean up
            try
            {
                // Revert back to the original default type Id
                await modelSettingsClient
                    .UpdateDefaultTypeIdAsync(defaultTypeId);

                // Delete the type created
                if (tsiTypeId != null)
                {
                    await typesClient
                        .DeleteByIdAsync(new List<string> { tsiTypeId });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed at one of the clean up steps: {ex.Message}");
            }
        }
    }
}

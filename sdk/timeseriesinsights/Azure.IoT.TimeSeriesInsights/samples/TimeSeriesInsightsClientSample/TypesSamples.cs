// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Azure.IoT.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    internal class TypesSamples
    {
        /// <summary>
        /// This sample demonstrates usage of Time Series Insights types APIs.
        /// </summary>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client)
        {
            // For the purpose of keeping code snippets readable to the user, hardcoded string literals are used in place of assigned variables, eg Ids.
            // Despite not being a good code practice, this prevents code snippets from being out of context for the user when making API calls that accept Ids as parameters.

            PrintHeader("TIME SERIES INSIGHTS TYPES SAMPLE");

            #region Snippet:TimeSeriesInsightsSampleCreateType
            TimeSeriesInsightsTypes typesClient = client.GetTypesClient();

            // Create a type with an aggregate variable
            var timeSeriesTypes = new List<TimeSeriesType>();

            var countExpression = new TimeSeriesExpression("count()");
            var aggregateVariable = new AggregateVariable(countExpression);
            var variables = new Dictionary<string, TimeSeriesVariable>();
            variables.Add("aggregateVariable", aggregateVariable);

            timeSeriesTypes.Add(new TimeSeriesType("Type1", variables) { Id = "Type1Id" });
            timeSeriesTypes.Add(new TimeSeriesType("Type2", variables) { Id = "Type2Id" });

            Response<TimeSeriesTypeOperationResult[]> createTypesResult = await typesClient
                .CreateOrReplaceAsync(timeSeriesTypes);

            // The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
            // If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < createTypesResult.Value.Length; i++)
            {
                if (createTypesResult.Value[i].Error == null)
                {
                    Console.WriteLine($"Created Time Series type successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to create a Time Series Insights type: {createTypesResult.Value[i].Error.Message}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleCreateType

            #region Snippet:TimeSeriesInsightsSampleGetTypeById
            // Code snippet below shows getting a default Type using Id
            // The default type Id can be obtained programmatically by using the ModelSettings client.

            TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
            TimeSeriesModelSettings modelSettings = await modelSettingsClient.GetAsync();
            Response<TimeSeriesTypeOperationResult[]> getTypeByIdResults = await typesClient
                .GetByIdAsync(new string[] { modelSettings.DefaultTypeId });

            // The response of calling the API contains a list of type or error objects corresponding by position to the input parameter array in the request.
            // If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < getTypeByIdResults.Value.Length; i++)
            {
                if (getTypeByIdResults.Value[i].Error == null)
                {
                    Console.WriteLine($"Retrieved Time Series type with Id: '{getTypeByIdResults.Value[i].TimeSeriesType.Id}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve a Time Series type due to '{getTypeByIdResults.Value[i].Error.Message}'.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleGetTypeById

            #region Snippet:TimeSeriesInsightsSampleReplaceType
            // Update variables with adding a new variable
            foreach (TimeSeriesType type in timeSeriesTypes)
            {
                type.Description = "Description";
            }

            Response<TimeSeriesTypeOperationResult[]> updateTypesResult = await typesClient
                .CreateOrReplaceAsync(timeSeriesTypes);

            // The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
            // If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < updateTypesResult.Value.Length; i++)
            {
                if (updateTypesResult.Value[i].Error == null)
                {
                    Console.WriteLine($"Updated Time Series type successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to update a Time Series Insights type due to: {updateTypesResult.Value[i].Error.Message}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleReplaceType

            #region Snippet:TimeSeriesInsightsSampleGetAllTypes
            // Get all Time Series types in the environment
            AsyncPageable<TimeSeriesType> getAllTypesResponse = typesClient.GetTypesAsync();

            await foreach (TimeSeriesType tsiType in getAllTypesResponse)
            {
                Console.WriteLine($"Retrieved Time Series Insights type with Id: '{tsiType?.Id}' and Name: '{tsiType?.Name}'");
            }
            #endregion Snippet:TimeSeriesInsightsSampleGetAllTypes

            // Clean up
            try
            {
                #region Snippet:TimeSeriesInsightsSampleDeleteTypeById

                // Delete Time Series types with Ids

                var typesIdsToDelete = new List<string> { "Type1Id", " Type2Id" };
                Response<TimeSeriesOperationError[]> deleteTypesResponse = await typesClient
                    .DeleteByIdAsync(typesIdsToDelete);

                // The response of calling the API contains a list of error objects corresponding by position to the input parameter
                // array in the request. If the error object is set to null, this means the operation was a success.
                foreach (var result in deleteTypesResponse.Value)
                {
                    if (result != null)
                    {
                        Console.WriteLine($"Failed to delete a Time Series Insights type: {result.Message}.");
                    }
                    else
                    {
                        Console.WriteLine($"Deleted a Time Series Insights type successfully.");
                    }
                }
                #endregion Snippet:TimeSeriesInsightsSampleDeleteTypeById
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete Time Series Insights type: {ex.Message}");
            }
        }
    }
}

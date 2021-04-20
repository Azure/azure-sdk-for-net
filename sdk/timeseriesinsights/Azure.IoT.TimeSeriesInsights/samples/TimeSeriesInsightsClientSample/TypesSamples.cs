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
            PrintHeader("TIME SERIES INSIGHTS TYPES SAMPLE");

            // Get model settings
            TimeSeriesModelSettings modelSettings = await client.ModelSettings.GetAsync().ConfigureAwait(false);

            #region Snippet:TimeSeriesInsightsSampleCreateType
            // Create an aggregate type
            var timeSeriesTypes = new List<TimeSeriesType>();

            var countExpression = new TimeSeriesExpression("count()");
            var aggregateVariable = new AggregateVariable(countExpression);
            var variables = new Dictionary<string, TimeSeriesVariable>();
            var variableName = "aggregateVariable";
            variables.Add(variableName, aggregateVariable);

            var timeSeriesTypesProperties = new Dictionary<string, string>
            {
                { "Type1", Guid.NewGuid().ToString()},
                { "Type2", Guid.NewGuid().ToString()}
            };

            foreach (KeyValuePair<string, string> property in timeSeriesTypesProperties)
            {
                var type = new TimeSeriesType(property.Key, variables)
                {
                    Id = property.Value
                };
                timeSeriesTypes.Add(type);
            }

            Response<TimeSeriesTypeOperationResult[]> createTypesResult = await client
                .Types
                .CreateOrReplaceAsync(timeSeriesTypes)
                .ConfigureAwait(false);

            // Check if the result error array does contain any object that is set
            foreach (var result in createTypesResult.Value)
            {
                if (result.Error != null)
                {
                    Console.WriteLine($"Failed to create a Time Series Insights type: {result.Error.Message}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleCreateType

            #region Snippet:TimeSeriesInsightsSampleGetTypeById
            // Code snippet below shows getting a default Type using Id
            Response<TimeSeriesTypeOperationResult[]> getTypeByIdResults = await client
                .Types
                .GetByIdAsync(new string[] { modelSettings.DefaultTypeId })
                .ConfigureAwait(false);

            TimeSeriesTypeOperationResult getTypeByIdResult = getTypeByIdResults.Value[0];

            if (getTypeByIdResult.TimeSeriesType != null)
            {
                Console.WriteLine($"Retrieved Time Series Insights type with Id '{getTypeByIdResult.TimeSeriesType.Id}' and name '{getTypeByIdResult.TimeSeriesType.Name}'.");
            }
            else if (getTypeByIdResult.Error != null)
            {
                Console.WriteLine($"Failed to retrieve a Time Series Insights type with Id '{getTypeByIdResult.Error.Message}'.");
            }
            #endregion Snippet:TimeSeriesInsightsSampleGetTypeById

            #region Snippet:TimeSeriesInsightsSampleReplaceType
            // Update variables with adding a new variable
            foreach (TimeSeriesType type in timeSeriesTypes)
            {
                type.Description = "Description";
            }

            Response<TimeSeriesTypeOperationResult[]> updateTypesResult = await client
                .Types
                .CreateOrReplaceAsync(timeSeriesTypes)
                .ConfigureAwait(false);

            // Check if the result error array does contain any object that is set
            foreach (var result in createTypesResult.Value)
            {
                if (result.Error != null)
                {
                    Console.WriteLine($"Failed to replace a Time Series Insights type: {result.Error.Message}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleReplaceType

            #region Snippet:TimeSeriesInsightsSampleGetAllTypes
            // Get all Time Series types in the environment
            AsyncPageable<TimeSeriesType> getAllTypesResponse = client.Types.GetTypesAsync();

            await foreach (TimeSeriesType tsiType in getAllTypesResponse)
            {
                Console.WriteLine($"Retrieved Time Series Insights type with Id: {tsiType?.Id} and Name: {tsiType?.Name}");
            }
            #endregion Snippet:TimeSeriesInsightsSampleGetAllTypes

            // Clean up
            try
            {
                #region Snippet:TimeSeriesInsightsSampleDeleteTypeById
                Response<TimeSeriesOperationError[]> deleteTypesResponse = await client
                    .Types
                    .DeleteByIdAsync(timeSeriesTypesProperties.Values)
                    .ConfigureAwait(false);

                // The response of calling the API contains a list of error objects corresponding by position to the input parameter
                // array in the request. If the error object is set to null, this means the operation was a success.
                foreach (var result in deleteTypesResponse.Value)
                {
                    if (result != null)
                    {
                        Console.WriteLine($"Failed to delete a Time Series Insights type: {result.Message}.");
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

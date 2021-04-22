// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Azure.IoT.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    internal class InstancesSamples
    {
        /// <summary>
        /// Creates a Time Series Insights instance
        /// Gets all instances for the environment
        /// Gets a specific instance by Id
        /// Replaces an instance
        /// Deletes an instance.
        /// </summary>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client)
        {
            PrintHeader("TIME SERIES INSIGHTS INSTANCES SAMPLE");

            // Figure out how many keys make up the Time Series Id
            TimeSeriesModelSettings modelSettings = await client.ModelSettings.GetAsync().ConfigureAwait(false);

            TimeSeriesId instanceId = modelSettings.TimeSeriesIdProperties.Count switch
            {
                1 => new TimeSeriesId("key1"),
                2 => new TimeSeriesId("key1", "key2"),
                3 => new TimeSeriesId("key1", "key2", "key3"),
                _ => throw new Exception($"Invalid number of Time Series Insights Id properties."),
            };

            string defaultTypeId = modelSettings.DefaultTypeId;

            #region Snippet:TimeSeriesInsightsSampleCreateInstance

            // Create a Time Series Instance object with the default Time Series Insights type Id.
            // The default type Id can be obtained programmatically by using the ModelSettings client.
            var instance = new TimeSeriesInstance(instanceId, defaultTypeId)
            {
                Name = "instance1",
            };

            var tsiInstancesToCreate = new List<TimeSeriesInstance>
            {
                instance,
            };

            Response<TimeSeriesOperationError[]> createInstanceErrors = await client
                .Instances
                .CreateOrReplaceAsync(tsiInstancesToCreate)
                .ConfigureAwait(false);

            // The response of calling the API contains a list of error objects corresponding by position to the input parameter
            // array in the request. If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < createInstanceErrors.Value.Length; i++)
            {
                TimeSeriesId tsiId = tsiInstancesToCreate[i].TimeSeriesId;

                if (createInstanceErrors.Value[i] == null)
                {
                    Console.WriteLine($"Created Time Series Insights instance with Id '{tsiId}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to create a Time Series Insights instance with Id '{tsiId}'.");
                }
            }

            #endregion Snippet:TimeSeriesInsightsSampleCreateInstance

            #region Snippet:TimeSeriesInsightsGetAllInstances

            // Get all instances for the Time Series Insigths environment
            AsyncPageable<TimeSeriesInstance> tsiInstances = client.Instances.GetAsync();
            await foreach (TimeSeriesInstance tsiInstance in tsiInstances)
            {
                Console.WriteLine($"Retrieved Time Series Insights instance with Id '{tsiInstance.TimeSeriesId}' and name '{tsiInstance.Name}'.");
            }

            #endregion Snippet:TimeSeriesInsightsGetAllInstances

            #region Snippet:TimeSeriesInsightsReplaceInstance

            // Get Time Series Insights instances by Id
            var instanceIdsToGet = new List<TimeSeriesId>
            {
                instanceId,
            };

            Response<InstancesOperationResult[]> getInstancesByIdResult = await client.Instances.GetAsync(instanceIdsToGet).ConfigureAwait(false);

            TimeSeriesInstance instanceResult = getInstancesByIdResult.Value[0].Instance;
            Console.WriteLine($"Retrieved Time Series Insights instance with Id '{instanceResult.TimeSeriesId}' and name '{instanceResult.Name}'.");

            // Now let's replace the instance with an updated name
            instanceResult.Name = "newInstanceName";

            var instancesToReplace = new List<TimeSeriesInstance>
            {
                instanceResult,
            };

            Response<InstancesOperationResult[]> replaceInstancesResult = await client.Instances.ReplaceAsync(instancesToReplace).ConfigureAwait(false);

            // The response of calling the API contains a list of error objects corresponding by position to the input parameter
            // array in the request. If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < replaceInstancesResult.Value.Length; i++)
            {
                TimeSeriesId tsiId = instancesToReplace[i].TimeSeriesId;

                TimeSeriesOperationError currentError = replaceInstancesResult.Value[i].Error;

                if (currentError != null)
                {
                    Console.WriteLine($"Failed to replace Time Series Insights instance with Id '{tsiId}'. Error Message: '{currentError.Message}'.");
                }
                else
                {
                    Console.WriteLine($"Replaced Time Series Insights instance with Id '{tsiId}'.");
                }
            }

            #endregion Snippet:TimeSeriesInsightsReplaceInstance

            #region Snippet:TimeSeriesInsightsGetnstancesById

            // Get Time Series Insights instances by Id
            var timeSeriesIds = new List<TimeSeriesId>
            {
                instanceId,
            };

            Response<InstancesOperationResult[]> getByIdsResult = await client.Instances.GetAsync(timeSeriesIds).ConfigureAwait(false);

            /// The response of calling the API contains a list of instance or error objects corresponding by position to the array in the request.
            /// Instance object is set when operation is successful and error object is set when operation is unsuccessful.
            for (int i = 0; i < getByIdsResult.Value.Length; i++)
            {
                InstancesOperationResult currentOperationResult = getByIdsResult.Value[i];

                if (currentOperationResult.Instance != null)
                {
                    Console.WriteLine($"Retrieved Time Series Insights instance with Id '{currentOperationResult.Instance.TimeSeriesId}' and name '{currentOperationResult.Instance.Name}'.");
                }
                else if (currentOperationResult.Error != null)
                {
                    Console.WriteLine($"Failed to retrieve a Time Series Insights instance with Id '{timeSeriesIds[i]}'. Error message: '{currentOperationResult.Error.Message}'.");
                }
            }

            #endregion Snippet:TimeSeriesInsightsGetnstancesById

            // Clean up
            try
            {
                #region Snippet:TimeSeriesInsightsSampleDeleteInstanceById

                var instancesToDelete = new List<TimeSeriesId>
                {
                    instanceId,
                };

                Response<TimeSeriesOperationError[]> deleteInstanceErrors = await client
                    .Instances
                    .DeleteAsync(instancesToDelete)
                    .ConfigureAwait(false);

                // The response of calling the API contains a list of error objects corresponding by position to the input parameter
                // array in the request. If the error object is set to null, this means the operation was a success.
                for (int i = 0; i < deleteInstanceErrors.Value.Length; i++)
                {
                    TimeSeriesId tsiId = instancesToDelete[i];

                    if (deleteInstanceErrors.Value[i] == null)
                    {
                        Console.WriteLine($"Deleted Time Series Insights instance with Id '{tsiId}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to delete a Time Series Insights instance with Id '{tsiId}'. Error Message: '{deleteInstanceErrors.Value[i].Message}'");
                    }
                }

                #endregion Snippet:TimeSeriesInsightsSampleDeleteInstanceById
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete Time Series Insights instance: {ex.Message}");
            }
        }
    }
}

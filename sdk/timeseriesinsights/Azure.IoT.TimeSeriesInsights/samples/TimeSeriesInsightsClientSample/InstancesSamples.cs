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

            // Figure out what keys make up the Time Series Id
            TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
            TimeSeriesInsightsInstances instancesClient = client.GetInstancesClient();
            TimeSeriesModelSettings modelSettings = await modelSettingsClient.GetAsync();
            TimeSeriesId tsId = TimeSeriesIdHelper.CreateTimeSeriesId(modelSettings);
            string defaultTypeId = modelSettings.DefaultTypeId;

            #region Snippet:TimeSeriesInsightsSampleCreateInstance

            // Create a Time Series Instance object with the default Time Series Insights type Id.
            // The default type Id can be obtained programmatically by using the ModelSettings client.
            // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
            var instance = new TimeSeriesInstance(tsId, defaultTypeId)
            {
                Name = "instance1",
            };

            var tsiInstancesToCreate = new List<TimeSeriesInstance>
            {
                instance,
            };

            Response<TimeSeriesOperationError[]> createInstanceErrors = await instancesClient
                .CreateOrReplaceAsync(tsiInstancesToCreate);

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
                    Console.WriteLine($"Failed to create a Time Series Insights instance with Id '{tsiId}', " +
                        $"Error Message: '{createInstanceErrors.Value[i].Message}, " +
                        $"Error code: '{createInstanceErrors.Value[i].Code}'.");
                }
            }

            #endregion Snippet:TimeSeriesInsightsSampleCreateInstance

            #region Snippet:TimeSeriesInsightsGetAllInstances

            // Get all instances for the Time Series Insights environment
            AsyncPageable<TimeSeriesInstance> tsiInstances = instancesClient.GetAsync();
            await foreach (TimeSeriesInstance tsiInstance in tsiInstances)
            {
                Console.WriteLine($"Retrieved Time Series Insights instance with Id '{tsiInstance.TimeSeriesId}' and name '{tsiInstance.Name}'.");
            }

            #endregion Snippet:TimeSeriesInsightsGetAllInstances

            #region Snippet:TimeSeriesInsightsReplaceInstance

            // Get Time Series Insights instances by Id
            // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
            var instanceIdsToGet = new List<TimeSeriesId>
            {
                tsId,
            };

            Response<InstancesOperationResult[]> getInstancesByIdResult = await instancesClient.GetByIdAsync(instanceIdsToGet);

            TimeSeriesInstance instanceResult = getInstancesByIdResult.Value[0].Instance;
            Console.WriteLine($"Retrieved Time Series Insights instance with Id '{instanceResult.TimeSeriesId}' and name '{instanceResult.Name}'.");

            // Now let's replace the instance with an updated name
            instanceResult.Name = "newInstanceName";

            var instancesToReplace = new List<TimeSeriesInstance>
            {
                instanceResult,
            };

            Response<InstancesOperationResult[]> replaceInstancesResult = await instancesClient.ReplaceAsync(instancesToReplace);

            // The response of calling the API contains a list of error objects corresponding by position to the input parameter.
            // array in the request. If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < replaceInstancesResult.Value.Length; i++)
            {
                TimeSeriesId tsiId = instancesToReplace[i].TimeSeriesId;

                TimeSeriesOperationError currentError = replaceInstancesResult.Value[i].Error;

                if (currentError != null)
                {
                    Console.WriteLine($"Failed to replace Time Series Insights instance with Id '{tsiId}'," +
                        $" Error Message: '{currentError.Message}', Error code: '{currentError.Code}'.");
                }
                else
                {
                    Console.WriteLine($"Replaced Time Series Insights instance with Id '{tsiId}'.");
                }
            }

            #endregion Snippet:TimeSeriesInsightsReplaceInstance

            #region Snippet:TimeSeriesInsightsGetnstancesById

            // Get Time Series Insights instances by Id
            // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
            var timeSeriesIds = new List<TimeSeriesId>
            {
                tsId,
            };

            Response<InstancesOperationResult[]> getByIdsResult = await instancesClient.GetByIdAsync(timeSeriesIds);

            // The response of calling the API contains a list of instance or error objects corresponding by position to the array in the request.
            // Instance object is set when operation is successful and error object is set when operation is unsuccessful.
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

                // tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
                var instancesToDelete = new List<TimeSeriesId>
                {
                    tsId,
                };

                Response<TimeSeriesOperationError[]> deleteInstanceErrors = await instancesClient
                    .DeleteByIdAsync(instancesToDelete);

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

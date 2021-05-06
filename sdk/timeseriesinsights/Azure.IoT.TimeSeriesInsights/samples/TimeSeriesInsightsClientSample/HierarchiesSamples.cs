﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Azure.IoT.TimeSeriesInsights.Samples.SampleLogger;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    internal class HierarchiesSamples
    {
        /// <summary>
        /// This sample demonstrates usage of Time Series Insights hierarchy APIs.
        /// </summary>
        public async Task RunSamplesAsync(TimeSeriesInsightsClient client)
        {
            // For the purpose of keeping code snippets readable to the user, hardcoded string literals are used in place of assigned variables, eg Ids.
            // Despite not being a good code practice, this prevents code snippets from being out of context for the user when making API calls that accept Ids as parameters.

            PrintHeader("TIME SERIES INSIGHTS HIERARCHIES SAMPLE");

            #region Snippet:TimeSeriesInsightsSampleCreateHierarchies
            var tsiHierarchyName = "sampleHierarchy";
            var tsiInstanceField1 = "hierarchyLevel1";
            var hierarchySource = new TimeSeriesHierarchySource();
            hierarchySource.InstanceFieldNames.Add(tsiInstanceField1);

            var tsiHierarchy = new TimeSeriesHierarchy(tsiHierarchyName, hierarchySource);
            tsiHierarchy.Id = "sampleHierarchyId";

            var timeSeriesHierarchies = new List<TimeSeriesHierarchy>
            {
                tsiHierarchy
            };

            // Create Time Series hierarchies
            Response<TimeSeriesHierarchyOperationResult[]> createHierarchiesResult = await client
                .Hierarchies
                .CreateOrReplaceAsync(timeSeriesHierarchies)
                .ConfigureAwait(false);

            // The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
            // If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < createHierarchiesResult.Value.Length; i++)
            {
                if (createHierarchiesResult.Value[i].Error == null)
                {
                    Console.WriteLine($"Created Time Series hierarchy successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to create a Time Series hierarchy: {createHierarchiesResult.Value[i].Error.Message}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleCreateHierarchies

            #region Snippet:TimeSeriesInsightsSampleGetAllHierarchies
            // Get all Time Series hierarchies in the environment
            AsyncPageable<TimeSeriesHierarchy> getAllHierarchies = client.Hierarchies.GetAsync();
            await foreach (TimeSeriesHierarchy hierarchy in getAllHierarchies)
            {
                Console.WriteLine($"Retrieved Time Series Insights hierarchy with Id: '{hierarchy.Id}' and Name: '{hierarchy.Name}'.");
            }
            #endregion Snippet:TimeSeriesInsightsSampleGetAllHierarchies

            #region Snippet:TimeSeriesInsightsSampleReplaceHierarchies
            // Update hierarchies with adding a new instance field
            var tsiInstanceField2 = "hierarchyLevel2";
            foreach (TimeSeriesHierarchy hierarchy in timeSeriesHierarchies)
            {
                hierarchy.Source.InstanceFieldNames.Add(tsiInstanceField2);
            }

            Response<TimeSeriesHierarchyOperationResult[]> updateHierarchiesResult = await client
                    .Hierarchies
                    .CreateOrReplaceAsync(timeSeriesHierarchies)
                    .ConfigureAwait(false);

            // The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
            // If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < updateHierarchiesResult.Value.Length; i++)
            {
                if (updateHierarchiesResult.Value[i].Error == null)
                {
                    Console.WriteLine($"Updated Time Series hierarchy successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to update a Time Series Insights hierarchy due to: {updateHierarchiesResult.Value[i].Error.Message}.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleReplaceHierarchies

            #region Snippet:TimeSeriesInsightsSampleGetHierarchiesById
            var tsiHierarchyIds = new List<string>
            {
                "sampleHierarchyId"
            };

            Response<TimeSeriesHierarchyOperationResult[]> getHierarchiesByIdsResult = await client
                        .Hierarchies
                        .GetByIdAsync(tsiHierarchyIds)
                        .ConfigureAwait(false);

            // The response of calling the API contains a list of hieararchy or error objects corresponding by position to the input parameter array in the request.
            // If the error object is set to null, this means the operation was a success.
            for (int i = 0; i < getHierarchiesByIdsResult.Value.Length; i++)
            {
                if (getHierarchiesByIdsResult.Value[i].Error == null)
                {
                    Console.WriteLine($"Retrieved Time Series hieararchy with Id: '{getHierarchiesByIdsResult.Value[i].Hierarchy.Id}'.");
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve a Time Series hieararchy due to '{getHierarchiesByIdsResult.Value[i].Error.Message}'.");
                }
            }
            #endregion Snippet:TimeSeriesInsightsSampleGetHierarchiesById

            // Clean up
            try
            {
                #region Snippet:TimeSeriesInsightsSampleDeleteHierarchiesById
                // Delete Time Series hierarchies with Ids
                var tsiHierarchyIdsToDelete = new List<string>
                {
                    "sampleHiearchyId"
                };

                Response<TimeSeriesOperationError[]> deleteHierarchiesResponse = await client
                        .Hierarchies
                        .DeleteByIdAsync(tsiHierarchyIdsToDelete)
                        .ConfigureAwait(false);

                // The response of calling the API contains a list of error objects corresponding by position to the input parameter
                // array in the request. If the error object is set to null, this means the operation was a success.
                foreach (TimeSeriesOperationError result in deleteHierarchiesResponse.Value)
                {
                    if (result != null)
                    {
                        Console.WriteLine($"Failed to delete a Time Series Insights hierarchy: {result.Message}.");
                    }
                    else
                    {
                        Console.WriteLine($"Deleted a Time Series Insights hierarchy successfully.");
                    }
                }
                #endregion Snippet:TimeSeriesInsightsSampleDeleteHierarchiesById
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete Time Series Insights hierarchy: {ex.Message}");
            }
        }
    }
}

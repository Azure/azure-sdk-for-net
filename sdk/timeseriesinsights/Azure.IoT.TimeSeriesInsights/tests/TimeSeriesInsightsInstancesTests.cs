// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsInstancesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(20);

        private const int MaxNumberOfRetries = 10;

        public TimeSeriesInsightsInstancesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsInstances_Lifecycle()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();
            int numOfIdProperties = 3;
            int numOfInstancesToSetup = 2;
            var timeSeriesInstances = new List<TimeSeriesInstance>();
            string defaultTypeId = await getDefaultTypeIdAsync(client).ConfigureAwait(false);

            for (int i = 0; i < numOfInstancesToSetup; i++)
            {
                TimeSeriesId id = await GetUniqueTimeSeriesInstanceIdAsync(client, numOfIdProperties)
                    .ConfigureAwait(false);

                var instance = new TimeSeriesInstance(id, defaultTypeId)
                {
                    Name = Recording.GenerateAlphaNumericId("instance"),
                };
                timeSeriesInstances.Add(instance);
            }

            IEnumerable<TimeSeriesId> timeSeriesInstancesIds = timeSeriesInstances.Select((instance) => instance.TimeSeriesId);

            // Act and assert
            try
            {
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>(async () =>
                {
                    // Create TSI instances
                    Response<TimeSeriesOperationError[]> createInstancesResult = await client
                    .CreateOrReplaceTimeSeriesInstancesAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                    // Assert that the result error array does not contain any object that is set
                    createInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult == null);

                    // Get the created instances by Ids
                    Response<InstancesOperationResult[]> getInstancesByIdsResult = await client
                        .GetInstancesAsync(timeSeriesInstancesIds)
                        .ConfigureAwait(false);

                    getInstancesByIdsResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                    foreach (InstancesOperationResult instanceResult in getInstancesByIdsResult.Value)
                    {
                        instanceResult.Instance.Should().NotBeNull();
                        instanceResult.Error.Should().BeNull();
                        instanceResult.Instance.TimeSeriesId.ToArray().Length.Should().Be(numOfIdProperties);
                        instanceResult.Instance.TypeId.Should().Be(defaultTypeId);
                        instanceResult.Instance.HierarchyIds.Count.Should().Be(0);
                        instanceResult.Instance.InstanceFields.Count.Should().Be(0);
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Update the instances by adding descriptions to them
                timeSeriesInstances.ForEach((timeSeriesInstance) =>
                    timeSeriesInstance.Description = "Description");

                Response<InstancesOperationResult[]> replaceInstancesResult = await client
                    .ReplaceTimeSeriesInstancesAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                replaceInstancesResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                replaceInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>(async () =>
                {
                    // Get instances by name
                    Response<InstancesOperationResult[]> getInstancesByNameResult = await client
                        .GetInstancesAsync(timeSeriesInstances.Select((instance) => instance.Name))
                        .ConfigureAwait(false);

                    getInstancesByNameResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                    foreach (InstancesOperationResult instanceResult in getInstancesByNameResult.Value)
                    {
                        instanceResult.Instance.Should().NotBeNull();
                        instanceResult.Error.Should().BeNull();
                        instanceResult.Instance.TimeSeriesId.ToArray().Length.Should().Be(numOfIdProperties);
                        instanceResult.Instance.TypeId.Should().Be(defaultTypeId);
                        instanceResult.Instance.HierarchyIds.Count.Should().Be(0);
                        instanceResult.Instance.InstanceFields.Count.Should().Be(0);
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Get all Time Series instances in the environment
                AsyncPageable<TimeSeriesInstance> getAllInstancesResponse = client.GetInstancesAsync();

                int numOfInstances = 0;
                await foreach (TimeSeriesInstance tsiInstance in getAllInstancesResponse)
                {
                    numOfInstances++;
                    tsiInstance.Should().NotBeNull();
                }
                numOfInstances.Should().BeGreaterOrEqualTo(numOfInstancesToSetup);

                // Get search suggestions for the first instance
                TimeSeriesId timeSeriesIdToSuggest = timeSeriesInstances.First().TimeSeriesId;
                string suggestionString = timeSeriesIdToSuggest.ToArray().First();
                Response<SearchSuggestion[]> searchSuggestionResponse = await TestRetryHelper.RetryAsync(async () =>
                {
                    Response<SearchSuggestion[]> searchSuggestions = await client
                        .GetSearchSuggestionsAsync(suggestionString)
                        .ConfigureAwait(false);

                    if (searchSuggestions.Value.Length == 0)
                    {
                        throw new Exception($"Unable to find a search suggestion for string {suggestionString}.");
                    }

                    return searchSuggestions;
                }, MaxNumberOfRetries, s_retryDelay);

                searchSuggestionResponse.Value.Length.Should().Be(1);
            }
            finally
            {
                // clean up
                try
                {
                    Response<TimeSeriesOperationError[]> deleteInstancesResponse = await client
                        .DeleteInstancesAsync(timeSeriesInstancesIds)
                        .ConfigureAwait(false);

                    // Assert that the response array does not have any error object set
                    deleteInstancesResponse.Value.Should().OnlyContain((errorResult) => errorResult == null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Test clean up failed: {ex.Message}");
                    throw;
                }
            }
        }
    }
}

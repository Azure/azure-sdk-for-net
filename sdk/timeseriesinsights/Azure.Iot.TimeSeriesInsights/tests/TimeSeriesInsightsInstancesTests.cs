// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsInstancesTests : E2eTestBase
    {
        // TODO: replace hardcoding the Type GUID when the Types resource has been implemented
        private const string DefaultType = "1be09af9-f089-4d6b-9f0b-48018b5f7393";

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

            for (int i = 0; i < numOfInstancesToSetup; i++)
            {
                ITimeSeriesId id = await GetUniqueTimeSeriesInstanceIdAsync(client, numOfIdProperties)
                    .ConfigureAwait(false);

                timeSeriesInstances.Add(new TimeSeriesInstance(id, DefaultType));
            }

            // Act and assert
            try
            {
                // Create TSI instances
                Response<InstancesOperationError[]> createInstancesResult = await client
                    .CreateOrReplaceTimeSeriesInstancesAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                // Assert that the result error array does not contain any object that is set
                createInstancesResult.Value.Any((errorResult) => errorResult != null)
                    .Should().BeFalse();

                // Get the created instances by Ids
                Response<InstancesOperationResult[]> getInstancesByIdsResult = await client
                    .GetInstancesAsync(timeSeriesInstances.Select((instance) => instance.TimeSeriesId))
                    .ConfigureAwait(false);

                getInstancesByIdsResult.Value.Length.Should().Be(timeSeriesInstances.Count);

                foreach (InstancesOperationResult resultItem in getInstancesByIdsResult.Value)
                {
                    TimeSeriesInstance tsiInstance = resultItem.Instance;

                    tsiInstance.Should().NotBeNull();
                    resultItem.Error.Should().BeNull();

                    tsiInstance.TimeSeriesId.GetType().GenericTypeArguments.Count().Should().Be(numOfIdProperties);
                    tsiInstance.TypeId.Should().Be(DefaultType);
                    tsiInstance.HierarchyIds.Count.Should().Be(0);
                    tsiInstance.InstanceFields.Count.Should().Be(0);

                    // Ensure that the result response has a Time Series instance that matches one of the instances we setup earlier
                    timeSeriesInstances.Any(
                        (timeSeriesInstance) => timeSeriesInstance.TimeSeriesId.ToArray().SequenceEqual(tsiInstance.TimeSeriesId.ToArray()))
                        .Should().BeTrue();
                }

                // Update the instances by adding names to them
                var tsiInstanceNamePrefix = "instance";
                foreach (TimeSeriesInstance instance in timeSeriesInstances)
                {
                    instance.Name = Recording.GenerateAlphaNumericId(tsiInstanceNamePrefix);
                }

                Response<InstancesOperationResult[]> replaceInstancesResult = await client
                    .ReplaceTimeSeriesInstancesAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                replaceInstancesResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                replaceInstancesResult.Value.Any((errorResult) => errorResult.Error != null).Should().BeFalse();

                // Get instances by name
                Response<InstancesOperationResult[]> getInstancesByNameResult = await client
                    .GetInstancesAsync(timeSeriesInstances.Select((instance) => instance.Name))
                    .ConfigureAwait(false);

                getInstancesByNameResult.Value.Length.Should().Be(timeSeriesInstances.Count);

                foreach (InstancesOperationResult resultItem in getInstancesByNameResult.Value)
                {
                    TimeSeriesInstance tsiInstance = resultItem.Instance;

                    tsiInstance.Should().NotBeNull();
                    resultItem.Error.Should().BeNull();
                    tsiInstance.TimeSeriesId.GetType().GenericTypeArguments.Count().Should().Be(numOfIdProperties);
                    tsiInstance.TypeId.Should().Be(DefaultType);
                    tsiInstance.HierarchyIds.Count.Should().Be(0);
                    tsiInstance.InstanceFields.Count.Should().Be(0);

                    // Ensure that the result response has a Time Series instance that matches one of the instances we setup earlier
                    timeSeriesInstances.Any((timeSeriesInstance) => timeSeriesInstance.Name == tsiInstance.Name).Should().BeTrue();
                }

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
                var timeSeriesIdToSuggest = (TimeSeries3Id)timeSeriesInstances.First().TimeSeriesId;
                string suggestionString = string.Join(string.Empty, timeSeriesIdToSuggest.ToArray()).Substring(0, 3);
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
                }, 5, TimeSpan.FromSeconds(5));

                searchSuggestionResponse.Value.Length.Should().Be(1);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // clean up
                try
                {
                    Response<InstancesOperationError[]> deleteInstancesResponse = await client
                        .DeleteInstancesAsync(timeSeriesInstances.Select((instance) => instance.TimeSeriesId))
                        .ConfigureAwait(false);

                    // Assert that the response array does not have any error object set
                    deleteInstancesResponse.Value.Any((errorResult) => errorResult == null).Should().BeTrue();
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }
    }
}

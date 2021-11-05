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
    public class InstancesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(20);

        private const int MaxNumberOfRetries = 10;

        public InstancesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsInstances_Lifecycle()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();
            TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
            TimeSeriesInsightsInstances instancesClient = client.GetInstancesClient();

            int numOfInstancesToSetup = 2;
            var timeSeriesInstances = new List<TimeSeriesInstance>();
            Response<TimeSeriesModelSettings> currentSettings = await modelSettingsClient.GetAsync().ConfigureAwait(false);
            string defaultTypeId = currentSettings.Value.DefaultTypeId;
            int numOfIdProperties = currentSettings.Value.TimeSeriesIdProperties.Count;

            for (int i = 0; i < numOfInstancesToSetup; i++)
            {
                TimeSeriesId id = await GetUniqueTimeSeriesInstanceIdAsync(instancesClient, numOfIdProperties)
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
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>((Func<Task<Response<InstancesOperationResult[]>>>)(async () =>
                {
                    // Create TSI instances
                    Response<TimeSeriesOperationError[]> createInstancesResult = await instancesClient
                        .CreateOrReplaceAsync(timeSeriesInstances)
                        .ConfigureAwait(false);

                    // Assert that the result error array does not contain any object that is set
                    createInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult == null);

                    // Get the created instances by Ids
                    Response<InstancesOperationResult[]> getInstancesByIdsResult = await instancesClient
                        .GetByIdAsync(timeSeriesInstancesIds)
                        .ConfigureAwait(false);

                    getInstancesByIdsResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                    foreach (InstancesOperationResult instanceResult in getInstancesByIdsResult.Value)
                    {
                        instanceResult.Instance.Should().NotBeNull();
                        instanceResult.Error.Should().BeNull();
                        instanceResult.Instance.TimeSeriesId.ToStringArray().Length.Should().Be(numOfIdProperties);
                        AssertionExtensions.Should(instanceResult.Instance.TimeSeriesTypeId).Be(defaultTypeId);
                        instanceResult.Instance.HierarchyIds.Count.Should().Be(0);
                        instanceResult.Instance.InstanceFields.Count.Should().Be(0);
                    }

                    // Update the instances by adding descriptions to them
                    timeSeriesInstances.ForEach((timeSeriesInstance) =>
                        timeSeriesInstance.Description = "Description");

                    Response<InstancesOperationResult[]> replaceInstancesResult = await instancesClient
                        .ReplaceAsync(timeSeriesInstances)
                        .ConfigureAwait(false);

                    replaceInstancesResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                    replaceInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);

                    // Get instances by name
                    Response<InstancesOperationResult[]> getInstancesByNameResult = await instancesClient
                        .GetByNameAsync(timeSeriesInstances.Select((instance) => instance.Name))
                        .ConfigureAwait(false);

                    getInstancesByNameResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                    foreach (InstancesOperationResult instanceResult in getInstancesByNameResult.Value)
                    {
                        instanceResult.Instance.Should().NotBeNull();
                        instanceResult.Error.Should().BeNull();
                        instanceResult.Instance.TimeSeriesId.ToStringArray().Length.Should().Be(numOfIdProperties);
                        AssertionExtensions.Should(instanceResult.Instance.TimeSeriesTypeId).Be(defaultTypeId);
                        instanceResult.Instance.HierarchyIds.Count.Should().Be(0);
                        instanceResult.Instance.InstanceFields.Count.Should().Be(0);
                    }

                    // Get all Time Series instances in the environment
                    AsyncPageable<TimeSeriesInstance> getAllInstancesResponse = instancesClient.GetAsync();

                    int numOfInstances = 0;
                    await foreach (TimeSeriesInstance tsiInstance in getAllInstancesResponse)
                    {
                        numOfInstances++;
                        tsiInstance.Should().NotBeNull();
                    }
                    numOfInstances.Should().BeGreaterOrEqualTo(numOfInstancesToSetup);
                    return null;
                }), MaxNumberOfRetries, s_retryDelay);
            }
            finally
            {
                // clean up
                try
                {
                    Response<TimeSeriesOperationError[]> deleteInstancesResponse = await instancesClient
                        .DeleteByIdAsync(timeSeriesInstancesIds)
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

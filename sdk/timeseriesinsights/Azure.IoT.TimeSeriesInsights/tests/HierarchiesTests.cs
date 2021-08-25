// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    public class HierarchiesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(10);
        private const int MaxNumberOfRetries = 10;

        public HierarchiesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsHierarchies_Lifecycle()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();
            TimeSeriesInsightsHierarchies hierarchiesClient = client.GetHierarchiesClient();
            var tsiHiearchyNamePrefix = "hierarchy";
            var tsiSourceNamePrefix = "hierarchySource";
            var tsiHierarchyName = Recording.GenerateAlphaNumericId(tsiHiearchyNamePrefix);
            var hierarchyNames = new List<string>
            {
                tsiHierarchyName
            };

            var hierarchySource = new TimeSeriesHierarchySource();
            hierarchySource.InstanceFieldNames.Add(Recording.GenerateAlphaNumericId(tsiSourceNamePrefix));
            var tsiHierarchy = new TimeSeriesHierarchy(tsiHierarchyName, hierarchySource);
            tsiHierarchy.Id = Recording.GenerateId();
            var timeSeriesHierarchies = new List<TimeSeriesHierarchy>
            {
                tsiHierarchy
            };

            // Act and assert
            try
            {
                // Create Time Series hierarchies
                Response<TimeSeriesHierarchyOperationResult[]> createHierarchiesResult = await hierarchiesClient
                    .CreateOrReplaceAsync(timeSeriesHierarchies)
                    .ConfigureAwait(false);

                // Assert that the result error array does not contain any object that is set
                createHierarchiesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);
                Response<TimeSeriesHierarchyOperationResult[]> getHierarchiesByNamesResult;

                // This retry logic was added as the TSI hierarchies are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<TimeSeriesHierarchyOperationResult[]>>(async () =>
                {
                    // Get the created hierarchies by names
                    getHierarchiesByNamesResult = await hierarchiesClient
                        .GetByNameAsync(new List<string>()
                        {
                            tsiHierarchyName
                        })
                        .ConfigureAwait(false);

                    getHierarchiesByNamesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);
                    getHierarchiesByNamesResult.Value.Length.Should().Be(timeSeriesHierarchies.Count);
                    foreach (TimeSeriesHierarchyOperationResult hierarchiesResult in getHierarchiesByNamesResult.Value)
                    {
                        hierarchiesResult.Error.Should().BeNull();
                        hierarchiesResult.Hierarchy.Should().NotBeNull();
                        hierarchiesResult.Hierarchy.Id.Should().NotBeNullOrEmpty();
                    }
                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Update hierarchies with adding a source and set Id
                var updateTsiName = Recording.GenerateAlphaNumericId(tsiHiearchyNamePrefix);
                hierarchyNames.Add(updateTsiName);

                hierarchySource.InstanceFieldNames.Add(Recording.GenerateAlphaNumericId(tsiSourceNamePrefix));
                var tsiHierarchyToAdd = new TimeSeriesHierarchy(updateTsiName, hierarchySource);
                tsiHierarchyToAdd.Id = Recording.GenerateId();
                timeSeriesHierarchies.Add(tsiHierarchyToAdd);

                Response<TimeSeriesHierarchyOperationResult[]> updateHierarchiesResult = await hierarchiesClient
                    .CreateOrReplaceAsync(timeSeriesHierarchies)
                    .ConfigureAwait(false);

                updateHierarchiesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);
                updateHierarchiesResult.Value.Length.Should().Be(timeSeriesHierarchies.Count);

                // This retry logic was added as the TSI hierarchies are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<TimeSeriesHierarchyOperationResult[]>>(async () =>
                {
                    // Get hierarchy by Id
                    Response<TimeSeriesHierarchyOperationResult[]> getHierarchyByIdResult = await hierarchiesClient
                        .GetByIdAsync(new string[] { tsiHierarchy.Id })
                        .ConfigureAwait(false);

                    getHierarchyByIdResult.Value.Length.Should().Be(1);
                    foreach (TimeSeriesHierarchyOperationResult hierarchyOperationResult in getHierarchyByIdResult.Value)
                    {
                        hierarchyOperationResult.Hierarchy.Should().NotBeNull();
                        hierarchyOperationResult.Error.Should().BeNull();
                        hierarchyOperationResult.Hierarchy.Name.Should().StartWith(tsiHiearchyNamePrefix);
                        hierarchyOperationResult.Hierarchy.Id.Should().Be(tsiHierarchy.Id);
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Get all Time Series hierarchies in the environment
                AsyncPageable<TimeSeriesHierarchy> getAllHierarchies = hierarchiesClient.GetAsync();
                await foreach (TimeSeriesHierarchy hierarchy in getAllHierarchies)
                {
                    hierarchy.Should().NotBeNull();
                }
            }
            finally
            {
                // clean up
                try
                {
                    Response<TimeSeriesOperationError[]> deleteHierarchiesResponse = await hierarchiesClient
                        .DeleteByNameAsync(hierarchyNames)
                        .ConfigureAwait(false);
                    // Assert that the response array does not have any error object set
                    deleteHierarchiesResponse.Value.Should().OnlyContain((errorResult) => errorResult == null);
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

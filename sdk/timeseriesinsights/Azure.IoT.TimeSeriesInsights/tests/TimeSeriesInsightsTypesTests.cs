// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsTypesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(10);
        private const int MaxNumberOfRetries = 10;

        public TimeSeriesInsightsTypesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsTypes_Lifecycle()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();
            var timeSeriesTypes = new List<TimeSeriesType>();
            var tsiTypeNamePrefix = "type";
            int numOfTypesCreated = 0;
            var timeSeriesTypesProperties = new Dictionary<string, string>
            {
                { Recording.GenerateAlphaNumericId(tsiTypeNamePrefix), Recording.GenerateId()},
                { Recording.GenerateAlphaNumericId(tsiTypeNamePrefix), Recording.GenerateId()}
            };

            // Build aggregate type
            var countExpression = new TimeSeriesExpression("count()");
            var aggValue = new AggregateVariable(countExpression);
            var variables = new Dictionary<string, TimeSeriesVariable>();
            var variableNamePrefix = "var";
            variables.Add(Recording.GenerateAlphaNumericId(variableNamePrefix), aggValue);

            foreach (var property in timeSeriesTypesProperties)
            {
                var type = new TimeSeriesType(property.Key, variables);
                type.Id = property.Value;
                timeSeriesTypes.Add(type);
                numOfTypesCreated++;
            }

            // Act and assert
            try
            {
                // Get all Time Series types in the environment
                AsyncPageable<TimeSeriesType> getAllTypesResponse = client.GetTimeSeriesTypesAsync();

                await foreach (TimeSeriesType tsiType in getAllTypesResponse)
                {
                    tsiType.Should().NotBeNull();
                }

                // Create Time Series types
                Response<TimeSeriesOperationError[]> createInstancesResult = await client
                    .CreateOrReplaceTimeSeriesTypesAsync(timeSeriesTypes)
                    .ConfigureAwait(false);

                // Assert that the result error array does not contain any object that is set
                createInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult == null);
                Response<TimeSeriesTypeOperationResult[]> getTypesByNamesResult;

                //This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<TimeSeriesTypeOperationResult[]>>(async () =>
                {
                    // Get the created instances by Ids
                    getTypesByNamesResult = await client
                        .GetTimeSeriesTypesByNamesAsync(timeSeriesTypesProperties.Keys)
                        .ConfigureAwait(false);

                    getTypesByNamesResult.Value.Length.Should().Be(timeSeriesTypes.Count);
                    foreach (TimeSeriesTypeOperationResult typesResult in getTypesByNamesResult.Value)
                    {
                        typesResult.TimeSeriesType.Should().NotBeNull();
                        typesResult.Error.Should().BeNull();
                        typesResult.TimeSeriesType.Id.Should().NotBeNullOrEmpty();
                        typesResult.TimeSeriesType.Variables.Count.Should().Be(1);
                        typesResult.TimeSeriesType.Variables.IsSameOrEqualTo(variables);
                    }
                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Update variables with adding a new variable
                foreach (var type in timeSeriesTypes)
                {
                    type.Description = "Description";
                }

                Response<TimeSeriesOperationError[]> updateTypesResult = await client
                    .CreateOrReplaceTimeSeriesTypesAsync(timeSeriesTypes)
                    .ConfigureAwait(false);

                updateTypesResult.Value.Should().OnlyContain((errorResult) => errorResult == null);
                updateTypesResult.Value.Length.Should().Be(timeSeriesTypes.Count);

                // This retry logic was added as the TSI types are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>(async () =>
                {
                    // Get type by Id
                    Response<TimeSeriesTypeOperationResult[]> getTypeByIdResult = await client
                        .GetTimeSeriesTypesByIdAsync(timeSeriesTypesProperties.Values)
                        .ConfigureAwait(false);

                    getTypeByIdResult.Value.Length.Should().Be(numOfTypesCreated);
                    foreach (TimeSeriesTypeOperationResult typeOperationResult in getTypeByIdResult.Value)
                    {
                        typeOperationResult.TimeSeriesType.Should().NotBeNull();
                        typeOperationResult.Error.Should().BeNull();
                        typeOperationResult.TimeSeriesType.Name.Should().StartWith(tsiTypeNamePrefix);
                        typeOperationResult.TimeSeriesType.Id.Should().NotBeNull();
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);
            }
            finally
            {
                // clean up
                try
                {
                    Response<TimeSeriesOperationError[]> deleteTypesResponse = await client
                        .DeleteTimeSeriesTypesbyIdAsync(timeSeriesTypesProperties.Values)
                        .ConfigureAwait(false);

                    // Assert that the response array does not have any error object set
                    deleteTypesResponse.Value.Should().OnlyContain((errorResult) => errorResult == null);
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

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
    [Parallelizable(ParallelScope.None)]
    public class TimeSeriesInsightsTypesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(10);
        private const int MaxNumberOfRetries = 10;

        public TimeSeriesInsightsTypesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsTypeWithNumericVariable_ExpectsError()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();
            var timeSeriesTypes = new List<TimeSeriesType>();
            var tsiTypeNamePrefix = "type";
            var timeSeriesTypesName = Recording.GenerateAlphaNumericId(tsiTypeNamePrefix);
            string timeSeriesTypeId = Recording.GenerateId();

            // Build Numeric variable
            // Below is an invalid expression
            var numExpression = new TimeSeriesExpression("$event");
            var aggregation = new TimeSeriesExpression("avg($value)");
            var numericVariable = new NumericVariable(numExpression, aggregation);
            var variables = new Dictionary<string, TimeSeriesVariable>();
            var variableNamePrefix = "numericVariableName";
            variables.Add(Recording.GenerateAlphaNumericId(variableNamePrefix), numericVariable);

            var type = new TimeSeriesType(timeSeriesTypesName, variables);
            type.Id = timeSeriesTypeId;
            timeSeriesTypes.Add(type);

            // Act and Assert
            await TestTimeSeriesTypeWhereErrorIsExpected(client, timeSeriesTypes, timeSeriesTypesName).ConfigureAwait(false);
        }

        [Test]
        public async Task TimeSeriesInsightsTypeWithCategoricalVariable_ExpectsError()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();
            var timeSeriesTypes = new List<TimeSeriesType>();
            var tsiTypeNamePrefix = "type";
            var timeSeriesTypesName = Recording.GenerateAlphaNumericId(tsiTypeNamePrefix);
            string timeSeriesTypeId = Recording.GenerateId();

            // Build Numeric variable
            // Below is an invalid expression
            var categoricalValue = new TimeSeriesExpression("$event");
            var category = new TimeSeriesDefaultCategory("label");
            var categoricalVariable = new CategoricalVariable(categoricalValue, category);
            var variables = new Dictionary<string, TimeSeriesVariable>();
            var variableNamePrefix = "categoricalVariableName";
            variables.Add(Recording.GenerateAlphaNumericId(variableNamePrefix), categoricalVariable);

            var type = new TimeSeriesType(timeSeriesTypesName, variables);
            type.Id = timeSeriesTypeId;
            timeSeriesTypes.Add(type);

            // Act and Assert
            await TestTimeSeriesTypeWhereErrorIsExpected(client, timeSeriesTypes, timeSeriesTypesName).ConfigureAwait(false);
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

            // Build aggregate variable
            var countExpression = new TimeSeriesExpression("count()");
            var aggregateVariable = new AggregateVariable(countExpression);
            var variables = new Dictionary<string, TimeSeriesVariable>();
            var variableNamePrefix = "aggregateVariable";
            variables.Add(Recording.GenerateAlphaNumericId(variableNamePrefix), aggregateVariable);

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
                Response<TimeSeriesOperationError[]> createTypesResult = await client
                    .CreateOrReplaceTimeSeriesTypesAsync(timeSeriesTypes)
                    .ConfigureAwait(false);

                // Assert that the result error array does not contain any object that is set
                createTypesResult.Value.Should().OnlyContain((errorResult) => errorResult == null);
                Response<TimeSeriesTypeOperationResult[]> getTypesByNamesResult;

                // This retry logic was added as the TSI types are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<TimeSeriesTypeOperationResult[]>>(async () =>
                {
                    // Get the created types by names
                    getTypesByNamesResult = await client
                        .GetTimeSeriesTypesByNamesAsync(timeSeriesTypesProperties.Keys)
                        .ConfigureAwait(false);

                    getTypesByNamesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);
                    getTypesByNamesResult.Value.Length.Should().Be(timeSeriesTypes.Count);
                    foreach (TimeSeriesTypeOperationResult typesResult in getTypesByNamesResult.Value)
                    {
                        typesResult.Error.Should().BeNull();
                        typesResult.TimeSeriesType.Should().NotBeNull();
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
                await TestRetryHelper.RetryAsync<Response<TimeSeriesTypeOperationResult[]>>(async () =>
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

        private static async Task TestTimeSeriesTypeWhereErrorIsExpected(TimeSeriesInsightsClient client, List<TimeSeriesType> timeSeriesTypes, string timeSeriesTypesName)
        {
            // create numeric type and expect failure due to invalid input expression
            Response<TimeSeriesOperationError[]> createTypesResult = await client
                .CreateOrReplaceTimeSeriesTypesAsync(timeSeriesTypes)
                .ConfigureAwait(false);

            // Assert that the result error array does not contain an error
            createTypesResult.Value.Should().OnlyContain((errorResult) => errorResult != null);

            // Get the type by name and expect error
            var getTypesByNamesResult = await client
                .GetTimeSeriesTypesByNamesAsync(new string[] { timeSeriesTypesName })
                .ConfigureAwait(false);
            getTypesByNamesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error != null);

            // Delete the type by name and expect error
            Response<TimeSeriesOperationError[]> deleteTypesResponse = await client
                       .DeleteTimeSeriesTypesByNamesAsync(new string[] { timeSeriesTypesName })
                       .ConfigureAwait(false);

            // Response is null even when type does not exist.
            deleteTypesResponse.Value.Should().OnlyContain((errorResult) => errorResult == null);
        }
    }
}

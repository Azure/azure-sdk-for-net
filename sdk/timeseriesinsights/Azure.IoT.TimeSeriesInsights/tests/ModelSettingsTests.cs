// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    [Parallelizable(ParallelScope.None)]
    public class ModelSettingsTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(20);

        private const int MaxNumberOfRetries = 5;

        public ModelSettingsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsClient_ModelSettingsTest()
        {
            TimeSeriesInsightsClient client = GetClient();
            TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
            TimeSeriesInsightsTypes typesClient = client.GetTypesClient();

            // GET model settings
            Response<TimeSeriesModelSettings> currentSettings = await modelSettingsClient.GetAsync().ConfigureAwait(false);
            currentSettings.GetRawResponse().Status.Should().Be((int)HttpStatusCode.OK);
            string testName = "testModel";
            // UPDATE model settings
            string typeId = await createTimeSeriesTypeAsync(client).ConfigureAwait(false);
            string defaultTypeId = await getDefaultTypeIdAsync(modelSettingsClient).ConfigureAwait(false);

            try
            {
                Response<TimeSeriesModelSettings> updatedSettingsName = await modelSettingsClient.UpdateNameAsync(testName).ConfigureAwait(false);
                updatedSettingsName.GetRawResponse().Status.Should().Be((int)HttpStatusCode.OK);
                updatedSettingsName.Value.Name.Should().Be(testName);

                await TestRetryHelper.RetryAsync<Response<TimeSeriesModelSettings>>(async () =>
                {
                    Response<TimeSeriesModelSettings> updatedSettingsId = await modelSettingsClient.UpdateDefaultTypeIdAsync(typeId).ConfigureAwait(false);
                    updatedSettingsId.Value.DefaultTypeId.Should().Be(typeId);

                    // update it back to the default Type Id
                    updatedSettingsId = await modelSettingsClient.UpdateDefaultTypeIdAsync(defaultTypeId).ConfigureAwait(false);
                    updatedSettingsId.Value.DefaultTypeId.Should().Be(defaultTypeId);

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);
            }
            finally
            {
                // clean up
                try
                {
                    Response<TimeSeriesOperationError[]> deleteTypesResponse = await typesClient
                        .DeleteByIdAsync(new string[] { typeId })
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

        [Test]
        public void UpdateModelSettingsWithInvalidType_ThrowsBadRequestException()
        {
            // arrange
            TimeSeriesInsightsClient client = GetClient();
            TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();

            // act
            Func<Task> act = async () => await modelSettingsClient.UpdateDefaultTypeIdAsync("testId").ConfigureAwait(false);

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.BadRequest);
        }

        private async Task<string> createTimeSeriesTypeAsync(TimeSeriesInsightsClient client)
        {
            TimeSeriesInsightsTypes typesClient = client.GetTypesClient();
            var timeSeriesTypes = new List<TimeSeriesType>();
            var tsiTypeNamePrefix = "type";
            var timeSeriesTypesName = Recording.GenerateAlphaNumericId(tsiTypeNamePrefix);
            string timeSeriesTypeId = Recording.GenerateId();

            // Build aggregate variable
            var countExpression = new TimeSeriesExpression("count()");
            var aggregateVariable = new AggregateVariable(countExpression);
            var variables = new Dictionary<string, TimeSeriesVariable>();
            var variableNamePrefix = "aggregateVariable";
            variables.Add(Recording.GenerateAlphaNumericId(variableNamePrefix), aggregateVariable);

            var type = new TimeSeriesType(timeSeriesTypesName, variables)
            {
                Id = timeSeriesTypeId
            };
            timeSeriesTypes.Add(type);

            Response<TimeSeriesTypeOperationResult[]> createTypesResult = await typesClient
               .CreateOrReplaceAsync(timeSeriesTypes)
               .ConfigureAwait(false);

            createTypesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);

            return timeSeriesTypeId;
        }
    }
}

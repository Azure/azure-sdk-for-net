// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    public class TimeSeriesIdTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(20);

        // This is the GUID that TSI uses to represent the default type for a Time Series Instance.
        // TODO: replace hardcoding the Type GUID when the Types resource has been implemented.
        private const string DefaultType = "1be09af9-f089-4d6b-9f0b-48018b5f7393";
        private const int MaxNumberOfRetries = 10;

        public TimeSeriesIdTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesId_CreateInstanceWith3Keys()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();

            // Create a Time Series Id with 3 keys. Middle key is a null
            TimeSeriesId idWithNull = new TimeSeriesId(
                Recording.GenerateAlphaNumericId(string.Empty, 5),
                null,
                Recording.GenerateAlphaNumericId(string.Empty, 5));

            var timeSeriesInstances = new List<TimeSeriesInstance>
            {
                new TimeSeriesInstance(idWithNull, DefaultType),
            };

            // Act and assert
            try
            {
                // Create TSI instances
                Response<TimeSeriesOperationError[]> createInstancesResult = await client
                    .CreateOrReplaceTimeSeriesInstancesAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                // Assert that the result error array does not contain any object that is set
                createInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult == null);

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>(async () =>
                {
                    // Get the instance with a null item in its Id
                    Response<InstancesOperationResult[]> getInstanceWithNullInId = await client
                        .GetInstancesAsync(new List<TimeSeriesId> { idWithNull })
                        .ConfigureAwait(false);

                    getInstanceWithNullInId.Value.Length.Should().Be(1);

                    InstancesOperationResult resultItem = getInstanceWithNullInId.Value.First();
                    resultItem.Error.Should().BeNullOrEmpty();
                    resultItem.Instance.Should().NotBeNull();
                    resultItem.Instance.TimeSeriesId.ToArray().Length.Should().Be(3);
                    resultItem.Instance.TimeSeriesId.ToArray()[1].Should().BeNull();

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);
            }
            finally
            {
                // clean up
                try
                {
                    Response<TimeSeriesOperationError[]> deleteInstancesResponse = await client
                        .DeleteInstancesAsync(timeSeriesInstances.Select((instance) => instance.TimeSeriesId))
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

        [Test]
        public void TimeSeriesId_GetIdForStringKeys()
        {
            // Arrange
            var key1 = "B17";
            var key2 = "F1";
            var key3 = "R400";
            var tsiId = new TimeSeriesId(key1, key2, key3);

            // Act
            var idAsString = tsiId.ToString();

            // Assert
            idAsString.Should().Be($"[\"{key1}\",\"{key2}\",\"{key3}\"]");
        }

        [Test]
        public void TimeSeriesId_ToArrayWith1StringKey()
        {
            // Arrange
            var key1 = "B17";
            var tsiId = new TimeSeriesId(key1);

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            idAsArray.Should().Equal(new string[] { key1 });
        }

        [Test]
        public void TimeSeriesId_ToArrayWith2StringKeys()
        {
            // Arrange
            var key1 = "B17";
            var key2 = "F1";
            var tsiId = new TimeSeriesId(key1, key2);

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            idAsArray.Should().Equal(new string[] { key1, key2 });
        }

        [Test]
        public void TimeSeriesId_ToArrayWith3StringKeys()
        {
            // Arrange
            var key1 = "B17";
            var key2 = "F1";
            var key3 = "R1";
            var tsiId = new TimeSeriesId(key1, key2, key3);

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            idAsArray.Should().Equal(new string[] { key1, key2, key3 });
        }
    }
}

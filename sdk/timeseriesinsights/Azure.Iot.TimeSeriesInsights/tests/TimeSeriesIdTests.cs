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
    public class TimeSeriesIdTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(10);

        // This is the GUID that TSI uses to represent the default type for a Time Series Instance.
        // TODO: replace hardcoding the Type GUID when the Types resource has been implemented.
        private const string DefaultType = "1be09af9-f089-4d6b-9f0b-48018b5f7393";
        private const int MaxNumberOfRetries = 10;

        public TimeSeriesIdTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsInstances_TimeSeries3Id()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();

            // Create a Time Series Id with 3 properties. Middle property is a null
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
                Response<InstancesOperationError[]> createInstancesResult = await client
                    .CreateOrReplaceTimeSeriesInstancesAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                // Assert that the result error array does not contain any object that is set
                createInstancesResult.Value.All((errorResult) => errorResult == null)
                    .Should().BeTrue();

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>(async () =>
                {
                    // Get the instance with a null item in its Id
                    Response<InstancesOperationResult[]> getInstanceWithNullInId = await client
                        .GetInstancesAsync(new List<TimeSeriesId> { idWithNull })
                        .ConfigureAwait(false);

                    getInstanceWithNullInId.Value.Length.Should().Be(1);

                    InstancesOperationResult resultItem = getInstanceWithNullInId.Value.First();
                    resultItem.Error.Should().BeNull();
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
                    Response<InstancesOperationError[]> deleteInstancesResponse = await client
                        .DeleteInstancesAsync(timeSeriesInstances.Select((instance) => instance.TimeSeriesId))
                        .ConfigureAwait(false);

                    // Assert that the response array does not have any error object set
                    deleteInstancesResponse.Value.All((errorResult) => errorResult == null).Should().BeTrue();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Test clean up failed: {ex.Message}");
                    throw;
                }
            }
        }

        [Test]
        public void TimeSeriesInsightsInstances_GetIdForStringKeys()
        {
            // Arrange
            var tsiId = new TimeSeriesId("B17", "F1", "R400");

            // Act
            var idAsString = tsiId.GetId();

            // Assert
            idAsString.Should().Be("B17,F1,R400");
        }

        [Test]
        public void TimeSeriesInsightsInstances_GetIdForObjectKeys()
        {
            // Arrange
            var tsiId = new TimeSeriesId(true, 1);

            // Act
            var idAsString = tsiId.GetId();

            // Assert
            idAsString.Should().Be("True,1");
        }

        [Test]
        public void TimeSeriesInsightsInstances_ToArrayWith1StringKey()
        {
            // Arrange
            var tsiId = new TimeSeriesId("B17");

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            Enumerable.SequenceEqual(idAsArray, new object[] { "B17" }).Should().BeTrue();
        }

        [Test]
        public void TimeSeriesInsightsInstances_ToArrayWith2StringKeys()
        {
            // Arrange
            var tsiId = new TimeSeriesId("B17", "F1");

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            Enumerable.SequenceEqual(idAsArray, new object[] { "B17", "F1" }).Should().BeTrue();
        }

        [Test]
        public void TimeSeriesInsightsInstances_ToArrayWith3StringKeys()
        {
            // Arrange
            var tsiId = new TimeSeriesId("B17", "F1", "R1");

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            Enumerable.SequenceEqual(idAsArray, new object[] { "B17", "F1", "R1" }).Should().BeTrue();
        }

        [Test]
        public void TimeSeriesInsightsInstances_ToArrayWith1ObjectKeys()
        {
            // Arrange
            var tsiId = new TimeSeriesId(true);

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            Enumerable.SequenceEqual(idAsArray, new object[] { true }).Should().BeTrue();
        }

        [Test]
        public void TimeSeriesInsightsInstances_ToArrayWith2ObjectKeys()
        {
            // Arrange
            var tsiId = new TimeSeriesId(1, true);

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            Enumerable.SequenceEqual(idAsArray, new object[] { 1, true }).Should().BeTrue();
        }

        [Test]
        public void TimeSeriesInsightsInstances_ToArrayWith3ObjectKeys()
        {
            // Arrange
            var tsiId = new TimeSeriesId(1, false, "B1");

            // Act
            var idAsArray = tsiId.ToArray();

            // Assert
            Enumerable.SequenceEqual(idAsArray, new object[] { 1, false, "B1" }).Should().BeTrue();
        }
    }
}

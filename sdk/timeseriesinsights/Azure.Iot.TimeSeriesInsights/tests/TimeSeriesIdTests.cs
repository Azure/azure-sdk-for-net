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
        // TODO: replace hardcoding the Type GUID when the Types resource has been implemented
        private const string DefaultType = "1be09af9-f089-4d6b-9f0b-48018b5f7393";

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
            ITimeSeriesId idWithNull = new TimeSeries3Id(
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
                        .GetInstancesAsync(new List<ITimeSeriesId> { idWithNull })
                        .ConfigureAwait(false);

                    getInstanceWithNullInId.Value.Length.Should().Be(1);

                    InstancesOperationResult resultItem = getInstanceWithNullInId.Value.First();
                    resultItem.Error.Should().BeNull();
                    resultItem.Instance.Should().NotBeNull();
                    resultItem.Instance.TimeSeriesId.GetType().GenericTypeArguments.Count().Should().Be(3);
                    resultItem.Instance.TimeSeriesId.ToArray().Length.Should().Be(3);
                    resultItem.Instance.TimeSeriesId.ToArray()[1].Should().BeNull();

                    return null;
                }, 5, TimeSpan.FromSeconds(5));
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
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }
    }
}

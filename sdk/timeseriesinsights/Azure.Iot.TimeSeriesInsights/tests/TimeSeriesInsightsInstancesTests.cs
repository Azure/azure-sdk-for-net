// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            // arrange
            TimeSeriesInsightsClient client = GetClient();
            int numOfIdProperties = 3;

            ITimeSeriesId timeSeriesInstance1Id = await GetUniqueTimeSeriesInstanceIdAsync(client, numOfIdProperties).ConfigureAwait(false);
            ITimeSeriesId timeSeriesInstance2Id = await GetUniqueTimeSeriesInstanceIdAsync(client, numOfIdProperties).ConfigureAwait(false);

            var timeSeriesInstances = new List<TimeSeriesInstance>()
            {
                new TimeSeriesInstance(timeSeriesInstance1Id, DefaultType),
                new TimeSeriesInstance(timeSeriesInstance2Id, DefaultType),
            };

            try
            {
                // Create two TSI instances
                Response<InstancesOperationError[]> createInstancesResult = await client
                    .CreateOrReplaceTimeSeriesInstancesAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                // Assert that the result error array does not contain any object that is set
                Assert.IsFalse(createInstancesResult.Value.Any((errorResult) => errorResult != null));

                // Get the two created instances by Ids
                Response<InstancesOperationResult[]> getInstancesByIdsResult = await client
                    .GetInstancesAsync(new List<ITimeSeriesId> { timeSeriesInstance1Id, timeSeriesInstance2Id })
                    .ConfigureAwait(false);

                Assert.AreEqual(timeSeriesInstances.Count, getInstancesByIdsResult.Value.Length);
                Assert.AreEqual(string.Join(",", timeSeriesInstance1Id.ToArray()), string.Join(",", getInstancesByIdsResult.Value[0].Instance.TimeSeriesId.ToArray()));
                Assert.AreEqual(string.Join(",", timeSeriesInstance2Id.ToArray()), string.Join(",", getInstancesByIdsResult.Value[1].Instance.TimeSeriesId.ToArray()));

                foreach (InstancesOperationResult resultItem in getInstancesByIdsResult.Value)
                {
                    Assert.IsNotNull(resultItem.Instance);
                    Assert.IsNull(resultItem.Error);
                    Assert.AreEqual(numOfIdProperties, resultItem.Instance.TimeSeriesId.GetType().GenericTypeArguments.Count());
                    Assert.AreEqual(DefaultType, resultItem.Instance.TypeId);
                    Assert.AreEqual(0, resultItem.Instance.HierarchyIds.Count);
                    Assert.AreEqual(0, resultItem.Instance.InstanceFields.Count);
                }
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
                    //await Task
                    //    .WhenAll(
                    //        client.DeleteInstancesAsync(
                    //            new List<TimeSeriesId>
                    //            {
                    //                timeSeriesInstance1Id,
                    //                timeSeriesInstance2Id,
                    //                timeSeriesInstance3Id,
                    //            }))
                    //    .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }
    }
}

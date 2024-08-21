// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ComputeSchedule.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputescheduleOperationsTests: ComputeScheduleTestBaseOperations
    {
        private static readonly int s_waitTime = 2000;
        private static readonly int s_submitOperationsDelayedSeconds = 1;
        private static readonly string s_resourceGroupName = "computeschedule-netsdktest-rg";

        public ComputescheduleOperationsTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSubmitStartOperations()
        {
            // Arrange
            string _resourceNamePrefix = "computeschedule_netsdk_submitstart_test";
            string resourceGroupName = Recording.GenerateAssetName(s_resourceGroupName);
            await CreateResourceGroup(DefaultSubscription, resourceGroupName, location);
            Schedule schedule = new(DateTimeOffset.UtcNow.AddSeconds(s_submitOperationsDelayedSeconds), "UTC", DeadlineType.InitiateAt);
            Models.Resources resources = GenerateResources(resourceGroupName, DefaultSubscription, _resourceNamePrefix, 1);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };
            var submitStartRequest = new SubmitStartContent(schedule, executionParameters, resources, Guid.NewGuid().ToString());

            // Act
            // SubmitStart
            StartResourceOperationResponse submitStartResult = await TestSubmitStartAsync(location, submitStartRequest, DefaultSubscription.ToString());

            Task.Delay(s_waitTime).Wait();

            // GetOps status
            var allOperationIds = submitStartResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
            var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Guid.NewGuid().ToString());
            GetOperationStatusResponse getOperationStatus = TestGetOpsStatusAsync(location, getOpsStatusReq, Guid.NewGuid().ToString()).Result;

            // Assert
            Assert.NotNull(submitStartResult);
            Assert.NotNull(getOperationStatus);
        }
    }
}

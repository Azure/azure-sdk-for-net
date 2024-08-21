// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputescheduleOperationsTests: ComputeScheduleTestBaseOperations
    {
        private static readonly int s_waitTime = 3000;
        private static readonly int s_submitOperationsDelayedSeconds = 1;
        private static readonly string s_resourceGroupName = "computeschedule-netsdktest-rg";
        private ResourceGroupResource _rg;

        public ComputescheduleOperationsTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            try
            {
                Response<ResourceGroupResource> rgValue = _rg.Get();
                if (rgValue.Value == null)
                {
                    _rg = await CreateResourceGroupAsync(s_resourceGroupName);
                    return;
                }
                _rg = rgValue.Value;
                await CreateCommonClient();
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                throw;
            }
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            Task.Delay(s_waitTime).Wait();

            try
            {
                await _rg.DeleteAsync(WaitUntil.Completed);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                throw;
            }
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task TestSubmitStartOperations()
        {
            // Arrange
            string vmName = Recording.GenerateAssetName("computeschedule-netsdktest-submitstart-vm");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, _rg, 3).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Schedule schedule = new(DateTimeOffset.UtcNow.AddSeconds(s_submitOperationsDelayedSeconds), "UTC", DeadlineType.InitiateAt);
            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitStartRequest = new SubmitStartContent(schedule, executionParameters, resources, Guid.NewGuid().ToString());

            // Act
            // SubmitStart
            StartResourceOperationResponse submitStartResult = await TestSubmitStartAsync(Location, submitStartRequest, DefaultSubscription.ToString());

            Task.Delay(s_waitTime).Wait();

            // GetOps status
            var allOperationIds = submitStartResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
            var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Guid.NewGuid().ToString());
            GetOperationStatusResponse getOperationStatus = TestGetOpsStatusAsync(Location, getOpsStatusReq, Guid.NewGuid().ToString()).Result;

            // Assert
            Assert.NotNull(submitStartResult);
            Assert.NotNull(getOperationStatus);
        }
    }
}

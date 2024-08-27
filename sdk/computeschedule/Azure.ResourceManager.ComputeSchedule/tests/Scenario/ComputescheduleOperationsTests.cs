// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Scenario
{
    public class ComputescheduleOperationsTests : ComputeScheduleManagementTestBase
    {
        private static readonly string s_resourceGroupName = "computeschedule-netsdktest-rg";
        private static readonly int s_submitOperationsDelayedSeconds = 1;
        private ResourceGroupResource _rg;

        public ComputescheduleOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            try
            {
                if (DefaultResourceGroupResource == null)
                {
                    _rg = await CreateResourceGroupAsync(s_resourceGroupName);
                    return;
                }
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
            int vmCount = 2;

            string vmName = Recording.GenerateAssetName("computeschedule-netsdktest-submitstart-vm");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Schedule schedule = new(DateTimeOffset.UtcNow.AddSeconds(s_submitOperationsDelayedSeconds), "UTC", DeadlineType.InitiateAt);
            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitStartRequest = new SubmitStartContent(schedule, executionParameters, resources, Guid.NewGuid().ToString());

            // Act
            // SubmitStart
            var subId = DefaultSubscription.Id.Name;
            StartResourceOperationResponse submitStartResult = await TestSubmitStartAsync(Location, submitStartRequest, subId);

            // Put polling logic here
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var allOperationIds = submitStartResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Guid.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, Guid.NewGuid().ToString());
            }).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(submitStartResult);
            Assert.NotNull(getOperationStatus);
        }
    }
}

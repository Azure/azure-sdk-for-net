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
        private static readonly int s_submitOperationsDelayedSeconds = 1;
        private static readonly int s_cancelOperationsDelayedDays = 5;
        private static readonly List<OperationState> s_terminalList = new() { OperationState.Succeeded, OperationState.Failed, OperationState.Cancelled };

        public ComputescheduleOperationsTests(bool isAsync)
            : base(isAsync)
                  //, RecordedTestMode.Record)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task TestSubmitStartOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("substart");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Schedule schedule = new(Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds) , "UTC", DeadlineType.InitiateAt);
            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitStartRequest = new SubmitStartContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitStart
            var subId = DefaultSubscription.Id.Name;
            StartResourceOperationResponse submitStartResult = await TestSubmitStartAsync(Location, submitStartRequest, subId, Client);

            // Put polling logic here: GetOperationsStatus
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var allOperationIds = submitStartResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Assert results are returned
            Assert.NotNull(submitStartResult);
            Assert.NotNull(getOperationStatus);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.Contains(result.Operation.State, s_terminalList);
                Assert.AreEqual(result.Operation.SubscriptionId, subId);
            }
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task TestSubmitDeallocateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("subdeall");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Schedule schedule = new(Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds), "UTC", DeadlineType.InitiateAt);
            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitDeallocateRequest = new SubmitDeallocateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitDeallocate
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResponse submitDeallocateResult = await TestSubmitDeallocateAsync(Location, submitDeallocateRequest, subId, Client);

            // Put polling logic here: GetOperationsStatus
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var allOperationIds = submitDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Assert results are returned
            Assert.NotNull(submitDeallocateResult);
            Assert.NotNull(getOperationStatus);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.Contains(result.Operation.State, s_terminalList);
                Assert.AreEqual(result.Operation.SubscriptionId, subId);
            }
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task TestSubmitHibernateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("subhib");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Schedule schedule = new(Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds), "UTC", DeadlineType.InitiateAt);
            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitHibernateRequest = new SubmitHibernateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Submit Hibernate
            var subId = DefaultSubscription.Id.Name;
            HibernateResourceOperationResponse submitHibernateResult = await TestSubmitHibernateAsync(Location, submitHibernateRequest, subId, Client);

            // Put polling logic here: GetOperationsStatus
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var allOperationIds = submitHibernateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Assert results are returned
            Assert.NotNull(submitHibernateResult);
            Assert.NotNull(getOperationStatus);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.Contains(result.Operation.State, s_terminalList);
                Assert.AreEqual(result.Operation.SubscriptionId, subId);
            }
        }

        [TestCase, Order(4)]
        [RecordedTest]
        public async Task TestExecuteHibernateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("exeHib");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeHibernateRequest = new ExecuteHibernateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Hibernate
            var subId = DefaultSubscription.Id.Name;
            HibernateResourceOperationResponse executeHibernateResult = await TestExecuteHibernateAsync(Location, executeHibernateRequest, subId, Client);

            // Put polling logic here: GetOperationsStatus
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var allOperationIds = executeHibernateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Assert results are returned
            Assert.NotNull(executeHibernateResult);
            Assert.NotNull(getOperationStatus);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.Contains(result.Operation.State, s_terminalList);
                Assert.AreEqual(result.Operation.SubscriptionId, subId);
            }
        }

        [TestCase, Order(5)]
        [RecordedTest]
        public async Task TestExecuteDeallocateOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("exeDeall");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeDeallocateRequest = new ExecuteDeallocateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Deallocate
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResponse executeDeallocateResult = await TestExecuteDeallocateAsync(Location, executeDeallocateRequest, subId, Client);

            // Put polling logic here: GetOperationsStatus
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var allOperationIds = executeDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Assert results are returned
            Assert.NotNull(executeDeallocateResult);
            Assert.NotNull(getOperationStatus);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.Contains(result.Operation.State, s_terminalList);
                Assert.AreEqual(result.Operation.SubscriptionId, subId);
            }
        }

        [TestCase, Order(6)]
        [RecordedTest]
        public async Task TestExecuteStartOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("exesta");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeStartRequest = new ExecuteStartContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Start
            var subId = DefaultSubscription.Id.Name;
            StartResourceOperationResponse executeStartResult = await TestExecuteStartAsync(Location, executeStartRequest, subId, Client);

            // Put polling logic here: GetOperationsStatus
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var allOperationIds = executeStartResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Assert results are returned
            Assert.NotNull(executeStartResult);
            Assert.NotNull(getOperationStatus);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.Contains(result.Operation.State, s_terminalList);
                Assert.AreEqual(result.Operation.SubscriptionId, subId);
            }
        }

        [TestCase, Order(7)]
        [RecordedTest]
        public async Task TestCancelScheduledOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("cancops");

            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Schedule schedule = new(Recording.Now.AddDays(s_cancelOperationsDelayedDays), "UTC", DeadlineType.InitiateAt);
            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitDeallocateRequest = new SubmitDeallocateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitDeallocate: Schedule a deallocate op in the future
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResponse submitDeallocateResult = await TestSubmitDeallocateAsync(Location, submitDeallocateRequest, subId, Client);

            var allOperationIds = submitDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();

            // Cancel the scheduled operation
            CancelOperationsContent cancelOperationsContent = new(allOperationIds, Recording.Random.NewGuid().ToString());
            CancelOperationsResponse canceloperationsResponse = await TestCancelOpsAsync(Location, cancelOperationsContent, subId, Client);

            // Put polling logic here: GetOperationsStatus
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Assert results are returned
            Assert.NotNull(submitDeallocateResult);
            Assert.NotNull(canceloperationsResponse);
            Assert.NotNull(getOperationStatus);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.AreEqual(result.Operation.State, OperationState.Cancelled);
                Assert.NotNull(result.Operation.ResourceOperationError);
                Assert.AreEqual(result.Operation.ResourceOperationError.ErrorCode, "OperationCancelledByUser");
            }
        }

        [TestCase, Order(8)]
        [RecordedTest]
        public async Task TestGetOperationsErrors()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("opserr");
            List<VirtualMachineResource> allVms = GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount).Result;

            var allResourceids = allVms.Select(vm => vm.Id).ToList();

            Models.Resources resources = new(allResourceids);
            ExecutionParameters executionParameters = new() { RetryPolicy = new RetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeDeallocateRequest = new ExecuteDeallocateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // ExecuteDeallocate
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResponse executeDeallocateResult = await TestExecuteDeallocateAsync(Location, executeDeallocateRequest, subId, Client);

            var allOperationIds = executeDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();

            // Polling
            GetOperationStatusResponse getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
            {
                // GetOps status
                var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
            }).GetAwaiter().GetResult();

            // Get operation errors if any
            GetOperationErrorsContent getOperationsErrorsRequest = new(allOperationIds);
            GetOperationErrorsResponse getOperationsErrorsResponse = await TestGetOperationErrorsAsync(Location, getOperationsErrorsRequest, subId, Client);

            // Assert results are returned
            Assert.NotNull(executeDeallocateResult);
            Assert.NotNull(getOperationStatus);
            Assert.NotNull(getOperationsErrorsResponse);

            foreach (ResourceOperation result in getOperationStatus.Results)
            {
                Assert.Contains(result.Operation.State, s_terminalList);
                Assert.AreEqual(result.Operation.SubscriptionId, subId);
            }
        }
    }
}

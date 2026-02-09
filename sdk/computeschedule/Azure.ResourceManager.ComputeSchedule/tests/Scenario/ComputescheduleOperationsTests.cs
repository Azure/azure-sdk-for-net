// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.ComputeSchedule.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Scenario
{
    public class ComputescheduleOperationsTests : ComputeScheduleManagementTestBase
    {
        private static readonly int s_cancelOperationsDelayedDays = 5;
        public ComputescheduleOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        private static readonly int s_submitOperationsDelayedSeconds = 1;
        private static readonly List<ScheduledActionOperationState> s_terminalList = [ScheduledActionOperationState.Succeeded, ScheduledActionOperationState.Failed, ScheduledActionOperationState.Cancelled];

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task TestSubmitStartOperations()
        {
            int vmCount = 1;
            string vmName = Recording.GenerateAssetName("substart");
            List<VirtualMachineResource> allVms = await GenerateMultipleVirtualMachines(vmName, DefaultResourceGroupResource, vmCount);

            var allResourceids = allVms.Select(vm => vm.Id).ToList();
            Console.WriteLine($"Submitting start operations for {vmCount} VMs");
            DateTimeOffset dateTimeOffset = Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds);

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = dateTimeOffset
            };
            UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitStartRequest = new SubmitStartContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitStart
            var subId = DefaultSubscription.Id.Name;
            StartResourceOperationResult submitStartResult = await TestSubmitStartAsync(Location, submitStartRequest, subId, Client);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitStartResult.Results);

            if (validOperationIds.Count > 0)
            {
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    var getOpsStatusReq = new GetOperationStatusContent(validOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                Assert.NotNull(submitStartResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
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

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds)
            };

            UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitDeallocateRequest = new SubmitDeallocateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitDeallocate
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResult submitDeallocateResult = await TestSubmitDeallocateAsync(Location, submitDeallocateRequest, subId, Client);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = submitDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(submitDeallocateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
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

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = Recording.Now.AddSeconds(s_submitOperationsDelayedSeconds)
            };
            UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitHibernateRequest = new SubmitHibernateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Submit Hibernate
            var subId = DefaultSubscription.Id.Name;
            HibernateResourceOperationResult submitHibernateResult = await TestSubmitHibernateAsync(Location, submitHibernateRequest, subId, Client);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitHibernateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = submitHibernateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(submitHibernateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
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

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeHibernateRequest = new ExecuteHibernateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Hibernate
            var subId = DefaultSubscription.Id.Name;
            HibernateResourceOperationResult executeHibernateResult = await TestExecuteHibernateAsync(Location, executeHibernateRequest, subId, Client);
            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeHibernateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = executeHibernateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(executeHibernateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
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

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeDeallocateRequest = new ExecuteDeallocateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Deallocate
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResult executeDeallocateResult = await TestExecuteDeallocateAsync(Location, executeDeallocateRequest, subId, Client);
            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = executeDeallocateResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(executeDeallocateResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
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

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeStartRequest = new ExecuteStartContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // Execute Start
            var subId = DefaultSubscription.Id.Name;
            StartResourceOperationResult executeStartResult = await TestExecuteStartAsync(Location, executeStartRequest, subId, Client);
            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeStartResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var allOperationIds = executeStartResult.Results.Select(result => result.Operation?.OperationId).Where(operationId => !string.IsNullOrEmpty(operationId)).ToList();
                    var getOpsStatusReq = new GetOperationStatusContent(allOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(executeStartResult);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
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

            UserRequestSchedule schedule = new(ScheduledActionDeadlineType.InitiateAt)
            {
                Timezone = "UTC",
                Deadline = Recording.Now.AddDays(s_cancelOperationsDelayedDays)
            };
            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var submitDeallocateRequest = new SubmitDeallocateContent(schedule, executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // SubmitDeallocate: UserRequestSchedule a deallocate op in the future
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResult submitDeallocateResult = await TestSubmitDeallocateAsync(Location, submitDeallocateRequest, subId, Client);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(submitDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Cancel the scheduled operation
                CancelOperationsContent cancelOperationsContent = new(validOperationIds, Recording.Random.NewGuid().ToString());
                CancelOperationsResult canceloperationsResponse = await TestCancelOpsAsync(Location, cancelOperationsContent, subId, Client);

                // Put polling logic here: GetOperationsStatus
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var getOpsStatusReq = new GetOperationStatusContent(validOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                // Assert results are returned
                Assert.NotNull(submitDeallocateResult);
                Assert.NotNull(canceloperationsResponse);
                Assert.NotNull(getOperationStatus);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.AreEqual(result.Operation.State, ScheduledActionOperationState.Cancelled);
                    Assert.NotNull(result.Operation.ResourceOperationError);
                    Assert.AreEqual(result.Operation.ResourceOperationError.ErrorCode, "OperationCancelledByUser");
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
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

            Models.UserRequestResources resources = new(allResourceids);
            ScheduledActionExecutionParameterDetail executionParameters = new() { RetryPolicy = new UserRequestRetryPolicy() { RetryCount = 3, RetryWindowInMinutes = 30 } };

            var executeDeallocateRequest = new ExecuteDeallocateContent(executionParameters, resources, Recording.Random.NewGuid().ToString());

            // Act
            // ExecuteDeallocate
            var subId = DefaultSubscription.Id.Name;
            DeallocateResourceOperationResult executeDeallocateResult = await TestExecuteDeallocateAsync(Location, executeDeallocateRequest, subId, Client);

            HashSet<string> validOperationIds = ExcludeResourcesNotProcessed(executeDeallocateResult.Results);

            if (validOperationIds.Count > 0)
            {
                // Polling
                GetOperationStatusResult getOperationStatus = PollOperationStatus(vmCount).ExecuteAsync(async () =>
                {
                    // GetOps status
                    var getOpsStatusReq = new GetOperationStatusContent(validOperationIds, Recording.Random.NewGuid().ToString());
                    return await TestGetOpsStatusAsync(Location, getOpsStatusReq, subId, Client);
                }).GetAwaiter().GetResult();

                // Get operation errors if any
                GetOperationErrorsContent getOperationsErrorsRequest = new(validOperationIds);
                GetOperationErrorsResult getOperationsErrorsResponse = await TestGetOperationErrorsAsync(Location, getOperationsErrorsRequest, subId, Client);

                // Assert results are returned
                Assert.NotNull(executeDeallocateResult);
                Assert.NotNull(getOperationStatus);
                Assert.NotNull(getOperationsErrorsResponse);

                foreach (ResourceOperationResult result in getOperationStatus.Results)
                {
                    Assert.Contains(result.Operation.State, s_terminalList);
                    Assert.AreEqual(result.Operation.SubscriptionId, subId);
                }
            }
            else
            {
                Assert.Pass("No operations to process.");
            }
        }
    }
}

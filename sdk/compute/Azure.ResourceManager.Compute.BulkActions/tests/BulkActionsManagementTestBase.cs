// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.BulkActions.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.ResourceManager.Compute.BulkActions.Tests
{
    public class BulkActionsManagementTestBase : ManagementRecordedTestBase<BulkActionsManagementTestEnvironment>
    {
        // Terminal states for ScheduledActionOperationState; reaching any of these means the
        // service is done with the operation.
        protected static readonly HashSet<ScheduledActionOperationState> TerminalOperationStates = new()
        {
            ScheduledActionOperationState.Succeeded,
            ScheduledActionOperationState.Failed,
            ScheduledActionOperationState.Cancelled,
            ScheduledActionOperationState.Blocked,
        };

        // Non-terminal "the service accepted the request" states. Used to assert the initial
        // response when we cannot afford to wait for the full InitiateAt deadline (~hours).
        protected static readonly HashSet<ScheduledActionOperationState> AcceptedOperationStates = new()
        {
            ScheduledActionOperationState.PendingScheduling,
            ScheduledActionOperationState.Scheduled,
            ScheduledActionOperationState.PendingExecution,
            ScheduledActionOperationState.Executing,
            ScheduledActionOperationState.Succeeded,
        };

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected ResourceGroupResource DefaultResourceGroup { get; private set; }

        protected AzureLocation Location => new AzureLocation(TestEnvironment.TestLocation);

        protected string PreCreatedResourceGroupName => TestEnvironment.TestResourceGroup;

        protected BulkActionsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected BulkActionsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            DefaultResourceGroup = await DefaultSubscription
                .GetResourceGroups()
                .GetAsync(PreCreatedResourceGroupName)
                .ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        // Returns the resource IDs of the pre-created VMs in the test RG that the recording guide
        // expects (bulkactions-sdkrec-vm-1 .. -vm-5). Each test targets its own dedicated VM(s) so
        // a still-Executing bulk operation from one test never blocks (OperationConflict) the next
        // one running against the same VM. IDs are assembled statically from env vars so we do not
        // depend on a list VMs call (which would add unnecessary noise to recordings).
        protected IList<ResourceIdentifier> GetPreCreatedVmIds(params int[] indexes)
        {
            var ids = new List<ResourceIdentifier>(indexes.Length);
            foreach (int i in indexes)
            {
                ids.Add(new ResourceIdentifier(
                    $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{PreCreatedResourceGroupName}/providers/Microsoft.Compute/virtualMachines/bulkactions-sdkrec-vm-{i}"));
            }
            return ids;
        }

        protected static ExecuteStartContent BuildStartContent(IList<ResourceIdentifier> ids) =>
            new ExecuteStartContent(BuildExecutionParameters(), new UserRequestResources(ids));

        protected static ExecuteDeallocateContent BuildDeallocateContent(IList<ResourceIdentifier> ids) =>
            new ExecuteDeallocateContent(BuildExecutionParameters(), new UserRequestResources(ids));

        protected static ExecuteHibernateContent BuildHibernateContent(IList<ResourceIdentifier> ids) =>
            new ExecuteHibernateContent(BuildExecutionParameters(), new UserRequestResources(ids));

        protected static ExecuteDeleteContent BuildDeleteContent(IList<ResourceIdentifier> ids, bool forceDelete = false) =>
            new ExecuteDeleteContent(BuildExecutionParameters(), new UserRequestResources(ids)) { IsForceDeletion = forceDelete };

        // Builds execution parameters with a representative retry policy so recordings exercise a
        // realistic request shape.
        private static ScheduledActionExecutionParameterDetail BuildExecutionParameters() =>
            new ScheduledActionExecutionParameterDetail
            {
                RetryPolicy = new BulkOperationRetryPolicy { RetryCount = 3, RetryWindowInMinutes = 30 }
            };

        // Extracts non-empty operation IDs from a bulk action response, filtering out any result
        // entries the service rejected up-front (e.g. resource not found).
        protected static IList<string> ExtractOperationIds(IEnumerable<ComputeBulkOperationResult> results)
        {
            return results
                .Where(r => string.IsNullOrEmpty(r.ErrorCode) && !string.IsNullOrEmpty(r.Operation?.OperationId))
                .Select(r => r.Operation.OperationId)
                .ToList();
        }

        // Polls BulkGetOperationsStatus on a fixed interval until either every supplied operation
        // satisfies stopCondition, or maxWait elapses. Returns the last status snapshot regardless.
        // In Playback the delay is skipped so recorded polls replay instantly.
        protected async Task<GetBulkOperationStatusResult> PollUntilAsync(
            IEnumerable<string> operationIds,
            Func<ComputeBulkOperationResult, bool> stopCondition,
            TimeSpan maxWait,
            TimeSpan? pollInterval = null)
        {
            var interval = pollInterval ?? TimeSpan.FromSeconds(15);
            var ids = operationIds as IList<string> ?? operationIds.ToList();
            var deadline = DateTimeOffset.UtcNow + maxWait;
            GetBulkOperationStatusResult last = null;

            while (true)
            {
                var content = new GetBulkOperationStatusContent(ids);
                var response = await DefaultResourceGroup
                    .BulkGetOperationsStatusAsync(Location, content)
                    .ConfigureAwait(false);
                last = response.Value;

                if (last.Results.Count > 0 && last.Results.All(stopCondition))
                {
                    return last;
                }

                if (DateTimeOffset.UtcNow >= deadline)
                {
                    return last;
                }

                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(interval).ConfigureAwait(false);
                }
            }
        }

        // Stop once every operation has progressed past the initial PendingScheduling state.
        // This proves the service actually scheduled the work without forcing us to wait for the
        // (potentially long) execution to finish.
        protected Task<GetBulkOperationStatusResult> PollUntilProgressedAsync(
            IEnumerable<string> operationIds,
            TimeSpan maxWait,
            TimeSpan? pollInterval = null) =>
            PollUntilAsync(
                operationIds,
                r => r.Operation?.State.HasValue == true
                     && r.Operation.State.Value != ScheduledActionOperationState.PendingScheduling,
                maxWait,
                pollInterval);

        // Stop once every operation reaches a terminal state.
        protected Task<GetBulkOperationStatusResult> PollUntilTerminalAsync(
            IEnumerable<string> operationIds,
            TimeSpan maxWait,
            TimeSpan? pollInterval = null) =>
            PollUntilAsync(
                operationIds,
                r => r.Operation?.State.HasValue == true
                     && TerminalOperationStates.Contains(r.Operation.State.Value),
                maxWait,
                pollInterval);

        // Validates that each result entry in a bulk action response carries the expected per-resource
        // metadata: no service-side error, a non-null Operation with an OperationId, a deadline set
        // within reasonable bounds, and an initial state the service considers "accepted".
        protected static void AssertBulkResponseAccepted(
            IEnumerable<ComputeBulkOperationResult> results,
            ComputeBulkOperationType expectedOpType,
            int expectedCount)
        {
            var list = results.ToList();
            ClassicAssert.AreEqual(expectedCount, list.Count, "Unexpected result count in bulk action response.");

            foreach (var r in list)
            {
                ClassicAssert.IsNull(r.ErrorCode, $"Service returned per-resource error code {r.ErrorCode} for {r.ResourceId}: {r.ErrorDetails}");
                ClassicAssert.IsNotNull(r.Operation, $"Operation block missing for resource {r.ResourceId}.");
                ClassicAssert.IsFalse(string.IsNullOrWhiteSpace(r.Operation.OperationId), $"OperationId missing for {r.ResourceId}.");
                ClassicAssert.IsNotNull(r.Operation.State, $"Initial State missing for {r.ResourceId}.");
                ClassicAssert.IsTrue(
                    AcceptedOperationStates.Contains(r.Operation.State.Value),
                    $"Initial state for {r.ResourceId} was {r.Operation.State} (expected one of {string.Join(",", AcceptedOperationStates)}).");
                ClassicAssert.AreEqual(expectedOpType, r.Operation.OperationType, $"OperationType mismatch for {r.ResourceId}.");

                if (r.Operation.DeadlineOn.HasValue)
                {
                    ClassicAssert.AreEqual(ScheduledActionDeadlineType.InitiateAt, r.Operation.DeadlineType,
                        $"Unexpected DeadlineType for {r.ResourceId}.");
                }
            }
        }
    }
}

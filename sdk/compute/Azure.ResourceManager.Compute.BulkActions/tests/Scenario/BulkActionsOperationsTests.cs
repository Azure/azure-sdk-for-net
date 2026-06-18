// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.BulkActions.Models;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.ResourceManager.Compute.BulkActions.Tests.Scenario
{
    public class BulkActionsOperationsTests : BulkActionsManagementTestBase
    {
        // Each bulk action call sets InitiateAt=now on the service side, so the scheduler picks
        // the operations up within seconds. Poll long enough to see every operation transition
        // past PendingScheduling without waiting for the (potentially slow) terminal state.
        private static readonly TimeSpan ProgressPollWindow = TimeSpan.FromMinutes(2);
        private static readonly TimeSpan CancelPollWindow = TimeSpan.FromMinutes(2);
        private static readonly TimeSpan PollInterval = TimeSpan.FromSeconds(10);

        public BulkActionsOperationsTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1), RecordedTest]
        public async Task TestBulkStartOperation()
        {
            var ids = GetPreCreatedVmIds(1);
            var content = BuildStartContent(ids);

            var response = await DefaultResourceGroup.BulkStartOperationAsync(Location, content);
            var result = response.Value;

            ClassicAssert.AreEqual(Location.ToString(), result.Location.ToString());
            AssertBulkResponseAccepted(result.Results, ComputeBulkOperationType.Start, ids.Count);

            var opIds = ExtractOperationIds(result.Results);
            ClassicAssert.AreEqual(ids.Count, opIds.Count, "Expected one operation id per resource.");
            var status = await PollUntilProgressedAsync(opIds, ProgressPollWindow, PollInterval);
            AssertEveryOpProgressedPastPending(status, ComputeBulkOperationType.Start, DefaultSubscription.Id.Name);
        }

        [TestCase, Order(2), RecordedTest]
        public async Task TestBulkDeallocateOperation()
        {
            var ids = GetPreCreatedVmIds(2);
            var content = BuildDeallocateContent(ids);

            var response = await DefaultResourceGroup.BulkDeallocateOperationAsync(Location, content);
            var result = response.Value;

            ClassicAssert.AreEqual(Location.ToString(), result.Location.ToString());
            AssertBulkResponseAccepted(result.Results, ComputeBulkOperationType.Deallocate, ids.Count);

            var opIds = ExtractOperationIds(result.Results);
            ClassicAssert.AreEqual(ids.Count, opIds.Count);
            var status = await PollUntilProgressedAsync(opIds, ProgressPollWindow, PollInterval);
            AssertEveryOpProgressedPastPending(status, ComputeBulkOperationType.Deallocate, DefaultSubscription.Id.Name);
        }

        [TestCase, Order(3), RecordedTest]
        public async Task TestBulkHibernateOperation()
        {
            var ids = GetPreCreatedVmIds(3);
            var content = BuildHibernateContent(ids);

            var response = await DefaultResourceGroup.BulkHibernateOperationAsync(Location, content);
            var result = response.Value;

            ClassicAssert.AreEqual(Location.ToString(), result.Location.ToString());
            AssertBulkResponseAccepted(result.Results, ComputeBulkOperationType.Hibernate, ids.Count);

            var opIds = ExtractOperationIds(result.Results);
            ClassicAssert.AreEqual(ids.Count, opIds.Count);
            var status = await PollUntilProgressedAsync(opIds, ProgressPollWindow, PollInterval);
            AssertEveryOpProgressedPastPending(status, ComputeBulkOperationType.Hibernate, DefaultSubscription.Id.Name);
        }

        [TestCase, Order(4), RecordedTest]
        public async Task TestBulkGetOperationsStatus()
        {
            // Seed a fresh Start so we have known operation IDs to query, then call GetStatus
            // directly. This isolates the GetStatus contract: shape, mapping to operation IDs,
            // and round-trip echo of OperationType/State.
            var ids = GetPreCreatedVmIds(4);
            var startResponse = await DefaultResourceGroup.BulkStartOperationAsync(Location, BuildStartContent(ids));
            var opIds = ExtractOperationIds(startResponse.Value.Results);
            ClassicAssert.AreEqual(ids.Count, opIds.Count, "Seeding Start did not return one operation per resource.");

            var statusResponse = await DefaultResourceGroup.BulkGetOperationsStatusAsync(
                Location,
                new GetBulkOperationStatusContent(opIds));
            var status = statusResponse.Value;

            ClassicAssert.AreEqual(opIds.Count, status.Results.Count);
            var returnedIds = new HashSet<string>(status.Results.Select(r => r.Operation?.OperationId));
            foreach (var id in opIds)
            {
                ClassicAssert.IsTrue(returnedIds.Contains(id), $"GetStatus did not echo operation id {id}.");
            }
            foreach (var r in status.Results)
            {
                ClassicAssert.IsNotNull(r.Operation?.State, $"State missing for {r.ResourceId}.");
                ClassicAssert.AreEqual(ComputeBulkOperationType.Start, r.Operation.OperationType);
                ClassicAssert.AreEqual(DefaultSubscription.Id.Name, r.Operation.SubscriptionId, $"SubscriptionId mismatch for {r.ResourceId}.");
            }
        }

        [TestCase, Order(5), RecordedTest]
        public async Task TestBulkCancelOperations()
        {
            // Schedule a Deallocate, immediately cancel, then poll until the service reports
            // every op as Cancelled. The cancel transition is fast, so this validation runs
            // within the recording budget.
            var ids = GetPreCreatedVmIds(5);
            var seedResponse = await DefaultResourceGroup.BulkDeallocateOperationAsync(Location, BuildDeallocateContent(ids));
            var opIds = ExtractOperationIds(seedResponse.Value.Results);
            ClassicAssert.AreEqual(ids.Count, opIds.Count, "Seeding Deallocate did not return one operation per resource.");

            var cancelResponse = await DefaultResourceGroup.BulkCancelOperationsAsync(
                Location,
                new CancelBulkOperationsContent(opIds));
            var cancel = cancelResponse.Value;
            ClassicAssert.AreEqual(opIds.Count, cancel.Results.Count);
            foreach (var r in cancel.Results)
            {
                ClassicAssert.IsNull(r.ErrorCode, $"Cancel returned error for {r.ResourceId}: {r.ErrorDetails}");
                ClassicAssert.IsNotNull(r.Operation, $"Cancel result missing Operation for {r.ResourceId}.");
            }

            var status = await PollUntilTerminalAsync(opIds, CancelPollWindow, PollInterval);
            ClassicAssert.AreEqual(opIds.Count, status.Results.Count);
            foreach (var r in status.Results)
            {
                ClassicAssert.IsNotNull(r.Operation?.State, $"State missing for {r.ResourceId} after cancel.");
                ClassicAssert.IsTrue(
                    TerminalOperationStates.Contains(r.Operation.State.Value),
                    $"After cancel, expected a terminal state for {r.ResourceId} but got {r.Operation.State}.");
                ClassicAssert.AreEqual(
                    ScheduledActionOperationState.Cancelled,
                    r.Operation.State.Value,
                    $"Expected Cancelled for {r.ResourceId} but got {r.Operation.State}.");
                ClassicAssert.AreEqual(DefaultSubscription.Id.Name, r.Operation.SubscriptionId, $"SubscriptionId mismatch for {r.ResourceId}.");
                ClassicAssert.IsNotNull(r.Operation.Error, $"Cancelled operation for {r.ResourceId} is missing an Error block.");
                ClassicAssert.AreEqual(
                    "OperationCancelledByUser",
                    r.Operation.Error.ErrorCode,
                    $"Unexpected cancel error code for {r.ResourceId}: {r.Operation.Error.ErrorDetails}");
            }
        }

        [TestCase, Order(6), RecordedTest]
        public async Task TestBulkDeleteOperation()
        {
            // Reuses vm-5 (the Cancel test's VM): Cancel drives its operation to a terminal
            // Cancelled state before this test runs, so vm-5 is free of any in-flight operation.
            var ids = GetPreCreatedVmIds(5);
            var content = BuildDeleteContent(ids, forceDelete: false);

            var response = await DefaultResourceGroup.BulkDeleteOperationAsync(Location, content);
            var result = response.Value;

            ClassicAssert.AreEqual(Location.ToString(), result.Location.ToString());
            AssertBulkResponseAccepted(result.Results, ComputeBulkOperationType.Delete, ids.Count);

            var opIds = ExtractOperationIds(result.Results);
            ClassicAssert.AreEqual(ids.Count, opIds.Count);
            var status = await PollUntilProgressedAsync(opIds, ProgressPollWindow, PollInterval);
            AssertEveryOpProgressedPastPending(status, ComputeBulkOperationType.Delete, DefaultSubscription.Id.Name);
        }

        // Validates the poll result: every operation in the response moved past PendingScheduling
        // (which proves the service actually scheduled the work) and carries the expected opType.
        private static void AssertEveryOpProgressedPastPending(
            GetBulkOperationStatusResult status,
            ComputeBulkOperationType expectedOpType,
            string expectedSubscriptionId)
        {
            ClassicAssert.IsNotNull(status, "Poll returned no status.");
            ClassicAssert.Greater(status.Results.Count, 0, "Poll returned an empty Results array.");
            foreach (var r in status.Results)
            {
                ClassicAssert.IsNotNull(r.Operation?.State, $"State missing for {r.ResourceId} after polling.");
                ClassicAssert.AreNotEqual(
                    ScheduledActionOperationState.PendingScheduling,
                    r.Operation.State.Value,
                    $"Operation {r.Operation.OperationId} for {r.ResourceId} never progressed past PendingScheduling.");
                ClassicAssert.AreEqual(expectedOpType, r.Operation.OperationType, $"OperationType mismatch for {r.ResourceId}.");
                ClassicAssert.AreEqual(expectedSubscriptionId, r.Operation.SubscriptionId, $"SubscriptionId mismatch for {r.ResourceId}.");
            }
        }
    }
}

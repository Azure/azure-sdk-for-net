// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.ComputeSchedule.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Scenario
{
    public class RecurringScheduledActionsTests : ComputeScheduleManagementTestBase
    {
        private static readonly TimeSpan s_startScheduleTime = new(19, 0, 0);

        public RecurringScheduledActionsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
        }

        #region Tests
        [TestCase, Order(1)]
        [RecordedTest]
        public async Task TestRecurringScheduledAction_Create()
        {
            string scheduledActionName = Recording.GenerateAssetName("create");
            try
            {
                ScheduledAction sa = await CreateAndValidateScheduledAction(scheduledActionName, s_startScheduleTime);
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
            finally
            {
                // delete AA
                await DeleteScheduledAction(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource, false);
            }
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task TestRecurringScheduledAction_AttachDetach()
        {
            ScheduledAction sa = await CreateAndValidateScheduledAction("crud-aa-", s_startScheduleTime);
            var scheduledActionName = sa.Name;

            List<ResourceIdentifier> allResourceids = [.. GetTestResourceIdentifiers(DefaultSubscription.Id.Name, DefaultResourceGroupResource.Data.Name)];
            Console.WriteLine($"Generated vmIds: {allResourceids.FormatCollection()} VMs");

            try
            {
                // attach
                ScheduledActionResource[] res = RecurringScheduledActionUtils.GenerateResources(allResourceids);
                ResourceAttachContent attachContent = new(res);
                RecurringActionsResourceOperationResult attachResult = await DefaultResourceGroupResource.AttachResourcesScheduledActionAsync(scheduledActionName, attachContent);

                Assert.NotNull(attachResult);
                foreach (ResourceStatus attachRes in attachResult.ResourcesStatuses)
                {
                    Assert.IsTrue(attachRes.Status.Equals(ResourceOperationStatus.Succeeded));
                }

                //detach
                ResourceDetachContent detachContent = new([allResourceids[0]]);
                RecurringActionsResourceOperationResult detachResult = await DefaultResourceGroupResource.DetachResourcesScheduledActionAsync(scheduledActionName, detachContent);

                Assert.NotNull(detachResult);
                foreach (ResourceStatus detachRes in detachResult.ResourcesStatuses)
                {
                    Assert.IsTrue(detachRes.Status.Equals(ResourceOperationStatus.Succeeded));
                }
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
            finally
            {
                // delete AA
                await DeleteScheduledAction(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource, false);
            }
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task TestRecurringScheduledAction_EnableDisable()
        {
            ScheduledAction sa = await CreateAndValidateScheduledAction("en-dis-aa-", s_startScheduleTime);
            var scheduledActionName = sa.Name;
            try
            {
                // enable
                await DefaultResourceGroupResource.EnableScheduledActionAsync(scheduledActionName);

                // check enabled
                Response<ScheduledAction> saAfterEnable = await GetScheduledActions(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource);

                if (saAfterEnable != null)
                {
                    Assert.False(saAfterEnable.Value.Properties.Disabled);
                }

                // disable
                await DefaultResourceGroupResource.DisableScheduledActionAsync(scheduledActionName);

                // check disabled
                Response<ScheduledAction> saAfterDisable = await GetScheduledActions(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource);

                if (saAfterDisable != null)
                {
                    Assert.True(saAfterDisable.Value.Properties.Disabled);
                }
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
            finally
            {
                // delete AA
                await DeleteScheduledAction(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource, false);
            }
        }

        [TestCase, Order(4)]
        [RecordedTest]
        public async Task TestRecurringScheduledAction_CancelNextOccurrence()
        {
            var resourceIds = GetTestResourceIdentifiers(DefaultSubscription.Id.Name, DefaultResourceGroupResource.Data.Name).ToList();
            var scheduledAction = await CreateAndValidateScheduledAction("ca-nx-", s_startScheduleTime, isDisabled: false);
            var scheduledActionName = scheduledAction.Name;

            try
            {
                ScheduledActionResource[] resourcesToAttach = RecurringScheduledActionUtils.GenerateResources(resourceIds);
                var attachContent = new ResourceAttachContent(resourcesToAttach);
                Response<RecurringActionsResourceOperationResult> attachResult = await DefaultResourceGroupResource.AttachResourcesScheduledActionAsync(scheduledActionName, attachContent);

                Assert.NotNull(attachResult);
                foreach (ResourceStatus status in attachResult.Value.ResourcesStatuses)
                {
                    Assert.IsTrue(status.Status == ResourceOperationStatus.Succeeded);
                }

                await Task.Delay(Recording.Random.Next(900, 1000));

                OccurrenceCollection occurrences = DefaultResourceGroupResource.GetOccurrences(scheduledActionName);
                var occurrenceList = new List<OccurrenceResource>();

                await foreach (OccurrenceResource occurrence in occurrences.GetAllAsync())
                {
                    occurrenceList.Add(occurrence);
                }

                if (occurrenceList.Count > 0)
                {
                    // Cancel the next occurrence
                    await DefaultResourceGroupResource.CancelNextOccurrenceScheduledActionAsync(scheduledActionName, new(resourceIds: []));

                    // Retrieve updated occurrences
                    OccurrenceCollection updatedOccurrences = DefaultResourceGroupResource.GetOccurrences(scheduledActionName);
                    var updatedOccurrenceList = new List<OccurrenceResource>();

                    await foreach (OccurrenceResource occurrence in updatedOccurrences.GetAllAsync())
                    {
                        updatedOccurrenceList.Add(occurrence);
                    }

                    var sortedOccurrences = updatedOccurrenceList.OrderBy(o => o.Data.Properties.ScheduledOn).ToList();
                    OccurrenceResource firstOccurrence = sortedOccurrences.FirstOrDefault();

                    Assert.IsTrue(firstOccurrence?.Data.Properties.ProvisioningState == OccurrenceState.Canceled, "Occurrence is not cancelled as expected.");
                }
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
            finally
            {
                await DeleteScheduledAction(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource, false);
            }
        }

        [TestCase, Order(5)]
        [RecordedTest]
        public async Task TestRecurringScheduledAction_TriggerManualOccurrence()
        {
            var resourceIds = GetTestResourceIdentifiers(DefaultSubscription.Id.Name, DefaultResourceGroupResource.Data.Name).ToList();
            var scheduledAction = await CreateAndValidateScheduledAction("ca-tr-", s_startScheduleTime, isDisabled: false);
            var scheduledActionName = scheduledAction.Name;

            try
            {
                ScheduledActionResource[] resourcesToAttach = RecurringScheduledActionUtils.GenerateResources(resourceIds);
                var attachContent = new ResourceAttachContent(resourcesToAttach);
                Response<RecurringActionsResourceOperationResult> attachResult = await DefaultResourceGroupResource.AttachResourcesScheduledActionAsync(scheduledActionName, attachContent);

                Assert.NotNull(attachResult);
                foreach (ResourceStatus status in attachResult.Value.ResourcesStatuses)
                {
                    Assert.IsTrue(status.Status == ResourceOperationStatus.Succeeded);
                }

                await Task.Delay(Recording.Random.Next(900, 1000));

                OccurrenceCollection occurrences = DefaultResourceGroupResource.GetOccurrences(scheduledActionName);
                var occurrenceList = new List<OccurrenceResource>();

                await foreach (OccurrenceResource occurrence in occurrences.GetAllAsync())
                {
                    occurrenceList.Add(occurrence);
                }

                if (occurrenceList.Count > 0)
                {
                    // Trigger a manual occurrence
                    Response<OccurrenceResource> triggeredOccurrence = await DefaultResourceGroupResource.TriggerManualOccurrenceScheduledActionAsync(scheduledActionName);

                    Assert.IsTrue(triggeredOccurrence.Value.Data.Properties.ProvisioningState != OccurrenceState.Scheduled);

                    RecurringScheduledActionUtils.ValidateTriggeredOccurrence(triggeredOccurrence.Value.Data, scheduledActionName);
                }
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
            finally
            {
                await DeleteScheduledAction(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource, false);
            }
        }

        [TestCase, Order(6)]
        [RecordedTest]
        public async Task TestRecurringScheduledAction_CancelOccurrence()
        {
            List<ResourceIdentifier> allResourceids = GetTestResourceIdentifiers(DefaultSubscription.Id.Name, DefaultResourceGroupResource.Data.Name).ToList();
            ScheduledAction sa = await CreateAndValidateScheduledAction("cat-aa-", s_startScheduleTime, isDisabled: false);
            var scheduledActionName = sa.Name;

            try
            {
                // attach
                ScheduledActionResource[] res = RecurringScheduledActionUtils.GenerateResources(allResourceids);
                ResourceAttachContent attachContent = new(res);
                RecurringActionsResourceOperationResult attachResult = await DefaultResourceGroupResource.AttachResourcesScheduledActionAsync(scheduledActionName, attachContent);

                Assert.NotNull(attachResult);
                foreach (ResourceStatus attachRes in attachResult.ResourcesStatuses)
                {
                    Assert.IsTrue(attachRes.Status.Equals(ResourceOperationStatus.Succeeded));
                }

                await Task.Delay(Recording.Random.Next(1000, 2000));
                OccurrenceCollection occurrences = DefaultResourceGroupResource.GetOccurrences(scheduledActionName);

                var occurrenceList = new List<OccurrenceResource>();

                await foreach (OccurrenceResource item in occurrences.GetAllAsync())
                {
                    occurrenceList.Add(item);
                }

                if (occurrenceList.Count > 0)
                {
                    IOrderedEnumerable<OccurrenceResource> sortedOccurrences = occurrenceList.OrderBy(o => o.Data.Properties.ScheduledOn);

                    await CancelOccurrenceTask(sortedOccurrences.First(), allResourceids, scheduledActionName, OccurrenceState.Scheduled, "RsScheduled");

                    await CancelOccurrenceTask(sortedOccurrences.Last(), allResourceids, scheduledActionName, OccurrenceState.Created, "RsCreated");
                }
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
            finally
            {
                // delete AA
                await DeleteScheduledAction(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource, false);
            }
        }

        [TestCase, Order(7)]
        [RecordedTest]
        public async Task TestRecurringScheduledAction_DelayOccurrence()
        {
            List<ResourceIdentifier> allResourceids = GetTestResourceIdentifiers(DefaultSubscription.Id.Name, DefaultResourceGroupResource.Data.Name).ToList();
            ScheduledAction sa = await CreateAndValidateScheduledAction("del-sch-", s_startScheduleTime, isDisabled: false);
            var scheduledActionName = sa.Name;
            try
            {
                // attach
                ScheduledActionResource[] res = RecurringScheduledActionUtils.GenerateResources(allResourceids);
                ResourceAttachContent attachContent = new(res);
                RecurringActionsResourceOperationResult attachResult = await DefaultResourceGroupResource.AttachResourcesScheduledActionAsync(scheduledActionName, attachContent);

                Assert.NotNull(attachResult);
                foreach (ResourceStatus attachRes in attachResult.ResourcesStatuses)
                {
                    Assert.IsTrue(attachRes.Status.Equals(ResourceOperationStatus.Succeeded));
                }

                await Task.Delay(Recording.Random.Next(1000, 2000));
                OccurrenceCollection occurrences = DefaultResourceGroupResource.GetOccurrences(scheduledActionName);
                var occurrenceList = new List<OccurrenceResource>();
                await foreach (OccurrenceResource item in occurrences.GetAllAsync())
                {
                    occurrenceList.Add(item);
                }

                if (occurrenceList.Count > 0)
                {
                    IOrderedEnumerable<OccurrenceResource> sortedOccurrences = occurrenceList.OrderBy(o => o.Data.Properties.ScheduledOn);

                    await DelayOccurrenceTask(sortedOccurrences.First(), allResourceids, scheduledActionName, OccurrenceState.Scheduled, "RsScheduled");
                    await DelayOccurrenceTask(sortedOccurrences.Last(), allResourceids, scheduledActionName, OccurrenceState.Created, "RsCreated");
                }
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
            finally
            {
                // delete AA
                await DeleteScheduledAction(DefaultSubscription.Id.Name, Client, scheduledActionName, DefaultResourceGroupResource, false);
            }
        }
        #endregion

        #region Private methods
        private static HashSet<ResourceIdentifier> GetTestResourceIdentifiers(string subId, string resourceGroupName)
        {
            var vmNames = new[] { "crud-vm66690", "crud-vm4060" };
            IEnumerable<ResourceIdentifier> resourceIds = vmNames.Select(vmName =>
                new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}")
            );
            return [.. resourceIds];
        }

        private async Task CancelOccurrenceTask(OccurrenceResource occ, List<ResourceIdentifier> resources, string scheduledActionName, OccurrenceState occurrenceStateConfirm, string resourceStateConfirm)
        {
            await occ.CancelAsync(new(resourceIds: [resources[0]]));

            // Validate cancel
            OccurrenceResource cancelledOcc = await DefaultResourceGroupResource.GetOccurrences(scheduledActionName).GetAsync(occ.Data.Name);
            Assert.NotNull(cancelledOcc);
            Assert.True(cancelledOcc.Data.Properties.ProvisioningState == occurrenceStateConfirm);

            List<Models.OccurrenceResource> occResources = [];

            // get the resources from the cancelled occurrence
            await foreach (Models.OccurrenceResource item in cancelledOcc.GetResourcesAsync())
            {
                occResources.Add(item);
            }

            // get the min time of the resources in the occurrence
            DateTimeOffset minTime = occResources.Select(item => item.ScheduledOn).Min();
            Assert.AreEqual(cancelledOcc.Data.Properties.ScheduledOn, minTime);

            foreach (Models.OccurrenceResource item in occResources)
            {
                if (item.ResourceId == resources[0])
                {
                    Assert.AreEqual(item.ProvisioningState.ToString(), "RsCanceled");
                }
                else
                {
                    Assert.AreEqual(item.ProvisioningState.ToString(), resourceStateConfirm);
                }
            }

            // cancel all resources
            await occ.CancelAsync(new(resourceIds: []));

            // Validate all cancel
            OccurrenceResource allCancelled = await DefaultResourceGroupResource.GetOccurrences(scheduledActionName).GetAsync(occ.Data.Name);
            Assert.NotNull(allCancelled);
            Assert.True(allCancelled.Data.Properties.ProvisioningState == OccurrenceState.Canceled);

            List<Models.OccurrenceResource> allCancelledResources = [];

            // get the resources from the allCancelled occurrence
            await foreach (Models.OccurrenceResource item in allCancelled.GetResourcesAsync())
            {
                allCancelledResources.Add(item);
            }

            foreach (Models.OccurrenceResource item in allCancelledResources)
            {
                Assert.AreEqual(item.ProvisioningState.ToString(), "RsCanceled");
            }
        }

        private async Task DelayOccurrenceTask(OccurrenceResource occ, List<ResourceIdentifier> resources, string scheduledActionName, OccurrenceState occurrenceStateConfirm, string resourceStateConfirm)
        {
            Assert.True(occ.Data.Properties.ProvisioningState == occurrenceStateConfirm);

            // delay subset of resources
            DateTimeOffset delayTimeOne = occ.Data.Properties.ScheduledOn.AddHours(2);
            DelayContent delayContentSubset = new(resourceIds: [resources[0]], delay: delayTimeOne);

            await occ.DelayAsync(WaitUntil.Completed, delayContentSubset);

            // Validate delay
            OccurrenceResource delayedOcc = await DefaultResourceGroupResource.GetOccurrences(scheduledActionName).GetAsync(occ.Data.Name);

            Assert.NotNull(delayedOcc);
            Assert.True(delayedOcc.Data.Properties.ProvisioningState == occurrenceStateConfirm);
            List<Models.OccurrenceResource> occResources = [];

            await foreach (Models.OccurrenceResource item in delayedOcc.GetResourcesAsync())
            {
                occResources.Add(item);
            }

            // get the min time of the resources in the occurrence
            DateTimeOffset minTime = occResources.Select(item => item.ScheduledOn).Min();
            Assert.AreEqual(delayedOcc.Data.Properties.ScheduledOn, minTime);

            foreach (Models.OccurrenceResource item in occResources)
            {
                Assert.AreEqual(item.ProvisioningState.ToString(), resourceStateConfirm);

                if (item.ResourceId == resources[0])
                {
                    Assert.AreEqual(delayTimeOne, item.ScheduledOn);
                }
                else
                {
                    Assert.AreNotEqual(delayTimeOne, item.ScheduledOn);
                }
            }

            // delay all resources
            DateTimeOffset delayAllTime = delayTimeOne.AddMinutes(45);
            DelayContent delayAllContent = new(resourceIds: [], delay: delayAllTime);

            await occ.DelayAsync(WaitUntil.Completed, delayAllContent);

            // Validate delay
            OccurrenceResource delayedAllOcc = await DefaultResourceGroupResource.GetOccurrences(scheduledActionName).GetAsync(occ.Data.Name);
            Assert.NotNull(delayedAllOcc);
            Assert.True(delayedAllOcc.Data.Properties.ProvisioningState == occurrenceStateConfirm);
            Assert.AreEqual(delayAllTime, delayedAllOcc.Data.Properties.ScheduledOn);

            await foreach (Models.OccurrenceResource item in delayedOcc.GetResourcesAsync())
            {
                Assert.AreEqual(delayAllTime, item.ScheduledOn);
                Assert.AreEqual(item.ProvisioningState.ToString(), resourceStateConfirm);
            }
        }

        private async Task<ScheduledAction> CreateAndValidateScheduledAction(string saNamePrefix, TimeSpan scheduleTime, bool isDisabled = true)
        {
            string scheduledActionName = Recording.GenerateAssetName(saNamePrefix);
            var actiontype = new ScheduledActionType("Deallocate");
            ScheduledActionDeadlineType deadlineType = ScheduledActionDeadlineType.InitiateAt;
            DateTimeOffset startsOn = Recording.Now.AddMonths(-1);
            DateTimeOffset endsOn = Recording.Now.AddMonths(1);
            UserRequestRetryPolicy retryPolicy = new() { RetryCount = 3, RetryWindowInMinutes = 30 };
            //ScheduledAction resource = RecurringScheduledActionUtils.GenerateScheduledActionResource(
            //    "Eastus2euap",
            //    retryPolicy,
            //    deadlineType,
            //    startsOn,
            //    endsOn,
            //    actiontype,
            //    scheduleTime,
            //    "UTC",
            //    isDisabled: isDisabled
            //    );
            ScheduledAction resource = RecurringScheduledActionUtils.GenerateScheduledActionResourceOther(
                scheduledActionName,
                "Eastus2euap",
                retryPolicy,
                deadlineType,
                startsOn,
                endsOn,
                actiontype,
                scheduleTime,
                "UTC",
                isDisabled: isDisabled,
                DefaultSubscription.Id.Name,
                DefaultResourceGroupResource.Id.Name
                );

            // create scheduledaction
            ArmOperation<ScheduledAction> lro = await DefaultResourceGroupResource.CreateOrUpdateScheduledActionAsync(WaitUntil.Completed, scheduledActionName, resource);
            ScheduledAction result = lro.Value;

            if (isDisabled)
            {
                Assert.True(result.Properties.Disabled);
            }
            else
            {
                Assert.False(result.Properties.Disabled);
            }

            Assert.NotNull(result);
            Assert.True(result.Name.Equals(scheduledActionName));
            Assert.True(result.Properties.ActionType.Equals(actiontype));
            Assert.True(result.Properties.Schedule.ScheduledTime.Equals(scheduleTime));
            Assert.True(result.Properties.StartOn.Equals(startsOn));
            Assert.True(result.Properties.EndOn.Equals(endsOn));
            Assert.AreEqual(result.ResourceType, "microsoft.computeschedule/scheduledactions");

            return result;
        }
        #endregion
    }
}

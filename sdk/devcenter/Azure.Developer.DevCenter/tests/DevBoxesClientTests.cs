// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    public class DevBoxesClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        public const string DevBoxName = "MyDevBox";

        private DevBoxesClient _devBoxesClient;

        internal DevBoxesClient GetDevBoxesClient() =>
            InstrumentClient(new DevBoxesClient(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new DevCenterClientOptions())));

        public DevBoxesClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _devBoxesClient = GetDevBoxesClient();
        }

        [Test]
        public async Task CreateStopAndStartDevBoxSucceeds()
        {
            await CreateDevBoxAsync();

            // At this point we should have a running dev box, let's stop it
            Operation devBoxStopOperation = await _devBoxesClient.StopDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            CheckLROSucceeded(devBoxStopOperation);

            // Start the dev box
            Operation devBoxStartOperation = await _devBoxesClient.StartDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            CheckLROSucceeded(devBoxStartOperation);
        }

        [Test]
        public async Task RestartDevBoxSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            Operation devBoxRestartOperation = await _devBoxesClient.RestartDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            CheckLROSucceeded(devBoxRestartOperation);
        }

        [Test]
        public async Task GetRemoteConnectionSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            RemoteConnection remoteConnection = await _devBoxesClient.GetRemoteConnectionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            // Check webUrl
            Uri webUrl = remoteConnection.WebUri;
            if (webUrl == null)
            {
                FailDueToMissingProperty("webUrl");
            }

            Assert.AreEqual(webUrl.Scheme, Uri.UriSchemeHttps);

            // Check RDP connection
            Uri remoteConnectionUrl = remoteConnection.RdpConnectionUri;
            if (remoteConnectionUrl == null)
            {
                FailDueToMissingProperty("rdpConnectionUrl");
            }

            Assert.AreEqual(remoteConnectionUrl.Scheme, "ms-avd");
        }

        [Test]
        public async Task GetDevBoxSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            DevBox devBox = await _devBoxesClient.GetDevBoxAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            string devBoxName = devBox.Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [Test]
        public async Task GetDevBoxesSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            List<DevBox> devBoxes = await _devBoxesClient.GetDevBoxesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId).ToEnumerableAsync();

            Assert.AreEqual(1, devBoxes.Count);

            string devBoxName = devBoxes[0].Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [Test]
        public async Task GetAllDevBoxesSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            List<DevBox> devBoxes = await _devBoxesClient.GetAllDevBoxesAsync().ToEnumerableAsync();

            Assert.AreEqual(1, devBoxes.Count);

            string devBoxName = devBoxes[0].Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [Test]
        public async Task GetAllDevBoxesByUserSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            List<DevBox> devBoxes = await _devBoxesClient.GetAllDevBoxesByUserAsync(TestEnvironment.MeUserId).ToEnumerableAsync();

            Assert.AreEqual(1, devBoxes.Count);

            string devBoxName = devBoxes[0].Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [Test]
        public async Task GetPoolSucceeds()
        {
            DevBoxPool pool = await _devBoxesClient.GetPoolAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName);

            string poolName = pool.Name;
            if (string.IsNullOrWhiteSpace(poolName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(poolName, TestEnvironment.PoolName);
        }

        [Test]
        public async Task GetPoolsSucceeds()
        {
            List<DevBoxPool> pools = await _devBoxesClient.GetPoolsAsync(TestEnvironment.ProjectName).ToEnumerableAsync();

            Assert.AreEqual(1, pools.Count);

            string poolName = pools[0].Name;
            if (string.IsNullOrWhiteSpace(poolName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(poolName, TestEnvironment.PoolName);
        }

        [Test]
        public async Task GetScheduleSucceeds()
        {
            DevBoxSchedule schedule = await _devBoxesClient.GetScheduleAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName,
                "default");

            string scheduleName = schedule.Name;
            if (string.IsNullOrWhiteSpace(scheduleName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual("default", scheduleName);
        }

        [Test]
        public async Task GetSchedulesSucceeds()
        {
            List<DevBoxSchedule> schedules = await _devBoxesClient.GetSchedulesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName).ToEnumerableAsync();

            Assert.AreEqual(1, schedules.Count);

            string scheduleName = schedules[0].Name;
            if (string.IsNullOrWhiteSpace(scheduleName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual("default", scheduleName);
        }

        [Test]
        public async Task GetAndDelayActionSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            //only perform actions if it exists and it's in the 24hrs window
            if (!await HasDefaultActionIn24hrsAsync())
            {
                return;
            }

            DevBoxAction action = await _devBoxesClient.GetDevBoxActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default");

            Assert.NotNull(action);
            Assert.AreEqual("schedule-default", action.Name);
            Assert.AreEqual(DevBoxActionType.Stop, action.ActionType);

            DateTimeOffset currentScheduledTime = action.NextAction.ScheduledTime;
            Assert.NotNull(currentScheduledTime);

            DateTimeOffset delayUntil = currentScheduledTime.AddMinutes(10);

            //when target action is more than 24 hours away, delay can't be applied
            if (delayUntil >= DateTimeOffset.UtcNow.AddHours(24))
            {
                return;
            }

            DevBoxAction delayedAction = await _devBoxesClient.DelayActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                action.Name,
                delayUntil);

            DateTimeOffset delayedTime = delayedAction.NextAction.ScheduledTime;

            Assert.NotNull(delayedTime);
            Assert.AreEqual(delayUntil, delayedTime);
        }

        [Test]
        public async Task GetAndDelayAllActionsSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            List<DevBoxAction> devBoxActions = await _devBoxesClient.GetDevBoxActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName).ToEnumerableAsync();

            if (devBoxActions.Count == 0)
            {
                return;
            }

            DateTimeOffset latestActionTime = devBoxActions.Max(action => action.NextAction.ScheduledTime);
            DateTimeOffset delayUntil = latestActionTime.AddMinutes(10);

            //when target action is more than 24 hours away, delay can't be applied
            if (delayUntil >= DateTimeOffset.UtcNow.AddHours(24))
            {
                return;
            }

            List<DevBoxActionDelayResult> actionsDelayResult = await _devBoxesClient.DelayAllActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                delayUntil).ToEnumerableAsync();

            Assert.AreEqual(devBoxActions.Count, actionsDelayResult.Count);
            foreach (var actionDelayResult in actionsDelayResult)
            {
                Assert.AreEqual(DevBoxActionDelayStatus.Succeeded, actionDelayResult.DelayStatus);
                Assert.True(devBoxActions.Any(action => action.Name == actionDelayResult.ActionName));
            }
        }

        [Test]
        public async Task SkipActionAndDeleteDevBoxSucceeds()
        {
            await EnsureDevBoxExistsAsync();

            if (!await HasDefaultActionIn24hrsAsync())
            {
                return;
            }

            Response skipActionResponse = await _devBoxesClient.SkipActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default");

            Assert.AreEqual((int)HttpStatusCode.NoContent, skipActionResponse.Status);

            Operation devBoxDeleteOperation = await _devBoxesClient.DeleteDevBoxAsync(
               WaitUntil.Completed,
               TestEnvironment.ProjectName,
               TestEnvironment.MeUserId,
               DevBoxName);

            CheckLROSucceeded(devBoxDeleteOperation);
        }

        private async Task EnsureDevBoxExistsAsync()
        {
            List<DevBox> devBoxes = await _devBoxesClient.GetDevBoxesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId).ToEnumerableAsync();

            if (!devBoxes.Any(d => d.Name.Equals(DevBoxName)))
            {
                await CreateDevBoxAsync();
            }
        }

        private async Task CreateDevBoxAsync()
        {
            DevBox devBox = new DevBox
            (
                 DevBoxName,
                 TestEnvironment.PoolName
            );

            Operation<DevBox> devBoxCreateOperation = await _devBoxesClient.CreateDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                devBox);

            devBox = devBoxCreateOperation.Value;

            Assert.NotNull(devBox);
            Assert.AreEqual(DevBoxName, devBox.Name);

            DevBoxProvisioningState? devBoxProvisioningState = devBox.ProvisioningState;

            // Both states indicate successful provisioning
            bool devBoxProvisionSucceeded =
                devBoxProvisioningState.Equals(DevBoxProvisioningState.Succeeded) ||
                devBoxProvisioningState.Equals(DevBoxProvisioningState.ProvisionedWithWarning);

            Assert.IsTrue(devBoxProvisionSucceeded);
        }

        private async Task<bool> HasDefaultActionIn24hrsAsync()
        {
            List<DevBoxAction> devBoxActions = await _devBoxesClient.GetDevBoxActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName).ToEnumerableAsync();

            if (!devBoxActions.Any(action => action.Name == "schedule-default"))
            {
                return false;
            }

            DevBoxAction defaultAction = devBoxActions.Where(action => action.Name == "schedule-default").First();
            bool isInThe24hWindow = defaultAction.NextAction.ScheduledTime < DateTimeOffset.UtcNow.AddHours(24);

            return isInThe24hWindow;
        }

        private void CheckLROSucceeded(Operation finalOperationResponse)
        {
            var responseData = finalOperationResponse.GetRawResponse().Content;
            var response = JsonDocument.Parse(responseData).RootElement;

            if (!response.TryGetProperty("status", out var responseStatusJson))
            {
                FailDueToMissingProperty("status");
            }

            var status = responseStatusJson.ToString();
            Assert.True(status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));
        }

        private void FailDueToMissingProperty(string propertyName)
        {
            Assert.Fail($"The response received from the service does not include the necessary property: {propertyName}");
        }
    }
}

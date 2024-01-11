// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    //[PlaybackOnly("As deploy/delete manipulations with real resources take time.")]
    public class DevBoxClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        public const string DevBoxName = "MyDevBox";

        private DevBoxesClient _devBoxesClient;

        internal DevBoxesClient GetDevBoxesClient() =>
            InstrumentClient(new DevBoxesClient(
                TestEnvironment.Endpoint,
                new InteractiveBrowserCredential(),
                InstrumentClientOptions(new DevCenterClientOptions())));

        public DevBoxClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUpAsync()
        {
            _devBoxesClient = GetDevBoxesClient();
            await SetUpDevBoxAsync();
        }

        [Test]
        public async Task StartAndStopDevBoxSucceeds()
        {
            // At this point we should have a running dev box, let's stop it
            Operation devBoxStopOperation = await _devBoxesClient.StopDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            BinaryData devBoxData = devBoxStopOperation.GetRawResponse().Content;
            JsonElement devBox = JsonDocument.Parse(devBoxData).RootElement;

            if (!devBox.TryGetProperty("status", out var devBoxStatusJson))
            {
                FailDueToMissingProperty("status");
            }

            string devBoxStatus = devBoxStatusJson.ToString();
            Assert.True(devBoxStatus.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));

            // Start the dev box
            Operation devBoxStartOperation = await _devBoxesClient.StartDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            devBoxData = devBoxStartOperation.GetRawResponse().Content;
            devBox = JsonDocument.Parse(devBoxData).RootElement;

            if (!devBox.TryGetProperty("status", out devBoxStatusJson))
            {
                FailDueToMissingProperty("status");
            }

            devBoxStatus = devBoxStatusJson.ToString();
            Assert.True(devBoxStatus.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public async Task GetRemoteConnectionSucceeds()
        {
            Response<RemoteConnection> remoteConnectionResponse = await _devBoxesClient.GetRemoteConnectionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            // Check webUrl
            Uri webUrl = remoteConnectionResponse?.Value?.WebUri;
            if (webUrl == null)
            {
                FailDueToMissingProperty("webUrl");
            }

            Assert.AreEqual(webUrl.Scheme, Uri.UriSchemeHttps);

            // Check RDP connection
            Uri remoteConnectionUrl = remoteConnectionResponse?.Value?.RdpConnectionUri;
            if (remoteConnectionUrl == null)
            {
                FailDueToMissingProperty("rdpConnectionUrl");
            }

            Assert.AreEqual(remoteConnectionUrl.Scheme, "ms-avd");
        }

        [Test]
        public async Task GetDevBoxesSucceeds()
        {
            int numberOfReturnedDevBoxes = 0;

            await foreach (DevBox devBox in _devBoxesClient.GetDevBoxesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId))
            {
                numberOfReturnedDevBoxes++;

                string devBoxName = devBox.Name;
                if (string.IsNullOrWhiteSpace(devBoxName))
                {
                    FailDueToMissingProperty("name");
                }

                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [Test]
        public async Task GetAllDevBoxesSucceeds()
        {
            int numberOfReturnedDevBoxes = 0;

            await foreach (DevBox devBox in _devBoxesClient.GetAllDevBoxesAsync())
            {
                numberOfReturnedDevBoxes++;

                string devBoxName = devBox.Name;
                if (string.IsNullOrWhiteSpace(devBoxName))
                {
                    FailDueToMissingProperty("name");
                }

                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [Test]
        public async Task GetAllDevBoxesByUserSucceeds()
        {
            int numberOfReturnedDevBoxes = 0;

            await foreach (DevBox devBox in _devBoxesClient.GetAllDevBoxesByUserAsync(TestEnvironment.MeUserId))
            {
                numberOfReturnedDevBoxes++;

                string devBoxName = devBox.Name;
                if (string.IsNullOrWhiteSpace(devBoxName))
                {
                    FailDueToMissingProperty("name");
                }

                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [Test]
        public async Task GetPoolSucceeds()
        {
            Response<DevBoxPool> getPoolResponse = await _devBoxesClient.GetPoolAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName);

            string poolName = getPoolResponse?.Value.Name;
            if (string.IsNullOrWhiteSpace(poolName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(poolName, TestEnvironment.PoolName);
        }

        [Test]
        public async Task GetPoolsSucceeds()
        {
            var numberOfReturnedPools = 0;
            await foreach (DevBoxPool pool in _devBoxesClient.GetPoolsAsync(TestEnvironment.ProjectName))
            {
                numberOfReturnedPools++;

                string poolName = pool.Name;
                if (string.IsNullOrWhiteSpace(poolName))
                {
                    FailDueToMissingProperty("name");
                }
                Assert.AreEqual(poolName, TestEnvironment.PoolName);
            }

            Assert.AreEqual(1, numberOfReturnedPools);
        }

        [Test]
        public async Task GetSchedulesSucceeds()
        {
            var numberOfReturnedSchedules = 0;
            await foreach (DevBoxSchedule schedule in _devBoxesClient.GetSchedulesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName))
            {
                numberOfReturnedSchedules++;

                string scheduleName = schedule.Name;
                if (string.IsNullOrWhiteSpace(scheduleName))
                {
                    FailDueToMissingProperty("name");
                }
                Assert.AreEqual("default", scheduleName);
            }

            Assert.AreEqual(1, numberOfReturnedSchedules);
        }

        [Test]
        public async Task GetScheduleSucceeds()
        {
            Response<DevBoxSchedule> getScheduleResponse = await _devBoxesClient.GetScheduleAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName,
                "default");

            string scheduleName = getScheduleResponse?.Value?.Name;
            if (string.IsNullOrWhiteSpace(scheduleName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual("default", scheduleName);
        }

        [Test]
        public async Task GetAndDelayActionSucceeds()
        {
            DevBoxAction action = await GetActionAsync();

            DateTimeOffset delayUntil = action.NextAction.ScheduledTime.AddHours(1);

            Response<DevBoxAction> delayActionResponse = await _devBoxesClient.DelayActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                action.Name,
                delayUntil);

            DevBoxNextAction nextAction = delayActionResponse?.Value?.NextAction;
            if (nextAction == null)
            {
                FailDueToMissingProperty("nextAction");
            }

            Assert.AreEqual(delayUntil, nextAction.ScheduledTime);
        }

        [Test]
        public async Task GetAndDelayAllActionsSucceeds()
        {
            DevBoxAction action = default;
            var numberOfReturnedActions = 0;

            await foreach (DevBoxAction devBoxAction in _devBoxesClient.GetDevBoxActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName))
            {
                numberOfReturnedActions++;

                action = devBoxAction;
                if (string.IsNullOrWhiteSpace(action.Name))
                {
                    FailDueToMissingProperty("name");
                }
                Assert.AreEqual("schedule-default", action.Name);
            }

            Assert.AreEqual(1, numberOfReturnedActions);

            DateTimeOffset delayUntil = action.NextAction.ScheduledTime.AddHours(1);
            numberOfReturnedActions = 0;

            await foreach (DevBoxActionDelayResult actionDelayResult in _devBoxesClient.DelayAllActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                delayUntil))
            {
                numberOfReturnedActions++;

                DevBoxActionDelayStatus actionDelayStatus = actionDelayResult.Result;
                if (actionDelayStatus == default)
                {
                    FailDueToMissingProperty("actionDelayStatus");
                }

                Assert.AreEqual(DevBoxActionDelayStatus.Succeeded, actionDelayStatus);
            }

            Assert.AreEqual(1, numberOfReturnedActions);
        }

        [Test]
        public async Task SkipActionSucceeds()
        {
            Response skipActionResponse = await _devBoxesClient.SkipActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default");

            Assert.AreEqual((int)HttpStatusCode.NoContent, skipActionResponse.Status);
        }

        [Test]
        public async Task DeleteDevBoxSucceeds()
        {
            Operation devBoxDeleteOperation = await _devBoxesClient.DeleteDevBoxAsync(
               WaitUntil.Completed,
               TestEnvironment.ProjectName,
               TestEnvironment.MeUserId,
               DevBoxName);

            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
        }

        private async Task SetUpDevBoxAsync()
        {
            DevBox devBox = await GetDevBoxAsync();
            if (devBox == null)
            {
                devBox = await CreateDevBoxAsync();
            }

            string devBoxName = devBox.Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);

            DevBoxProvisioningState? devBoxProvisioningState = devBox.ProvisioningState;

            // Both states indicate successful provisioning
            bool devBoxProvisionSucceeded =
                devBoxProvisioningState.Equals(DevBoxProvisioningState.Succeeded) ||
                devBoxProvisioningState.Equals(DevBoxProvisioningState.ProvisionedWithWarning);

            Assert.IsTrue(devBoxProvisionSucceeded);
        }

        private async Task<DevBoxAction> GetActionAsync()
        {
            DevBoxAction action = (await _devBoxesClient.GetDevBoxActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default"))?.Value;

            string actionName = action?.Name;
            if (string.IsNullOrWhiteSpace(actionName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual("schedule-default", actionName);
            Assert.AreEqual(DevBoxActionType.Stop, action.ActionType);

            return action;
        }

        private async Task<DevBox> GetDevBoxAsync()
        {
            return (await _devBoxesClient.GetDevBoxAsync(
               TestEnvironment.ProjectName,
               TestEnvironment.MeUserId,
               DevBoxName))?.Value;
        }

        private async Task<DevBox> CreateDevBoxAsync()
        {
            DevBox devBox = new DevBox
            (
                 TestEnvironment.PoolName
            );

            // Create dev box
            Operation<DevBox> devBoxCreateOperation = await _devBoxesClient.CreateDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                devBox);

            return await devBoxCreateOperation.WaitForCompletionAsync();
        }

        private void FailDueToMissingProperty(string propertyName)
        {
            Assert.Fail($"The response received from the service does not include the necessary property: {propertyName}");
        }
    }
}

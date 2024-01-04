// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    [PlaybackOnly("As deploy/delete manipulations with real resources take time.")]
    public class DevBoxClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        public const string DevBoxName = "MyDevBox";

        private DevBoxesClient _devBoxesClient;

        internal DevBoxesClient GetDevBoxesClient() =>
            InstrumentClient(new DevBoxesClient(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
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

        [TearDown]
        public async Task TearDownAsync()
        {
            Operation devBoxDeleteOperation = await _devBoxesClient.DeleteDevBoxAsync(
               WaitUntil.Completed,
               TestEnvironment.ProjectName,
               TestEnvironment.MeUserId,
               DevBoxName);

            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task GetDevBoxSucceeds()
        {
            Response<DevBox> devBoxResponse = await _devBoxesClient.GetDevBoxAsync(
               TestEnvironment.ProjectName,
               TestEnvironment.MeUserId,
               DevBoxName);

            string devBoxName = devBoxResponse?.Value?.Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task GetActionsSucceeds()
        {
            var numberOfReturnedActions = 0;
            await foreach (DevBoxAction devBoxAction in _devBoxesClient.GetDevBoxActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName))
            {
                numberOfReturnedActions++;

                string actionName = devBoxAction.Name;
                if (string.IsNullOrWhiteSpace(actionName))
                {
                    FailDueToMissingProperty("name");
                }
                Assert.AreEqual("schedule-default", actionName);
            }

            Assert.AreEqual(1, numberOfReturnedActions);
        }

        [RecordedTest]
        public async Task GetActionSucceeds()
        {
            Response<DevBoxAction> getActionResponse = await _devBoxesClient.GetDevBoxActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default");

            string actionName = getActionResponse?.Value.Name;
            if (string.IsNullOrWhiteSpace(actionName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual("schedule-default", actionName);
        }

        [RecordedTest]
        public async Task SkipActionSucceeds()
        {
            Response skipActionResponse = await _devBoxesClient.SkipActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default");

            Assert.AreEqual((int)HttpStatusCode.NoContent, skipActionResponse.Status);
        }

        [RecordedTest]
        public async Task DelayActionSucceeds()
        {
            // Using fixed time to match sessions records
            string time = "2023-05-02T16:01:53.3821556Z";
            DateTimeOffset delayUntil = DateTimeOffset.Parse(time);

            Response<DevBoxAction> delayActionResponse = await _devBoxesClient.DelayActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default",
                delayUntil);

            DevBoxNextAction nextAction = delayActionResponse?.Value.NextAction;
            if (nextAction == null)
            {
                FailDueToMissingProperty("nextAction");
            }

            Assert.AreEqual(delayUntil, nextAction.ScheduledTime);
        }

        [RecordedTest]
        public async Task DelayAllActionsSucceeds()
        {
            // Using fixed time to match sessions records
            DateTimeOffset delayUntil = DateTimeOffset.Parse("2023-05-02T16:01:53.3821556Z");
            var numberOfReturnedActions = 0;

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

        private async Task SetUpDevBoxAsync()
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

            devBox = await devBoxCreateOperation.WaitForCompletionAsync();
            DevBoxProvisioningState? devBoxProvisioningState = devBox.ProvisioningState;

            // Both states indicate successful provisioning
            bool devBoxProvisionSucceeded = devBoxProvisioningState.Equals(DevBoxProvisioningState.Succeeded) || devBoxProvisioningState.Equals(DevBoxProvisioningState.ProvisionedWithWarning);
            Assert.IsTrue(devBoxProvisionSucceeded);
        }

        private void FailDueToMissingProperty(string propertyName)
        {
            Assert.Fail($"The response received from the service does not include the necessary property: {propertyName}");
        }
    }
}

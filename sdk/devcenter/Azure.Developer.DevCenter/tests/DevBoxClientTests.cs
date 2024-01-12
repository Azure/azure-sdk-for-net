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

        [RecordedTest]
        public async Task StartAndStopDevBoxSucceeds()
        {
            // At this point we should have a running dev box, let's stop it
            Operation devBoxStopOperation = await _devBoxesClient.StopDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            Response devBoxStopResponse = devBoxStopOperation.WaitForCompletionResponse();

            Assert.AreEqual((int)HttpStatusCode.OK, devBoxStopResponse.Status);

            // Start the dev box
            Operation devBoxStartOperation = await _devBoxesClient.StartDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName);

            Response devBoxStartResponse = devBoxStartOperation.WaitForCompletionResponse();

            Assert.AreEqual((int)HttpStatusCode.OK, devBoxStartResponse.Status);
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
        public async Task GetDevBoxesSucceeds()
        {
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

        [RecordedTest]
        public async Task GetAllDevBoxesSucceeds()
        {
            List<DevBox> devBoxes = await _devBoxesClient.GetAllDevBoxesAsync().ToEnumerableAsync();

            Assert.AreEqual(1, devBoxes.Count);

            string devBoxName = devBoxes[0].Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [RecordedTest]
        public async Task GetAllDevBoxesByUserSucceeds()
        {
            List<DevBox> devBoxes = await _devBoxesClient.GetAllDevBoxesByUserAsync(TestEnvironment.MeUserId).ToEnumerableAsync();

            Assert.AreEqual(1, devBoxes.Count);

            string devBoxName = devBoxes[0].Name;
            if (string.IsNullOrWhiteSpace(devBoxName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [RecordedTest]
        public async Task GetPoolSucceeds()
        {
            Response<DevBoxPool> getPoolResponse = await _devBoxesClient.GetPoolAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName);

            string poolName = getPoolResponse.Value.Name;
            if (string.IsNullOrWhiteSpace(poolName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(poolName, TestEnvironment.PoolName);
        }

        [RecordedTest]
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

        [RecordedTest]
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
        public async Task GetAndDelayActionSucceeds()
        {
            Response<DevBoxAction> actionResponse = await _devBoxesClient.GetDevBoxActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default");

            DevBoxAction action = actionResponse.Value;
            if (action == default)
            {
                FailDueToMissingProperty("action");
            }

            Assert.AreEqual("schedule-default", action.Name);
            Assert.AreEqual(DevBoxActionType.Stop, action.ActionType);

            DateTimeOffset delayUntil = action.NextAction.ScheduledTime.AddMinutes(10);

            Response<DevBoxAction> delayActionResponse = await _devBoxesClient.DelayActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                action.Name,
                delayUntil);

            DevBoxNextAction nextAction = delayActionResponse.Value.NextAction;
            if (nextAction == null)
            {
                FailDueToMissingProperty("nextAction");
            }

            Assert.AreEqual(delayUntil, nextAction.ScheduledTime);
        }

        [RecordedTest]
        public async Task GetAndDelayAllActionsSucceeds()
        {
            List<DevBoxAction> devBoxActions = await _devBoxesClient.GetDevBoxActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName).ToEnumerableAsync();

            Assert.AreEqual(1, devBoxActions.Count);

            var action = devBoxActions[0];
            if (string.IsNullOrWhiteSpace(action.Name))
            {
                FailDueToMissingProperty("name");
            }
            Assert.AreEqual("schedule-default", action.Name);

            DateTimeOffset delayUntil = action.NextAction.ScheduledTime.AddMinutes(10);

            List<DevBoxActionDelayResult> actionsDelayResult = await _devBoxesClient.DelayAllActionsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                delayUntil).ToEnumerableAsync();

            Assert.AreEqual(1, actionsDelayResult.Count);

            DevBoxActionDelayStatus actionDelayStatus = actionsDelayResult[0].Result;
            if (actionDelayStatus == default)
            {
                FailDueToMissingProperty("actionDelayStatus");
            }

            Assert.AreEqual(DevBoxActionDelayStatus.Succeeded, actionDelayStatus);
        }

        [RecordedTest]
        public async Task SkipActionAndDeleteDevBoxSucceeds()
        {
            //This test will run for each target framework. Since Skip Action can run only once - if you skip action in a machine that
            //already has the scheduled shutdown skipped it will fail. So we need no delete the machine, and SetUp will create a new one

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

        private async Task SetUpDevBoxAsync()
        {
            DevBox devBox = await GetDevBoxAsync();
            if (devBox == default)
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

        private async Task<DevBox> GetDevBoxAsync()
        {
            List<DevBox> devBoxes = await _devBoxesClient.GetDevBoxesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId).ToEnumerableAsync();

            return devBoxes.Where(d => d.Name.Equals(DevBoxName)).FirstOrDefault();
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

            return devBoxCreateOperation.Value;
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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
                InstrumentClientOptions(new AzureDeveloperDevCenterClientOptions())));

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
                DevBoxName,
                TestEnvironment.hibernate,
                TestEnvironment.context);

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
                DevBoxName,
                TestEnvironment.context);

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
            Response remoteConnectionResponse = await _devBoxesClient.GetRemoteConnectionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                TestEnvironment.context);

            JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;

            // Check webUrl
            if (!remoteConnectionData.TryGetProperty("webUrl", out var webUrlJson))
            {
                FailDueToMissingProperty("webUrl");
            }

            string uriString = webUrlJson.ToString();

            bool validConnectionUri = Uri.TryCreate(uriString, UriKind.Absolute, out Uri uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;

            Assert.True(validConnectionUri);

            // Check RDP connection string
            if (!remoteConnectionData.TryGetProperty("rdpConnectionUrl", out var rdpConnectionUrlJson))
            {
                FailDueToMissingProperty("rdpConnectionUrl");
            }

            string rdpConnectionUrlString = rdpConnectionUrlJson.ToString();
            Assert.False(string.IsNullOrEmpty(rdpConnectionUrlString));
            Assert.True(rdpConnectionUrlString.StartsWith("ms-avd"));
        }

        [RecordedTest]
        public async Task GetDevBoxSucceeds()
        {
            Response devBoxResponse = await _devBoxesClient.GetDevBoxAsync(
               TestEnvironment.ProjectName,
               TestEnvironment.MeUserId,
               DevBoxName,
               TestEnvironment.context);

            JsonElement devBoxResponseData = JsonDocument.Parse(devBoxResponse.ContentStream).RootElement;

            if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
            {
                FailDueToMissingProperty("name");
            }

            string devBoxName = devBoxNameJson.ToString();
            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [RecordedTest]
        public async Task GetDevBoxesSucceeds()
        {
            int numberOfReturnedDevBoxes = 0;

            await foreach (BinaryData devBoxData in _devBoxesClient.GetDevBoxesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                TestEnvironment.filter,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfReturnedDevBoxes++;
                JsonElement devBoxResponseData = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

                if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string devBoxName = devBoxNameJson.ToString();
                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [RecordedTest]
        public async Task GetAllDevBoxesSucceeds()
        {
            int numberOfReturnedDevBoxes = 0;

            await foreach (BinaryData devBoxData in _devBoxesClient.GetAllDevBoxesAsync(
                TestEnvironment.filter,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfReturnedDevBoxes++;
                JsonElement devBoxResponseData = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

                if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string devBoxName = devBoxNameJson.ToString();
                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [RecordedTest]
        public async Task GetAllDevBoxesByUserSucceeds()
        {
            int numberOfReturnedDevBoxes = 0;

            await foreach (BinaryData devBoxData in _devBoxesClient.GetAllDevBoxesByUserAsync(
                TestEnvironment.MeUserId,
                TestEnvironment.filter,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfReturnedDevBoxes++;
                JsonElement devBoxResponseData = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

                if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string devBoxName = devBoxNameJson.ToString();
                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [RecordedTest]
        public async Task GetPoolSucceeds()
        {
            Response getPoolResponse = await _devBoxesClient.GetPoolAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName,
                TestEnvironment.context);

            JsonElement getPoolData = JsonDocument.Parse(getPoolResponse.ContentStream).RootElement;

            if (!getPoolData.TryGetProperty("name", out var poolNameJson))
            {
                FailDueToMissingProperty("name");
            }

            string poolName = poolNameJson.ToString();
            Assert.AreEqual(poolName, TestEnvironment.PoolName);
        }

        [RecordedTest]
        public async Task GetPoolsSucceeds()
        {
            var numberOfReturnedPools = 0;
            await foreach (BinaryData poolData in _devBoxesClient.GetPoolsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.filter,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfReturnedPools++;
                JsonElement getPoolsResponseData = JsonDocument.Parse(poolData.ToStream()).RootElement;

                if (!getPoolsResponseData.TryGetProperty("name", out var poolNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string poolName = poolNameJson.ToString();
                Assert.AreEqual(poolName, TestEnvironment.PoolName);
            }

            Assert.AreEqual(1, numberOfReturnedPools);
        }

        [RecordedTest]
        public async Task GetSchedulesSucceeds()
        {
            var numberOfReturnedSchedules = 0;
            await foreach (BinaryData scheduleData in _devBoxesClient.GetSchedulesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName,
                TestEnvironment.filter,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfReturnedSchedules++;
                JsonElement getSchedulesResponseData = JsonDocument.Parse(scheduleData.ToStream()).RootElement;

                if (!getSchedulesResponseData.TryGetProperty("name", out var scheduleNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string scheduleName = scheduleNameJson.ToString();
                Assert.AreEqual("default", scheduleName);
            }

            Assert.AreEqual(1, numberOfReturnedSchedules);
        }

        [RecordedTest]
        public async Task GetScheduleSucceeds()
        {
            Response getScheduleResponse = await _devBoxesClient.GetScheduleAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName,
                "default",
                TestEnvironment.context);

            JsonElement getScheduleData = JsonDocument.Parse(getScheduleResponse.ContentStream).RootElement;

            if (!getScheduleData.TryGetProperty("name", out var scheduleNameJson))
            {
                FailDueToMissingProperty("name");
            }

            string scheduleName = scheduleNameJson.ToString();
            Assert.AreEqual("default", scheduleName);
        }

        [RecordedTest]
        public async Task GetActionsSucceeds()
        {
            var numberOfReturnedActions = 0;
            await foreach (BinaryData actionsData in _devBoxesClient.GetDevBoxActionsAsync(TestEnvironment.ProjectName, TestEnvironment.MeUserId, DevBoxName, TestEnvironment.context))
            {
                numberOfReturnedActions++;
                JsonElement getActionsResponseData = JsonDocument.Parse(actionsData.ToStream()).RootElement;

                if (!getActionsResponseData.TryGetProperty("name", out var actionNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string actionName = actionNameJson.ToString();
                Assert.AreEqual("schedule-default", actionName);
            }

            Assert.AreEqual(1, numberOfReturnedActions);
        }

        [RecordedTest]
        public async Task GetActionSucceeds()
        {
            Response getActionResponse = await _devBoxesClient.GetDevBoxActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default",
                TestEnvironment.context);

            JsonElement getActionData = JsonDocument.Parse(getActionResponse.ContentStream).RootElement;

            if (!getActionData.TryGetProperty("name", out var actionNameJson))
            {
                FailDueToMissingProperty("name");
            }

            string actionName = actionNameJson.ToString();
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

            Response delayActionResponse = await _devBoxesClient.DelayActionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                "schedule-default",
                delayUntil,
                TestEnvironment.context);

            JsonElement delayActionData = JsonDocument.Parse(delayActionResponse.ContentStream).RootElement;
            if (!delayActionData.TryGetProperty("next", out var nextActionTimeJson))
            {
                FailDueToMissingProperty("next");
            }

            if (!nextActionTimeJson.TryGetProperty("scheduledTime", out var scheduledTimeJson))
            {
                FailDueToMissingProperty("scheduledTime");
            }

            Assert.AreEqual(time, scheduledTimeJson.ToString());
        }

        [RecordedTest]
        public async Task DelayAllActionsSucceeds()
        {
            // Using fixed time to match sessions records
            DateTimeOffset delayUntil = DateTimeOffset.Parse("2023-05-02T16:01:53.3821556Z");
            var numberOfReturnedActions = 0;

            await foreach (BinaryData actionsData in _devBoxesClient.DelayAllActionsAsync(TestEnvironment.ProjectName, TestEnvironment.MeUserId, DevBoxName, delayUntil, TestEnvironment.context))
            {
                numberOfReturnedActions++;
                JsonElement getActionsResponseData = JsonDocument.Parse(actionsData.ToStream()).RootElement;

                if (!getActionsResponseData.TryGetProperty("result", out var actionResultJson))
                {
                    FailDueToMissingProperty("result");
                }

                string actionResultName = actionResultJson.ToString();
                Assert.AreEqual("Succeeded", actionResultName);
            }

            Assert.AreEqual(1, numberOfReturnedActions);
        }

        private async Task SetUpDevBoxAsync()
        {
            var content = new
            {
                poolName = TestEnvironment.PoolName,
            };

            // Create dev box
            Operation<BinaryData> devBoxCreateOperation = await _devBoxesClient.CreateDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                DevBoxName,
                RequestContent.Create(content));

            BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
            JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
            string devBoxProvisioningState = devBox.GetProperty("provisioningState").ToString();

            // Both states indicate successful provisioning
            bool devBoxProvisionSucceeded = devBoxProvisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase) || devBoxProvisioningState.Equals("ProvisionedWithWarning", StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(devBoxProvisionSucceeded);
        }

        private void FailDueToMissingProperty(string propertyName)
        {
            Assert.Fail($"The JSON response received from the service does not include the necessary property: {propertyName}");
        }
    }
}

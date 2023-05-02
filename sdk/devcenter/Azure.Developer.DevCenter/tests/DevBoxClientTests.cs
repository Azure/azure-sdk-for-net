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
    [PlaybackOnly("It takes roughly 15-30 minutes to create a dev-box")]
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
        public void SetUp()
        {
            _devBoxesClient = GetDevBoxesClient();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            Operation devBoxDeleteOperation = await _devBoxesClient.DeleteDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                DevBoxName,
                userId: TestEnvironment.UserId);

            await devBoxDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed dev box deletion.");
        }

        [RecordedTest]
        public async Task StartDevBoxSucceeds()
        {
            await SetUpDevBoxAsync();

            // Start the dev box
            Operation<BinaryData> devBoxStartOperation = await _devBoxesClient.StartDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                DevBoxName,
                userId: TestEnvironment.UserId);

            BinaryData devBoxData = await devBoxStartOperation.WaitForCompletionAsync();
            JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

            if (!devBox.TryGetProperty("status", out var devBoxStatusJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string devBoxStatus = devBoxStatusJson.ToString();
            Assert.True(devBoxStatus.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));
        }

        [RecordedTest]
        public async Task StopDevBoxSucceeds()
        {
            await SetUpDevBoxAsync();

            // Stop the dev box
            Operation<BinaryData> devBoxStopOperation = await _devBoxesClient.StopDevBoxAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                DevBoxName,
                userId: TestEnvironment.UserId);

            BinaryData devBoxData = await devBoxStopOperation.WaitForCompletionAsync();
            JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

            if (!devBox.TryGetProperty("status", out var devBoxStatusJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string devBoxStatus = devBoxStatusJson.ToString();
            Assert.True(devBoxStatus.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));
        }

        [RecordedTest]
        public async Task GetRemoteConnectionSucceeds()
        {
            await SetUpDevBoxAsync();

            Response remoteConnectionResponse = await _devBoxesClient.GetRemoteConnectionAsync(
                TestEnvironment.ProjectName,
                DevBoxName,
                userId: TestEnvironment.UserId);

            JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;

            if (!remoteConnectionData.TryGetProperty("webUrl", out var webUrlJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string uriString = webUrlJson.ToString();

            bool validConnectionUri = Uri.TryCreate(uriString, UriKind.Absolute, out Uri uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;

            Assert.True(validConnectionUri);
        }

        [RecordedTest]
        public async Task GetDevBoxSucceeds()
        {
            await SetUpDevBoxAsync();

            Response devBoxResponse = await _devBoxesClient.GetDevBoxAsync(
               TestEnvironment.ProjectName,
               DevBoxName,
               userId: TestEnvironment.UserId);

            JsonElement devBoxResponseData = JsonDocument.Parse(devBoxResponse.ContentStream).RootElement;

            if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string devBoxName = devBoxNameJson.ToString();
            Assert.AreEqual(devBoxName, DevBoxName);
        }

        [RecordedTest]
        public async Task GetDevBoxesSucceeds()
        {
            await SetUpDevBoxAsync();
            int numberOfReturnedDevBoxes = 0;

            await foreach (BinaryData devBoxData in _devBoxesClient.GetDevBoxesAsync(TestEnvironment.ProjectName))
            {
                numberOfReturnedDevBoxes++;
                JsonElement devBoxResponseData = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

                if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string devBoxName = devBoxNameJson.ToString();
                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [RecordedTest]
        public async Task GetAllDevBoxesSucceeds()
        {
            await SetUpDevBoxAsync();
            int numberOfReturnedDevBoxes = 0;

            await foreach (BinaryData devBoxData in _devBoxesClient.GetAllDevBoxesAsync())
            {
                numberOfReturnedDevBoxes++;
                JsonElement devBoxResponseData = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

                if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string devBoxName = devBoxNameJson.ToString();
                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [RecordedTest]
        public async Task GetAllDevBoxesByUserSucceeds()
        {
            await SetUpDevBoxAsync();
            int numberOfReturnedDevBoxes = 0;

            await foreach (BinaryData devBoxData in _devBoxesClient.GetAllDevBoxesByUserAsync(userId: TestEnvironment.UserId))
            {
                numberOfReturnedDevBoxes++;
                JsonElement devBoxResponseData = JsonDocument.Parse(devBoxData.ToStream()).RootElement;

                if (!devBoxResponseData.TryGetProperty("name", out var devBoxNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string devBoxName = devBoxNameJson.ToString();
                Assert.AreEqual(devBoxName, DevBoxName);
            }

            Assert.AreEqual(1, numberOfReturnedDevBoxes);
        }

        [RecordedTest]
        public async Task GetPoolSucceeds()
        {
            Response getPoolResponse = await _devBoxesClient.GetPoolAsync(TestEnvironment.ProjectName, TestEnvironment.PoolName);
            JsonElement getPoolData = JsonDocument.Parse(getPoolResponse.ContentStream).RootElement;

            if (!getPoolData.TryGetProperty("name", out var poolNameJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string poolName = poolNameJson.ToString();
            Assert.AreEqual(poolName, TestEnvironment.PoolName);
        }

        [RecordedTest]
        public async Task GetPoolsSucceeds()
        {
            var numberOfReturnedPools = 0;
            await foreach (BinaryData poolData in _devBoxesClient.GetPoolsAsync(TestEnvironment.ProjectName))
            {
                numberOfReturnedPools++;
                JsonElement getPoolsResponseData = JsonDocument.Parse(poolData.ToStream()).RootElement;

                if (!getPoolsResponseData.TryGetProperty("name", out var poolNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
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
            await foreach (BinaryData scheduleData in _devBoxesClient.GetSchedulesAsync(TestEnvironment.ProjectName, TestEnvironment.PoolName))
            {
                numberOfReturnedSchedules++;
                JsonElement getSchedulesResponseData = JsonDocument.Parse(scheduleData.ToStream()).RootElement;

                if (!getSchedulesResponseData.TryGetProperty("name", out var poolNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string poolName = poolNameJson.ToString();
                Assert.AreEqual("default", poolName);
            }

            Assert.AreEqual(1, numberOfReturnedSchedules);
        }

        [RecordedTest]
        public async Task GetScheduleSucceeds()
        {
            Response getScheduleResponse = await _devBoxesClient.GetScheduleAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.PoolName,
                "default");

            JsonElement getScheduleData = JsonDocument.Parse(getScheduleResponse.ContentStream).RootElement;

            if (!getScheduleData.TryGetProperty("name", out var scheduleNameJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string scheduleName = scheduleNameJson.ToString();
            Assert.AreEqual("default", scheduleName);
        }

        [RecordedTest]
        public async Task GetActionsSucceeds()
        {
            var numberOfReturnedActions = 0;
            await foreach (BinaryData actionsData in _devBoxesClient.GetActionsAsync(TestEnvironment.ProjectName, DevBoxName))
            {
                numberOfReturnedActions++;
                JsonElement getActionsResponseData = JsonDocument.Parse(actionsData.ToStream()).RootElement;

                if (!getActionsResponseData.TryGetProperty("name", out var actionNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string actionName = actionNameJson.ToString();
                Assert.AreEqual("schedule-default", actionName);
            }

            Assert.AreEqual(1, numberOfReturnedActions);
        }

        [RecordedTest]
        public async Task GetActionSucceeds()
        {
            Response getActionResponse = await _devBoxesClient.GetActionAsync(
                TestEnvironment.ProjectName,
                DevBoxName,
                "schedule-default");

            JsonElement getActionData = JsonDocument.Parse(getActionResponse.ContentStream).RootElement;

            if (!getActionData.TryGetProperty("name", out var actionNameJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string actionName = actionNameJson.ToString();
            Assert.AreEqual("schedule-default", actionName);
        }

        [RecordedTest]
        public async Task SkipActionSucceeds()
        {
            Response skipActionResponse = await _devBoxesClient.SkipActionAsync(
                TestEnvironment.ProjectName,
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
                DevBoxName,
                "schedule-default",
                delayUntil);

            JsonElement delayActionData = JsonDocument.Parse(delayActionResponse.ContentStream).RootElement;
            if (!delayActionData.TryGetProperty("next", out var nextActionTimeJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            if (!nextActionTimeJson.TryGetProperty("scheduledTime", out var scheduledTimeJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            Assert.AreEqual(time, scheduledTimeJson.ToString());
        }

        [RecordedTest]
        public async Task DelayAllActionsSucceeds()
        {
            // Using fixed time to match sessions records
            DateTimeOffset delayUntil = DateTimeOffset.Parse("2023-05-02T16:01:53.3821556Z");
            var numberOfReturnedActions = 0;

            await foreach (BinaryData actionsData in _devBoxesClient.DelayAllActionsAsync(TestEnvironment.ProjectName, DevBoxName, delayUntil))
            {
                numberOfReturnedActions++;
                JsonElement getActionsResponseData = JsonDocument.Parse(actionsData.ToStream()).RootElement;

                if (!getActionsResponseData.TryGetProperty("result", out var actionResultJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
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
                DevBoxName,
                RequestContent.Create(content),
                userId: TestEnvironment.UserId);

            BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
            JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
            string devBoxProvisioningState = devBox.GetProperty("provisioningState").ToString();

            // Both states indicate successful provisioning
            bool devBoxProvisionSucceeded = devBoxProvisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase) || devBoxProvisioningState.Equals("ProvisionedWithWarning", StringComparison.OrdinalIgnoreCase);
            Assert.IsTrue(devBoxProvisionSucceeded);
        }
    }
}

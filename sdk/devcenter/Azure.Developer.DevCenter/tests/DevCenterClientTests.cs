// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    [PlaybackOnly("As deploy/delete manipulations with real resources take time.")]
    public class DevCenterClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        private DevCenterClient _devCenterClient;

        internal DevCenterClient GetDevCenterClient() =>
            InstrumentClient(new DevCenterClient(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new AzureDeveloperDevCenterClientOptions())));

        public DevCenterClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _devCenterClient = GetDevCenterClient();
        }

        [RecordedTest]
        public async Task GetProjectsSucceeds()
        {
            var numberOfReturnedProjects = 0;
            await foreach (BinaryData projectData in _devCenterClient.GetProjectsAsync(
                TestEnvironment.filter,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfReturnedProjects++;
                JsonElement projectResponseData = JsonDocument.Parse(projectData.ToStream()).RootElement;

                if (!projectResponseData.TryGetProperty("name", out var projectNameJson))
                {
                    Assert.Fail($"The JSON response received from the service does not include the necessary property: {"name"}");
                }

                string projectName = projectNameJson.ToString();
                Assert.AreEqual(TestEnvironment.ProjectName, projectName);
            }

            Assert.AreEqual(1, numberOfReturnedProjects);
        }

        [RecordedTest]
        public async Task GetProjectSucceeds()
        {
            Response getProjectResponse = await _devCenterClient.GetProjectAsync(TestEnvironment.ProjectName, TestEnvironment.context);

            JsonElement getProjectData = JsonDocument.Parse(getProjectResponse.ContentStream).RootElement;

            if (!getProjectData.TryGetProperty("name", out var projectNameJson))
            {
                Assert.Fail($"The JSON response received from the service does not include the necessary property: {"name"}");
            }

            string projectName = projectNameJson.ToString();
            Assert.AreEqual(TestEnvironment.ProjectName, projectName);
        }
    }
}

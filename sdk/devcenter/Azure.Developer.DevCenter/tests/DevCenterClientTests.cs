// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    //[PlaybackOnly("As deploy/delete manipulations with real resources take time.")]
    public class DevCenterClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        private DevCenterClient _devCenterClient;

        internal DevCenterClient GetDevCenterClient() =>
            InstrumentClient(new DevCenterClient(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new DevCenterClientOptions())));

        public DevCenterClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _devCenterClient = GetDevCenterClient();
        }

        [Test]
        public async Task GetProjectsSucceeds()
        {
            var numberOfReturnedProjects = 0;

            await foreach (DevCenterProject item in _devCenterClient.GetProjectsAsync())
            {
                numberOfReturnedProjects++;
                string projectName = item?.Name;
                if (string.IsNullOrWhiteSpace(projectName))
                {
                    Assert.Fail($"The response received from the service does not include the necessary property: {"name"}");
                }

                Assert.AreEqual(TestEnvironment.ProjectName, projectName);
            }

            Assert.AreEqual(1, numberOfReturnedProjects);
        }

        [Test]
        public async Task GetProjectSucceeds()
        {
            Response<DevCenterProject> getProjectResponse = await _devCenterClient.GetProjectAsync(TestEnvironment.ProjectName);

            string projectName = getProjectResponse?.Value?.Name;
            if (string.IsNullOrWhiteSpace(projectName))
            {
                Assert.Fail($"The response received from the service does not include the necessary property: {"name"}");
            }

            Assert.AreEqual(TestEnvironment.ProjectName, projectName);
        }
    }
}

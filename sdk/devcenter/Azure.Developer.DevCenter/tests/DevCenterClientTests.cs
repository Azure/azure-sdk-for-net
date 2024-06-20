// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
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
            List<DevCenterProject> projects = await _devCenterClient.GetProjectsAsync().ToEnumerableAsync();

            Assert.AreEqual(1, projects.Count);

            string projectName = projects[0].Name;
            if (string.IsNullOrWhiteSpace(projectName))
            {
                Assert.Fail($"The response received from the service does not include the necessary property: {"name"}");
            }

            Assert.AreEqual(TestEnvironment.ProjectName, projectName);
        }

        [Test]
        public async Task GetProjectSucceeds()
        {
            DevCenterProject project = await _devCenterClient.GetProjectAsync(TestEnvironment.ProjectName);

            string projectName = project.Name;
            if (string.IsNullOrWhiteSpace(projectName))
            {
                Assert.Fail($"The response received from the service does not include the necessary property: {"name"}");
            }

            Assert.AreEqual(TestEnvironment.ProjectName, projectName);
        }
    }
}

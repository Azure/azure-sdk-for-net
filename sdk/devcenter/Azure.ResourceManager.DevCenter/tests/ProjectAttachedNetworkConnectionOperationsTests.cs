// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class ProjectAttachedNetworkConnectionOperationsTests : DevCenterManagementTestBase
    {
        public ProjectAttachedNetworkConnectionOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task ListAndGetAttachedNetworksByProject()
        {
            ResourceIdentifier projectId = new ResourceIdentifier(TestEnvironment.DefaultProjectId);

            var project = Client.GetDevCenterProjectResource(projectId);

            List<ProjectAttachedNetworkConnectionResource> attachedNetworks = await project.GetProjectAttachedNetworkConnections().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(attachedNetworks.Count > 0);

            // Get one of the networks
            var network = (await project.GetProjectAttachedNetworkConnectionAsync(attachedNetworks.First().Data.Name)).Value;
            Assert.IsNotNull(network);
        }
    }
}

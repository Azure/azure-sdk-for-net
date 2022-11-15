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
    public class ProjectDevBoxDefinitionOperationsTests : DevCenterManagementTestBase
    {
        public ProjectDevBoxDefinitionOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task ListAndGetDevBoxDefinitionsByProject()
        {
            ResourceIdentifier projectId = new ResourceIdentifier(TestEnvironment.DefaultProjectId);

            var project = Client.GetProjectResource(projectId);

            List<ProjectDevBoxDefinitionResource> devBoxDefinitions = await project.GetProjectDevBoxDefinitions().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(devBoxDefinitions.Count > 0);

            // Get one of the definitions
            var network = (await project.GetProjectDevBoxDefinitionAsync(devBoxDefinitions.First().Data.Name)).Value;
            Assert.IsNotNull(network);
        }
    }
}

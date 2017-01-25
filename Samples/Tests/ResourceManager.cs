// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class ResourceManager
    {
        public ResourceManager(ITestOutputHelper output)
        {
            Microsoft.Azure.Management.Samples.Common.Utilities.LoggerMethod = output.WriteLine;
            Microsoft.Azure.Management.Samples.Common.Utilities.PauseMethod = TestHelper.ReadLine;
        }

        [Fact(Skip = "TODO: Assets location needs to be properly set")]
        [Trait("Samples", "ResourceManager")]
        public void DeployUsingARMTemplateTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                DeployUsingARMTemplate.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: Assets location needs to be properly set")]
        [Trait("Samples", "ResourceManager")]
        public void DeployUsingARMTemplateWithProgressTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                DeployUsingARMTemplateWithProgress.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: Assets location needs to be properly set")]
        [Trait("Samples", "ResourceManager")]
        public void ManageResourceTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageResource.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "TODO: Assets location needs to be properly set")]
        [Trait("Samples", "ResourceManager")]
        public void ManageResourceGroupTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageResourceGroup.Program.RunSample(rollUpClient);
            }
        }
    }
}

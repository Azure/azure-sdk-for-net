// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Databricks.Tests.Scenario
{
    public class DatabricksWorkspaceTests : DatabricksManagementTestBase
    {
        public DatabricksWorkspaceTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        [Ignore("Recording is blocked by SetUp because ArmClient.GetDefaultSubscriptionAsync emits an Azure.Core.Http.Request diagnostic scope without az.namespace before the recording session exists.")]
        public async Task GetAll_ListsDatabricksWorkspaces()
        {
            var workspaces = await DefaultSubscription.GetDatabricksWorkspacesAsync().ToEnumerableAsync();
            Assert.That(workspaces, Is.Not.Null);
        }
    }
}

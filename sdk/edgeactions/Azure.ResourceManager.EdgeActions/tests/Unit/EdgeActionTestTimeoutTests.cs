// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.EdgeActions.Tests.Scenario;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionTestTimeoutTests
    {
        [TestCase(0, 20)]
        [TestCase(1, 50)]
        [TestCase(2, 90)]
        [TestCase(3, 130)]
        public void DeploymentBudgetsIncludeBuffer(int deployments, int minutes)
        {
            Assert.That(EdgeActionsManagementTestBase.GetTestTimeout(deployments), Is.EqualTo(TimeSpan.FromMinutes(minutes)));
        }

        [Test]
        public void NegativeDeploymentCountIsRejected()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EdgeActionsManagementTestBase.GetTestTimeout(-1));
        }

        [TestCase(typeof(EdgeActionCollectionTests), nameof(EdgeActionCollectionTests.Exists), 20)]
        [TestCase(typeof(EdgeActionLifecycleTests), nameof(EdgeActionLifecycleTests.EdgeActionTags), 20)]
        [TestCase(typeof(EdgeActionLifecycleTests), nameof(EdgeActionLifecycleTests.VersionMetadata), 20)]
        [TestCase(typeof(EdgeActionLifecycleTests), nameof(EdgeActionLifecycleTests.ExecutionFilterLifecycle), 90)]
        [TestCase(typeof(EdgeActionLifecycleTests), nameof(EdgeActionLifecycleTests.VersionsAndExecutionFilters), 130)]
        public void RecordedScenariosHaveExpectedBudgets(Type fixture, string methodName, int minutes)
        {
            PropertyAttribute property = fixture.GetMethod(methodName).GetCustomAttributes<PropertyAttribute>()
                .SingleOrDefault(attribute => attribute.Properties.ContainsKey(EdgeActionsManagementTestBase.DeploymentCountProperty));
            int deployments = (int?)property?.Properties.Get(EdgeActionsManagementTestBase.DeploymentCountProperty) ?? 0;
            Assert.That(EdgeActionsManagementTestBase.GetTestTimeout(deployments), Is.EqualTo(TimeSpan.FromMinutes(minutes)));
        }
    }
}

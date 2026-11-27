// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.ContainerServiceFleet.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerServiceFleet.Tests.Scenario
{
    public class ModelFactoryCompatibilityTests
    {
        [Test]
        public void ShortenedPositionalCallsPreserveConcurrency()
        {
            var group = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateGroup("group", "2");
            var stage = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateStage("stage", null, "env=prod", 30, "3");
            var groupStatus = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateGroupStatus(null, "group", 2);
            var stageStatus = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateStageStatus(null, "stage", 3);

            Assert.AreEqual("2", group.MaxConcurrency);
            Assert.IsNull(group.MaxAllowedFailures);
            Assert.AreEqual("3", stage.MaxConcurrency);
            Assert.AreEqual("env=prod", stage.MemberSelectorByLabel);
            Assert.AreEqual(30, stage.AfterStageWaitInSeconds);
            Assert.IsNull(stage.MaxAllowedFailures);
            Assert.AreEqual(2, groupStatus.MaxConcurrency);
            Assert.IsNull(groupStatus.FailureCount);
            Assert.IsNull(groupStatus.MaxAllowedFailures);
            Assert.AreEqual(3, stageStatus.MaxConcurrency);
            Assert.IsNull(stageStatus.FailureCount);
            Assert.IsNull(stageStatus.MaxAllowedFailures);
        }

        [Test]
        public void NewParametersFollowReleasedPositionalParameters()
        {
            var group = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateGroup("group", "2", "env=prod", null, null, "25%");
            var stage = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateStage("stage", new[] { group }, "env=prod", 30, "3", null, null, "50%");
            var groupStatus = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateGroupStatus(null, "group", 2, null, null, null, 1, 4);
            var waitStatus = ArmContainerServiceFleetModelFactory.ContainerServiceFleetWaitStatus();
            var stageStatus = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateStageStatus(null, "stage", 3, new[] { groupStatus }, null, null, waitStatus, 2, 5);

            Assert.AreEqual("2", group.MaxConcurrency);
            Assert.AreEqual("env=prod", group.MemberSelectorByLabel);
            Assert.AreEqual("25%", group.MaxAllowedFailures);
            Assert.AreEqual("3", stage.MaxConcurrency);
            Assert.AreSame(group, stage.Groups[0]);
            Assert.AreEqual("50%", stage.MaxAllowedFailures);
            Assert.AreEqual(2, groupStatus.MaxConcurrency);
            Assert.AreEqual(1, groupStatus.FailureCount);
            Assert.AreEqual(4, groupStatus.MaxAllowedFailures);
            Assert.AreEqual(3, stageStatus.MaxConcurrency);
            Assert.AreSame(groupStatus, stageStatus.Groups[0]);
            Assert.AreSame(waitStatus, stageStatus.AfterStageWaitStatus);
            Assert.AreEqual(2, stageStatus.FailureCount);
            Assert.AreEqual(5, stageStatus.MaxAllowedFailures);
        }

        [Test]
        public void ReleasedFullSignaturesRemainCallable()
        {
            var group = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateGroup("group", "2", "env=prod", null, null);
            var stage = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateStage("stage", new[] { group }, "env=prod", 30, "3", null, null);
            var groupStatus = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateGroupStatus(null, "group", 2, null, null, null);
            var stageStatus = ArmContainerServiceFleetModelFactory.ContainerServiceFleetUpdateStageStatus(null, "stage", 3, new[] { groupStatus }, null, null, null);

            Assert.AreEqual("2", group.MaxConcurrency);
            Assert.AreEqual("3", stage.MaxConcurrency);
            Assert.AreEqual(2, groupStatus.MaxConcurrency);
            Assert.AreEqual(3, stageStatus.MaxConcurrency);
        }
    }
}

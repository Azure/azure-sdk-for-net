﻿namespace Automation.Tests.ScenarioTests.UpdateManagement
{
    using System;

    using Microsoft.Azure.Management.Automation;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class SoftwareUpdateConfigurationRunTests : BaseTest
    {
        [Fact]
        public void CanGetRunById()
        {
            var runId = Guid.Parse("6ff49ee2-092a-48bf-841a-c3d645611689");
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var run = this.automationClient.SoftwareUpdateConfigurationRuns.GetById(ResourceGroupName, AutomationAccountName, runId);
                Assert.NotNull(run);
                Assert.Equal(runId.ToString(), run.Name);
            }
        }

        [Fact]
        public void CanGetAllRuns()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.List(ResourceGroupName, AutomationAccountName);
                Assert.NotNull(runs.Value);
                Assert.Equal(7, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByConfigurationName()
        {
            const string configName = "all-01";
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.ListByConfigurationName(ResourceGroupName, AutomationAccountName, configName);
                Assert.NotNull(runs.Value);
                Assert.Equal(2, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByOs()
        {
            const string os = "Windows";
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.ListByOsType(ResourceGroupName, AutomationAccountName, os);
                Assert.NotNull(runs.Value);
                Assert.Equal(7, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByStatus()
        {
            const string status = "Failed";
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.ListByStatus(ResourceGroupName, AutomationAccountName, status);
                Assert.NotNull(runs.Value);
                Assert.Equal(0, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByStartTime()
        {
            var startTime = DateTime.Parse("2018-10-23T11:02:00-8").ToUniversalTime();
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.ListByStartTime(ResourceGroupName, AutomationAccountName, startTime);
                Assert.NotNull(runs.Value);
                Assert.Equal(1, runs.Value.Count);
            }
        }
    }
}
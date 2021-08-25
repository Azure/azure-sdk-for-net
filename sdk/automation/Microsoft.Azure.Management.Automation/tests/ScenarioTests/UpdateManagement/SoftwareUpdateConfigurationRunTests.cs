namespace Automation.Tests.ScenarioTests.UpdateManagement
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
            var runId = Guid.Parse("e5934d51-6e50-41f8-b860-3a3657040f8d");
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(this.GetType()))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.List(ResourceGroupName, AutomationAccountName);
                Assert.NotNull(runs.Value);
                Assert.Equal(1, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByConfigurationName()
        {
            const string configName = "test-suc";
            using (var context = MockContext.Start(this.GetType()))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.ListByConfigurationName(ResourceGroupName, AutomationAccountName, configName);
                Assert.NotNull(runs.Value);
                Assert.Equal(1, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByOs()
        {
            const string os = "Windows";
            using (var context = MockContext.Start(this.GetType()))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.ListByOsType(ResourceGroupName, AutomationAccountName, os);
                Assert.NotNull(runs.Value);
                Assert.Equal(1, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByStatus()
        {
            const string status = "Failed";
            using (var context = MockContext.Start(this.GetType()))
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
            var startTime = DateTime.Parse("2021-03-31T17:10:39+05:30").ToUniversalTime();
            using (var context = MockContext.Start(this.GetType()))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationRuns.ListByStartTime(ResourceGroupName, AutomationAccountName, startTime);
                Assert.NotNull(runs.Value);
                Assert.Equal(1, runs.Value.Count);
            }
        }
    }
}
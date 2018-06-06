namespace Automation.Tests.ScenarioTests.UpdateManagement
{
    using System;

    using Microsoft.Azure.Management.Automation;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class SoftwareUpdateConfigurationMachineRunTests : BaseTest
    {
        [Fact]
        public void CanGetMachineRunById()
        {
            var runId = Guid.Parse("b56021cf-1643-4bfb-99d3-6b798db242f5");
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var run = this.automationClient.SoftwareUpdateConfigurationMachineRuns.GetById(ResourceGroupName, AutomationAccountName, runId);
                Assert.NotNull(run);
                Assert.Equal(runId.ToString(), run.Name);
            }
        }

        [Fact]
        public void CanGetAllMachineRuns()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationMachineRuns.List(ResourceGroupName, AutomationAccountName);
                Assert.NotNull(runs.Value);
                Assert.Equal(27, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByCorrelationId()
        {
            Guid correlationId = Guid.Parse("595159c7-64cb-436f-892d-b44b31970f7a");
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationMachineRuns.ListByCorrelationId(ResourceGroupName, AutomationAccountName, correlationId);
                Assert.NotNull(runs.Value);
                Assert.Equal(2, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByStatus()
        {
            const string status = "Failed";
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationMachineRuns.ListByStatus(ResourceGroupName, AutomationAccountName, status);
                Assert.NotNull(runs.Value);
                Assert.Equal(4, runs.Value.Count);
            }
        }
    }
}
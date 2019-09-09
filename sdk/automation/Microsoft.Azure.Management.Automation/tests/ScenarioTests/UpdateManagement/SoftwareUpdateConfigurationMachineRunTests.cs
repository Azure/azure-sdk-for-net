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
            var runId = Guid.Parse("da6493d0-de31-48d9-bc78-08e3c1d80d0a");
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(this.GetType()))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationMachineRuns.List(ResourceGroupName, AutomationAccountName);
                Assert.NotNull(runs.Value);
                Assert.Equal(16, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByCorrelationId()
        {
            Guid correlationId = Guid.Parse("6ff49ee2-092a-48bf-841a-c3d645611689");
            using (var context = MockContext.Start(this.GetType()))
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
            const string status = "Succeeded";
            using (var context = MockContext.Start(this.GetType()))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationMachineRuns.ListByStatus(ResourceGroupName, AutomationAccountName, status);
                Assert.NotNull(runs.Value);
                Assert.Equal(16, runs.Value.Count);
            }
        }
    }
}
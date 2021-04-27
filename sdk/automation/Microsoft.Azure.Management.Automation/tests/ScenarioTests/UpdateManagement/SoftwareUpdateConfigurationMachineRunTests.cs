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
            var runId = Guid.Parse("3c789f68-05aa-4614-9d1a-b557b39cc53c");
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
                Assert.Equal(1, runs.Value.Count);
            }
        }

        [Fact]
        public void CanGetAllRunsByCorrelationId()
        {
            Guid correlationId = Guid.Parse("e5934d51-6e50-41f8-b860-3a3657040f8d");
            using (var context = MockContext.Start(this.GetType()))
            {
                this.CreateAutomationClient(context);

                var runs = this.automationClient.SoftwareUpdateConfigurationMachineRuns.ListByCorrelationId(ResourceGroupName, AutomationAccountName, correlationId);
                Assert.NotNull(runs.Value);
                Assert.Equal(1, runs.Value.Count);
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
                Assert.Equal(1, runs.Value.Count);
            }
        }
    }
}
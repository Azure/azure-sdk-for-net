namespace Automation.Tests.ScenarioTests.UpdateManagement
{
    using System;
    using System.Linq;

    using Microsoft.Azure.Management.Automation;
    using Microsoft.Azure.Management.Automation.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class SoftwareUpdateConfigurationTests : BaseTest
    {
        [Fact]
        public void CanCreateGetAndDelete()
        {
            using (var context = MockContext.Start(GetType().FullName))
            {
                this.CreateAutomationClient(context);

                // Create and get the first SUC (targeting 1 VMs)
                var sucProperties = this.CreateSoftwareUpdateConfigurationModel(new[] { VM_01 });
                var createResult = this.automationClient.SoftwareUpdateConfigurations.Create(ResourceGroupName, AutomationAccountName, updateConfigurationName_01, sucProperties);
                Assert.NotNull(createResult);

                var getResult = this.automationClient.SoftwareUpdateConfigurations.GetByName(ResourceGroupName, AutomationAccountName, updateConfigurationName_01);
                Assert.NotNull(getResult);

                // Create and get the second SUC (targeting 2 VMs)
                sucProperties = this.CreateSoftwareUpdateConfigurationModel(new[] { VM_01, VM_02 });
                createResult = this.automationClient.SoftwareUpdateConfigurations.Create(ResourceGroupName, AutomationAccountName, updateConfigurationName_02, sucProperties);
                Assert.NotNull(createResult);

                getResult = this.automationClient.SoftwareUpdateConfigurations.GetByName(ResourceGroupName, AutomationAccountName, updateConfigurationName_02);
                Assert.NotNull(getResult);

                // List all SUCs
                var listResult = this.automationClient.SoftwareUpdateConfigurations.List(ResourceGroupName, AutomationAccountName);
                Assert.NotNull(listResult);
                Assert.NotNull(listResult.Value);
                Assert.Equal(9, listResult.Value.Count);

                // List for specific VM
                listResult = this.automationClient.SoftwareUpdateConfigurations.ListByAzureVirtualMachine(ResourceGroupName, AutomationAccountName, VM_01);
                Assert.NotNull(listResult);
                Assert.NotNull(listResult.Value);
                Assert.Equal(6, listResult.Value.Count);
                var suc = listResult.Value.Where(v => v.Name.Equals(updateConfigurationName_01, StringComparison.OrdinalIgnoreCase)).Single();
                Assert.Equal(updateConfigurationName_01, suc.Name);

                // Delete both
                this.automationClient.SoftwareUpdateConfigurations.Delete(ResourceGroupName, AutomationAccountName, updateConfigurationName_01);

                Assert.Throws<ErrorResponseException>(() =>
                {
                    this.automationClient.SoftwareUpdateConfigurations.GetByName(ResourceGroupName, AutomationAccountName, updateConfigurationName_01);
                });
                
                this.automationClient.SoftwareUpdateConfigurations.Delete(ResourceGroupName, AutomationAccountName, updateConfigurationName_02);

                Assert.Throws<ErrorResponseException>(() =>
                {
                    this.automationClient.SoftwareUpdateConfigurations.GetByName(ResourceGroupName, AutomationAccountName, updateConfigurationName_02);
                });
            }
        }

        private SoftwareUpdateConfiguration CreateSoftwareUpdateConfigurationModel(string[] azureVirtualMachines)
        {
            var updateConfiguration = new UpdateConfiguration
            {
                OperatingSystem = OperatingSystemType.Windows,
                Windows = new WindowsProperties
                {
                    IncludedUpdateClassifications = WindowsUpdateClasses.Critical + ',' + WindowsUpdateClasses.Security,
                    ExcludedKbNumbers = new[] { "KB123", "KB123" }
                },
                Duration = TimeSpan.FromHours(3),
                AzureVirtualMachines = azureVirtualMachines
            };

            var scheduleInfo = new ScheduleProperties
            {
                Frequency = ScheduleFrequency.Day,
                StartTime = DateTime.Parse("2018-05-05T19:26:00.000"),
                Interval = 1,
                TimeZone = "America/Los_Angeles"
            };

            return new SoftwareUpdateConfiguration(updateConfiguration, scheduleInfo);
        }
    }
}
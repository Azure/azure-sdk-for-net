namespace Automation.Tests.ScenarioTests.UpdateManagement
{
    using System;
    using System.Collections.Generic;
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
            using (var context = MockContext.Start(this.GetType()))
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
                Assert.NotNull(getResult.UpdateConfiguration);
                Assert.NotNull(getResult.UpdateConfiguration.Targets);
                Assert.NotNull(getResult.UpdateConfiguration.Targets.AzureQueries);
                Assert.Equal(1, getResult.UpdateConfiguration.Targets.AzureQueries.Count);
                Assert.Equal(2, getResult.UpdateConfiguration.Targets.AzureQueries.First().Scope.Count);
                Assert.Equal(2, getResult.UpdateConfiguration.Targets.NonAzureQueries.Count);
                Assert.NotNull(getResult.Tasks);
                Assert.NotNull(getResult.Tasks.PreTask);
                Assert.Equal("preScript", getResult.Tasks.PreTask.Source);
                Assert.NotNull(getResult.Tasks.PostTask);
                Assert.NotNull(getResult.Tasks.PostTask.Source);
                Assert.NotNull(getResult.Tasks.PostTask.Parameters);
                Assert.Equal(1, getResult.Tasks.PostTask.Parameters.Count);
                Assert.Equal("postScript", getResult.Tasks.PostTask.Source);

                // List all SUCs
                var listResult = this.automationClient.SoftwareUpdateConfigurations.List(ResourceGroupName, AutomationAccountName);
                Assert.NotNull(listResult);
                Assert.NotNull(listResult.Value);
                Assert.Equal(3, listResult.Value.Count);


                // List for specific VM
                listResult = this.automationClient.SoftwareUpdateConfigurations.ListByAzureVirtualMachine(ResourceGroupName, AutomationAccountName, VM_01);
                Assert.NotNull(listResult);
                Assert.NotNull(listResult.Value);
                Assert.Equal(3, listResult.Value.Count);
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
                AzureVirtualMachines = azureVirtualMachines,
                Targets = new TargetProperties
                {
                    AzureQueries = new List<AzureQueryProperties>
                    {
                        new AzureQueryProperties
                        {
                            Locations = new List<string>
                            {
                                "Japan East",
                                "UK South"
                            },
                            Scope = new List<string>
                            {
                                "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/sdk-tests-UM-rg",
                                "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d"
                            },
                            TagSettings = new TagSettingsProperties
                            {
                                Tags = new Dictionary<string, IList<string>>
                                {
                                    {
                                        "tag1" , new List<string>
                                        {
                                            "tag1Value1",
                                            "tag1Value2"
                                        }
                                    },
                                    {
                                        "tag2" , new List<string>
                                        {
                                            "tag2Value1",
                                            "tag2Value2"
                                        }
                                    },
                                },
                                FilterOperator = TagOperators.All
                            }
                        }
                    },
                    NonAzureQueries = new List<NonAzureQueryProperties>
                    {
                        new NonAzureQueryProperties
                        {
                            FunctionAlias = "SavedSearch1",
                            WorkspaceId = "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourcegroups/defaultresourcegroup-eus/providers/microsoft.operationalinsights/workspaces/workspace-a159f395-2f28-4897-b66e-a3b3b9a7cde5-eus"
                        },
                        new NonAzureQueryProperties
                        {
                            FunctionAlias = "SavedSearch2",
                            WorkspaceId = "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourcegroups/defaultresourcegroup-eus/providers/microsoft.operationalinsights/workspaces/workspace-a159f395-2f28-4897-b66e-a3b3b9a7cde5-eus"
                        }
                    }
                }
            };

            var scheduleInfo = new SUCScheduleProperties
            {
                Frequency = ScheduleFrequency.Day,
                StartTime = DateTime.Parse("2021-03-31T16:55:00.000"),
                Interval = 1,
                TimeZone = "America/Los_Angeles"
            };

            var tasks = new SoftwareUpdateConfigurationTasks
            {
                PreTask = new TaskProperties
                {
                    Source = "preScript"
                },
                PostTask = new TaskProperties
                {
                    Source = "postScript",
                    Parameters = new Dictionary<string, string>() { { "Num", "4" } }
                }
            };

            return new SoftwareUpdateConfiguration(updateConfiguration, scheduleInfo, tasks: tasks);
        }
    }
}
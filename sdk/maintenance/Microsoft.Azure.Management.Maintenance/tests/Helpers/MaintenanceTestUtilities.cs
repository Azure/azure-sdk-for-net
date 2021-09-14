// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Maintenance.Tests
{
    public class MaintenanceTestUtilities
    {
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static MaintenanceManagementClient GetMaintenanceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<MaintenanceManagementClient>(handlers: handler);
            return client;
        }

        public static ResourceGroup CreateResourceGroup(ResourceManagementClient client)
        {
            var resourceGroupName = TestUtilities.GenerateName("maintenance_rg");

            return client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup
            {
                Location = "eastus2euap"
            });
        }

        public static MaintenanceConfiguration CreateTestMaintenanceConfiguration(string maintenanceConfigurationName)
        {
            var maintenanceConfiguration = new MaintenanceConfiguration(
                name: maintenanceConfigurationName,
                location: "eastus2euap",
                startDateTime: "2021-09-01 01:00" ,
                duration: "03:00",
                timeZone: "India Standard Time",
                recurEvery: "2Weeks Monday",
                maintenanceScope: MaintenanceScope.Host);

            return maintenanceConfiguration;
        }

        public static MaintenanceConfiguration CreateTestMaintenanceConfigurationInGuestPatchScope(string maintenanceConfigurationName, bool advancePatchOption = false)
        {
            var maintenanceConfiguration = new MaintenanceConfiguration(
                name: maintenanceConfigurationName,
                location: "eastus2euap",
                startDateTime: "2021-09-01 01:00",
                maintenanceScope: MaintenanceScope.InGuestPatch,
                duration: "01:00",
                timeZone: "India Standard Time",
                recurEvery: "2Months Third Monday Offset-4");

            if (advancePatchOption)
            {
                maintenanceConfiguration.InstallPatches = new InputPatchConfiguration()
                {
                    PreTasks = new List<TaskProperties> 
                    {
                        new TaskProperties()
                        {
                            Source = "/subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourceGroups/DefaultResourceGroup-EUS/providers/Microsoft.Automation/automationAccounts/Automate-42c974dd-2c03-4f1b-96ad-b07f050aaa74-EUS/runbooks/foo",
                            TaskScope = TaskScope.Global,
                            Parameters = new Dictionary<string,string>() { ["param1"] = "value1" }
                        }
                    },
                    LinuxParameters = new InputLinuxParameters()
                    {
                        ClassificationsToInclude = new List<string> (){ "Other" },
                        PackageNameMasksToInclude = new List<string>() { "apt" }
                    },
                    WindowsParameters = new InputWindowsParameters()
                    {
                        ClassificationsToInclude = new List<string>() { "UpdateRollup", "ServicePack" },
                        KbNumbersToInclude = new List<string> { "KB123456" }
                    },
                    RebootSetting = RebootOptions.IfRequired
                };
            }

            return maintenanceConfiguration;
        }


        public static MaintenanceConfiguration CreateTestPublicMaintenanceConfiguration(string maintenanceConfigurationName)
        {
            var maintenanceConfiguration = new MaintenanceConfiguration(
                name: maintenanceConfigurationName,
                location: "eastus2euap",
                startDateTime: "2021-09-01 01:00",
                duration: "02:00",
                timeZone: "India Standard Time",
                recurEvery: "2Weeks Monday",
                visibility: Visibility.Public,
                maintenanceScope: MaintenanceScope.SQLDB,
                extensionProperties: new Dictionary<string, string>() { ["isAvailable"] = "true" });

            return maintenanceConfiguration;
        }

        public static void VerifyMaintenanceConfigurationProperties(MaintenanceConfiguration expected, MaintenanceConfiguration actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.MaintenanceScope, actual.MaintenanceScope);

            if (actual.MaintenanceScope == MaintenanceScope.InGuestPatch)
            {
                if (actual.InstallPatches == null)
                {
                    Assert.Equal(expected.InstallPatches, actual.InstallPatches);
                    return;
                }

                Assert.Equal(expected.InstallPatches.RebootSetting, actual.InstallPatches.RebootSetting);
                Assert.Equal(1, actual.InstallPatches.LinuxParameters.PackageNameMasksToInclude.Count);
                Assert.Equal(expected.InstallPatches.LinuxParameters.PackageNameMasksToInclude[0], actual.InstallPatches.LinuxParameters.PackageNameMasksToInclude[0]);
                Assert.Equal(1, actual.InstallPatches.LinuxParameters.ClassificationsToInclude.Count);
                Assert.Equal(expected.InstallPatches.LinuxParameters.ClassificationsToInclude[0], actual.InstallPatches.LinuxParameters.ClassificationsToInclude[0]);
                Assert.Equal(1, actual.InstallPatches.WindowsParameters.KbNumbersToInclude.Count);
                Assert.Equal(expected.InstallPatches.WindowsParameters.KbNumbersToInclude[0], actual.InstallPatches.WindowsParameters.KbNumbersToInclude[0]);
                Assert.Equal(2, actual.InstallPatches.WindowsParameters.ClassificationsToInclude.Count);
                Assert.Equal(expected.InstallPatches.WindowsParameters.ClassificationsToInclude[0], actual.InstallPatches.WindowsParameters.ClassificationsToInclude[0]);
                Assert.Equal(expected.InstallPatches.WindowsParameters.ClassificationsToInclude[1], actual.InstallPatches.WindowsParameters.ClassificationsToInclude[1]);
                Assert.Equal(1, actual.InstallPatches.PreTasks.Count);
                Assert.Equal(expected.InstallPatches.PreTasks[0].Source, actual.InstallPatches.PreTasks[0].Source);
                Assert.Equal(expected.InstallPatches.PreTasks[0].TaskScope, actual.InstallPatches.PreTasks[0].TaskScope);
                foreach (var kvp in expected.InstallPatches.PreTasks[0].Parameters)
                {
                    Assert.True(actual.InstallPatches.PreTasks[0].Parameters.TryGetValue(kvp.Key, out var _));
                    Assert.Equal(expected.InstallPatches.PreTasks[0].Parameters[kvp.Key], actual.InstallPatches.PreTasks[0].Parameters[kvp.Key]);
                }
            }
        }
    }
}

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
                Location = "westus"
            });
        }

        public static MaintenanceConfiguration CreateTestMaintenanceConfiguration(string maintenanceConfigurationName)
        {
            var maintenanceConfiguration = new MaintenanceConfiguration(
                name: maintenanceConfigurationName,
                location: "westus",
                startDateTime: "2020-04-01 01:00:00" ,
                maintenanceScope: MaintenanceScope.Host);

            return maintenanceConfiguration;
        }

        public static MaintenanceConfiguration CreateTestPublicMaintenanceConfiguration(string maintenanceConfigurationName)
        {
            var maintenanceConfiguration = new MaintenanceConfiguration(
                name: maintenanceConfigurationName,
                location: "westus",
                startDateTime: "2020-04-01 01:00:00",
                visibility: Visibility.Public,
                maintenanceScope: MaintenanceScope.SQLDB);

            return maintenanceConfiguration;
        }

        public static void VerifyMaintenanceConfigurationProperties(MaintenanceConfiguration expected, MaintenanceConfiguration actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.StartDateTime,actual.StartDateTime);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.MaintenanceScope, actual.MaintenanceScope);
        }
    }
}

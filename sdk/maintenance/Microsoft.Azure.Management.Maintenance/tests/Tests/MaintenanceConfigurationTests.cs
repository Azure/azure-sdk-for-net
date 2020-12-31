// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Maintenance.Tests
{
    /// <summary>
    /// Tests for Maintenance SDK.
    /// </summary>
    public class MaintenanceConfigurationTests : TestBase
    {
        /// <summary>
        /// Test create maintenance configuration.
        /// </summary>
        [Fact]
        public void MaintenanceConfigurationCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                var resourceGroup = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create maintenance configuration.
                var maintenanceConfigurationName = TestUtilities.GenerateName("maintenancesdk");
                var maintenanceConfiguration = MaintenanceTestUtilities.CreateTestMaintenanceConfiguration(maintenanceConfigurationName);

                // Verify created maintenance configuration.
                var createdMaintenanceConfiguration = maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup.Name, maintenanceConfigurationName, maintenanceConfiguration);
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration, createdMaintenanceConfiguration);
            }
        }

        /// <summary>
        /// Test get maintenance configuration.
        /// </summary>
        [Fact]
        public void MaintenanceConfigurationGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                var resourceGroup = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create maintenance configuration.
                var maintenanceConfigurationName = TestUtilities.GenerateName("maintenancesdk");
                var maintenanceConfiguration = MaintenanceTestUtilities.CreateTestMaintenanceConfiguration(maintenanceConfigurationName);

                // Verify created maintenance configuration.
                var createdMaintenanceConfiguration = maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup.Name, maintenanceConfigurationName, maintenanceConfiguration);
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration, createdMaintenanceConfiguration);

                // Verifiy retrieved maintenance configuration.
                var retrievedMaintenanceConfiguration = maintenanceClient.MaintenanceConfigurations.Get(resourceGroup.Name, maintenanceConfigurationName);
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration, retrievedMaintenanceConfiguration);
            }
        }

        /// <summary>
        /// Test list maintenance configurations.
        /// </summary>
        [Fact]
        public void MaintenanceConfigurationListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                // Create 2 maintenance configurations.
                var resourceGroup1 = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);
                var maintenanceConfigurationName1 = TestUtilities.GenerateName("maintenancesdk");
                var maintenanceConfiguration1 = MaintenanceTestUtilities.CreateTestMaintenanceConfiguration(maintenanceConfigurationName1);
                maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup1.Name, maintenanceConfigurationName1, maintenanceConfiguration1);

                var resourceGroup2 = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);
                var maintenanceConfigurationName2 = TestUtilities.GenerateName("acinetsdk");
                var maintenanceConfiguration2 = MaintenanceTestUtilities.CreateTestMaintenanceConfiguration(maintenanceConfigurationName2);
                maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup2.Name, maintenanceConfigurationName2, maintenanceConfiguration2);

                // Verify both maintenance configurations exist when listing.
                var retrievedMaintenanceConfigurations = maintenanceClient.MaintenanceConfigurations.List();
                Assert.True(retrievedMaintenanceConfigurations.Count() >= 2);
                var retrievedMaintenanceConfiguration1 = retrievedMaintenanceConfigurations.Where(cg => cg.Name == maintenanceConfigurationName1).FirstOrDefault();
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration1, retrievedMaintenanceConfiguration1);
                var retrievedMaintenanceConfiguration2 = retrievedMaintenanceConfigurations.Where(cg => cg.Name == maintenanceConfigurationName2).FirstOrDefault();
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration2, retrievedMaintenanceConfiguration2);
            }
        }

        /// <summary>
        /// Test list public maintenance configurations.
        /// </summary>
        [Fact]
        public void PublicMaintenanceConfigurationListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                // Create 2 maintenance configurations.
                var resourceGroup1 = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);
                var maintenanceConfigurationName1 = TestUtilities.GenerateName("maintenancesdk");
                var maintenanceConfiguration1 = MaintenanceTestUtilities.CreateTestPublicMaintenanceConfiguration(maintenanceConfigurationName1);
                maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup1.Name, maintenanceConfigurationName1, maintenanceConfiguration1);

                var resourceGroup2 = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);
                var maintenanceConfigurationName2 = TestUtilities.GenerateName("acinetsdk");
                var maintenanceConfiguration2 = MaintenanceTestUtilities.CreateTestPublicMaintenanceConfiguration(maintenanceConfigurationName2);
                maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup2.Name, maintenanceConfigurationName2, maintenanceConfiguration2);

                // Verify both maintenance configurations exist when listing.
                var retrievedMaintenanceConfigurations = maintenanceClient.PublicMaintenanceConfigurations.List();
                Assert.True(retrievedMaintenanceConfigurations.Count() >= 2);
                var retrievedMaintenanceConfiguration1 = retrievedMaintenanceConfigurations.Where(cg => cg.Name == maintenanceConfigurationName1).FirstOrDefault();
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration1, retrievedMaintenanceConfiguration1);
                var retrievedMaintenanceConfiguration2 = retrievedMaintenanceConfigurations.Where(cg => cg.Name == maintenanceConfigurationName2).FirstOrDefault();
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration2, retrievedMaintenanceConfiguration2);
            }
        }

        /// <summary>
        /// Test get maintenance configuration.
        /// </summary>
        [Fact]
        public void PublicMaintenanceConfigurationGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                var resourceGroup = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create maintenance configuration.
                var maintenanceConfigurationName = TestUtilities.GenerateName("maintenancesdk");
                var maintenanceConfiguration = MaintenanceTestUtilities.CreateTestPublicMaintenanceConfiguration(maintenanceConfigurationName);

                // Verifiy retrieved maintenance configuration.
                var retrievedMaintenanceConfiguration = maintenanceClient.PublicMaintenanceConfigurations.Get( maintenanceConfigurationName);
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration, retrievedMaintenanceConfiguration);
            }
        }

    }
}

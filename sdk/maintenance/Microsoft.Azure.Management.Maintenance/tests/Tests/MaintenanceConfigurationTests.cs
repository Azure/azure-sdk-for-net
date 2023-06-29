// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
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
                maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup.Name, maintenanceConfigurationName, maintenanceConfiguration);

                // Verifiy retrieved maintenance configuration.
                var retrievedMaintenanceConfiguration = maintenanceClient.PublicMaintenanceConfigurations.Get( maintenanceConfigurationName);
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration, retrievedMaintenanceConfiguration);
            }
        }

        /// <summary>
        /// Test create maintenance configuration.
        /// </summary>
        [Fact]
        public void MaintenanceConfigurationCreateInGuestPatchTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                var resourceGroup = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create maintenance configuration.
                var maintenanceConfigurationName1 = TestUtilities.GenerateName("maintenancesdk");
                var maintenanceConfigurationName2 = TestUtilities.GenerateName("maintenancesdk");
                var maintenanceConfiguration1 = MaintenanceTestUtilities.CreateTestMaintenanceConfigurationInGuestPatchScope(maintenanceConfigurationName1);
                var maintenanceConfiguration2 = MaintenanceTestUtilities.CreateTestMaintenanceConfigurationInGuestPatchScope(maintenanceConfigurationName2, true);

                // Verify created maintenance configuration.
                var createdMaintenanceConfiguration1 = maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup.Name, maintenanceConfigurationName1, maintenanceConfiguration1);
                var createdMaintenanceConfiguration2 = maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup.Name, maintenanceConfigurationName2, maintenanceConfiguration2);
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration1, createdMaintenanceConfiguration1);
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration2, createdMaintenanceConfiguration2);
            }
        }

        /// <summary>
        /// Test create maintenance configuration.
        /// </summary>
        [Fact]
        public void MaintenanceConfigurationAssignmentDynamicScopeTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                var resourceGroup = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create maintenance configuration.
                var maintenanceConfigurationName1 = TestUtilities.GenerateName("maintenancesdk");
                var configurationAssignmentName1 = "dotsdktestassignment01";
                var maintenanceConfiguration1 = MaintenanceTestUtilities.CreateTestMaintenanceConfigurationInGuestPatchScope(maintenanceConfigurationName1, advancePatchOption: true);
 
                // Verify created maintenance configuration.
                var createdMaintenanceConfiguration1 = maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup.Name,maintenanceConfigurationName1, maintenanceConfiguration1);
  
                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration1, createdMaintenanceConfiguration1);

                var createdConfigurationAssignment1 = maintenanceClient.ConfigurationAssignmentsForSubscriptions.CreateOrUpdate(configurationAssignmentName1, new Microsoft.Azure.Management.Maintenance.Models.ConfigurationAssignment() {
                    Location = "global",
                    MaintenanceConfigurationId = createdMaintenanceConfiguration1.Id
                });

                var createdConfigurationAssignment2 = maintenanceClient.ConfigurationAssignmentsForSubscriptions.Get(configurationAssignmentName1);

                Assert.Equal(createdConfigurationAssignment2.Location, createdConfigurationAssignment1.Location);
                Assert.Equal(createdConfigurationAssignment2.MaintenanceConfigurationId, createdConfigurationAssignment1.MaintenanceConfigurationId);
                Assert.Equal(createdConfigurationAssignment2.Filter, createdConfigurationAssignment1.Filter);

                createdConfigurationAssignment1 = maintenanceClient.ConfigurationAssignmentsForSubscriptions.CreateOrUpdate(configurationAssignmentName1, new Microsoft.Azure.Management.Maintenance.Models.ConfigurationAssignment()
                {
                    Location = "global",
                    MaintenanceConfigurationId = createdMaintenanceConfiguration1.Id,
                    Filter = new Microsoft.Azure.Management.Maintenance.Models.ConfigurationAssignmentFilterProperties()
                    {
                        Locations = new List<string> { "eastus2euap", "centraluseuap"}
                    }
                });

                createdConfigurationAssignment2 = maintenanceClient.ConfigurationAssignmentsForSubscriptions.Get(configurationAssignmentName1);

                Assert.Equal(createdConfigurationAssignment2.Location, createdConfigurationAssignment1.Location);
                Assert.Equal(createdConfigurationAssignment2.MaintenanceConfigurationId, createdConfigurationAssignment1.MaintenanceConfigurationId);
                Assert.Equal(createdConfigurationAssignment2.Filter.Locations.Count, createdConfigurationAssignment1.Filter.Locations.Count);
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("eastus2euap"));
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("centraluseuap"));


                createdConfigurationAssignment1 = maintenanceClient.ConfigurationAssignmentsForSubscriptions.CreateOrUpdate(configurationAssignmentName1, new Microsoft.Azure.Management.Maintenance.Models.ConfigurationAssignment()
                {
                    Location = "global",
                    MaintenanceConfigurationId = createdMaintenanceConfiguration1.Id,
                    Filter = new Microsoft.Azure.Management.Maintenance.Models.ConfigurationAssignmentFilterProperties()
                    {
                        Locations = new List<string> { "eastus2euap", "centraluseuap" },
                        TagSettings = new Microsoft.Azure.Management.Maintenance.Models.TagSettingsProperties()
                        {
                            FilterOperator = Microsoft.Azure.Management.Maintenance.Models.TagOperators.Any,
                            Tags = new Dictionary<string, IList<string>> {
                                ["tagKey1"] = new List<string> { "tagKey1Value1", "tagKey1Value2" },
                                ["tagKey2"] = new List<string> { "tagKey2Value1", "tagKey2Value2", "tagKey2Value3" }
                            }
                        }
                    }
                });

                createdConfigurationAssignment2 = maintenanceClient.ConfigurationAssignmentsForSubscriptions.Get(configurationAssignmentName1);

                Assert.Equal(createdConfigurationAssignment2.Location, createdConfigurationAssignment1.Location);
                Assert.Equal(createdConfigurationAssignment2.MaintenanceConfigurationId, createdConfigurationAssignment1.MaintenanceConfigurationId);
                Assert.Equal(createdConfigurationAssignment2.Filter.Locations.Count, createdConfigurationAssignment1.Filter.Locations.Count);
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("eastus2euap"));
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("centraluseuap"));
                Assert.Equal(2, createdConfigurationAssignment2.Filter.TagSettings.Tags.Count);
                Assert.Equal(2, createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey1"].Count);
                Assert.Equal(3, createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Count);
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Contains("tagKey2Value1"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Contains("tagKey2Value2"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Contains("tagKey2Value3"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey1"].Contains("tagKey1Value1"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey1"].Contains("tagKey1Value2"));

                //Delete
                maintenanceClient.ConfigurationAssignmentsForSubscriptions.Delete(configurationAssignmentName1);
            }
        }

        /// <summary>
        /// Test create maintenance configuration.
        /// </summary>
        [Fact]
        public void MaintenanceConfigurationAssignmentResourceGroupDynamicScopeTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = MaintenanceTestUtilities.GetResourceManagementClient(context, handler);
                var maintenanceClient = MaintenanceTestUtilities.GetMaintenanceManagementClient(context, handler);

                var resourceGroup = MaintenanceTestUtilities.CreateResourceGroup(resourceClient);

                // Create maintenance configuration.
                var maintenanceConfigurationName1 = TestUtilities.GenerateName("maintenancesdk");
                var configurationAssignmentName1 = "dotnetsdktestassignment01";
                var configurationAssignmentResourceGroupName = "dotnetsdkeastus2euap";
                var maintenanceConfiguration1 = MaintenanceTestUtilities.CreateTestMaintenanceConfigurationInGuestPatchScope(maintenanceConfigurationName1, advancePatchOption: true);

                // Verify created maintenance configuration.
                var createdMaintenanceConfiguration1 = maintenanceClient.MaintenanceConfigurations.CreateOrUpdate(resourceGroup.Name, maintenanceConfigurationName1, maintenanceConfiguration1);

                MaintenanceTestUtilities.VerifyMaintenanceConfigurationProperties(maintenanceConfiguration1, createdMaintenanceConfiguration1);

                var createdConfigurationAssignment1 = maintenanceClient.ConfigurationAssignmentsForResourceGroup.CreateOrUpdate(configurationAssignmentResourceGroupName, configurationAssignmentName1, new ConfigurationAssignment()
                {
                    Location = resourceGroup.Location,
                    MaintenanceConfigurationId = createdMaintenanceConfiguration1.Id,
                    Filter = new ConfigurationAssignmentFilterProperties()
                    {
                        Locations = new List<string>() { "eastus2euap" }
                    }
                });

                var createdConfigurationAssignment2 = maintenanceClient.ConfigurationAssignmentsForResourceGroup.Get(configurationAssignmentResourceGroupName, configurationAssignmentName1);

                Assert.Equal(createdConfigurationAssignment2.Location, createdConfigurationAssignment1.Location);
                Assert.Equal(createdConfigurationAssignment2.MaintenanceConfigurationId, createdConfigurationAssignment1.MaintenanceConfigurationId);
                Assert.Equal(createdConfigurationAssignment2.Filter.Locations.Count, createdConfigurationAssignment1.Filter.Locations.Count);
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("eastus2euap"));

                createdConfigurationAssignment1 = maintenanceClient.ConfigurationAssignmentsForResourceGroup.CreateOrUpdate(configurationAssignmentResourceGroupName, configurationAssignmentName1, new ConfigurationAssignment()
                {
                    Location = resourceGroup.Location,
                    MaintenanceConfigurationId = createdMaintenanceConfiguration1.Id,
                    Filter = new ConfigurationAssignmentFilterProperties()
                    {
                        Locations = new List<string> { "eastus2euap", "centraluseuap" }
                    }
                });

                createdConfigurationAssignment2 = maintenanceClient.ConfigurationAssignmentsForResourceGroup.Get(configurationAssignmentResourceGroupName, configurationAssignmentName1);

                Assert.Equal(createdConfigurationAssignment2.Location, createdConfigurationAssignment1.Location);
                Assert.Equal(createdConfigurationAssignment2.MaintenanceConfigurationId, createdConfigurationAssignment1.MaintenanceConfigurationId);
                Assert.Equal(createdConfigurationAssignment2.Filter.Locations.Count, createdConfigurationAssignment1.Filter.Locations.Count);
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("eastus2euap"));
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("centraluseuap"));


                createdConfigurationAssignment1 = maintenanceClient.ConfigurationAssignmentsForResourceGroup.CreateOrUpdate(configurationAssignmentResourceGroupName, configurationAssignmentName1, new ConfigurationAssignment()
                {
                    Location = resourceGroup.Location,
                    MaintenanceConfigurationId = createdMaintenanceConfiguration1.Id,
                    Filter = new ConfigurationAssignmentFilterProperties()
                    {
                        Locations = new List<string> { "eastus2euap", "centraluseuap" },
                        TagSettings = new TagSettingsProperties()
                        {
                            FilterOperator = TagOperators.Any,
                            Tags = new Dictionary<string, IList<string>>
                            {
                                ["tagKey1"] = new List<string> { "tagKey1Value1", "tagKey1Value2" },
                                ["tagKey2"] = new List<string> { "tagKey2Value1", "tagKey2Value2", "tagKey2Value3" }
                            }
                        }
                    }
                });

                createdConfigurationAssignment2 = maintenanceClient.ConfigurationAssignmentsForResourceGroup.Get(configurationAssignmentResourceGroupName, configurationAssignmentName1);

                Assert.Equal(createdConfigurationAssignment2.Location, createdConfigurationAssignment1.Location);
                Assert.Equal(createdConfigurationAssignment2.MaintenanceConfigurationId, createdConfigurationAssignment1.MaintenanceConfigurationId);
                Assert.Equal(createdConfigurationAssignment2.Filter.Locations.Count, createdConfigurationAssignment1.Filter.Locations.Count);
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("eastus2euap"));
                Assert.True(createdConfigurationAssignment2.Filter.Locations.Contains("centraluseuap"));
                Assert.Equal(2, createdConfigurationAssignment2.Filter.TagSettings.Tags.Count);
                Assert.Equal(2, createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey1"].Count);
                Assert.Equal(3, createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Count);
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Contains("tagKey2Value1"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Contains("tagKey2Value2"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey2"].Contains("tagKey2Value3"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey1"].Contains("tagKey1Value1"));
                Assert.True(createdConfigurationAssignment2.Filter.TagSettings.Tags["tagKey1"].Contains("tagKey1Value2"));

                //Delete
                maintenanceClient.ConfigurationAssignmentsForResourceGroup.Delete(configurationAssignmentResourceGroupName, configurationAssignmentName1);
            }
        }
    }
}

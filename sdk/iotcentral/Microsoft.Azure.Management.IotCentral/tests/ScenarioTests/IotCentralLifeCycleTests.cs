// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace IotCentral.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IotCentral.Tests.Helpers;
    using Microsoft.Azure.Management.IotCentral;
    using Microsoft.Azure.Management.IotCentral.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;

    public class IotCentralLifeCycleTests : IotCentralTestBase
    {
        [Fact]
        public void TestIotCentralCreateLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
				// Note: Set IotCentralTestBase.isTestRecorderRun to true when building and running tests locally (before recording for PR).

                Initialize(context);

                // Create Resource Group
                Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup resourceGroup = CreateResourceGroup(this.ResourceGroupName);

                // Create App
                App app = CreateIotCentral(resourceGroup, IotCentralTestUtilities.DefaultLocation, ResourceName, SubDomain);

                // Validate resourceName and subdomain are taken
                this.CheckAppNameAndSubdomainTaken(app.Name, app.Subdomain);

                Assert.NotNull(app);
                Assert.Equal(DefaultIotcSku, app.Sku.Name);
                Assert.Contains(IotCentralTestUtilities.DefaultResourceName, app.Name);
                Assert.Contains(IotCentralTestUtilities.DefaultSubdomain, app.Subdomain);
                Assert.Equal("eastus", app.Location);
                Assert.Equal("created", app.State);
                Assert.Equal("Microsoft.IoTCentral/IoTApps", app.Type);
                Assert.Equal("None", app.Identity.Type);

                // Add and Get Tags
                IDictionary<string, string> tags = new Dictionary<string, string>
                 {
                     { "key1", "value1" },
                     { "key2", "value2" },
                 };

                var appPatch = new AppPatch()
                {
                    Tags = tags,
                    DisplayName = ResourceName,
                    Subdomain = SubDomain,
                };

                app = this.iotCentralClient.Apps.Update(ResourceGroupName, ResourceName, appPatch);

                Assert.NotNull(app);
                Assert.True(app.Tags.Count().Equals(2));
                Assert.Equal("value2", app.Tags["key2"]);

                // Get all Iot Central apps in a resource group
                var iotAppsByResourceGroup = this.iotCentralClient.Apps.ListByResourceGroup(ResourceGroupName.ToLowerInvariant()).ToList();

                // Get all Iot Apps in a subscription
                var iotAppsBySubscription = this.iotCentralClient.Apps.ListBySubscription().ToList();

                Assert.True(iotAppsByResourceGroup.Count > 0);
                Assert.True(iotAppsBySubscription.Count > 0);
            }
        }

        [Fact]
        public void TestIotCentralCreateWithManagedIdentityLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Initialize(context);

                // Create Resource Group
                Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup resourceGroup = CreateResourceGroup(ResourceGroupName);

                // Create App
                App app = CreateIotCentral(resourceGroup, IotCentralTestUtilities.DefaultLocation, ResourceName, SubDomain, DefaultMIType);

                // Validate resourceName and subdomain are taken
                this.CheckAppNameAndSubdomainTaken(app.Name, app.Subdomain);

                Assert.NotNull(app);
                Assert.Equal(AppSku.ST2, app.Sku.Name);
                Assert.Contains(IotCentralTestUtilities.DefaultResourceName, app.Name);
                Assert.Contains(IotCentralTestUtilities.DefaultSubdomain, app.Subdomain);
                Assert.Equal("eastus", app.Location);
                Assert.Equal("created", app.State);
                Assert.Equal("Microsoft.IoTCentral/IoTApps", app.Type);

                // validate managed identity.
                Assert.NotNull(app.Identity);
                Assert.Equal("SystemAssigned", app.Identity.Type);
                Assert.NotNull(app.Identity.PrincipalId);
                Assert.NotNull(app.Identity.TenantId);
                var principalId = app.Identity.PrincipalId;
                var tenantId = app.Identity.TenantId;

                // Add and Get Tags
                IDictionary<string, string> tags = new Dictionary<string, string>
                 {
                     { "key1", "value1" },
                     { "key2", "value2" },
                 };

                var appPatch = new AppPatch()
                {
                    Tags = tags,
                    DisplayName = ResourceName,
                    Subdomain = SubDomain,
                };

                app = this.iotCentralClient.Apps.Update(ResourceGroupName, ResourceName, appPatch);

                Assert.NotNull(app);
                Assert.True(app.Tags.Count().Equals(2));
                Assert.Equal("value2", app.Tags["key2"]);
                Assert.NotNull(app.Identity);
                Assert.Equal("SystemAssigned", app.Identity.Type);
                Assert.NotNull(app.Identity.PrincipalId);
                Assert.NotNull(app.Identity.TenantId);
                Assert.Equal(principalId, app.Identity.PrincipalId);
                Assert.Equal(tenantId, app.Identity.TenantId);

                // Get all Iot Central apps in a resource group
                var iotAppsByResourceGroup = this.iotCentralClient.Apps.ListByResourceGroup(ResourceGroupName.ToLowerInvariant()).ToList();

                // Get all Iot Apps in a subscription
                var iotAppsBySubscription = this.iotCentralClient.Apps.ListBySubscription().ToList();

                Assert.True(iotAppsByResourceGroup.Count > 0);
                Assert.True(iotAppsBySubscription.Count > 0);
            }
        }

        [Fact]
        public void TestIotCentralUpdateLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.Initialize(context);

                // Create Resource Group
                var resourceGroup = CreateResourceGroup(UpdateResourceGroupName);

                // Create App
                var app = CreateIotCentral(resourceGroup, IotCentralTestUtilities.DefaultLocation, UpdateResourceName, UpdateSubDomain);

                // Validate the default sku
                Assert.Equal(DefaultIotcSku, app.Sku.Name);

                // Validate resourceName and subdomain are taken
                this.CheckAppNameAndSubdomainTaken(app.Name, app.Subdomain);

                // Update App
                var newSubDomain = "test-updated-sub-domain";
                var newDisplayName = "test-updated-display-name";

                // Add and Get Tags
                IDictionary<string, string> tags = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                };

                AppPatch appPatch = new AppPatch()
                {
                    Tags = tags,
                    DisplayName = newDisplayName,
                    Subdomain = newSubDomain,
                    Sku = new AppSkuInfo(AppSku.ST2),
                };

                app = UpdateIotCentral(resourceGroup, appPatch, UpdateResourceName);

                // List apps
                app = iotCentralClient.Apps.ListByResourceGroup(UpdateResourceGroupName)
                    .FirstOrDefault(e => e.Name.Equals(UpdateResourceName, StringComparison.OrdinalIgnoreCase));

                Assert.NotNull(app);
                Assert.Equal(newDisplayName, app.DisplayName);
                Assert.True(app.Tags.Count().Equals(2));
                Assert.Equal("value2", app.Tags["key2"]);
                Assert.Equal(app.Sku.Name, AppSku.ST2);
            }
        }

        [Fact]
        public void TestAppWhenUnsupportedS1SkuIsUsed()
        {
            string sku = "S1";
            string exceptionMessage = "The sku S1 is invalid, allowed skus are ST0, ST1, ST2";
            var exceptionThrown = false;

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Initialize(context);

                // Create Resource Group
                Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup resourceGroup = CreateResourceGroup(ResourceGroupName);

                try
                {
                    // Create App
                    App app = CreateIotCentral(resourceGroup, IotCentralTestUtilities.DefaultLocation, ResourceName, SubDomain, DefaultMIType, sku);
                }
                catch (CloudException cex)
                {
                    exceptionThrown = true;
                    Assert.Equal(exceptionMessage, cex.Body.Message);
                }
            }

            Assert.True(exceptionThrown);
        }

        [Fact]
        public void TestAppWhenF1SkuIsUsed()
        {
            string sku = "F1";
            string exceptionMessage = "Cannot create a subscription less application with SKU F1";
            var exceptionThrown = false;

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Initialize(context);

                // Create Resource Group
                Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup resourceGroup = CreateResourceGroup(ResourceGroupName);

                try
                {
                    // Create App
                    App app = CreateIotCentral(resourceGroup, IotCentralTestUtilities.DefaultLocation, ResourceName, SubDomain, DefaultMIType, sku);
                }
                catch (CloudException cex)
                {
                    exceptionThrown = true;
                    Assert.Equal(exceptionMessage, cex.Body.Message);
                }
            }

            Assert.True(exceptionThrown);
        }

        [Fact]
        public void TestAppWhenNullAppSkuInfo()
        {
            var exceptionThrown = false;
            try
            {
                App app = new App()
                {
                    Location = IotCentralTestUtilities.DefaultLocation,
                    Sku = new AppSkuInfo(),
                    Subdomain = SubDomain,
                    DisplayName = IotCentralTestUtilities.DefaultUpdateResourceName,
                };
                app.Validate();
            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Assert.Equal(typeof(ValidationException), ex.GetType());
            }
            Assert.True(exceptionThrown);
        }

        [Fact]
        public void TestAppSkuInfoWhenNullInput()
        {
            var exceptionThrown = false;
            try
            {
                AppSkuInfo appSku = new AppSkuInfo();
                appSku.Validate();
            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Assert.Equal(typeof(ValidationException), ex.GetType());
            }
            Assert.True(exceptionThrown);
        }

        [Fact]
        public void TestOperationInputsWhenNullInput()
        {
            var exceptionThrown = false;
            try
            {
                OperationInputs operationInput = new OperationInputs();
                operationInput.Validate();
            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Assert.Equal(typeof(ValidationException), ex.GetType());
            }
            Assert.True(exceptionThrown);
        }

        [Fact]
        public void TestResourceWhenNullLocation()
        {
            var exceptionThrown = false;
            try
            {
                Resource resource = new Resource();
                resource.Validate();
            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Assert.Equal(typeof(ValidationException), ex.GetType());
            }
            Assert.True(exceptionThrown);
        }

        [Fact]
        public void TestAppTemplateNameField()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Initialize(context);
                
                var iotAppsTemplates = this.iotCentralClient.Apps.ListTemplates().ToList();
                
                Assert.True(iotAppsTemplates.Count > 0);
                Assert.NotNull(iotAppsTemplates[0].Name);
                Assert.Equal("Store Analytics – Condition Monitoring", iotAppsTemplates[0].Name);
                Assert.NotNull(iotAppsTemplates[0].Industry);
                Assert.Equal("Retail", iotAppsTemplates[0].Industry);
                Assert.True(iotAppsTemplates[0].Locations.Count > 0);
                Assert.NotNull(iotAppsTemplates[0].Locations[0].Id);
                Assert.NotNull(iotAppsTemplates[0].Locations[0].DisplayName);
                
                // Validate Geo->Regional change.
                IList<AppTemplateLocations> locations = iotAppsTemplates[0].Locations;
                Enumerable.SequenceEqual(locations, IotCentralTestUtilities.SupportedAzureRegions);
            }
        }

        [Fact]
        public void TestIotCentralOperationsApi()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Initialize(context);
                
                // Get all of the available IoT Apps REST API operations
                var operationList = this.iotCentralClient.Operations.List().ToList();

                Assert.True(operationList.Count > 0);

                // Get IoT Central Apps REST API read operation
                var readOperation = operationList.Where(e => e.Name.Equals("Microsoft.IoTCentral/IotApps/Read", StringComparison.OrdinalIgnoreCase)).ToList();
                // Get IoT Central Apps REST API read metricDefinitions operation
                var readMetricDefinitionsOperation = operationList.Where(e => e.Name.Equals("Microsoft.IoTCentral/IoTApps/providers/Microsoft.Insights/metricDefinitions/read", StringComparison.OrdinalIgnoreCase)).ToList();

                Assert.True(readOperation.Count.Equals(1));
                Assert.True(readMetricDefinitionsOperation.Count.Equals(1));
                Assert.NotNull(readMetricDefinitionsOperation[0].Origin);
                Assert.NotNull(readMetricDefinitionsOperation[0].Properties);
            }
        }

        private void CheckAppNameAndSubdomainTaken(string resourceName, string subdomain)
        {
            OperationInputs resourceNameInputs = new OperationInputs(resourceName, "IoTApps");
            OperationInputs subdomainInputs = new OperationInputs(subdomain, "IoTApps");

            // check if names are available
            var resourceNameResult = iotCentralClient.Apps.CheckNameAvailability(resourceNameInputs);
            var subdomainResult = iotCentralClient.Apps.CheckSubdomainAvailability(subdomainInputs);

            Assert.False(resourceNameResult.NameAvailable);
            Assert.False(subdomainResult.NameAvailable);
        }
    }
}


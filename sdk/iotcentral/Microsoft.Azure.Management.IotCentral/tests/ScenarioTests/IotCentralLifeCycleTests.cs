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
    using Newtonsoft.Json.Linq;
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
                Initialize(context);

                // Create Resource Group
                var resourceGroup = CreateResourceGroup(IotCentralTestUtilities.DefaultResourceGroupName);

                // Create App
                var app = CreateIotCentral(resourceGroup, IotCentralTestUtilities.DefaultLocation, IotCentralTestUtilities.DefaultResourceName, IotCentralTestUtilities.DefaultSubdomain);

                // Validate resourceName and subdomain are taken
                this.CheckAppNameAndSubdomainTaken(app.Name, app.Subdomain);

                Assert.NotNull(app);
                Assert.Equal(AppSku.ST1, app.Sku.Name);
                Assert.Equal(IotCentralTestUtilities.DefaultResourceName, app.Name);
                Assert.Equal(IotCentralTestUtilities.DefaultSubdomain, app.Subdomain);

                // Add and Get Tags
                IDictionary<string, string> tags = new Dictionary<string, string>
                 {
                     { "key1", "value1" },
                     { "key2", "value2" }
                 };

                var appPatch = new AppPatch()
                {
                    Tags = tags,
                    DisplayName = IotCentralTestUtilities.DefaultResourceName,
                    Subdomain = IotCentralTestUtilities.DefaultSubdomain
                };

                app = this.iotCentralClient.Apps.Update(IotCentralTestUtilities.DefaultResourceGroupName, IotCentralTestUtilities.DefaultResourceName, appPatch);

                Assert.NotNull(app);
                Assert.True(app.Tags.Count().Equals(2));
                Assert.Equal("value2", app.Tags["key2"]);

                // Get all Iot Central apps in a resource group
                var iotAppsByResourceGroup = this.iotCentralClient.Apps.ListByResourceGroup(IotCentralTestUtilities.DefaultResourceGroupName.ToLowerInvariant()).ToList();

                // Get all Iot Apps in a subscription
                var iotAppsBySubscription = this.iotCentralClient.Apps.ListBySubscription().ToList();

                // Get all of the available IoT Apps REST API operations
                var operationList = this.iotCentralClient.Operations.List().ToList();

                // Get IoT Central Apps REST API read operation
                var readOperation = operationList.Where(e => e.Name.Equals("Microsoft.IoTCentral/IotApps/Read", StringComparison.OrdinalIgnoreCase)).ToList();

                Assert.True(iotAppsByResourceGroup.Count > 0);
                Assert.True(iotAppsBySubscription.Count > 0);
                Assert.True(operationList.Count > 0);
                Assert.True(readOperation.Count.Equals(1));
            }
        }

        [Fact]
        public void TestIotCentralUpdateLifeCycle()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.Initialize(context);

                // Create Resource Group
                var resourceGroup = CreateResourceGroup(IotCentralTestUtilities.DefaultUpdateResourceGroupName);

                // Create App
                var app = CreateIotCentral(resourceGroup, IotCentralTestUtilities.DefaultLocation, IotCentralTestUtilities.DefaultUpdateResourceName, IotCentralTestUtilities.DefaultUpdateSubdomain);

                // Validate the default sku
                Assert.Equal(app.Sku.Name, AppSku.ST1);

                // Validate resourceName and subdomain are taken
                this.CheckAppNameAndSubdomainTaken(app.Name, app.Subdomain);

                // Update App
                var newSubDomain = "test-updated-sub-domain";
                var newDisplayName = "test-updated-display-name";
                // Add and Get Tags
                IDictionary<string, string> tags = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                };

                AppPatch appPatch = new AppPatch()
                {
                    Tags = tags,
                    DisplayName = newDisplayName,
                    Subdomain = newSubDomain,
                    Sku = new AppSkuInfo(AppSku.ST2),
                };

                app = UpdateIotCentral(resourceGroup, appPatch, IotCentralTestUtilities.DefaultUpdateResourceName);

                // List apps
                app = iotCentralClient.Apps.ListByResourceGroup(IotCentralTestUtilities.DefaultUpdateResourceGroupName)
                    .FirstOrDefault(e => e.Name.Equals(IotCentralTestUtilities.DefaultUpdateResourceName, StringComparison.OrdinalIgnoreCase));

                Assert.NotNull(app);
                Assert.Equal(newDisplayName, app.DisplayName);
                Assert.True(app.Tags.Count().Equals(2));
                Assert.Equal("value2", app.Tags["key2"]);
                Assert.Equal(app.Sku.Name, AppSku.ST2);
            }
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
                    Subdomain = IotCentralTestUtilities.DefaultUpdateSubdomain,
                    DisplayName = IotCentralTestUtilities.DefaultUpdateResourceName
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


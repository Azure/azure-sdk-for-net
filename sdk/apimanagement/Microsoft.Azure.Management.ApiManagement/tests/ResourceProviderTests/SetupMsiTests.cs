// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public void SetupMsiTests()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                string consumptionSkuRegion = "West US";

                // setup MSI on Consumption SKU
                testBase.serviceProperties.Location = consumptionSkuRegion;
                testBase.serviceProperties.Sku = new ApiManagementServiceSkuProperties(SkuType.Consumption);
                testBase.serviceProperties.Identity = new ApiManagementServiceIdentity();
                var createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);

                ValidateService(createdService,
                    testBase.serviceName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    consumptionSkuRegion,
                    testBase.serviceProperties.PublisherEmail,
                    testBase.serviceProperties.PublisherName,
                    testBase.serviceProperties.Sku.Name,
                    testBase.tags);

                Assert.NotNull(createdService.Identity);
                Assert.NotNull(createdService.Identity.PrincipalId);
                Assert.NotNull(createdService.Identity.TenantId);

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }
    }
}
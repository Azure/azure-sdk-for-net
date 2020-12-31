// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Collections.Generic;
using System.Linq;
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
        public void SetupSystemAssignedMsiTests()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                string consumptionSkuRegion = "West US";

                // setup MSI on Consumption SKU
                testBase.serviceProperties.Location = consumptionSkuRegion;
                testBase.serviceProperties.Sku = new ApiManagementServiceSkuProperties(SkuType.Consumption, capacity: 0);
                testBase.serviceProperties.Identity = new ApiManagementServiceIdentity("SystemAssigned");
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
                Assert.Equal("SystemAssigned", createdService.Identity.Type);
                Assert.NotNull(createdService.Identity.PrincipalId);
                Assert.NotNull(createdService.Identity.TenantId);

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<ErrorResponseException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }

        [Fact]
        [Trait("owner", "sasolank")]
        public void SetupUserAssignedMsiTests()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                string consumptionSkuRegion = "West US";

                // create user assigned identity
                var parameters = new Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity()
                {
                    Location = consumptionSkuRegion
                };
                var userAssignedResponse = testBase.managedIdentityClient.UserAssignedIdentities.CreateOrUpdateWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    parameters).GetAwaiter().GetResult();

                Assert.NotNull(userAssignedResponse);
                var userAssigned = userAssignedResponse.Body;
                Assert.NotNull(userAssigned.PrincipalId);
                Assert.NotNull(userAssigned.TenantId);

                // setup MSI on Consumption SKU
                testBase.serviceProperties.Location = consumptionSkuRegion;
                testBase.serviceProperties.Sku = new ApiManagementServiceSkuProperties(SkuType.Consumption, capacity: 0);
                testBase.serviceProperties.Identity = new ApiManagementServiceIdentity("UserAssigned")
                {
                    UserAssignedIdentities = new Dictionary<string, UserIdentityProperties>()
                    {
                        { userAssignedResponse.Body.Id, new UserIdentityProperties() }
                    }
                };
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
                Assert.NotNull(createdService.Identity.Type);
                Assert.Equal("UserAssigned", createdService.Identity.Type);
                Assert.NotNull(createdService.Identity.UserAssignedIdentities);
                Assert.Equal(1, createdService.Identity.UserAssignedIdentities.Count);
                Assert.Equal(userAssigned.PrincipalId.ToString(), createdService.Identity.UserAssignedIdentities.First().Value.PrincipalId);
                Assert.Equal(userAssigned.Id.ToString(), createdService.Identity.UserAssignedIdentities.First().Key);

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<ErrorResponseException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }
    }
}
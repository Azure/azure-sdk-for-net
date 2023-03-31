// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public void CreateMultiRegionService()
        {
                      Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);

                var additionalLocation = new AdditionalLocation()
                {
                    Location = testBase.GetAdditionLocation(testBase.location, "Europe"),
                    Sku = new ApiManagementServiceSkuProperties(SkuType.Premium, capacity: 1)
                };

                // only premium sku supports multi-region
                testBase.serviceProperties.Sku.Name = SkuType.Premium;
                testBase.serviceProperties.AdditionalLocations = new List<AdditionalLocation>()
                {
                    additionalLocation
                };

                var createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);

                ValidateService(createdService,
                    testBase.serviceName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.location,
                    testBase.serviceProperties.PublisherEmail,
                    testBase.serviceProperties.PublisherName,
                    testBase.serviceProperties.Sku.Name,
                    testBase.tags,
                    PlatformVersion.Stv2);

                Assert.NotNull(createdService.AdditionalLocations);
                Assert.Single(createdService.AdditionalLocations);
                Assert.Equal(additionalLocation.Location.ToLowerInvariant().Replace(" ", string.Empty),
                    createdService.AdditionalLocations.First().Location.ToLowerInvariant().Replace(" ", string.Empty));
                Assert.False(createdService.DisableGateway);
                Assert.False(createdService.AdditionalLocations.First().DisableGateway);

                // disable primary region
                testBase.serviceProperties.DisableGateway = true;
                createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);

                ValidateService(createdService,
                   testBase.serviceName,
                   testBase.rgName,
                   testBase.subscriptionId,
                   testBase.location,
                   testBase.serviceProperties.PublisherEmail,
                   testBase.serviceProperties.PublisherName,
                   testBase.serviceProperties.Sku.Name,
                   testBase.tags,
                   PlatformVersion.Stv2);

                // validate primary region is disabled
                Assert.True(createdService.DisableGateway);
                Assert.False(createdService.AdditionalLocations.First().DisableGateway);

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
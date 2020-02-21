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
using System.Linq;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "kjoshi")]
        public void CreateListDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);

                // check name availability api
                var parameters = new ApiManagementServiceCheckNameAvailabilityParameters()
                {
                    Name = testBase.serviceName
                };
                var checkNameResponse = testBase.client.ApiManagementService.CheckNameAvailability(parameters);
                Assert.NotNull(checkNameResponse);
                Assert.True(checkNameResponse.NameAvailable);                

                // create service
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
                    testBase.tags);
                                
                // list service
                var listServiceResponse = testBase.client.ApiManagementService.ListByResourceGroup(
                    resourceGroupName: testBase.rgName);

                Assert.NotNull(listServiceResponse);
                Assert.True(listServiceResponse.Any(), $"Service in rg {testBase.rgName} does not exist");

                var serviceResponse = listServiceResponse.FirstOrDefault();

                ValidateService(serviceResponse,
                   testBase.serviceName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.location,
                    testBase.serviceProperties.PublisherEmail,
                    testBase.serviceProperties.PublisherName,
                    testBase.serviceProperties.Sku.Name,
                    testBase.tags);

                // get sso token
                var ssoTokenResponse = testBase.client.ApiManagementService.GetSsoToken(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.NotNull(ssoTokenResponse);
                Assert.NotNull(ssoTokenResponse.RedirectUri);

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
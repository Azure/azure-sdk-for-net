// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class CacheTests : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list caches: there should be none
                var cacheListResponse = testBase.client.Cache.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(cacheListResponse);
                Assert.Empty(cacheListResponse);

                // create new cache
                string cacheid = testBase.serviceProperties.Location;

                try
                {
                    var cacheContract = new CacheContract()
                    {
                        ConnectionString = TestUtilities.GenerateName(),
                        Description = TestUtilities.GenerateName()
                    };

                    var createResponse = await testBase.client.Cache.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        cacheid,
                        cacheContract);

                    Assert.NotNull(createResponse);
                    Assert.Equal(cacheid, createResponse.Name);
                    Assert.Equal(cacheContract.Description, createResponse.Description);

                    // get the certificate to check is was created
                    var getResponse = await testBase.client.Cache.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        cacheid);

                    Assert.NotNull(getResponse);
                    Assert.Equal(cacheid, getResponse.Body.Name);

                    // list caches
                    cacheListResponse = testBase.client.Cache.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(cacheListResponse);
                    Assert.Single(cacheListResponse);

                    // remove the certificate
                    testBase.client.Cache.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        cacheid,
                        getResponse.Headers.ETag);

                    // list again to see it was removed
                    cacheListResponse = testBase.client.Cache.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(cacheListResponse);
                    Assert.Empty(cacheListResponse);
                }
                finally
                {
                    testBase.client.Cache.Delete(testBase.rgName, testBase.serviceName, cacheid, "*");
                    // clean up all properties
                    var listOfProperties = testBase.client.Property.ListByService(
                        testBase.rgName,
                        testBase.serviceName);
                    foreach (var property in listOfProperties)
                    {
                        testBase.client.Property.Delete(
                            testBase.rgName,
                            testBase.serviceName,
                            property.Name,
                            "*");
                    }
                }
            }
        }
    }
}

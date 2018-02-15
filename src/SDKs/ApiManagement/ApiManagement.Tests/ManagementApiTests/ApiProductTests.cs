// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiProductTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // there should be 'Echo API' which is created by default for every new instance of API Management

                var apis = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(apis);
                var api = apis.Single();
                Assert.Equal("Echo API", api.DisplayName);

                // list products

                var listResponse = testBase.client.ApiProduct.ListByApis(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name);

                Assert.NotNull(listResponse);
                Assert.Equal(2, listResponse.Count());
                Assert.NotNull(listResponse.NextPageLink);

                // list paged 
                listResponse = testBase.client.ApiProduct.ListByApis(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ProductContract> { Top = 1 });

                Assert.NotNull(listResponse);
                Assert.Single(listResponse);
                Assert.Equal("Starter", listResponse.First().DisplayName);
                Assert.NotEmpty(listResponse.NextPageLink);

                var listByApiResponse = await testBase.client.ApiProduct.ListByApisWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ProductContract> { Skip = 1 });

                Assert.NotNull(listByApiResponse);
                Assert.Single(listByApiResponse.Body);
                Assert.Equal("Unlimited", listByApiResponse.Body.First().DisplayName);
                Assert.NotNull(listByApiResponse.Body.NextPageLink);
            }
        }
    }
}

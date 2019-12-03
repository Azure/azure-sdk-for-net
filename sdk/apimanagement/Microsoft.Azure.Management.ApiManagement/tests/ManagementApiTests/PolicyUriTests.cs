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
using System.Net;
using System.Collections.Generic;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class PolicyUriTests : TestBase
    {
        protected const string ApiValid = "https://raw.githubusercontent.com/Azure/api-management-samples/master/sdkClientResources/ApiPolicy.xml";

        protected const string ProductValid = "https://raw.githubusercontent.com/Azure/api-management-samples/master/sdkClientResources/ProductPolicy.xml";

        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // test tenant policy
                var globalPolicy = testBase.client.Policy.Get(testBase.rgName, testBase.serviceName);
                Assert.NotNull(globalPolicy);

                // test api policy
                string newApiId = TestUtilities.GenerateName("policyapi");

                try
                {
                    var createdApiContract = testBase.client.Api.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        new ApiCreateOrUpdateParameter
                        {
                            DisplayName = TestUtilities.GenerateName("display"),
                            Description = TestUtilities.GenerateName("description"),
                            Path = TestUtilities.GenerateName("path"),
                            ServiceUrl = "https://echoapi.cloudapp.net/echo",
                            Protocols = new List<Protocol?> { Protocol.Https, Protocol.Http }
                        });

                    Assert.NotNull(createdApiContract);

                    var policyContract = new PolicyContract();
                    policyContract.Value = ApiValid;
                    policyContract.Format = PolicyContentFormat.XmlLink;

                    var apiPolicyContract = await testBase.client.ApiPolicy.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        policyContract);
                    Assert.NotNull(apiPolicyContract);
                    Assert.NotNull(apiPolicyContract.Value);

                    // get policy tag
                    var apiPolicyTag = await testBase.client.ApiPolicy.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.NotNull(apiPolicyTag);
                    Assert.NotNull(apiPolicyTag.ETag);

                    // delete policy
                    await testBase.client.ApiPolicy.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        apiPolicyTag.ETag);

                    Assert.Throws<ErrorResponseException>(() =>
                        testBase.client.ApiPolicy.Get(testBase.rgName, testBase.serviceName, newApiId));
                }
                finally
                {
                    await testBase.client.Api.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*",
                        deleteRevisions: true);
                }

                // test product policy

                // get 'Unlimited' product
                var getProductResponse = testBase.client.Product.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ProductContract>
                    {
                        Filter = "name eq 'Unlimited'"
                    });

                var product = getProductResponse.Single();

                // get product policy
                try
                {
                    testBase.client.ProductPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        product.Name);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // create product policy contract
                var productPolicyContract = new PolicyContract();
                productPolicyContract.Value = ProductValid;
                productPolicyContract.Format = PolicyContentFormat.XmlLink;

                var productPolicyResponse = testBase.client.ProductPolicy.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    productPolicyContract);

                Assert.NotNull(productPolicyResponse);
                Assert.NotNull(productPolicyResponse.Value);
                Assert.Equal("policy", productPolicyResponse.Name); // there can be only one policy per product

                // get policy to check it was added
                var getProductPolicy = await testBase.client.ProductPolicy.GetAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name);

                Assert.NotNull(getProductPolicy);
                Assert.NotNull(getProductPolicy.Format);

                // get product policy etag                
                var productPolicyTag = await testBase.client.ProductPolicy.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name);
                Assert.NotNull(productPolicyTag);
                Assert.NotNull(productPolicyTag.ETag);

                // remove policy
                testBase.client.ProductPolicy.Delete(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    productPolicyTag.ETag);

                // get policy to check it was removed
                try
                {
                    testBase.client.ProductPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        product.Name);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }
    }
}

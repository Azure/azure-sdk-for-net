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
    public class ProductTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var listResponse = testBase.client.Product.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.Equal(2, listResponse.Count());// there are 2 product Starter and Unlimited created by default
                Assert.NotNull(listResponse.NextPageLink);

                string productId = TestUtilities.GenerateName("newproduct");

                try
                {
                    string productName = TestUtilities.GenerateName("productName");
                    bool? productApprovalRequired = true;
                    string productDescription = TestUtilities.GenerateName("productDescription");
                    ProductState productState = ProductState.NotPublished;
                    bool? productSubscriptionRequired = true;
                    int? productSubscriptionsLimit = 10;
                    string productTerms = TestUtilities.GenerateName("productTerms");

                    var createParameters = new ProductContract(productName)
                    {
                        ApprovalRequired = productApprovalRequired,
                        Description = productDescription,
                        State = productState,
                        SubscriptionRequired = productSubscriptionRequired,
                        SubscriptionsLimit = productSubscriptionsLimit,
                        Terms = productTerms
                    };

                    var createResponse = testBase.client.Product.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        productId,
                        createParameters);

                    Assert.NotNull(createResponse);
                    Assert.Equal(productName, createResponse.DisplayName);
                    Assert.Equal(productApprovalRequired, createResponse.ApprovalRequired);
                    Assert.Equal(productDescription, createResponse.Description);
                    Assert.Equal(productState, createResponse.State);
                    Assert.Equal(productSubscriptionRequired, createResponse.SubscriptionRequired);
                    Assert.Equal(productSubscriptionsLimit, createResponse.SubscriptionsLimit);
                    Assert.Equal(productTerms, createResponse.Terms);

                    //get async
                    var getResponse = await testBase.client.Product.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        productId);
                    Assert.NotNull(getResponse);

                    // update product
                    string patchedName = TestUtilities.GenerateName("productName");
                    string patchedDescription = TestUtilities.GenerateName("productDescription");
                    string patchedTerms = TestUtilities.GenerateName("productTerms");
                    var updateParameters = new ProductUpdateParameters
                    {
                        Name = patchedName,
                        Description = patchedDescription,
                        Terms = patchedTerms
                    };
                    testBase.client.Product.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        productId,
                        updateParameters,
                        getResponse.Headers.ETag);

                    // get to check it was updated
                    var getUpdatedResponse = testBase.client.Product.Get(testBase.rgName, testBase.serviceName, productId);

                    Assert.NotNull(getUpdatedResponse);

                    Assert.Equal(patchedName, getUpdatedResponse.DisplayName);
                    Assert.Equal(productApprovalRequired, getUpdatedResponse.ApprovalRequired);
                    Assert.Equal(patchedDescription, getUpdatedResponse.Description);
                    Assert.Equal(productState, getUpdatedResponse.State);
                    Assert.Equal(productSubscriptionRequired, getUpdatedResponse.SubscriptionRequired);
                    Assert.Equal(productSubscriptionsLimit, getUpdatedResponse.SubscriptionsLimit);
                    Assert.Equal(patchedTerms, getUpdatedResponse.Terms);

                    // delete the product 
                    testBase.client.Product.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        productId,
                        "*",
                        true);

                    // get the deleted api to make sure it was deleted
                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Product.Get(testBase.rgName, testBase.serviceName, productId));
                }
                finally
                {
                    testBase.client.Product.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        productId,
                        "*",
                        true);
                }
            }
        }

        [Fact]
        public void ApisListAddRemove()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // there should be 'Echo API' which is created by default for every new instance of API Management and
                // 'Starter' product

                var getProductsResponse = testBase.client.Product.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ProductContract>
                    {
                        Filter = "name eq 'Starter'"
                    });

                Assert.NotNull(getProductsResponse);                
                Assert.Equal(1, getProductsResponse.Count());

                var product = getProductsResponse.Single();

                // list product apis: there sHould be 1
                var listApisResponse = testBase.client.ProductApi.ListByProduct(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    null);

                Assert.NotNull(listApisResponse);                
                Assert.Equal(1, listApisResponse.Count());

                // get api
                var getResponse = testBase.client.Api.Get(
                    testBase.rgName,
                    testBase.serviceName,
                    listApisResponse.Single().Name);

                Assert.NotNull(getResponse);

                // remove api from product
                testBase.client.ProductApi.Delete(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    listApisResponse.Single().Name);
                
                // list to check it was removed
                listApisResponse = testBase.client.ProductApi.ListByProduct(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    null);

                Assert.NotNull(listApisResponse);                
                Assert.Equal(0, listApisResponse.Count());

                // add the api to product
                var addResponse = testBase.client.ProductApi.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    getResponse.Name);

                Assert.NotNull(addResponse);

                // list to check it was added
                listApisResponse = testBase.client.ProductApi.ListByProduct(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    null);

                Assert.NotNull(listApisResponse);                
                Assert.Equal(1, listApisResponse.Count());
            }
        }

        [Fact]
        public void GroupsListAddRemove()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // there should be 'Administrators', 'Developers' and 'Guests' groups which is created by default for every new instance of API Management and
                // 'Starter' product

                var getProductsResponse = testBase.client.Product.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ProductContract>
                    {
                        Filter = "name eq 'Starter'"
                    });

                Assert.NotNull(getProductsResponse);                
                Assert.Equal(1, getProductsResponse.Count());

                var product = getProductsResponse.Single();

                // list product groups: there sould be all three
                var listGroupsResponse = testBase.client.ProductGroup.ListByProduct(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    null);

                Assert.NotNull(listGroupsResponse);
                Assert.Equal(3, listGroupsResponse.Count());

                // get group
                var getResponse = testBase.client.Group.Get(
                    testBase.rgName,
                    testBase.serviceName,
                    listGroupsResponse.Single(g => g.DisplayName.Equals("Guests")).Name);

                Assert.NotNull(getResponse);

                // remove group from product
                testBase.client.ProductGroup.Delete(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    getResponse.Name);
                
                // list to check it was removed
                listGroupsResponse = testBase.client.ProductGroup.ListByProduct(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    null);

                Assert.NotNull(listGroupsResponse);                
                Assert.Equal(2, listGroupsResponse.Count());

                // assign the group to the product

                var addResponse = testBase.client.ProductGroup.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    getResponse.Name);

                Assert.NotNull(addResponse);

                // list to check it was added
                listGroupsResponse = testBase.client.ProductGroup.ListByProduct(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    null);

                Assert.NotNull(listGroupsResponse);                
                Assert.Equal(3, listGroupsResponse.Count());
            }
        }

        [Fact]
        public void SubscriptionsList()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // get product
                var listProductsResponse = testBase.client.Product.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ProductContract>
                    {
                        Filter = "name eq 'Starter'"
                    });

                var product = listProductsResponse.Single();

                // list product's subscriptions
                var listSubscriptionsResponse = testBase.client.ProductSubscriptions.List(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    null);

                Assert.NotNull(listSubscriptionsResponse);                
                Assert.Equal(1, listSubscriptionsResponse.Count());
            }
        }
    }
}

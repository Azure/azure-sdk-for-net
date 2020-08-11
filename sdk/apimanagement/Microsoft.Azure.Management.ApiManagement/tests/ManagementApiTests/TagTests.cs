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
using ApiManagementManagement.Tests.Helpers;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class TagTest : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDeleteApiTags()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var tagsResources = await testBase.client.Tag.ListByServiceAsync(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.Empty(tagsResources);

                // list all the APIs
                var listResponse = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.Single(listResponse);
                Assert.Null(listResponse.NextPageLink);

                var echoApi = listResponse.First();

                string tagId = TestUtilities.GenerateName("apiTag");
                try
                {
                    string tagDisplayName = TestUtilities.GenerateName("apiTag");
                    var createParameters = new TagCreateUpdateParameters();
                    createParameters.DisplayName = tagDisplayName;

                    // create a tag
                    var tagContract = testBase.client.Tag.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId,
                        createParameters);

                    Assert.NotNull(tagContract);
                    Assert.Equal(tagDisplayName, tagContract.DisplayName);

                    // associate the tag with the API
                    tagContract = await testBase.client.Tag.AssignToApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);
                    Assert.NotNull(tagContract);

                    // get APIs with Tags 
                    var apisWithTags = await testBase.client.Api.ListByTagsAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        new Microsoft.Rest.Azure.OData.ODataQuery<TagResourceContract>
                        {
                            Top = 1
                        });
                    Assert.NotNull(apisWithTags);
                    Assert.Single(apisWithTags);
                    Assert.Equal(tagContract.DisplayName, apisWithTags.GetEnumerator().ToIEnumerable().First().Tag.Name);

                    // Tag list by API
                    var tagsInApi = await testBase.client.Tag.ListByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name);
                    Assert.NotNull(tagsInApi);
                    Assert.Single(tagsInApi);
                    Assert.Equal(tagDisplayName, tagsInApi.GetEnumerator().ToIEnumerable().First().DisplayName);

                    // get the tag on the api
                    var tagOnApi = await testBase.client.Tag.GetByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);
                    Assert.NotNull(tagOnApi);
                    Assert.Equal(tagDisplayName, tagOnApi.DisplayName);

                    // get the tag Etag
                    var tagEtagByApi = await testBase.client.Tag.GetEntityStateByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);
                    Assert.NotNull(tagEtagByApi);
                    Assert.NotNull(tagEtagByApi.ETag);

                    // get the tag resources for the service.
                    var tagResources = await testBase.client.TagResource.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName);
                    Assert.NotNull(tagResources);
                    Assert.Single(tagResources);
                    Assert.Equal(tagDisplayName, tagResources.GetEnumerator().ToIEnumerable().First().Tag.Name);
                    Assert.NotNull(tagResources.GetEnumerator().ToIEnumerable().First().Api);
                    Assert.Equal(echoApi.DisplayName, tagResources.GetEnumerator().ToIEnumerable().First().Api.Name);

                    // detach the tag
                    await testBase.client.Tag.DetachFromApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Tag.GetByApi(
                            testBase.rgName,
                            testBase.serviceName,
                            echoApi.Name,
                            tagId));

                    var tagEtag = await testBase.client.Tag.GetEntityStateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId);
                    Assert.NotNull(tagEtag);
                    Assert.NotNull(tagEtag.ETag);

                    //delete the tag
                    await testBase.client.Tag.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId,
                        tagEtag.ETag);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Tag.GetEntityState(
                            testBase.rgName,
                            testBase.serviceName,
                            tagId));
                }
                finally
                {
                    testBase.client.Tag.DetachFromApi(
                        testBase.rgName, testBase.serviceName, echoApi.Name, tagId);
                    testBase.client.Tag.Delete(
                        testBase.rgName, testBase.serviceName, tagId, "*");
                }
            }
        }

        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDeleteProductTags()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var tagsResources = await testBase.client.Tag.ListByServiceAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.Empty(tagsResources);

                // list all the Product
                var listResponse = testBase.client.Product.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);
                Assert.NotNull(listResponse);
                Assert.Equal(2, listResponse.GetEnumerator().ToIEnumerable().Count());
                Assert.Null(listResponse.NextPageLink);

                var starterProduct = listResponse.First();

                string tagId = TestUtilities.GenerateName("productTag");
                try
                {
                    string tagDisplayName = TestUtilities.GenerateName("productTag");
                    var createParameters = new TagCreateUpdateParameters();
                    createParameters.DisplayName = tagDisplayName;

                    // create a tag
                    var tagContract = testBase.client.Tag.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId,
                        createParameters);

                    Assert.NotNull(tagContract);
                    Assert.Equal(tagDisplayName, tagContract.DisplayName);

                    // associate the tag with the API
                    tagContract = await testBase.client.Tag.AssignToProductAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        starterProduct.Name,
                        tagId);
                    Assert.NotNull(tagContract);

                    // Tag list by Prod
                    var tagsInProduct = await testBase.client.Tag.ListByProductAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        starterProduct.Name);
                    Assert.NotNull(tagsInProduct);
                    Assert.Single(tagsInProduct);
                    Assert.Equal(tagDisplayName, tagsInProduct.GetEnumerator().ToIEnumerable().First().DisplayName);

                    // get the tag on the api
                    var tagOnProduct = await testBase.client.Tag.GetByProductAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        starterProduct.Name,
                        tagId);
                    Assert.NotNull(tagOnProduct);
                    Assert.Equal(tagDisplayName, tagOnProduct.DisplayName);

                    // get the tag resources for the service.
                    var tagResources = await testBase.client.TagResource.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName);
                    Assert.NotNull(tagResources);
                    Assert.Single(tagResources);
                    Assert.Equal(tagDisplayName, tagResources.First().Tag.Name);
                    Assert.Null(tagResources.First().Api);
                    Assert.Null(tagResources.First().Operation);
                    Assert.NotNull(tagResources.First().Product);
                    Assert.Equal(starterProduct.DisplayName, tagResources.First().Product.Name);

                    // get the tag Etag
                    var tagEtagByProduct = await testBase.client.Tag.GetEntityStateByProductAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        starterProduct.Name,
                        tagId);
                    Assert.NotNull(tagEtagByProduct);
                    Assert.NotNull(tagEtagByProduct.ETag);

                    // detach the tag
                    await testBase.client.Tag.DetachFromProductAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        starterProduct.Name,
                        tagId);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Tag.GetByProduct(
                            testBase.rgName,
                            testBase.serviceName,
                            starterProduct.Name,
                            tagId));

                    var tagEtag = await testBase.client.Tag.GetEntityStateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId);
                    Assert.NotNull(tagEtag);
                    Assert.NotNull(tagEtag.ETag);

                    //delete the tag
                    await testBase.client.Tag.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId,
                        tagEtag.ETag);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Tag.GetEntityState(
                            testBase.rgName,
                            testBase.serviceName,
                            tagId));
                }
                finally
                {
                    testBase.client.Tag.DetachFromProduct(
                        testBase.rgName, testBase.serviceName, starterProduct.Name, tagId);
                    testBase.client.Tag.Delete(
                        testBase.rgName, testBase.serviceName, tagId, "*");
                }
            }
        }

        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDeleteOperationTags()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var tagsResources = await testBase.client.Tag.ListByServiceAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.Empty(tagsResources);

                // there should be 'Echo API' which is created by default for every new instance of API Management
                var apis = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.Single(apis);
                var api = apis.Single();

                // list paged 
                var listResponse = testBase.client.ApiOperation.ListByApi(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    new Microsoft.Rest.Azure.OData.ODataQuery<OperationContract> { Top = 1 });

                var firstOperation = listResponse.First();

                string tagId = TestUtilities.GenerateName("operationTag");
                try
                {
                    string tagDisplayName = TestUtilities.GenerateName("opreationTag");
                    var createParameters = new TagCreateUpdateParameters();
                    createParameters.DisplayName = tagDisplayName;

                    // create a tag
                    var tagContract = testBase.client.Tag.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId,
                        createParameters);

                    Assert.NotNull(tagContract);
                    Assert.Equal(tagDisplayName, tagContract.DisplayName);

                    // associate the tag with the API Operation
                    tagContract = await testBase.client.Tag.AssignToOperationAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        firstOperation.Name,
                        tagId);
                    Assert.NotNull(tagContract);

                    // Tag list by Api Operation
                    var tagsInOperation = await testBase.client.Tag.ListByOperationAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        firstOperation.Name);
                    Assert.NotNull(tagsInOperation);
                    Assert.Single(tagsInOperation);
                    Assert.Equal(tagDisplayName, tagsInOperation.First().DisplayName);

                    // get the tag on the api operation
                    var tagOnOperation = await testBase.client.Tag.GetByOperationAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        firstOperation.Name,
                        tagId);
                    Assert.NotNull(tagOnOperation);
                    Assert.Equal(tagDisplayName, tagOnOperation.DisplayName);

                    // get the tag resources for the service.
                    var tagResources = await testBase.client.TagResource.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName);
                    Assert.NotNull(tagResources);
                    Assert.Single(tagResources);
                    Assert.Equal(tagDisplayName, tagResources.First().Tag.Name);
                    Assert.Null(tagResources.First().Api);
                    Assert.NotNull(tagResources.First().Operation);
                    Assert.Null(tagResources.First().Product);
                    Assert.Equal(firstOperation.DisplayName, tagResources.GetEnumerator().ToIEnumerable().First().Operation.Name, true);
                    Assert.Equal(firstOperation.Method, tagResources.GetEnumerator().ToIEnumerable().First().Operation.Method);

                    // get the tag Etag
                    var tagEtagByOperation = await testBase.client.Tag.GetEntityStateByOperationAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        firstOperation.Name,
                        tagId);
                    Assert.NotNull(tagEtagByOperation);
                    Assert.NotNull(tagEtagByOperation.ETag);

                    // detach the tag
                    await testBase.client.Tag.DetachFromOperationAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        firstOperation.Name,
                        tagId);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Tag.GetByOperation(
                            testBase.rgName,
                            testBase.serviceName,
                            api.Name,
                            firstOperation.Name,
                            tagId));

                    var tagEtag = await testBase.client.Tag.GetEntityStateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId);
                    Assert.NotNull(tagEtag);
                    Assert.NotNull(tagEtag.ETag);

                    //delete the tag
                    await testBase.client.Tag.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId,
                        tagEtag.ETag);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Tag.GetEntityState(
                            testBase.rgName,
                            testBase.serviceName,
                            tagId));
                }
                finally
                {
                    testBase.client.Tag.DetachFromOperation(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        firstOperation.Name,
                        tagId);

                    testBase.client.Tag.Delete(
                        testBase.rgName, testBase.serviceName, tagId, "*");
                }
            }
        }
    }
}

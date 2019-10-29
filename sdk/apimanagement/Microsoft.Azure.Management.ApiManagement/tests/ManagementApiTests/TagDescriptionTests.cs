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
    public class TagDescriptionTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

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

                    // list tag description
                    var tagDescriptionList = await testBase.client.ApiTagDescription.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name);

                    Assert.NotNull(tagDescriptionList);
                    Assert.Empty(tagDescriptionList);

                    // create a tag description
                    var tagDescriptionCreateParams = new TagDescriptionCreateParameters()
                    {
                        Description = TestUtilities.GenerateName("somedescription"),
                        ExternalDocsUrl = "http://somelog.content"
                    };
                    var tagDescriptionContract = await testBase.client.ApiTagDescription.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId,
                        tagDescriptionCreateParams);
                    Assert.NotNull(tagDescriptionContract);
                    Assert.Equal(tagDisplayName, tagDescriptionContract.DisplayName);
                    Assert.Equal(tagDescriptionCreateParams.Description, tagDescriptionContract.Description);

                    // get the tagdescription etag
                    var tagDescriptionTag = await testBase.client.ApiTagDescription.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);
                    Assert.NotNull(tagDescriptionTag);
                    Assert.NotNull(tagDescriptionTag.ETag);

                    // update the tag description
                    tagDescriptionCreateParams.Description = TestUtilities.GenerateName("tag_update");
                    tagDescriptionContract = await testBase.client.ApiTagDescription.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId,
                        tagDescriptionCreateParams,
                        tagDescriptionTag.ETag);
                    Assert.NotNull(tagDescriptionContract);
                    Assert.Equal(tagDisplayName, tagDescriptionContract.DisplayName);
                    Assert.Equal(tagDescriptionCreateParams.Description, tagDescriptionContract.Description);

                    // get the entity
                    tagDescriptionTag = await testBase.client.ApiTagDescription.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);
                    Assert.NotNull(tagDescriptionTag);
                    Assert.NotNull(tagDescriptionTag.ETag);

                    // delete the tag description
                    await testBase.client.ApiTagDescription.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId,
                        tagDescriptionTag.ETag);

                    // get the entity tag
                    var tagTag = await testBase.client.Tag.GetEntityStateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId);
                    Assert.NotNull(tagTag);
                    Assert.NotNull(tagTag.ETag);

                    // detach from Api
                    await testBase.client.Tag.DetachFromApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);

                    // get the entity tag
                    tagTag = await testBase.client.Tag.GetEntityStateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId);
                    Assert.NotNull(tagTag);
                    Assert.NotNull(tagTag.ETag);

                    // delete the tag
                    await testBase.client.Tag.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        tagId,
                        tagTag.ETag);

                    // delete the tag description
                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Tag.Get(
                            testBase.rgName,
                            testBase.serviceName,
                            tagId));                    
                }
                finally
                {
                    // detach from api
                    testBase.client.Tag.DetachFromApi(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId);

                    // delete the tag description
                    testBase.client.ApiTagDescription.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        tagId,
                        "*");

                    // delete the tag
                    testBase.client.Tag.Delete(
                        testBase.rgName, 
                        testBase.serviceName,
                        tagId, 
                        "*");
                }
            }
        }
    }
}

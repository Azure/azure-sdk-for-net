// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiManagementManagement.Tests.Helpers;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiRevisionTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // add new api
                const string swaggerPath = "./Resources/SwaggerPetStoreV2.json";
                const string path = "swaggerApi";

                string newApiId = TestUtilities.GenerateName("apiid");
                string newReleaseId = TestUtilities.GenerateName("apireleaseid");

                try
                {                    
                    // import API
                    string swaggerApiContent;
                    using (StreamReader reader = File.OpenText(swaggerPath))
                    {
                        swaggerApiContent = reader.ReadToEnd();
                    }

                    var apiCreateOrUpdate = new ApiCreateOrUpdateParameter()
                    {
                        Path = path,
                        ContentFormat = ContentFormat.SwaggerJson,
                        ContentValue = swaggerApiContent
                    };

                    var swaggerApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            newApiId,
                            apiCreateOrUpdate);

                    Assert.NotNull(swaggerApiResponse);

                    // get new api to check it was added
                    var petstoreApiContract = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newApiId);

                    Assert.NotNull(petstoreApiContract);
                    Assert.Equal(path, petstoreApiContract.Path);
                    Assert.Equal("Swagger Petstore Extensive", petstoreApiContract.DisplayName);
                    Assert.Equal("http://petstore.swagger.wordnik.com/api", petstoreApiContract.ServiceUrl);

                    // test the number of operations it has
                    var petstoreApiOperations = testBase.client.ApiOperation.ListByApi(
                        testBase.rgName,
                        testBase.serviceName, 
                        newApiId);
                    Assert.NotNull(petstoreApiOperations);
                    Assert.NotEmpty(petstoreApiOperations);

                    // get the API Entity Tag
                    ApiGetEntityTagHeaders apiTag = testBase.client.Api.GetEntityTag(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);

                    Assert.NotNull(apiTag);
                    Assert.NotNull(apiTag.ETag);

                    // add an api revision
                    string revisionNumber = "2";

                    // create a revision of Petstore
                    var revisionDescription = "Petstore second revision";
                    var petstoreRevisionContract = new ApiCreateOrUpdateParameter()
                    {
                        Path = petstoreApiContract.Path + revisionNumber,
                        DisplayName = petstoreApiContract.DisplayName + revisionNumber,
                        ServiceUrl = petstoreApiContract.ServiceUrl + revisionNumber,
                        Protocols = petstoreApiContract.Protocols,
                        SubscriptionKeyParameterNames = petstoreApiContract.SubscriptionKeyParameterNames,
                        AuthenticationSettings = petstoreApiContract.AuthenticationSettings,
                        Description = petstoreApiContract.Description,
                        ApiRevisionDescription = revisionDescription
                    };

                    var petStoreSecondRevision = await testBase.client.Api.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId.ApiRevisionIdentifier(revisionNumber),
                        petstoreRevisionContract);
                    Assert.NotNull(petStoreSecondRevision);
                    Assert.Equal(petstoreRevisionContract.Path, petStoreSecondRevision.Path);
                    Assert.Equal(petstoreRevisionContract.ServiceUrl, petStoreSecondRevision.ServiceUrl);
                    Assert.Equal(revisionNumber, petStoreSecondRevision.ApiRevision);
                    Assert.Equal(revisionDescription, petStoreSecondRevision.ApiRevisionDescription);

                    // add couple of operation to this revision
                    var newOperationId = TestUtilities.GenerateName("firstOpRev");
                    var firstOperationContract = testBase.CreateOperationContract("POST");
                    var firstOperation = await testBase.client.ApiOperation.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId.ApiRevisionIdentifier(revisionNumber),
                        newOperationId,
                        firstOperationContract);
                    Assert.NotNull(firstOperation);
                    Assert.Equal("POST", firstOperation.Method);

                    var secondOperationId = TestUtilities.GenerateName("secondOpName");
                    var secondOperationContract = testBase.CreateOperationContract("GET");
                    var secondOperation = await testBase.client.ApiOperation.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId.ApiRevisionIdentifier(revisionNumber),
                        secondOperationId,
                        secondOperationContract);
                    Assert.NotNull(secondOperation);
                    Assert.Equal("GET", secondOperation.Method);

                    // now test out list operation on the revision api
                    var firstOperationOfSecondRevision = await testBase.client.ApiOperation.ListByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId.ApiRevisionIdentifier(revisionNumber),
                        new Microsoft.Rest.Azure.OData.ODataQuery<OperationContract>
                        {
                            Top = 1
                        });
                    Assert.NotNull(firstOperationOfSecondRevision);
                    Assert.Single(firstOperationOfSecondRevision);
                    Assert.NotEmpty(firstOperationOfSecondRevision.NextPageLink);

                    // now test whether the next page link works
                    var secondOperationOfSecondRevision = await testBase.client.ApiOperation.ListByApiNextAsync(
                        firstOperationOfSecondRevision.NextPageLink);
                    Assert.NotNull(secondOperationOfSecondRevision);
                    Assert.Single(secondOperationOfSecondRevision);
                    Assert.Empty(secondOperationOfSecondRevision.NextPageLink);

                    // list apiRevision
                    IPage<ApiRevisionContract> apiRevisions = await testBase.client.ApiRevisions.ListAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.NotNull(apiRevisions);
                    Assert.Equal(2, apiRevisions.GetEnumerator().ToIEnumerable<ApiRevisionContract>().Count());
                    Assert.NotEmpty(apiRevisions.GetEnumerator().ToIEnumerable().Single(d => d.ApiRevision.Equals(revisionNumber)).ApiRevision);
                    Assert.Single(apiRevisions.GetEnumerator().ToIEnumerable().Where(a => a.IsCurrent.HasValue && a.IsCurrent.Value)); // there is only one revision which is current

                    // get the etag of the revision
                    var apiSecondRevisionTag = await testBase.client.Api.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId.ApiRevisionIdentifier(revisionNumber));

                    var apiOnlineRevisionTag = await testBase.client.Api.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);

                    Assert.NotNull(apiSecondRevisionTag);
                    Assert.NotNull(apiOnlineRevisionTag);
                    Assert.NotEqual(apiOnlineRevisionTag.ETag, apiSecondRevisionTag.ETag);

                    //there should be no release intially
                    var apiReleases = await testBase.client.ApiRelease.ListAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.Empty(apiReleases);

                    // lets create a release now
                    var apiReleaseContract = new ApiReleaseContract()
                    {
                        ApiId = newApiId.ApiRevisionIdentifierFullPath(revisionNumber),
                        Notes = TestUtilities.GenerateName("revision_description")
                    };
                    var newapiBackendRelease = await testBase.client.ApiRelease.CreateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newReleaseId,
                        apiReleaseContract);
                    Assert.NotNull(newapiBackendRelease);
                    Assert.Equal(newReleaseId, newapiBackendRelease.Name);
                    Assert.Equal(apiReleaseContract.Notes, newapiBackendRelease.Notes);

                    // get the release eta
                    var releaseTag = await testBase.client.ApiRelease.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newReleaseId);
                    Assert.NotNull(releaseTag);

                    // update the release details
                    apiReleaseContract.Notes = TestUtilities.GenerateName("update_desc");
                    await testBase.client.ApiRelease.UpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newReleaseId,
                        apiReleaseContract,
                        releaseTag.ETag);

                    // get the release detaild
                    newapiBackendRelease = await testBase.client.ApiRelease.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newReleaseId);
                    Assert.NotNull(newapiBackendRelease);
                    Assert.Equal(newapiBackendRelease.Notes, apiReleaseContract.Notes);

                    // list the revision
                    apiReleases = await testBase.client.ApiRelease.ListAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.NotNull(apiReleases);
                    Assert.Single(apiReleases);

                    // find the revision which is not online

                    // delete the api
                    await testBase.client.Api.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*",
                        deleteRevisions: true);

                    // get the deleted api to make sure it was deleted
                    try
                    {
                        testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newApiId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // delete authorization server
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*",
                        deleteRevisions: true);
                }
            }
        }
    }
}

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
using System.Collections.Generic;
using System;
using System.Net;
using Microsoft.Rest.Azure;
using ApiManagementManagement.Tests.Helpers;

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

                // create autorization server
                string newApiAuthorizationServerId = TestUtilities.GenerateName("authorizationServerId");
                string newApiId = TestUtilities.GenerateName("apiid");
                string newReleaseId = TestUtilities.GenerateName("apireleaseid");

                try
                {
                    var createAuthServerParams = new AuthorizationServerContract
                    {
                        DisplayName = TestUtilities.GenerateName("authName"),
                        DefaultScope = TestUtilities.GenerateName("oauth2scope"),
                        AuthorizationEndpoint = "https://contoso.com/auth",
                        TokenEndpoint = "https://contoso.com/token",
                        ClientRegistrationEndpoint = "https://contoso.com/clients/reg",
                        GrantTypes = new List<string> { GrantType.AuthorizationCode, GrantType.Implicit },
                        AuthorizationMethods = new List<AuthorizationMethod?> { AuthorizationMethod.POST, AuthorizationMethod.GET },
                        BearerTokenSendingMethods = new List<string> { BearerTokenSendingMethod.AuthorizationHeader, BearerTokenSendingMethod.Query },
                        ClientId = TestUtilities.GenerateName("clientid")
                    };

                    testBase.client.AuthorizationServer.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiAuthorizationServerId,
                        createAuthServerParams);

                    string newApiName = TestUtilities.GenerateName("apiname");
                    string newApiDescription = TestUtilities.GenerateName("apidescription");
                    string newApiPath = "newapiPath";
                    string newApiServiceUrl = "http://newechoapi.cloudapp.net/api";
                    string subscriptionKeyParametersHeader = TestUtilities.GenerateName("header");
                    string subscriptionKeyQueryStringParamName = TestUtilities.GenerateName("query");
                    string newApiAuthorizationScope = TestUtilities.GenerateName("oauth2scope");
                    var newApiAuthenticationSettings = new AuthenticationSettingsContract
                    {
                        OAuth2 = new OAuth2AuthenticationSettingsContract
                        {
                            AuthorizationServerId = newApiAuthorizationServerId,
                            Scope = newApiAuthorizationScope
                        }
                    };

                    var apiCreateOrUpdateParameter = new ApiCreateOrUpdateParameter
                    {
                        DisplayName = newApiName,
                        Description = newApiDescription,
                        Path = newApiPath,
                        ServiceUrl = newApiServiceUrl,
                        Protocols = new List<Protocol?> { Protocol.Https, Protocol.Http },
                        SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract
                        {
                            Header = subscriptionKeyParametersHeader,
                            Query = subscriptionKeyQueryStringParamName
                        },
                        AuthenticationSettings = newApiAuthenticationSettings
                    };
                    
                    var createdApiContract = testBase.client.Api.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        apiCreateOrUpdateParameter);

                    // get new api to check it was added
                    var apiGetResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newApiId);

                    Assert.NotNull(apiGetResponse);
                    Assert.Equal(newApiId, apiGetResponse.Name);
                    Assert.Equal(newApiName, apiGetResponse.DisplayName);
                    Assert.Equal(newApiDescription, apiGetResponse.Description);
                    Assert.Equal(newApiPath, apiGetResponse.Path);
                    Assert.Equal(newApiServiceUrl, apiGetResponse.ServiceUrl);
                    Assert.Equal(subscriptionKeyParametersHeader, apiGetResponse.SubscriptionKeyParameterNames.Header);
                    Assert.Equal(subscriptionKeyQueryStringParamName, apiGetResponse.SubscriptionKeyParameterNames.Query);
                    Assert.Equal(2, apiGetResponse.Protocols.Count);
                    Assert.True(apiGetResponse.Protocols.Contains(Protocol.Http));
                    Assert.True(apiGetResponse.Protocols.Contains(Protocol.Https));
                    Assert.NotNull(apiGetResponse.AuthenticationSettings);
                    Assert.NotNull(apiGetResponse.AuthenticationSettings.OAuth2);
                    Assert.Equal(newApiAuthorizationServerId, apiGetResponse.AuthenticationSettings.OAuth2.AuthorizationServerId);

                    // get the API Entity Tag
                    ApiGetEntityTagHeaders apiTag = testBase.client.Api.GetEntityTag(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);

                    Assert.NotNull(apiTag);
                    Assert.NotNull(apiTag.ETag);

                    // add an api revision
                    string revisionNumber = "2";
                    string newApiRevisionServiceUrl = "http://newechoapi.cloudapp.net/apiv2";

                    apiCreateOrUpdateParameter.ServiceUrl = newApiRevisionServiceUrl;

                    apiGetResponse = await testBase.client.Api.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId.ApiRevisionIdentifier(revisionNumber),
                        apiCreateOrUpdateParameter);

                    Assert.NotNull(apiGetResponse);
                    Assert.Equal(newApiId.ApiRevisionIdentifier(revisionNumber), apiGetResponse.Name);
                    Assert.Equal(newApiName, apiGetResponse.DisplayName);
                    Assert.Equal(newApiDescription, apiGetResponse.Description);
                    Assert.Equal(newApiPath, apiGetResponse.Path);
                    Assert.Equal(newApiRevisionServiceUrl, apiGetResponse.ServiceUrl);
                    Assert.Equal(subscriptionKeyParametersHeader, apiGetResponse.SubscriptionKeyParameterNames.Header);
                    Assert.Equal(subscriptionKeyQueryStringParamName, apiGetResponse.SubscriptionKeyParameterNames.Query);
                    Assert.Equal(2, apiGetResponse.Protocols.Count);
                    Assert.True(apiGetResponse.Protocols.Contains(Protocol.Http));
                    Assert.True(apiGetResponse.Protocols.Contains(Protocol.Https));
                    Assert.NotNull(apiGetResponse.AuthenticationSettings);
                    Assert.NotNull(apiGetResponse.AuthenticationSettings.OAuth2);
                    Assert.Equal(newApiAuthorizationServerId, apiGetResponse.AuthenticationSettings.OAuth2.AuthorizationServerId);

                    // list apiRevision
                    IPage<ApiRevisionContract> apiRevisions = await testBase.client.ApiRevisions.ListAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.NotNull(apiRevisions);
                    Assert.Equal(2, apiRevisions.GetEnumerator().ToIEnumerable<ApiRevisionContract>().Count());
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

                    testBase.client.AuthorizationServer.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiAuthorizationServerId,
                        "*");
                }
            }
        }
    }
}

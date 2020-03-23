// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiTests : TestBase
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

                // list all the APIs
                var listResponse = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);
                Assert.NotNull(listResponse);
                Assert.Single(listResponse);
                Assert.Null(listResponse.NextPageLink);

                var echoApi = listResponse.First();
                Assert.Equal("Echo API", echoApi.DisplayName);
                Assert.Null(echoApi.Description);
                Assert.Equal("http://echoapi.cloudapp.net/api", echoApi.ServiceUrl);
                Assert.Equal("echo", echoApi.Path);

                Assert.NotNull(echoApi.Protocols);
                Assert.Equal(1, echoApi.Protocols.Count);
                Assert.Equal(Protocol.Https, echoApi.Protocols[0]);

                // get the API by id
                var getResponse = await testBase.client.Api.GetWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    echoApi.Name);

                Assert.NotNull(getResponse);

                Assert.Equal("Echo API", getResponse.Body.DisplayName);
                Assert.Null(getResponse.Body.Description);
                Assert.Equal("http://echoapi.cloudapp.net/api", getResponse.Body.ServiceUrl);
                Assert.Equal("echo", getResponse.Body.Path);

                Assert.NotNull(getResponse.Body.Protocols);
                Assert.Equal(1, getResponse.Body.Protocols.Count);
                Assert.Equal(Protocol.Https, getResponse.Body.Protocols[0]);

                // add new api

                // create autorization server
                string newApiAuthorizationServerId = TestUtilities.GenerateName("authorizationServerId");
                string newApiId = TestUtilities.GenerateName("apiid");
                string newOpenApiId = TestUtilities.GenerateName("openApiid");
                string openIdNoSecret = TestUtilities.GenerateName("openId");

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

                    var createdApiContract = testBase.client.Api.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        new ApiCreateOrUpdateParameter
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
                        });

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

                    // patch added api
                    string patchedName = TestUtilities.GenerateName("patchedname");
                    string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                    string patchedPath = TestUtilities.GenerateName("patchedPath");

                    testBase.client.Api.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        new ApiUpdateContract
                        {
                            DisplayName = patchedName,
                            Description = patchedDescription,
                            Path = patchedPath,
                            AuthenticationSettings = new AuthenticationSettingsContract
                            {
                                OAuth2 = null
                            }
                        },
                        apiTag.ETag);

                    // get patched api to check it was patched
                    apiGetResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newApiId);

                    Assert.NotNull(apiGetResponse);
                    Assert.Equal(newApiId, apiGetResponse.Name);
                    Assert.Equal(patchedName, apiGetResponse.DisplayName);
                    Assert.Equal(patchedDescription, apiGetResponse.Description);
                    Assert.Equal(patchedPath, apiGetResponse.Path);
                    Assert.Equal(newApiServiceUrl, apiGetResponse.ServiceUrl);
                    Assert.Equal(subscriptionKeyParametersHeader, apiGetResponse.SubscriptionKeyParameterNames.Header);
                    Assert.Equal(subscriptionKeyQueryStringParamName, apiGetResponse.SubscriptionKeyParameterNames.Query);
                    Assert.Equal(2, apiGetResponse.Protocols.Count);
                    Assert.True(apiGetResponse.Protocols.Contains(Protocol.Http));
                    Assert.True(apiGetResponse.Protocols.Contains(Protocol.Https));

                    // add an api with OpenId authentication settings
                    // create a openId connect provider
                    string openIdProviderName = TestUtilities.GenerateName("openIdName");
                    string metadataEndpoint = testBase.GetOpenIdMetadataEndpointUrl();
                    string clientId = TestUtilities.GenerateName("clientId");
                    var openIdConnectCreateParameters = new OpenidConnectProviderContract(openIdProviderName,
                        metadataEndpoint, clientId);

                    var openIdCreateResponse = testBase.client.OpenIdConnectProvider.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        openIdNoSecret,
                        openIdConnectCreateParameters);

                    Assert.NotNull(openIdCreateResponse);
                    Assert.Equal(openIdProviderName, openIdCreateResponse.DisplayName);
                    Assert.Equal(openIdNoSecret, openIdCreateResponse.Name);

                    string newOpenIdApiName = TestUtilities.GenerateName("apiname");
                    string newOpenIdApiDescription = TestUtilities.GenerateName("apidescription");
                    string newOpenIdApiPath = "newOpenapiPath";
                    string newOpenIdApiServiceUrl = "http://newechoapi2.cloudapp.net/api";
                    string newOpenIdAuthorizationScope = TestUtilities.GenerateName("oauth2scope");
                    var newnewOpenIdAuthenticationSettings = new AuthenticationSettingsContract
                    {
                        Openid = new OpenIdAuthenticationSettingsContract
                        {
                            OpenidProviderId = openIdCreateResponse.Name,
                            BearerTokenSendingMethods = new[] { BearerTokenSendingMethods.AuthorizationHeader }
                        }
                    };

                    var createdOpenApiIdContract = testBase.client.Api.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newOpenApiId,
                        new ApiCreateOrUpdateParameter
                        {
                            DisplayName = newOpenIdApiName,
                            Description = newOpenIdApiDescription,
                            Path = newOpenIdApiPath,
                            ServiceUrl = newOpenIdApiServiceUrl,
                            Protocols = new List<Protocol?> { Protocol.Https, Protocol.Http },
                            SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract
                            {
                                Header = subscriptionKeyParametersHeader,
                                Query = subscriptionKeyQueryStringParamName
                            },
                            AuthenticationSettings = newnewOpenIdAuthenticationSettings
                        });

                    // get new api to check it was added
                    var openApiGetResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newOpenApiId);
                    Assert.NotNull(openApiGetResponse);
                    Assert.Equal(newOpenApiId, openApiGetResponse.Name);
                    Assert.Equal(newOpenIdApiName, openApiGetResponse.DisplayName);
                    Assert.Equal(newOpenIdApiDescription, openApiGetResponse.Description);
                    Assert.Equal(newOpenIdApiPath, openApiGetResponse.Path);
                    Assert.Equal(newOpenIdApiServiceUrl, openApiGetResponse.ServiceUrl);
                    Assert.Equal(subscriptionKeyParametersHeader, openApiGetResponse.SubscriptionKeyParameterNames.Header);
                    Assert.Equal(subscriptionKeyQueryStringParamName, openApiGetResponse.SubscriptionKeyParameterNames.Query);
                    Assert.Equal(2, openApiGetResponse.Protocols.Count);
                    Assert.True(openApiGetResponse.Protocols.Contains(Protocol.Http));
                    Assert.True(openApiGetResponse.Protocols.Contains(Protocol.Https));
                    Assert.NotNull(openApiGetResponse.AuthenticationSettings.Openid);
                    Assert.Equal(openIdCreateResponse.Name, openApiGetResponse.AuthenticationSettings.Openid.OpenidProviderId);

                    // list with paging
                    listResponse = testBase.client.Api.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        new Microsoft.Rest.Azure.OData.ODataQuery<ApiContract> { Top = 1 });

                    Assert.NotNull(listResponse);
                    Assert.Single(listResponse);
                    Assert.NotNull(listResponse.NextPageLink);

                    listResponse = testBase.client.Api.ListByServiceNext(listResponse.NextPageLink);

                    Assert.NotNull(listResponse);
                    Assert.Single(listResponse);
                    Assert.NotNull(listResponse.NextPageLink);

                    // delete the api
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");

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

                    // delete the api
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newOpenApiId,
                        "*");

                    // get the deleted api to make sure it was deleted
                    try
                    {
                        testBase.client.Api.Get(testBase.rgName, testBase.serviceName, newOpenApiId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // delete api server
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");

                    testBase.client.AuthorizationServer.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiAuthorizationServerId,
                        "*");

                    // delete api server
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newOpenApiId,
                        "*");

                    testBase.client.OpenIdConnectProvider.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        openIdNoSecret,
                        "*");
                }
            }
        }

        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CloneApiUsingSourceApiId()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // add new api
                const string swaggerPath = "./Resources/SwaggerPetStoreV2.json";
                const string path = "swaggerApi";

                string newApiAuthorizationServerId = TestUtilities.GenerateName("authorizationServerId");
                string newApiId = TestUtilities.GenerateName("apiid");
                string swaggerApiId = TestUtilities.GenerateName("swaggerApiId");

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
                        Format = ContentFormat.SwaggerJson,
                        Value = swaggerApiContent
                    };

                    var swaggerApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            swaggerApiId,
                            apiCreateOrUpdate);

                    Assert.NotNull(swaggerApiResponse);
                    Assert.True(swaggerApiResponse.SubscriptionRequired);
                    Assert.Equal(path, swaggerApiResponse.Path);

                    var swagerApiOperations = await testBase.client.ApiOperation.ListByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        swaggerApiResponse.Name);

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

                    await testBase.client.AuthorizationServer.CreateOrUpdateAsync(
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

                    var createdApiContract = testBase.client.Api.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        new ApiCreateOrUpdateParameter
                        {
                            SourceApiId = swaggerApiResponse.Id, // create a clone of the Swagger API created above and override the following parameters
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
                            AuthenticationSettings = newApiAuthenticationSettings,
                            SubscriptionRequired = true,
                        });

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
                    Assert.True(apiGetResponse.SubscriptionRequired);

                    var newApiOperations = await testBase.client.ApiOperation.ListByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);

                    Assert.NotNull(newApiOperations);
                    // make sure all operations got copied
                    Assert.Equal(swagerApiOperations.Count(), newApiOperations.Count());
                }
                finally
                {
                    // delete api server
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        swaggerApiId,
                        "*");

                    // delete api server
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");

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

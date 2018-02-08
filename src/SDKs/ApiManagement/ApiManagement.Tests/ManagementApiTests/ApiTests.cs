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
using System.IO;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list all the APIs
                var listResponse = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);
                Assert.NotNull(listResponse);                                
                Assert.Equal(1, listResponse.Count());
                Assert.NotNull(listResponse.NextPageLink);

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

                try
                {
                    var createAuthServerParams = new AuthorizationServerContract
                    {
                        DisplayName = TestUtilities.GenerateName("authName"),
                        DefaultScope = TestUtilities.GenerateName("oauth2scope"),
                        AuthorizationEndpoint = "https://contoso.com/auth",
                        TokenEndpoint = "https://contoso.com/token",
                        ClientRegistrationEndpoint = "https://contoso.com/clients/reg",
                        GrantTypes = new List<GrantType?> { GrantType.AuthorizationCode, GrantType.Implicit },
                        AuthorizationMethods = new List<AuthorizationMethod?> { AuthorizationMethod.POST, AuthorizationMethod.GET },
                        BearerTokenSendingMethods = new List<BearerTokenSendingMethod?> { BearerTokenSendingMethod.AuthorizationHeader, BearerTokenSendingMethod.Query },
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
                        "*");

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

                    // list with paging
                    listResponse = testBase.client.Api.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        new Microsoft.Rest.Azure.OData.ODataQuery<ApiContract> { Top = 1 });

                    Assert.NotNull(listResponse);
                    Assert.Equal(1, listResponse.Count());
                    Assert.NotNull(listResponse.NextPageLink);

                    listResponse = testBase.client.Api.ListByServiceNext(listResponse.NextPageLink);

                    Assert.NotNull(listResponse);
                    Assert.Equal(1, listResponse.Count());
                    Assert.Empty(listResponse.NextPageLink);

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
                }
                finally
                {
                    // delete authorization server
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

        [Fact]
        public async Task ImportFromSwaggerDocument()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                const string swaggerPath = "./Resources/SwaggerPetStoreV2.json";                
                const string path = "swaggerApi";
                string swaggerApi = TestUtilities.GenerateName("aid");

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
                            swaggerApi,
                            apiCreateOrUpdate);

                    Assert.NotNull(swaggerApiResponse);

                    // get the api to check it was created
                    var getResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, swaggerApi);

                    Assert.NotNull(getResponse);                    
                    Assert.Equal(swaggerApi, getResponse.Name);
                    Assert.Equal(path, getResponse.Path);
                    Assert.Equal("Swagger Petstore Extensive", getResponse.DisplayName);
                    Assert.Equal("http://petstore.swagger.wordnik.com/api", getResponse.ServiceUrl);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, swaggerApi, "*");
                }

            }
        }

        [Fact]
        public async Task ImportFromWadlDocument()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                const string wadlPath = "./Resources/WADLYahoo.xml";
                const string path = "yahooWadl";
                string wadlApi = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    string wadlApiContent;
                    using (StreamReader reader = File.OpenText(wadlPath))
                    {
                        wadlApiContent = reader.ReadToEnd();
                    }

                    var apiCreateOrUpdate = new ApiCreateOrUpdateParameter()
                    {
                        Path = path,
                        ContentFormat = ContentFormat.WadlXml,
                        ContentValue = wadlApiContent
                    };

                    var wadlApiResponse = testBase.client.Api.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            wadlApi,
                            apiCreateOrUpdate);

                    Assert.NotNull(wadlApiResponse);

                    // get the api to check it was created
                    var getResponse = testBase.client.Api.Get(testBase.rgName, testBase.serviceName, wadlApi);

                    Assert.NotNull(getResponse);
                    Assert.Equal(wadlApi, getResponse.Name);
                    Assert.Equal(path, getResponse.Path);
                    Assert.Equal("Yahoo News Search", getResponse.DisplayName);
                    Assert.Equal("http://api.search.yahoo.com/NewsSearchService/V1/", getResponse.ServiceUrl);
                    Assert.True(getResponse.IsCurrent);
                    Assert.True(getResponse.Protocols.Contains(Protocol.Https));
                    Assert.Equal("1", getResponse.ApiRevision);
                }
                finally
                {
                    // remove the API
                    testBase.client.Api.Delete(testBase.rgName, testBase.serviceName, wadlApi, "*");
                }
            }
        }
    }
}

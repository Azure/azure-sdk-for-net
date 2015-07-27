//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.IO;
    using System.Net;
    using System.Xml.Linq;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Newtonsoft.Json;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void ApisCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApisCreateListUpdateDelete");

            try
            {
                // list all the APIs
                var listResponse = ApiManagementClient.Apis.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                // there should be 'Echo API' which is created by default for every new instance of :
                /*
                {  
                   "value":[  
                      {  
                         "id":"/apis/5515969a0a6a4406e8040001",
                         "name":"Echo API",
                         "description":null,
                         "serviceUrl":"http://echoapi.cloudapp.net/api",
                         "path":"echo",
                         "protocols":[  
                            "https"
                         ],
                         "authenticationSettings":null,
                         "subscriptionKeyParameterNames":null
                      }
                   ],
                   "count":1,
                   "nextLink":null
                }
                */

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(1, listResponse.Result.TotalCount);
                Assert.Equal(1, listResponse.Result.Values.Count);
                Assert.Null(listResponse.Result.NextLink);

                Assert.Equal("Echo API", listResponse.Result.Values[0].Name);
                Assert.Null(listResponse.Result.Values[0].Description);
                Assert.Equal("http://echoapi.cloudapp.net/api", listResponse.Result.Values[0].ServiceUrl);
                Assert.Equal("echo", listResponse.Result.Values[0].Path);

                Assert.NotNull(listResponse.Result.Values[0].Protocols);
                Assert.Equal(1, listResponse.Result.Values[0].Protocols.Count);
                Assert.Equal(ApiProtocolContract.Https, listResponse.Result.Values[0].Protocols[0]);

                // get the API by id
                var getResponse = ApiManagementClient.Apis.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    listResponse.Result.Values[0].Id);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal("Echo API", getResponse.Value.Name);
                Assert.Null(getResponse.Value.Description);
                Assert.Equal("http://echoapi.cloudapp.net/api", getResponse.Value.ServiceUrl);
                Assert.Equal("echo", getResponse.Value.Path);

                Assert.NotNull(getResponse.Value.Protocols);
                Assert.Equal(1, getResponse.Value.Protocols.Count);
                Assert.Equal(ApiProtocolContract.Https, getResponse.Value.Protocols[0]);

                // add new api

                // create autorization server
                string newApiAuthorizationServerId = TestUtilities.GenerateName("authorizationServerId");
                try
                {
                    var createAuthServerParams = new AuthorizationServerCreateOrUpdateParameters(
                        new OAuth2AuthorizationServerContract
                        {
                            Name = TestUtilities.GenerateName("authName"),
                            DefaultScope = TestUtilities.GenerateName("oauth2scope"),
                            AuthorizationEndpoint = "https://contoso.com/auth",
                            TokenEndpoint = "https://contoso.com/token",
                            ClientRegistrationEndpoint = "https://contoso.com/clients/reg",
                            GrantTypes = new[] {GrantTypesContract.AuthorizationCode, GrantTypesContract.Implicit},
                            AuthorizationMethods = new[] {MethodContract.Post, MethodContract.Get},
                            BearerTokenSendingMethods = new[] {BearerTokenSendingMethodsContract.AuthorizationHeader, BearerTokenSendingMethodsContract.Query},
                            ClientId = TestUtilities.GenerateName("clientid")
                        });
                    ApiManagementClient.AuthorizationServers.Create(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        newApiAuthorizationServerId,
                        createAuthServerParams);

                    string newApiId = TestUtilities.GenerateName("apiid");
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

                    var createResponse = ApiManagementClient.Apis.CreateOrUpdate(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        newApiId,
                        new ApiCreateOrUpdateParameters(
                            new ApiContract
                            {
                                Name = newApiName,
                                Description = newApiDescription,
                                Path = newApiPath,
                                ServiceUrl = newApiServiceUrl,
                                Protocols = new[] {ApiProtocolContract.Https, ApiProtocolContract.Http},
                                SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract
                                {
                                    Header = subscriptionKeyParametersHeader,
                                    Query = subscriptionKeyQueryStringParamName
                                },
                                AuthenticationSettings = newApiAuthenticationSettings
                            }),
                        null
                        );

                    Assert.NotNull(createResponse);
                    Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                    // get new api to check it was added
                    getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, newApiId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Value);
                    Assert.Equal(newApiId, getResponse.Value.Id);
                    Assert.Equal(newApiName, getResponse.Value.Name);
                    Assert.Equal(newApiDescription, getResponse.Value.Description);
                    Assert.Equal(newApiPath, getResponse.Value.Path);
                    Assert.Equal(newApiServiceUrl, getResponse.Value.ServiceUrl);
                    Assert.Equal(subscriptionKeyParametersHeader, getResponse.Value.SubscriptionKeyParameterNames.Header);
                    Assert.Equal(subscriptionKeyQueryStringParamName, getResponse.Value.SubscriptionKeyParameterNames.Query);
                    Assert.Equal(2, getResponse.Value.Protocols.Count);
                    Assert.True(getResponse.Value.Protocols.Contains(ApiProtocolContract.Http));
                    Assert.True(getResponse.Value.Protocols.Contains(ApiProtocolContract.Https));
                    Assert.NotNull(getResponse.Value.AuthenticationSettings);
                    Assert.NotNull(getResponse.Value.AuthenticationSettings.OAuth2);
                    Assert.Equal(newApiAuthorizationServerId, getResponse.Value.AuthenticationSettings.OAuth2.AuthorizationServerId);

                    // patch added api
                    string patchedName = TestUtilities.GenerateName("patchedname");
                    string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                    string patchedPath = TestUtilities.GenerateName("patchedPath");

                    var patchResponse = ApiManagementClient.Apis.Patch(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        newApiId,
                        new PatchParameters
                        {
                            RawJson = JsonConvert.SerializeObject(new
                            {
                                Name = patchedName,
                                Description = patchedDescription,
                                Path = patchedPath,
                                AuthenticationSettings = new AuthenticationSettingsContract
                                {
                                    OAuth2 = null
                                }
                            })
                        },
                        getResponse.ETag);

                    Assert.NotNull(patchResponse);
                    Assert.Equal(HttpStatusCode.NoContent, patchResponse.StatusCode);

                    // get patched api to check it was patched
                    getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, newApiId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Value);
                    Assert.Equal(newApiId, getResponse.Value.Id);
                    Assert.Equal(patchedName, getResponse.Value.Name);
                    Assert.Equal(patchedDescription, getResponse.Value.Description);
                    Assert.Equal(patchedPath, getResponse.Value.Path);
                    Assert.Equal(newApiServiceUrl, getResponse.Value.ServiceUrl);
                    Assert.Equal(subscriptionKeyParametersHeader, getResponse.Value.SubscriptionKeyParameterNames.Header);
                    Assert.Equal(subscriptionKeyQueryStringParamName, getResponse.Value.SubscriptionKeyParameterNames.Query);
                    Assert.Equal(2, getResponse.Value.Protocols.Count);
                    Assert.True(getResponse.Value.Protocols.Contains(ApiProtocolContract.Http));
                    Assert.True(getResponse.Value.Protocols.Contains(ApiProtocolContract.Https));

                    // list with paging
                    listResponse = ApiManagementClient.Apis.List(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        new QueryParameters {Top = 1});

                    Assert.NotNull(listResponse);
                    Assert.NotNull(listResponse.Result.Values);
                    Assert.Equal(2, listResponse.Result.TotalCount);
                    Assert.Equal(1, listResponse.Result.Values.Count);
                    Assert.NotNull(listResponse.Result.NextLink);

                    listResponse = ApiManagementClient.Apis.ListNext(listResponse.Result.NextLink);

                    Assert.NotNull(listResponse);
                    Assert.NotNull(listResponse.Result.Values);
                    Assert.Equal(2, listResponse.Result.TotalCount);
                    Assert.Equal(1, listResponse.Result.Values.Count);
                    Assert.Null(listResponse.Result.NextLink);

                    // delete the api
                    var deleteResponse = ApiManagementClient.Apis.Delete(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        newApiId,
                        "*");

                    Assert.NotNull(deleteResponse);
                    Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                    // get the deleted api to make sure it was deleted
                    try
                    {
                        ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, newApiId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // delete authorization server
                    ApiManagementClient.AuthorizationServers.Delete(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        newApiAuthorizationServerId,
                        "*");
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void ApiImportExport()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApiImportExport");

            try
            {
                const string wadlPath = "./Resources/WADLYahoo.xml";
                const string wadlMediaType = "application/vnd.sun.wadl+xml";
                const string path = "wadlapi";
                string wadlApiId = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    AzureOperationResponse importResponse = null;
                    using (var stream = File.OpenRead(wadlPath))
                    {
                        importResponse = ApiManagementClient.Apis.Import(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            wadlApiId,
                            wadlMediaType,
                            stream,
                            path);
                    }

                    Assert.NotNull(importResponse);
                    Assert.Equal(HttpStatusCode.Created, importResponse.StatusCode);

                    // get the api to check it was created
                    var getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, wadlApiId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Value);
                    Assert.Equal(wadlApiId, getResponse.Value.Id);
                    Assert.Equal(path, getResponse.Value.Path);

                    // export API
                    var exportResponse = ApiManagementClient.Apis.Export(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        wadlApiId,
                        wadlMediaType);

                    Assert.NotNull(exportResponse);
                    Assert.NotNull(exportResponse.Content);

                    var expectedWadlDoc = XDocument.Load(File.OpenRead(wadlPath));
                    var wadlDoc = XDocument.Load(new MemoryStream(exportResponse.Content));

                    Assert.Equal(expectedWadlDoc.Root.Value, wadlDoc.Root.Value);
                }
                finally
                {
                    // remove the API
                    ApiManagementClient.Apis.Delete(ResourceGroupName, ApiManagementServiceName, wadlApiId, "*");
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}
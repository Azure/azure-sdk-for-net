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
    using System.Xml.Schema;
    using Hyak.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SmapiModels;
    using Test;
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
        public void ApiImportExport_Wadl()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApiImportExport_Wadl");

            try
            {
                const string wadlPath = "./Resources/WADLYahoo.xml";
                const string wadl2Path = "./Resources/WADLYahooModified.xml";
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
                            path,
                            string.Empty,
                            string.Empty,
                            null);
                    }

                    Assert.NotNull(importResponse);
                    Assert.Equal(HttpStatusCode.Created, importResponse.StatusCode);

                    // get the api to check it was created
                    var getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, wadlApiId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Value);
                    Assert.Equal(wadlApiId, getResponse.Value.Id);
                    Assert.Equal(path, getResponse.Value.Path);
                    Assert.Equal(ApiTypeContract.Http, getResponse.Value.Type);

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

                    // import on existing api
                    using (var stream = File.OpenRead(wadl2Path))
                    {
                        importResponse = ApiManagementClient.Apis.Import(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            wadlApiId,
                            wadlMediaType,
                            stream,
                            path,
                            string.Empty,
                            string.Empty,
                            null);
                    }

                    Assert.NotNull(importResponse);
                    Assert.Equal(HttpStatusCode.NoContent, importResponse.StatusCode);

                    // get the api to check it was created
                    getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, wadlApiId);

                    Assert.Equal("http://api.search.yahoo.com/NewsSearchService/V2/", getResponse.Value.ServiceUrl);
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

        [Fact]
        public void ApiImportExport_Swagger()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApiImportExport_Swagger");

            try
            {
                const string swaggerPath = "./Resources/SwaggerPetStoreV2.json";
                const string expectedSwaggerPath = "./Resources/SwaggerPetStoreV2Expected.json";
                const string swaggerMediaType = "application/vnd.swagger.doc+json";
                const string path = "swaggerApi";
                string swaggerApi = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    AzureOperationResponse importResponse = null;
                    using (var stream = File.OpenRead(swaggerPath))
                    {
                        importResponse = ApiManagementClient.Apis.Import(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            swaggerApi,
                            swaggerMediaType,
                            stream,
                            path,
                            null,
                            null,
                            null);
                    }

                    Assert.NotNull(importResponse);
                    Assert.Equal(HttpStatusCode.Created, importResponse.StatusCode);

                    // get the api to check it was created
                    var getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, swaggerApi);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Value);
                    Assert.Equal(swaggerApi, getResponse.Value.Id);
                    Assert.Equal(path, getResponse.Value.Path);
                    Assert.Equal(ApiTypeContract.Http, getResponse.Value.Type);

                    // export API
                    var exportResponse = ApiManagementClient.Apis.Export(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        swaggerApi,
                        swaggerMediaType);

                    Assert.NotNull(exportResponse);
                    Assert.NotNull(exportResponse.Content);

                    JObject expectedExportedSwagger = new JObject();
                    byte[] swaggerExpectedBytes = File.ReadAllBytes(expectedSwaggerPath);
                    using (Stream stream = new MemoryStream(swaggerExpectedBytes))
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        JsonReader jread = new JsonTextReader(sr);
                        expectedExportedSwagger = JObject.Load(jread);
                    }

                    JObject actualExportedSwagger;
                    using (Stream stream = new MemoryStream(exportResponse.Content))
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        JsonReader jread = new JsonTextReader(sr);
                        actualExportedSwagger = JObject.Load(jread);
                    }

                    Assert.Equal(expectedExportedSwagger.GetValue("info"), actualExportedSwagger.GetValue("info"));
                }
                finally
                {
                    // remove the API
                    ApiManagementClient.Apis.Delete(ResourceGroupName, ApiManagementServiceName, swaggerApi, "*");
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void ApiImportExport_Wsdl()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApiImportExport_Wsdl");

            try
            {
                const string wsdlPath = "./Resources/Weather.wsdl";
                const string wsdlXsdSchema = "./Resources/wsdl11.xsd";
                const string wsdlMediaType = "application/wsdl+xml";
                const string path = "soapApi";
                const string wsdlServiceName = "Weather";
                const string wsdlEndpointName = "WeatherSoap";
                string soapApiId = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    AzureOperationResponse importResponse = null;
                    using (var stream = File.OpenRead(wsdlPath))
                    {
                        importResponse = ApiManagementClient.Apis.Import(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            soapApiId,
                            wsdlMediaType,
                            stream,
                            path,
                            wsdlServiceName,
                            wsdlEndpointName,
                            "http");
                    }

                    Assert.NotNull(importResponse);
                    Assert.Equal(HttpStatusCode.Created, importResponse.StatusCode);

                    // get the api to check it was created
                    var getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, soapApiId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Value);
                    Assert.Equal(soapApiId, getResponse.Value.Id);
                    Assert.Equal(path, getResponse.Value.Path);
                    Assert.Equal(ApiTypeContract.Soap, getResponse.Value.Type);

                    // export API
                    var exportResponse = ApiManagementClient.Apis.Export(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        soapApiId,
                        wsdlMediaType);

                    Assert.NotNull(exportResponse);
                    Assert.NotNull(exportResponse.Content);

                    string wsdlOutput;
                    using (Stream stream = new MemoryStream(exportResponse.Content))
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        wsdlOutput = sr.ReadToEnd();
                    }

                    XmlSchemaSet xsds = new XmlSchemaSet();
                    byte[] expectedSchema = File.ReadAllBytes(wsdlXsdSchema);
                    using (Stream xsdstream = new MemoryStream(expectedSchema))
                    {
                        xsds.Add(XmlSchema.Read(xsdstream, (s, e) => { Assert.True(false, e.Message); }));
                        xsds.Compile();
                    }
                    
                    var doc = XDocument.Parse(wsdlOutput);
                    doc.Validate(xsds, (s, e) => { Assert.True( false, e.Message); });
                }
                finally
                {
                    // remove the API
                    ApiManagementClient.Apis.Delete(ResourceGroupName, ApiManagementServiceName, soapApiId, "*");
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void ApiImportExport_Wsdl_SoapToRest()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApiImportExport_Wsdl_SoapToRest");

            try
            {
                const string wsdlPath = "./Resources/Weather.wsdl";
                const string wsdlXsdSchema = "./Resources/wsdl11.xsd";
                const string wsdlMediaType = "application/wsdl+xml";
                const string path = "soapApi";
                const string wsdlServiceName = "Weather";
                const string wsdlEndpointName = "WeatherSoap";
                string soapApiId = TestUtilities.GenerateName("aid");

                try
                {
                    // import API
                    AzureOperationResponse importResponse = null;
                    using (var stream = File.OpenRead(wsdlPath))
                    {
                        importResponse = ApiManagementClient.Apis.Import(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            soapApiId,
                            wsdlMediaType,
                            stream,
                            path,
                            wsdlServiceName,
                            wsdlEndpointName,
                            "soap");
                    }

                    Assert.NotNull(importResponse);
                    Assert.Equal(HttpStatusCode.Created, importResponse.StatusCode);

                    // get the api to check it was created
                    var getResponse = ApiManagementClient.Apis.Get(ResourceGroupName, ApiManagementServiceName, soapApiId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Value);
                    Assert.Equal(soapApiId, getResponse.Value.Id);
                    Assert.Equal(path, getResponse.Value.Path);
                    Assert.Equal(ApiTypeContract.Soap, getResponse.Value.Type);

                    // export API
                    var exportResponse = ApiManagementClient.Apis.Export(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        soapApiId,
                        wsdlMediaType);

                    Assert.NotNull(exportResponse);
                    Assert.NotNull(exportResponse.Content);

                    string wsdlOutput;
                    using (Stream stream = new MemoryStream(exportResponse.Content))
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        wsdlOutput = sr.ReadToEnd();
                    }

                    XmlSchemaSet xsds = new XmlSchemaSet();
                    byte[] expectedSchema = File.ReadAllBytes(wsdlXsdSchema);
                    using (Stream xsdstream = new MemoryStream(expectedSchema))
                    {
                        xsds.Add(XmlSchema.Read(xsdstream, (s, e) => { Assert.True(false, e.Message); }));
                        xsds.Compile();
                    }

                    var doc = XDocument.Parse(wsdlOutput);
                    doc.Validate(xsds, (s, e) => { Assert.True(false, e.Message); });
                }
                finally
                {
                    // remove the API
                    ApiManagementClient.Apis.Delete(ResourceGroupName, ApiManagementServiceName, soapApiId, "*");
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}
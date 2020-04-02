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
using System.Xml.Linq;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiSchemaTests : TestBase
    {
        public static string XmlSchemaString2 = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
<xs:element name=""shiporder"">
  <xs:complexType>
    <xs:sequence>
      <xs:element name=""orderperson"" type=""xs:string""/>
      <xs:element name=""shipto"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""name"" type=""xs:string""/>
            <xs:element name=""address"" type=""xs:string""/>
            <xs:element name=""city"" type=""xs:string""/>
            <xs:element name=""country"" type=""xs:string""/>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
      <xs:element name=""item"" maxOccurs=""unbounded"">
        <xs:complexType>
          <xs:sequence>
            <xs:element name=""title"" type=""xs:string""/>
            <xs:element name=""note"" type=""xs:string"" minOccurs=""0""/>
            <xs:element name=""quantity"" type=""xs:positiveInteger""/>
            <xs:element name=""price"" type=""xs:decimal""/>
          </xs:sequence>
        </xs:complexType>
      </xs:element>
    </xs:sequence>
    <xs:attribute name=""orderid"" type=""xs:string"" use=""required""/>
  </xs:complexType>
</xs:element>
</xs:schema> ";

        public static string JsonSchemaString1 = @"{
            ""pet"": {
                ""required"": [""id"",
                ""name""],
                ""externalDocs"": {
                    ""description"": ""findmoreinfohere"",
                    ""url"": ""https: //helloreverb.com/about""
                },
                ""properties"": {
                    ""id"": {
                        ""type"": ""integer"",
                        ""format"": ""int64""
                    },
                    ""name"": {
                        ""type"": ""string""
                    },
                    ""tag"": {
                        ""type"": ""string""
                    }
                }
            },
            ""newPet"": {
                ""allOf"": [{
                    ""$ref"": ""pet""
                },
                {
                    ""required"": [""name""],
                    ""id"": {
                        ""properties"": {
                            ""type"": ""integer"",
                            ""format"": ""int64""
                        }
                    }
                }]
            },
            ""errorModel"": {
                ""required"": [""code"",
                ""message""],
                ""properties"": {
                    ""code"": {
                        ""type"": ""integer"",
                        ""format"": ""int32""
                    },
                    ""message"": {
                        ""type"": ""string""
                    }
                }
            }
        }";

        public static string JsonSchemaStringWithDefinitions = @"{""definitions"":{
            ""pet"": {
                ""required"": [""id"",
                ""name""],
                ""externalDocs"": {
                    ""description"": ""findmoreinfohere"",
                    ""url"": ""https: //helloreverb.com/about""
                },
                ""properties"": {
                    ""id"": {
                        ""type"": ""integer"",
                        ""format"": ""int64""
                    },
                    ""name"": {
                        ""type"": ""string""
                    },
                    ""tag"": {
                        ""type"": ""string""
                    }
                }
            },
            ""newPet"": {
                ""allOf"": [{
                    ""$ref"": ""pet""
                },
                {
                    ""required"": [""name""],
                    ""id"": {
                        ""properties"": {
                            ""type"": ""integer"",
                            ""format"": ""int64""
                        }
                    }
                }]
            },
            ""errorModel"": {
                ""required"": [""code"",
                ""message""],
                ""properties"": {
                    ""code"": {
                        ""type"": ""integer"",
                        ""format"": ""int32""
                    },
                    ""message"": {
                        ""type"": ""string""
                    }
                }
            }
        }}";

        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDeleteSwaggerSchema()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // add new api               
                string newApiId = TestUtilities.GenerateName("apiid");
                string newSchemaId = TestUtilities.GenerateName("schemaid");

                try
                {
                    string newApiName = TestUtilities.GenerateName("apiname");
                    string newApiDescription = TestUtilities.GenerateName("apidescription");
                    string newApiPath = "newapiPath";
                    string newApiServiceUrl = "http://newechoapi.cloudapp.net/api";
                    string subscriptionKeyParametersHeader = TestUtilities.GenerateName("header");
                    string subscriptionKeyQueryStringParamName = TestUtilities.GenerateName("query");

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
                            }
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

                    var schemaContractParams = new SchemaContract()
                    {
                        ContentType = "application/vnd.ms-azure-apim.swagger.definitions+json",
                        Value = JsonSchemaString1
                    };

                    var schemaContract = await testBase.client.ApiSchema.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaContractParams);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);
                    Assert.NotNull(schemaContract.Definitions);
                    Assert.Null(schemaContract.Value);

                    // list the schemas attached to the api
                    var schemasList = await testBase.client.ApiSchema.ListByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.NotNull(schemasList);
                    Assert.Single(schemasList);
                    Assert.Equal(schemaContractParams.ContentType, schemasList.First().ContentType);

                    // get the schema tag
                    var schemaTag = await testBase.client.ApiSchema.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId);
                    Assert.NotNull(schemaTag);
                    Assert.NotNull(schemaTag.ETag);

                    // delete the schema
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaTag.ETag);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);

                    // check the entity is deleted
                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.ApiSchema.Get(testBase.rgName, testBase.serviceName, newApiId, newSchemaId));

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
                    // delete the apischema 
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        "*");


                    // delete the api
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");
                }
            }
        }

        [Fact]
        public async Task CreateListUpdateDeleteOpenApiSchema()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // add new api               
                string newApiId = TestUtilities.GenerateName("apiid");
                string newSchemaId = TestUtilities.GenerateName("schemaid");

                try
                {
                    string newApiName = TestUtilities.GenerateName("apiname");
                    string newApiDescription = TestUtilities.GenerateName("apidescription");
                    string newApiPath = "newapiPath";
                    string newApiServiceUrl = "http://newechoapi.cloudapp.net/api";
                    string subscriptionKeyParametersHeader = TestUtilities.GenerateName("header");
                    string subscriptionKeyQueryStringParamName = TestUtilities.GenerateName("query");

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
                            }
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

                    //check schema containig definitions
                    var schemaContractParams = new SchemaContract()
                    {
                        ContentType = "application/vnd.ms-azure-apim.swagger.definitions+json",
                        Value = JsonSchemaStringWithDefinitions
                    };

                    var schemaContract = await testBase.client.ApiSchema.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaContractParams);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);
                    Assert.NotNull(schemaContract.Definitions);
                    Assert.Null(schemaContract.Value);

                    //check schema without definitions
                    schemaContractParams = new SchemaContract()
                    {
                        ContentType = "application/vnd.oai.openapi.components+json",
                        Value = JsonSchemaString1
                    };

                    schemaContract = await testBase.client.ApiSchema.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaContractParams);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);
                    Assert.Null(schemaContract.Definitions);
                    Assert.NotNull(schemaContract.Value);

                    // list the schemas attached to the api
                    var schemasList = await testBase.client.ApiSchema.ListByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.NotNull(schemasList);
                    Assert.Single(schemasList);
                    Assert.Equal(schemaContractParams.ContentType, schemasList.First().ContentType);

                    // get the schema tag
                    var schemaTag = await testBase.client.ApiSchema.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId);
                    Assert.NotNull(schemaTag);
                    Assert.NotNull(schemaTag.ETag);

                    // delete the schema
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaTag.ETag);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);

                    // check the entity is deleted
                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.ApiSchema.Get(testBase.rgName, testBase.serviceName, newApiId, newSchemaId));

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
                    // delete the apischema 
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        "*");


                    // delete the api
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");
                }
            }
        }

        [Fact]
        public async Task CreateListUpdateDeleteWsdlSchema()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // add new api               
                string newApiId = TestUtilities.GenerateName("apiid");
                string newSchemaId = TestUtilities.GenerateName("schemaid");

                try
                {
                    string newApiName = TestUtilities.GenerateName("apiname");
                    string newApiDescription = TestUtilities.GenerateName("apidescription");
                    string newApiPath = "newapiPath";
                    string newApiServiceUrl = "http://newechoapi.cloudapp.net/api";
                    string subscriptionKeyParametersHeader = TestUtilities.GenerateName("header");
                    string subscriptionKeyQueryStringParamName = TestUtilities.GenerateName("query");

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
                            }
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

                    XDocument schemaXDoc = XDocument.Parse(XmlSchemaString2);
                    var schemaContractParams = new SchemaContract()
                    {
                        ContentType = "application/vnd.ms-azure-apim.xsd+xml",
                        Value = schemaXDoc.ToString()
                    };

                    var schemaContract = await testBase.client.ApiSchema.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaContractParams);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);
                    Assert.NotNull(schemaContract.Value);
                    Assert.Null(schemaContract.Definitions);
                    Assert.NotNull(schemaContract.WsdlSchema);

                    // list the schemas attached to the api
                    var schemasList = await testBase.client.ApiSchema.ListByApiAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId);
                    Assert.NotNull(schemasList);
                    Assert.Single(schemasList);
                    Assert.Equal(schemaContractParams.ContentType, schemasList.First().ContentType);

                    // get the schema tag
                    var schemaTag = await testBase.client.ApiSchema.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId);
                    Assert.NotNull(schemaTag);
                    Assert.NotNull(schemaTag.ETag);

                    // delete the schema
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        schemaTag.ETag);
                    Assert.NotNull(schemaContract);
                    Assert.Equal(schemaContractParams.ContentType, schemaContract.ContentType);

                    // check the entity is deleted
                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.ApiSchema.Get(testBase.rgName, testBase.serviceName, newApiId, newSchemaId));

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
                    // delete the apischema 
                    await testBase.client.ApiSchema.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        newSchemaId,
                        "*");


                    // delete the api
                    testBase.client.Api.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newApiId,
                        "*");
                }
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiSchemaTests : ApiManagementManagementTestBase
    {
        public ApiSchemaTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

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

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var apiCollection = ApiServiceResource.GetApis();

            // Add new api
            string newApiId = Recording.GenerateAssetName("apiid");
            string newSchemaId = Recording.GenerateAssetName("schemaid");
            string newApiName = Recording.GenerateAssetName("apiname");
            string newApiDescription = Recording.GenerateAssetName("apidescription");
            string newApiPath = "newapiPath";
            string newApiServiceUrl = "http://newechoapi.cloudapp.net/api";
            string subscriptionKeyParametersHeader = Recording.GenerateAssetName("header");
            string subscriptionKeyQueryStringParamName = Recording.GenerateAssetName("query");
            var apiContent = new ApiCreateOrUpdateContent()
            {
                DisplayName = newApiName,
                Description = newApiDescription,
                Path = newApiPath,
                ServiceLink = newApiServiceUrl,
                Protocols = { ApiOperationInvokableProtocol.Https, ApiOperationInvokableProtocol.Http },
                SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract()
                {
                    Header = subscriptionKeyParametersHeader,
                    Query = subscriptionKeyQueryStringParamName
                }
            };

            var createdApiContract = (await apiCollection.CreateOrUpdateAsync(WaitUntil.Completed, newApiId, apiContent)).Value;

            // Get new api to check it was added
            var apiGetResponse = (await apiCollection.GetAsync(newApiId)).Value;
            Assert.NotNull(apiGetResponse);
            Assert.AreEqual(newApiId, apiGetResponse.Data.Name);
            Assert.AreEqual(newApiName, apiGetResponse.Data.DisplayName);
            Assert.AreEqual(newApiDescription, apiGetResponse.Data.Description);
            Assert.AreEqual(newApiPath, apiGetResponse.Data.Path);
            Assert.AreEqual(newApiServiceUrl, apiGetResponse.Data.ServiceLink);
            Assert.AreEqual(subscriptionKeyParametersHeader, apiGetResponse.Data.SubscriptionKeyParameterNames.Header);
            Assert.AreEqual(subscriptionKeyQueryStringParamName, apiGetResponse.Data.SubscriptionKeyParameterNames.Query);
            Assert.AreEqual(2, apiGetResponse.Data.Protocols.Count);
            Assert.IsTrue(apiGetResponse.Data.Protocols.Contains(ApiOperationInvokableProtocol.Http));
            Assert.IsTrue(apiGetResponse.Data.Protocols.Contains(ApiOperationInvokableProtocol.Https));

            var schemaCollection = apiGetResponse.GetApiSchemas();
            ApiSchemaData schemaData = null;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                schemaData = new ApiSchemaData()
                {
                    ContentType = "application/vnd.ms-azure-apim.swagger.definitions+json",
                    Value = JsonSchemaString1
                };
            }
            else
            {
                schemaData = new ApiSchemaData()
                {
                    ContentType = "application/vnd.ms-azure-apim.swagger.definitions+json",
                    Value = JsonSchemaString1.Replace("\n", "\r\n")
                };
            }
            var schemaContract = (await schemaCollection.CreateOrUpdateAsync(WaitUntil.Completed, newSchemaId, schemaData)).Value;
            Assert.NotNull(schemaContract);
            Assert.AreEqual(schemaData.ContentType, schemaContract.Data.ContentType);
            Assert.NotNull(schemaContract.Data.Definitions);
            Assert.Null(schemaContract.Data.Value);

            // list the schemas attached to the api
            var schemasList = await schemaCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(schemasList);
            Assert.AreEqual(schemasList.Count, 1);
            Assert.AreEqual(schemaData.ContentType, schemasList.FirstOrDefault().Data.ContentType);

            // delete the schema
            await schemaContract.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await schemaCollection.ExistsAsync(newSchemaId)).Value;
            Assert.IsFalse(resultFalse);
        }
    }
}

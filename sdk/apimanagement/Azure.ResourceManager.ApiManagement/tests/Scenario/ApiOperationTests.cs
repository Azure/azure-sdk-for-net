// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiOperationTests : ApiManagementManagementTestBase
    {
        public ApiOperationTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private VirtualNetworkCollection VNetCollection { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiCollection Collection { get; set; }

        private ApiResource Resources { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            VNetCollection = ResourceGroup.GetVirtualNetworks();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var list = await ApiServiceResource.GetApis().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(list.Count == 1);
            var api = list.Single();

            var collection = api.GetApiOperations();
            var operations = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(operations);
            Assert.GreaterOrEqual(operations.Count, 1);

            // Get first operation
            var firstOperation = operations.First();
            var getResponse = (await collection.GetAsync(firstOperation.Data.Name)).Value;
            Assert.NotNull(getResponse);
            Assert.AreEqual(firstOperation.Data.Name, getResponse.Data.Name);
            Assert.AreEqual(firstOperation.Data.Method, getResponse.Data.Method);
            Assert.AreEqual(firstOperation.Data.UriTemplate, getResponse.Data.UriTemplate);

            // Add new operation
            string newOperationId = Recording.GenerateAssetName("operationid");
            string newOperationName = Recording.GenerateAssetName("operationName");
            string newOperationMethod = "PATCH";
            string newperationUrlTemplate = "/newresource";
            string newOperationDescription = Recording.GenerateAssetName("operationDescription");
            string newOperationRequestDescription = Recording.GenerateAssetName("operationRequestDescription");

            string newOperationRequestHeaderParamName = Recording.GenerateAssetName("newOperationRequestHeaderParmName");
            string newOperationRequestHeaderParamDescr = Recording.GenerateAssetName("newOperationRequestHeaderParamDescr");
            bool newOperationRequestHeaderParamIsRequired = true;
            string newOperationRequestHeaderParamDefaultValue = Recording.GenerateAssetName("newOperationRequestHeaderParamDefaultValue");
            string newOperationRequestHeaderParamType = "string";

            string newOperationRequestParmName = Recording.GenerateAssetName("newOperationRequestParmName");
            string newOperationRequestParamDescr = Recording.GenerateAssetName("newOperationRequestParamDescr");
            bool newOperationRequestParamIsRequired = true;
            string newOperationRequestParamDefaultValue = Recording.GenerateAssetName("newOperationRequestParamDefaultValue");
            string newOperationRequestParamType = "string";

            string newOperationRequestRepresentationContentType = Recording.GenerateAssetName("newOperationRequestRepresentationContentType");
            string newOperationRequestRepresentationTypeName = "not null";

            string newOperationResponseDescription = Recording.GenerateAssetName("newOperationResponseDescription");
            int newOperationResponseStatusCode = 1980785443;
            string newOperationResponseRepresentationContentType = Recording.GenerateAssetName("newOperationResponseRepresentationContentType");

            var newOperation = new ApiOperationData
            {
                DisplayName = newOperationName,
                Method = newOperationMethod,
                UriTemplate = newperationUrlTemplate,
                Description = newOperationDescription,
                Request = new RequestContract
                {
                    Description = newOperationRequestDescription,
                    Headers = {
                            new ParameterContract(newOperationRequestHeaderParamName, newOperationRequestHeaderParamType)
                            {
                                Description = newOperationRequestHeaderParamDescr,
                                IsRequired = newOperationRequestHeaderParamIsRequired,
                                DefaultValue = newOperationRequestHeaderParamDefaultValue,
                                Values = {newOperationRequestHeaderParamDefaultValue, "1", "2", "3"},
                                TypeName = newOperationRequestRepresentationTypeName
                            }
                        },
                    QueryParameters = {
                            new ParameterContract(newOperationRequestParmName, newOperationRequestParamType)
                            {
                                Description = newOperationRequestParamDescr,
                                IsRequired = newOperationRequestParamIsRequired,
                                DefaultValue = newOperationRequestParamDefaultValue,
                                Values = {newOperationRequestParamDefaultValue, "1", "2", "3"},
                                TypeName = newOperationRequestRepresentationTypeName
                            }
                        },
                    Representations =
                            {
                            new RepresentationContract(newOperationRequestRepresentationContentType)
                            {
                                Examples = {
                                    ["default"] = new ParameterExampleContract
                                    {
                                        Description = "My default request example",
                                        ExternalValue = "https://contoso.com",
                                        Summary = "Just an example",
                                        Value = new BinaryData("default")
                                    }
                                }
                            }
                        }
                },
                Responses = {
                        new ResponseContract(newOperationResponseStatusCode)
                        {
                            Description = newOperationResponseDescription,
                            Representations = {
                                new RepresentationContract (newOperationResponseRepresentationContentType)
                                {
                                    Examples = {
                                        ["default"] = new ParameterExampleContract
                                        {
                                            Description = "My default request example",
                                            ExternalValue = "https://contoso.com",
                                            Summary = "Just an example",
                                            Value = new BinaryData("default")
                                        }
                                    }
                                }
                            }
                        }
                 }
            };

            var createResponse = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, newOperationId, newOperation)).Value;
            Assert.NotNull(createResponse);
            var apiOperationResponse = (await collection.GetAsync(newOperationId));
            Assert.NotNull(apiOperationResponse);
        }
    }
}

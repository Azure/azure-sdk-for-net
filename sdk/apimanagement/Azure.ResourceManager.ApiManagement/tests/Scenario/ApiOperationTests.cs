// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiOperationTests : ApiManagementManagementTestBase
    {
        public ApiOperationTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Standard, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var list = await ApiServiceResource.GetApis().GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(list.Count, 1);
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
                    Representations = { new RepresentationContract("application/json") }
                },
                Responses = {
                        new ResponseContract(newOperationResponseStatusCode)
                        {
                            Description = newOperationResponseDescription,
                            Representations = {
                                new RepresentationContract ("application/xml"),
                                new RepresentationContract ("application/json")
                            }
                        }
                 }
            };

            var createResponse = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, newOperationId, newOperation)).Value;
            Assert.NotNull(createResponse);
            var apiOperationResponse = (await collection.GetAsync(newOperationId)).Value;
            Assert.NotNull(apiOperationResponse);
            Assert.AreEqual(newOperationId, apiOperationResponse.Data.Name);

            // Get the Api Operation Etag
            var operationTag = (await apiOperationResponse.GetEntityTagAsync()).Value;
            Assert.NotNull(operationTag);

            // Patch the operation
            string patchedName = Recording.GenerateAssetName("patchedName");
            string patchedDescription = Recording.GenerateAssetName("patchedDescription");
            string patchedMethod = "HEAD";
            var patchOperation = new ApiOperationPatch()
            {
                DisplayName = patchedName,
                Description = patchedDescription,
                Method = patchedMethod,
            };
            getResponse = (await apiOperationResponse.UpdateAsync(ETag.All, patchOperation)).Value;
            Assert.NotNull(getResponse);
            Assert.AreEqual(getResponse.Data.Method, patchedMethod);

            // Delete the operation
            await apiOperationResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var exsits = (await collection.ExistsAsync(newOperationId)).Value;
            Assert.IsFalse(exsits);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class PolicyTests : ApiManagementManagementTestBase
    {
        public PolicyTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        protected const string ApiValid =
            @"<policies>
	            <inbound>
		            <set-header name=""x-sdk-call"" exists-action=""append"">
			            <value>true</value>
		            </set-header>
		            <base />
	            </inbound>
	            <backend>
		            <base />
	            </backend>
	            <outbound>
		            <base />
	            </outbound>
            </policies>";

        public const string OperationValid =
            @"<policies>
	            <inbound>
	                <rewrite-uri template=""/resource"" />
		            <base />
	            </inbound>
	            <outbound>
		            <base />
	            </outbound>
	            <backend>
		            <base />
	            </backend>
            </policies>";

        protected const string ProductValid =
                @"<policies>
                    <inbound>
                        <rate-limit calls=""5"" renewal-period=""60"" />
                        <quota calls=""100"" renewal-period=""604800"" />
                        <base />
                    </inbound>
                    <backend>
		                <base />
                    </backend>
                    <outbound>
                        <base />
                    </outbound>
                </policies>";

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

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
            var collection = ApiServiceResource.GetApiManagementPolicies();

            // test tenant policy
            var globalPolicy = (await collection.GetAsync("policy")).Value;

            // set policy
            var policyDoc = XDocument.Parse(globalPolicy.Data.Value);
            PolicyContractData policyContract = null;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                policyContract = new PolicyContractData()
                {
                    Value = policyDoc.ToString()
                };
            }
            else
            {
                policyContract = new PolicyContractData()
                {
                    Value = policyDoc.ToString().Replace("\n", "\r\n")
                };
            }

            var globalPolicyResponse = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, "policy", policyContract)).Value;
            Assert.NotNull(globalPolicyResponse);

            // get policy to check it was added
            var getPolicyResponse = (await collection.GetAsync("policy", PolicyExportFormat.Xml)).Value;

            Assert.NotNull(getPolicyResponse);
            Assert.NotNull(getPolicyResponse.Data.Value);

            // remove policy
            await getPolicyResponse.DeleteAsync(WaitUntil.Completed, ETag.All);

            // get policy to check it was removed
            var resultFalse = (await collection.ExistsAsync("policy")).Value;
            Assert.IsFalse(resultFalse);

            await collection.CreateOrUpdateAsync(WaitUntil.Completed, "policy", policyContract);

            // test api policy

            // there should be 'Echo API' with no policy

            var getApiResponse = await ApiServiceResource.GetApis().GetAllAsync().ToEnumerableAsync();

            var api = getApiResponse.Single();

            var apiPolicyCollection = api.GetApiPolicies();
            var listResult = await apiPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(listResult);

            // set policy
            policyDoc = XDocument.Parse(ApiValid);
            PolicyContractData data = null;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                data = new PolicyContractData()
                {
                    Value = policyDoc.ToString()
                };
            }
            else
            {
                data = new PolicyContractData()
                {
                    Value = policyDoc.ToString().Replace("\n", "\r\n")
                };
            }

            var setResponse = (await apiPolicyCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "policy",
                data
                )).Value;

            Assert.NotNull(setResponse);

            // get policy to check it was added
            var getApiPolicy = (await apiPolicyCollection.GetAsync("policy")).Value;

            Assert.NotNull(getApiPolicy);
            Assert.NotNull(getApiPolicy.Data.Value);

            // get policy in a blob link
            var getApiPolicyRawXml = (await apiPolicyCollection.GetAsync("policy", PolicyExportFormat.RawXml)).Value;

            Assert.NotNull(getApiPolicyRawXml);
            Assert.AreEqual(PolicyContentFormat.RawXml, getApiPolicyRawXml.Data.Format);
            Assert.NotNull(getApiPolicyRawXml.Data.Value);

            // remove policy
            await getApiPolicy.DeleteAsync(WaitUntil.Completed, ETag.All);
            resultFalse = (await apiPolicyCollection.ExistsAsync("policy")).Value;
            Assert.IsFalse(resultFalse);

            // test api operation policy
            var getOperationResponse = await api.GetApiOperations().GetAllAsync().ToEnumerableAsync();

            var operation = getOperationResponse.First(op => op.Data.DisplayName.Equals("Modify Resource", StringComparison.OrdinalIgnoreCase));

            var operationPolicyCollection = operation.GetApiOperationPolicies();
            var listResult2 = await operationPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(listResult2);

            // set policy
            policyDoc = XDocument.Parse(OperationValid);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                data = new PolicyContractData()
                {
                    Value = policyDoc.ToString()
                };
            }
            else
            {
                data = new PolicyContractData()
                {
                    Value = policyDoc.ToString().Replace("\n", "\r\n")
                };
            }

            var setResponse2 = (await operationPolicyCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "policy",
                data,
                ETag.All)).Value;

            Assert.NotNull(setResponse2);

            // get policy to check it was added
            var getOperationPolicy = (await operationPolicyCollection.GetAsync("policy", PolicyExportFormat.Xml)).Value;

            Assert.NotNull(getOperationPolicy);
            Assert.AreEqual(PolicyContentFormat.Xml, getOperationPolicy.Data.Format);
            Assert.NotNull(getOperationPolicy.Data.Value);

            // remove policy
            await getOperationPolicy.DeleteAsync(WaitUntil.Completed, ETag.All);

            resultFalse = (await operationPolicyCollection.ExistsAsync("policy")).Value;
            Assert.IsFalse(resultFalse);

            // test product policy

            // get 'Unlimited' product
            var productCollection = ApiServiceResource.GetApiManagementProducts();
            var productList = await productCollection.GetAllAsync().ToEnumerableAsync();
            var product = productList.FirstOrDefault(item => item.Data.Name.Equals("unlimited"));
            var productPolicyCollection = product.GetApiManagementProductPolicies();

            // get product policy
            var listResult3 = await productPolicyCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(listResult3);

            // set policy
            policyDoc = XDocument.Parse(ProductValid);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                data = new PolicyContractData()
                {
                    Value = policyDoc.ToString()
                };
            }
            else
            {
                data = new PolicyContractData()
                {
                    Value = policyDoc.ToString().Replace("\n", "\r\n")
                };
            }

            var setResponse3 = (await productPolicyCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "policy",
                data,
                ETag.All)).Value;

            Assert.NotNull(setResponse3);

            // get policy to check it was added
            var getProductPolicy = (await productPolicyCollection.GetAsync("policy")).Value;

            Assert.NotNull(getProductPolicy);
            Assert.NotNull(getProductPolicy.Data.Value);

            // get policy in a blob link=
            var getProductPolicyXml = (await productPolicyCollection.GetAsync("policy", PolicyExportFormat.Xml)).Value;

            Assert.NotNull(getProductPolicyXml);
            Assert.AreEqual(PolicyContentFormat.Xml, getProductPolicyXml.Data.Format);
            Assert.NotNull(getProductPolicyXml.Data.Value);

            // remove policy
            await getProductPolicy.DeleteAsync(WaitUntil.Completed, ETag.All);

            resultFalse = (await productPolicyCollection.ExistsAsync("policy")).Value;
            Assert.IsFalse(resultFalse);
        }
    }
}

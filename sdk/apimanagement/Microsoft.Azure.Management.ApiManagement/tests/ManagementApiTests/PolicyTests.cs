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
using System;
using System.Xml.Linq;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class PolicyTests : TestBase
    {
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

        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // test tenant policy
                var globalPolicy = testBase.client.Policy.Get(testBase.rgName, testBase.serviceName);

                // set policy
                var policyDoc = XDocument.Parse(globalPolicy.Value);

                var policyContract = new PolicyContract(policyDoc.ToString());

                try
                {
                    var globalPolicyResponse = testBase.client.Policy.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        policyContract);
                    Assert.NotNull(globalPolicyResponse);

                    // get policy to check it was added
                    var getPolicyResponse = await testBase.client.Policy.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        PolicyExportFormat.Xml);

                    Assert.NotNull(getPolicyResponse);
                    Assert.NotNull(getPolicyResponse.Value);

                    // get the policy etag
                    var globalPolicyTag = await testBase.client.Policy.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName);
                    Assert.NotNull(globalPolicyTag);
                    Assert.NotNull(globalPolicyTag.ETag);

                    // remove policy
                    testBase.client.Policy.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        globalPolicyTag.ETag);

                    // get policy to check it was removed
                    try
                    {
                        testBase.client.Policy.Get(
                            testBase.rgName,
                            testBase.serviceName);
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.Policy.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        policyContract);
                }

                // test api policy

                // there should be 'Echo API' with no policy

                var getApiResponse = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                var api = getApiResponse.Single();

                try
                {
                    testBase.client.ApiPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Id);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // set policy
                policyDoc = XDocument.Parse(ApiValid);

                var setResponse = testBase.client.ApiPolicy.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    new PolicyContract(policyDoc.ToString()),
                    "*");

                Assert.NotNull(setResponse);

                // get policy to check it was added
                var getApiPolicy = await testBase.client.ApiPolicy.GetAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name);

                Assert.NotNull(getApiPolicy);
                Assert.NotNull(getApiPolicy.Value);

                // get policy in a blob link                
                var getApiPolicyRawXml = await testBase.client.ApiPolicy.GetAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    PolicyExportFormat.Rawxml);

                Assert.NotNull(getApiPolicyRawXml);
                Assert.Equal(PolicyExportFormat.Rawxml, getApiPolicyRawXml.Format);
                Assert.NotNull(getApiPolicyRawXml.Value);

                // get the api policy tag
                var apiPolicyTag = await testBase.client.ApiPolicy.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name);
                Assert.NotNull(apiPolicyTag);
                Assert.NotNull(apiPolicyTag.ETag);

                // remove policy
                testBase.client.ApiPolicy.Delete(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    apiPolicyTag.ETag);

                // get policy to check it was removed
                try
                {
                    testBase.client.ApiPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // test api operation policy
                var getOperationResponse = testBase.client.ApiOperation.ListByApi(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    null);

                var operation = getOperationResponse.First(op => op.DisplayName.Equals("Modify Resource", StringComparison.OrdinalIgnoreCase));

                try
                {
                    testBase.client.ApiOperationPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        operation.Name);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // set policy
                policyDoc = XDocument.Parse(OperationValid);

                setResponse = testBase.client.ApiOperationPolicy.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    operation.Name,
                    new PolicyContract(policyDoc.ToString()),
                    "*");

                Assert.NotNull(setResponse);

                // get policy to check it was added
                var getOperationPolicy = await testBase.client.ApiOperationPolicy.GetAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    operation.Name,
                    PolicyExportFormat.Xml);

                Assert.NotNull(getOperationPolicy);
                Assert.Equal(PolicyExportFormat.Xml, getOperationPolicy.Format);
                Assert.NotNull(getOperationPolicy.Value);

                // get operation policy tag
                var operationPolicyTag = await testBase.client.ApiOperationPolicy.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    operation.Name);
                Assert.NotNull(operationPolicyTag);
                Assert.NotNull(operationPolicyTag.ETag);

                // remove policy
                testBase.client.ApiOperationPolicy.Delete(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    operation.Name,
                    operationPolicyTag.ETag);

                // get policy to check it was removed
                try
                {
                    testBase.client.ApiOperationPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        operation.Name);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }


                // test product policy

                // get 'Unlimited' product
                var getProductResponse = testBase.client.Product.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<ProductContract>
                    {
                        Filter = "name eq 'Unlimited'"
                    });

                var product = getProductResponse.Single();

                // get product policy
                try
                {
                    testBase.client.ProductPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        product.Name);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // set policy
                policyDoc = XDocument.Parse(ProductValid);

                setResponse = testBase.client.ProductPolicy.CreateOrUpdate(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    new PolicyContract(value: policyDoc.ToString()));

                Assert.NotNull(setResponse);

                // get policy to check it was added
                var getProductPolicy = await testBase.client.ProductPolicy.GetAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name);

                Assert.NotNull(getProductPolicy);
                Assert.NotNull(getProductPolicy.Value);

                // get policy in a blob link                
                var getProductPolicyXml = await testBase.client.ProductPolicy.GetAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    PolicyExportFormat.Xml);

                Assert.NotNull(getProductPolicyXml);
                Assert.Equal(PolicyExportFormat.Xml, getProductPolicyXml.Format);
                Assert.NotNull(getProductPolicyXml.Value);

                // get product policy tag
                var productPolicyTag = await testBase.client.ProductPolicy.GetEntityTagAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name);
                Assert.NotNull(productPolicyTag);
                Assert.NotNull(productPolicyTag.ETag);

                // remove policy
                testBase.client.ProductPolicy.Delete(
                    testBase.rgName,
                    testBase.serviceName,
                    product.Name,
                    productPolicyTag.ETag);

                // get policy to check it was removed
                try
                {
                    testBase.client.ProductPolicy.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        product.Name);
                }
                catch (ErrorResponseException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }
    }
}

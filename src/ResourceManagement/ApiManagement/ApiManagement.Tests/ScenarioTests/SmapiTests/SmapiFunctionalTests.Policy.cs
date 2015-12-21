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
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using global::ApiManagement.Tests;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        public const string TenantValid =
                @"<policies>
                    <inbound>
                        <find-and-replace from=""aaa"" to=""BBB"" />
                        <set-header name=""ETag"" exists-action=""skip"">
                            <value>bbyby</value>
                            <!-- for multiple headers with the same name add additional value elements -->
                        </set-header>
                        <set-query-parameter name=""additional"" exists-action=""append"">
                            <value>xxbbcczc</value>
                            <!-- for multiple parameters with the same name add additional value elements -->
                        </set-query-parameter>
                        <cross-domain />
                    </inbound>
                    <outbound />
                </policies>";

        public const string ProductValid =
                @"<policies>
                    <inbound>
                        <rate-limit calls=""5"" renewal-period=""60"" />
                        <quota calls=""100"" renewal-period=""604800"" />
                        <base />
                    </inbound>
                    <outbound>
                        <base />
                    </outbound>
                </policies>";

        public const string ApiValid =
            @"<policies>
                <inbound>
                    <base />
                    <cache-lookup vary-by-developer=""false"" vary-by-developer-groups=""false"" downstream-caching-type=""none"">
                    <vary-by-query-parameter>version</vary-by-query-parameter>
                    <vary-by-header>Accept</vary-by-header>
                    <vary-by-header>Accept-Charset</vary-by-header>
                    </cache-lookup>
                </inbound>
                <outbound>
                    <cache-store duration=""10"" />
                    <base />
                </outbound>
            </policies>";

        public const string OperationValid =
                @"<policies>
                    <inbound>
                        <base />
                        <rewrite-uri template=""/resource"" />
                    </inbound>
                    <outbound>
                        <base />
                    </outbound>
                </policies>";

        [Fact]
        public void PolicyCreateGetUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "PolicyCreateGetUpdateDelete");

            try
            {
                const string format = "application/vnd.ms-azure-apim.policy+xml";

                // test tenant policy

                try
                {
                    ApiManagementClient.TenantPolicy.Get(ResourceGroupName, ApiManagementServiceName, format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // set policy
                var policyDoc = XDocument.Parse(TenantValid);

                var setResponse = ApiManagementClient.TenantPolicy.Set(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    format,
                    policyDoc.ToStream(),
                    "*");

                Assert.NotNull(setResponse);

                // get policy to check it was added
                var getPolicyResponse = ApiManagementClient.TenantPolicy.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    format);

                Assert.NotNull(getPolicyResponse);
                Assert.NotNull(getPolicyResponse.PolicyBytes);

                var stream = new MemoryStream(getPolicyResponse.PolicyBytes);
                var getXdoc = XDocument.Load(stream);

                Assert.Equal(policyDoc.Root.Value, getXdoc.Root.Value);

                // remove policy
                ApiManagementClient.TenantPolicy.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    getPolicyResponse.ETag);

                // get policy to check it was removed
                try
                {
                    ApiManagementClient.TenantPolicy.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // test api policy

                // there should be 'Echo API' with no policy

                var getApiResponse = ApiManagementClient.Apis.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                var api = getApiResponse.Result.Values.Single();

                try
                {
                    ApiManagementClient.ApiPolicy.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        api.Id,
                        format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // set policy
                policyDoc = XDocument.Parse(ApiValid);

                setResponse = ApiManagementClient.ApiPolicy.Set(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    format,
                    policyDoc.ToStream(),
                    "*");

                Assert.NotNull(setResponse);

                // get policy to check it was added
                getPolicyResponse = ApiManagementClient.ApiPolicy.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    format);

                Assert.NotNull(getPolicyResponse);
                Assert.NotNull(getPolicyResponse.PolicyBytes);

                stream = new MemoryStream(getPolicyResponse.PolicyBytes);
                getXdoc = XDocument.Load(stream);

                Assert.Equal(policyDoc.Root.Value, getXdoc.Root.Value);

                // remove policy
                ApiManagementClient.ApiPolicy.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    getPolicyResponse.ETag);

                // get policy to check it was removed
                try
                {
                    ApiManagementClient.ApiPolicy.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        api.Id,
                        format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // test api operation policy
                var getOperationResponse = ApiManagementClient.ApiOperations.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    null);

                var operation = getOperationResponse.Result.Values.First(op => op.Name.Equals("Modify Resource", StringComparison.OrdinalIgnoreCase));

                try
                {
                    ApiManagementClient.ApiOperationPolicy.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        operation.ApiId,
                        operation.OperationId,
                        format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // set policy
                policyDoc = XDocument.Parse(OperationValid);

                setResponse = ApiManagementClient.ApiOperationPolicy.Set(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    operation.ApiId,
                    operation.OperationId,
                    format,
                    policyDoc.ToStream(),
                    "*");

                Assert.NotNull(setResponse);

                // get policy to check it was added
                getPolicyResponse = ApiManagementClient.ApiOperationPolicy.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    operation.ApiId,
                    operation.OperationId,
                    format);

                Assert.NotNull(getPolicyResponse);
                Assert.NotNull(getPolicyResponse.PolicyBytes);

                stream = new MemoryStream(getPolicyResponse.PolicyBytes);
                getXdoc = XDocument.Load(stream);

                Assert.Equal(policyDoc.Root.Value, getXdoc.Root.Value);

                // remove policy
                ApiManagementClient.ApiOperationPolicy.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    operation.ApiId,
                    operation.OperationId,
                    getPolicyResponse.ETag);

                // get policy to check it was removed
                try
                {
                    ApiManagementClient.ApiOperationPolicy.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        operation.ApiId,
                        operation.OperationId,
                        format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }


                // test product policy

                // get 'Unlimited' product
                var getProductResponse = ApiManagementClient.Products.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters
                    {
                        Filter = "name eq 'Unlimited'"
                    });

                var product = getProductResponse.Result.Values.Single();

                // get product policy
                try
                {
                    ApiManagementClient.ProductPolicy.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        product.Id,
                        format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // set policy
                policyDoc = XDocument.Parse(ProductValid);

                setResponse = ApiManagementClient.ProductPolicy.Set(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    format,
                    policyDoc.ToStream(),
                    "*");

                Assert.NotNull(setResponse);

                // get policy to check it was added
                getPolicyResponse = ApiManagementClient.ProductPolicy.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    format);

                Assert.NotNull(getPolicyResponse);
                Assert.NotNull(getPolicyResponse.PolicyBytes);

                stream = new MemoryStream(getPolicyResponse.PolicyBytes);
                getXdoc = XDocument.Load(stream);

                Assert.Equal(policyDoc.Root.Value, getXdoc.Root.Value);

                // remove policy
                ApiManagementClient.ProductPolicy.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    getPolicyResponse.ETag);

                // get policy to check it was removed
                try
                {
                    ApiManagementClient.ProductPolicy.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        product.Id,
                        format);
                }
                catch (Hyak.Common.CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}
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
    using System.Net;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void OpenIdConnectProviderCreateUpdateDeleteList()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "OpenIdConnectProviderCreateUpdateDeleteList");

            try
            {
                // create non Secret property
                string openIdNoSecret = TestUtilities.GenerateName("openId");
                string openIdProviderName = TestUtilities.GenerateName("openIdName");
                string metadataEndpoint = GetHttpsUrl();
                string clientId = TestUtilities.GenerateName("clientId");
                var openIdConnectCreateParameters = new OpenidConnectProviderCreateContract(openIdProviderName,
                    metadataEndpoint, clientId);

                var createResponse = ApiManagementClient.OpenIdConnectProviders.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    openIdNoSecret,
                    openIdConnectCreateParameters);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                var getResponse = ApiManagementClient.OpenIdConnectProviders.Get(ResourceGroupName, ApiManagementServiceName, openIdNoSecret);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal(openIdProviderName, getResponse.Value.Name);
                Assert.Equal(metadataEndpoint, getResponse.Value.MetadataEndpoint);
                Assert.Equal(clientId, getResponse.Value.ClientId);
                Assert.Equal(openIdNoSecret, getResponse.Value.Id);
                Assert.Null(getResponse.Value.ClientSecret);
                Assert.Null(getResponse.Value.Description);

                // create a Secret property
                string openId2 = TestUtilities.GenerateName("openId");
                string openIdProviderName2 = TestUtilities.GenerateName("openIdName");
                string metadataEndpoint2 = GetHttpsUrl();
                string clientId2 = TestUtilities.GenerateName("clientId");
                string clientSecret = TestUtilities.GenerateName("clientSecret");
                var openIdConnectCreateParameters2 = new OpenidConnectProviderCreateContract(openIdProviderName2,
                    metadataEndpoint2, clientId2);
                openIdConnectCreateParameters2.ClientSecret = clientSecret;
                openIdConnectCreateParameters2.Description = TestUtilities.GenerateName("description");

                var createResponse2 = ApiManagementClient.OpenIdConnectProviders.Create(
                   ResourceGroupName,
                   ApiManagementServiceName,
                   openId2,
                   openIdConnectCreateParameters2);

                Assert.NotNull(createResponse2);
                Assert.Equal(HttpStatusCode.Created, createResponse2.StatusCode);

                // get to check it was created
                var getResponse2 = ApiManagementClient.OpenIdConnectProviders.Get(ResourceGroupName, ApiManagementServiceName, openId2);

                Assert.NotNull(getResponse2);
                Assert.NotNull(getResponse2.Value);

                Assert.Equal(openIdProviderName2, getResponse2.Value.Name);
                Assert.Equal(clientId2, getResponse2.Value.ClientId);
                Assert.Equal(metadataEndpoint2, getResponse2.Value.MetadataEndpoint);
                Assert.NotNull(getResponse2.Value.ClientSecret);
                Assert.Equal(clientSecret, getResponse2.Value.ClientSecret);
                Assert.NotNull(getResponse2.Value.Description);
                Assert.Equal(openId2, getResponse2.Value.Id);

                // list the openId Connect Providers
                var listResponse = ApiManagementClient.OpenIdConnectProviders.List(ResourceGroupName, ApiManagementServiceName, null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);

                // there should be atleast 2 openId connect Providers.
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.True(listResponse.Result.Values.Count >= 2);

                // list using Query
                listResponse = ApiManagementClient.OpenIdConnectProviders.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters { Top = 1 });

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.Equal(1, listResponse.Result.Values.Count);

                // delete a OpenId Connect Provider
                var deleteResponse = ApiManagementClient.OpenIdConnectProviders.Delete(ResourceGroupName, ApiManagementServiceName, openIdNoSecret, getResponse.ETag);
                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted openId Connect Provider to make sure it was deleted
                try
                {
                    ApiManagementClient.OpenIdConnectProviders.Get(ResourceGroupName, ApiManagementServiceName, openIdNoSecret);
                    throw new Exception("This code should not have been executed.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // patch the openId Connect Provider
                string updateMetadataEndpoint = GetHttpsUrl();
                string updatedClientId = TestUtilities.GenerateName("updatedClient");
                var patchResponse = ApiManagementClient.OpenIdConnectProviders.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    openId2,
                    new OpenidConnectProviderUpdateContract 
                    {
                        MetadataEndpoint = updateMetadataEndpoint,
                        ClientId = updatedClientId
                    },
                    getResponse2.ETag);

                Assert.NotNull(patchResponse);

                // get to check it was patched
                getResponse2 = ApiManagementClient.OpenIdConnectProviders.Get(ResourceGroupName, ApiManagementServiceName, openId2);

                Assert.NotNull(getResponse2);
                Assert.NotNull(getResponse2.Value);

                Assert.Equal(openIdProviderName2, getResponse2.Value.Name);
                Assert.Equal(updatedClientId, getResponse2.Value.ClientId);
                Assert.Equal(updateMetadataEndpoint, getResponse2.Value.MetadataEndpoint);
                Assert.Equal(clientSecret, getResponse2.Value.ClientSecret);
                Assert.NotNull(getResponse2.Value.Description);

                // delete the openId Connect Provider 
                deleteResponse = ApiManagementClient.OpenIdConnectProviders.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    openId2,
                    getResponse2.ETag);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted openId Connect Provider to make sure it was deleted
                try
                {
                    ApiManagementClient.OpenIdConnectProviders.Get(ResourceGroupName, ApiManagementServiceName, openId2);
                    throw new Exception("This code should not have been executed.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        static string GetHttpsUrl()
        {
            return "https://" + TestUtilities.GenerateName("provider") + "." + TestUtilities.GenerateName("endpoint");
        }
    }
}
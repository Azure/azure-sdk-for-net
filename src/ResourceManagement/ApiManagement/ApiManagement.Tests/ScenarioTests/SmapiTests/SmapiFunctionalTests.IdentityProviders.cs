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


using ApiManagement.Tests;

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.Net;
    using Hyak.Common;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void IdentityProviderCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "IdentityProviderCreateListUpdateDelete");

            try
            {
                // create facebook external identity provider
                string clientId = TestUtilities.GenerateName("clientId");
                string clientSecret = TestUtilities.GenerateName("clientSecret");

                var identityProviderCreateParameters = new IdentityProviderCreateParameters(clientId, clientSecret);

                var createResponse = ApiManagementClient.IdentityProvider.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    IdentityProviderTypeContract.Facebook.ToString("g"),
                    identityProviderCreateParameters);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                var getResponse = ApiManagementClient.IdentityProvider.Get(ResourceGroupName, ApiManagementServiceName, IdentityProviderTypeContract.Facebook.ToString("g"));

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.NotNull(getResponse.Value.ClientId);
                Assert.NotNull(getResponse.Value.ClientSecret);
                Assert.Equal(IdentityProviderTypeContract.Facebook, getResponse.Value.Type);

                var listIdentityProviders = ApiManagementClient.IdentityProvider.List(ResourceGroupName, ApiManagementServiceName, null);

                Assert.NotNull(listIdentityProviders);
                Assert.NotNull(listIdentityProviders.Result);

                // there should be one identity Provider
                Assert.True(listIdentityProviders.Result.Count >= 1);

                // patch identity provider
                string patchedSecret = TestUtilities.GenerateName("clientSecret");
                var patchResponse = ApiManagementClient.IdentityProvider.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    IdentityProviderTypeContract.Facebook.ToString("g"),
                    new IdentityProviderUpdateParameters
                    {
                        ClientSecret = patchedSecret
                    }, 
                    getResponse.ETag);

                Assert.NotNull(patchResponse);

                // get to check it was patched
                getResponse = ApiManagementClient.IdentityProvider.Get(ResourceGroupName, ApiManagementServiceName, IdentityProviderTypeContract.Facebook.ToString("g"));

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(IdentityProviderTypeContract.Facebook, getResponse.Value.Type);
                Assert.Equal(patchedSecret, getResponse.Value.ClientSecret);

                // delete the identity provider
                var deleteResponse = ApiManagementClient.IdentityProvider.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    IdentityProviderTypeContract.Facebook.ToString("g"),
                    getResponse.ETag);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted identity provider to make sure it was deleted
                try
                {
                    ApiManagementClient.IdentityProvider.Get(ResourceGroupName, ApiManagementServiceName, IdentityProviderTypeContract.Facebook.ToString("g"));
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
    }
}
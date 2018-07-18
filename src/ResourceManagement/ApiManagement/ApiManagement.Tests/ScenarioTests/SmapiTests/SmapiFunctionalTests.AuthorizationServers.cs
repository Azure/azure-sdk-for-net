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
    using System.Linq;
    using System.Net;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void AuthorizationServersCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "AuthorizationServersCreateListUpdateDelete");

            try
            {
                // list all server
                var listResponse = ApiManagementClient.AuthorizationServers.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(0, listResponse.Result.TotalCount);
                Assert.Equal(0, listResponse.Result.Values.Count);

                // create server
                string authsid = TestUtilities.GenerateName("authsid");
                try
                {
                    var oAuth2AuthorizationServerContract = new OAuth2AuthorizationServerContract()
                    {
                        Name = TestUtilities.GenerateName("authName"),
                        DefaultScope = TestUtilities.GenerateName("oauth2scope"),
                        AuthorizationEndpoint = "https://contoso.com/auth",
                        TokenEndpoint = "https://contoso.com/token",
                        ClientRegistrationEndpoint = "https://contoso.com/clients/reg",
                        GrantTypes = new[] {GrantTypesContract.AuthorizationCode, GrantTypesContract.Implicit, GrantTypesContract.ResourceOwnerPassword},
                        AuthorizationMethods = new[] {MethodContract.Post, MethodContract.Get},
                        BearerTokenSendingMethods = new[] {BearerTokenSendingMethodsContract.AuthorizationHeader, BearerTokenSendingMethodsContract.Query},
                        ClientId = TestUtilities.GenerateName("clientid"),
                        Description = TestUtilities.GenerateName("authdescription"),
                        ClientAuthenticationMethod = new[] {ClientAuthenticationMethodContract.Basic},
                        ClientSecret = TestUtilities.GenerateName("authclientsecret"),
                        ResourceOwnerPassword = TestUtilities.GenerateName("authresourceownerpwd"),
                        ResourceOwnerUsername = TestUtilities.GenerateName("authresourceownerusername"),
                        SupportState = true,
                        TokenBodyParameters = new[]
                        {
                            new TokenBodyParameterContract
                            {
                                Name = TestUtilities.GenerateName("tokenname"),
                                Value = TestUtilities.GenerateName("tokenvalue")
                            }
                        }
                    };
                    var createParameters = new AuthorizationServerCreateOrUpdateParameters(oAuth2AuthorizationServerContract);
                    var createResponse = ApiManagementClient.AuthorizationServers.Create(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        authsid,
                        createParameters);

                    Assert.NotNull(createResponse);

                    // get to check is was created
                    var getResponse = ApiManagementClient.AuthorizationServers.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        authsid);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.ETag);
                    Assert.NotNull(getResponse.Value);

                    Assert.Equal(authsid, getResponse.Value.Id);
                    Assert.Equal(oAuth2AuthorizationServerContract.Name, getResponse.Value.Name);
                    Assert.Equal(oAuth2AuthorizationServerContract.Description, getResponse.Value.Description);
                    Assert.Equal(oAuth2AuthorizationServerContract.DefaultScope, getResponse.Value.DefaultScope);
                    Assert.Equal(oAuth2AuthorizationServerContract.AuthorizationEndpoint, getResponse.Value.AuthorizationEndpoint);
                    Assert.Equal(oAuth2AuthorizationServerContract.TokenEndpoint, getResponse.Value.TokenEndpoint);
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientId, getResponse.Value.ClientId);
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientRegistrationEndpoint, getResponse.Value.ClientRegistrationEndpoint);
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientSecret, getResponse.Value.ClientSecret);
                    Assert.Equal(oAuth2AuthorizationServerContract.ResourceOwnerPassword, getResponse.Value.ResourceOwnerPassword);
                    Assert.Equal(oAuth2AuthorizationServerContract.ResourceOwnerUsername, getResponse.Value.ResourceOwnerUsername);
                    Assert.Equal(oAuth2AuthorizationServerContract.GrantTypes.Count, getResponse.Value.GrantTypes.Count);
                    Assert.True(getResponse.Value.GrantTypes.All(gt => oAuth2AuthorizationServerContract.GrantTypes.Contains(gt)));
                    Assert.Equal(oAuth2AuthorizationServerContract.AuthorizationMethods.Count, getResponse.Value.AuthorizationMethods.Count);
                    Assert.True(getResponse.Value.AuthorizationMethods.All(gt => oAuth2AuthorizationServerContract.AuthorizationMethods.Contains(gt)));
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientAuthenticationMethod.Count, getResponse.Value.ClientAuthenticationMethod.Count);
                    Assert.True(getResponse.Value.ClientAuthenticationMethod.All(gt => oAuth2AuthorizationServerContract.ClientAuthenticationMethod.Contains(gt)));
                    Assert.Equal(oAuth2AuthorizationServerContract.SupportState, getResponse.Value.SupportState);
                    Assert.Equal(oAuth2AuthorizationServerContract.TokenBodyParameters.Count, getResponse.Value.TokenBodyParameters.Count);
                    Assert.True(getResponse.Value.TokenBodyParameters.All(p => oAuth2AuthorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))));

                    // list again
                    listResponse = ApiManagementClient.AuthorizationServers.List(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        null);

                    Assert.NotNull(listResponse);
                    Assert.NotNull(listResponse.Result);
                    Assert.NotNull(listResponse.Result.Values);
                    Assert.Equal(1, listResponse.Result.TotalCount);
                    Assert.Equal(1, listResponse.Result.Values.Count);

                    // update
                    oAuth2AuthorizationServerContract = new OAuth2AuthorizationServerContract
                    {
                        Name = TestUtilities.GenerateName("authName"),
                        DefaultScope = TestUtilities.GenerateName("oauth2scope"),
                        AuthorizationEndpoint = "https://contoso.com/auth1",
                        TokenEndpoint = "https://contoso.com/token1",
                        ClientRegistrationEndpoint = "https://contoso.com/clients/reg1",
                        GrantTypes = new[] {GrantTypesContract.AuthorizationCode, GrantTypesContract.ResourceOwnerPassword},
                        AuthorizationMethods = new[] {MethodContract.Get},
                        BearerTokenSendingMethods = new[] {BearerTokenSendingMethodsContract.AuthorizationHeader},
                        ClientId = TestUtilities.GenerateName("clientid"),
                        Description = TestUtilities.GenerateName("authdescription"),
                        ClientAuthenticationMethod = new[] {ClientAuthenticationMethodContract.Basic},
                        ClientSecret = TestUtilities.GenerateName("authclientsecret"),
                        ResourceOwnerPassword = TestUtilities.GenerateName("authresourceownerpwd"),
                        ResourceOwnerUsername = TestUtilities.GenerateName("authresourceownerusername"),
                        SupportState = true,
                        TokenBodyParameters = new[]
                        {
                            new TokenBodyParameterContract
                            {
                                Name = TestUtilities.GenerateName("tokenname"),
                                Value = TestUtilities.GenerateName("tokenvalue")
                            }
                        }
                    };
                    var updateParameters = new AuthorizationServerCreateOrUpdateParameters(oAuth2AuthorizationServerContract);
                    var updateResponse = ApiManagementClient.AuthorizationServers.Update(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        authsid,
                        updateParameters,
                        getResponse.ETag);

                    Assert.NotNull(updateResponse);

                    // get to check is was updated
                    getResponse = ApiManagementClient.AuthorizationServers.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        authsid);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.ETag);
                    Assert.NotNull(getResponse.Value);

                    Assert.Equal(authsid, getResponse.Value.Id);
                    Assert.Equal(oAuth2AuthorizationServerContract.Name, getResponse.Value.Name);
                    Assert.Equal(oAuth2AuthorizationServerContract.Description, getResponse.Value.Description);
                    Assert.Equal(oAuth2AuthorizationServerContract.DefaultScope, getResponse.Value.DefaultScope);
                    Assert.Equal(oAuth2AuthorizationServerContract.AuthorizationEndpoint, getResponse.Value.AuthorizationEndpoint);
                    Assert.Equal(oAuth2AuthorizationServerContract.TokenEndpoint, getResponse.Value.TokenEndpoint);
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientId, getResponse.Value.ClientId);
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientRegistrationEndpoint, getResponse.Value.ClientRegistrationEndpoint);
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientSecret, getResponse.Value.ClientSecret);
                    Assert.Equal(oAuth2AuthorizationServerContract.ResourceOwnerPassword, getResponse.Value.ResourceOwnerPassword);
                    Assert.Equal(oAuth2AuthorizationServerContract.ResourceOwnerUsername, getResponse.Value.ResourceOwnerUsername);
                    Assert.Equal(oAuth2AuthorizationServerContract.GrantTypes.Count, getResponse.Value.GrantTypes.Count);
                    Assert.True(getResponse.Value.GrantTypes.All(gt => oAuth2AuthorizationServerContract.GrantTypes.Contains(gt)));
                    Assert.Equal(oAuth2AuthorizationServerContract.AuthorizationMethods.Count, getResponse.Value.AuthorizationMethods.Count);
                    Assert.True(getResponse.Value.AuthorizationMethods.All(gt => oAuth2AuthorizationServerContract.AuthorizationMethods.Contains(gt)));
                    Assert.Equal(oAuth2AuthorizationServerContract.ClientAuthenticationMethod.Count, getResponse.Value.ClientAuthenticationMethod.Count);
                    Assert.True(getResponse.Value.ClientAuthenticationMethod.All(gt => oAuth2AuthorizationServerContract.ClientAuthenticationMethod.Contains(gt)));
                    Assert.Equal(oAuth2AuthorizationServerContract.SupportState, getResponse.Value.SupportState);
                    Assert.Equal(oAuth2AuthorizationServerContract.TokenBodyParameters.Count, getResponse.Value.TokenBodyParameters.Count);
                    Assert.True(getResponse.Value.TokenBodyParameters.All(p => oAuth2AuthorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))));
                }
                finally
                {
                    // delete
                    ApiManagementClient.AuthorizationServers.Delete(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        authsid,
                        "*");

                    // get to check is was deleted
                    try
                    {
                        ApiManagementClient.AuthorizationServers.Get(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            authsid);

                        throw new Exception("This code should not have been executed.");
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        } 
    }
}
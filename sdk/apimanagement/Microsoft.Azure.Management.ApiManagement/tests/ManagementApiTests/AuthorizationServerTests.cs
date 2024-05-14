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
using System.Collections.Generic;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class AuthorizationServerTests : TestBase
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list all server
                var listResponse = testBase.client.AuthorizationServer.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.Empty(listResponse);

                // create server
                string authsid = TestUtilities.GenerateName("authsid");
                try
                {
                    var authorizationServerContract = new AuthorizationServerContract
                    {
                        DisplayName = TestUtilities.GenerateName("authName"),
                        DefaultScope = TestUtilities.GenerateName("oauth2scope"),
                        AuthorizationEndpoint = "https://contoso.com/auth",
                        TokenEndpoint = "https://contoso.com/token",
                        ClientRegistrationEndpoint = "https://contoso.com/clients/reg",
                        GrantTypes = new List<string> { GrantType.AuthorizationCode, GrantType.Implicit, GrantType.ResourceOwnerPassword },
                        AuthorizationMethods = new List<AuthorizationMethod?> { AuthorizationMethod.POST, AuthorizationMethod.GET },
                        BearerTokenSendingMethods = new List<string> { BearerTokenSendingMethod.AuthorizationHeader, BearerTokenSendingMethod.Query },
                        ClientId = TestUtilities.GenerateName("clientid"),
                        Description = TestUtilities.GenerateName("authdescription"),
                        ClientAuthenticationMethod = new List<string> { ClientAuthenticationMethod.Basic },
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

                    var createResponse = testBase.client.AuthorizationServer.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        authsid,
                        authorizationServerContract);

                    Assert.NotNull(createResponse);

                    // get to check is was created
                    var getResponse = await testBase.client.AuthorizationServer.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authsid);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Headers.ETag);
                    Assert.NotNull(getResponse.Body);

                    Assert.Equal(authsid, getResponse.Body.Name);
                    Assert.Equal(authorizationServerContract.DisplayName, getResponse.Body.DisplayName);
                    Assert.Equal(authorizationServerContract.Description, getResponse.Body.Description);
                    Assert.Equal(authorizationServerContract.DefaultScope, getResponse.Body.DefaultScope);
                    Assert.Equal(authorizationServerContract.AuthorizationEndpoint, getResponse.Body.AuthorizationEndpoint);
                    Assert.Equal(authorizationServerContract.TokenEndpoint, getResponse.Body.TokenEndpoint);
                    Assert.Equal(authorizationServerContract.ClientId, getResponse.Body.ClientId);
                    Assert.Equal(authorizationServerContract.ClientRegistrationEndpoint, getResponse.Body.ClientRegistrationEndpoint);
                    Assert.Null(getResponse.Body.ClientSecret);
                    Assert.Null(getResponse.Body.ResourceOwnerPassword);
                    Assert.Null(getResponse.Body.ResourceOwnerUsername);
                    Assert.Equal(authorizationServerContract.GrantTypes.Count, getResponse.Body.GrantTypes.Count);
                    Assert.True(getResponse.Body.GrantTypes.All(gt => authorizationServerContract.GrantTypes.Contains(gt)));
                    Assert.Equal(authorizationServerContract.AuthorizationMethods.Count, getResponse.Body.AuthorizationMethods.Count);
                    Assert.True(getResponse.Body.AuthorizationMethods.All(gt => authorizationServerContract.AuthorizationMethods.Contains(gt)));
                    Assert.Equal(authorizationServerContract.ClientAuthenticationMethod.Count, getResponse.Body.ClientAuthenticationMethod.Count);
                    Assert.True(getResponse.Body.ClientAuthenticationMethod.All(gt => authorizationServerContract.ClientAuthenticationMethod.Contains(gt)));
                    Assert.Equal(authorizationServerContract.SupportState, getResponse.Body.SupportState);
                    Assert.Equal(authorizationServerContract.TokenBodyParameters.Count, getResponse.Body.TokenBodyParameters.Count);
                    Assert.True(getResponse.Body.TokenBodyParameters.All(p => authorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))));

                    // check default values for UseInTestConsole and UseInApiDocumentation
                    Assert.True(getResponse.Body.UseInTestConsole);
                    Assert.False(getResponse.Body.UseInApiDocumentation);


                    var secretsResponse = await testBase.client.AuthorizationServer.ListSecretsAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authsid);
                    Assert.Equal(authorizationServerContract.ClientSecret, secretsResponse.ClientSecret);
                    Assert.Equal(authorizationServerContract.ResourceOwnerUsername, secretsResponse.ResourceOwnerUsername);
                    Assert.Equal(authorizationServerContract.ResourceOwnerPassword, secretsResponse.ResourceOwnerPassword);

                    // list again
                    listResponse = testBase.client.AuthorizationServer.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(listResponse);
                    Assert.Single(listResponse);
                    Assert.Null(listResponse.First().ClientSecret);

                    // update                    
                    var updateParameters = new AuthorizationServerUpdateContract
                    {
                        GrantTypes = new List<string> { GrantType.AuthorizationCode, GrantType.ResourceOwnerPassword },
                        UseInApiDocumentation = true,
                        UseInTestConsole = false
                    };

                    testBase.client.AuthorizationServer.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        authsid,
                        updateParameters,
                        getResponse.Headers.ETag);

                    // get to check is was updated
                    getResponse = await testBase.client.AuthorizationServer.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authsid);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Headers.ETag);
                    Assert.NotNull(getResponse.Body);

                    Assert.Equal(authsid, getResponse.Body.Name);
                    Assert.Equal(authorizationServerContract.DisplayName, getResponse.Body.DisplayName);
                    Assert.Equal(authorizationServerContract.Description, getResponse.Body.Description);
                    Assert.Equal(authorizationServerContract.DefaultScope, getResponse.Body.DefaultScope);
                    Assert.Equal(authorizationServerContract.AuthorizationEndpoint, getResponse.Body.AuthorizationEndpoint);
                    Assert.Equal(authorizationServerContract.TokenEndpoint, getResponse.Body.TokenEndpoint);
                    Assert.Equal(authorizationServerContract.ClientId, getResponse.Body.ClientId);
                    Assert.Equal(authorizationServerContract.ClientRegistrationEndpoint, getResponse.Body.ClientRegistrationEndpoint);
                    Assert.Null(getResponse.Body.ClientSecret);
                    Assert.Null(getResponse.Body.ResourceOwnerPassword);
                    Assert.Null(getResponse.Body.ResourceOwnerUsername);
                    Assert.Equal(updateParameters.GrantTypes.Count, getResponse.Body.GrantTypes.Count);
                    Assert.True(getResponse.Body.GrantTypes.All(gt => updateParameters.GrantTypes.Contains(gt)));
                    Assert.Equal(authorizationServerContract.AuthorizationMethods.Count, getResponse.Body.AuthorizationMethods.Count);
                    Assert.True(getResponse.Body.AuthorizationMethods.All(gt => authorizationServerContract.AuthorizationMethods.Contains(gt)));
                    Assert.Equal(authorizationServerContract.ClientAuthenticationMethod.Count, getResponse.Body.ClientAuthenticationMethod.Count);
                    Assert.True(getResponse.Body.ClientAuthenticationMethod.All(gt => authorizationServerContract.ClientAuthenticationMethod.Contains(gt)));
                    Assert.Equal(authorizationServerContract.SupportState, getResponse.Body.SupportState);
                    Assert.Equal(authorizationServerContract.TokenBodyParameters.Count, getResponse.Body.TokenBodyParameters.Count);
                    Assert.True(getResponse.Body.TokenBodyParameters.All(p => authorizationServerContract.TokenBodyParameters.Any(p1 => p1.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) && p1.Value.Equals(p.Value, StringComparison.OrdinalIgnoreCase))));
                    Assert.False(getResponse.Body.UseInTestConsole);
                    Assert.True(getResponse.Body.UseInApiDocumentation);

                    // delete
                    testBase.client.AuthorizationServer.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        authsid,
                        getResponse.Headers.ETag);

                    // get to check is was deleted
                    try
                    {
                        testBase.client.AuthorizationServer.Get(
                            testBase.rgName,
                            testBase.serviceName,
                            authsid);

                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal((int)HttpStatusCode.NotFound, (int)ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // delete
                    testBase.client.AuthorizationServer.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        authsid,
                        "*");
                }
            }
        }
    }
}

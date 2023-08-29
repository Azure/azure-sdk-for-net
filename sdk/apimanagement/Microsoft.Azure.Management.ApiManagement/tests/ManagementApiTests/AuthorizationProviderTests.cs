// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class AuthorizationProviderTests : TestBase
    {
        [Fact]
        [Trait("owner", "loganzipkes")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list all authorization providers
                var authProviderlistResponse = await testBase.client.AuthorizationProvider.ListByServiceWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(authProviderlistResponse);
                Assert.Empty(authProviderlistResponse.Body);

                // create authorization providers
                string authorizationProviderId = TestUtilities.GenerateName("authorizationProviderId");
                try
                {
                    var authorizationProviderContract = new AuthorizationProviderContract
                    {
                        DisplayName = TestUtilities.GenerateName("authorizationProviderDisplayName"),
                        IdentityProvider = "google",
                        Oauth2 = new AuthorizationProviderOAuth2Settings
                        {
                            RedirectUrl = "https://constoso.com",
                            GrantTypes = new AuthorizationProviderOAuth2GrantTypes
                            {
                                AuthorizationCode = new Dictionary<string, string>()
                                {
                                    { "clientId", "clientid" },
                                    { "clientSecret", "clientsecret" },
                                    { "scopes", "scopes" }
                                }
                            }
                        }
                    };

                    var createAuthProviderResponse = await testBase.client.AuthorizationProvider.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationProviderContract);

                    Assert.NotNull(createAuthProviderResponse);

                    // get authorization provider to check if it was created
                    var getAuthProviderResponse = await testBase.client.AuthorizationProvider.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId);

                    Assert.NotNull(getAuthProviderResponse);
                    Assert.NotNull(getAuthProviderResponse.Body);

                    Assert.Equal(authorizationProviderContract.DisplayName, getAuthProviderResponse.Body.DisplayName);
                    Assert.Equal(authorizationProviderContract.IdentityProvider, getAuthProviderResponse.Body.IdentityProvider);

                    // list authorization providers again
                    authProviderlistResponse = await testBase.client.AuthorizationProvider.ListByServiceWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(authProviderlistResponse);
                    Assert.NotEmpty(authProviderlistResponse.Body);

                    // list all authorizations
                    var authorizationlistResponse = await testBase.client.Authorization.ListByAuthorizationProviderWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        null);

                    Assert.NotNull(authorizationlistResponse);
                    Assert.Empty(authorizationlistResponse.Body);

                    string authorizationId = TestUtilities.GenerateName("authorizationId");
                    var authorizationContract = new AuthorizationContract
                    {
                        AuthorizationType = AuthorizationType.OAuth2,
                        OAuth2GrantType = OAuth2GrantType.AuthorizationCode
                    };

                    var createAuthorizationResponse = await testBase.client.Authorization.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        authorizationContract);

                    Assert.NotNull(createAuthorizationResponse);

                    // get authorization to validate that it was created
                    var getAuthorizationResponse = await testBase.client.Authorization.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId);

                    Assert.NotNull(getAuthorizationResponse);
                    Assert.NotNull(getAuthorizationResponse.Body);

                    Assert.Equal(authorizationContract.AuthorizationType, getAuthorizationResponse.Body.AuthorizationType);
                    Assert.Equal(authorizationContract.OAuth2GrantType, getAuthorizationResponse.Body.OAuth2GrantType);

                    // list authorizations again
                    authorizationlistResponse = await testBase.client.Authorization.ListByAuthorizationProviderWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        null);

                    Assert.NotNull(authorizationlistResponse);
                    Assert.NotEmpty(authorizationlistResponse.Body);

                    // get login link
                    var getLoginLinksResponse = await testBase.client.AuthorizationLoginLinks.PostWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        new AuthorizationLoginRequestContract
                        {
                            PostLoginRedirectUrl = "https://contoso.com"
                        });

                    Assert.NotNull(getLoginLinksResponse);

                    // list all access policies
                    var listAccessPoliciesResponse = await testBase.client.AuthorizationAccessPolicy.ListByAuthorizationWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        null);

                    Assert.NotNull(listAccessPoliciesResponse);
                    Assert.Empty(listAccessPoliciesResponse.Body);

                    // create access policy
                    var accessPolicyId = TestUtilities.GenerateName("accessPolicyId");
                    var accessPolicyContract = new AuthorizationAccessPolicyContract()
                    {
                        TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                        ObjectId = "a676137a-7ef9-49cd-a466-d87b143841da"
                    };

                    var createAccessPolicyResponse = await testBase.client.AuthorizationAccessPolicy.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        accessPolicyId,
                        accessPolicyContract);

                    Assert.NotNull(createAccessPolicyResponse);

                    // get access policy to validate that it was created
                    var getAccessPolicyResponse = await testBase.client.AuthorizationAccessPolicy.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        accessPolicyId);

                    Assert.NotNull(getAccessPolicyResponse);
                    Assert.NotNull(getAccessPolicyResponse.Body);

                    Assert.Equal(accessPolicyContract.TenantId, getAccessPolicyResponse.Body.TenantId);
                    Assert.Equal(accessPolicyContract.ObjectId, getAccessPolicyResponse.Body.ObjectId);

                    // list access policies again
                    listAccessPoliciesResponse = await testBase.client.AuthorizationAccessPolicy.ListByAuthorizationWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        null);

                    Assert.NotNull(listAccessPoliciesResponse);
                    Assert.NotEmpty(listAccessPoliciesResponse.Body);

                    // update access policies
                    var updateAccessPolicyParameters = new AuthorizationAccessPolicyContract
                    {
                        TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                        ObjectId = "a676137a-7ef9-49cd-a466-d87b143841da"
                    };

                    await testBase.client.AuthorizationAccessPolicy.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        accessPolicyId,
                        updateAccessPolicyParameters);

                    // get access policy to validate that it was updated
                    getAccessPolicyResponse = await testBase.client.AuthorizationAccessPolicy.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        accessPolicyId);

                    Assert.NotNull(getAccessPolicyResponse);
                    Assert.NotNull(getAccessPolicyResponse.Body);

                    Assert.Equal(updateAccessPolicyParameters.TenantId, getAccessPolicyResponse.Body.TenantId);
                    Assert.Equal(updateAccessPolicyParameters.ObjectId, getAccessPolicyResponse.Body.ObjectId);

                    // delete access policy
                    await testBase.client.AuthorizationAccessPolicy.DeleteWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        accessPolicyId,
                        "*");

                    // get access policy to validate that it was deleted
                    try
                    {
                        await testBase.client.AuthorizationAccessPolicy.GetWithHttpMessagesAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            authorizationProviderId,
                            authorizationId,
                            accessPolicyId);

                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal((int)HttpStatusCode.NotFound, (int)ex.Response.StatusCode);
                    }

                    // update authorization
                    var updateAuthorizationParameters = new AuthorizationContract
                    {
                        AuthorizationType = AuthorizationType.OAuth2,
                        OAuth2GrantType = OAuth2GrantType.AuthorizationCode
                    };

                    await testBase.client.Authorization.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        updateAuthorizationParameters);

                    // get authorization to validate that it was updated
                    getAuthorizationResponse = await testBase.client.Authorization.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId);

                    Assert.NotNull(getAuthorizationResponse);
                    Assert.NotNull(getAuthorizationResponse.Body);

                    Assert.Equal(updateAuthorizationParameters.AuthorizationType, getAuthorizationResponse.Body.AuthorizationType);
                    Assert.Equal(updateAuthorizationParameters.OAuth2GrantType, getAuthorizationResponse.Body.OAuth2GrantType);

                    // delete authorization
                    await testBase.client.Authorization.DeleteWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        authorizationId,
                        "*");

                    // get authorization to validate that it was deleted
                    try
                    {
                        await testBase.client.Authorization.GetWithHttpMessagesAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            authorizationProviderId,
                            authorizationId);

                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal((int)HttpStatusCode.NotFound, (int)ex.Response.StatusCode);
                    }

                    var updateAuthProviderParameters = new AuthorizationProviderContract
                    {
                        DisplayName = TestUtilities.GenerateName("newAuthorizationProviderDisplayName"),
                        IdentityProvider = "google",
                        Oauth2 = new AuthorizationProviderOAuth2Settings
                        {
                            RedirectUrl = "https://constoso.com",
                            GrantTypes = new AuthorizationProviderOAuth2GrantTypes
                            {
                                AuthorizationCode = new Dictionary<string, string>()
                                {
                                    { "clientId", "clientid" },
                                    { "clientSecret", "clientsecret" },
                                    { "scopes", "scopes" }
                                }
                            }
                        }
                    };

                    // update authorization provider
                    await testBase.client.AuthorizationProvider.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        updateAuthProviderParameters);

                    // get authorization provider to validate that it was updated
                    getAuthProviderResponse = await testBase.client.AuthorizationProvider.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId);

                    Assert.NotNull(getAuthProviderResponse);
                    Assert.NotNull(getAuthProviderResponse.Body);

                    Assert.Equal(updateAuthProviderParameters.DisplayName, getAuthProviderResponse.Body.DisplayName);
                    Assert.Equal(authorizationProviderContract.IdentityProvider, getAuthProviderResponse.Body.IdentityProvider);

                    // delete authorization provider
                    await testBase.client.AuthorizationProvider.DeleteWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        "*");

                    // get authorization provider to check if it was deleted
                    try
                    {
                        await testBase.client.AuthorizationProvider.GetWithHttpMessagesAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            authorizationProviderId);

                        throw new System.Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal((int)HttpStatusCode.NotFound, (int)ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // delete authorization provider to ensure clean up
                    await testBase.client.AuthorizationProvider.DeleteWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        authorizationProviderId,
                        "*");
                }
            }
        }
    }
}

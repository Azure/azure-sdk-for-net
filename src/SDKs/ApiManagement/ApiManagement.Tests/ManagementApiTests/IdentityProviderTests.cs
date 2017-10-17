// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Threading.Tasks;
using System;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class IdentityProviderTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                try
                {
                    // create facebook external identity provider
                    string clientId = TestUtilities.GenerateName("clientId");
                    string clientSecret = TestUtilities.GenerateName("clientSecret");

                    var identityProviderCreateParameters = new IdentityProviderContract(clientId, clientSecret);

                    var createResponse = testBase.client.IdentityProvider.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook,
                        identityProviderCreateParameters);

                    Assert.NotNull(createResponse);

                    // get to check it was created
                    var getResponse = await testBase.client.IdentityProvider.GetWithHttpMessagesAsync(
                        testBase.rgName, 
                        testBase.serviceName,
                        IdentityProviderType.Facebook);

                    Assert.NotNull(getResponse);
                    Assert.Equal(IdentityProviderType.Facebook, getResponse.Body.IdentityProviderContractType);
                    Assert.NotNull(getResponse.Body.ClientId);
                    Assert.NotNull(getResponse.Body.ClientSecret);
                    Assert.Equal(clientId, getResponse.Body.ClientId);
                    Assert.Equal(clientSecret, getResponse.Body.ClientSecret);
                    Assert.Equal(IdentityProviderType.Facebook, getResponse.Body.IdentityProviderContractType);

                    var listIdentityProviders = testBase.client.IdentityProvider.ListByService(testBase.rgName, testBase.serviceName);

                    Assert.NotNull(listIdentityProviders);

                    // there should be one identity Provider
                    Assert.True(listIdentityProviders.Value.Count >= 1);

                    // patch identity provider
                    string patchedSecret = TestUtilities.GenerateName("clientSecret");
                    testBase.client.IdentityProvider.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook,
                        new IdentityProviderUpdateParameters
                        {
                            ClientSecret = patchedSecret
                        },
                        getResponse.Headers.ETag);

                    // get to check it was patched
                    getResponse = await testBase.client.IdentityProvider.GetWithHttpMessagesAsync(testBase.rgName, testBase.serviceName, IdentityProviderType.Facebook);

                    Assert.NotNull(getResponse);
                    Assert.Equal(IdentityProviderType.Facebook, getResponse.Body.IdentityProviderContractType);
                    Assert.Equal(patchedSecret, getResponse.Body.ClientSecret);
                    Assert.Equal(clientId, getResponse.Body.ClientId);

                    // delete the identity provider
                    testBase.client.IdentityProvider.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook,
                        getResponse.Headers.ETag);

                    // get the deleted identity provider to make sure it was deleted
                    try
                    {
                        testBase.client.IdentityProvider.Get(testBase.rgName, testBase.serviceName, IdentityProviderType.Facebook);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.IdentityProvider.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook,
                        "*");
                }
            }
        }
    }
}

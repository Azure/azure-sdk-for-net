// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using ApiManagementManagement.Tests.Helpers;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class IdentityProviderTests : TestBase
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

                try
                {
                    // create facebook external identity provider
                    string clientId = TestUtilities.GenerateName("clientId");
                    string clientSecret = TestUtilities.GenerateName("clientSecret");

                    var identityProviderCreateParameters = new IdentityProviderCreateContract(clientId, clientSecret);

                    var identityProviderContract = testBase.client.IdentityProvider.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook,
                        identityProviderCreateParameters);

                    Assert.NotNull(identityProviderContract);
                    Assert.Equal(IdentityProviderType.Facebook, identityProviderContract.IdentityProviderContractType);
                    Assert.NotNull(identityProviderContract.ClientId);
                    Assert.NotNull(identityProviderContract.ClientSecret);
                    Assert.Equal(clientId, identityProviderContract.ClientId);
                    Assert.Equal(clientSecret, identityProviderContract.ClientSecret);
                    Assert.Equal(IdentityProviderType.Facebook, identityProviderContract.IdentityProviderContractType);

                    // list
                    var listIdentityProviders = testBase.client.IdentityProvider.ListByService(testBase.rgName, testBase.serviceName);

                    Assert.NotNull(listIdentityProviders);
                    Assert.True(listIdentityProviders.GetEnumerator().ToIEnumerable().Count() >= 1);

                    // get the entity tag
                    var identityProviderTag = await testBase.client.IdentityProvider.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook);
                    Assert.NotNull(identityProviderTag);
                    Assert.NotNull(identityProviderTag.ETag);

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
                        identityProviderTag.ETag);

                    // get to check it was patched
                    identityProviderContract = await testBase.client.IdentityProvider.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook);

                    Assert.NotNull(identityProviderContract);
                    Assert.Equal(IdentityProviderType.Facebook, identityProviderContract.IdentityProviderContractType);
                    Assert.Null(identityProviderContract.ClientSecret);
                    Assert.Equal(clientId, identityProviderContract.ClientId);

                    // get the tag again
                    identityProviderTag = await testBase.client.IdentityProvider.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook);

                    var secret = await testBase.client.IdentityProvider.ListSecretsAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook);
                    Assert.Equal(patchedSecret, secret.ClientSecret);

                    // delete the identity provider
                    testBase.client.IdentityProvider.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        IdentityProviderType.Facebook,
                        identityProviderTag.ETag);

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

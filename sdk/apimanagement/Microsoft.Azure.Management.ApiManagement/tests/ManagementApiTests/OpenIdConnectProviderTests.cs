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
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class OpenIdConnectProviderTests : TestBase
    {
        [Fact]
        [Trait("owner", "jikang")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                string openIdNoSecret = TestUtilities.GenerateName("openId");
                string openId2 = TestUtilities.GenerateName("openId");

                try
                {
                    // create a openId connect provider
                    string openIdProviderName = TestUtilities.GenerateName("openIdName");
                    string metadataEndpoint = testBase.GetOpenIdMetadataEndpointUrl();
                    string clientId = TestUtilities.GenerateName("clientId");
                    var openIdConnectCreateParameters = new OpenidConnectProviderContract(openIdProviderName,
                        metadataEndpoint, clientId);

                    var createResponse = testBase.client.OpenIdConnectProvider.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        openIdNoSecret,
                        openIdConnectCreateParameters);

                    Assert.NotNull(createResponse);
                    Assert.Equal(openIdProviderName, createResponse.DisplayName);
                    Assert.Equal(openIdNoSecret, createResponse.Name);

                    // get to check it was created
                    var openIdConnectProviderContract = await testBase.client.OpenIdConnectProvider.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        openIdNoSecret);

                    Assert.NotNull(openIdConnectProviderContract);

                    Assert.Equal(openIdProviderName, openIdConnectProviderContract.DisplayName);
                    Assert.Equal(metadataEndpoint, openIdConnectProviderContract.MetadataEndpoint);
                    Assert.Equal(clientId, openIdConnectProviderContract.ClientId);
                    Assert.Equal(openIdNoSecret, openIdConnectProviderContract.Name);
                    Assert.Null(openIdConnectProviderContract.ClientSecret);
                    Assert.Null(openIdConnectProviderContract.Description);

                    // check default values for UseInTestConsole and UseInApiDocumentation
                    Assert.True(openIdConnectProviderContract.UseInTestConsole);
                    Assert.False(openIdConnectProviderContract.UseInApiDocumentation);

                    // create a Secret property
                    string openIdProviderName2 = TestUtilities.GenerateName("openIdName");
                    string metadataEndpoint2 = testBase.GetOpenIdMetadataEndpointUrl();
                    string clientId2 = TestUtilities.GenerateName("clientId");
                    string clientSecret = TestUtilities.GenerateName("clientSecret");
                    var openIdConnectCreateParameters2 = new OpenidConnectProviderContract(openIdProviderName2,
                        metadataEndpoint2, clientId2);
                    openIdConnectCreateParameters2.ClientSecret = clientSecret;
                    openIdConnectCreateParameters2.Description = TestUtilities.GenerateName("description");

                    var createResponse2 = testBase.client.OpenIdConnectProvider.CreateOrUpdate(
                       testBase.rgName,
                       testBase.serviceName,
                       openId2,
                       openIdConnectCreateParameters2);

                    Assert.NotNull(createResponse2);
                    Assert.Equal(openIdProviderName2, createResponse2.DisplayName);
                    Assert.Equal(openId2, createResponse2.Name);

                    // get to check it was created
                    var getResponse2 = testBase.client.OpenIdConnectProvider.Get(testBase.rgName, testBase.serviceName, openId2);

                    Assert.NotNull(getResponse2);
                    Assert.Equal(openIdProviderName2, getResponse2.DisplayName);
                    Assert.Equal(clientId2, getResponse2.ClientId);
                    Assert.Equal(metadataEndpoint2, getResponse2.MetadataEndpoint);
                    Assert.Null(getResponse2.ClientSecret);
                    Assert.NotNull(getResponse2.Description);
                    Assert.Equal(openId2, getResponse2.Name);

                    var secretResponse = testBase.client.OpenIdConnectProvider.ListSecrets(testBase.rgName, testBase.serviceName, openId2);
                    Assert.Equal(clientSecret, secretResponse.ClientSecret);

                    // list the openId Connect Providers
                    var listResponse = testBase.client.OpenIdConnectProvider.ListByService(testBase.rgName, testBase.serviceName, null);

                    Assert.NotNull(listResponse);

                    // there should be atleast 2 openId connect Providers.
                    Assert.True(listResponse.Count() >= 2);
                    Assert.Null(listResponse.NextPageLink);

                    // list using Query
                    listResponse = testBase.client.OpenIdConnectProvider.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        new Microsoft.Rest.Azure.OData.ODataQuery<OpenidConnectProviderContract> { Top = 1 });

                    Assert.NotNull(listResponse);
                    Assert.Single(listResponse);
                    Assert.NotNull(listResponse.NextPageLink);
                    Assert.Null(listResponse.First().ClientSecret);

                    // get the openid connect provider tag
                    var openIdConnectProviderTag = await testBase.client.OpenIdConnectProvider.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        openIdNoSecret);
                    Assert.NotNull(openIdConnectProviderTag);
                    Assert.NotNull(openIdConnectProviderTag.ETag);

                    // delete a OpenId Connect Provider
                    await testBase.client.OpenIdConnectProvider.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        openIdNoSecret,
                        openIdConnectProviderTag.ETag);

                    // get the deleted openId Connect Provider to make sure it was deleted
                    try
                    {
                        testBase.client.OpenIdConnectProvider.Get(testBase.rgName, testBase.serviceName, openIdNoSecret);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }

                    // get the etag of openId2
                    openIdConnectProviderTag = await testBase.client.OpenIdConnectProvider.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        openId2);
                    Assert.NotNull(openIdConnectProviderTag);
                    Assert.NotNull(openIdConnectProviderTag.ETag);

                    // patch the openId Connect Provider
                    string updateMetadataEndpoint = testBase.GetOpenIdMetadataEndpointUrl();
                    string updatedClientId = TestUtilities.GenerateName("updatedClient");
                    testBase.client.OpenIdConnectProvider.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        openId2,
                        new OpenidConnectProviderUpdateContract
                        {
                            MetadataEndpoint = updateMetadataEndpoint,
                            ClientId = updatedClientId,
                            UseInTestConsole = true,
                            UseInApiDocumentation = false
                        },
                        openIdConnectProviderTag.ETag);

                    // get to check it was patched
                    var getResponseOpendId2 = await testBase.client.OpenIdConnectProvider.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        openId2);

                    Assert.NotNull(getResponseOpendId2);
                    Assert.NotNull(getResponseOpendId2.Body);
                    Assert.NotNull(getResponseOpendId2.Headers.ETag);

                    Assert.Equal(openId2, getResponseOpendId2.Body.Name);
                    Assert.Equal(updatedClientId, getResponseOpendId2.Body.ClientId);
                    Assert.Equal(updateMetadataEndpoint, getResponseOpendId2.Body.MetadataEndpoint);
                    Assert.Null(getResponseOpendId2.Body.ClientSecret);
                    Assert.NotNull(getResponseOpendId2.Body.Description);
                    Assert.True(getResponseOpendId2.Body.UseInTestConsole);
                    Assert.False(getResponseOpendId2.Body.UseInApiDocumentation);

                    var secretsResponse = await testBase.client.OpenIdConnectProvider.ListSecretsAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        openId2);
                    Assert.Equal(clientSecret, secretsResponse.ClientSecret);

                    // delete the openId Connect Provider 
                    testBase.client.OpenIdConnectProvider.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        openId2,
                        getResponseOpendId2.Headers.ETag);

                    // get the deleted openId Connect Provider to make sure it was deleted
                    try
                    {
                        testBase.client.OpenIdConnectProvider.Get(testBase.rgName, testBase.serviceName, openId2);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.OpenIdConnectProvider.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        openIdNoSecret,
                        "*");

                    testBase.client.OpenIdConnectProvider.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        openId2,
                        "*");
                }
            }
        }
    }
}

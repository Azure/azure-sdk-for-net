// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class GatewayTests : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list gateways: there should be none
                var gatewayListResponse = testBase.client.Gateway.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(gatewayListResponse);
                Assert.Empty(gatewayListResponse);

                // list all the APIs
                var apisResponse = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(apisResponse);
                Assert.Single(apisResponse);
                Assert.Null(apisResponse.NextPageLink);
                var echoApi = apisResponse.First();

                string gatewayId = TestUtilities.GenerateName("gatewayid"); ;
                string certificateId = TestUtilities.GenerateName("certificateId");
                string hostnameConfigId = TestUtilities.GenerateName("hostnameConfigId");

                try
                {
                    var gatewayContract = new GatewayContract()
                    {
                        LocationData = new ResourceLocationDataContract()
                        {
                            City = "Seattle",
                            CountryOrRegion = "USA",
                            District = "King County",
                            Name = "Microsoft"
                        }, 
                        Description = TestUtilities.GenerateName()
                    };

                    var createResponse = await testBase.client.Gateway.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        gatewayContract);

                    Assert.NotNull(createResponse);
                    Assert.Equal(gatewayId, createResponse.Name);
                    Assert.Equal(gatewayContract.Description, createResponse.Description);
                    Assert.NotNull(createResponse.LocationData);
                    Assert.Equal(gatewayContract.LocationData.City, createResponse.LocationData.City);
                    Assert.Equal(gatewayContract.LocationData.CountryOrRegion, createResponse.LocationData.CountryOrRegion);
                    Assert.Equal(gatewayContract.LocationData.District, createResponse.LocationData.District);
                    Assert.Equal(gatewayContract.LocationData.Name, createResponse.LocationData.Name);

                    // get the gateway to check is was created
                    var getResponse = await testBase.client.Gateway.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId);

                    Assert.NotNull(getResponse);
                    Assert.Equal(gatewayId, getResponse.Body.Name);

                    // list gateways
                    gatewayListResponse = testBase.client.Gateway.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(gatewayListResponse);
                    Assert.Single(gatewayListResponse);


                    var associationContract = new AssociationContract()
                    {
                        ProvisioningState = ProvisioningState.Created
                    };

                    // assign gateway to api
                    var assignResponse = await testBase.client.GatewayApi.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        echoApi.Name,
                        associationContract);

                    Assert.NotNull(assignResponse);
                    Assert.Equal(echoApi.Name, assignResponse.Name);

                    // list gateway apis
                    var apiGatewaysResponse = await testBase.client.GatewayApi.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId);

                    Assert.NotNull(apiGatewaysResponse);
                    Assert.Single(apiGatewaysResponse);
                    Assert.Equal(echoApi.Name, apiGatewaysResponse.First().Name);


                    //hostnameConfiguration:
                    //certificate first:
                    var base64ArrayCertificate = Convert.FromBase64String(testBase.base64EncodedTestCertificateData);
                    var cert = new X509Certificate2(base64ArrayCertificate, testBase.testCertificatePassword);

                    var certCreateResponse = testBase.client.Certificate.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        certificateId,
                        new CertificateCreateOrUpdateParameters
                        {
                            Data = testBase.base64EncodedTestCertificateData,
                            Password = testBase.testCertificatePassword
                        },
                        null);

                    var hostnameConfig = new GatewayHostnameConfigurationContract()
                    {
                        CertificateId = certCreateResponse.Id,
                        Hostname = "www.contoso.com",
                        NegotiateClientCertificate = false
                    };

                    var hostnameConfigCreateResponse = await testBase.client.GatewayHostnameConfiguration.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        hostnameConfigId,
                        hostnameConfig
                        );
                    Assert.NotNull(hostnameConfigCreateResponse);
                    Assert.Equal(hostnameConfigId, hostnameConfigCreateResponse.Name);
                    Assert.Equal(hostnameConfigCreateResponse.CertificateId, hostnameConfigCreateResponse.CertificateId);
                    Assert.Equal("www.contoso.com", hostnameConfigCreateResponse.Hostname);
                    Assert.False(hostnameConfigCreateResponse.NegotiateClientCertificate);

                    var hostnameConfigResponse = await testBase.client.GatewayHostnameConfiguration.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        hostnameConfigId
                        );

                    Assert.NotNull(hostnameConfigCreateResponse);
                    Assert.Equal(hostnameConfigId, hostnameConfigCreateResponse.Name);
                    Assert.Equal(hostnameConfigCreateResponse.CertificateId, hostnameConfigCreateResponse.CertificateId);
                    Assert.Equal("www.contoso.com", hostnameConfigCreateResponse.Hostname);
                    Assert.False(hostnameConfigCreateResponse.NegotiateClientCertificate);

                    //delete hostname config
                    testBase.client.GatewayHostnameConfiguration.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        hostnameConfigId);

                    //get latest etag for delete
                    getResponse = await testBase.client.Gateway.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId);

                    // remove the gateway
                    testBase.client.Gateway.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        getResponse.Headers.ETag);

                    // list again to see it was removed
                    gatewayListResponse = testBase.client.Gateway.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(gatewayListResponse);
                    Assert.Empty(gatewayListResponse);
                }
                finally
                {
                    try
                    {
                        testBase.client.GatewayHostnameConfiguration.Delete(testBase.rgName, testBase.serviceName, gatewayId, hostnameConfigId);
                    }
                    catch (ErrorResponseException) { }
                    testBase.client.Gateway.Delete(testBase.rgName, testBase.serviceName, gatewayId, "*");
                    testBase.client.Certificate.Delete(testBase.rgName, testBase.serviceName, certificateId, "*");
                }
            }
        }


        [Fact]
        [Trait("owner", "vifedo")]

        public async Task GetRegenerateKeys()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list gateways: there should be none
                var gatewayListResponse = testBase.client.Gateway.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(gatewayListResponse);
                Assert.Empty(gatewayListResponse);

                string gatewayId = TestUtilities.GenerateName("gatewayid"); ;

                try
                {
                    var gatewayContract = new GatewayContract()
                    {
                        LocationData = new ResourceLocationDataContract()
                        {
                            City = "Seattle",
                            CountryOrRegion = "USA",
                            District = "King County",
                            Name = "Microsoft"
                        },
                        Description = TestUtilities.GenerateName()
                    };

                    var createResponse = await testBase.client.Gateway.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        gatewayContract);

                    Assert.NotNull(createResponse);
                    Assert.Equal(gatewayId, createResponse.Name);
                    Assert.Equal(gatewayContract.Description, createResponse.Description);
                    Assert.NotNull(createResponse.LocationData);
                    Assert.Equal(gatewayContract.LocationData.City, createResponse.LocationData.City);
                    Assert.Equal(gatewayContract.LocationData.CountryOrRegion, createResponse.LocationData.CountryOrRegion);
                    Assert.Equal(gatewayContract.LocationData.District, createResponse.LocationData.District);
                    Assert.Equal(gatewayContract.LocationData.Name, createResponse.LocationData.Name);

                    // get keys
                    var getResponse = await testBase.client.Gateway.ListKeysAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Primary);
                    Assert.NotNull(getResponse.Secondary);

                    var primaryKey = getResponse.Primary;
                    var secondaryKey = getResponse.Secondary;
                    Assert.NotEqual(primaryKey, secondaryKey);

                    var expiry = DateTime.UtcNow;

                    // generate token
                    var tokenResponse = await testBase.client.Gateway.GenerateTokenAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        new GatewayTokenRequestContract() { Expiry = expiry, KeyType = KeyType.Primary });
                    Assert.NotNull(tokenResponse);
                    Assert.NotNull(tokenResponse.Value);
                    var primaryToken = tokenResponse.Value;

                    //check the same token stays
                    tokenResponse = await testBase.client.Gateway.GenerateTokenAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        new GatewayTokenRequestContract() { Expiry = expiry, KeyType = KeyType.Primary });
                    Assert.NotNull(tokenResponse);
                    Assert.NotNull(tokenResponse.Value);
                    Assert.Equal(primaryToken, tokenResponse.Value);

                    // generate secondary token
                    tokenResponse = await testBase.client.Gateway.GenerateTokenAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        new GatewayTokenRequestContract() { Expiry = expiry, KeyType = KeyType.Secondary });
                    Assert.NotNull(tokenResponse);
                    Assert.NotNull(tokenResponse.Value);
                    var secondaryToken = tokenResponse.Value;

                    Assert.NotEqual(primaryToken, secondaryToken);

                    //change keys
                    await testBase.client.Gateway.RegenerateKeyAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        new GatewayKeyRegenerationRequestContract() { KeyType = KeyType.Primary });

                    await testBase.client.Gateway.RegenerateKeyAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        new GatewayKeyRegenerationRequestContract() { KeyType = KeyType.Secondary });

                    // get keys
                    getResponse = await testBase.client.Gateway.ListKeysAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Primary);
                    Assert.NotNull(getResponse.Secondary);

                    Assert.NotEqual(primaryKey, getResponse.Primary);
                    Assert.NotEqual(secondaryKey, getResponse.Secondary);

                    // generate token
                    tokenResponse = await testBase.client.Gateway.GenerateTokenAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        new GatewayTokenRequestContract() { Expiry = expiry, KeyType = KeyType.Primary });
                    Assert.NotNull(tokenResponse);
                    Assert.NotNull(tokenResponse.Value);
                    Assert.NotEqual(primaryToken, tokenResponse.Value);

                    // generate secondary token
                    tokenResponse = await testBase.client.Gateway.GenerateTokenAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        gatewayId,
                        new GatewayTokenRequestContract() { Expiry = expiry, KeyType = KeyType.Secondary });
                    Assert.NotNull(tokenResponse);
                    Assert.NotNull(tokenResponse.Value);
                    Assert.NotEqual(secondaryToken, tokenResponse.Value);
                }
                finally
                {
                    testBase.client.Gateway.Delete(testBase.rgName, testBase.serviceName, gatewayId, "*");
                }
            }
        }
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public void CreateMultiHostNameZoneAwareService()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);

                var domainOwnershipIdentifierResult = testBase.client.ApiManagementService.GetDomainOwnershipIdentifier();
                Assert.NotNull(domainOwnershipIdentifierResult);
                Assert.NotEmpty(domainOwnershipIdentifierResult.DomainOwnershipIdentifier);

                testBase.serviceProperties.Zones = new[] { "1", "2" };
                testBase.serviceProperties.Sku.Name = SkuType.Premium;
                testBase.serviceProperties.Sku.Capacity = 2; // unit count in multiple of zones
                testBase.location = "eastus2euap";
                testBase.serviceProperties.Location = testBase.location;
                var hostnameConfig1 = new HostnameConfiguration()
                {
                    Type = HostnameType.Proxy,
                    HostName = "gateway1.msitesting.net",
                    EncodedCertificate = testBase.base64EncodedTestCertificateData,
                    CertificatePassword = testBase.testCertificatePassword,
                    DefaultSslBinding = true
                };

                var hostnameConfig2 = new HostnameConfiguration()
                {
                    Type = HostnameType.Proxy,
                    HostName = "gateway2.msitesting.net",
                    EncodedCertificate = testBase.base64EncodedTestCertificateData,
                    CertificatePassword = testBase.testCertificatePassword,
                    NegotiateClientCertificate = true
                };

                var hostnameConfig3 = new HostnameConfiguration()
                {
                    Type = HostnameType.Portal,
                    HostName = "portal1.msitesting.net",
                    EncodedCertificate = testBase.base64EncodedTestCertificateData,
                    CertificatePassword = testBase.testCertificatePassword
                };

                var hostnameConfig4 = new HostnameConfiguration()
                {
                    Type = HostnameType.DeveloperPortal,
                    HostName = "devportal1.msitesting.net",
                    EncodedCertificate = testBase.base64EncodedTestCertificateData,
                    CertificatePassword = testBase.testCertificatePassword
                };

                testBase.serviceProperties.HostnameConfigurations = new List<HostnameConfiguration>
                {
                    hostnameConfig1,
                    hostnameConfig2,
                    hostnameConfig3,
                    hostnameConfig4
                };

                var base64ArrayCertificate = Convert.FromBase64String(testBase.base64EncodedTestCertificateData);
                var cert = new X509Certificate2(base64ArrayCertificate, testBase.testCertificatePassword);

                var createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);

                ValidateService(createdService,
                    testBase.serviceName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.location,
                    testBase.serviceProperties.PublisherEmail,
                    testBase.serviceProperties.PublisherName,
                    testBase.serviceProperties.Sku.Name,
                    testBase.tags);

                Assert.Equal(2, createdService.Sku.Capacity);
                Assert.Equal(2, createdService.Zones.Count);
                Assert.True(createdService.Zones.Contains("1"));
                Assert.True(createdService.Zones.Contains("2"));
                Assert.NotNull(createdService.HostnameConfigurations);
                Assert.Equal(5, createdService.HostnameConfigurations.Count()); // customhostname config + 1 default proxy
                var defaultHostname = new Uri(createdService.GatewayUrl).Host;
                var hostnameConfigurationToValidate = createdService.HostnameConfigurations
                    .Where(h => !h.HostName.Equals(defaultHostname, StringComparison.InvariantCultureIgnoreCase));

                foreach (HostnameConfiguration hostnameConfig in hostnameConfigurationToValidate)
                {
                    var hostnameConfiguration = createdService.HostnameConfigurations
                        .SingleOrDefault(h => hostnameConfig.HostName.Equals(h.HostName));
                    Assert.NotNull(hostnameConfiguration);
                    Assert.Equal(hostnameConfig.Type, hostnameConfiguration.Type);
                    Assert.NotNull(hostnameConfiguration.Certificate);
                    Assert.NotNull(hostnameConfiguration.Certificate.Subject);
                    Assert.Null(hostnameConfig.IdentityClientId);
                    Assert.Null(hostnameConfig.KeyVaultId);
                    Assert.Equal(cert.Thumbprint, hostnameConfiguration.Certificate.Thumbprint);

                    if (HostnameType.Proxy == hostnameConfiguration.Type)
                    {
                        Assert.True(hostnameConfiguration.DefaultSslBinding);
                    }
                    else
                    {
                        Assert.False(hostnameConfiguration.DefaultSslBinding);
                    }

                    if (hostnameConfig2.HostName.Equals(hostnameConfiguration.HostName))
                    {
                        Assert.True(hostnameConfiguration.NegotiateClientCertificate);
                    }
                    else
                    {
                        Assert.False(hostnameConfiguration.NegotiateClientCertificate);
                    }
                }

                // update the service
                int intialTagsCount = createdService.Tags.Count;
                createdService.Tags.Add("client", "test");
                var updatedService = testBase.client.ApiManagementService.CreateOrUpdate(testBase.rgName,
                     testBase.serviceName,
                     createdService);
                Assert.NotNull(updatedService);
                Assert.NotEmpty(updatedService.Tags);
                Assert.Equal(intialTagsCount + 1, updatedService.Tags.Count);
                Assert.Equal(5, updatedService.HostnameConfigurations.Count());

                hostnameConfigurationToValidate = updatedService.HostnameConfigurations
                    .Where(h => !h.HostName.Equals(defaultHostname, StringComparison.InvariantCultureIgnoreCase));
                foreach (HostnameConfiguration hostnameConfig in hostnameConfigurationToValidate)
                {
                    var hostnameConfiguration = updatedService.HostnameConfigurations
                        .SingleOrDefault(h => hostnameConfig.HostName.Equals(h.HostName));
                    Assert.NotNull(hostnameConfiguration);
                    Assert.Equal(hostnameConfig.Type, hostnameConfiguration.Type);
                    Assert.NotNull(hostnameConfiguration.Certificate);
                    Assert.NotNull(hostnameConfiguration.Certificate.Subject);
                    Assert.Equal(cert.Thumbprint, hostnameConfiguration.Certificate.Thumbprint);

                    if (HostnameType.Proxy == hostnameConfiguration.Type)
                    {
                        Assert.True(hostnameConfiguration.DefaultSslBinding);
                    }
                    else
                    {
                        Assert.False(hostnameConfiguration.DefaultSslBinding);
                    }

                    if (hostnameConfig2.HostName.Equals(hostnameConfiguration.HostName))
                    {
                        Assert.True(hostnameConfiguration.NegotiateClientCertificate);
                    }
                    else
                    {
                        Assert.False(hostnameConfiguration.NegotiateClientCertificate);
                    }
                }

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<ErrorResponseException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }
    }
}
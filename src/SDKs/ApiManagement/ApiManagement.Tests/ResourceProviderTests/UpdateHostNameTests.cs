// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        public async Task UpdateHostNameTests()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                                
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
                
                var base64ArrayCertificate = Convert.FromBase64String(testBase.base64EncodedTestCertificateData);
                var cert = new X509Certificate2(base64ArrayCertificate, testBase.testCertificatePassword);

                var uploadCertificateParams = new ApiManagementServiceUploadCertificateParameters()
                {
                    Type = HostnameType.Proxy,
                    Certificate = testBase.base64EncodedTestCertificateData,
                    CertificatePassword = testBase.testCertificatePassword
                };
                var certificateInformation = await testBase.client.ApiManagementService.UploadCertificateAsync(testBase.rgName, testBase.serviceName, uploadCertificateParams);

                Assert.NotNull(certificateInformation);
                Assert.Equal(cert.Thumbprint, certificateInformation.Thumbprint);
                Assert.Equal(cert.Subject, certificateInformation.Subject);

                var updateHostnameParams = new ApiManagementServiceUpdateHostnameParameters()
                {
                    Update = new List<HostnameConfigurationOld>()
                    { new HostnameConfigurationOld(HostnameType.Proxy, "proxy.msitesting.net", certificateInformation) }
                };

                var serviceResource = await testBase.client.ApiManagementService.UpdateHostnameAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    updateHostnameParams);

                Assert.NotNull(serviceResource);
                Assert.Single(serviceResource.HostnameConfigurations);
                Assert.Equal(HostnameType.Proxy, serviceResource.HostnameConfigurations.First().Type);
                Assert.Equal("proxy.msitesting.net", serviceResource.HostnameConfigurations.First().HostName);

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<CloudException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }
    }
}
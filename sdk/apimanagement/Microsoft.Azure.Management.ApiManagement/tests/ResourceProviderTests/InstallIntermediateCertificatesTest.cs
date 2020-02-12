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
using Xunit;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public void InstallIntermediateCertificatesTest()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.serviceProperties.Sku.Name = SkuType.Basic;

                testBase.serviceProperties.Certificates = new List<CertificateConfiguration>();
                var certConfig = new CertificateConfiguration()
                {
                    StoreName = StoreName.CertificateAuthority.ToString("G"),
                    EncodedCertificate = testBase.base64EncodedTestCertificateData,
                    CertificatePassword = testBase.testCertificatePassword
                };
                testBase.serviceProperties.Certificates.Add(certConfig);

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

                Assert.NotNull(createdService.Certificates);
                Assert.Single(createdService.Certificates);
                Assert.Equal(StoreName.CertificateAuthority.ToString("G"), createdService.Certificates.First().StoreName, ignoreCase: true);
                Assert.Equal(cert.Thumbprint, createdService.Certificates.First().Certificate.Thumbprint, ignoreCase: true);

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
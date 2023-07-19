﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class CertificateTests : TestBase
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

                // list certificates: there should be none
                var listResponse = testBase.client.Certificate.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.Empty(listResponse);

                // create new certificate
                string certificateId = TestUtilities.GenerateName("certificateId");

                try
                {
                    var base64ArrayCertificate = Convert.FromBase64String(testBase.base64EncodedTestCertificateData);
                    var cert = new X509Certificate2(base64ArrayCertificate, testBase.testCertificatePassword);

                    var createResponse = testBase.client.Certificate.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        certificateId,
                        new CertificateCreateOrUpdateParameters
                        {
                            Data = testBase.base64EncodedTestCertificateData,
                            Password = testBase.testCertificatePassword
                        },
                        null);

                    Assert.NotNull(createResponse);
                    Assert.Equal(certificateId, createResponse.Name);

                    // get the certificate to check is was created
                    var getResponse = await testBase.client.Certificate.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        certificateId);

                    Assert.NotNull(getResponse);
                    Assert.Equal(certificateId, getResponse.Body.Name);
                    Assert.Equal(cert.Subject, getResponse.Body.Subject, StringComparer.OrdinalIgnoreCase);
                    Assert.Equal(cert.Thumbprint, getResponse.Body.Thumbprint, StringComparer.OrdinalIgnoreCase);

                    //create key vault certificate
                    string kvcertificateId = TestUtilities.GenerateName("kvcertificateId");
                    var kvCreateParameters = new CertificateCreateOrUpdateParameters
                    {
                        KeyVault = new KeyVaultContractCreateProperties
                        {
                            SecretIdentifier = testBase.testKeyVaultSecretUrl
                        },
                    };

                    var kvCertificateIdResponse = testBase.client.Certificate.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        kvcertificateId,
                        kvCreateParameters,
                        null);

                    Assert.NotNull(createResponse);
                    Assert.Equal(certificateId, createResponse.Name);

                    // get the certificate to check is was created
                    var getKVResponse = await testBase.client.Certificate.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        kvcertificateId);

                    Assert.NotNull(getKVResponse);
                    Assert.Equal(kvcertificateId, getKVResponse.Body.Name);

                    //refresh secret of key vault client
                    var refreshKvCertificateResponse = testBase.client.Certificate.RefreshSecret(
                        testBase.rgName,
                        testBase.serviceName,
                        kvcertificateId);

                    Assert.NotNull(refreshKvCertificateResponse);

                    // list certificates
                    listResponse = testBase.client.Certificate.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(listResponse);
                    Assert.Equal(2, listResponse.Count());

                    // remove the certificate
                    testBase.client.Certificate.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        certificateId,
                        getResponse.Headers.ETag);

                    testBase.client.Certificate.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        kvcertificateId,
                        "*");

                    // list again to see it was removed
                    listResponse = testBase.client.Certificate.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(listResponse);
                    Assert.Empty(listResponse);
                }
                finally
                {
                    testBase.client.Certificate.Delete(testBase.rgName, testBase.serviceName, certificateId, "*");
                }
            }
        }
    }
}

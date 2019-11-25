
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.Management.Attestation.Models;
using Microsoft.Azure.Management.ResourceManager;
using Attestation.Management.ScenarioTests;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using Xunit;
namespace Attestation.Tests.ScenarioTests
{
    public class AttestationOperationsTests : TestBase
    {
        [Fact]
        public void AttestationManagementAttestationCreateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var mode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
                var testBase = new AttestationTestBase(context);
                testBase.apiVersion = testBase.apiVersion;

                byte[] certBuffer = Convert.FromBase64String("MIICjzCCAjSgAwIBAgIUImUM1lqdNInzg7SVUr9QGzknBqwwCgYIKoZIzj0EAwIwaDEaMBgGA1UEAwwRSW50ZWwgU0dYIFJvb3QgQ0ExGjAYBgNVBAoMEUludGVsIENvcnBvcmF0aW9uMRQwEgYDVQQHDAtTYW50YSBDbGFyYTELMAkGA1UECAwCQ0ExCzAJBgNVBAYTAlVTMB4XDTE4MDUyMTEwNDExMVoXDTMzMDUyMTEwNDExMFowaDEaMBgGA1UEAwwRSW50ZWwgU0dYIFJvb3QgQ0ExGjAYBgNVBAoMEUludGVsIENvcnBvcmF0aW9uMRQwEgYDVQQHDAtTYW50YSBDbGFyYTELMAkGA1UECAwCQ0ExCzAJBgNVBAYTAlVTMFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEC6nEwMDIYZOj/iPWsCzaEKi71OiOSLRFhWGjbnBVJfVnkY4u3IjkDYYL0MxO4mqsyYjlBalTVYxFP2sJBK5zlKOBuzCBuDAfBgNVHSMEGDAWgBQiZQzWWp00ifODtJVSv1AbOScGrDBSBgNVHR8ESzBJMEegRaBDhkFodHRwczovL2NlcnRpZmljYXRlcy50cnVzdGVkc2VydmljZXMuaW50ZWwuY29tL0ludGVsU0dYUm9vdENBLmNybDAdBgNVHQ4EFgQUImUM1lqdNInzg7SVUr9QGzknBqwwDgYDVR0PAQH/BAQDAgEGMBIGA1UdEwEB/wQIMAYBAf8CAQAwCgYIKoZIzj0EAwIDSQAwRgIhAIpQ/KlO1XE4hH8cw5Ol/E0yzs8PToJe9Pclt+bhfLUgAiEAss0qf7FlMmAMet+gbpLD97ldYy/wqjjmwN7yHRVr2AM=");
                X509Certificate2 certificate = new X509Certificate2(certBuffer);
                var jwks = new JSONWebKeySet();
                var jwk = new JSONWebKey() { Kty = "RSA" };
                jwk.X5c = new List<string>() { System.Convert.ToBase64String(certificate.Export(X509ContentType.Cert)) };
                jwks.Keys = new List<JSONWebKey>() { jwk };

                var instanceParams = new AttestationServiceCreationParams {  PolicySigningCertificates = jwks};
                try
                {
                    var createdAttestation = testBase.client.AttestationProviders.Create(
                        resourceGroupName: testBase.rgName,
                        providerName: testBase.attestationName,
                        creationParams: instanceParams
                    );
                    ValidateAttestationProvider(createdAttestation,
                        testBase.attestationName,
                        testBase.rgName,
                        testBase.subscriptionId);

                   testBase.client.AttestationProviders.Get(
                        resourceGroupName: testBase.rgName,
                        providerName: testBase.attestationName);
                }
                finally 
                {
                    testBase.client.AttestationProviders.Delete(
                        resourceGroupName: testBase.rgName,
                        providerName: testBase.attestationName);

                }
            }
        }

        private void ValidateAttestationProvider(
            AttestationProvider attestaton,
            string expectedAttestationName,
            string expectedResourceGroupName,
            string expectedSubId)
        {
            Assert.NotNull(attestaton);
            Assert.Equal(expectedAttestationName, attestaton.Name);
            string resourceIdFormat = "subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Attestation/attestationProviders/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedAttestationName);
            Assert.Equal(expectedResourceId, attestaton.Id);
        }
    }
}


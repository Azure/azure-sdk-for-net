
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
using System.Diagnostics;
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

                var creationParams = new AttestationServiceCreationParams
                {
                    Location = testBase.location,
                    Tags = new Dictionary<string, string>
                    {
                        { "Key1", "Value1" },
                        { "Key2", "Value2" }
                    },
                    Properties  = new AttestationServiceCreationSpecificParams
                    {
                        PolicySigningCertificates = jwks
                    }
                };
                try
                {
                    var createdAttestation = testBase.client.AttestationProviders.Create(
                        resourceGroupName: testBase.rgName,
                        providerName: testBase.attestationName,
                        creationParams: creationParams
                    );
                    ValidateAttestationProvider(createdAttestation,
                        testBase.attestationName,
                        testBase.rgName,
                        testBase.subscriptionId,
                        creationParams);

                    testBase.client.AttestationProviders.Get(
                        resourceGroupName: testBase.rgName,
                        providerName: testBase.attestationName);

                    // Get EUS Test default provider and validate
                    string defaultProviderName = "sharedeus";
                    string defaultProviderLocation = "East US";
                    var defaultProvider = testBase.client.AttestationProviders.GetDefaultByLocation(location: defaultProviderLocation);

                    ValidateDefaultProvider(defaultProvider,
                        defaultProviderName,
                       defaultProviderLocation);

                    // List all Test default providers and validate
                    var defaultProviderList =  testBase.client.AttestationProviders.ListDefault();
                    ValidateDefaultProviderList(defaultProviderList);
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
            AttestationProvider attestation,
            string expectedAttestationName,
            string expectedResourceGroupName,
            string expectedSubId,
            AttestationServiceCreationParams creationParams)
        {
            Assert.NotNull(attestation);
            Assert.Equal(expectedAttestationName, attestation.Name);

            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Attestation/attestationProviders/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedResourceGroupName, expectedAttestationName);
            Assert.Equal(expectedResourceId, attestation.Id);

            if (creationParams.Tags != null)
            {
                Assert.Equal(attestation.Tags.Count, creationParams.Tags.Count);
                Assert.False(creationParams.Tags.Except(attestation.Tags).Any());
                Assert.False(attestation.Tags.Except(creationParams.Tags).Any());
            }
            else
            {
                Assert.Null(attestation.Tags);
            }

            Assert.True(creationParams.Location.Equals(attestation.Location, StringComparison.InvariantCultureIgnoreCase));
        }

        private void ValidateDefaultProvider(
            AttestationProvider defaultProvider,
            string expectedAttestationName,
            string expectedLocation =  "")
        {
            Assert.NotNull(defaultProvider);
            Assert.Equal(expectedAttestationName, defaultProvider.Name);

            string resourceIdFormat = "/providers/Microsoft.Attestation/attestationProviders/{0}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedAttestationName);
            Assert.Equal(expectedResourceId, defaultProvider.Id);

            Assert.Null(defaultProvider.Tags);
            if (!string.IsNullOrEmpty(expectedLocation))
            {
                Assert.True(expectedLocation.Equals(defaultProvider.Location, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        private void ValidateDefaultProviderList(AttestationProviderListResult defaultProviderList)
        {
            Assert.NotNull(defaultProviderList);
            Assert.IsType<AttestationProviderListResult>(defaultProviderList);
            Assert.True(defaultProviderList.Value.Count > 0);

            string resourceIdFormat = "/providers/Microsoft.Attestation/attestationProviders/shared";
            string nameFormat = "shared";

            foreach (AttestationProvider defaultProvider in defaultProviderList.Value)
            {
                Assert.StartsWith(nameFormat, defaultProvider.Name);
                Assert.StartsWith(resourceIdFormat, defaultProvider.Id);
                Assert.Null(defaultProvider.Tags);
                Assert.NotEmpty(defaultProvider.Location);
                Assert.StartsWith("https://" + defaultProvider.Name, defaultProvider.AttestUri);
                Assert.EndsWith("attest.azure.net", defaultProvider.AttestUri);
            }
        }
    }
}


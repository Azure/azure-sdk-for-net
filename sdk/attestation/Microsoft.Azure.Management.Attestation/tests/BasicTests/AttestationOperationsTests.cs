
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.Management.Attestation.Models;
using Microsoft.Azure.Management.ResourceManager;
using Attestation.Management.ScenarioTests;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
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
            var mode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new AttestationTestBase(context);
                testBase.apiVersion = testBase.apiVersion;
                //create
                var createdAttestation = testBase.client.AttestationProviders.Create(
                    resourceGroupName: testBase.rgName,
                    providerName: testBase.attestationName,
                    creationParams: new AttestationServiceCreationParams { }
                );


                ValidateAttestationProvider(createdAttestation,
                    testBase.attestationName,
                    testBase.rgName,
                    testBase.subscriptionId);
                //get
                var retrievedAttestation = testBase.client.AttestationProviders.Get(
                    resourceGroupName: testBase.rgName,
                    providerName: testBase.attestationName);

                // Delete
                testBase.client.AttestationProviders.Delete(
                    resourceGroupName: testBase.rgName,
                    providerName: testBase.attestationName);
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


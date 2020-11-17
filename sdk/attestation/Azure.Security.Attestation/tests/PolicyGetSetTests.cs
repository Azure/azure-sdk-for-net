// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Security.Attestation.Models;
using Azure.Identity;
using Azure.Security.Attestation.Tests.Samples;

namespace Azure.Security.Attestation.Tests
{
    public class PolicyGetSetTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        public PolicyGetSetTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetPolicy()
        {
            var adminclient = GetAadAdministrationClient();
            var attestClient = GetAadAttestationClient();

            AttestationSigner[] signingCertificates = attestClient.GetSigningCertificates();

            var policyResult = await adminclient.GetPolicyAsync(AttestationType.SgxEnclave);
            var result = policyResult.Value.AttestationPolicy;

        }

        private AttestationClient GetAadAttestationClient()
        {
            string endpoint = TestEnvironment.AadAttestationUrl;

            var options = InstrumentClientOptions(new AttestationClientOptions());
            return InstrumentClient(new AttestationClient(new Uri(endpoint), new DefaultAzureCredential(), options));
        }

        private AttestationAdministrationClient GetAadAdministrationClient()
        {
            string endpoint = TestEnvironment.AadAttestationUrl;

            var options = InstrumentClientOptions(new AttestationClientOptions());
            return InstrumentClient(new AttestationAdministrationClient(new Uri(endpoint), new DefaultAzureCredential(), options));
        }

    }
}

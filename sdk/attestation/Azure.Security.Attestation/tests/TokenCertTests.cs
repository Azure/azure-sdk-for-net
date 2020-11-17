﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class TokenCertTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        public TokenCertTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetCertificates()
        {
            AttestationClient attestationClient = GetAttestationClient();

            AttestationSigner[] certs = await attestationClient.GetSigningCertificatesAsync();

            Assert.AreNotEqual(0, certs.Length);

            return;
        }

        [RecordedTest]
        public async Task AttestSgx()
        {
            AttestationServiceAttestationSamples samples = new AttestationServiceAttestationSamples();
            await samples.AttestingAnSgxEnclave();
        }

        private AttestationClient GetAttestationClient()
        {
            string endpoint = TestEnvironment.AadAttestationUrl;

            var options = InstrumentClientOptions(new AttestationClientOptions());
            return InstrumentClient(new AttestationClient(new Uri(endpoint), new DefaultAzureCredential(), options));
        }
    }
}

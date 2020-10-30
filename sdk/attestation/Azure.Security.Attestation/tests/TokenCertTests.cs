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
    public class TokenCertTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        public TokenCertTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Live)
        {
        }

        [Test]
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
            await Task.Yield();
            samples.SettingAttestationPolicy();
            return;
        }

        private AttestationClient GetAttestationClient()
        {
            string endpoint = TestEnvironment.SharedUkSouth;

            /*TokenCredential credential = TestEnvironment.Credential;*/

            var options = InstrumentClientOptions(new AttestationClientOptions());
            string powerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
            return InstrumentClient(new AttestationClient(new Uri(endpoint), new InteractiveBrowserCredential(null, powerShellClientId), options));
        }
    }
}

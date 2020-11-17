// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.Attestation.Tests
{
    public class AttestationClientTestEnvironment : TestEnvironment
    {
        public AttestationClientTestEnvironment() : base("attestation")
        {
        }

        public string IsolatedAttestationUrl => GetRecordedVariable("ISOLATED_ATTESTATION_URL");
        public string AadAttestationUrl => GetRecordedVariable("AAD_ATTESTATION_URL");

        public string PolicyCertificate0 => GetRecordedVariable("policySigningCertificates0");
        public string PolicyCertificate1 => GetRecordedVariable("policySigningCertificates1");
        public string PolicyCertificate2 => GetRecordedVariable("policySigningCertificates2");
        public string PolicyManagementCertificate => GetRecordedVariable("policySigningCertificates");

        public string SharedEusTest => "https://sharedeus.eus.test.attest.azure.net";
        public string SharedUkSouth => "https://shareduks.uks.test.attest.azure.net";
    }
}

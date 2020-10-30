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

        public string KeyVaultUri => GetRecordedVariable("KEYVAULT_URL");

        public string SharedEusTest => "https://sharedeus.eus.test.attest.azure.net";
        public string SharedUkSouth => "https://shareduks.uks.test.attest.azure.net";
    }
}

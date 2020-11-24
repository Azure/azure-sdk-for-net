// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Security.Attestation.Tests
{
    public class AttestationClientTestEnvironment : TestEnvironment
    {
        public AttestationClientTestEnvironment() : base("attestation")
        {
        }

        public string IsolatedAttestationUrl => GetRecordedVariable("ISOLATED_ATTESTATION_URL");
        public string AadAttestationUrl => GetRecordedVariable("AAD_ATTESTATION_URL");

        public X509Certificate2 PolicyCertificate0 => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("policySigningCertificate0")));
        public X509Certificate2 PolicyCertificate1 => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("policySigningCertificate1")));
        public X509Certificate2 PolicyCertificate2 => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("policySigningCertificate2")));

        public RSA PolicySigningKey0 => new RSACng(CngKey.Import(Convert.FromBase64String(GetRecordedVariable("policySigningKey0")), CngKeyBlobFormat.Pkcs8PrivateBlob));
        public RSA PolicySigningKey1 => new RSACng(CngKey.Import(Convert.FromBase64String(GetRecordedVariable("policySigningKey1")), CngKeyBlobFormat.Pkcs8PrivateBlob));
        public RSA PolicySigningKey2 => new RSACng(CngKey.Import(Convert.FromBase64String(GetRecordedVariable("policySigningKey2")), CngKeyBlobFormat.Pkcs8PrivateBlob));

        // Policy management keys.
        public X509Certificate2 PolicyManagementCertificate => new X509Certificate2(Convert.FromBase64String(GetRecordedVariable("isolatedSigningCertificate")));
        public RSA PolicyManagementKey => new RSACng(CngKey.Import(Convert.FromBase64String(GetRecordedVariable("isolatedSigningKey")), CngKeyBlobFormat.Pkcs8PrivateBlob));

        public string SharedEusTest => "https://sharedeus.eus.test.attest.azure.net";
        public string SharedUkSouth => "https://shareduks.uks.test.attest.azure.net";

        public string ActiveDirectoryTenantId => GetRecordedVariable("TENANT_ID");
        public string ActiveDirectoryApplicationId => GetRecordedVariable("CLIENT_ID");
        public string ActiveDirectoryClientSecret => GetRecordedVariable("CLIENT_SECRET");

        private static Uri DataPlaneScope => new Uri($"https://attest.azure.net");

        public TokenCredential GetClientSecretCredential() => Credential;
    }
}
